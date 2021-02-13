using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarNameInvalid = "araba ismi Geçersiz.";
        public static string MaintenanceTime= "Sistem başarıyla bakımda.";
        public static string CarListed = "Araba başarıyla listelendi.";
        public static string CarDelete= "Araba başarıyla silindi.";
        public static string CarUpdated = "Araba başarıyla güncellendi.";
        public static string CarPriceInvalid= "Ürün fiyatı geçersiz.Lütfen Girdiğiniz fiyat kısmı 0'dan büyük giriniz.";
        public static string BrandAdded = "Marka Başarıyla Eklendi.";
        public static string BrandNameInvalid = "Marka isminin uzunluğunu 2 karakterden fazla giriniz.";
        public static string BrandDelete= "Marka başarıyla silindi.";
        public static string BrandUpdate= "Marka başarıyla Güncellendi.";
        public static string BrandListed= "Marka başarıyla listelendi.";
        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorDelete = "Renk başarıyla silindi.";
        public static string ColorListed= "Renkler başarıyla listelendi.";
        public static string ColorUpdated= "Renk başarıyla güncellendi";
        public static string UsingAdded ="Kullanıcı Başarıyla eklendi.";
        public static string UserUpdate="Kullıcı başarıyla güncelendi.";
        public static string RentalAddedError= "Aracın kiraya verilebilmesi için önce teslim edilmesi gerekir.";
        public static string RentalAdded= "Kiralama işlemi başarılı";
        public static string RentalDelete="Kiralama işlemi başarıyla silindi";
        public static string RentalUpdate="Kiralama işlemi başarıyla güncellendi";
    }
}
