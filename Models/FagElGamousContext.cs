using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class FagElGamousContext : DbContext
    {

        public FagElGamousContext(DbContextOptions<FagElGamousContext> options)
            : base(options)
        {
        }
        public FagElGamousContext()
        {
        }

        public static FagElGamousContext Create()
        {
            return new FagElGamousContext();
        }

        public virtual DbSet<Artifacts> Artifacts { get; set; }
        public virtual DbSet<BiologicalSample> BiologicalSample { get; set; }
        public virtual DbSet<Bones> Bones { get; set; }
        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<C14Sample> C14Sample { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Preservation> Preservation { get; set; }
        public virtual DbSet<Researcher> Researcher { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<FieldBooks> FieldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-14AH40MQ\\SQLExpress;Database=FagElGamous;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artifacts>(entity =>
            {
                entity.HasKey(e => e.ArtifactId)
                    .HasName("PK__Artifact__A074A76F31F6F620");

                entity.Property(e => e.ArtifactId).HasColumnName("artifact_id");

                entity.Property(e => e.ArtifactDescription)
                    .HasColumnName("artifact_description")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Artifacts)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artifacts__buria__2645B050");
            });

            modelBuilder.Entity<BiologicalSample>(entity =>
            {
                entity.HasKey(e => e.BioSampleId)
                    .HasName("PK__Biologic__2F14FA938AE9481F");

                entity.ToTable("Biological Sample");

                entity.Property(e => e.BioSampleId).HasColumnName("bio_sample_id");

                entity.Property(e => e.BagNum).HasColumnName("bag_num");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.Initials)
                    .HasColumnName("initials")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PreviouslySampled).HasColumnName("previously_sampled");

                entity.Property(e => e.RackNum).HasColumnName("rack_num");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.BiologicalSample)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Biologica__buria__2CF2ADDF");
            });

            modelBuilder.Entity<Bones>(entity =>
            {
                entity.HasKey(e => e.BoneInfoId)
                    .HasName("PK__Bones__E22A264B25D1748E");

                entity.HasIndex(e => e.BurialId)
                    .HasName("UQ__Bones__12A901C43AF1ECAB")
                    .IsUnique();

                entity.Property(e => e.BoneInfoId).HasColumnName("bone_info_id");

                entity.Property(e => e.AgeSkull)
                    .HasColumnName("age_skull")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BasilarSuture)
                    .HasColumnName("basilar_suture")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BasionBregmaHeight).HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion).HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength).HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter).HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.ButtonOsteoma).HasColumnName("button_osteoma");

                entity.Property(e => e.CranialSuture)
                    .HasColumnName("cranial_suture")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CribraOrbitala).HasColumnName("cribra_orbitala");

                entity.Property(e => e.DateOnSkull)
                    .HasColumnName("date_on_skull")
                    .HasColumnType("datetime");

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.EpiphysealUnion)
                    .HasColumnName("epiphyseal_union")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FemurHead).HasColumnName("femur_head");

                entity.Property(e => e.FemurLength).HasColumnName("femur_length");

                entity.Property(e => e.ForemanMagnum)
                    .HasColumnName("foreman_magnum")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.HumerusHead).HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength).HasColumnName("humerus_length");

                entity.Property(e => e.InterorbitalBreadth).HasColumnName("interorbital_breadth");

                entity.Property(e => e.LinearHypoplasiaEnamel).HasColumnName("linear_hypoplasia_enamel");

                entity.Property(e => e.MaximumCranialBreadth).HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength).HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth).HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MedialIpRamus).HasColumnName("medial_IP_ramus");

                entity.Property(e => e.MetopicSuture).HasColumnName("metopic_suture");

                entity.Property(e => e.NasionProsthion).HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbit_edge");

                entity.Property(e => e.OsteologyNotes)
                    .HasColumnName("osteology_notes")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasColumnName("osteology_unknown_comment")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Osteophytosis)
                    .HasColumnName("osteophytosis")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PoroticHyperososisLocations)
                    .HasColumnName("porotic_hyperososis_locations")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PoroticHyperostosis).HasColumnName("porotic_hyperostosis");

                entity.Property(e => e.PoscraniaTrauma).HasColumnName("poscrania_trauma");

                entity.Property(e => e.PostrcraniaAtMagazine).HasColumnName("postrcrania_at_magazine");

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PubicBone).HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphysis)
                    .HasColumnName("pubic_symphysis")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Rack)
                    .HasColumnName("rack")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SexSkull)
                    .HasColumnName("sex_skull")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfNumber).HasColumnName("shelf_number");

                entity.Property(e => e.SkullAtMagazine).HasColumnName("skull_at_magazine");

                entity.Property(e => e.SkullTrauma).HasColumnName("skull_trauma");

                entity.Property(e => e.SubpubicAngle).HasColumnName("subpubic_angle");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TemporalMandibularJointOsteoarthritus).HasColumnName("temporal_mandibular_joint_osteoarthritus");

                entity.Property(e => e.TibiaLength).HasColumnName("tibia_length");

                entity.Property(e => e.ToBeConfirmed).HasColumnName("to_be_confirmed");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");

                entity.HasOne(d => d.Burial)
                    .WithOne(p => p.Bones)
                    .HasForeignKey<Bones>(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bones__burial_id__2A164134");
            });

            modelBuilder.Entity<Burial>(entity =>
            {
                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.AgeCodeSingle)
                    .HasColumnName("age_code_single")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AgeMethod)
                    .HasColumnName("age_method")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArtifactFound).HasColumnName("artifact_found");

                entity.Property(e => e.BodyAnalysisYear)
                    .HasColumnName("body_analysis_year")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.BoneTaken).HasColumnName("bone_taken");

                entity.Property(e => e.BurialAdultChild)
                    .HasColumnName("burial_adult_child")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialSituation)
                    .HasColumnName("burial_situation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ByuSample)
                    .HasColumnName("byu_sample")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DayFound)
                    .HasColumnName("day_found")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateAge).HasColumnName("estimate_age");

                entity.Property(e => e.EstimateLivingStature)
                    .HasColumnName("estimate_living_stature")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldBook)
                    .HasColumnName("field_book")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldBookPageNumber).HasColumnName("field_book_page_number");

                entity.Property(e => e.FieldNotes)
                    .HasColumnName("field_notes")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.GeFunctionTotal).HasColumnName("GE_function_total");

                entity.Property(e => e.GenderGe)
                    .HasColumnName("gender_GE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HairTaken).HasColumnName("hair_taken");

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InitialsOfDataEntryChecker)
                    .HasColumnName("initials_of_data_entry_checker")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InitialsOfDataEntryExpert)
                    .HasColumnName("initials_of_data_entry_expert")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsTomb).HasColumnName("is_tomb");

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MonthExcav)
                    .HasColumnName("month_excav")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MonthFound)
                    .HasColumnName("month_found")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleNum)
                    .HasColumnName("sample_num")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleTaken)
                    .HasColumnName("sample_taken")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SexMethod)
                    .HasColumnName("sex_method")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoftTissueTaken).HasColumnName("soft_tissue_taken");

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");

                entity.Property(e => e.TextileTaken).HasColumnName("textile_taken");

                entity.Property(e => e.TombDescription)
                    .HasColumnName("tomb_description")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ToothAttrition)
                    .HasColumnName("tooth_attrition")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToothTaken).HasColumnName("tooth_taken");

                entity.Property(e => e.WestToFeet).HasColumnName("west_to_feet");

                entity.Property(e => e.WestToHead).HasColumnName("west_to_head");

                entity.Property(e => e.YearExcav)
                    .HasColumnName("year_excav")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.YearFound)
                    .HasColumnName("year_found")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Burial__location__236943A5");
            });

            modelBuilder.Entity<C14Sample>(entity =>
            {
                entity.ToTable("C14 Sample");

                entity.Property(e => e.C14SampleId).HasColumnName("c14_sample_id");

                entity.Property(e => e.AreaNum).HasColumnName("area_num");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .HasColumnName("calibrated_95%_calendar_date_AVG")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("calibrated_95%_calendar_date_MAX");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("calibrated_95%_calendar_date_MIN");

                entity.Property(e => e.Calibrated95CalendarDateSpan).HasColumnName("calibrated_95%_calendar_date_SPAN");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Conventia14cAgeBp).HasColumnName("conventia_14C-age_BP");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Questions)
                    .HasColumnName("questions")
                    .HasMaxLength(800)
                    .IsUnicode(false);

                entity.Property(e => e.RackNum).HasColumnName("rack_num");

                entity.Property(e => e.SizeMl).HasColumnName("size_ml");

                entity.Property(e => e.TubeNum).HasColumnName("tube_num");

                entity.Property(e => e._14cCalendarDate).HasColumnName("14C_calendar_date");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.C14Sample)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__C14 Sampl__buria__2FCF1A8A");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.AreaNum).HasColumnName("area_num");

                entity.Property(e => e.BurialLocationEw)
                    .HasColumnName("burial_location_EW")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BurialLocationNs)
                    .HasColumnName("burial_location_NS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.HighPairEw).HasColumnName("high_pair_EW");

                entity.Property(e => e.HighPairNs).HasColumnName("high_pair_NS");

                entity.Property(e => e.LocationString)
                    .HasColumnName("location_string")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LowPairEw).HasColumnName("low_pair_EW");

                entity.Property(e => e.LowPairNs).HasColumnName("low_pair_NS");

                entity.Property(e => e.TombNumber).HasColumnName("tomb_number");
            });

            modelBuilder.Entity<Preservation>(entity =>
            {
                entity.HasKey(e => e.BurialId)
                    .HasName("PK__Preserva__12A901C5D06A1943");

                entity.Property(e => e.BurialId)
                    .HasColumnName("burial_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialIcon)
                    .HasColumnName("burial_icon")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BurialIcon2)
                    .HasColumnName("burial_icon_2")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BurialWrapping)
                    .HasColumnName("burial_wrapping")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreservationDescription)
                    .HasColumnName("preservation_description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PreservationIndex)
                    .HasColumnName("preservation_index")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Burial)
                    .WithOne(p => p.Preservation)
                    .HasForeignKey<Preservation>(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preservat__buria__32AB8735");
            });

            modelBuilder.Entity<Researcher>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Research__B9BE370FD6FC7953");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsSuperUser).HasColumnName("is_super_user");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
