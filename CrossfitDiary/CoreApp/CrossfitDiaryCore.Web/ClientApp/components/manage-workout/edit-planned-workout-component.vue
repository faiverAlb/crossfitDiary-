﻿<template>
    <div>
        <div class="dashed-container-description border-warning text-center">
            <b-badge variant="warning">2</b-badge>
            Plan workout:
        </div>
        <div class="d-flex justify-content-end mt-3">
            <b-form-group>
                <b-form-radio-group
                        :options="wodSubTypes"
                        button-variant="outline-primary"
                        buttons
                        name="radio-btn-outline"
                        size="sm"
                        v-model="planningWorkout.wodSubType"
                />
            </b-form-group>

        </div>
        <div class="d-flex justify-content-end">
            <b-form-checkbox
                    :disabled="isPrivatePlanningFixed"
                    id="isPrivatePlanning"
                    name="isPrivatePlanning"
                    v-model="planningWorkout.isPrivatePlanning">
                Plan as private session
            </b-form-checkbox>
        </div>
        <div class="row justify-content-end mt-3">
            <div class="col-lg-4 col-sm data-selector-container">
                <div class="form-group">
                    <b-input-group size="sm">
                        <date-picker
                                :config="{ format: 'DD.MM.YYYY'}"
                                :wrap="true"
                                name="toPlanModelDate"
                                placeholder="Select date"
                                v-model="planningWorkout.displayPlanDate"
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
            <div class="col-lg-4 col-sm mb-1">
                <b-button-group class="btn-group d-flex" size="sm">
                    <b-button
                            class="w-100"
                            v-bind:class="{focus:isActive(0)}"
                            v-on:click="showPlanWorkoutModal(0)"
                            variant="success"
                    >Plan as Sc
                    </b-button>
                    <b-button
                            class="w-100"
                            v-bind:class="{focus:isActive(1)}"
                            v-on:click="showPlanWorkoutModal(1)"
                            variant="warning"
                    >Plan as Rx
                    </b-button>
                    <b-button
                            class="w-100"
                            v-bind:class="{focus:isActive(2)}"
                            v-on:click="showPlanWorkoutModal(2)"
                            variant="danger"
                    >Plan as Rx+
                    </b-button>
                </b-button-group>
            </div>

        </div>

        <b-modal @ok="planWorkout" okTitle="Plan workout" okVariant="warning" ref="planWorkoutModal"
                 title="Sure to plan this workout?">
            Are you sure you want to plan this workout as {{selectedWorkoutDispayLevel}}?
        </b-modal>
    </div>

</template>

<script lang="ts">
    /* Font awesome icons */
    import {faCalendar} from "@fortawesome/free-solid-svg-icons/faCalendar";
    import {library} from "@fortawesome/fontawesome-svg-core";
    /* public components */
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {BBadge, BButton, BButtonGroup, BFormCheckbox, BFormGroup, BFormRadioGroup, BModal} from "bootstrap-vue";
    import datePicker from "vue-bootstrap-datetimepicker";
    import {FontAwesomeIcon} from "@fortawesome/vue-fontawesome";
    /* app components */
    import {WodSubType} from "../../models/viewModels/WodSubType";
    /* models and styles */
    import {PlanningWorkoutLevel} from "../../models/viewModels/WorkoutViewModel";
    import {PlanningWorkoutViewModel} from "../../models/viewModels/PlanningWorkoutViewModel";

    library.add(faCalendar);
    Vue.component("b-form-checkbox", BFormCheckbox);
    declare var workouter: {
        canUserPlanWorkouts: boolean;
    };

    @Component({
        components: {BModal, datePicker, FontAwesomeIcon, BButtonGroup, BButton, BFormGroup, BFormRadioGroup, BBadge}
    })
    export default class EditPlannedWorkoutComponent extends Vue {
        @Prop() planningWorkout: PlanningWorkoutViewModel;
        selectedWorkoutDispayLevel: string = "";
        selectedPlanningLevel?: PlanningWorkoutLevel = null;
        isPrivatePlanningFixed: boolean = true;
        $refs: {
            planWorkoutModal: HTMLFormElement;
        };
        wodSubTypes = [
            {text: 'Skill', value: WodSubType.Skill},
            {text: 'Workout', value: WodSubType.Wod},
            {text: 'Accessory', value: WodSubType.AccessoryWork}
        ];

        mounted() {
            this.isPrivatePlanningFixed = workouter.canUserPlanWorkouts == false;
            if (workouter.canUserPlanWorkouts == false) {
                this.planningWorkout.isPrivatePlanning = true;
            }
        }

        showPlanWorkoutModal(type: PlanningWorkoutLevel): void {
            this.selectedPlanningLevel = type;
            this.selectedWorkoutDispayLevel = PlanningWorkoutLevel[type];
            this.$refs.planWorkoutModal.show();
        }

        hidePlanModal(): void {
            this.$refs.planWorkoutModal.hide();
        }

        planWorkout() {
            this.planningWorkout.planningWorkoutLevel = this.selectedPlanningLevel;
            this.hidePlanModal();
            this.$emit("planWorkoutAction", {});
        }

        isActive(type: PlanningWorkoutLevel) {
            return type == this.planningWorkout.planningWorkoutLevel;
        }
    }
</script>

<style>
</style>