using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Infra.CrossCutting.ViewModel
{
    public class ChartIndividualViewModel
    {
        public Domain.Entities.Evaluated Avaliado { get; set; }
        public Domain.Entities.Evaluated Superior { get; set; }
        
        public ICollection<Domain.Entities.QuizResult> ListQuizResult { get; set; }
    }

}
