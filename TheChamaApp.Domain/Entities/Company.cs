using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
        public string StateDocument { get; set; }
        public string WebSite { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        public virtual CompanyAddress Address { get; set; }
        public ICollection<CompanyContact> Contacts { get; set; }
        public ICollection<CompanyUnity> Unitys { get; set; }
    }
}
