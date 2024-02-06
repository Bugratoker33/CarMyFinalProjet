using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //static verdiğimizde clası newlemiyoruz 
        //direk messages. devam ediyoruz 
        public static string CarAdded = "Ürün eklendi";
        public static string CarNameInvalid = "Ürün ismi geçersiz"; //ınvalid = geçersiz:
        public static string MaintenanceTime = "Sistem Bakında";
        public static string CartsListed = "ürünler Listelendi";
        public static string CarDelete = "ürün silindi";
        public static string CarUpdate = "Ürün Güncellendi";
        public static string AuthorizationDenied = "YETKİNİZ YOK";
    }
}
