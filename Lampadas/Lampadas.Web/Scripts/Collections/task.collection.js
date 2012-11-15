Lampadas.TaskCollection = Ember.ArrayProxy.extend({
    content: [],
    init: function () {
        var that = this, task;
        $.getJSON('http://localhost:5007/api/tasks', function (data) {
            $.each(data, function (index, value) {
                task = Lampadas.Task.create().setProperties(value);
                that.content.push(task);
            });
        });
    }
});