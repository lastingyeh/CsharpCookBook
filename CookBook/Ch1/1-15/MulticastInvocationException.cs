using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace CookBook.Ch1._1_15
{
    [Serializable]
    public class MulticastInvocationException : Exception
    {
        private List<Exception> _invocationExceptions;

        public MulticastInvocationException() : base() { }

        public MulticastInvocationException(IEnumerable<Exception> invocationExceptions)
        {
            _invocationExceptions = new List<Exception>(invocationExceptions);
        }

        public MulticastInvocationException(string message) : base(message) { }

        public MulticastInvocationException(string message, Exception innerException) : base(message, innerException) { }

        protected MulticastInvocationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _invocationExceptions = (List<Exception>)info.GetValue("InvocationExceptions", typeof(List<Exception>));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("InvocationExceptions", this.InvocationExceptions);
            base.GetObjectData(info, context);
        }

        public ReadOnlyCollection<Exception> InvocationExceptions =>
            new ReadOnlyCollection<Exception>(_invocationExceptions);
    }
}
