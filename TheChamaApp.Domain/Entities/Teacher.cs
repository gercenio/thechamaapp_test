using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Domain.Entities
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string Description { get; set; }
        public Util.TeacherType TeacherType { get; set; } 
        public DateTime UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
    }
}
