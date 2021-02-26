using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem bakımda lütfen daha sınra tekrar deneyin.";

        // Car Messages
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarNameInvalid = "araba ismi Geçersiz.";
        public static string CarListed = "Arabalar başarıyla listelendi.";
        public static string CarDelete= "Araba başarıyla silindi.";
        public static string CarUpdated = "Araba başarıyla güncellendi.";
        public static string CarPriceInvalid= "Ürün fiyatı geçersiz.Lütfen girdiğiniz fiyat kısmı 0'dan büyük giriniz.";

        // Brand Messages
        public static string BrandAdded = "Marka başarıyla Eklendi.";
        public static string BrandNameInvalid = "Marka isminin uzunluğunu 2 karakterden fazla giriniz.";
        public static string BrandDelete= "Marka başarıyla silindi.";
        public static string BrandUpdate= "Marka başarıyla Güncellendi.";
        public static string BrandListed= "Markalar başarıyla listelendi.";
        public static string BrandList = "Marka başarıyla listelendi";

        // Color Messages
        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorDelete = "Renk başarıyla silindi.";
        public static string ColorListed= "Renkler başarıyla listelendi.";
        public static string ColorUpdated= "Renk başarıyla güncellendi";

        // User Messages
        public static string UserListed = "Kullanıcılar başarıyla listelendi";
        public static string UserList = "Kullanıcı başarıyla listelendi";
        public static string UserAdded ="Kullanıcı başarıyla eklendi.";
        public static string UserUpdate="Kullıcı başarıyla güncelendi.";
        public static string UserDelete = "Kişi başarıyla Silindi";

        // Rental Messages
        public static string RentalAddedError= "Aracın kiraya verilebilmesi için önce teslim edilmesi gerekir.";
        public static string RentalAdded= "Kiralama işlemi başarılı";
        public static string RentalDelete="Kiralama işlemi başarıyla silindi";
        public static string RentalUpdate="Kiralama işlemi başarıyla güncellendi";
        public static string RentalListed = "Kiralanan arabalar başarıyla listelendi";

        // CarImage Messages
        public static string CarImageAdded="Resim başarıyla eklendi";
        public static string CarImageLists = "Resimler başarıyla listelendi";
        public static string CarImageList = "Resim başarıyla listelendi ";
        public static string CarImageDelete="Resim başarıyla silindi";
        public static string CarImageUpdated="Resim başarıyla güncellendi";

      
    }
}
