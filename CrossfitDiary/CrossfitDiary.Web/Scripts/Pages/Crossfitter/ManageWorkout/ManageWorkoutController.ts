﻿module Pages {
  import CrossfitterService = General.CrossfitterService;

  export class ManageWorkoutController {
    createWorkoutController: CreateWorkoutController;
    chooseExistingWorkoutController: ChooseExistingWorkoutController;
    service: CrossfitterService;
    logWorkoutController: KnockoutObservable<LogWorkoutController>;
    isAnyContainersVisible: KnockoutObservable<boolean>;
    isCreateNewWorkoutPressed: KnockoutObservable<boolean>;

    constructor(public parameters: { pathToApp: string }) {
      this.createWorkoutController = new CreateWorkoutController(parameters);
      this.chooseExistingWorkoutController = new ChooseExistingWorkoutController(parameters);
      this.logWorkoutController = ko.observable();

      this.service = new CrossfitterService(parameters.pathToApp);

      this.isAnyContainersVisible = ko.observable(false);
      this.isCreateNewWorkoutPressed = ko.observable(false);
      this.chooseExistingWorkoutController.workoutToDisplay.subscribe((newValue) => {
        if (!newValue) {
          return;
        }
        const lightLogModel = {
          selectedWorkoutType: newValue.selectedWorkoutType(),
          simpleRoutines: newValue.simpleRoutines(),
          selectedWorkout: this.chooseExistingWorkoutController.selectedWorkout,
          logWorkoutText: "Log workout"
        };

        this.createLogController(lightLogModel);
      });

      this.createWorkoutController.simpleRoutines.subscribe((newValue) => {
        if (!newValue || newValue.length === 0) {
          return;
        }
        var lightLogModel = {
          selectedWorkoutType: this.createWorkoutController.selectedWorkoutType(),
          simpleRoutines: this.createWorkoutController.simpleRoutines(),
          logWorkoutText: "Create and log workout"
        };
        this.createLogController(lightLogModel);
      });


      ko.computed(() => {
        this.isAnyContainersVisible(this.logWorkoutController() != null &&
          (this.chooseExistingWorkoutController.selectedWorkout() || this.createWorkoutController.hasAnyRoutines()));
      });

    }

    private logFunction = () => {
      const canLogWorkout = this.logWorkoutController().canLogWorkout();

      if (this.isCreateNewWorkoutPressed()) {
        const canCreateWorkout = this.createWorkoutController.canCreateCreateWorkout();
        if (canCreateWorkout && canLogWorkout) {
          const model = {
            newWorkoutViewModel: this.createWorkoutController.getCreateWorkoutModel(),
            logWorkoutViewModel: this.logWorkoutController().toJSON()
          };
          this.service.createAndLogWorkout(model);
        }
      } else {
        if (canLogWorkout) {
          this.service.logWorkout(this.logWorkoutController().toJSON());
        }
      }
    };


    private createLogController = (lightLogModel) => {
      lightLogModel.crossfitterWorkoutId = null;
      this.logWorkoutController(new LogWorkoutController(lightLogModel, this.logFunction));
    };

    private manageWorkoutClick = (isCreateNewWorkout: boolean) => {
      this.chooseExistingWorkoutController.clearState();
      this.createWorkoutController.clearState();

      this.isCreateNewWorkoutPressed(isCreateNewWorkout);
      this.logWorkoutController(null);
    };

  }
}