/// <reference path="../Libs/_references.js" />
/// <reference path="../Models/iteration.model.js" />
DefaultRoute = Ember.Router.extend({
    root: Ember.Route.extend({
        index: Ember.Route.extend({
            route: '/',
            showIteration: Ember.Route.transitionTo('iteration'),
            redirectsTo: 'iterations'
        }),

        iterations: Ember.Route.extend({
            route: '/iterations',
            showIteration: Ember.Route.transitionTo('iteration'),
            connectOutlets: function (router) {
                router.get('applicationController').connectOutlet('iterations', Iteration.create().find());
            }
        }),

        iteration: IterationRoute
    })
})