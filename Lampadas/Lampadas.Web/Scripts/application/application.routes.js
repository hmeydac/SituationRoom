/// <reference path="../Libs/_references.js" />
DefaultRoute = Ember.Router.extend({
    enableLogging: true,

    root: Ember.Route.extend({
        index: Ember.Route.extend({
            route: '/'
        }),

        iteration: IterationRoute
    })
})