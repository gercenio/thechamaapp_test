using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Ask
    {
        public Ask() {
            RellationshipAskToAnswer = new HashSet<Domain.Entities.RellationshipAskToAnswer>();
        }

        #region # Fields
        [Key]
        public int AskId { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
        #endregion

        #region # Atributs
        public virtual ICollection<RellationshipAskToAnswer> RellationshipAskToAnswer { get; set; }
        #endregion
    }
}
