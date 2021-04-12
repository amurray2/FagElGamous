using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class SummaryPageViewModel
    {
        public IQueryable<Burial> Burials { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
    }
}
