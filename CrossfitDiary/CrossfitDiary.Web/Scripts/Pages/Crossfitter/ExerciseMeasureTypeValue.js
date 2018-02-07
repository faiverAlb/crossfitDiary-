var Crossfitter;
(function (Crossfitter) {
    var ExerciseMeasureTypeValue = (function () {
        function ExerciseMeasureTypeValue(model, isRequired) {
            var _this = this;
            this.toJSON = function () { return ({
                exerciseMeasureType: {
                    measureType: _this.measureType(),
                    measureValue: _this.measureValue()
                }
            }); };
            this.measureType = ko.observable(model.measureType);
            this.measureValue = ko.observable().extend({ required: isRequired });
            if (parseFloat(model.measureValue)) {
                this.measureValue(parseFloat(model.measureValue));
            }
            this.measureDesciption = ko.observable(model.description);
            this.shortMeasureDescription = ko.observable(model.shortMeasureDescription);
        }
        return ExerciseMeasureTypeValue;
    }());
    Crossfitter.ExerciseMeasureTypeValue = ExerciseMeasureTypeValue;
})(Crossfitter || (Crossfitter = {}));
//# sourceMappingURL=ExerciseMeasureTypeValue.js.map