﻿using System.Collections.Generic;
using System.Linq;
using CrossfitDiaryCore.DAL.EF;
using CrossfitDiaryCore.DAL.EF.Exercises;
using CrossfitDiaryCore.DAL.EF.WorkoutMatchers;
using CrossfitDiaryCore.Model;

namespace CrossfitDiaryCore.BL.Services
{
    public class ReadWorkoutsService
    {
        private readonly WorkouterContext _context;
        private readonly WorkoutsMatchDispatcher _workoutsMatchDispatcher;

        public ReadWorkoutsService(WorkouterContext  context, WorkoutsMatchDispatcher workoutsMatchDispatcher)
        {
            _context = context;
            _workoutsMatchDispatcher = workoutsMatchDispatcher;
        }


//        /// <summary>
//        /// Find existing workout by workout structure
//        /// </summary>
//        /// <param name="routineComplexToSave">
//        /// The routine complex to save.
//        /// </param>
//        /// <param name="workoutId">
//        /// The workout id if found
//        /// </param>
//        /// <returns>
//        /// The <see cref="bool"/>.
//        /// </returns>
//        public virtual int FindDefaultOrExistingWorkout(RoutineComplex routineComplexToSave)
//        {
//            List<RoutineComplex> workoutsToCheck = _routineComplexRepository.GetAll().ToList();
//            foreach (RoutineComplex existingRoutineComplex in workoutsToCheck)
//            {
//                if (_workoutsMatchDispatcher.IsWorkoutsMatch(existingRoutineComplex, routineComplexToSave) == false)
//                {
//                    continue;
//                }
//                return existingRoutineComplex.Id;
//            }
//
//            return 0;
//        }
//
//
//
        /// <summary>
        /// The get person maximum for exercise.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="exerciseId">
        ///     The exercise id.
        /// </param>
        /// <returns>
        /// The <see cref="PersonMaximum"/>.
        /// </returns>
        public PersonMaximum GetPersonMaximumForExercise(string userId, int exerciseId)
        {
            
            List<CrossfitterWorkout> workoutsWithExericesOnly = _context.CrossfitterWorkouts.Where(x => x.Crossfitter.Id == userId
                                      && (x.RoutineComplex.RoutineSimple.Any(y => y.ExerciseId == exerciseId)
                                      || x.RoutineComplex.Children.Any(child => child.RoutineSimple.Any(chZ => chZ.ExerciseId == exerciseId)))
                                      && x.RepsToFinishOnCapTime.HasValue == false)
                                    
                        .ToList();

            
            string exerciseAbbreviation = _context.Exercises.Single(x => x.Id == exerciseId).Abbreviation;

            var routineDictionary = new Dictionary<int, List<RoutineSimple>>();
            foreach (CrossfitterWorkout workout in workoutsWithExericesOnly)
            {
                if (routineDictionary.ContainsKey(workout.Id))
                {
                    routineDictionary[workout.Id].AddRange(workout.RoutineComplex.RoutineSimple);
                }
                else
                {
                    routineDictionary[workout.Id] = new List<RoutineSimple>((workout.RoutineComplex.RoutineSimple));
                }
                routineDictionary[workout.Id].AddRange(workout.RoutineComplex.Children.SelectMany(x => x.RoutineSimple));

            }

            PersonMaximum maximum = (from crossfitterWorkout in workoutsWithExericesOnly
                select new PersonMaximum
                {
                    Date = crossfitterWorkout.Date,
                    PersonName = crossfitterWorkout.Crossfitter.FullName,
                    PersonId = crossfitterWorkout.Crossfitter.Id,
                    WorkoutTitle = crossfitterWorkout.RoutineComplex.Title,
                    CrossfitWorkoutId = crossfitterWorkout.Id,
                    ExerciseDisplayName = exerciseAbbreviation,
                    ExerciseId = exerciseId,
                    MaximumWeight = (
                        from exercise in routineDictionary.Where(x => x.Key == crossfitterWorkout.Id).SelectMany(x => x.Value)
                        where exercise.ExerciseId == exerciseId
                        select exercise.Weight
                    ).Max()
                }).OrderByDescending(x => x.MaximumWeight).ThenBy(x => x.Date).FirstOrDefault();

            if (maximum?.MaximumWeight != null)
            {
                PersonMaximum secondMaximum = (from crossfitterWorkout in workoutsWithExericesOnly
                    select new PersonMaximum
                    {
                        MaximumWeight = (
                            from exercise in routineDictionary.Where(x => x.Key == crossfitterWorkout.Id).SelectMany(x => x.Value)
                            where exercise.ExerciseId == exerciseId && exercise.Weight != maximum.MaximumWeight
                            select exercise.Weight
                        ).Max()
                    }).OrderByDescending(x => x.MaximumWeight).ThenBy(x => x.Date).FirstOrDefault();

                maximum.PreviousMaximumWeight = secondMaximum?.MaximumWeight;
            }
            return maximum;

        }
//
//
//        public List<PersonMaximum> GetAllPersonMaximumForExercise(int exerciseId, string currentUserId)
//        {
//            IEnumerable<CrossfitterWorkout> workoutsWithExericesOnly = _crossfitterWorkoutRepository.GetMany(x => x.RoutineComplex.RoutineSimple.Any(y => y.ExerciseId == exerciseId));
//            var groupedByCrossfitter = workoutsWithExericesOnly.GroupBy(x => x.Crossfitter.Id);
//            var resultMaximums = new List<PersonMaximum>();
//            foreach (var group in groupedByCrossfitter)
//            {
//                resultMaximums.Add(GetPersonMaximumForExercise(group.Key, exerciseId));
//            }
//
//            resultMaximums = resultMaximums.OrderByDescending(x => x.MaximumWeight).ToList();
//            for (int i = 0; i < resultMaximums.Count; i++)
//            {
//                resultMaximums[i].PositionBetweenOthers = i + 1;
//                resultMaximums[i].IsItMe = resultMaximums[i].PersonId == currentUserId;
//            }
//
//            return resultMaximums;
//        }
//
//        public List<PersonMaximum> GetPersonMaximumsWithAllExercises(string currentUserId)
//        {
//            IEnumerable<CrossfitterWorkout> crossfiterWorkouts = _crossfitterWorkoutRepository
//                .GetMany(x => x.Crossfitter.Id == currentUserId 
//                              && x.RoutineComplex.RoutineSimple.Any(y => y.Weight.HasValue &&  y.Exercise.ExerciseMeasures.Any(z => z.ExerciseMeasureType.MeasureType == MeasureType.Weight))).ToList();
//            IEnumerable<int> exerciseIds = crossfiterWorkouts.SelectMany(x => x.RoutineComplex.RoutineSimple)
//                .Select(x => x.ExerciseId)
//                .Distinct()
//                .ToList();
//            var personMaximums = new List<PersonMaximum>();
//            foreach (int exerciseId in exerciseIds)
//            {
//                PersonMaximum maximum = GetPersonMaximumForExercise(currentUserId, exerciseId);
//                if (maximum?.MaximumWeight != null && maximum.MaximumWeight != 0)
//                {
//                    personMaximums.Add(maximum);
//                }
//
//            }
//            return personMaximums;
//        }
//
//
        /// <summary>
        ///     Returns all crossfitters workouts.
        /// </summary>
        public List<CrossfitterWorkout> GetAllCrossfittersWorkouts(string userId, int? exerciseId, int page, int pageSize)
        {
            List<CrossfitterWorkout> crossfitterWorkouts = string.IsNullOrEmpty(userId)? _context.CrossfitterWorkouts.ToList() : _context.CrossfitterWorkouts.Where(x => x.Crossfitter.Id == userId).ToList();
            crossfitterWorkouts = FilterWorkoutsOnSelectedExercise(crossfitterWorkouts, exerciseId);

            UpdateWorkoutsWithRecords(crossfitterWorkouts);
            List<CrossfitterWorkout> allCrossfittersWorkouts = crossfitterWorkouts.OrderByDescending(x => x.Date).ThenByDescending(x => x.CreatedUtc).ToList().Skip(((page - 1) * pageSize)).Take(pageSize).ToList();
            foreach (CrossfitterWorkout allCrossfittersWorkout in allCrossfittersWorkouts)
            {
                allCrossfittersWorkout.RoutineComplex.Children = allCrossfittersWorkout.RoutineComplex.Children.OrderBy(x => x.Position).ToList();
            }
            return allCrossfittersWorkouts;
        }


        /// <summary>
        ///     Find exercise maximums and mark crossfitter workout as having new maximum and exercise as new max
        /// </summary>
        /// <param name="crossfitterWorkouts"></param>
        private void UpdateWorkoutsWithRecords(List<CrossfitterWorkout> crossfitterWorkouts)
        {
            IEnumerable<IGrouping<ApplicationUser, CrossfitterWorkout>> groupedByuser = crossfitterWorkouts.GroupBy(x => x.Crossfitter);

            foreach (IGrouping<ApplicationUser, CrossfitterWorkout> personWorkouts in groupedByuser)
            {
                List<Exercise> allDistinctExercisesFromWorkouts = personWorkouts
                                .SelectMany(x => x.RoutineComplex.RoutineSimple.Select(y => y.Exercise))
                                .Union(personWorkouts.SelectMany(x => x.RoutineComplex.Children.SelectMany(z => z.RoutineSimple)).Select(x => x.Exercise))
                                .Distinct()
                                .ToList();
                foreach (Exercise exercise in allDistinctExercisesFromWorkouts)
                {
                    var user = personWorkouts.Key;
                    PersonMaximum personMaximum =  GetPersonMaximumForExercise(user.Id, exercise.Id);
                    MarkWorkoutWithWeightRecord(personMaximum, crossfitterWorkouts);
                }
            }
        }

        /// <summary>
        ///     Implement inner logic for marking crossfit workout with record
        /// </summary>
        /// <param name="personMaximum"></param>
        /// <param name="crossfitterWorkouts"></param>
        public void MarkWorkoutWithWeightRecord(PersonMaximum personMaximum, List<CrossfitterWorkout> crossfitterWorkouts)
        {
            if (personMaximum == null || personMaximum.MaximumWeight == null || personMaximum.MaximumWeight == 0)
            {
                return;
            }

            CrossfitterWorkout workoutToAddMaximum = crossfitterWorkouts.SingleOrDefault(x => x.Id == personMaximum.CrossfitWorkoutId);
            if (workoutToAddMaximum == null)
            {
                return;
            }

            if (workoutToAddMaximum.RoutineComplex.Children.Any())
            {
                foreach (RoutineComplex routineComplexChild in workoutToAddMaximum.RoutineComplex.Children.Where(z => z.RoutineSimple.Any(x => x.ExerciseId == personMaximum.ExerciseId && x.Weight == personMaximum.MaximumWeight)))
                {
                    RoutineSimple routineSimple = routineComplexChild.RoutineSimple.First(x => x.ExerciseId == personMaximum.ExerciseId && x.Weight == personMaximum.MaximumWeight);
                    routineSimple.IsNewWeightMaximum = true;
                    routineSimple.AddedToMaxWeight = personMaximum.PreviousMaximumWeight.HasValue?personMaximum.MaximumWeight - personMaximum.PreviousMaximumWeight:null;
                }
            }
            else
            {
                RoutineSimple routineSimple = workoutToAddMaximum.RoutineComplex.RoutineSimple.First(x => x.ExerciseId == personMaximum.ExerciseId && x.Weight == personMaximum.MaximumWeight);
                routineSimple.IsNewWeightMaximum = true;
                routineSimple.AddedToMaxWeight = personMaximum.PreviousMaximumWeight.HasValue?personMaximum.MaximumWeight - personMaximum.PreviousMaximumWeight:null;
            }
        }

        /// <summary>
        /// Filters workouts having the exercise if it not null
        /// </summary>
        /// <param name="crossfitterWorkouts"></param>
        /// <param name="exerciseId"></param>
        private List<CrossfitterWorkout> FilterWorkoutsOnSelectedExercise(List<CrossfitterWorkout> crossfitterWorkouts, int? exerciseId)
        {
            if (exerciseId.HasValue == false)
            {
                return crossfitterWorkouts;
            }

            return crossfitterWorkouts.Where(x => x.RoutineComplex.RoutineSimple.Any(y => y.ExerciseId == exerciseId) || x.RoutineComplex.Children.Any(childW => childW.RoutineSimple.Any(c => c.ExerciseId == exerciseId))).ToList();
        }
//
//
//        /// <summary>
//        /// The get crossfitter workout.
//        /// </summary>
//        /// <param name="crossfitterWorkoutId"></param>
//        /// <returns>
//        /// The <see cref="CrossfitterWorkout"/>.
//        /// </returns>
//        public CrossfitterWorkout GetCrossfitterWorkout(int crossfitterWorkoutId)
//        {
//            CrossfitterWorkout crossfitterWorkout = _crossfitterWorkoutRepository.Single(x => x.Id == crossfitterWorkoutId);
//            return crossfitterWorkout;
//        }
//
//
//        public void RemoveWorkout(int crossfitterWorkoutId, ApplicationUser user)
//        {
//            _crossfitterWorkoutRepository.Delete(x => x.Id == crossfitterWorkoutId && x.Crossfitter.Id == user.Id);
//            _unitOfWork.Commit();
//        }
//
//        public List<PersonMaximum> GetPersonMaximumForMainExercises(string userId, int? exerciseId)
//        {
//            var exercisesListTitle = new List<string> { "deadlift", "back squat", "bench press", "shoulder press (strict)", "snatch", "power snatch", "clean", "power clean" };
//            var resultMaximums = new List<PersonMaximum>();
//
//            var exercisesList = new List<Exercise>();
//            foreach (string exerciseTitle in exercisesListTitle)
//            {
//                Exercise exercise = _exerciseRepository.FirstOrDefault(x => x.Title.ToLower() == exerciseTitle.ToLower());
//                exercisesList.Add(exercise);
//            }
//
//            if (exerciseId.HasValue)
//            {
//                exercisesList = exercisesList.Where(x => x.Id == exerciseId).ToList();
//            }
//
//            foreach (Exercise exercise in exercisesList)
//            {
//                PersonMaximum personMaximumForExercise = GetPersonMaximumForExercise(userId, exercise.Id);
//                if (personMaximumForExercise == null)
//                {
//                    continue;
//                }
//
//                personMaximumForExercise.ExerciseDisplayName = exercise.Abbreviation;
//                resultMaximums.Add(personMaximumForExercise);
//            }
//
//            return resultMaximums;
//        }
    }
}