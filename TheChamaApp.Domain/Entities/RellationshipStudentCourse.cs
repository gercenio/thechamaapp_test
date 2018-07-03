using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class RellationshipStudentCourse
    {
        [Key]
        public int RellationshipStudentCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

    }
}
