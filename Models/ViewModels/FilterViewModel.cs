using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class FilterViewModel
    {
        public IQueryable<Burial> AllBurials { get; set; }
        public IQueryable<Burial> Burials { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public int LocationId { get; set; }
        public string Age { get; set; }
        public string HeadDirection { get; set; }
    }
}
