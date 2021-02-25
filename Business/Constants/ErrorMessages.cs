using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class ErrorMessages
    {
        //Car Messages
        public static string CarNameInvalid = "Geçersiz Araba İsmi";
        public static string CouldntCarAdded = "Araba Eklenirken Hata Oluştu";
        public static string CouldntCarDeleted = "Araba Silinirken Hata Oluştu";
        public static string CouldntCarUpdated = "Araba Güncellenirken Hata Oluştu";

        //Brand Messages
        public static string CouldntBrandAdded = "Marka Eklenirken Hata Oluştu";
        public static string CouldntBrandDeleted = "Marka Silinirken Hata Oluştu";
        public static string CouldntBrandUpdated = "Marka Güncellenirken Hata Oluştu";
        public static string BrandNameInvalid = "Geçersiz Marka İsmi";

        //Color Messages
        public static string CouldntColorAdded = "Renk Eklenirken Hata Oluştu";
        public static string CouldntColorDeleted = "Renk Silinirken Hata Oluştu";
        public static string CouldntColorUpdated = "Renk Güncellenirken Hata Oluştu";
        public static string ColorNameInvalid = "Geçersiz Renk İsmi";

        //Rentals
        public static string CouldntRentalAdded = "Kira eklenemedi. Şuan araç zaten kiralanmış!!!";
        //Core Message
        public static string MaintenanceTime = "Sistem Bakımda";

        public static string BrandCountError = "500' den fazla marka eklenemez";
    }
}
