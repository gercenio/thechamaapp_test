using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Quiz
    {
        #region # Constructor
        public Quiz()
        {
            RellationshipQuizToAsk = new HashSet<RellationshipQuizToAsk>();
        }
        #endregion

        #region # Fields
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizId { get; set; }
        public string Description { get; set; }
        public Util.QuizStatus Status { get; set; }
        public Util.QuizType Type { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
        #endregion

        #region # Atributs
        public virtual ICollection<RellationshipQuizToAsk> RellationshipQuizToAsk { get; set; }
        #endregion

    }
}
