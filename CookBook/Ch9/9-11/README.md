### Simulating Form Execution

```csharp
// In order to use this, you need to run the CSCBWeb project first.
Uri uri = new Uri("http://localhost:4088/WebForm1.aspx");
WebClient client = new WebClient();

// Create a series of name/value pairs to send
// Add necessary parameter/value pairs to the name/value container.
NameValueCollection collection = new NameValueCollection()
	{ 
		{"Item", "WebParts"},
		{"Identity", "foo@bar.com"},
		{"Quantity", "5"} 
	};

Console.WriteLine($"Uploading name/value pairs to URI {uri.AbsoluteUri} ...");
// Upload the NameValueCollection.
byte[] responseArray = await client.UploadValuesTaskAsync(uri, "POST", collection);
// Decode and display the response.
Console.WriteLine($"\nResponse received was {Encoding.UTF8.GetString(responseArray)}");
```

#### WebForm1.aspx
```aspx
<%@ page language="C#" autoeventwireup="true" codefile="WebForm1.aspx.cs"
    inherits="WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" Height="139px" Width="361px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="Label1"
                            runat="server"
                            Text="Identity"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="Identity"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="Label2"
                            runat="server"
                            Text="Item"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="Item"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="Label3"
                            runat="server"
                            Text="Quantity"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="Quantity"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Button ID="Button1"
                            runat="server"
                            OnClick="Button1_Click" Text="Submit" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
```
#### WebForm1.aspx.cs
```csharp
using System;
using System.Web;
public partial class WebForm1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
            WriteOrderResponse();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        WriteOrderResponse();
    }
    private void WriteOrderResponse()
    {
        string response = "Thanks for the order!<br/>";
        response += "Identity: " + Request.Form["Identity"] + "<br/>";
        response += "Item: " + Request.Form["Item"] + "<br/>";
        response += "Quantity: " + Request.Form["Quantity"] + "<br/>";
        Response.Write(response);
    }
}

```