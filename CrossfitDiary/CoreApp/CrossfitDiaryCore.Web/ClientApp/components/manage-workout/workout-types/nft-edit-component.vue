﻿<template>
    <div>
        <div class="routine-complex-info">
            <div class="row">
                <div class="col">
                    <ErrorAlertComponent
                            :errorAlertModel="errorAlertModel"
                            class="my-1 mx-0"
                    />
                </div>
            </div>
            <div class="pt-2 general-info-container">
                <div class="dashed-container-description border-info text-center">
                    <b-badge variant="info">1</b-badge>
                    Create workout:
                </div>
                <div class="row">
                    <div class="col-lg-3 pb-2">
                        <label
                                class="sr-only"
                                for="roundsInput"
                        >Rounds count:</label>
                        <b-input-group size="sm">
                            <b-input-group-prepend>
                                <b-input-group-text tag="span">
                                    <font-awesome-icon :icon="['fas','hashtag']"/>
                                </b-input-group-text>
                            </b-input-group-prepend>
                            <b-form-input
                                    :state="fields.roundsCount && fields.roundsCount.valid"
                                    id="roundsInput"
                                    inputmode="numeric"
                                    min="1"
                                    name="roundsCount"
                                    placeholder="Rounds count"
                                    type="text"
                                    v-mask="'#####'"
                                    v-model="model.roundsCount"
                                    v-validate.initial="'required'"
                            />
                        </b-input-group>
                    </div>
                </div>
                <ExercisesListComponent :exercisesToDo="model.exercisesToDoList">
                    <template v-slot:additional-exercise-settings>
                        <p-check class="p-icon p-smooth" color="info" name="check" v-model="model.asNonBreakingSet">
                            <font-awesome-icon :icon="['fas','check']" class="icon" slot="extra"/>
                            As non-breaking set
                        </p-check>
                        <p-check @change="onIsFindMaxWeightChange" class="p-icon p-smooth" color="warning" name="check"
                                 v-model="model.findMaxWeight">
                            <font-awesome-icon :icon="['fas','check']" class="icon" slot="extra"/>
                            Find max weight
                        </p-check>
                    </template>
                </ExercisesListComponent>

                <div class="comments-section">
                    <b-form-textarea
                            :maxlength="150"
                            class="mt-2"
                            id="commentSection"
                            max-rows="2"
                            name="commentSection"
                            no-resize
                            placeholder="Note: ex. girls do max 30kg"
                            rows="2"
                            size="sm"
                            type="text"
                            v-model="model.comment"
                    />
                    <small
                            class="form-text text-muted text-right"
                            id="workoutNote"
                    >
                        Workout note
                    </small>
                </div>
            </div>

        </div>
        <EditPlannedWorkoutComponent
                :planningWorkout="planWorkoutModel"
                @planWorkoutAction="planWorkoutAction"
                v-if="workoutEdit.canUserSeePlanWorkouts && spinner.status == false"
        />

        <div
                class="want-to-log-container my-3"
                v-if="!workoutEdit.canUserSeePlanWorkouts"
        >
            <div class="log-workout-container row">
                <div class="col-md-12 text-right">
                    <div class="dashed-container-description border-success text-center">
                        <b-badge variant="success">2</b-badge>
                        Write results:
                    </div>
                    <div class="row d-flex justify-content-end mt-3" v-if="isFindMaxWeight">
                        <div class="col-lg-3 pb-2">
                            <label
                                    class="sr-only"
                                    for="maxWeightInput"
                            >Found max weight</label>
                            <b-input-group size="sm">
                                <b-input-group-prepend>
                                    <b-input-group-text tag="span">
                                        Max weight (kg):
                                    </b-input-group-text>
                                </b-input-group-prepend>
                                <b-form-input
                                        :state="fields.weight && fields.weight.valid"
                                        id="maxWeightInput"
                                        name="weight"
                                        placeholder="Weight"
                                        type="number"
                                        v-model="toLogModel.weight"
                                        v-validate.initial="'required'"
                                />
                            </b-input-group>
                        </div>
                    </div>
                    <div
                            class="row justify-content-end"
                            v-bind:class="{saving:spinner.status}"
                    >
                        <div class="col-lg-3 col-sm data-selector-container pr-lg-3">
                            <div class="form-group">
                                <b-input-group size="sm">
                                    <date-picker
                                            :config="{ format: 'DD.MM.YYYY'}"
                                            :wrap="true"
                                            name="toLogModelDate"
                                            placeholder="Select date"
                                            v-model="toLogModel.displayDate"
                                    />
                                    <b-input-group-append>
                                        <button
                                                class="btn btn-secondary datepickerbutton"
                                                title="Toggle"
                                                type="button"
                                        >
                                            <font-awesome-icon :icon="['fas','calendar']"/>
                                        </button>
                                    </b-input-group-append>
                                </b-input-group>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="offset-5">
                            <spinner
                                    :color="spinner.color"
                                    :depth="spinner.depth"
                                    :rotation="spinner.rotation"
                                    :size="spinner.size"
                                    :speed="spinner.speed"
                                    :status="spinner.status"
                            >
                            </spinner>
                        </div>
                    </div>
                    <div
                            class="comments-section"
                            v-bind:class="{saving:spinner.status}"
                    >
                        <b-form-textarea
                                :maxlength="200"
                                class="mt-2"
                                id="logWorkoutCommentSection"
                                max-rows="2"
                                name="commentSection"
                                no-resize
                                placeholder="Note: ex. Holy sh*t! Will do it again!"
                                rows="2"
                                size="sm"
                                type="text"
                                v-model="toLogModel.comment"
                        />
                        <small
                                class="form-text text-muted"
                                id="passwordHelpBlock"
                        >
                            Your thoughts on wod. Max length = 200
                        </small>
                    </div>
                    <div class="d-flex justify-content-end mt-3">
                        <b-form-group>
                            <b-form-radio-group
                                    :options="wodSubTypes"
                                    button-variant="outline-primary"
                                    buttons
                                    name="radio-btn-outline"
                                    size="sm"
                                    v-model="toLogModel.wodSubType"
                            />
                        </b-form-group>

                    </div>
                    <div
                            class="row justify-content-end mt-3"
                            v-if="spinner.status == false"
                    >
                        <span class="col-md-2 col-sm px-md-1">
                          <b-button
                                  class=" btn-block "
                                  size="sm"
                                  v-on:click="showLogWorkoutModal"
                                  variant="success"
                          >Log workout</b-button>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <b-modal @ok="logWorkout" okTitle="Log workout" okVariant="success" ref="logWorkoutModal"
                 title="Write your results">
            Are you sure you want to log this workout?
        </b-modal>
    </div>
</template>

<script lang="ts">
    /* Font awesome icons */
    import {faClock} from "@fortawesome/free-solid-svg-icons/faClock";
    import {faCalendar} from "@fortawesome/free-solid-svg-icons/faCalendar";
    import {faHashtag} from "@fortawesome/free-solid-svg-icons/faHashtag";
    import {library} from "@fortawesome/fontawesome-svg-core";
    /* public components */
    import {FontAwesomeIcon} from "@fortawesome/vue-fontawesome";
    import {Component, Mixins, Vue} from "vue-property-decorator";
    import {
        BAlert,
        BBadge,
        BButton,
        BFormGroup,
        BFormInput,
        BFormRadioGroup,
        BFormTextarea,
        BModal,
        InputGroupPlugin
    } from "bootstrap-vue";
    import datePicker from "vue-bootstrap-datetimepicker";
    import "pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css";
    import {mask} from "vue-the-mask";
    import VeeValidate from "vee-validate";
    import Spinner from "vue-spinner-component/src/Spinner.vue";
    import PrettyCheckbox from 'pretty-checkbox-vue';
    /* app components */
    import ExercisesListComponent from "./exercises-list-component.vue";
    import ErrorAlertComponent from "../../error-alert-component.vue";
    import EditPlannedWorkoutComponent from "../edit-planned-workout-component.vue";
    /* models and styles */
    import {WorkoutViewModel} from "../../../models/viewModels/WorkoutViewModel";
    import {ToLogWorkoutViewModel} from "../../../models/viewModels/ToLogWorkoutViewModel";
    import {WorkoutType} from "../../../models/viewModels/WorkoutType";
    import {WorkoutTypeComponent} from "./workoutTypeMixin";

    library.add(faClock, faHashtag, faCalendar);

    Vue.use(PrettyCheckbox);
    Vue.use(InputGroupPlugin);
    Vue.use(VeeValidate);
    const namespace: string = "workoutEdit";

    declare var workouter: {
        toLogWorkoutRawModel: ToLogWorkoutViewModel;
        workoutViewModel: WorkoutViewModel;
    };

    @Component({
        components: {
            FontAwesomeIcon,
            ExercisesListComponent,
            BFormInput,
            datePicker,
            BFormTextarea,
            BModal,
            BButton,
            BBadge,
            BAlert,
            BFormGroup,
            BFormRadioGroup,
            Spinner,
            ErrorAlertComponent,
            EditPlannedWorkoutComponent
        },
        directives: {mask}
    })
    export default class NFTEditComponent extends Mixins(WorkoutTypeComponent) {
        mounted() {
            this.model.workoutType = WorkoutType.NotForTime;
        }
    }
</script>

<style>
</style>