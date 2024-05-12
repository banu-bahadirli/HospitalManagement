
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi.";
        public static string ProductDeleted = "Ürün başarıyla silindi.";
        public static string ProductUpdated = "Ürün başarıyla güncellendi.";
        public static string ProductAlreadyExists = "Aynı ürün kodu ile kayıt zaten mevcut";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu.";

        public static string BuildingAdded = "Bina başarıyla eklendi.";
        public static string BuildingDeleted = "Bina başarıyla silindi.";
        public static string BuildingUpdated = "Bina başarıyla güncellendi.";
		public static string BuildingAlreadyExists = "Aynı bina ismi ile kayıt zaten mevcut";

		public static string RoomAdded = "Oda başarıyla eklendi.";
        public static string RoomDeleted = "Oda başarıyla silindi.";
        public static string RoomUpdated = "Oda başarıyla güncellendi.";
        public static string RoomAlreadyExists = "Aynı oda ismi ile kayıt zaten mevcut";

        public static string StoreAdded = "Depo başarıyla eklendi.";
        public static string StoreDeleted = "Depo başarıyla silindi.";
        public static string StoreUpdated = "Depo başarıyla güncellendi.";
    }
}
