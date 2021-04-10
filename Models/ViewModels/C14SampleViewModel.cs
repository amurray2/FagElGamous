using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class C14SampleViewModel
    {
        public IEnumerable<C14Sample> C14Samples { get; set; }
        public Burial Burial { get; set; }
        public Location Location { get; set; }
    }
}
