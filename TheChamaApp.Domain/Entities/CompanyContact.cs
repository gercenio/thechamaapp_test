using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class CompanyContact
    {
        [Key]
        public int CompanyContactId { get; set; }
        public int CompanyId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string ContactType { get; set; }
        public string PhoneNumber { get; set; }
        public string CodePhoneArea { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    }
}
