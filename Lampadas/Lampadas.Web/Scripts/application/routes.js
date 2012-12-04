/// <reference path="../Libs/_references.js" />
DefaultRoute = Ember.Router.extend({
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