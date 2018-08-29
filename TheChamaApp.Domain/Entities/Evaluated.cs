using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Evaluated
    {
        [Key]
        public int EvaluatedId { get; set; }
        public int CompanyUnityId { get; set; }
        public int LevelEvaluatedId { get; set; }
        public string Description { get; set; }
        public string KeyNumber { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("CompanyUnityId")]
        public virtual CompanyUnity Unity { get; set; }

        [ForeignKey("LevelEvaluatedId")]
        public virtual LevelEvaluated Level { get; set; }
    }
}
