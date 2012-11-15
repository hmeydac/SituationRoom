// Create namespace
var Lampadas = Ember.Application.create();

// Define Task Model
Lampadas.Task = Ember.Object.extend({
    title: 'Enter your task title here',
    description: 'Enter your description here'
});

// Define Task Collection
Lampadas.TaskCollection = Ember.ArrayProxy.extend({
    content: [],
    init: function () {
        this.content.push({ title: 'Task1', description: 'Some description' });
        this.content.push({ title: 'Task2', description: 'Some description' });
        this.content.push({ title: 'Task3', description: 'Some description' });
        this.content.push({ title: 'Task4', description: 'Some description' });
    }
});

// Task Controller
Lampadas.TaskController = Ember.Controller.extend({
    content: null
});

// Task View
Lampadas.TaskView = Ember.View.extend({
    controller: null,
    templateName: 'task-list-template'
});

var model = Lampadas.TaskCollection.create();

Lampadas.TaskView.create({
    controller: Lampadas.TaskController.create({
        content: model
    })
}).appendTo('body');
