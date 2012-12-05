/// <reference path="routes.js" />
// *** Ember Application
window.App = Ember.Application.create({
    ready: function () { console.log("Hello World"); },
    
    Router: DefaultRoute,

    // *** Application
    ApplicationView: ApplicationView,
    
    ApplicationController: ApplicationController,
    
    // *** Iteration
    IterationView: IterationView,
    
    IterationController: IterationController,
    
    // *** Task
    TaskView: TaskView,
    
    TaskController: TaskController
});

App.initialize();

