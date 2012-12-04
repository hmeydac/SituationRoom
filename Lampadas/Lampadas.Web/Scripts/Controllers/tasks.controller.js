/// <reference path="../Libs/_references.js" />
/// <reference path="../Models/task.model.js" />
TasksController = Ember.ArrayController.extend(
    {
        content: [],
        
        init: function() {
            jQuery.getJSON('/api/tasks', jQuery.proxy(this.fillValues, this));
        },
        
        fillValues: function (data) {
            console.log('Tasks retrieved');
            for (var i = 0; i < data.length; i++) {
                task = Task.create().setProperties(data[i]);
                this.content.push(task);
            };
        }
    });