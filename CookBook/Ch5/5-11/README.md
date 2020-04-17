### Watching the Event Log for a Specific Entry

#### Create the following method to set up the event handler to handle event log writes:
```csharp
public void WatchForAppEvent(EventLog log)
{
    log.EnableRaisingEvents = true;
    // Hook up the System.Diagnostics.EntryWrittenEventHandler.
    log.EntryWritten += new EntryWrittenEventHandler(OnEntryWritten);
}
```

#### Create the event handler to examine the log entries and determine whether further action is to be performed.
```csharp
public static void OnEntryWritten(object source, EntryWrittenEventArgs entryArg)
{
    if (entryArg.Entry.EntryType == EventLogEntryType.Error)
    {
        Console.WriteLine(entryArg.Entry.Message);
        Console.WriteLine(entryArg.Entry.Category);
        Console.WriteLine(entryArg.Entry.EntryType.ToString());
        // Do further actions here as necessary…
    }
}
```