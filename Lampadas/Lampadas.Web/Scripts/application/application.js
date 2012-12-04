/// <reference path="routes.js" />
// *** Ember Application
window.App = Ember.Application.create({
    ready: function () { console.log("Hello World"); },
    
    Router: DefaultRoute,

    // *** Application
    ApplicationView: ApplicationView,
    
    ApplicationController: ApplicationController,
    
    // *** Tasks
    TasksView: TasksView,
    
    TasksController: TasksController
});

App.initialize();

