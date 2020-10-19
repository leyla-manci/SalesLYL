using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models.Mock
{
    public class Enums
    {
    }
    public enum Currency
    {
        TL,
        EUR,
        USD,
        AU,
        GBP
    }
    public enum Country
    {
        TR,
        DUC,
        ABD,
        EN,
        US,
        UK
    }
    public enum City
    {
        Istanbul,
        Ankara,
        Hakkari,
        Hatay,
        Rize,
        Muğla
    }
    public enum Variant
    {
        Red_S,
        Red_M,
        Blue_L,
        Yellow_XL,
        Gray_Std,
        Brown_Std
    }
    public enum Material
    {
        Atkı,
        Bere,
        Şapka,
        Kulaklık,
        Kumaş,
        Mobilya
    }
    public enum Unit
    {
        AD, KG, M, BOX
    }
    public enum DocType
    {
        F1, F2, F3, F4, F5, I1, P1, C1
    }
}