import { ExerciseMeasureType } from "./ExerciseMeasureType";
var ExerciseMeasureTypeViewModel = /** @class */ (function () {
    function ExerciseMeasureTypeViewModel(params) {
        this.measureType = ExerciseMeasureType.Weight;
        this.measureValue = '';
        this.description = '';
        this.shortMeasureDescription = '';
        this.isRequired = false;
        if (params == null) {
            return;
        }
        this.measureType = params.measureType;
        this.measureValue = params.measureValue;
        this.description = params.description;
        this.shortMeasureDescription = params.shortMeasureDescription;
        this.isRequired = params.isRequired;
    }
    ExerciseMeasureTypeViewModel.prototype.deserialize = function (jsonInput) {
        if (jsonInput == null) {
            return (null);
        }
        return new ExerciseMeasureTypeViewModel({
            measureType: jsonInput.measureType,
            measureValue: jsonInput.measureValue,
            description: jsonInput.description,
            isRequired: jsonInput.isRequired,
            shortMeasureDescription: jsonInput.shortMeasureDescription,
        });
    };
    return ExerciseMeasureTypeViewModel;
}());
export { ExerciseMeasureTypeViewModel };
;
//# sourceMappingURL=ExerciseMeasureTypeViewModel.js.map