Lampadas.TaskService = Ember.Object.create({
   getTasks: function(onSuccess, onError) {
       $.getJSON('http://localhost:5007/api/tasks', onSuccess, onError);
   },
   addTask: function(task, onSuccess, onError) {
       $.ajax({
           url: 'http://localhost:5007/api/tasks',
           type: 'POST',
           dataType: 'json',
           success: onSuccess,
           error: onError,
           data: task
       });
   }
});