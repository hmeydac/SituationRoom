/// <reference path="../Libs/_references.js" />
IterationRoute = Ember.Route.extend({
    route: '/iteration',

    showTask: Ember.Route.transitionTo('iteration.task'),

    index: Ember.Route.extend({
        route: '/',
        enter: function(router) {
            console.log("The iteration sub-state was entered.");
        },

        connectOutlets: function(router, context) {
            router.get('applicationController').connectOutlet('iteration');
        }
    }),

    task: TaskRoute
});