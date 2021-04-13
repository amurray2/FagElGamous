using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class Burial
    {
        public Burial()
        {
            Artifacts = new HashSet<Artifacts>();
            BiologicalSample = new HashSet<BiologicalSample>();
            C14Sample = new HashSet<C14Sample>();
            Photos = new HashSet<Photos>();
            FieldBooks = new HashSet<FieldBooks>();
        }

        public int BurialId { get; set; }
        public int LocationId { get; set; }
        public int? BurialDepth { get; set; }
        public int? SouthToHead { get; set; }
        public int? SouthToFeet { get; set; }
        public int? WestToHead { get; set; }
        public int? WestToFeet { get; set; }
        public string BurialSituation { get; set; }
        public int? LengthOfRemains { get; set; }
        public int? BurialNumber { get; set; }
        public string GenderGe { get; set; }
        public int? GeFunctionTotal { get; set; }
        public string HairColor { get; set; }
        public string SampleNum { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public bool? ArtifactFound { get; set; }
        public int? EstimateAge { get; set; }
        public string EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string YearFound { get; set; }
        public string MonthFound { get; set; }
        public string DayFound { get; set; }
        public string HeadDirection { get; set; }
        public string SexMethod { get; set; }
        public string AgeMethod { get; set; }
        public string SampleTaken { get; set; }
        public string FieldBook { get; set; }
        public int? FieldBookPageNumber { get; set; }
        public string InitialsOfDataEntryExpert { get; set; }
        public string InitialsOfDataEntryChecker { get; set; }
        public string ByuSample { get; set; }
        public string BodyAnalysisYear { get; set; }
        public bool? IsTomb { get; set; }
        public string TombDescription { get; set; }
        public string YearExcav { get; set; }
        public string MonthExcav { get; set; }
        public string BurialAdultChild { get; set; }
        public string AgeCodeSingle { get; set; }
        public string FieldNotes { get; set; }

        public virtual Location Location { get; set; }
        public virtual Bones Bones { get; set; }
        public virtual Preservation Preservation { get; set; }
        public virtual ICollection<Artifacts> Artifacts { get; set; }
        public virtual ICollection<BiologicalSample> BiologicalSample { get; set; }
        public virtual ICollection<C14Sample> C14Sample { get; set; }
        public virtual ICollection<Photos> Photos { get; set; }
        public virtual ICollection<FieldBooks> FieldBooks { get; set; }
    }
}
