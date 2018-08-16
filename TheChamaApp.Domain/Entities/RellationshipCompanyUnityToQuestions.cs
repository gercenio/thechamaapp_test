using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipCompanyUnityToQuestions
    {
        [Key]
        public int RellationshipCompanyUnityToQuestionsId { get; set; }
        public int CompanyUnityId { get; set; }
        public int QuestionsId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

    }
}
