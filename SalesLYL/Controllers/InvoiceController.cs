using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using SalesLYL.Models;
using System.Data.SqlClient;
using System.Net;
using SalesLYL.Models.Mock;

namespace SalesLYL.Controllers
{
    public class InvoiceController : Controller
    {
        DbRepository conn = new DbRepository();
        // GET: Invoice
        public ActionResult InvoiceList()
        {           
            
            return View(conn.getSalheadList());
        }

      
        // GET: Invoice/Details/5
        public ActionResult Details(int? id,string type)
        {

            if (id == null || type == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var salesInvoice = conn.getSalInvoiceDetail(id, type);
            
            if (salesInvoice == null)
            {
                return HttpNotFound();
            }
        
            return View(salesInvoice);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            SalesGeneral sGeneral = new SalesGeneral();
            SalesHead sh = new SalesHead();
            List<SalesItem> sl = new List<SalesItem>();
            SalesItem si = new SalesItem();
            si.itemNum = 10;
         
            sh.docDate =  DateTime.Today;
            sl.Add(si);
            SalesItem si2 = new SalesItem();
           
            si2.itemNum = 20;
            sl.Add(si2);
            SalesItem si3 = new SalesItem();
            
            si3.itemNum = 30;
            sl.Add(si3);
            sh.city = "İstanbul";
            sh.currency = "TL";
            sh.country = "TR";
            sh.docType = "F1";
            sGeneral.salesHead = sh;
            sGeneral.salesItemList = sl;
            fillViewBag();
            return View(sGeneral);
        }

        // POST: Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            SalesGeneral salGen
            ,FormCollection collection)
        {
            fillViewBag();

            try
            {
                if (salGen == null )
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                salGen.resultInserted = false;
                salGen = conn.InsertSalesInvoice(salGen);

                if (salGen.resultInserted == false)
                {
                    ViewBag.Message("Process failed !");
                    return View(salGen);
                }


                return RedirectToAction("InvoiceList");
                // TODO: Add insert logic here

            }
            catch
            {
                return View(salGen);
            }
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int? id, string type)
        {
            fillViewBag();
            SalesGeneral sGeneral = new SalesGeneral();

            if (id == null || type == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var salesInvoice = conn.getSalInvoiceDetail(id, type);
            sGeneral.salesHead = salesInvoice.salesHead;
            sGeneral.salesItemList = salesInvoice.salesItemList;

            ViewBag.SalHead = sGeneral.salesHead;
            ViewBag.SalItemList = sGeneral.salesItemList;
            if (salesInvoice == null)
            {
                return HttpNotFound();
            }

            return View(sGeneral);
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string type,SalesGeneral salGen, FormCollection collection)
        {
            fillViewBag();
            var salesInvoice = conn.getSalInvoiceDetail(id, type);
            SalesHead shold = salesInvoice.salesHead;
            List<SalesItem> siOldlist = salesInvoice.salesItemList;
            try
            {
                if (salGen == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                salGen.resultUpdated = false;
                salGen = conn.UpdateSalesInvoice(salGen, shold, siOldlist);

                if (salGen.resultUpdated == false)
                {
                    ViewBag.Message("Process failed !");
                    return View(salGen);
                }


                return RedirectToAction("InvoiceList");
                // TODO: Add insert logic here

            }
            catch
            {
                return View(salGen);
            }
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int? id, string type)
        {
            if (id == null || type == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var salesInvoice = conn.getSalInvoiceDetail(id, type);

            if (salesInvoice == null)
            {
                return HttpNotFound();
            }
            return View(salesInvoice);
        }

        public void fillViewBag()
        {

            DocTypeL page = new DocTypeL();
            ViewBag.DocType = page.getDocTypeList();
            UnitL page2 = new UnitL();
            ViewBag.Unit = page2.getUnitList();
            CountryL page3 = new CountryL();
            ViewBag.Country = page3.getCountryList();
            CityL page4 = new CityL();
            ViewBag.City = page4.getCityList();
            CurrencyL page5 = new CurrencyL();
            ViewBag.Currency = page5.getCurrencyList();
            VariantL page6 = new VariantL();
            ViewBag.Variant = page6.getVariantList();
            MaterialL page7 = new MaterialL();
            ViewBag.Material = page7.getMaterialList();
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, string type, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (id == null || type == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                bool resultDeletion = conn.DeleteSalesInvoice(id, type);

                if (resultDeletion == false)
                {
                    ViewBag.Message("Process failed !");
                    return View();
                }
              

                return RedirectToAction("InvoiceList");
            }
            catch
            {
                return View();
            }
        }
    }
}
