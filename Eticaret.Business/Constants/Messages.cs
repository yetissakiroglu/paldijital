using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Constants
{
    //Bu bölüm business için hata mesajları
    public static class Messages
    {
        public static string Creared = "Başarıyla Eklendi";
        public static string Deleted = "Başarıyla Silindi";
        public static string Updated = "Başarıyla Güncellendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string RefreshTokenTime = "Refresh token süresi dolmuş";
        public static string RefreshTokenNull = "Refresh token bulunamadı";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string NameAlreadyExists = "Bu isim zaten mevcut";

    }
}
