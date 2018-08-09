using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Description { get; set; }
    }
}
