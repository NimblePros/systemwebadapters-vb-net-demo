Imports Microsoft.AspNetCore.SystemWebAdapters.SessionState.Serialization

Public Class InspectSessionWebForms
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisplaySessionVariables()
    End Sub

    Protected Sub UpdateSession_Click(sender As Object, e As EventArgs)
        UpdateAndDisplaySessionVariables()
    End Sub
    Protected Sub UpdateAndDisplaySessionVariables()
        Session("CurrentTime") = DateTime.Now
        Session("UserName") = "TestUser" + DateTime.Now.Second.ToString()
        DisplaySessionVariables()
    End Sub

    Protected Sub DisplaySessionVariables()
        Dim stringFormat As String
        Dim builder As New StringBuilder
        stringFormat = "<strong>{0}</strong>: {1}<br />"
        builder.Append(String.Format(stringFormat, "SessionId", Session.SessionID))
        If (Session.Keys.Count = 0) Then
            builder.Append("No Session Variables")
        Else
            For Each sessionKey In Session.Keys
                builder.Append(String.Format(stringFormat, sessionKey, Session(sessionKey)))
            Next
        End If
        lblContent.Text = builder.ToString
    End Sub
    Protected Sub HideSessionVariablesOutput()
        lblContent.Text = ""
    End Sub

    Protected Sub DisplaySession_Click(sender As Object, e As EventArgs)
        DisplaySessionVariables()
    End Sub

    Protected Sub ClearOutput_Click(sender As Object, e As EventArgs)
        HideSessionVariablesOutput()
    End Sub

End Class