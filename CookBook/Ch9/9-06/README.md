### Prebuilding an ASP.NET Website Programmatically

```csharp
string cscbWebPath = GetWebAppPath();

if(cscbWebPath.Length > 0)
{
    string appVirtualDir = @"CSCBWeb";
    string appPhysicalSourceDir = cscbWebPath;
    // Make the target an adjacent directory as it cannot be in the same tree
    // or the build manager screams…
    string appPhysicalTargetDir =
    Path.GetDirectoryName(cscbWebPath) + @"\ BuildCSCB";

    PrecompilationFlags flags = PrecompilationFlags.ForceDebug |
                                PrecompilationFlags.OverwriteTarget;

    ClientBuildManagerParameter cbmp = new ClientBuildManagerParameter();
    cbmp.PrecompilationFlags = flags;
    ClientBuildManager cbm = new ClientBuildManager(appVirtualDir,
            appPhysicalSourceDir, appPhysicalTargetDir, cbmp);
    MyClientBuildManagerCallback myCallback = new MyClientBuildManagerCallback();
    cbm.PrecompileApplication(myCallback);
}

// implemented to write to the debug stream and the console
public class MyClientBuildManagerCallback : ClientBuildManagerCallback
{
    public MyClientBuildManagerCallback(): base(){}

    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    public override void ReportCompilerError(CompilerError error)
    {
        string msg = $"Report Compiler Error: {error.ToString()}";
        Debug.WriteLine(msg);
        Console.WriteLine(msg);
    }

    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    public override void ReportParseError(ParserError error)
    {
        string msg = $"Report Parse Error: {error.ToString()}";
        Debug.WriteLine(msg);
        Console.WriteLine(msg);
    }

    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    public override void ReportProgress(string message)
    {
        string msg = $"Report Progress: {message}";
        Debug.WriteLine(msg);
        Console.WriteLine(msg);
    }
}
```