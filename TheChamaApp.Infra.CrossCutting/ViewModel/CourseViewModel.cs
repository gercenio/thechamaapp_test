using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Infra.CrossCutting.ViewModel
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Description { get; set; }
        public int MaxNumberOfStudent { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }
    }
}
