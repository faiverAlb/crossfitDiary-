var PersonExerciseRecord = /** @class */ (function () {
    function PersonExerciseRecord(params) {
        this.personName = '';
        this.maximumWeight = '';
        this.addedToPreviousMaximum = '';
        this.date = '';
        this.workoutTitle = '';
        this.positionBetweenOthers = 0;
        this.isItMe = false;
        this.exerciseId = 0;
        if (params == null) {
            return;
        }
        this.personName = params.personName;
        this.maximumWeight = params.maximumWeight;
        this.date = params.date;
        this.workoutTitle = params.workoutTitle;
        this.positionBetweenOthers = params.positionBetweenOthers;
        this.isItMe = params.isItMe;
        this.exerciseId = params.exerciseId;
        this.maximumWeightValue = params.maximumWeightValue;
    }
    PersonExerciseRecord.prototype.deserialize = function (input) {
        if (input == null) {
            return (null);
        }
        return new PersonExerciseRecord({
            personName: input.personName,
            maximumWeight: input.maximumWeight,
            addedToPreviousMaximum: input.addedToPreviousMaximum,
            date: input.date,
            workoutTitle: input.workoutTitle,
            positionBetweenOthers: input.positionBetweenOthers,
            isItMe: input.isItMe,
            exerciseId: input.exerciseId,
            maximumWeightValue: input.maximumWeightValue,
        });
    };
    return PersonExerciseRecord;
}());
export { PersonExerciseRecord };
//# sourceMappingURL=PersonExerciseRecord.js.map