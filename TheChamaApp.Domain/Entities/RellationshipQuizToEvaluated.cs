using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipQuizToEvaluated
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RellationshipQuizToEvaluatedId { get; set; }
        public int QuizId { get; set; }
        public int EvaluatedId { get; set; }
        public int? SubordinatedId { get; set; }
        public bool? Answered { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime UpdateAt { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        [ForeignKey("SubordinatedId")]
        public virtual Evaluated Subordinated { get; set; }
    }
}
