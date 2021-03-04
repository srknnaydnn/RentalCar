using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Message
    {
        public static string AddSuccess = "Araba Ekleme İşlemi bşarılı";
        public static string AddUnSuccess = "Araba Ekleme İşlemi Başarısız";
        public static string CustomerAddSuccess = "Müşteri Ekleme İşlemi Başarılı";
        public static string CustomerAddUnSuccess = "Müşteri Ekleme İşlemi Başarısız";
        public static string CustomerDeleteSuccess = "Müşteri Silme İşemei Başarılı";
        public static string CustomerDeleteUnSuccess = "Müşteri Silme İşlemi Başarısız";
        public static string CustomersListSuccess = "Müşteriler Listelendi";
        public static string CustomersListUnSuccess = "Müşteri Listelenmedi";
        public static string CustomerListUnSuccess = "Müşteri Bulunamadı";
        public static string UserSuccessList = "Kullanıcılar listelendi";
        public static string UserAddSuccess = "Kullanıcı Ekleme İşlemi ";
        public static string AddSuccessRental = "Araba Tekrar Eklendi";
        public static string AddUnSuccessRental = "Araba Şuan Kiralık";
        public static string AddSuccessCarImages = "Resim Eklendi";
        public static string CarImagesLimited = "Bir Arcın Beşten Fazla Resmi Olamaz";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string ErrorPassword = "Parola Yanlış";
        public static string UserRegistered = "Kullanıcı Kaydı Başarılı";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string UserAlreadyExists = "kullanıcı bulunamadı";

    }
}
