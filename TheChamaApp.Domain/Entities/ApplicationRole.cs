using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class ApplicationRole
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
