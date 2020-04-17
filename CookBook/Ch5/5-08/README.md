### Dealing with Unhandled Exceptions in WPF Applications

#### App.xaml
```xaml
<Application x:Class="UnhandledWPFException.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    StartupUri="Window1.xaml"
    DispatcherUnhandledException="Application_DispatcherUnhandledException">
    <Application.MainWindow>
       <Window />
    </Application.MainWindow>
    <Application.Resources>
    </Application.Resources>
</Application>


#### App.xaml.cs
```csharp
private void Application_DispatcherUnhandledException(object sender,
    System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
{
    // Log the exception information in the event log
    EventLog.WriteEntry("UnhandledWPFException Application",
        e.Exception.ToString(), EventLogEntryType.Error);
    // Let the user know what happenned
    MessageBox.Show("Application_DispatcherUnhandledException: " +
        e.Exception.ToString());
    // indicate we handled it
    e.Handled = true;
    // shut down the application
    this.Shutdown();
}
```

#### Adding Startup event handler
```xaml
<Application x:Class="UnhandledWPFException.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    StartupUri="Window1.xaml"
    Startup="Application_Startup" >
    <Application.MainWindow>
        <Window />
    </Application.MainWindow>
    <Application.Resources>
    </Application.Resources>
</Application>
```

#### Establish the event handler
```csharp
private void Application_Startup(object sender, StartupEventArgs e)
{
    this.DispatcherUnhandledException +=
        new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(
            Application_DispatcherUnhandledException);
}
```

#### Update App.xaml.cs
```csharp
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_DispatcherUnhandledException(object sender,
        System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
    // indicate we handled it
        e.Handled = true;
        ReportUnhandledException(e.Exception);
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        // WPF UI exceptions
        this.DispatcherUnhandledException +=
            new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(
                pplication_DispatcherUnhandledException);
        // Those dirty thread exceptions
        AppDomain.CurrentDomain.UnhandledException +=
            new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        ReportUnhandledException(e.ExceptionObject as Exception);
    }

    private void ReportUnhandledException(Exception ex)
    {
        // Log the exception information in the event log
        EventLog.WriteEntry("UnhandledWPFException Application",
            ex.ToString(), EventLogEntryType.Error);
        // Let the user know what happenned
        MessageBox.Show("Unhandled Exception: " + ex.ToString());
        // shut down the application
        this.Shutdown();
    }
}
```