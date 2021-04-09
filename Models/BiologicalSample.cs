using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class BiologicalSample
    {
        public int BioSampleId { get; set; }
        public int BurialId { get; set; }
        public int? RackNum { get; set; }
        public int? BagNum { get; set; }
        public bool? PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public string Initials { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
