using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Domain.ViewModel
{
    public class IndividualGraficEvaluatedHeader
    {
        public Domain.Entities.Evaluated Header { get; set; }
        public virtual IEnumerable<IndividualGraficEvaluatedBody> Body { get; set; }
    }
}
