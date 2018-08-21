var Models;
(function (Models) {
    var ExerciseMeasureViewModel = /** @class */ (function () {
        function ExerciseMeasureViewModel(params) {
            this.exerciseMeasureType = null;
            if (params == null) {
                return;
            }
            this.exerciseMeasureType = params.exerciseMeasureType;
        }
        ExerciseMeasureViewModel.prototype.deserialize = function (input) {
            if (input == null) {
                return (null);
            }
            return new ExerciseMeasureViewModel({
                exerciseMeasureType: new Models.ExerciseMeasureTypeViewModel().deserialize(input.exerciseMeasureType)
            });
        };
        return ExerciseMeasureViewModel;
    }());
    Models.ExerciseMeasureViewModel = ExerciseMeasureViewModel;
})(Models || (Models = {}));
//# sourceMappingURL=ExerciseMeasureViewModel.js.map