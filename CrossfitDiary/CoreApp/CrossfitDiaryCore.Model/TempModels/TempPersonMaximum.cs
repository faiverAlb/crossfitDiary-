﻿namespace CrossfitDiaryCore.Model.TempModels
{
    /// <summary>
    ///     Represents interim class for person maximum weight/alternative weight for an exercise
    /// </summary>
    public class TempPersonMaximum
    {
        public int ExerciseId { get; set; }

        public double? MaximumWeight { get; set; }

        public double? MaximumAlternativeWeight { get; set; }
    }
}