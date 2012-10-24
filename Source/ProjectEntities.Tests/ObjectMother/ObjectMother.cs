namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public abstract class ObjectMother<T>
    {        
        protected T Instance { get; set; }

        public virtual T Build()
        {
            return this.Instance;
        }
    }
}
