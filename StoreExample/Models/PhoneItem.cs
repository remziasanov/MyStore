using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreExample.Models
{
    public class PhoneItem
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Модель")]
        public string ModelOfPhone { get; set; }
        [Display(Name = "Компания изготовитель")]
        public string Company { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Изображение")]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Подкатегория")]
        public string SubCategory { get; set; }
    }
}