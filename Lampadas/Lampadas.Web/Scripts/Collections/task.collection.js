Lampadas.TaskCollection = Ember.ArrayProxy.extend({
    content: [],
    init: function () {
        Lampadas.Proxy.getTasks($.proxy(this.getTasksCallback, this));
    },
    getTasksCallback: function (data) {
        var that = this, task;
        $.each(data, function (index, value) {
            task = Lampadas.Task.create().setProperties(value);
            that.content.push(task);
        });
    }
});