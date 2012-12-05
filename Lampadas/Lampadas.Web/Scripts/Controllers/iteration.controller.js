/// <reference path="../Libs/_references.js" />
/// <reference path="../Models/task.model.js" />
IterationController = Ember.ArrayController.extend(
    {
        content: null,
        
        init: function() {
            jQuery.getJSON('/api/tasks', jQuery.proxy(this.fillValues, this));
        },
        
        fillValues: function (data) {
            var tasks = [];
            console.log('Tasks retrieved');
            for (var i = 0; i < data.length; i++) {
                tasks.push(Task.create().setProperties(data[i]));
            };

            this.set('content', tasks);
        }
    });