import Vue from "vue";
import {WodSubType} from "../../../models/viewModels/WodSubType";
import {Component} from "vue-property-decorator";
import CrossfitterService from "../../../CrossfitterService";
import {SpinnerModel} from "../../../models/viewModels/SpinnerModel";
import {WorkoutViewModel} from "../../../models/viewModels/WorkoutViewModel";
import {ToLogWorkoutViewModel} from "../../../models/viewModels/ToLogWorkoutViewModel";
import {ErrorAlertModel} from "../../../models/viewModels/ErrorAlertModel";
import {WindowHelper} from "../../../helpers/WindowHelper";
import VeeValidate from "vee-validate";
import {Action, Getter, State} from "vuex-class";
import {IWorkoutEditState} from "../../../workout-edit-store/types";
import {PlanningWorkoutViewModel} from "../../../models/viewModels/PlanningWorkoutViewModel";

import {faCheck} from "@fortawesome/free-solid-svg-icons/faCheck";
import {library} from "@fortawesome/fontawesome-svg-core";
import {FontAwesomeIcon} from "@fortawesome/vue-fontawesome";

library.add(faCheck);

Vue.use(VeeValidate);

const namespace: string = "workoutEdit";

declare var workouter: {
    toLogWorkoutRawModel: ToLogWorkoutViewModel;
    workoutViewModel: WorkoutViewModel;

};

@Component({
    components: {
        FontAwesomeIcon
    }
})

export class WorkoutTypeComponent extends Vue {
    spinner: SpinnerModel = new SpinnerModel(false);
    model: WorkoutViewModel = new WorkoutViewModel();
    toLogModel: ToLogWorkoutViewModel = new ToLogWorkoutViewModel();
    errorAlertModel: ErrorAlertModel = new ErrorAlertModel();
    planWorkoutModel: PlanningWorkoutViewModel = new PlanningWorkoutViewModel();
    $refs: {
        logWorkoutModal: HTMLFormElement;
    };

    @Action("setIsFindMaxWeight", {namespace})
    setIsFindMaxWeight: any;

    @Getter('isFindMaxWeightGetter', {namespace})
    isFindMaxWeight: boolean;

    @State("workoutEdit")
    workoutEdit: IWorkoutEditState;

    wodSubTypes = [
        {text: 'Skill', value: WodSubType.Skill},
        {text: 'Workout', value: WodSubType.Wod},
        {text: 'Accessory', value: WodSubType.AccessoryWork}
    ];

    mounted() {
        if (workouter != null && workouter.toLogWorkoutRawModel != null) {
            workouter.toLogWorkoutRawModel = new ToLogWorkoutViewModel().deserialize(workouter.toLogWorkoutRawModel);
            this.model = workouter.toLogWorkoutRawModel.workoutViewModel;
            this.toLogModel = workouter.toLogWorkoutRawModel;
        } else if (workouter != null && workouter.workoutViewModel != null) {
            this.model = new WorkoutViewModel().deserialize(workouter.workoutViewModel);
        }
        this.planWorkoutModel = new PlanningWorkoutViewModel();
        this.planWorkoutModel.workoutViewModel = this.model;
        this.setIsFindMaxWeight(this.model.findMaxWeight);

    }

    logWorkout() {
        this.$validator.validate().then(isValid => {
            if (isValid) {
                let workoutModel = this.model;
                const model = {
                    newWorkoutViewModel: workoutModel,
                    logWorkoutViewModel: this.toLogModel
                };
                let crossfitterService: CrossfitterService = new CrossfitterService();
                this.spinner.activate();
                crossfitterService
                    .createAndLogWorkout(model)
                    .then(data => {
                        window.location.href = "\\";
                    })
                    .catch(data => {
                        this.spinner.disable();
                        this.errorAlertModel.setError(data.response.statusText);
                    });
            }
        });
    }

    showLogWorkoutModal(): void {
        this.$validator.validate();
        let scrollToErrors = this.$el.querySelector("[aria-invalid=true]");
        if (scrollToErrors) {
            WindowHelper.scrollToTargetAdjusted(scrollToErrors);
        }

        this.$validator.validate().then(isValid => {
            if (isValid) {
                this.$refs.logWorkoutModal.show();
            }
        });
    }

    planWorkoutAction(): void {

        this.$validator.validate();

        let scrollToErrors = this.$el.querySelector("[aria-invalid=true]");
        if (scrollToErrors) {
            WindowHelper.scrollToTargetAdjusted(scrollToErrors);
        }
        this.$validator.validate().then(isValid => {
            if (isValid) {
                let crossfitterService: CrossfitterService = new CrossfitterService();
                this.spinner.activate();
                crossfitterService
                    .createAndPlanWorkout(this.planWorkoutModel)
                    .then(data => {
                        window.location.href = "\\";
                    })
                    .catch(data => {
                        this.spinner.disable();
                        this.errorAlertModel.setError(data.response.statusText);
                    });
            }
        });
    }

    onIsFindMaxWeightChange() {
        this.setIsFindMaxWeight(this.model.findMaxWeight);
    }


}