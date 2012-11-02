using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectEntities.EntityExceptions;

namespace ProjectEntities
{
    public class Timeline
    {
        public Timeline()
        {
            this.Activities = new List<TimelineActivity>();
        }

        [Key]
        public int Id { get; set; }

        protected List<TimelineActivity> Activities { get; set; }

        public List<TimelineActivity> GetActivities()
        {
            return this.Activities;
        }

        public TimelineActivity GetActivity(int id)
        {
            return this.Activities.FirstOrDefault(activity => activity.Id == id);
        }

        public void AddActivity(TimelineActivity activity)
        {
            if (this.GetActivity(activity.Id) != null)
            {
                var message = string.Format("Timeline Activity {0} already exists in the Timeline {1}.", activity.Id, this.Id);
                throw new EntityAlreadyExistsException(message);
            }

            this.Activities.Add(activity);
        }

        public void RemoveActivity(int id)
        {
            var activity = this.GetActivity(id);
            if (activity == null)
            {
                var message = string.Format("Unable to remove Timeline Activity {0} from Timeline {1}. Not found.", id, this.Id);
                throw new EntityDoesNotExistsException(message);
            }

            this.Activities.Remove(activity);
        }
    }
}
