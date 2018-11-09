using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Infra.CrossCutting.ViewModel
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ResultActionMensagem { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime InsertAt { get; set; }

        public virtual CourseViewModel Course { get; set; }
    }

}
