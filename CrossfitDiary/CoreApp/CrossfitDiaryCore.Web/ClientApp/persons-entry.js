import Vue from 'vue';
import './style/persons.scss';
import { ToLogWorkoutViewModel } from './models/viewModels/ToLogWorkoutViewModel';
import PersonsActivitiesComponent from "./components/person-activities-component.vue";
import CrossfitterService from "./CrossfitterService";
var apiService = new CrossfitterService();
new Vue({
    el: '#home-page-container',
    template: "<div class=\"home-container\"><PersonsActivitiesComponent :activities=\"activities\"/> </div>",
    components: {
        PersonsActivitiesComponent: PersonsActivitiesComponent
    },
    data: function () {
        return {
            activities: ToLogWorkoutViewModel[0],
        };
    },
    mounted: function () {
        var _this = this;
        apiService.getAllCrossfittersWorkouts()
            .then(function (data) {
            _this.activities = data;
        });
    },
});
//# sourceMappingURL=persons-entry.js.map