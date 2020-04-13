using System;
using System.Linq;
using Experimental.System.Messaging;

namespace CookBook.Ch4
{
    public static class EX401
    {
        public static void Run()
        {
            string queuePath = @".\private$\LINQMQ";
            EnumerableMessageQueue messageQueue = null;

            if (!EnumerableMessageQueue.Exists(queuePath))
                messageQueue = EnumerableMessageQueue.Create(queuePath);
            else
                messageQueue = new EnumerableMessageQueue(queuePath);

            using (messageQueue)
            {
                BinaryMessageFormatter messageFormatter = new BinaryMessageFormatter();

                // Query the message queue for specific messages with the following criteria:
                // 1) the label must be less than 5
                // 2) the name of the type in the message body must contain 'CSharpRecipes.D'
                // 3) the results should be in descending order by type name (from the body)
                var query = from Message msg in messageQueue
                                // The first assignment to msg.Formatter is so that we can touch the
                                // Message object. It assigns the BinaryMessageFormatter to each message
                                // instance so that it can be read to determine if it matches the
                                // criteria. This is done and then checks that the formatter was
                                // correctly assigned by performing an equality check which satisfies the
                                // where clause's need for a Boolean result while still executing the
                                // assignment of the formatter.
                            where ((msg.Formatter = messageFormatter) == messageFormatter) &&
                                int.Parse(msg.Label) < 5 &&
                                msg.Body.ToString().Contains("CSharpRecipes.D")
                            orderby msg.Body.ToString() descending
                            select msg;

                // check our results for messages with a label > 5 and containing
                // a 'D' in the name
                foreach (var msg in query)
                {
                    Console.WriteLine($"Label: {msg.Label}" +
                        $" Body: {msg.Body}");
                }

            }
        }
       
    }
}
