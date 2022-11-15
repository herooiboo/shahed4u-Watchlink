Imports MaterialSkin

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim msm As MaterialSkinManager = MaterialSkinManager.Instance
            msm.ColorScheme = New ColorScheme(Primary.Red600, Primary.Red800, Primary.Red500, Accent.Red100, TextShade.WHITE)
        Catch ex As Exception
            MsgBox("UNEXPECTED ERR: LOADING COLOR SCHEME")
        End Try
    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        Try
            With MaterialProgressBar1
                .Minimum = 0
                .Maximum = 50
                .Step = 5
            End With
            For index As Integer = 0 To 50 Step 5
                MaterialProgressBar1.Value = index
                System.Threading.Thread.Sleep(50)
            Next
        Catch ex As Exception
            MsgBox("UNEXPECTED ERR: PROGRESS BAR COUNTING")
        End Try
    End Sub

    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        Try
            MaterialSingleLineTextField2.Text = "----------------------------------------- READING -----------------------------------------"

            WebBrowser1.Navigate(MaterialSingleLineTextField1.Text)
        Catch ex As Exception
            MsgBox("UNEXPECTED ERR: NAVIGATING")
        End Try
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Try
            For Each a As HtmlElement In WebBrowser1.Document.GetElementsByTagName("input")
                If a.GetAttribute("name") = "fserver" Then
                    MaterialSingleLineTextField2.Text = a.GetAttribute("value")
                End If
            Next
        Catch ex As Exception
            MsgBox("UNEXPECTED ERR: READING DOM")
        End Try
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        Try
            Process.Start(MaterialSingleLineTextField2.Text)

        Catch ex As Exception
            MsgBox("UNEXPECTED ERR: START PROCESS")
        End Try
    End Sub
End Class
