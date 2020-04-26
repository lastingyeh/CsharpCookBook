###  Using the Web Browser Control

```csharp
// add your HTML (<h1>Hey you added some HTML!</h1>)
this._webBrowser.Document.Body.InnerHtml = "<h1>Hey you added some HTML!</h1>";

// navigation to a web page
Uri uri = new Uri(this._txtAddress.Text);
this._webBrowser.Navigate(uri);

// event
// provides a WebBrowserNavigatedEventArgs class that has a Url property to tell the URL
// of the document that has been navigated to:
private void _webBrowser_Navigated(object sender, WebBrowserNavigatedEvnetArgs e){
	this._txtAddress.Text = e.Url.ToString();
	this._btnBack.Enabled = this._webBrowser.CanGoBack;
	this._btnForward.Enabled = this._webBrowser.CanGoForward;
}
```