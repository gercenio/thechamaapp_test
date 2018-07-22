using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class CompanyUnity
    {
        [Key]
        public int CompanyUnityId { get; set; }
        public int CompanyId { get; set; }
        public int StateId { get; set; }
        public string Description { get; set; }
        public string ContactName { get; set; }
        public string Document { get; set; }
        public string StateDocument { get; set; }
        public string CodePhoneArea { get; set; }    
        public string PhoneNumber { get; set; }
        public string Cep { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Ibge { get; set; }
        public string City { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

    }
}
