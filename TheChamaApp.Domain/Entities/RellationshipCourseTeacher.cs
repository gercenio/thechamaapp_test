using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipCourseTeacher
    {
        [Key]
        public int RellationshipCourseTeacherId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public DateTime UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
    }
}
