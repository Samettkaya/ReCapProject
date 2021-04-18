using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string CarDelete = "Araba başarıyla silindi.";
        public static string CarUpdated = "Araba başarıyla güncellendi.";
        public static string CarPriceInvalid = "Ürün fiyatı geçersiz.Lütfen girdiğiniz fiyat kısmı 0'dan büyük giriniz.";

        // Brand Messages
        public static string BrandAdded = "Marka başarıyla Eklendi.";
        public static string BrandNameInvalid = "Marka isminin uzunluğunu 2 karakterden fazla giriniz.";
        public static string BrandDelete = "Marka başarıyla silindi.";
        public static string BrandUpdate = "Marka başarıyla Güncellendi.";
        public static string BrandListed = "Markalar başarıyla listelendi.";
        public static string BrandList = "Marka başarıyla listelendi";

        // Color Messages
        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorDelete = "Renk başarıyla silindi.";
        public static string ColorListed = "Renkler başarıyla listelendi.";
        public static string ColorUpdated = "Renk başarıyla güncellendi";

        // User Messages
        public static string UserListed = "Kullanıcılar başarıyla listelendi";
        public static string UserList = "Kullanıcı başarıyla listelendi";
        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UserUpdate = "Kullıcı başarıyla güncelendi.";
        public static string UserDelete = "Kişi başarıyla Silindi";

        // Rental Messages
        public static string RentalAddedError = "Aracın kiraya verilebilmesi için önce teslim edilmesi gerekir.";
        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string RentalDelete = "Kiralama işlemi başarıyla silindi";
        public static string RentalUpdate = "Kiralama işlemi başarıyla güncellendi";
        public static string RentalListed = "Kiralanan arabalar başarıyla listelendi";
        public static string GetErrorRentalMessage = "Araç kiralama işlemi bilgileri getirilemedi.";
        public static string GetSuccessRentalMessage = "Araç kiralama işlemi bilgileri getirildi.";
        public static string CarDelivered = "Araç teslim edildi";
        public static string CarAlreadyDelivered = "Araç daha önce teslim edilmiş";

        // CarImage Messages
        //CarImage
        public static string CarImageAdded = "Araba Resmi Eklendi.";
        public static string CarImageUpdate = "Araba Resmi Güncellendi";
        public static string CarImageDelete = "Araba Resmi Silindi";
        public static string CarImageListed = "Araba Resmi Listelendi";
        public static string CarImageAddingLimit = "Araba sisteminde en fazla 5 resim eklenebilir";
        public static string IncorrectFileExtension = " Resmi dosya uzantısı  yanlıştır";
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string SuccessfulLogin = "Sisteme başarıyla giriş yapıldı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Giriş Yapıldı";

        public static string GetSuccessCustomerMessage = "Müşteri bilgileri getirildi";
        public static string GetErrorCarMessage = "Araç bilgisi getirilemedi.";
        public static string PasswordChanged = "Şifre değiştirildi";
        public static string PaymentSuccessful = "Ödeme tamamlandı";
        public static string CardAdded ="Kart Eklendi";
        public static string CardDelete = "Kartınız Silindi";

        public static string FindexScoreAdded = "Findeks skoru eklendi.";
        public static string FindexScoreDeleted = "Findeks skoru silindi.";
        public static string FindexScoreListed  = "Findeks skorları listelendi.";
        public static string FindexScoreNotFound = "Findeks skoru bulunamadı.";
        public static string FindexScoreUpdated = "Findeks skoru güncellendi.";
        public static string FindeksScoreNotFound = "Findeks skoru bulunamadı.";
        public static string FindeksScoreInsufficient = "Findeks skoru yetersiz.";

    }
}
