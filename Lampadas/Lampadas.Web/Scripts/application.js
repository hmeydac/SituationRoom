var model = Lampadas.TaskCollection.create();

Lampadas.TaskView.create({
    controller: Lampadas.TaskController.create()
}).appendTo('#task-list');