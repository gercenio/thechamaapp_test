using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipAskPoint
    {
        [Key]
        public int RellationshipAskPointId { get; set; }
        public int AskId { get; set; }
        public int AskPoint { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

    }
}
