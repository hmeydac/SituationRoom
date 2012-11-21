Lampadas.TaskCollection = Ember.ArrayProxy.extend({
    content: [],
    init: function () {
    },
    getTasksCallback: function (data) {
        var that = this, task;
        $.each(data, function (index, value) {
            task = Lampadas.Task.create().setProperties(value);
            that.content.push(task);
        });
    }
});