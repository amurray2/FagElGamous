using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FagElGamous.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    location_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_string = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    burial_location_NS = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    burial_location_EW = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    low_pair_NS = table.Column<int>(nullable: true),
                    high_pair_NS = table.Column<int>(nullable: true),
                    low_pair_EW = table.Column<int>(nullable: true),
                    high_pair_EW = table.Column<int>(nullable: true),
                    burial_subplot = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    area_num = table.Column<int>(nullable: true),
                    tomb_number = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "Researcher",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    password = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    first_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    last_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    is_super_user = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Research__B9BE370FD6FC7953", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Burial",
                columns: table => new
                {
                    burial_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_id = table.Column<int>(nullable: false),
                    burial_depth = table.Column<int>(nullable: true),
                    south_to_head = table.Column<int>(nullable: true),
                    south_to_feet = table.Column<int>(nullable: true),
                    west_to_head = table.Column<int>(nullable: true),
                    west_to_feet = table.Column<int>(nullable: true),
                    burial_situation = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    length_of_remains = table.Column<int>(nullable: true),
                    burial_number = table.Column<int>(nullable: true),
                    gender_GE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    GE_function_total = table.Column<int>(nullable: true),
                    hair_color = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    sample_num = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    hair_taken = table.Column<bool>(nullable: true),
                    soft_tissue_taken = table.Column<bool>(nullable: true),
                    bone_taken = table.Column<bool>(nullable: true),
                    tooth_taken = table.Column<bool>(nullable: true),
                    textile_taken = table.Column<bool>(nullable: true),
                    description_of_taken = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    artifact_found = table.Column<bool>(nullable: true),
                    estimate_age = table.Column<int>(nullable: true),
                    estimate_living_stature = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tooth_attrition = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tooth_eruption = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    pathology_anomalies = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    year_found = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    month_found = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    day_found = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    head_direction = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    sex_method = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    age_method = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    sample_taken = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    field_book = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    field_book_page_number = table.Column<int>(nullable: true),
                    initials_of_data_entry_expert = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    initials_of_data_entry_checker = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    byu_sample = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    body_analysis_year = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    is_tomb = table.Column<bool>(nullable: true),
                    tomb_description = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    year_excav = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    month_excav = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    burial_adult_child = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    age_code_single = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    field_notes = table.Column<string>(unicode: false, maxLength: 8000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burial", x => x.burial_id);
                    table.ForeignKey(
                        name: "FK__Burial__location__236943A5",
                        column: x => x.location_id,
                        principalTable: "Location",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artifacts",
                columns: table => new
                {
                    artifact_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burial_id = table.Column<int>(nullable: false),
                    artifact_description = table.Column<string>(unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Artifact__A074A76F31F6F620", x => x.artifact_id);
                    table.ForeignKey(
                        name: "FK__Artifacts__buria__2645B050",
                        column: x => x.burial_id,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Biological Sample",
                columns: table => new
                {
                    bio_sample_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burial_id = table.Column<int>(nullable: false),
                    rack_num = table.Column<int>(nullable: true),
                    bag_num = table.Column<int>(nullable: true),
                    previously_sampled = table.Column<bool>(nullable: true),
                    notes = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    initials = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Biologic__2F14FA938AE9481F", x => x.bio_sample_id);
                    table.ForeignKey(
                        name: "FK__Biologica__buria__2CF2ADDF",
                        column: x => x.burial_id,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bones",
                columns: table => new
                {
                    bone_info_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burial_id = table.Column<int>(nullable: false),
                    date_on_skull = table.Column<DateTime>(type: "datetime", nullable: true),
                    basilar_suture = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    ventral_arc = table.Column<int>(nullable: true),
                    subpubic_angle = table.Column<int>(nullable: true),
                    sciatic_notch = table.Column<int>(nullable: true),
                    pubic_bone = table.Column<int>(nullable: true),
                    preaur_sulcus = table.Column<int>(nullable: true),
                    medial_IP_ramus = table.Column<int>(nullable: true),
                    dorsal_pitting = table.Column<int>(nullable: true),
                    foreman_magnum = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    femur_head = table.Column<double>(nullable: true),
                    humerus_head = table.Column<double>(nullable: true),
                    osteophytosis = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    pubic_symphysis = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    femur_length = table.Column<double>(nullable: true),
                    humerus_length = table.Column<double>(nullable: true),
                    tibia_length = table.Column<double>(nullable: true),
                    robust = table.Column<int>(nullable: true),
                    supraorbital_ridges = table.Column<int>(nullable: true),
                    orbit_edge = table.Column<int>(nullable: true),
                    parietal_bossing = table.Column<int>(nullable: true),
                    gonian = table.Column<int>(nullable: true),
                    nuchal_crest = table.Column<int>(nullable: true),
                    zygomatic_crest = table.Column<int>(nullable: true),
                    cranial_suture = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    maximum_cranial_length = table.Column<double>(nullable: true),
                    maximum_cranial_breadth = table.Column<double>(nullable: true),
                    basion_bregma_height = table.Column<double>(nullable: true),
                    basion_nasion = table.Column<double>(nullable: true),
                    basion_prosthion_length = table.Column<double>(nullable: true),
                    bizygomatic_diameter = table.Column<double>(nullable: true),
                    nasion_prosthion = table.Column<double>(nullable: true),
                    maximum_nasal_breadth = table.Column<double>(nullable: true),
                    interorbital_breadth = table.Column<double>(nullable: true),
                    epiphyseal_union = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    skull_at_magazine = table.Column<bool>(nullable: true),
                    postrcrania_at_magazine = table.Column<bool>(nullable: true),
                    sex_skull = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    age_skull = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    rack = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    shelf_number = table.Column<int>(nullable: true),
                    to_be_confirmed = table.Column<bool>(nullable: true),
                    skull_trauma = table.Column<bool>(nullable: true),
                    poscrania_trauma = table.Column<bool>(nullable: true),
                    cribra_orbitala = table.Column<bool>(nullable: true),
                    porotic_hyperostosis = table.Column<bool>(nullable: true),
                    porotic_hyperososis_locations = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    metopic_suture = table.Column<bool>(nullable: true),
                    button_osteoma = table.Column<bool>(nullable: true),
                    osteology_unknown_comment = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    temporal_mandibular_joint_osteoarthritus = table.Column<bool>(nullable: true),
                    linear_hypoplasia_enamel = table.Column<bool>(nullable: true),
                    osteology_notes = table.Column<string>(unicode: false, maxLength: 8000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bones__E22A264B25D1748E", x => x.bone_info_id);
                    table.ForeignKey(
                        name: "FK__Bones__burial_id__2A164134",
                        column: x => x.burial_id,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "C14 Sample",
                columns: table => new
                {
                    c14_sample_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burial_id = table.Column<int>(nullable: false),
                    rack_num = table.Column<int>(nullable: true),
                    area_num = table.Column<int>(nullable: true),
                    tube_num = table.Column<int>(nullable: true),
                    description = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    size_ml = table.Column<int>(nullable: true),
                    foci = table.Column<int>(nullable: true),
                    location = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    questions = table.Column<string>(unicode: false, maxLength: 800, nullable: true),
                    conventia_14Cage_BP = table.Column<int>(name: "conventia_14C-age_BP", nullable: true),
                    _14C_calendar_date = table.Column<int>(name: "14C_calendar_date", nullable: true),
                    calibrated_95_calendar_date_MAX = table.Column<int>(name: "calibrated_95%_calendar_date_MAX", nullable: true),
                    calibrated_95_calendar_date_MIN = table.Column<int>(name: "calibrated_95%_calendar_date_MIN", nullable: true),
                    calibrated_95_calendar_date_SPAN = table.Column<int>(name: "calibrated_95%_calendar_date_SPAN", nullable: true),
                    calibrated_95_calendar_date_AVG = table.Column<string>(name: "calibrated_95%_calendar_date_AVG", unicode: false, maxLength: 15, nullable: true),
                    category = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    notes = table.Column<string>(unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C14 Sample", x => x.c14_sample_id);
                    table.ForeignKey(
                        name: "FK__C14 Sampl__buria__2FCF1A8A",
                        column: x => x.burial_id,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialId = table.Column<int>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Burial_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preservation",
                columns: table => new
                {
                    burial_id = table.Column<int>(nullable: false),
                    preservation_description = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    burial_icon = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    burial_icon_2 = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    preservation_index = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    burial_wrapping = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Preserva__12A901C5D06A1943", x => x.burial_id);
                    table.ForeignKey(
                        name: "FK__Preservat__buria__32AB8735",
                        column: x => x.burial_id,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_burial_id",
                table: "Artifacts",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Biological Sample_burial_id",
                table: "Biological Sample",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Bones__12A901C43AF1ECAB",
                table: "Bones",
                column: "burial_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Burial_location_id",
                table: "Burial",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_C14 Sample_burial_id",
                table: "C14 Sample",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BurialId",
                table: "Photos",
                column: "BurialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artifacts");

            migrationBuilder.DropTable(
                name: "Biological Sample");

            migrationBuilder.DropTable(
                name: "Bones");

            migrationBuilder.DropTable(
                name: "C14 Sample");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Preservation");

            migrationBuilder.DropTable(
                name: "Researcher");

            migrationBuilder.DropTable(
                name: "Burial");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
