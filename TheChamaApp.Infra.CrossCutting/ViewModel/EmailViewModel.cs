using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheChamaApp.Infra.CrossCutting.ViewModel
{
    public class EmailViewModel
    {
        [Required]
        public string EmailTo { get; set; }
        [Required]
        public string EmailSubject { get; set; }
        [Required]
        public string EmailBody { get; set; }
    }
}
