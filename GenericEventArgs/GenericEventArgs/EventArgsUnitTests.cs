using System;
using FluentAssertions;
using NUnit.Framework;

namespace GenericEventArgs
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EventArgs<T> : EventArgs
    {
        public T Type { get; set; }
    }

    public class ClassWithAnEvent
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
    [TestFixture]
    public class EventArgsUnitTests
    {
        [Test]
        public void CustomEvent_GivenAGenericEventsArgsWithATypeOfPerson_ContainsPerson()
        {
            Person person = null;
            ClassWithAnEvent classWithAnEvent = new ClassWithAnEvent();
            classWithAnEvent.CustomEvent += delegate(object sender, EventArgs<Person> args)
            {
                person = args.Type;
            };

            classWithAnEvent.OnCustomEventRaised();

            person.Should().NotBeNull();
            person.Id.Should().Be(1);
            person.Name.Should().Be("Ray");
        }
    }
}
