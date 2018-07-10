using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class CompanyAddress
    {
        [Key]
        public int CompanyAddressId { get; set; }
        public int Company { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complent { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
    }
}
