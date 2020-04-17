using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

namespace CookBook.Ch5
{
    public static class EX510
    {
        public static void CreateMultipleLogs()
        {
            AppEvents appEventLog = new AppEvents("AppLog", "AppLocal");
            AppEvents globalEventLog = new AppEvents("AppSystemLog", "AppGlobal");

            ListDictionary logList = new ListDictionary();
            logList.Add(appEventLog.LogName, appEventLog);
            logList.Add(globalEventLog.LogName, globalEventLog);

            ((AppEvents)logList[appEventLog.LogName]).WriteToLog(
                "App startup security check",
                EventLogEntryType.Information,
                CategoryType.AppStartUp,
                EventIDType.BufferOverflowCondition);

            ((AppEvents)logList[globalEventLog.LogName]).WriteToLog(
                "App startup security check",
                EventLogEntryType.Information,
                CategoryType.AppStartUp,
                EventIDType.BufferOverflowCondition);

            // iterate over all the AppEvents that write a single message
            foreach (DictionaryEntry log in logList)
            {
                ((AppEvents)log.Value).WriteToLog("App startup",
                    EventLogEntryType.FailureAudit,
                    CategoryType.AppStartUp,
                    EventIDType.SecurityFailure);
            }

            // delete logList
            foreach (DictionaryEntry log in logList)
            {
                ((AppEvents)log.Value).DeleteLog();
            }
            logList.Clear();
        }
    }
}
