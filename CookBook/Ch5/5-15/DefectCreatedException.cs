using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CookBook.Ch5
{
    [Serializable]
    public class DefectCreatedException : Exception
    {
        public DefectCreatedException() : base() { }
        public DefectCreatedException(string message) : base(message) { }
        public DefectCreatedException(string message, Exception innerException)
            : base(message, innerException) { }

        // new params constructors
        public DefectCreatedException(string defect, int line) : base(string.Empty)
        {
            Defect = defect;
            Line = line;
        }
        public DefectCreatedException(string defect, int line, Exception innerException)
            : base(string.Empty, innerException)
        {
            Defect = defect;
            Line = line;
        }

        protected DefectCreatedException(SerializationInfo serializationInfo,
            StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }

        #region Properties
        public string Defect { get; }
        public int Line { get; }

        public override string Message =>
            $"A defect was introduced: ({Defect ?? "Unknown"} on line {Line})";
        #endregion

        #region Overridden methods
        // ToFullDisplayString see. 5-02/ExceptionExtension
        public override string ToString() =>
            $"{Environment.NewLine}{this.ToFullDisplayString()}";

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Defect", Defect);
            info.AddValue("Line", Line);
        }
        #endregion

        public string ToBaseString() => base.ToString();

    }
}
