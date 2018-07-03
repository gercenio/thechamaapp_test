using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Description { get; set; }
        public int MaxNumberOfStudent { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
    }
}
