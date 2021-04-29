using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi.";
        public static string ProductDeleted = "Ürün başarıyla silindi.";
        public static string ProductUpdated = "Ürün başarıyla güncellendi.";


        public static string CategoryAdded = "Kategori başarıyla eklendi.";
        public static string CategoryDeleted = "Kategori başarıyla silindi.";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi.";

        public static string SecurityKeyError = "Güvenlik anahtarı çözülemiyor.";
        public static string ClientKeyError = "Client key hatalı";


        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı";
        public static string successfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists= "Bu kullanıcı zaten kayıtlı.";
        public static string UserRegistered="Kullanıcı başarıyla kayıt edildi";
        public static string AccessTokenCreated="Access Token Başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string ProductNameAlreadyExists="Ürün ismi zaten mevcut";
    }
}
