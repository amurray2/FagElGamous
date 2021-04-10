using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class ArtifactViewModel
    {
        public IEnumerable<Artifacts> Artifacts { get; set; }
        public Burial Burial { get; set; }
        public Location Location { get; set; }
    }
}
