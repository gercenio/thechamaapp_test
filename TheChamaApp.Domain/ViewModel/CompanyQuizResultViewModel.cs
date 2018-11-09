using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Domain.ViewModel
{
    public class CompanyQuizResultViewModel
    {
        public int CompanyUnityId { get; set; }
        public string CompanyUnityDescription { get; set; }
        public int EvaluatedId { get; set; }
        public string EvaluatedDescription { get; set; }
        public int? Autopercepcao { get; set; }
        public int? Superior { get; set; }
        public int? Subordinado { get; set; }
    }
}
