using System;

namespace GenericEventArgs
{
    public class ClassWithGenericEvent
    {
        public event EventHandler<EventArgs<Person>> CustomEvent;

        public void OnCustomEventRaised()
        {
            EventArgs<Person> eventArgs = new EventArgs<Person>
            {
                Type = new Person
                {
                    Id = 1,
                    Name = "Ray"
                }
            };

            if (CustomEvent != null)
            {
                CustomEvent(this, eventArgs);
            }
        }
    }
}