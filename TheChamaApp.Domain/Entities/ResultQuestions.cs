using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class ResultQuestions
    {
        [Key]
        public int ResultQuestionsId { get; set; }
        public int? LoginId { get; set; }
        public int QuestionsId { get; set; }
        public int AskId { get; set; }
        public int AnswerId { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("QuestionsId")]
        public virtual Questions Questions { get; set; }

        [ForeignKey("AskId")]
        public virtual Ask Ask { get; set; }

        [ForeignKey("AnswerId")]
        public virtual Answer Answer { get; set; }
    }
}
