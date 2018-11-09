using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class CompanyImage
    {
        [Key]
        public int CompanyImageId { get; set; }
        public int CompanyId { get; set; }
        public string Image { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
    }
}
