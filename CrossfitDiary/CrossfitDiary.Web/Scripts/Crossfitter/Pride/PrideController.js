var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var PrideController = (function (_super) {
    __extends(PrideController, _super);
    function PrideController(basicParameters) {
        var _this = _super.call(this) || this;
        _this.loadExercises = function () {
            _this._service.getStatisticalExercises()
                .then(function (exercises) {
                _this._exercises(exercises);
            });
        };
        _this._service = new CrossfitterService(basicParameters.pathToApp);
        _this._exercises = ko.observableArray([]);
        _this._personMaximums = ko.observableArray([]);
        _this._allPersonsMaximums = ko.observableArray([]);
        _this._selectedExercise = ko.observable();
        _this.initiateFiltering(_this._allPersonsMaximums, [{ value: "personName" }, { value: "date" }]);
        _this.loadExercises();
        ko.computed(function () {
            var exercise = _this._selectedExercise();
            if (!exercise) {
                return;
            }
            _this._service.getPersonExerciseMaximumWeight(exercise.id)
                .then(function (personMaximums) {
                _this._personMaximums(personMaximums);
            })
                .then(function () {
                return _this._service.getAllPersonsExerciseMaximumWeights(exercise.id);
            })
                .then(function (allPersonsRecords) {
                _this._allPersonsMaximums($.map(allPersonsRecords, function (item) { return new ObservablePersonExerciseRecord(item.personName, item.maximumWeight, item.date, item.workoutTitle); }));
            });
        });
        return _this;
    }
    return PrideController;
}(General.FilterableViewModel));
var PersonExerciseRecord = (function () {
    function PersonExerciseRecord() {
    }
    return PersonExerciseRecord;
}());
var ObservablePersonExerciseRecord = (function () {
    function ObservablePersonExerciseRecord(personName, maximumWeight, date, workoutTitle) {
        this.personName = ko.observable(personName);
        this.maximumWeight = ko.observable(maximumWeight);
        this.date = ko.observable(date);
        this.workoutTitle = ko.observable(workoutTitle);
    }
    return ObservablePersonExerciseRecord;
}());
//# sourceMappingURL=PrideController.js.map