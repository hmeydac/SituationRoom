// *** Application Routes

// *** Ember Application
window.App = Ember.Application.create({
    ApplicationView: Ember.View.extend({
        templateName: 'application',
        classNames: ['application-view']
    }),
    
    ApplicationController: Ember.Controller.extend({
    }),
    
    // *** Tasks
    TasksView: Ember.View.extend({
        templateName: 'tasks'
    }),
    
    TasksController: Ember.ArrayController.extend(),
    
    ready: function () { console.log("Hello World"); },
    
    Router: Ember.Router.extend({
        enableLogging: true,

        root: Ember.Route.extend({
            index: Ember.Route.extend({
                route: '/'
            }),

            tasks: Ember.Route.extend({
                route: '/tasks',

                enter: function (router) {
                    console.log("The tasks sub-state was entered.");
                },
                connectOutlets: function (router, context) {
                    router.get('applicationController').connectOutlet('tasks');
                }
            })
        })
    })
});

App.initialize();

