using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipAskToAnswer
    {
        [Key]
        public int RellationshipAskToAnswerId { get; set; }
        public int AskId { get; set; }
        public int AnswerId { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }


    }
}
