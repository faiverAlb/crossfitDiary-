﻿var LogWorkoutController = function (parameters) {
    var self = this;
    self.service = new CrossfitterService(parameters.pathToApp);
    self.availableWorkouts = ko.observableArray(parameters.viewModel.availableWorkouts);
    self.selectedWorkout = ko.observable();
    self.isReadOnlyMode = true;

    self.totalRoundsFinished = ko.observable();
    self.partialRepsFinished = ko.observable();

    self.distance = ko.observable();
    self.generalPoints = ko.observable();

    self.wasFinished = ko.observable();
    self.isRx = ko.observable(true);
    self.IsModified = ko.observable();
    self.workoutToDisplay = ko.observable();
    self.totalTime = ko.observable();

    self.canSeeTotalRounds = ko.observable();
    self.canSeePassedDistance = ko.observable();
    self.canSeeGeneralPoints = ko.observable();
    self.canSeeTotalTime = ko.observable();


    self.logWorkout = function () {
        self.service.logWorkout(self.toJSON());
    };

    function updateInputsVisibility() {
        var selectedTypeValue = self.workoutToDisplay().selectedWorkoutType().Value;

        /* Rounds */
        self.canSeeTotalRounds(selectedTypeValue == Crossfitter.WorkoutTypes.AMRAP);

        /* Distance input */
        self.canSeePassedDistance(checkWorkoutContainsDistanceExercise() && selectedTypeValue == Crossfitter.WorkoutTypes.EMOM);

        /* General points */
        self.canSeeGeneralPoints(selectedTypeValue == Crossfitter.WorkoutTypes.Points);

        /* General time */
        self.canSeeTotalTime(selectedTypeValue == Crossfitter.WorkoutTypes.ForTime);
    }

    function checkWorkoutContainsDistanceExercise() {
        return ko.utils.arrayFirst(self.workoutToDisplay().simpleRoutines(), function(routine) {
            var foundDistanceMeasure = ko.utils.arrayFirst(routine.exerciseMeasures(), function (measure) {
                return measure.measureType() == Crossfitter.ExerciseMeasureTypes.Distance;
            });
            return foundDistanceMeasure;
        }) != null;
    }

    ko.computed(function() {
        var workout = self.selectedWorkout();
        if (!workout) {
            return;
        }
        workout.isReadOnlyMode = self.isReadOnlyMode;
        self.workoutToDisplay(new CrossfitterController(workout));

        updateInputsVisibility();
    });


    self.toJSON = function() {
        var model = {
            selectedWorkoutId: self.selectedWorkout().id,
            roundsFinished: self.totalRoundsFinished,
            partialRepsFinished: self.partialRepsFinished,
            timePassed: self.totalTime,
            distance: self.distance,
            points: self.generalPoints,
            wasFinished: self.wasFinished,
            isRx: self.isRx()
        };
        return model;
    };

    return self;
};
