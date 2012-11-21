Lampadas.TaskController = Ember.ArrayController.extend({
    content: null,
    init: function () {
        var that = this, task;
        var fillTasks = function(data) {
            var temp = [];

            $.each(data, function(index, value) {
                task = Lampadas.Task.create().setProperties(value);
                temp.push(task);
            });

            that.set('content', temp);
        };
        
        var errorGetTasks = function(err) {
                alert(err);
            };

        Lampadas.TaskService.getTasks(fillTasks, errorGetTasks);
    }
});