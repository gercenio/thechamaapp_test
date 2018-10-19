using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Ask
    {
        #region # Constructor
        public Ask() {
            RellationshipAskToAnswer = new HashSet<Domain.Entities.RellationshipAskToAnswer>();
        }
        #endregion

        #region # Fields

        [Key]
        public int AskId { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
        public int? Order { get; set; }

        #endregion

        #region # Atributs

        public virtual ICollection<RellationshipAskToAnswer> RellationshipAskToAnswer { get; set; }

        //Bpublic virtual GroupAsk GroupAsk { get; set; }

        #endregion
    }
}
