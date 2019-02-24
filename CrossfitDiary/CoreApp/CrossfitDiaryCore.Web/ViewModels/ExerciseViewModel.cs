﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrossfitDiaryCore.Web.ViewModels
{
    public class ExerciseViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("exerciseMeasures")]
        public IEnumerable<ExerciseMeasureViewModel> ExerciseMeasures { get; set; }

        [JsonProperty("isAlternative")]
        public bool IsAlternative { get; set; }

        [JsonProperty("isNewWeightMaximum")]
        public bool IsNewWeightMaximum { get; set; }

        [JsonProperty("isDoUnbroken")]
        public bool IsDoUnbroken { get; set; }

        [JsonProperty("addedToMaxWeightString")]
        public string AddedToMaxWeightString { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }


    public class ExerciseMeasureViewModel
    {
        [JsonProperty("measureType")]
        public MeasureTypeViewModel MeasureType { get; set; }

        [JsonProperty("measureValue")]
        public string MeasureValue { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("shortMeasureDescription")]
        public string ShortMeasureDescription { get; set; }

        [JsonProperty("isRequired")]
        public bool IsRequired { get; set; } = true;
    }
    

    public enum MeasureTypeViewModel
    {
        Distance = 1,
        Count = 2,
        Weight = 3,
        Calories = 4,
        Height = 5,
    }
}