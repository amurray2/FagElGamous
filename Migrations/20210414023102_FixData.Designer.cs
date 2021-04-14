﻿// <auto-generated />
using System;
using FagElGamous.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FagElGamous.Migrations
{
    [DbContext(typeof(FagElGamousContext))]
    [Migration("20210414023102_FixData")]
    partial class FixData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FagElGamous.Models.Artifacts", b =>
                {
                    b.Property<int>("ArtifactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("artifact_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtifactDescription")
                        .HasColumnName("artifact_description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<int>("BurialId")
                        .HasColumnName("burial_id")
                        .HasColumnType("int");

                    b.HasKey("ArtifactId")
                        .HasName("PK__Artifact__A074A76F31F6F620");

                    b.HasIndex("BurialId");

                    b.ToTable("Artifacts");
                });

            modelBuilder.Entity("FagElGamous.Models.BiologicalSample", b =>
                {
                    b.Property<int>("BioSampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bio_sample_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BagNum")
                        .HasColumnName("bag_num")
                        .HasColumnType("int");

                    b.Property<int>("BurialId")
                        .HasColumnName("burial_id")
                        .HasColumnType("int");

                    b.Property<string>("Initials")
                        .HasColumnName("initials")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<bool?>("PreviouslySampled")
                        .HasColumnName("previously_sampled")
                        .HasColumnType("bit");

                    b.Property<int?>("RackNum")
                        .HasColumnName("rack_num")
                        .HasColumnType("int");

                    b.HasKey("BioSampleId")
                        .HasName("PK__Biologic__2F14FA938AE9481F");

                    b.HasIndex("BurialId");

                    b.ToTable("Biological Sample");
                });

            modelBuilder.Entity("FagElGamous.Models.Bones", b =>
                {
                    b.Property<int>("BoneInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bone_info_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeSkull")
                        .HasColumnName("age_skull")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("BasilarSuture")
                        .HasColumnName("basilar_suture")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<double?>("BasionBregmaHeight")
                        .HasColumnName("basion_bregma_height")
                        .HasColumnType("float");

                    b.Property<double?>("BasionNasion")
                        .HasColumnName("basion_nasion")
                        .HasColumnType("float");

                    b.Property<double?>("BasionProsthionLength")
                        .HasColumnName("basion_prosthion_length")
                        .HasColumnType("float");

                    b.Property<double?>("BizygomaticDiameter")
                        .HasColumnName("bizygomatic_diameter")
                        .HasColumnType("float");

                    b.Property<int>("BurialId")
                        .HasColumnName("burial_id")
                        .HasColumnType("int");

                    b.Property<bool?>("ButtonOsteoma")
                        .HasColumnName("button_osteoma")
                        .HasColumnType("bit");

                    b.Property<string>("CranialSuture")
                        .HasColumnName("cranial_suture")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<bool?>("CribraOrbitala")
                        .HasColumnName("cribra_orbitala")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateOnSkull")
                        .HasColumnName("date_on_skull")
                        .HasColumnType("datetime");

                    b.Property<int?>("DorsalPitting")
                        .HasColumnName("dorsal_pitting")
                        .HasColumnType("int");

                    b.Property<string>("EpiphysealUnion")
                        .HasColumnName("epiphyseal_union")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<double?>("FemurHead")
                        .HasColumnName("femur_head")
                        .HasColumnType("float");

                    b.Property<double?>("FemurLength")
                        .HasColumnName("femur_length")
                        .HasColumnType("float");

                    b.Property<string>("ForemanMagnum")
                        .HasColumnName("foreman_magnum")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<int?>("Gonian")
                        .HasColumnName("gonian")
                        .HasColumnType("int");

                    b.Property<double?>("HumerusHead")
                        .HasColumnName("humerus_head")
                        .HasColumnType("float");

                    b.Property<double?>("HumerusLength")
                        .HasColumnName("humerus_length")
                        .HasColumnType("float");

                    b.Property<double?>("InterorbitalBreadth")
                        .HasColumnName("interorbital_breadth")
                        .HasColumnType("float");

                    b.Property<bool?>("LinearHypoplasiaEnamel")
                        .HasColumnName("linear_hypoplasia_enamel")
                        .HasColumnType("bit");

                    b.Property<double?>("MaximumCranialBreadth")
                        .HasColumnName("maximum_cranial_breadth")
                        .HasColumnType("float");

                    b.Property<double?>("MaximumCranialLength")
                        .HasColumnName("maximum_cranial_length")
                        .HasColumnType("float");

                    b.Property<double?>("MaximumNasalBreadth")
                        .HasColumnName("maximum_nasal_breadth")
                        .HasColumnType("float");

                    b.Property<int?>("MedialIpRamus")
                        .HasColumnName("medial_IP_ramus")
                        .HasColumnType("int");

                    b.Property<bool?>("MetopicSuture")
                        .HasColumnName("metopic_suture")
                        .HasColumnType("bit");

                    b.Property<double?>("NasionProsthion")
                        .HasColumnName("nasion_prosthion")
                        .HasColumnType("float");

                    b.Property<int?>("NuchalCrest")
                        .HasColumnName("nuchal_crest")
                        .HasColumnType("int");

                    b.Property<int?>("OrbitEdge")
                        .HasColumnName("orbit_edge")
                        .HasColumnType("int");

                    b.Property<string>("OsteologyNotes")
                        .HasColumnName("osteology_notes")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<string>("OsteologyUnknownComment")
                        .HasColumnName("osteology_unknown_comment")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Osteophytosis")
                        .HasColumnName("osteophytosis")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<int?>("ParietalBossing")
                        .HasColumnName("parietal_bossing")
                        .HasColumnType("int");

                    b.Property<string>("PoroticHyperososisLocations")
                        .HasColumnName("porotic_hyperososis_locations")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<bool?>("PoroticHyperostosis")
                        .HasColumnName("porotic_hyperostosis")
                        .HasColumnType("bit");

                    b.Property<bool?>("PoscraniaTrauma")
                        .HasColumnName("poscrania_trauma")
                        .HasColumnType("bit");

                    b.Property<bool?>("PostrcraniaAtMagazine")
                        .HasColumnName("postrcrania_at_magazine")
                        .HasColumnType("bit");

                    b.Property<int?>("PreaurSulcus")
                        .HasColumnName("preaur_sulcus")
                        .HasColumnType("int");

                    b.Property<int?>("PubicBone")
                        .HasColumnName("pubic_bone")
                        .HasColumnType("int");

                    b.Property<string>("PubicSymphysis")
                        .HasColumnName("pubic_symphysis")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Rack")
                        .HasColumnName("rack")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<int?>("Robust")
                        .HasColumnName("robust")
                        .HasColumnType("int");

                    b.Property<int?>("SciaticNotch")
                        .HasColumnName("sciatic_notch")
                        .HasColumnType("int");

                    b.Property<string>("SexSkull")
                        .HasColumnName("sex_skull")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<int?>("ShelfNumber")
                        .HasColumnName("shelf_number")
                        .HasColumnType("int");

                    b.Property<bool?>("SkullAtMagazine")
                        .HasColumnName("skull_at_magazine")
                        .HasColumnType("bit");

                    b.Property<bool?>("SkullTrauma")
                        .HasColumnName("skull_trauma")
                        .HasColumnType("bit");

                    b.Property<int?>("SubpubicAngle")
                        .HasColumnName("subpubic_angle")
                        .HasColumnType("int");

                    b.Property<int?>("SupraorbitalRidges")
                        .HasColumnName("supraorbital_ridges")
                        .HasColumnType("int");

                    b.Property<bool?>("TemporalMandibularJointOsteoarthritus")
                        .HasColumnName("temporal_mandibular_joint_osteoarthritus")
                        .HasColumnType("bit");

                    b.Property<double?>("TibiaLength")
                        .HasColumnName("tibia_length")
                        .HasColumnType("float");

                    b.Property<bool?>("ToBeConfirmed")
                        .HasColumnName("to_be_confirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("VentralArc")
                        .HasColumnName("ventral_arc")
                        .HasColumnType("int");

                    b.Property<int?>("ZygomaticCrest")
                        .HasColumnName("zygomatic_crest")
                        .HasColumnType("int");

                    b.HasKey("BoneInfoId")
                        .HasName("PK__Bones__E22A264B25D1748E");

                    b.HasIndex("BurialId")
                        .IsUnique()
                        .HasName("UQ__Bones__12A901C43AF1ECAB");

                    b.ToTable("Bones");
                });

            modelBuilder.Entity("FagElGamous.Models.Burial", b =>
                {
                    b.Property<int>("BurialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("burial_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeCodeSingle")
                        .HasColumnName("age_code_single")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("AgeMethod")
                        .HasColumnName("age_method")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("ArtifactFound")
                        .HasColumnName("artifact_found")
                        .HasColumnType("bit");

                    b.Property<string>("BodyAnalysisYear")
                        .HasColumnName("body_analysis_year")
                        .HasColumnType("varchar(4)")
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    b.Property<bool?>("BoneTaken")
                        .HasColumnName("bone_taken")
                        .HasColumnType("bit");

                    b.Property<string>("BurialAdultChild")
                        .HasColumnName("burial_adult_child")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("BurialDepth")
                        .HasColumnName("burial_depth")
                        .HasColumnType("int");

                    b.Property<int?>("BurialNumber")
                        .HasColumnName("burial_number")
                        .HasColumnType("int");

                    b.Property<string>("BurialSituation")
                        .HasColumnName("burial_situation")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ByuSample")
                        .HasColumnName("byu_sample")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("DayFound")
                        .HasColumnName("day_found")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DescriptionOfTaken")
                        .HasColumnName("description_of_taken")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<int?>("EstimateAge")
                        .HasColumnName("estimate_age")
                        .HasColumnType("int");

                    b.Property<string>("EstimateLivingStature")
                        .HasColumnName("estimate_living_stature")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("FieldBook")
                        .HasColumnName("field_book")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("FieldBookPageNumber")
                        .HasColumnName("field_book_page_number")
                        .HasColumnType("int");

                    b.Property<string>("FieldNotes")
                        .HasColumnName("field_notes")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<int?>("GeFunctionTotal")
                        .HasColumnName("GE_function_total")
                        .HasColumnType("int");

                    b.Property<string>("GenderGe")
                        .HasColumnName("gender_GE")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("HairColor")
                        .HasColumnName("hair_color")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("HairTaken")
                        .HasColumnName("hair_taken")
                        .HasColumnType("bit");

                    b.Property<string>("HeadDirection")
                        .HasColumnName("head_direction")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("InitialsOfDataEntryChecker")
                        .HasColumnName("initials_of_data_entry_checker")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("InitialsOfDataEntryExpert")
                        .HasColumnName("initials_of_data_entry_expert")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<bool?>("IsTomb")
                        .HasColumnName("is_tomb")
                        .HasColumnType("bit");

                    b.Property<int?>("LengthOfRemains")
                        .HasColumnName("length_of_remains")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnName("location_id")
                        .HasColumnType("int");

                    b.Property<string>("MonthExcav")
                        .HasColumnName("month_excav")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("MonthFound")
                        .HasColumnName("month_found")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PathologyAnomalies")
                        .HasColumnName("pathology_anomalies")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SampleNum")
                        .HasColumnName("sample_num")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SampleTaken")
                        .HasColumnName("sample_taken")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SexMethod")
                        .HasColumnName("sex_method")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("SoftTissueTaken")
                        .HasColumnName("soft_tissue_taken")
                        .HasColumnType("bit");

                    b.Property<int?>("SouthToFeet")
                        .HasColumnName("south_to_feet")
                        .HasColumnType("int");

                    b.Property<int?>("SouthToHead")
                        .HasColumnName("south_to_head")
                        .HasColumnType("int");

                    b.Property<bool?>("TextileTaken")
                        .HasColumnName("textile_taken")
                        .HasColumnType("bit");

                    b.Property<string>("TombDescription")
                        .HasColumnName("tomb_description")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<string>("ToothAttrition")
                        .HasColumnName("tooth_attrition")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ToothEruption")
                        .HasColumnName("tooth_eruption")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("ToothTaken")
                        .HasColumnName("tooth_taken")
                        .HasColumnType("bit");

                    b.Property<int?>("WestToFeet")
                        .HasColumnName("west_to_feet")
                        .HasColumnType("int");

                    b.Property<int?>("WestToHead")
                        .HasColumnName("west_to_head")
                        .HasColumnType("int");

                    b.Property<string>("YearExcav")
                        .HasColumnName("year_excav")
                        .HasColumnType("varchar(4)")
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    b.Property<string>("YearFound")
                        .HasColumnName("year_found")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("BurialId");

                    b.HasIndex("LocationId");

                    b.ToTable("Burial");
                });

            modelBuilder.Entity("FagElGamous.Models.C14Sample", b =>
                {
                    b.Property<int>("C14SampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("c14_sample_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaNum")
                        .HasColumnName("area_num")
                        .HasColumnType("int");

                    b.Property<int>("BurialId")
                        .HasColumnName("burial_id")
                        .HasColumnType("int");

                    b.Property<string>("Calibrated95CalendarDateAvg")
                        .HasColumnName("calibrated_95%_calendar_date_AVG")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int?>("Calibrated95CalendarDateMax")
                        .HasColumnName("calibrated_95%_calendar_date_MAX")
                        .HasColumnType("int");

                    b.Property<int?>("Calibrated95CalendarDateMin")
                        .HasColumnName("calibrated_95%_calendar_date_MIN")
                        .HasColumnType("int");

                    b.Property<int?>("Calibrated95CalendarDateSpan")
                        .HasColumnName("calibrated_95%_calendar_date_SPAN")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnName("category")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Conventia14cAgeBp")
                        .HasColumnName("conventia_14C-age_BP")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<int?>("Foci")
                        .HasColumnName("foci")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnName("location")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<string>("Questions")
                        .HasColumnName("questions")
                        .HasColumnType("varchar(800)")
                        .HasMaxLength(800)
                        .IsUnicode(false);

                    b.Property<int?>("RackNum")
                        .HasColumnName("rack_num")
                        .HasColumnType("int");

                    b.Property<int?>("SizeMl")
                        .HasColumnName("size_ml")
                        .HasColumnType("int");

                    b.Property<int?>("TubeNum")
                        .HasColumnName("tube_num")
                        .HasColumnType("int");

                    b.Property<int?>("_14cCalendarDate")
                        .HasColumnName("14C_calendar_date")
                        .HasColumnType("int");

                    b.HasKey("C14SampleId");

                    b.HasIndex("BurialId");

                    b.ToTable("C14 Sample");
                });

            modelBuilder.Entity("FagElGamous.Models.Files", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BurialId")
                        .HasColumnType("int");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FileId");

                    b.HasIndex("BurialId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("FagElGamous.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("location_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaNum")
                        .HasColumnName("area_num")
                        .HasColumnType("int");

                    b.Property<string>("BurialLocationEw")
                        .HasColumnName("burial_location_EW")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("BurialLocationNs")
                        .HasColumnName("burial_location_NS")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("BurialSubplot")
                        .HasColumnName("burial_subplot")
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<int?>("HighPairEw")
                        .HasColumnName("high_pair_EW")
                        .HasColumnType("int");

                    b.Property<int?>("HighPairNs")
                        .HasColumnName("high_pair_NS")
                        .HasColumnType("int");

                    b.Property<string>("LocationString")
                        .HasColumnName("location_string")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("LowPairEw")
                        .HasColumnName("low_pair_EW")
                        .HasColumnType("int");

                    b.Property<int?>("LowPairNs")
                        .HasColumnName("low_pair_NS")
                        .HasColumnType("int");

                    b.Property<int?>("TombNumber")
                        .HasColumnName("tomb_number")
                        .HasColumnType("int");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("FagElGamous.Models.Preservation", b =>
                {
                    b.Property<int>("BurialId")
                        .HasColumnName("burial_id")
                        .HasColumnType("int");

                    b.Property<string>("BurialIcon")
                        .HasColumnName("burial_icon")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("BurialIcon2")
                        .HasColumnName("burial_icon_2")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("BurialWrapping")
                        .HasColumnName("burial_wrapping")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PreservationDescription")
                        .HasColumnName("preservation_description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("PreservationIndex")
                        .HasColumnName("preservation_index")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("BurialId")
                        .HasName("PK__Preserva__12A901C5D06A1943");

                    b.ToTable("Preservation");
                });

            modelBuilder.Entity("FagElGamous.Models.Researcher", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("IsSuperUser")
                        .HasColumnName("is_super_user")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("UserId")
                        .HasName("PK__Research__B9BE370FD6FC7953");

                    b.ToTable("Researcher");
                });

            modelBuilder.Entity("FagElGamous.Models.Artifacts", b =>
                {
                    b.HasOne("FagElGamous.Models.Burial", "Burial")
                        .WithMany("Artifacts")
                        .HasForeignKey("BurialId")
                        .HasConstraintName("FK__Artifacts__buria__2645B050")
                        .IsRequired();
                });

            modelBuilder.Entity("FagElGamous.Models.BiologicalSample", b =>
                {
                    b.HasOne("FagElGamous.Models.Burial", "Burial")
                        .WithMany("BiologicalSample")
                        .HasForeignKey("BurialId")
                        .HasConstraintName("FK__Biologica__buria__2CF2ADDF")
                        .IsRequired();
                });

            modelBuilder.Entity("FagElGamous.Models.Bones", b =>
                {
                    b.HasOne("FagElGamous.Models.Burial", "Burial")
                        .WithOne("Bones")
                        .HasForeignKey("FagElGamous.Models.Bones", "BurialId")
                        .HasConstraintName("FK__Bones__burial_id__2A164134")
                        .IsRequired();
                });

            modelBuilder.Entity("FagElGamous.Models.Burial", b =>
                {
                    b.HasOne("FagElGamous.Models.Location", "Location")
                        .WithMany("Burial")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK__Burial__location__236943A5")
                        .IsRequired();
                });

            modelBuilder.Entity("FagElGamous.Models.C14Sample", b =>
                {
                    b.HasOne("FagElGamous.Models.Burial", "Burial")
                        .WithMany("C14Sample")
                        .HasForeignKey("BurialId")
                        .HasConstraintName("FK__C14 Sampl__buria__2FCF1A8A")
                        .IsRequired();
                });

            modelBuilder.Entity("FagElGamous.Models.Files", b =>
                {
                    b.HasOne("FagElGamous.Models.Burial", "Burial")
                        .WithMany("Files")
                        .HasForeignKey("BurialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FagElGamous.Models.Preservation", b =>
                {
                    b.HasOne("FagElGamous.Models.Burial", "Burial")
                        .WithOne("Preservation")
                        .HasForeignKey("FagElGamous.Models.Preservation", "BurialId")
                        .HasConstraintName("FK__Preservat__buria__32AB8735")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
