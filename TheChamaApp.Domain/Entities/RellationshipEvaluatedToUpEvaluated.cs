using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TheChamaApp.Domain.Entities
{
    public class RellationshipEvaluatedToUpEvaluated
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RellationshipEvaluatedToUpEvaluatedId { get; set; }
        public int EvaluatedId { get; set; }
        public int UpEvaluatedId { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        [ForeignKey("EvaluatedId")]
        public virtual Evaluated Evaluated { get; set; }

        [ForeignKey("UpEvaluatedId")]
        public virtual Evaluated UpEvaluated { get; set; }

    }
}
