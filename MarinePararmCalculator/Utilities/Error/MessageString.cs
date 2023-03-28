using MarinePararmCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Utilities.Error
{
    public static class MessageString
    {
        public static string NoFile="Dosya Bulunamadı";
        public static string EmptyField="Hesaplamak içiin alanlar dolu değil";
        public static string PrintOK="Çıktı alındı";
        internal static string LogFilePathChanged="Log dosyasının konumu değiştirildi";
        internal static string CalculationFilePathChanged = "Hesaplama dosyasının konumu değiştirildi";
    }
}
