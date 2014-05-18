using System;

namespace GenericEventArgs
{
    public class EventArgs<T> : EventArgs
    {
        public T Type { get; set; }
    }
}