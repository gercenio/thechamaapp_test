using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class CompanyAddress
    {
        [Key]
        public int CompanyAddressId { get; set; }
        public int Company { get; set; }
        public int StateId { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complent { get; set; }
        public string City { get; set; }
        public string Cep { get; set; }
        public string Ibge { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }
    }
}
