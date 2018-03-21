var Models;
(function (Models) {
    var PersonExerciseRecord = (function () {
        function PersonExerciseRecord() {
        }
        return PersonExerciseRecord;
    }());
    Models.PersonExerciseRecord = PersonExerciseRecord;
    var ObservablePersonExerciseRecord = (function () {
        function ObservablePersonExerciseRecord(personName, maximumWeight, date, workoutTitle, positionBetweenOthers, isItMe) {
            this.personName = ko.observable(personName);
            this.maximumWeight = ko.observable(maximumWeight);
            this.date = ko.observable(date);
            this.workoutTitle = ko.observable(workoutTitle);
            this.positionBetweenOthers = ko.observable(positionBetweenOthers);
            this.isItMe = ko.observable(isItMe);
        }
        return ObservablePersonExerciseRecord;
    }());
    Models.ObservablePersonExerciseRecord = ObservablePersonExerciseRecord;
})(Models || (Models = {}));
//# sourceMappingURL=PersonExerciseRecord.js.map