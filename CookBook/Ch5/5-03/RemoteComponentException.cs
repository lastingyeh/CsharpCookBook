using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CookBook.Ch5
{
    public class RemoteComponentException : Exception, ISerializable
    {
        #region Properties
        public string ServerName { get; }
        public override string Message => $"{base.Message}{Environment.NewLine}" +
            $"The server ({ServerName ?? "Unknow"}) has encountered an error.";
        #endregion

        #region Constructors
        public RemoteComponentException() : base() { }
        public RemoteComponentException(string message) : base(message) { }
        public RemoteComponentException(string message, Exception innerException)
            : base(message, innerException) { }
        // Exception ctor's that accept the new ServerName parameter
        public RemoteComponentException(string message, string serverName) : base(message)
        {
            ServerName = serverName;
        }

        public RemoteComponentException(string message,
            Exception innerException, string serverName) : base(message, innerException)
        {
            ServerName = serverName;
        }

        // Serialization ctor
        protected RemoteComponentException(SerializationInfo exceptionInfo,
            StreamingContext exceptionContext) : base(exceptionInfo, exceptionContext)
        {
            ServerName = exceptionInfo.GetString("ServerName");
        }
        #endregion

        #region Overridden methods
        // ToFullDisplayString() see 5-02 ExceptionExtension
        public override string ToString() =>
            "An error has occurred in a server component of this client." +
            $"{Environment.NewLine}Server Name: " +
            $"{ServerName}{Environment.NewLine}" +
            $"{this.ToFullDisplayString()}";

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ServerName", ServerName);
        }
        #endregion

        public string ToBaseString() => base.ToString();
    }
}
