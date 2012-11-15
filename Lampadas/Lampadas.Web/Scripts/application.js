var model = Lampadas.TaskCollection.create();

Lampadas.TaskView.create({
    controller: Lampadas.TaskController.create({
        content: model
    })
}).appendTo('#taks-list');