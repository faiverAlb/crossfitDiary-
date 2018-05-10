var Models;
(function (Models) {
    var ExerciseViewModelObservable = (function () {
        function ExerciseViewModelObservable(model) {
            var _this = this;
            this.model = model;
            this.toPlainObject = function () {
                var plainExercise = new Models.ExerciseViewModel({
                    id: _this.model.id,
                    title: _this.model.title,
                    exerciseMeasures: _this._exerciseMeasures.map(function (item) { return item.toPlainObject(); }),
                    isAlternative: _this.model.isAlternative
                });
                return plainExercise;
            };
            this._exerciseMeasures = model.exerciseMeasures.map(function (item) { return new Models.ExerciseMeasureViewModelObservable(item); });
        }
        return ExerciseViewModelObservable;
    }());
    Models.ExerciseViewModelObservable = ExerciseViewModelObservable;
})(Models || (Models = {}));
//# sourceMappingURL=ExerciseViewModelObservable.js.map