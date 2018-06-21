﻿using System.Collections.Generic;
using System.Linq;
using CrossfitDiary.Model;

namespace CrossfitDiary.DAL.EF.DataContexts.CrossfitDiaryMigrations.Seeders
{
    public static partial class ExerciseSeeder
    {

        internal static List<Exercise> AddSeeds_June_2018_Fourth(CrossfitDiaryDbContext context)
        {
            if (IsExerciseAlreadyExist("Barbell overhead lunges", context))
            {
                return new List<Exercise>();
            }

            return new List<Exercise>
            {
                new Exercise {Title = "Barbell overhead lunges", Abbreviation = "Barbell OH lunges", ExerciseMeasures = GetExerciseMeasures(context, MeasureType.Weight, MeasureType.Distance)},
            };
        }
        internal static List<Exercise> AddSeeds_June_2018_21(CrossfitDiaryDbContext context)
        {
            if (IsExerciseAlreadyExist("Squat Snatch", context))
            {
                return new List<Exercise>();
            }

            return new List<Exercise>
            {
                new Exercise {Title = "Squat Snatch", Abbreviation = "Squat SN", ExerciseMeasures = GetExerciseMeasures(context, MeasureType.Count,MeasureType.Weight)},
            };
        }
    }
}