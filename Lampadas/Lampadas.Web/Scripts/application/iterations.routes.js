/// <reference path="../Libs/_references.js" />
IterationsRoute = Ember.Route.extend({
    route: '/iterations',

    showIteration: Ember.Route.transitionTo('iteration'),

    index: Ember.Route.extend({
        route: '/',
        enter: function(router) {
            console.log("The iterations sub-state was entered.");
        },

        connectOutlets: function(router, context) {
            router.get('applicationController').connectOutlet('iterations');
        }
    }),

    iteration: IterationRoute
});