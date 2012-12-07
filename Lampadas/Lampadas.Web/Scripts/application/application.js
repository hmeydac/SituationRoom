/// <reference path="routes.js" />
/// <reference path="../Libs/_references.js" />
// *** Ember Application
window.App = Ember.Application.create({
    ready: function () { console.log("Hello World"); },
    
    ApplicationController: ApplicationController,
    
    ApplicationView: ApplicationView,

    IterationsController: Ember.ArrayController.extend(),
    
    IterationsView: IterationsView,

    Router: DefaultRoute
});
    
window.App.initialize();

