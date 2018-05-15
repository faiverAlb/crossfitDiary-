var Models;
(function (Models) {
    var PersonExerciseRecord = (function () {
        function PersonExerciseRecord(params) {
            if (params == null) {
                return;
            }
            this.personName = params.personName;
            this.maximumWeight = params.maximumWeight;
            this.date = params.date;
            this.workoutTitle = params.workoutTitle;
            this.positionBetweenOthers = params.positionBetweenOthers;
            this.isItMe = params.isItMe;
        }
        PersonExerciseRecord.prototype.deserialize = function (input) {
            if (input == null) {
                return null;
            }
            return new PersonExerciseRecord({
                personName: input.personName,
                maximumWeight: input.maximumWeight,
                date: input.date,
                workoutTitle: input.workoutTitle,
                positionBetweenOthers: input.positionBetweenOthers,
                isItMe: input.isItMe
            });
        };
        return PersonExerciseRecord;
    }());
    Models.PersonExerciseRecord = PersonExerciseRecord;
})(Models || (Models = {}));
//# sourceMappingURL=PersonExerciseRecord.js.map