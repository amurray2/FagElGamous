using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class Preservation
    {
        public int BurialId { get; set; }
        public string PreservationDescription { get; set; }
        public string BurialIcon { get; set; }
        public string BurialIcon2 { get; set; }
        public string PreservationIndex { get; set; }
        public string BurialWrapping { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
