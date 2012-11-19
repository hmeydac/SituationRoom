Lampadas.Proxy = Ember.Object.create({
   getTasks: function(callback) {
       $.getJSON('http://localhost:5007/api/tasks', callback);
   } 
});