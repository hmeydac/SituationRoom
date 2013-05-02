/// <reference path="../Libs/_references.js" />
TaskRoute = Ember.Route.extend({
    route: '/task/:Id',

    enter: function(router) {
        console.log("The task sub-state was entered.");
    },

        deserialize: function(router, context) {
            return window.App.Router.get('taskController') .find(context.Id);
        },

        serialize: function(router, context) {
            return {
                Id: context.Id,
                Title: context.Title
            };
        },

    connectOutlets: function(router, aTask) {
        router.get('applicationController').connectOutlet('task', aTask);
    }
});