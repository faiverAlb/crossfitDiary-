﻿using System.Data.Entity.ModelConfiguration;
using CrossfitDiary.Model;

namespace CrossfitDiary.DAL.EF.Configuration
{
    public class RoutineComplexConfiguration : EntityTypeConfiguration<RoutineComplex>
    {
        public RoutineComplexConfiguration()
        {
            ToTable("RoutineComplex");
            Property(x => x.Id).IsRequired();
            Property(x => x.Title);
            Property(x => x.ComplexType).IsRequired();

            HasOptional(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
}