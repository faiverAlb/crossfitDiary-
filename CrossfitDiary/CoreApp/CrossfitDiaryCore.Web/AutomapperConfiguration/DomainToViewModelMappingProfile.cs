﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CrossfitDiaryCore.Model;
using CrossfitDiaryCore.Model.TempModels;
using CrossfitDiaryCore.Web.AutomapperConfiguration.Resolvers;
using CrossfitDiaryCore.Web.ViewModels;
using CrossfitDiaryCore.Web.ViewModels.Pride;

namespace CrossfitDiaryCore.Web.AutomapperConfiguration
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => nameof(DomainToViewModelMappingProfile);

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Exercise, ExerciseViewModel>()
                .ForMember(x =>x.ExerciseMeasures, x => x.MapFrom(y => y.ExerciseMeasures))
                .AfterMap((exercise, model) =>
                {
                    foreach (var exerciseMeasureViewModel in model.ExerciseMeasures)
                    {
                        switch (exerciseMeasureViewModel.MeasureType)
                        {
                            case MeasureTypeViewModel.Weight:
                                exerciseMeasureViewModel.IsRequired = exercise.ExerciseMeasures.Count <= 1;
                                break;
                        }
                    }
                });
            CreateMap<MeasureType, MeasureTypeViewModel>();
            CreateMap<TempPersonMaximum, PersonMaximumViewModel>();
            CreateMap<ExerciseMeasure, ExerciseMeasureViewModel>()
                .ForMember(x => x.MeasureType, x => x.MapFrom(y => y.ExerciseMeasureTypeId))
                .AfterMap((exerciseMeasure, viewModel) =>
            {
                switch (exerciseMeasure.ExerciseMeasureTypeId)
                {
                    case MeasureType.Distance:
                        viewModel.ShortMeasureDescription = "m";
                        viewModel.Description = "Distance";
                        break;
                    case MeasureType.Count:
                        viewModel.ShortMeasureDescription = "count";
                        viewModel.Description = "Count";
                        break;
                    case MeasureType.Weight:
                        viewModel.ShortMeasureDescription = "kgs";
                        viewModel.Description = "Weight";
                        break;
                    case MeasureType.Calories:
                        viewModel.ShortMeasureDescription = "cal";
                        viewModel.Description = "Calories";
                        break;
                    case MeasureType.Height:
                        viewModel.ShortMeasureDescription = "cm";
                        viewModel.Description = "Height";
                        break;
                    case MeasureType.AlternativeWeight:
                        viewModel.ShortMeasureDescription = "kgs";
                        viewModel.Description = "Alt weight";
                        break;
                    case MeasureType.Time:
                        viewModel.ShortMeasureDescription = "sec";
                        viewModel.Description = "Seconds";
                        break;
                    default:
                        break;
                }
            });
            CreateMap<PersonMaximum, PersonExerciseMaximumViewModel>()
                .ForMember(x => x.Date, x => x.MapFrom(y => y.Date.ToString("d")))
                .ForMember(x => x.MaximumWeightValue, x => x.MapFrom(y => y.MaximumWeight))
                .ForMember(x => x.AddedToPreviousMaximum, x => x.MapFrom<WeightImprovementResolver>())
                .ForMember(x => x.MaximumWeight, x => x.MapFrom(y => y.MaximumWeight.HasValue == false? "-": $"{y.MaximumWeight.ToCustomString()} kg"));


            CreateMap<CrossfitterWorkout, ToLogWorkoutViewModel>()
                .ForMember(x => x.SelectedWorkoutName, x => x.MapFrom(y => y.RoutineComplex.Title))
                .ForMember(x => x.SelectedWorkoutId, x => x.MapFrom(y => y.RoutineComplex.Id))
                .ForMember(x => x.CrossfitterWorkoutId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.DisplayDate, x => x.MapFrom(y => y.Date.ToString("dd.MM.yyyy")))
                //TODO: Fix
                .ForMember(x => x.CanBeRemovedByCurrentUser, x => x.MapFrom<CanBeRemovedResolver>())
                .ForMember(x => x.WorkouterName, x => x.MapFrom(y => y.Crossfitter.FullName))
                .ForMember(x => x.WorkoutViewModel, x => x.MapFrom(y => y.RoutineComplex))
                .ForMember(x => x.WorkouterId, x => x.MapFrom(y => y.Crossfitter.Id))
                .ForMember(x => x.TimePassed, x => x.MapFrom<TimePassedResolver>())
                .AfterMap((crossfitterWorkout, toLogWorkoutViewModel) =>
                {
                    foreach (TempPersonMaximum personalRecord in crossfitterWorkout.PersonalRecords)
                    {

                        ExerciseViewModel routineSimple = toLogWorkoutViewModel.WorkoutViewModel.ExercisesToDoList.Single(x => x.TempRoutineSimpleId == personalRecord.RoutineSimpleId);
                        routineSimple.IsNewWeightMaximum = true;
                        routineSimple.AddedToMaxWeightString = $"+{personalRecord.AddedToMaxWeight.ToCustomString()}kg";
                    }
                    
                });


            // CreateMap<PlanningLevel, PlanningWorkoutLevel>();
            CreateMap<KeyValuePair<PlanningLevel, List<PlanningHistory>>, KeyValuePair<PlanningWorkoutLevel, List<PlanningWorkoutViewModel>>>();
            CreateMap<PlanningHistory, PlanningWorkoutViewModel>()
                .ForMember(x => x.WorkoutViewModel, x => x.MapFrom(y => y.RoutineComplex))
                .ForMember(x => x.PlanningWorkoutLevel, x => x.MapFrom(y => y.PlanningLevel))
                .ForMember(x => x.DisplayPlanDate, x => x.MapFrom(y => y.PlanningDate));

            CreateMap<RoutineComplex, WorkoutViewModel>()
                .ForMember(x => x.WorkoutType, x => x.MapFrom(y => y.ComplexType))
                .ForMember(x => x.Children, x => x.MapFrom(y => y.OrderedChildren))
                .ForMember(x => x.ExercisesToDoList, x => x.MapFrom(y => y.RoutineSimple))
                .ForMember(x => x.RoundsCount, x => x.MapFrom(y => y.RoundCount))
                .ForMember(x => x.TimeToWork, x => x.MapFrom(y => ResolveTimeSpan(y.TimeToWork)))
                .ForMember(x => x.TimeCap, x => x.MapFrom(y => ResolveTimeSpan(y.TimeCap)))
                .ForMember(x => x.RestBetweenExercises, x => x.MapFrom(y => ResolveTimeSpan(y.RestBetweenExercises)))
                .ForMember(x => x.RestBetweenRounds, x => x.MapFrom(y => ResolveTimeSpan(y.RestBetweenRounds)))
                .ForMember(x => x.CanSeeLeaderboard, x => x.MapFrom<ResolveCanSeeLeaderboard>())
               
                .AfterMap((routineComplex, workoutViewModel) =>
                    {
                        workoutViewModel.ExercisesToDoList = workoutViewModel.ExercisesToDoList.OrderBy(x => x.Position).ToList();
                    });

            CreateMap<RoutineSimple, ExerciseViewModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.ExerciseId))
                .ForMember(x => x.TempRoutineSimpleId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.ExerciseMeasures, opt => opt.Ignore())
                .ForMember(x => x.Title, opt => opt.MapFrom(y => y.Exercise.Title))
                .ForMember(x => x.Abbreviation, opt => opt.MapFrom(y => y.Exercise.Abbreviation))
//                .ForMember(x => x.AddedToMaxWeightString, opt => opt.MapFrom(y => y.AddedToMaxWeight.HasValue? $"+{y.AddedToMaxWeight.ToCustomString()}kg": null))
                .ForMember(x => x.IsDoUnbroken, opt => opt.MapFrom(y => y.IsDoUnbroken))
                .AfterMap((simple, dest) =>
                {
                    var toMapExercises = new List<ExerciseMeasureViewModel>();
                    foreach (ExerciseMeasure exerciseMeasure in simple.Exercise.ExerciseMeasures)
                    {
                        var exerviseMeasureVm = new ExerciseMeasureViewModel() {};
                        switch (exerciseMeasure.ExerciseMeasureTypeId)
                        {
                            case MeasureType.Distance:
                                exerviseMeasureVm.MeasureType = MeasureTypeViewModel.Distance;
                                exerviseMeasureVm.MeasureValue = simple.Distance.ToCustomString();
                                exerviseMeasureVm.Description = "Distance";
                                //simple.Exercise.ExerciseMeasures.Single(x => x.ExerciseMeasureTypeId == MeasureType.Distance).Description;
                                exerviseMeasureVm.ShortMeasureDescription = "m";
                                break;
                            case MeasureType.Count:
                                exerviseMeasureVm.MeasureType = MeasureTypeViewModel.Count;
                                exerviseMeasureVm.MeasureValue = $"{simple.Count:0}";
                                exerviseMeasureVm.Description = "Count";
                                exerviseMeasureVm.ShortMeasureDescription = "count";
                                break;
                            case MeasureType.Weight:
                                exerviseMeasureVm.MeasureType = MeasureTypeViewModel.Weight;
                                exerviseMeasureVm.MeasureValue = simple.Weight.ToCustomString();
                                exerviseMeasureVm.Description = "Weight";
                                exerviseMeasureVm.ShortMeasureDescription = "kgs";
                                exerviseMeasureVm.IsRequired = simple.Exercise.ExerciseMeasures.Count <= 1;
                                break;
                            case MeasureType.AlternativeWeight:
                                exerviseMeasureVm.MeasureType = MeasureTypeViewModel.AlternativeWeight;
                                exerviseMeasureVm.MeasureValue = simple.AlternativeWeight.ToCustomString();
                                exerviseMeasureVm.Description = "Alt weight";
                                exerviseMeasureVm.ShortMeasureDescription = "kgs";
                                exerviseMeasureVm.IsRequired = simple.Exercise.ExerciseMeasures.Count <= 1;
                                break;
                            case MeasureType.Calories:
                                exerviseMeasureVm.MeasureType = MeasureTypeViewModel.Calories;
                                exerviseMeasureVm.MeasureValue = $"{simple.Calories:0}";
                                exerviseMeasureVm.Description = "Calories";
                                exerviseMeasureVm.ShortMeasureDescription = "cal";
                                break;
                            case MeasureType.AlternativeCalories:
                                exerviseMeasureVm.MeasureType = MeasureTypeViewModel.Calories;
                                exerviseMeasureVm.MeasureValue = $"{simple.Calories:0}";
                                exerviseMeasureVm.Description = "Alt Calories";
                                exerviseMeasureVm.ShortMeasureDescription = "alt cal";
                                break;
                            case MeasureType.Height:
                                exerviseMeasureVm.MeasureType = MeasureTypeViewModel.Height;
                                exerviseMeasureVm.MeasureValue = $"{simple.Centimeters:0}";
                                exerviseMeasureVm.Description = "Height";
                                exerviseMeasureVm.ShortMeasureDescription = "cm";
                                break;
                            case MeasureType.Time:
                                exerviseMeasureVm.MeasureType = MeasureTypeViewModel.Time;
                                exerviseMeasureVm.MeasureValue = $"{simple.Seconds:0}";
                                exerviseMeasureVm.Description = "Seconds";
                                exerviseMeasureVm.ShortMeasureDescription = "sec";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        toMapExercises.Add(exerviseMeasureVm);
                    }
                    dest.ExerciseMeasures = toMapExercises;
                });
        }

        private string ResolveTimeSpan(TimeSpan? timeSpan)
        {
            if (timeSpan == null)
            {
                return string.Empty;
            }

            return $"{Math.Floor(timeSpan.Value.TotalMinutes):00}:{timeSpan.Value.Seconds:00}";
        }
    }
}