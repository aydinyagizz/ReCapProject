using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //sürekli new'lememek için static yaptık.
    {
        public static string CarAdded = "Ürün Eklendi.";
        public static string CarNameInValid = "Ürün İsmi Geçersiz.";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarListed = "Ürünler Listelendi";
        public static string ReturnCar = "Araba Henüz Teslim Edilmemiştir";
        public static string RentalAdded = "Arabalar Listelendi";
        public static string CarCountOfColorError = "Bir Renkte En Fazla 10 Araba Olabilir.";
        public static string CarNameAlreadyExists = "Bu İsimde Zaten Başka Bir Araba Var.";
        public static string CategoryLimitExceded = "Renk Kategori Limiti Aşıldığı İçin Yeni Ürün Eklenemiyor.";
    }
}
