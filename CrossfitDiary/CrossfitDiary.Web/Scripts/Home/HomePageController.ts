﻿class HomePageController {
    weekWorkouts:any;

    constructor(public parameters: { viewModel: { weekWorkouts } }) {
        this.weekWorkouts = this.parameters.viewModel.weekWorkouts;
    }
};
