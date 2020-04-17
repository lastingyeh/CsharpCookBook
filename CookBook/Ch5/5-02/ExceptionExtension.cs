using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch5
{
    public static class ExceptionExtension
    {
        public static string ToShortDisplayString(this Exception ex)
        {
            StringBuilder displayText = new StringBuilder();
            WriteExceptionShortDetail(displayText, ex);

            foreach (Exception inner in ex.GetNestedExceptionList())
            {
                displayText.AppendFormat("**** INNEREXCEPTION START ****{0}",
                    Environment.NewLine);
                WriteExceptionShortDetail(displayText, inner);
                displayText.AppendFormat("**** INNEREXCEPTION END ****{0}{0}",
                    Environment.NewLine);
            }
            return displayText.ToString();
        }

        public static IEnumerable<Exception> GetNestedExceptionList(this Exception ex)
        {
            Exception current = ex;
            do
            {
                current = current.InnerException;
                if (current != null)
                    yield return current;
            } while (current != null);
        }

        public static void WriteExceptionShortDetail(StringBuilder builder, Exception ex)
        {
            builder.AppendFormat("Message: {0}{1}", ex.Message, Environment.NewLine);
            builder.AppendFormat("Type: {0}{1}", ex.GetType(), Environment.NewLine);
            builder.AppendFormat("Source: {0}{1}", ex.Source, Environment.NewLine);
            builder.AppendFormat("TargetSite: {0}{1}", ex.TargetSite, Environment.NewLine);
        }

        public static string ToFullDisplayString(this Exception ex)
        {
            StringBuilder displayText = new StringBuilder();
            WriteExceptionDetail(displayText, ex);
            foreach (Exception inner in ex.GetNestedExceptionList())
            {
                displayText.AppendFormat("**** INNEREXCEPTION START ****{0}", Environment.NewLine);
                WriteExceptionDetail(displayText, inner);
                displayText.AppendFormat("**** INNEREXCEPTION END ****{0}{0}", Environment.NewLine);
            }
            return displayText.ToString();
        }

        public static void WriteExceptionDetail(StringBuilder builder, Exception ex)
        {
            builder.AppendFormat("Message: {0}{1}", ex.Message, Environment.NewLine);
            builder.AppendFormat("Type: {0}{1}", ex.GetType(), Environment.NewLine);
            builder.AppendFormat("HelpLink: {0}{1}", ex.HelpLink, Environment.NewLine);
            builder.AppendFormat("Source: {0}{1}", ex.Source, Environment.NewLine);
            builder.AppendFormat("TargetSite: {0}{1}", ex.TargetSite, Environment.NewLine);
            builder.AppendFormat("Data:{0}", Environment.NewLine);

            foreach (DictionaryEntry de in ex.Data)
            {
                builder.AppendFormat("\t{0} : {1}{2}",
                    de.Key, de.Value, Environment.NewLine);
            }
            builder.AppendFormat("StackTrace: {0}{1}", ex.StackTrace, Environment.NewLine);
        }
    }
}
