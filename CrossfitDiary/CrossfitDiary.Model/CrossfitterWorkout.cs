﻿using System;

namespace CrossfitDiary.Model
{
    public class CrossfitterWorkout : BaseModel
    {
        public CrossfitterWorkout()
        {
            Date = DateTime.Now;
        }

        public int RoutineComplexId { get; set; }

        public RoutineComplex RoutineComplex { get; set; }



        public ApplicationUser Crossfitter { get; set; }

        public int? RoundsFinished { get; set; }

        public int? PartialRepsFinished { get; set; }

        public TimeSpan? TimePassed { get; set; }

        public int? Distance { get; set; }

        public DateTime Date { get; set; }

        public int? Points { get; set; }

        public bool WasFinished { get; set; }

        public bool IsRx { get; set; }

        public bool IsModified { get; set; }
    }
}