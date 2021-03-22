using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string SuccessAdded = "Başarıyla eklendi.";
		public static string SuccessDeleted = "Başarıyla silindi.";
		public static string SuccessUpdated = "Başarıyla güncellendi.";
		public static string SuccessListed = "Başarıyla listelendi.";
		
		public static string CarNameInvalid = "Araba ismi geçersiz";
		public static string CarListedInvalid = "Araba listelenemedi";
		public static string MaintenanceTime = "Bakım zamanı";
		public static string CarImageLimit = "Araba resim sınırına ulaştı";

		public static string AuthorizationDenied = "Yetkisiz";
		public static string UserRegistered = "Kayıt başarılı.";
		public static string UserNotFound = "Kullanıcı bulunamadı.";
		public static string PasswordError = "Parola yanlış";
		public static string UserAlreadyExists = "Kullanıcı zaten var.";
		public static string AccessTokenCreated = "Access Token oluşturuldu.";
		public static string SuccessfulLogin = "Başarılı giriş";
		public static string ProductUpdated = "Ürün güncellendi.";
		public static string CarNameAlreadyExists = "Böyle bir isimli araba mevcut";
	}
}
