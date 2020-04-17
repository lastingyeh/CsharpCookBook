using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CookBook.Ch5
{
    public class AppEvents
    {
        // If you encounter a SecurityException trying to read the registry
        // (Security log) follow these instructions:
        // 1) Open the Registry Editor (search for regedit or type regedit at the Run prompt)
        // 2) Navigate to the following key:
        // 3) HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Eventlog\Security
        // 4) Right-click on this entry and select Permissions
        // 5) Add the user you are logged in as and give the user the Read permission

        // If you encounter a SecurityException trying to write to the event log
        // "Requested registry access is not allowed.", then the event source has not
        // been created. Try re-running the EventLogInstaller for your custom event or
        // for this sample code, run %WINDOWS%\Microsoft.NET\Framework\v4.0.30319\
        // InstallUtil.exe AppEventsEventLogInstallerApp.dll"
        // If you just ran it, you may need to wait a bit until Windows catches up and
        // recognizes the log that was added.

        const string localMachine = ".";

        private EventLog Log { get; set; } = null;
        public string LogName { get; set; }
        public string SourceName { get; set; }
        public string MachineName { get; set; } = localMachine;

        public AppEvents(string logName) : this(logName, Process.GetCurrentProcess().ProcessName) { }

        public AppEvents(string logName, string source) : this(logName, source, localMachine) { }

        public AppEvents(string logName, string source, string machineName = localMachine)
        {
            LogName = logName;
            SourceName = source;
            MachineName = machineName;

            Log = new EventLog(LogName, MachineName, SourceName);
        }

        public void WriteToLog(string message, EventLogEntryType type,
            CategoryType category, EventIDType eventID)
        {
            if (Log == null)
                throw new ArgumentNullException(nameof(Log),
                    "This Event Log has not been opened or has been closed.");

            EventLogPermission eventLogPermission =
                new EventLogPermission(EventLogPermissionAccess.Write, MachineName);

            eventLogPermission.Demand();

            // If you get a SecurityException here, see the notes at the
            // top of the class
            Log.WriteEntry(message, type, (int)eventID, (short)category);
        }

        public void WriteToLog(string message, EventLogEntryType type,
            CategoryType category, EventIDType eventID, byte[] rawData)
        {
            if (Log == null)
                throw new ArgumentNullException(nameof(Log),
                    "This Event Log has not been opened or has been closed.");

            EventLogPermission evtPermission =
                new EventLogPermission(EventLogPermissionAccess.Write, MachineName);

            evtPermission.Demand();
            // If you get a SecurityException here, see the notes at the
            // top of the class
            Log.WriteEntry(message, type, (int)eventID, (short)category, rawData);
        }

        public IEnumerable<EventLogEntry> GetEntries()
        {
            EventLogPermission eventLogPermission =
                new EventLogPermission(EventLogPermissionAccess.Administer, MachineName);
            eventLogPermission.Demand();

            return Log?.Entries.Cast<EventLogEntry>().Where(evt =>
                evt.Source == SourceName);
        }

        public void ClearLog()
        {
            EventLogPermission eventLogPermission =
                new EventLogPermission(EventLogPermissionAccess.Administer, MachineName);
            eventLogPermission.Demand();

            if (!IsNonCustomLog())
                Log?.Clear();
        }

        public void CloseLog()
        {
            Log?.Close();
            Log = null;
        }

        public void DeleteLog()
        {
            if (!IsNonCustomLog())
                if (EventLog.Exists(LogName, MachineName))
                    EventLog.Delete(LogName, MachineName);
            CloseLog();
        }

        public bool IsNonCustomLog()
        {
            if (LogName == string.Empty ||
                LogName == "Application" ||
                LogName == "Security" ||
                LogName == "Setup" ||
                LogName == "System")
                return true;

            return false;
        }


    }
}
