﻿using System.Collections.Generic;
using CrossfitDiary.Model;

namespace CrossfitDiary.Service.Interfaces
{
    public interface ICrossfitterService
    {
        void CreateWorkout(RoutineComplex map);
        void LogWorkout(CrossfitterWorkout map);

        List<CrossfitterWorkout> GetCrossfitterWorkouts(ApplicationUser userId);
    }
}