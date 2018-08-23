using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Questions
    {

        #region # Constructor
        public Questions() {
            RellationshipQuestionsToAsk = new HashSet<RellationshipQuestionsToAsk>();
        }
        #endregion

        #region # Fields
        [Key]
        public int QuestionsId { get; set; }
        public string Description { get; set; }
        public bool? Unable { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
        #endregion

        #region # Atributs
        public virtual ICollection<RellationshipQuestionsToAsk> RellationshipQuestionsToAsk { get; set; }
        #endregion
    }
}
