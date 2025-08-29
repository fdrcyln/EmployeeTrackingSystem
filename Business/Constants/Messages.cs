using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public const string RequiredField = "Bu alan zorunludur.";
        public const string InvalidFormat = "Geçersiz format.";
        public const string NotFound = "Kayıt bulunamadı.";
        public const string AlreadyExists = "Bu kayıt zaten mevcut.";
        public const string InvalidDate = "Geçersiz tarih formatı.";
        public const string StartDateAfterEndDate = "Başlangıç tarihi bitiş tarihinden sonra olamaz.";
        public const string DatabaseConnectionError = "Veritabanına bağlanılamadı.";
        public const string BranchAdded = "Şube başarıyla eklendi.";
        public const string BranchUpdated = "Şube başarıyla güncellendi.";
        public const string BranchDeleted = "Şube başarıyla silindi.";
        public const string BranchNotFound = "Şube bulunamadı.";
        public const string BranchNameRequired = "Şube adı";
        public const string BranchAlreadyExists = "Bu şube zaten mevcut.";
        public const string BranchNameInvalid = "Şube adı geçersiz.";
        public const string BranchNameTooShort = "Şube adı en az 2 karakter olmalıdır.";

        // Departman
        public const string DepartmentNameRequired = "Departman adı zorunludur.";
        public const string DepartmentNotFound = "Departman bulunamadı.";

        // Pozisyon
        public const string PositionNameRequired = "Pozisyon adı zorunludur.";
        public const string PositionNotFound = "Pozisyon bulunamadı.";

        // Çalışan
        public const string EmployeeNameRequired = "Çalışan adı zorunludur.";
        public const string EmployeeSurnameRequired = "Çalışan soyadı zorunludur.";
        public const string EmployeeNotFound = "Çalışan bulunamadı.";
        public const string EmployeeAlreadyAssigned = "Çalışan zaten bu pozisyona atanmış.";

        // Görev
        public const string TaskNameRequired = "Görev adı zorunludur.";
        public const string TaskNotFound = "Görev bulunamadı.";
        public const string InvalidTaskStatus = "Geçersiz görev durumu.";

        // Şube
       // public const string BranchNameRequired = "Şube adı zorunludur.";
       // public const string BranchNotFound = "Şube bulunamadı.";

        // Başarı
        public const string RecordAdded = "Kayıt başarıyla eklendi.";
        public const string RecordUpdated = "Kayıt başarıyla güncellendi.";
        public const string RecordDeleted = "Kayıt başarıyla silindi.";
    }
}
