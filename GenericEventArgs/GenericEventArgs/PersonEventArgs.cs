using System;

namespace GenericEventArgs
{
    public class PersonEventArgs : EventArgs
    {
        public Person Person { get; set; }
    }
}