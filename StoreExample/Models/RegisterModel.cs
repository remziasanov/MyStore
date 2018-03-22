using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreExample.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string SurName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,}$",
            ErrorMessage = "Пароль должен быть более 8 символов и содержать цифры, " +
            "символы в различном регистре")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Потвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"\+?\d+([\(\s\-]?\d+[\)\s\-]?[\d\s\-]+)?",
            ErrorMessage = "Номер телефона должен быть в формате +7XXX XXX XX XX ")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Индекс")]
        public string IndexPost { get; set; }
    }
}