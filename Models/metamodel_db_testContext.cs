using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MetaModelCoreApp.Models
{
    public partial class metamodel_db_testContext : DbContext
    {
        public metamodel_db_testContext()
        {
        }

        public metamodel_db_testContext(DbContextOptions<metamodel_db_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencies> Agencies { get; set; }
        public virtual DbSet<AgencyProjects> AgencyProjects { get; set; }
        public virtual DbSet<BdDistricts> BdDistricts { get; set; }
        public virtual DbSet<BdpGoals> BdpGoals { get; set; }
        public virtual DbSet<BdpWithIndicator> BdpWithIndicator { get; set; }
        public virtual DbSet<CropLoss> CropLoss { get; set; }
        public virtual DbSet<CropLosses> CropLosses { get; set; }
        public virtual DbSet<CropTypes> CropTypes { get; set; }
        public virtual DbSet<GeoDistricts> GeoDistricts { get; set; }
        public virtual DbSet<GeoDivisions> GeoDivisions { get; set; }
        public virtual DbSet<GeoUpazilas> GeoUpazilas { get; set; }
        public virtual DbSet<Indicator> Indicator { get; set; }
        public virtual DbSet<LossTypes> LossTypes { get; set; }
        public virtual DbSet<Ministries> Ministries { get; set; }
        public virtual DbSet<MinistryProjects> MinistryProjects { get; set; }
        public virtual DbSet<PgBuffercache> PgBuffercache { get; set; }
        public virtual DbSet<PgStatStatements> PgStatStatements { get; set; }
        public virtual DbSet<PowerBi> PowerBi { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<ProjectInfo> ProjectInfo { get; set; }
        public virtual DbSet<ProjectLocations> ProjectLocations { get; set; }
        public virtual DbSet<ProjectPointLocation> ProjectPointLocation { get; set; }
        public virtual DbSet<ProjectWiseProgram> ProjectWiseProgram { get; set; }
        public virtual DbSet<ProjectWithBdpGoals> ProjectWithBdpGoals { get; set; }
        public virtual DbSet<ProjectWithSdgGoals> ProjectWithSdgGoals { get; set; }
        public virtual DbSet<ProjectWithStrategies> ProjectWithStrategies { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ScenariosDetailsYearwise> ScenariosDetailsYearwise { get; set; }
        public virtual DbSet<ScenariosSubitem> ScenariosSubitem { get; set; }
        public virtual DbSet<Scenariositem> Scenariositem { get; set; }
        public virtual DbSet<Sdg> Sdg { get; set; }
        public virtual DbSet<SenarioStrategies> SenarioStrategies { get; set; }
        public virtual DbSet<Senarios> Senarios { get; set; }
        public virtual DbSet<StategiesTopic> StategiesTopic { get; set; }
        public virtual DbSet<StategiesType> StategiesType { get; set; }
        public virtual DbSet<Strategies> Strategies { get; set; }
        public virtual DbSet<VwCropLose> VwCropLose { get; set; }
        public virtual DbSet<VwCropLoseAnnual> VwCropLoseAnnual { get; set; }
        public virtual DbSet<VwCropLoss> VwCropLoss { get; set; }
        public virtual DbSet<VwCropLossAnnual> VwCropLossAnnual { get; set; }
        public virtual DbSet<VwCropLossAnnualMut> VwCropLossAnnualMut { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=banglamm.postgres.database.azure.com;Port=5432;Database=metamodel_db_test;User ID=admin_banglamm@banglamm;Password=Monday87!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("postgis");

            modelBuilder.Entity<Agencies>(entity =>
            {
                entity.ToTable("agencies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("short_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AgencyProjects>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AgencyId, e.ProjectCode })
                    .HasName("agency_projects_pkey");

                entity.ToTable("agency_projects");

                entity.HasIndex(e => new { e.AgencyId, e.ProjectCode })
                    .HasName("agency_projects_agency_id_project_code_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AgencyId).HasColumnName("agency_id");

                entity.Property(e => e.ProjectCode)
                    .HasColumnName("project_code")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.AgencyProjects)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agency_projects_agency_id_fkey");

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.AgencyProjects)
                    .HasForeignKey(d => d.ProjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agency_projects_project_code_fkey");
            });

            modelBuilder.Entity<BdDistricts>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("bd_districts_pkey");

                entity.ToTable("bd_districts");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.DistClass).HasColumnName("dist_class");

                entity.Property(e => e.District1)
                    .HasColumnName("district_1")
                    .HasMaxLength(4);

                entity.Property(e => e.DistrictC)
                    .HasColumnName("district_c")
                    .HasMaxLength(4);

                entity.Property(e => e.DistrictN)
                    .HasColumnName("district_n")
                    .HasMaxLength(100);

                entity.Property(e => e.DivisionC)
                    .HasColumnName("division_c")
                    .HasMaxLength(2);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Objectid).HasColumnName("objectid");

                entity.Property(e => e.ShapeArea)
                    .HasColumnName("shape_area")
                    .HasColumnType("numeric");

                entity.Property(e => e.ShapeLeng)
                    .HasColumnName("shape_leng")
                    .HasColumnType("numeric");

                entity.Property(e => e.ZoneClass).HasColumnName("zone_class");
            });

            modelBuilder.Entity<BdpGoals>(entity =>
            {
                entity.HasKey(e => e.BdpGoalsCode)
                    .HasName("BdpGoals_pkey");

                entity.ToTable("bdp_goals");

                entity.Property(e => e.BdpGoalsCode)
                    .HasColumnName("bdp_goals_code")
                    .HasMaxLength(20);

                entity.Property(e => e.BdpGoalsName)
                    .IsRequired()
                    .HasColumnName("bdp_goals_name")
                    .HasMaxLength(200);

                entity.Property(e => e.SlNo).HasColumnName("sl_no");
            });

            modelBuilder.Entity<BdpWithIndicator>(entity =>
            {
                entity.ToTable("bdp_with_indicator");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BdpGoalsCode)
                    .IsRequired()
                    .HasColumnName("bdp_goals_code")
                    .HasMaxLength(50);

                entity.Property(e => e.IndicatorCode)
                    .IsRequired()
                    .HasColumnName("indicator_code")
                    .HasMaxLength(50);

                entity.HasOne(d => d.BdpGoalsCodeNavigation)
                    .WithMany(p => p.BdpWithIndicator)
                    .HasForeignKey(d => d.BdpGoalsCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bdp_with_indicator_bdp_goals_code_fkey");

                entity.HasOne(d => d.IndicatorCodeNavigation)
                    .WithMany(p => p.BdpWithIndicator)
                    .HasForeignKey(d => d.IndicatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bdp_with_indicator_indicator_code_fkey");
            });

            modelBuilder.Entity<CropLoss>(entity =>
            {
                entity.ToTable("crop_loss");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CollectedDate).HasColumnName("collected_date");

                entity.Property(e => e.CropTypeId).HasColumnName("crop_type_id");

                entity.Property(e => e.IndicatorCode)
                    .IsRequired()
                    .HasColumnName("indicator_code")
                    .HasMaxLength(20);

                entity.Property(e => e.IndicatorValue).HasColumnName("indicator_value");

                entity.Property(e => e.LossTypeId).HasColumnName("loss_type_id");

                entity.Property(e => e.RunCode).HasColumnName("run_code");

                entity.Property(e => e.UpzCode)
                    .IsRequired()
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);

                entity.HasOne(d => d.CropType)
                    .WithMany(p => p.CropLoss)
                    .HasForeignKey(d => d.CropTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crop_loss_crop_type_id_fkey1");

                entity.HasOne(d => d.LossType)
                    .WithMany(p => p.CropLoss)
                    .HasForeignKey(d => d.LossTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crop_loss_loss_type_id_fkey1");

                entity.HasOne(d => d.RunCodeNavigation)
                    .WithMany(p => p.CropLoss)
                    .HasForeignKey(d => d.RunCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crop_loss_run_code_fkey");

                entity.HasOne(d => d.UpzCodeNavigation)
                    .WithMany(p => p.CropLoss)
                    .HasForeignKey(d => d.UpzCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crop_loss_upz_code_fkey");
            });

            modelBuilder.Entity<CropLosses>(entity =>
            {
                entity.ToTable("crop_losses");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('crop_loss_id_seq'::regclass)");

                entity.Property(e => e.AreaAffectedHa).HasColumnName("area_affected_ha");

                entity.Property(e => e.CollectedDate).HasColumnName("collected_date");

                entity.Property(e => e.CropTypeId).HasColumnName("crop_type_id");

                entity.Property(e => e.LossMt).HasColumnName("loss_mt");

                entity.Property(e => e.LossTypeId).HasColumnName("loss_type_id");

                entity.Property(e => e.RunCode).HasColumnName("run_code");

                entity.Property(e => e.UpzCode)
                    .IsRequired()
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);

                entity.HasOne(d => d.CropType)
                    .WithMany(p => p.CropLosses)
                    .HasForeignKey(d => d.CropTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crop_loss_crop_type_id_fkey");

                entity.HasOne(d => d.LossType)
                    .WithMany(p => p.CropLosses)
                    .HasForeignKey(d => d.LossTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crop_loss_loss_type_id_fkey");

                entity.HasOne(d => d.RunCodeNavigation)
                    .WithMany(p => p.CropLosses)
                    .HasForeignKey(d => d.RunCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crop_losses_run_code_fkey");

                entity.HasOne(d => d.UpzCodeNavigation)
                    .WithMany(p => p.CropLosses)
                    .HasForeignKey(d => d.UpzCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crop_losses_upz_code_fkey");
            });

            modelBuilder.Entity<CropTypes>(entity =>
            {
                entity.ToTable("crop_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CropTypeName)
                    .IsRequired()
                    .HasColumnName("crop_type_name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<GeoDistricts>(entity =>
            {
                entity.HasKey(e => e.DistCode)
                    .HasName("geo_districts_pkey");

                entity.ToTable("geo_districts");

                entity.Property(e => e.DistCode)
                    .HasColumnName("dist_code")
                    .HasMaxLength(4);

                entity.Property(e => e.DistName)
                    .IsRequired()
                    .HasColumnName("dist_name")
                    .HasMaxLength(50);

                entity.Property(e => e.DivCode)
                    .IsRequired()
                    .HasColumnName("div_code")
                    .HasMaxLength(2);

                entity.Property(e => e.SlNo)
                    .HasColumnName("sl_no")
                    .HasDefaultValueSql("nextval('geo_district_id_seq'::regclass)");

                entity.HasOne(d => d.DivCodeNavigation)
                    .WithMany(p => p.GeoDistricts)
                    .HasForeignKey(d => d.DivCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("geo_districts_div_code_fkey");
            });

            modelBuilder.Entity<GeoDivisions>(entity =>
            {
                entity.HasKey(e => e.DivCode)
                    .HasName("geo_divisions_pkey");

                entity.ToTable("geo_divisions");

                entity.Property(e => e.DivCode)
                    .HasColumnName("div_code")
                    .HasMaxLength(2);

                entity.Property(e => e.DivName)
                    .IsRequired()
                    .HasColumnName("div_name")
                    .HasMaxLength(50);

                entity.Property(e => e.SlNo)
                    .HasColumnName("sl_no")
                    .HasDefaultValueSql("nextval('geo_divisions_id_seq'::regclass)");
            });

            modelBuilder.Entity<GeoUpazilas>(entity =>
            {
                entity.HasKey(e => e.UpzCode)
                    .HasName("geo_upazilas_pkey");

                entity.ToTable("geo_upazilas");

                entity.Property(e => e.UpzCode)
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);

                entity.Property(e => e.DistCode)
                    .IsRequired()
                    .HasColumnName("dist_code")
                    .HasMaxLength(4);

                entity.Property(e => e.DivCode)
                    .IsRequired()
                    .HasColumnName("div_code")
                    .HasMaxLength(2);

                entity.Property(e => e.SlNo)
                    .HasColumnName("sl_no")
                    .HasDefaultValueSql("nextval('geo_upazila_id_seq'::regclass)");

                entity.Property(e => e.UpzName)
                    .IsRequired()
                    .HasColumnName("upz_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.DistCodeNavigation)
                    .WithMany(p => p.GeoUpazilas)
                    .HasForeignKey(d => d.DistCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("geo_upazilas_dist_code_fkey");
            });

            modelBuilder.Entity<Indicator>(entity =>
            {
                entity.HasKey(e => e.IndicatorCode)
                    .HasName("Indicator_pkey");

                entity.ToTable("indicator");

                entity.Property(e => e.IndicatorCode)
                    .HasColumnName("indicator_code")
                    .HasMaxLength(20);

                entity.Property(e => e.IndicatorDescription)
                    .HasColumnName("indicator_description")
                    .HasMaxLength(1000);

                entity.Property(e => e.IndicatorIdBdp)
                    .HasColumnName("indicator_id_bdp")
                    .HasMaxLength(6);

                entity.Property(e => e.IndicatorName)
                    .IsRequired()
                    .HasColumnName("indicator_name")
                    .HasMaxLength(1000);

                entity.Property(e => e.Unit).HasMaxLength(100);
            });

            modelBuilder.Entity<LossTypes>(entity =>
            {
                entity.ToTable("loss_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('loss_type_id_seq'::regclass)");

                entity.Property(e => e.LossTypeName)
                    .IsRequired()
                    .HasColumnName("loss_type_name")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Ministries>(entity =>
            {
                entity.ToTable("ministries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("short_name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<MinistryProjects>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MinistryId, e.ProjectCode })
                    .HasName("ministry_projects_pkey");

                entity.ToTable("ministry_projects");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MinistryId).HasColumnName("ministry_id");

                entity.Property(e => e.ProjectCode)
                    .HasColumnName("project_code")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Ministry)
                    .WithMany(p => p.MinistryProjects)
                    .HasForeignKey(d => d.MinistryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ministry_projects_ministry_id_fkey");

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.MinistryProjects)
                    .HasForeignKey(d => d.ProjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ministry_projects_project_code_fkey");
            });

            modelBuilder.Entity<PgBuffercache>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_buffercache");

                entity.Property(e => e.Bufferid).HasColumnName("bufferid");

                entity.Property(e => e.Isdirty).HasColumnName("isdirty");

                entity.Property(e => e.PinningBackends).HasColumnName("pinning_backends");

                entity.Property(e => e.Relblocknumber).HasColumnName("relblocknumber");

                entity.Property(e => e.Reldatabase)
                    .HasColumnName("reldatabase")
                    .HasColumnType("oid");

                entity.Property(e => e.Relfilenode)
                    .HasColumnName("relfilenode")
                    .HasColumnType("oid");

                entity.Property(e => e.Relforknumber).HasColumnName("relforknumber");

                entity.Property(e => e.Reltablespace)
                    .HasColumnName("reltablespace")
                    .HasColumnType("oid");

                entity.Property(e => e.Usagecount).HasColumnName("usagecount");
            });

            modelBuilder.Entity<PgStatStatements>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnName("dbid")
                    .HasColumnType("oid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("oid");
            });

            modelBuilder.Entity<PowerBi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PowerBI");

                entity.HasComment("temporary for powerBI load");

                entity.Property(e => e.AreaAffectedHa).HasColumnName("area_affected_ha");

                entity.Property(e => e.CollectedDate).HasColumnName("collected_date");

                entity.Property(e => e.CropTypeId).HasColumnName("crop_type_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('crop_loss_id_seq'::regclass)");

                entity.Property(e => e.LossMt).HasColumnName("loss_mt");

                entity.Property(e => e.LossTypeId).HasColumnName("loss_type_id");

                entity.Property(e => e.RunCode).HasColumnName("run_code");

                entity.Property(e => e.UpzCode)
                    .IsRequired()
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.HasKey(e => e.ProgramCode)
                    .HasName("program_pkey");

                entity.ToTable("program");

                entity.Property(e => e.ProgramCode)
                    .HasColumnName("program_code")
                    .HasMaxLength(20);

                entity.Property(e => e.ProgramName)
                    .IsRequired()
                    .HasColumnName("program_name")
                    .HasMaxLength(200);

                entity.Property(e => e.SlNo).HasColumnName("sl_no");
            });

            modelBuilder.Entity<ProjectInfo>(entity =>
            {
                entity.ToTable("project_info");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Info)
                    .HasColumnName("info")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ProjectLocations>(entity =>
            {
                entity.ToTable("project_locations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DistCode)
                    .HasColumnName("dist_code")
                    .HasMaxLength(4);

                entity.Property(e => e.DivCode)
                    .IsRequired()
                    .HasColumnName("div_code")
                    .HasMaxLength(2);

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasColumnName("project_code")
                    .HasMaxLength(50);

                entity.Property(e => e.UpzCode)
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);

                entity.HasOne(d => d.UpzCodeNavigation)
                    .WithMany(p => p.ProjectLocations)
                    .HasForeignKey(d => d.UpzCode)
                    .HasConstraintName("project_locations_upz_code_fkey");
            });

            modelBuilder.Entity<ProjectPointLocation>(entity =>
            {
                entity.ToTable("project_point_location");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasColumnName("project_code")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.ProjectPointLocation)
                    .HasForeignKey(d => d.ProjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_point_location_project_code_fkey");
            });

            modelBuilder.Entity<ProjectWiseProgram>(entity =>
            {
                entity.ToTable("project_wise_program");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProgramCode)
                    .IsRequired()
                    .HasColumnName("program_code")
                    .HasMaxLength(20);

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasColumnName("project_code")
                    .HasMaxLength(20);

                entity.HasOne(d => d.ProgramCodeNavigation)
                    .WithMany(p => p.ProjectWiseProgram)
                    .HasForeignKey(d => d.ProgramCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_wise_program_program_code_fkey");

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.ProjectWiseProgram)
                    .HasForeignKey(d => d.ProjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_wise_program_project_code_fkey");
            });

            modelBuilder.Entity<ProjectWithBdpGoals>(entity =>
            {
                entity.ToTable("project_with_bdp_goals");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BdpGoalsCode)
                    .IsRequired()
                    .HasColumnName("bdp_goals_code")
                    .HasMaxLength(20);

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasColumnName("project_code")
                    .HasMaxLength(20);

                entity.HasOne(d => d.BdpGoalsCodeNavigation)
                    .WithMany(p => p.ProjectWithBdpGoals)
                    .HasForeignKey(d => d.BdpGoalsCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_with_bdp_goals_bdp_goals_code_fkey");

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.ProjectWithBdpGoals)
                    .HasForeignKey(d => d.ProjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_with_bdp_goals_project_code_fkey");
            });

            modelBuilder.Entity<ProjectWithSdgGoals>(entity =>
            {
                entity.ToTable("project_with_sdg_goals");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasColumnName("project_code")
                    .HasMaxLength(20);

                entity.Property(e => e.SdgGoalsCode)
                    .IsRequired()
                    .HasColumnName("sdg_goals_code")
                    .HasMaxLength(20);

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.ProjectWithSdgGoals)
                    .HasForeignKey(d => d.ProjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_with_sdg_goals_project_code_fkey");

                entity.HasOne(d => d.SdgGoalsCodeNavigation)
                    .WithMany(p => p.ProjectWithSdgGoals)
                    .HasForeignKey(d => d.SdgGoalsCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_with_sdg_goals_sdg_goals_code_fkey");
            });

            modelBuilder.Entity<ProjectWithStrategies>(entity =>
            {
                entity.ToTable("project_with_strategies");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasColumnName("project_code")
                    .HasMaxLength(20);

                entity.Property(e => e.StrategiesCode)
                    .IsRequired()
                    .HasColumnName("strategies_code")
                    .HasMaxLength(20);

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.ProjectWithStrategies)
                    .HasForeignKey(d => d.ProjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_with_strategies_project_code_fkey");

                entity.HasOne(d => d.StrategiesCodeNavigation)
                    .WithMany(p => p.ProjectWithStrategies)
                    .HasForeignKey(d => d.StrategiesCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_with_strategies_strategies_code_fkey");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectCode)
                    .HasName("projects_pkey");

                entity.ToTable("projects");

                entity.HasIndex(e => e.ProjectCode)
                    .HasName("projects_project_code_key")
                    .IsUnique();

                entity.Property(e => e.ProjectCode)
                    .HasColumnName("project_code")
                    .HasMaxLength(50);

                entity.Property(e => e.Benefits)
                    .HasColumnName("benefits")
                    .HasMaxLength(1000);

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(1000);

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.EstimatedCost).HasColumnName("estimated_cost");

                entity.Property(e => e.ExecutingAgency)
                    .HasColumnName("executing_agency")
                    .HasMaxLength(1000);

                entity.Property(e => e.Hotspot)
                    .HasColumnName("hotspot")
                    .HasMaxLength(1000);

                entity.Property(e => e.IsProjectActive).HasColumnName("is_project_active");

                entity.Property(e => e.ProjectIntervention)
                    .HasColumnName("project_intervention")
                    .HasMaxLength(1000);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("project_name")
                    .HasMaxLength(1000);

                entity.Property(e => e.ProjectObjectives)
                    .HasColumnName("project_objectives")
                    .HasMaxLength(1000);

                entity.Property(e => e.ResponsibleMinistry)
                    .HasColumnName("responsible_ministry")
                    .HasMaxLength(1000);

                entity.Property(e => e.SlNo)
                    .HasColumnName("sl_no")
                    .HasDefaultValueSql("nextval('projects_id_seq'::regclass)");

                entity.Property(e => e.Upazila)
                    .HasColumnName("upazila")
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<ScenariosDetailsYearwise>(entity =>
            {
                entity.HasKey(e => e.ScenariosDetailsId)
                    .HasName("scenarios_details_yearwise_pkey");

                entity.ToTable("scenarios_details_yearwise");

                entity.Property(e => e.ScenariosDetailsId).HasColumnName("scenarios_details_id");

                entity.Property(e => e.ScenariosId)
                    .HasColumnName("scenarios_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ScenariosItemId)
                    .HasColumnName("scenarios_item_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ScenariosSubitemId)
                    .HasColumnName("scenarios_subitem_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e._2015)
                    .HasColumnName("2015")
                    .HasColumnType("numeric");

                entity.Property(e => e._2020)
                    .HasColumnName("2020")
                    .HasColumnType("numeric");

                entity.Property(e => e._2030)
                    .HasColumnName("2030")
                    .HasColumnType("numeric");

                entity.Property(e => e._2040)
                    .HasColumnName("2040")
                    .HasColumnType("numeric");

                entity.Property(e => e._2050)
                    .HasColumnName("2050")
                    .HasColumnType("numeric");

                entity.Property(e => e._2100)
                    .HasColumnName("2100")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Scenarios)
                    .WithMany(p => p.ScenariosDetailsYearwise)
                    .HasForeignKey(d => d.ScenariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("scenarios_details_yearwise_scenarios_id_fkey");

                entity.HasOne(d => d.ScenariosItem)
                    .WithMany(p => p.ScenariosDetailsYearwise)
                    .HasForeignKey(d => d.ScenariosItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("scenarios_details_yearwise_scenarios_item_id_fkey");

                entity.HasOne(d => d.ScenariosSubitem)
                    .WithMany(p => p.ScenariosDetailsYearwise)
                    .HasForeignKey(d => d.ScenariosSubitemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("scenarios_details_yearwise_scenarios_subitem_id_fkey");
            });

            modelBuilder.Entity<ScenariosSubitem>(entity =>
            {
                entity.ToTable("scenarios_subitem");

                entity.Property(e => e.ScenariosSubitemId).HasColumnName("scenarios_subitem_id");

                entity.Property(e => e.ScenariosSubitemDescription)
                    .HasColumnName("scenarios_subitem_description")
                    .HasMaxLength(1000);

                entity.Property(e => e.ScenariosSubitemName)
                    .IsRequired()
                    .HasColumnName("scenarios_subitem_name")
                    .HasMaxLength(500);

                entity.Property(e => e.ScenariosSubitemUnit)
                    .IsRequired()
                    .HasColumnName("scenarios_subitem_unit")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Scenariositem>(entity =>
            {
                entity.ToTable("scenariositem");

                entity.Property(e => e.ScenariositemId).HasColumnName("scenariositem_id");

                entity.Property(e => e.ScenariositemName)
                    .IsRequired()
                    .HasColumnName("scenariositem_name")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Sdg>(entity =>
            {
                entity.HasKey(e => e.SdgCode)
                    .HasName("sdg_pkey");

                entity.ToTable("sdg");

                entity.Property(e => e.SdgCode)
                    .HasColumnName("sdg_code")
                    .HasMaxLength(20);

                entity.Property(e => e.SdgName)
                    .IsRequired()
                    .HasColumnName("sdg_name")
                    .HasMaxLength(200);

                entity.Property(e => e.SlNo).HasColumnName("sl_no");
            });

            modelBuilder.Entity<SenarioStrategies>(entity =>
            {
                entity.HasKey(e => e.RunCode)
                    .HasName("senario_strategies_pkey");

                entity.ToTable("senario_strategies");

                entity.Property(e => e.RunCode)
                    .HasColumnName("run_code")
                    .HasDefaultValueSql("nextval('senario_strategies_id_seq'::regclass)");

                entity.Property(e => e.SenarioId).HasColumnName("senario_id");

                entity.Property(e => e.StrategyCode)
                    .IsRequired()
                    .HasColumnName("strategy_code")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Senario)
                    .WithMany(p => p.SenarioStrategies)
                    .HasForeignKey(d => d.SenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("senario_strategies_senario_id_fkey");

                entity.HasOne(d => d.StrategyCodeNavigation)
                    .WithMany(p => p.SenarioStrategies)
                    .HasForeignKey(d => d.StrategyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("senario_strategies_strategy_code_fkey");
            });

            modelBuilder.Entity<Senarios>(entity =>
            {
                entity.ToTable("senarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClimateImage)
                    .HasColumnName("climate_image")
                    .HasMaxLength(200);

                entity.Property(e => e.ClimateSenarioScale)
                    .IsRequired()
                    .HasColumnName("climate_senario_scale")
                    .HasMaxLength(5);

                entity.Property(e => e.EconomicImage)
                    .HasColumnName("economic_image")
                    .HasMaxLength(200);

                entity.Property(e => e.EconomicSenarioScale)
                    .IsRequired()
                    .HasColumnName("economic_senario_scale")
                    .HasMaxLength(5);

                entity.Property(e => e.ScenarioCombineName)
                    .HasColumnName("scenario_CombineName")
                    .HasMaxLength(30);

                entity.Property(e => e.SenarioName)
                    .HasColumnName("senario_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<StategiesTopic>(entity =>
            {
                entity.HasKey(e => e.StategiesTopicCode)
                    .HasName("StategiesTopic_pkey");

                entity.ToTable("stategies_topic");

                entity.Property(e => e.StategiesTopicCode)
                    .HasColumnName("stategies_topic_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.StategiesTopicName)
                    .IsRequired()
                    .HasColumnName("stategies_topic_name")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<StategiesType>(entity =>
            {
                entity.HasKey(e => e.StategiesTypeCode)
                    .HasName("StategiesType_pkey");

                entity.ToTable("stategies_type");

                entity.Property(e => e.StategiesTypeCode)
                    .HasColumnName("stategies_type_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.StategiesTypeName)
                    .IsRequired()
                    .HasColumnName("stategies_type_name")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Strategies>(entity =>
            {
                entity.HasKey(e => e.StategiesCode)
                    .HasName("strategies_pkey");

                entity.ToTable("strategies");

                entity.Property(e => e.StategiesCode)
                    .HasColumnName("stategies_code")
                    .HasMaxLength(20);

                entity.Property(e => e.SlNo).HasColumnName("sl_no");

                entity.Property(e => e.StategiesTopicCode).HasColumnName("stategies_topic_code");

                entity.Property(e => e.StategiesTypeCode).HasColumnName("stategies_type_code");

                entity.Property(e => e.StrategyName)
                    .IsRequired()
                    .HasColumnName("strategy_name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.StategiesTopicCodeNavigation)
                    .WithMany(p => p.Strategies)
                    .HasForeignKey(d => d.StategiesTopicCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("strategies_stategies_topic_code_fkey");

                entity.HasOne(d => d.StategiesTypeCodeNavigation)
                    .WithMany(p => p.Strategies)
                    .HasForeignKey(d => d.StategiesTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("strategies_stategies_type_code_fkey");
            });

            modelBuilder.Entity<VwCropLose>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_crop_lose");

                entity.Property(e => e.AreaAffectedHa).HasColumnName("area_affected_ha");

                entity.Property(e => e.CollectedDate).HasColumnName("collected_date");

                entity.Property(e => e.LossMt).HasColumnName("loss_mt");

                entity.Property(e => e.RunCode).HasColumnName("run_code");

                entity.Property(e => e.UpzCode)
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<VwCropLoseAnnual>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_crop_lose_annual");

                entity.Property(e => e.AreaAffectedHa).HasColumnName("area_affected_ha");

                entity.Property(e => e.CollectedDate).HasColumnName("collected_date");

                entity.Property(e => e.CropTypeId).HasColumnName("crop_type_id");

                entity.Property(e => e.LossMtAnnual).HasColumnName("loss_mt_annual");

                entity.Property(e => e.LossTypeId).HasColumnName("loss_type_id");

                entity.Property(e => e.RunCode).HasColumnName("run_code");

                entity.Property(e => e.UpzCode)
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<VwCropLoss>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_crop_loss");

                entity.Property(e => e.AreaAffectedHa).HasColumnName("area_affected_ha");

                entity.Property(e => e.CollectedDate).HasColumnName("collected_date");

                entity.Property(e => e.CropTypeId).HasColumnName("crop_type_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LossMt).HasColumnName("loss_mt");

                entity.Property(e => e.LossTypeId).HasColumnName("loss_type_id");

                entity.Property(e => e.UpzCode)
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<VwCropLossAnnual>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_crop_loss_annual");

                entity.Property(e => e.CollectedDate).HasColumnName("collected_date");

                entity.Property(e => e.CropTypeId).HasColumnName("crop_type_id");

                entity.Property(e => e.IndicatorCode)
                    .HasColumnName("indicator_code")
                    .HasMaxLength(20);

                entity.Property(e => e.IndicatorValue).HasColumnName("indicator_value");

                entity.Property(e => e.LossTypeId).HasColumnName("loss_type_id");

                entity.Property(e => e.RunCode).HasColumnName("run_code");

                entity.Property(e => e.UpzCode)
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<VwCropLossAnnualMut>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_crop_loss_annual_mut");

                entity.Property(e => e.CollectedDate).HasColumnName("collected_date");

                entity.Property(e => e.CropTypeId).HasColumnName("crop_type_id");

                entity.Property(e => e.IndicatorCode)
                    .HasColumnName("indicator_code")
                    .HasMaxLength(20);

                entity.Property(e => e.IndicatorValue).HasColumnName("indicator_value");

                entity.Property(e => e.LossTypeId).HasColumnName("loss_type_id");

                entity.Property(e => e.RunCode).HasColumnName("run_code");

                entity.Property(e => e.UpzCode)
                    .HasColumnName("upz_code")
                    .HasMaxLength(6);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
