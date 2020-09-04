Option Explicit
Dim obj
Set obj = CreateObject("InternetExplorer.Application")
obj.Navigate "http://10.10.20.182:99/Default.aspx"
obj.visible = true
While obj.Busy
Wend
obj.Quit
Set obj = Nothing