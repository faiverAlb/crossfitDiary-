﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CrossfitDiaryCore.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        /// <summary>
        ///     Rights to plan new workouts for others
        /// </summary>
        public bool CanPlanWorkouts { get; set; }


        public virtual ICollection<CrossfitterWorkout> CrossfitterWorkout { get; set; }

        public virtual ICollection<RoutineComplex> RoutineComplexCollection { get; set; }

    }
}