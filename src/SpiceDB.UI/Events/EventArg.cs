using System;


namespace SpiceDB.UI.Events
{
    public class EventArg
    {
       static EventArg _emptyEventArg = new EventArg(Guid.Empty, null);

        public EventArg(Guid eventId, object arg)
        {
            EventId = eventId;
            Arg = arg;
        }

        public EventArg(object arg) : this(Guid.Empty, arg) { }
        public EventArg() : this(Guid.Empty, null) { }

        public Guid EventId { get; private set; }

        public object Arg { get; private set; }

        public static EventArg Empty
        {
            get
            {
                return _emptyEventArg;
            }
        }
    }


}
