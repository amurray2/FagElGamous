using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class Location
    {
        public Location()
        {
            Burial = new HashSet<Burial>();
        }

        public int LocationId { get; set; }
        public string LocationString { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }
        public int? LowPairNs { get; set; }
        public int? HighPairNs { get; set; }
        public int? LowPairEw { get; set; }
        public int? HighPairEw { get; set; }
        public string BurialSubplot { get; set; }
        public int? AreaNum { get; set; }
        public int? TombNumber { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
    }
}
