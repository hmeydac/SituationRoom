/// <reference path="../Libs/_references.js" />
TaskRoute = Ember.Route.extend({
    route: '/task/:id',

    enter: function(router) {
        console.log("The task sub-state was entered.");
    },

    deserialize: function(router, context) {
        return null;
    },

    serialize: function(router, context) {
        return {
            id: context.Id
        };
    },

    connectOutlets: function(router, aTask) {
        router.get('applicationController').connectOutlet('task', aTask);
    }
});