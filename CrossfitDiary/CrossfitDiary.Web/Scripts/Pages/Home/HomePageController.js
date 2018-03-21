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
var Pages;
(function (Pages) {
    var BaseController = General.BaseController;
    var CrossfitterService = General.CrossfitterService;
    var HomePageController = (function (_super) {
        __extends(HomePageController, _super);
        function HomePageController(parameters) {
            var _this = _super.call(this) || this;
            _this.parameters = parameters;
            _this.removeWorkout = function (crossfitterWorkoutId) {
                _this._service.removeWorkout(crossfitterWorkoutId)
                    .finally(function () {
                    window.location.href = "/Home";
                });
            };
            _this.allWorkouts = _this.parameters.viewModel.allWorkouts;
            _this._service = new CrossfitterService(parameters.pathToApp);
            return _this;
        }
        return HomePageController;
    }(BaseController));
    Pages.HomePageController = HomePageController;
    ;
})(Pages || (Pages = {}));
//# sourceMappingURL=HomePageController.js.map