using System;
using System.Collections;
using System.Collections.Generic;
//System.Messaging.MessageQueue (not support dotnet core)
using Experimental.System.Messaging;

namespace CookBook.Ch4
{
    public class EnumerableMessageQueue:MessageQueue, IEnumerable<Message>
    {
        public EnumerableMessageQueue() : base() { }
        public EnumerableMessageQueue(string path) : base(path) { }
        public EnumerableMessageQueue(string path, bool sharedModelDenyReceive)
            : base(path, sharedModelDenyReceive) { }
        public EnumerableMessageQueue(string path, QueueAccessMode accessMode)
            : base(path, accessMode) { }
        public EnumerableMessageQueue(string path, bool sharedModeDenyReceive, bool enableCache)
            : base(path, sharedModeDenyReceive, enableCache) { }
        public EnumerableMessageQueue(string path, bool sharedModeDenyReceive, bool enableCache, QueueAccessMode accessMode)
            : base(path, sharedModeDenyReceive, enableCache, accessMode){ }

        public static new EnumerableMessageQueue Create(string path) => Create(path, false);
        public static new EnumerableMessageQueue Create(string path, bool transactional)
        {
            // Use MessageQueue directly to make sure the queue exists
            if (!Exists(path))
                MessageQueue.Create(path, transactional);
            // create the enumerable queue once we know it is there
            return new EnumerableMessageQueue(path);
        }

        public new MessageEnumerator GetMessageEnumerator()
        {
            throw new NotSupportedException("Please use GetEnumerator");
        }

        public new MessageEnumerator GetMessageEnumerator2()
        {
            throw new NotSupportedException("Please use GetEnumerator");
        }

        IEnumerator<Message> IEnumerable<Message>.GetEnumerator()
        {
            MessageEnumerator messageEnumerator = base.GetMessageEnumerator2();
            while (messageEnumerator.MoveNext())
            {
                yield return messageEnumerator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            MessageEnumerator messageEnumerator = base.GetMessageEnumerator2();
            while (messageEnumerator.MoveNext())
            {
                yield return messageEnumerator.Current;
            }
        }
    }
}
