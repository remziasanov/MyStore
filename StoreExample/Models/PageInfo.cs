using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreExample.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } //номер страницы
        public int PageSize { get; set; } //количество товаров на странице
        public int TotalItems { get; set; } //всего товаров
        public int TotalPages //всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel
    {
        public IEnumerable<PhoneItem> Instruments { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}