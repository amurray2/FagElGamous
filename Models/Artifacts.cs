using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class Artifacts
    {
        public int ArtifactId { get; set; }
        public int BurialId { get; set; }
        public string ArtifactDescription { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
