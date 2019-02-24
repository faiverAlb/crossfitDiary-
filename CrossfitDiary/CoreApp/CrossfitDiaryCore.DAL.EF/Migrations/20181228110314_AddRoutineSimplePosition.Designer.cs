﻿// <auto-generated />
using CrossfitDiaryCore.DAL.EF;
using CrossfitDiaryCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CrossfitDiaryCore.DAL.EF.Migrations
{
    [DbContext(typeof(WorkouterContext))]
    [Migration("20181228110314_AddRoutineSimplePosition")]
    partial class AddRoutineSimplePosition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrossfitDiaryCore.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
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
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("CrossfitterId")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("Distance");

                    b.Property<bool>("IsModified");

                    b.Property<bool>("IsPlanned");

                    b.Property<bool>("IsRx");

                    b.Property<int?>("PartialRepsFinished");

                    b.Property<int?>("RepsToFinishOnCapTime");

                    b.Property<int?>("RoundsFinished");

                    b.Property<int>("RoutineComplexId");

                    b.Property<TimeSpan?>("TimePassed");

                    b.Property<bool>("WasFinished");

                    b.HasKey("Id");

                    b.HasIndex("CrossfitterId");

                    b.HasIndex("RoutineComplexId");

                    b.ToTable("CrossfitterWorkout");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation")
                        .IsRequired();

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.ExerciseMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("ExerciseId");

                    b.Property<int>("ExerciseMeasureTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("ExerciseMeasureTypeId");

                    b.ToTable("ExerciseMeasure");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.ExerciseMeasureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("MeasureType");

                    b.Property<string>("ShortMeasureDescription")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ExerciseMeasureType");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.RoutineComplex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComplexType");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int?>("ParentId");

                    b.Property<int>("Position");

                    b.Property<TimeSpan?>("RestBetweenExercises");

                    b.Property<TimeSpan?>("RestBetweenRounds");

                    b.Property<int?>("RoundCount");

                    b.Property<TimeSpan?>("TimeCap");

                    b.Property<TimeSpan?>("TimeToWork");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ParentId");

                    b.ToTable("RoutineComplex");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.RoutineSimple", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Calories");

                    b.Property<decimal?>("Centimeters");

                    b.Property<decimal?>("Count");

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<decimal?>("Distance");

                    b.Property<int>("ExerciseId");

                    b.Property<bool>("IsAlternative");

                    b.Property<bool>("IsDoUnbroken");

                    b.Property<int>("Position");

                    b.Property<int>("RoutineComplexId");

                    b.Property<TimeSpan?>("TimeToWork");

                    b.Property<decimal?>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("RoutineComplexId");

                    b.ToTable("RoutineSimple");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
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
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.CrossfitterWorkout", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser", "Crossfitter")
                        .WithMany("CrossfitterWorkout")
                        .HasForeignKey("CrossfitterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrossfitDiaryCore.Model.RoutineComplex", "RoutineComplex")
                        .WithMany()
                        .HasForeignKey("RoutineComplexId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrossfitDiaryCore.Model.ExerciseMeasure", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.Exercise", "Exercise")
                        .WithMany("ExerciseMeasures")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrossfitDiaryCore.Model.ExerciseMeasureType", "ExerciseMeasureType")
                        .WithMany()
                        .HasForeignKey("ExerciseMeasureTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrossfitDiaryCore.Model.RoutineComplex", "RoutineComplex")
                        .WithMany("RoutineSimple")
                        .HasForeignKey("RoutineComplexId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CrossfitDiaryCore.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}