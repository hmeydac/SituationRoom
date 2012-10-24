namespace ProjectEntities.EntityExceptions
{
    using System;

    public class EntityDoesNotExistsException : Exception
    {
        public EntityDoesNotExistsException(string message) : base(message)
        {
        }
    }
}
