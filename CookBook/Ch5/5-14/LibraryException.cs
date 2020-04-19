using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CookBook.Ch5
{
    [Serializable]
    public class LibraryException : Exception
    {
        public string CallerMemberName { get; set; }
        public string CallerFilePath { get; set; }
        public int CallerLineNumber { get; set; }
        public LibraryException(Exception inner) : base(inner.Message) { }

        public override void GetObjectData(
            SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("CallerMemberName", CallerMemberName);
            info.AddValue("CallerFilePath", CallerFilePath);
            info.AddValue("CallerLineNumber", CallerLineNumber);
        }

        public override string ToString() => $"LibraryException originated in " +
            $"member \"{CallerMemberName}\" " +
            $"on line {CallerLineNumber} " +
            $"in file {CallerFilePath} " +
            $"with exception details: {Environment.NewLine}" +
            $"{InnerException}";
    }
}
