﻿// <auto-generated />
using System;
using CrossfitDiaryCore.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrossfitDiaryCore.DAL.EF.Migrations
{
    [DbContext(typeof(WorkouterContext))]
    [Migration("20200202181314_AddSecondsForRoutineSimple")]
    partial class AddSecondsForRoutineSimple
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrossfitDiaryCore.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("CanPlanWorkouts")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ShowOnlyUserWods")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.CrossfitterWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("CrossfitterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Distance")
                        .HasColumnType("int");

                    b.Property<bool>("IsModified")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRx")
                        .HasColumnType("bit");

                    b.Property<int?>("PartialRepsFinished")
                        .HasColumnType("int");

                    b.Property<int?>("RepsToFinishOnCapTime")
                        .HasColumnType("int");

                    b.Property<int?>("RoundsFinished")
                        .HasColumnType("int");

                    b.Property<int>("RoutineComplexId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("TimePassed")
                        .HasColumnType("time");

                    b.Property<bool>("WasFinished")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WodSubType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CrossfitterId");

                    b.HasIndex("RoutineComplexId");

                    b.ToTable("CrossfitterWorkout");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercise");

                    b.HasData(
                        new
                        {
                            Id = 130,
                            Abbreviation = "HSC",
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hang Squat Clean"
                        },
                        new
                        {
                            Id = 131,
                            Abbreviation = "HCP",
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hang Clean Pull"
                        },
                        new
                        {
                            Id = 132,
                            Abbreviation = "DDL",
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Deficit Deadlift"
                        },
                        new
                        {
                            Id = 133,
                            Abbreviation = "PSBH",
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pistol squat bottom hold"
                        },
                        new
                        {
                            Id = 134,
                            Abbreviation = "Pegboard",
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pegboard"
                        },
                        new
                        {
                            Id = 135,
                            Abbreviation = "Ring PshU",
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Ring Push-Up"
                        },
                        new
                        {
                            Id = 136,
                            Abbreviation = "Burpee D-ball over box",
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Burpee D-ball over box"
                        });
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.ExerciseMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseMeasureTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseMeasure");

                    b.HasData(
                        new
                        {
                            Id = 311,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 130,
                            ExerciseMeasureTypeId = 2
                        },
                        new
                        {
                            Id = 312,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 130,
                            ExerciseMeasureTypeId = 3
                        },
                        new
                        {
                            Id = 313,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 130,
                            ExerciseMeasureTypeId = 8
                        },
                        new
                        {
                            Id = 314,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 131,
                            ExerciseMeasureTypeId = 2
                        },
                        new
                        {
                            Id = 315,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 131,
                            ExerciseMeasureTypeId = 3
                        },
                        new
                        {
                            Id = 316,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 131,
                            ExerciseMeasureTypeId = 8
                        },
                        new
                        {
                            Id = 317,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 132,
                            ExerciseMeasureTypeId = 2
                        },
                        new
                        {
                            Id = 318,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 132,
                            ExerciseMeasureTypeId = 3
                        },
                        new
                        {
                            Id = 319,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 132,
                            ExerciseMeasureTypeId = 8
                        },
                        new
                        {
                            Id = 320,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 133,
                            ExerciseMeasureTypeId = 2
                        },
                        new
                        {
                            Id = 321,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 133,
                            ExerciseMeasureTypeId = 11
                        },
                        new
                        {
                            Id = 322,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 134,
                            ExerciseMeasureTypeId = 2
                        },
                        new
                        {
                            Id = 323,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 134,
                            ExerciseMeasureTypeId = 3
                        },
                        new
                        {
                            Id = 324,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 134,
                            ExerciseMeasureTypeId = 8
                        },
                        new
                        {
                            Id = 325,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 135,
                            ExerciseMeasureTypeId = 2
                        },
                        new
                        {
                            Id = 326,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 135,
                            ExerciseMeasureTypeId = 3
                        },
                        new
                        {
                            Id = 327,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 135,
                            ExerciseMeasureTypeId = 8
                        },
                        new
                        {
                            Id = 328,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 136,
                            ExerciseMeasureTypeId = 2
                        },
                        new
                        {
                            Id = 329,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 136,
                            ExerciseMeasureTypeId = 3
                        },
                        new
                        {
                            Id = 330,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExerciseId = 136,
                            ExerciseMeasureTypeId = 8
                        });
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.PlanningHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("CrossfitterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PlanningDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlanningLevel")
                        .HasColumnType("int");

                    b.Property<int>("RoutineComplexId")
                        .HasColumnType("int");

                    b.Property<int>("WodSubType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CrossfitterId");

                    b.HasIndex("RoutineComplexId");

                    b.ToTable("PlanningHistory");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.RoutineComplex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AsNonBreakingSet")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComplexType")
                        .HasColumnType("int");

                    b.Property<string>("CreatedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<bool>("FindMaxWeight")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("RestBetweenExercises")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("RestBetweenRounds")
                        .HasColumnType("time");

                    b.Property<int?>("RoundCount")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("TimeCap")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("TimeToWork")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ParentId");

                    b.ToTable("RoutineComplex");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.RoutineSimple", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AlternativeWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Calories")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Centimeters")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Count")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<decimal?>("Distance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAlternative")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDoUnbroken")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("RoutineComplexId")
                        .HasColumnType("int");

                    b.Property<int?>("Seconds")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("TimeToWork")
                        .HasColumnType("time");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WeightDisplayType")
                        .HasColumnType("int");

                    b.Property<double?>("WeightPercentValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("RoutineComplexId");

                    b.ToTable("RoutineSimple");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.CrossfitterWorkout", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser", "Crossfitter")
                        .WithMany("CrossfitterWorkout")
                        .HasForeignKey("CrossfitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrossfitDiaryCore.Model.RoutineComplex", "RoutineComplex")
                        .WithMany()
                        .HasForeignKey("RoutineComplexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.ExerciseMeasure", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.Exercise", "Exercise")
                        .WithMany("ExerciseMeasures")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.PlanningHistory", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser", "Crossfitter")
                        .WithMany("PlanningHistoryCollection")
                        .HasForeignKey("CrossfitterId");

                    b.HasOne("CrossfitDiaryCore.Model.RoutineComplex", "RoutineComplex")
                        .WithMany()
                        .HasForeignKey("RoutineComplexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.RoutineComplex", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser", "CreatedBy")
                        .WithMany("RoutineComplexCollection")
                        .HasForeignKey("CreatedById");

                    b.HasOne("CrossfitDiaryCore.Model.RoutineComplex", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.RoutineSimple", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrossfitDiaryCore.Model.RoutineComplex", "RoutineComplex")
                        .WithMany("RoutineSimple")
                        .HasForeignKey("RoutineComplexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
