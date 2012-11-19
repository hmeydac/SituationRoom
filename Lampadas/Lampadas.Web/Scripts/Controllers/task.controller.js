Lampadas.TaskController = Ember.ArrayController.extend({
    content: null,
    init: function () {
        var that = this, task;
        $.getJSON('http://localhost:5007/api/tasks', function (data) {
            var temp = [];

            $.each(data, function (index, value) {
                task = Lampadas.Task.create().setProperties(value);
                temp.push(task);
            });

            that.set('content', temp);
        });
    }
});