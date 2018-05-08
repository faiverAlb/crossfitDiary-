var Models;
(function (Models) {
    var ExerciseMeasureTypeViewModel = (function () {
        function ExerciseMeasureTypeViewModel(params) {
            if (params == null) {
                return;
            }
            this.measureType = params.measureType;
            this.measureValue = params.measureValue;
            this.description = params.description;
            this.shortMeasureDescription = params.shortMeasureDescription;
            this.isRequired = params.isRequired;
        }
        ExerciseMeasureTypeViewModel.prototype.deserialize = function (input) {
            if (input == null) {
                return null;
            }
            return new ExerciseMeasureTypeViewModel({
                measureType: input.measureType,
                measureValue: input.measureValue,
                description: input.description,
                isRequired: input.isRequired,
                shortMeasureDescription: input.shortMeasureDescription,
            });
        };
        return ExerciseMeasureTypeViewModel;
    }());
    Models.ExerciseMeasureTypeViewModel = ExerciseMeasureTypeViewModel;
    ;
})(Models || (Models = {}));
//# sourceMappingURL=ExerciseMeasureTypeViewModel.js.map