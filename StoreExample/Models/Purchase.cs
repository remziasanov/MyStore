using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreExample.Models
{
    public class Purchase
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string SurName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string IndexPost { get; set; }
        [Required]

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}