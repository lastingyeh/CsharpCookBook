using System;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace CookBook.Ch5
{
    [Serializable]
    public class DatabaseException : DbException
    {
        public DatabaseException(string message) : base(message) { }
        public byte Class { get; set; }
        public Guid ClientConnectionId { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SqlErrorCollection Errors { get; set; }
        public int LineNumber { get; set; }
        public int Number { get; set; }
        public string Procedure { get; set; }
        public string Server { get; set; }
        public byte State { get; set; }
        public override string ToString() => base.ToString();
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

    }
}
