using System;

namespace GenericEventArgs
{
    public class ClassWithEvent
    {
        public event EventHandler<PersonEventArgs> CustomEvent;

        public void OnCustomEventRaised()
        {
            PersonEventArgs personEventArgs = new PersonEventArgs
            {
                Person = new Person
                {
                    Id = 1,
                    Name = "Ray"
                }
            };

            if (CustomEvent != null)
            {
                CustomEvent(this, personEventArgs);
            }
        }
    }
}