using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesLYL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace SalesLYL.Models
{
    public class DbRepository
    {

        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["dbConnectString"].ConnectionString;
            con = new SqlConnection(constring);
        }
        public List<SalesHead> getSalheadList()
        {
            List<SalesHead> salHeadList = new List<SalesHead>();
            connection();
            
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_sal_head", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                SalesHead salHead = default(SalesHead);
                while (rdr.Read())
                {

                    salHead = Activator.CreateInstance<SalesHead>();
                    foreach (PropertyInfo prop in salHead.GetType().GetProperties())
                    {
                        if (!object.Equals(rdr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(salHead, rdr[prop.Name], null);
                        }
                    }
                    salHeadList.Add(salHead);
                }
                rdr.Close();
                con.Close();
            
            return salHeadList;
        }

        public SalesInvoice getSalInvoiceDetail(int? id, string type)
        {
            SalesInvoice salInvoice = new SalesInvoice();

            if (id == null || type == null)
            {
                return salInvoice;
            }
            List<SalesItem> salItemList = new List<SalesItem>();
            connection();
                string selectionQuery = "SELECT * FROM tbl_sal_head where docNum = '"+ id +"' and docType = '"+type+"'";
                string selectionQuery2 = "SELECT * FROM tbl_sal_item where docNum = '"+ id +"' and docType = '"+type+"'";



                SqlCommand cmd = new SqlCommand(selectionQuery, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                SalesHead salesHead = default(SalesHead);
                if (dr.Read())
                {
                    salesHead = Activator.CreateInstance<SalesHead>();
                    foreach (PropertyInfo prop in salesHead.GetType().GetProperties())
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(salesHead, dr[prop.Name], null);
                        }
                    }


                    salInvoice.salesHead = salesHead;
                    dr.Close();

                    SqlCommand cmd2 = new SqlCommand(selectionQuery2, con);
                    cmd2.CommandType = CommandType.Text;


                    SqlDataReader rdr = cmd2.ExecuteReader();
                    SalesItem salesItem = default(SalesItem);
                    while (rdr.Read())
                    {

                        salesItem = Activator.CreateInstance<SalesItem>();
                        foreach (PropertyInfo prop in salesItem.GetType().GetProperties())
                        {
                            if (!object.Equals(rdr[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(salesItem, rdr[prop.Name], null);
                            }
                        }
                        salItemList.Add(salesItem);
                    }

                    salInvoice.salesItemList = salItemList;
                    rdr.Close();
            }
                               
                con.Close();
            
            return salInvoice;
        }

        public bool DeleteSalesInvoice(int? id, string type)
        {

            connection();
            string selectionQuery = "Delete FROM tbl_sal_head where docNum = '" + id + "' and docType = '" + type + "'";
            string selectionQuery2 = "Delete FROM tbl_sal_item where docNum = '" + id + "' and docType = '" + type + "'";
            SqlCommand cmd = new SqlCommand(selectionQuery2, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            bool result = false;

            if (i >= 1) {

                SqlCommand cmd2 = new SqlCommand(selectionQuery, con);
                int i2 = cmd2.ExecuteNonQuery();
                //to do item-head delete fail case rollback,begin and commit tran.

                result = true;


            }
            else {
                result = false;
            }
               
            con.Close();
            
                return result;
        }

        public SalesGeneral InsertSalesInvoice(SalesGeneral salGen)
        {
            connection();
            con.Open();
            var date = "";
            if (salGen.salesHead.address == null) { salGen.salesHead.address = " "; }
            if (salGen.salesHead.city == null) { salGen.salesHead.city = "Istanbul"; }
            if (salGen.salesHead.country == null) { salGen.salesHead.country = "TR"; }
            if (salGen.salesHead.currency == null) { salGen.salesHead.currency = "TL"; }
            if (salGen.salesHead.custName1 == null) { salGen.salesHead.custName1 = " "; }
            if (salGen.salesHead.custName2 == null) { salGen.salesHead.custName2 = " "; }          
            if (salGen.salesHead.docDate == null) {
                 date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                date = salGen.salesHead.docDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (salGen.salesHead.docType == null) { salGen.salesHead.docType = "F1"; }
            if (salGen.salesHead.email == null) { salGen.salesHead.email = " "; }          
            if (salGen.salesHead.hCurrency == null) { salGen.salesHead.hCurrency = "TL"; }

            string docnum = " select Max(docNum) as docnum from tbl_sal_head ";
            long docNum = 0;
            SqlCommand cmd0 = new SqlCommand(docnum, con);
            SqlDataReader dr = cmd0.ExecuteReader();
            if (dr.Read())
            {
                docNum = Convert.ToInt32(dr["docnum"]);


            }
            dr.Close();

            if(docNum == 0)
            {
                docNum = 100000000;
            }
            else
            {
                docNum = docNum + 1;

            }

            salGen.salesHead.docNum = docNum;
            int itemnum = 10;
            salGen.salesHead.discount = 0;
            salGen.salesHead.subTotal = 0;
            for (int x = 0; x < salGen.salesItemList.Count;x++)
            {
                if (salGen.salesItemList[x].quantity <= 0)
                {
                    continue;
                }
                salGen.salesItemList[x].docType = salGen.salesHead.docType;
                salGen.salesItemList[x].docNum = salGen.salesHead.docNum;
                salGen.salesItemList[x].itemNum = itemnum;
                itemnum = itemnum + 10;
                salGen.salesItemList[x].subTotal = salGen.salesItemList[x].quantity* salGen.salesItemList[x].price;
                salGen.salesItemList[x].grandTotal = salGen.salesItemList[x].subTotal  - salGen.salesItemList[x].discount;

                salGen.salesHead.discount = salGen.salesHead.discount + salGen.salesItemList[x].discount;
                salGen.salesHead.subTotal = salGen.salesHead.subTotal + salGen.salesItemList[x].subTotal;           
              

            }
            salGen.salesHead.grandTotal = salGen.salesHead.subTotal - salGen.salesHead.discount;

            string selectionQuery = "INSERT INTO tbl_sal_head (address,city,country,currency,custName1,custName2,customerId,discount,docChar,docDate,docNum,docType,email,exRate,grandTotal,hCurrency,phone,subTotal) VALUES('" + salGen.salesHead.address
                + "','" + salGen.salesHead.city
                + "','" + salGen.salesHead.country
                + "','" + salGen.salesHead.currency
                + "','" + salGen.salesHead.custName1
                + "','" + salGen.salesHead.custName2
                + "'," + salGen.salesHead.customerId
                + "," + salGen.salesHead.discount
                + "," + salGen.salesHead.docChar
                + ",'" + date
                + "'," + salGen.salesHead.docNum
                + ",'" + salGen.salesHead.docType
                + "','" + salGen.salesHead.email
                + "'," + salGen.salesHead.exRate
                + "," + salGen.salesHead.grandTotal
                + ",'" + salGen.salesHead.hCurrency
                + "'," + salGen.salesHead.phone
                + "," + salGen.salesHead.subTotal + ")";

         
           
            SqlCommand cmd = new SqlCommand(selectionQuery, con);
          //  con.Open();
            int i = cmd.ExecuteNonQuery();
            bool result = false;

            if (i >= 1)
            {

                foreach (var item in salGen.salesItemList)
                {
                    if (item.quantity <= 0)
                    {
                        continue;
                    }
                    string selectionQuery2 = "INSERT INTO tbl_sal_item (currency,discount,docNum,docType,grandTotal,itemNum,material,price,quantity,subTotal,unit,variantOptions) VALUES('" +
                   item.currency
                   + "'," + item.discount
                   + "," + item.docNum
                   + ",'" + item.docType
                   + "'," + item.grandTotal
                   + "," + item.itemNum
                   + ",'" + item.material
                   + "'," + item.price
                   + "," + item.quantity
                   + "," + item.subTotal
                   + ",'" + item.unit
                   + "','" + item.variantOptions
                   + "')";

                    SqlCommand cmd2 = new SqlCommand(selectionQuery2, con);
                    int i2 = cmd2.ExecuteNonQuery();
                    //to do item-head delete fail case rollback,begin and commit tran.

                }



                result = true;


            }
            else
            {
                result = false;
            }

            con.Close();
            salGen.resultInserted = result;

            return salGen;
        }
        public SalesGeneral UpdateSalesInvoice(SalesGeneral salGen,SalesHead oldh,List<SalesItem> oldit)
        {
            connection();
            con.Open();
            var date = "";
            if (salGen.salesHead.address == null) { salGen.salesHead.address = oldh.address; }
            if (salGen.salesHead.city == null) { salGen.salesHead.city = oldh.city; }
            if (salGen.salesHead.country == null) { salGen.salesHead.country = oldh.country; }
            if (salGen.salesHead.currency == null) { salGen.salesHead.currency = oldh.currency; }
            if (salGen.salesHead.custName1 == null) { salGen.salesHead.custName1 = oldh.custName1; }
            if (salGen.salesHead.custName2 == null) { salGen.salesHead.custName2 = oldh.custName2; }
            if (salGen.salesHead.docDate == null)
            {
                date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                date = salGen.salesHead.docDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (salGen.salesHead.docType == null) { salGen.salesHead.docType = oldh.docType; }
            if (salGen.salesHead.email == null) { salGen.salesHead.email = oldh.email; }
            if (salGen.salesHead.hCurrency == null) { salGen.salesHead.hCurrency = oldh.hCurrency; }

            // --todo dochead and item existing check
            // --todo new item insert and delete item feature 
            if (salGen.salesHead.docNum == 0)
            {

                salGen.resultUpdated = false;

                return salGen;
            }
            salGen.salesHead.discount = 0;
            salGen.salesHead.subTotal = 0;
            for (int x = 0; x < salGen.salesItemList.Count; x++)
            {
                if (salGen.salesItemList[x].currency == null) { salGen.salesItemList[x].currency = oldit[x].currency; }
                if (salGen.salesItemList[x].material == null) { salGen.salesItemList[x].material = oldit[x].material; }
                if (salGen.salesItemList[x].unit == null) { salGen.salesItemList[x].unit = oldit[x].unit; }
                if (salGen.salesItemList[x].variantOptions == null) { salGen.salesItemList[x].variantOptions = oldit[x].variantOptions; }
                if (salGen.salesItemList[x].price <= 0) { salGen.salesItemList[x].price = oldit[x].price; }
                if (salGen.salesItemList[x].quantity <= 0)
                {
                    salGen.salesItemList[x].quantity = oldit[x].quantity;
                }
                salGen.salesItemList[x].docType = salGen.salesHead.docType;
                salGen.salesItemList[x].docNum = salGen.salesHead.docNum;              
                salGen.salesItemList[x].subTotal = salGen.salesItemList[x].quantity * salGen.salesItemList[x].price;
                salGen.salesItemList[x].grandTotal = salGen.salesItemList[x].subTotal - salGen.salesItemList[x].discount;

                salGen.salesHead.discount = salGen.salesHead.discount + salGen.salesItemList[x].discount;
                salGen.salesHead.subTotal = salGen.salesHead.subTotal + salGen.salesItemList[x].subTotal;


            }
            salGen.salesHead.grandTotal = salGen.salesHead.subTotal - salGen.salesHead.discount;

            string selectionQuery = "UPDATE tbl_sal_head SET address ='" + salGen.salesHead.address
                + "', city ='" + salGen.salesHead.city
                + "',country ='" + salGen.salesHead.country
                + "',currency='" + salGen.salesHead.currency
                + "',custName1='" + salGen.salesHead.custName1
                + "',custName2='" + salGen.salesHead.custName2
                + "',discount=" + salGen.salesHead.discount
                + ",email='" + salGen.salesHead.email
                + "',grandTotal=" + salGen.salesHead.grandTotal
                + ",phone=" + salGen.salesHead.phone
                + ",subTotal=" + salGen.salesHead.subTotal
                + " Where docNum ="+ salGen.salesHead.docNum
                  + " and docType='" + salGen.salesHead.docType+"'"
                ;



            SqlCommand cmd = new SqlCommand(selectionQuery, con);
            //  con.Open();
            int i = cmd.ExecuteNonQuery();
            bool result = false;

            if (i >= 1)
            {

                foreach (var item in salGen.salesItemList)
                {
                    
                    string selectionQuery2 = "Update tbl_sal_item SET currency='" +
                   item.currency
                   + "',discount=" + item.discount
                   + ",grandTotal=" + item.grandTotal
                   + ",material='" + item.material
                   + "',price=" + item.price
                   + ",quantity=" + item.quantity
                   + ",subTotal=" + item.subTotal
                   + ",unit='" + item.unit
                   + "',variantOptions='" + item.variantOptions                   
                + "' Where docNum =" + item.docNum
                  + " and docType='" + item.docType + "'"
                  + " and itemNum=" + item.itemNum 
                ;

                    SqlCommand cmd2 = new SqlCommand(selectionQuery2, con);
                    int i2 = cmd2.ExecuteNonQuery();
                    //to do item-head delete fail case rollback,begin and commit tran.

                }



                result = true;


            }
            else
            {
                result = false;
            }

            con.Close();
            salGen.resultUpdated = result;

            return salGen;
        }
    }
}