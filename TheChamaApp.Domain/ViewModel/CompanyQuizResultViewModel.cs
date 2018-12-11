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
        public int? AutopercepcaoTotal { get; set; }
        public int? SuperiorTotal { get; set; }
        public int? SubordinadoTotal { get; set; }
        public string LevelEvaluatedDescription { get; set; }
        public string UpEvaluatedDescription { get; set; }
        public string LevelDescriptionByUpEvaluated { get; set; }
    }
}
