using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class LevelEvaluated
    {
        [Key]
        public int LevelEvaluatedId { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

    }
}
