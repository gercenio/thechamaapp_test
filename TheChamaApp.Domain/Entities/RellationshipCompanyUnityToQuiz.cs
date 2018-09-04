using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipCompanyUnityToQuiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RellationshipCompanyUnityToQuizId { get; set; }
        public int CompanyUnityId { get; set; }
        public int QuizId { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        [ForeignKey("CompanyUnityId")]
        public virtual CompanyUnity CompanyUnity { get; set; }

    }
}
