using FluentAssertions;
using NUnit.Framework;

namespace GenericEventArgs
{
    [TestFixture]
    public class GenericEventArgsUnitTests
    {
        [Test]
        public void CustomEvent_GivenAGenericEventsArgsWithATypeOfPerson_ContainsPerson()
        {
            Person person = null;
            ClassWithGenericEvent classWithGenericEvent = new ClassWithGenericEvent();
            classWithGenericEvent.CustomEvent += delegate(object sender, EventArgs<Person> args)
            {
                person = args.Type;
            };

            classWithGenericEvent.OnCustomEventRaised();

            person.Should().NotBeNull();
            person.Id.Should().Be(1);
            person.Name.Should().Be("Ray");
        }
    }

    [TestFixture]
    public class EventArgsUnitTests
    {
        [Test]
        public void CustomEvent_GivenAnEventsArgs_ReturnsPerson()
        {
            Person person = null;
            ClassWithEvent classWithEvent = new ClassWithEvent();
            classWithEvent.CustomEvent += delegate(object sender, PersonEventArgs args)
            {
                person = args.Person;
            };

            classWithEvent.OnCustomEventRaised();

            person.Should().NotBeNull();
            person.Id.Should().Be(1);
            person.Name.Should().Be("Ray");
        }
    }
}
