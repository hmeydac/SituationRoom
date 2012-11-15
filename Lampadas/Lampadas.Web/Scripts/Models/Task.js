// Create namespace
var Lampadas = Ember.Application.create();

// Define Task Model
Lampadas.Task = Ember.Object.extend({
    title: 'Enter your task title here',
    description: 'Enter your description here'
});

// Define Task Collection
Lampadas.TaskCollection = Ember.ArrayProxy.extend(
    {
        tasks: [],
        init: function () {
            alert('hola');
            this.tasks.push(Lampadas.Task.create({ title: 'Task1', description: 'Some description' }));
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
var controller = Lampadas.TaskController.create({content:model});
Lampadas.TaskView.create({controller: controller}).appendTo('body');
