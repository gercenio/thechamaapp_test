using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipQuestionsToAsk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RellationshipQuestionsToAskId { get; set; }
        public int QuestionsId { get; set; }
        public int AskId { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
    }
}
