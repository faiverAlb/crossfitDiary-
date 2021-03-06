﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossfitDiaryCore.Model
{
    /// <summary>
    /// Part of <see cref="RoutineComplex"/>
    /// </summary>
    /// <example>Wod: Cindy. 
    /// 5 pull-ups, 10 push-ups, 15 air squats.
    /// "5 pull-ups" - Simple Routine
    /// </example>
    public class RoutineSimple : BaseModel
    {
        /// <summary>
        /// Foreign Key to Exercise
        /// </summary>
        public int ExerciseId { get; set; }

        /// <summary>
        /// Exercise is a part of the simple routine
        /// </summary>
        public virtual Exercise Exercise { get; set; }

        /// <summary>
        /// Foreign Key to Routine Complex
        /// </summary>
        public int RoutineComplexId { get; set; }

        /// <summary>
        /// Link to Routine Complex
        /// </summary>
        public RoutineComplex RoutineComplex { get; set; }

        /// <summary>
        /// Possible time to work of this routine
        /// </summary>
        public TimeSpan? TimeToWork { get; set; }

        /// <summary>
        /// Possible count to do for this routine
        /// </summary>
        public decimal? Count { get; set; }


        /// <summary>
        /// Possible distance (meters) to pass
        /// </summary>
        public decimal? Distance { get; set; }

        /// <summary>
        /// Possible weight in kgs
        /// </summary>
        public decimal? Weight { get; set; }


        /// <summary>
        /// Possible alternative weight in kgs
        /// </summary>
        public decimal? AlternativeWeight { get; set; }

        /// <summary>
        /// Calories to make
        /// </summary>
        public decimal? Calories { get; set; }

        /// <summary>
        /// Centimeters to jump
        /// </summary>
        public decimal? Centimeters { get; set; }

        /// <summary>
        /// Possible seconds to hold for this routine
        /// </summary>
        public int? Seconds { get; set; }


        /// <summary>
        /// Specify does this exercise is alternative exercise (primarily used in EMOM/E2MOM)
        /// </summary>
        public bool IsAlternative { get; set; }

        /// <summary>
        ///     Should be done without break
        /// </summary>
        public bool IsDoUnbroken { get; set; }


        /// <summary>
        ///     Specify position of exercise between other exercises
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        ///     Describes how which weight we should display - fixed or calculated based on person's maximums in exercise
        /// </summary>
        public WeightDisplayType WeightDisplayType { get; set; } = WeightDisplayType.Default;


        /// <summary>
        ///     % of weight to calculate
        /// </summary>
        public double? WeightPercentValue { get; set; }

        [NotMapped]
        public decimal? CalculatedWeight { get; private set; }

        public void CalculateWeight(decimal? maxWeight)
        {
            if (Weight.HasValue)
            {
                return;
            }
            if (maxWeight == null)
            {
                Weight = 0;
            }
            switch (WeightPercentValue)
            {
                case null:
                    break;
                case 0:
                    Weight = 0;
                    break;
                default:
                    Weight = (maxWeight / 100 * (decimal?) WeightPercentValue);
                    break;
            }

        }
    }

    public enum WeightDisplayType
    {
        Default = 0,
        PercentPreviousPM,
        PercentMaxPM = 2
    }
}