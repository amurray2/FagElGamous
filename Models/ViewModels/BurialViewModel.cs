using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class BurialViewModel
    {
        public IEnumerable<Location> Location { get; set; }
        public Burial Burial { get; set; }
        public Preservation Preservation { get; set; }
    }
}
