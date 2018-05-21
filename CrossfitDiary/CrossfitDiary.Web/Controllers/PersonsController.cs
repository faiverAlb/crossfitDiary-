﻿using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CrossfitDiary.Service;
using CrossfitDiary.Web.ViewModels;
using CrossfitDiary.Web.ViewModels.Pride;
using Microsoft.AspNet.Identity;

namespace CrossfitDiary.Web.Controllers
{
    public partial class PersonsController : Controller
    {
        private readonly CrossfitterService _crossfitterService;

        public PersonsController(CrossfitterService crossfitterService)
        {
            _crossfitterService = crossfitterService;
        }
        public virtual ActionResult Index(string userId = null, int? exerciseId = null)
        {
            string userIdForWorkouts = exerciseId.HasValue && string.IsNullOrEmpty(userId)? User.Identity.GetUserId() : userId;
            string userIdForMaximums = string.IsNullOrEmpty(userId) ? User.Identity.GetUserId() : userId;
            PersonDataViewModel personDataViewModel = new PersonDataViewModel()
            {
                AllWorkouts = _crossfitterService.GetAllCrossfittersWorkouts(userIdForWorkouts, exerciseId).Select(Mapper.Map<ToLogWorkoutViewModel>).ToList(),
                PersonMaximums = _crossfitterService.GetPersonMaximumForMainExercises(userIdForMaximums, exerciseId).Select(x => Mapper.Map<PersonExerciseMaximumViewModel>(x)).OrderBy(x => x.ExerciseDisplayName).ToList(),
            };
            ViewBag.Title = "Person Page";
            ViewBag.UserId = userId;
            ViewBag.ExerciseId = exerciseId;
            return View(personDataViewModel);
        }
    }
}