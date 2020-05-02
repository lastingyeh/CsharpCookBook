### UploadData 

```csharp
// UploadData.aspx.cs
using System;
using System.Web;
public partial class UploadData : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		foreach (string f in Request.Files.AllKeys)
		{
			HttpPostedFile file = Request.Files[f];
			// need to have write permissions for the directory to write to
			try
			{
				string path = Server.MapPath(".") + @"\" + file.FileName;
				file.SaveAs(path);
				Response.Write("Saved " + path);
			}
			catch (HttpException hex)
			{
				// return error information specific to the save
				Response.Write("Failed to save file with error: " + hex.Message);
			}
		}
	}
}

```