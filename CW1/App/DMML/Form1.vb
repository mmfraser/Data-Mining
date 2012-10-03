Public Class Form1
    Private data As DataTable

    Private Sub btnSelectSpreadsheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSpreadsheet.Click
        OpenFileDialog1.ShowDialog()
    End Sub


    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        MsgBox("here")

        Dim oDb As New CooperSoftware.DataAccess.Database(CooperSoftware.DataAccess.DatabasePlatform.Excel)
    End Sub
End Class
