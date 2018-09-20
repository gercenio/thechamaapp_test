using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipQuizToAsk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RellationshipQuizToAskId { get; set; }
        public int QuizId { get; set; }
        public int AskId { get; set; }
        public int GroupAskId { get; set; }
        public int Order { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("AskId")]
        public virtual Ask Ask { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        [ForeignKey("GroupAskId")]
        public virtual GroupAsk GroupAsk { get; set; }

    }
}
