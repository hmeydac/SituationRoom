/// <reference path="../Libs/_references.js" />
Iteration = Ember.Object.extend({
    iterations: Ember.A(),
    find: function () {
        this.iterations.clear();
        jQuery.getJSON('/api/iteration', jQuery.proxy(this.fillValues, this));
        return this.iterations;
    },

    fillValues: function (data) {
        for (var i = 0; i < data.length; i++) {
            var iteration = Iteration.create();
            iteration.setProperties(data[i]);
            this.iterations.pushObject(iteration);
        }
    }
});