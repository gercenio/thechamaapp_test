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
        public string Autopercepcao { get; set; }
        public string Superior { get; set; }
        public string Subordinado { get; set; }
    }
}
