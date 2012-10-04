Imports WindowsApplication1.Project

Public Class Form1
    Private data As DataTable
    Private selectedClassIndex As Integer
    Private selectedNNIndex As Integer

   

    Private Sub btnSelectSpreadsheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSpreadsheet.Click

        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try

            DataGridView1.Columns.Clear()

            Dim oDb As New CooperSoftware.DataAccess.Database(CooperSoftware.DataAccess.DatabasePlatform.Excel)
            oDb.Name = OpenFileDialog1.FileName
            oDb.ExcelIMEX = 1
            oDb.ExcelHeader = True
            Dim oDal As New CooperSoftware.DataAccess.DAL(oDb)

            data = oDal.GetDataTable("SELECT * FROM [Sheet1$]")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        DataGridView1.DataSource = data

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim selectedCols As New List(Of Integer)

        For i = 0 To DataGridView1.SelectedCells.Count - 1
            selectedCols.Add(DataGridView1.SelectedCells.Item(i).ColumnIndex)
        Next

        Dim data As New List(Of Double())
        '    Dim data(DataGridView1.RowCount)() As Double
        Dim rowOn As Integer = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim a(DataGridView1.Columns.Count) As Double
            Dim count As Integer = 0
            For Each cell As DataGridViewCell In row.Cells
                If selectedCols.Contains(cell.ColumnIndex) Then
                    a(count) = CDbl(cell.Value)
                    count += 1
                End If
            Next
            data.Add(a)
            rowOn += 1
        Next

        DataGridView1.Columns.Add("1NN", "1-NN")

        For index = 0 To data.Count - 1
            Dim test() As Double = data(index)
            data.RemoveAt(index)

            DataGridView1.Rows(index).Cells("1NN").Value = FirstNearestNeighbour(data, test)
            data.Add(test)
        Next
    End Sub

    Public Sub MinMaxOnGridColumn(ByVal grid As DataGridView, ByVal column As Integer)
        Dim minVal As Double
        Dim maxVal As Double = 0

        ' get the min and max value
        For Each row As DataGridViewRow In grid.Rows
            If IsNumeric(row.Cells(column).Value) Then
                Dim val = CDbl(row.Cells(column).Value)
                If minVal > val Then
                    minVal = val
                End If

                If maxVal < val Then
                    maxVal = val
                End If
            Else
                Throw New Exception("Cell values must be numeric do to min-max normalisation")
            End If
        Next

        Dim range As Double = maxVal - minVal

        For Each row As DataGridViewRow In grid.Rows
            Dim currentVal As Double = CDbl(row.Cells(column).Value)

            row.Cells(column).Value = ((currentVal - minVal) / range) * 100


        Next

    End Sub

    Public Function FirstNearestNeighbour(ByVal LearningData As List(Of Double()), ByVal data() As Double) As Double
        Dim distances As New List(Of Double)

        For index = 0 To LearningData.Count - 1
            Dim distance As Double = EuclidianDistance(LearningData(index), data)
            If distance <> -1 Then
                If distance = 0 Then
                    distances.Add(distance)
                End If
                distances.Add(distance)

            End If
        Next

        Return distances.Min
    End Function

    Public Function EuclidianDistance(ByVal a() As Double, ByVal b() As Double) As Double
        Dim sumDistance As Double = 0
        Try
            If a.Length = b.Length Then
                For index = 0 To a.Length - 1
                    sumDistance += (a(index) - b(index)) ^ 2
                Next
            Else
                Throw New Exception("Arrays a and b require the same number of elements")
            End If
        Catch ex As NullReferenceException
            Return -1
        End Try

        Return sumDistance
    End Function

    Private Sub btnMinMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinMax.Click
        Dim selectedCols As New List(Of Integer)

        For i = 0 To DataGridView1.SelectedCells.Count - 1
            selectedCols.Add(DataGridView1.SelectedCells.Item(i).ColumnIndex)
        Next

        For Each columnNo As Integer In selectedCols
            MinMaxOnGridColumn(DataGridView1, columnNo)
        Next

    End Sub

    Private Sub btnCalcAccuracy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcAccuracy.Click

        'Dim selectedCols As New List(Of Integer)

        'For i = 0 To DataGridView1.SelectedCells.Count - 1
        '    selectedCols.Add(DataGridView1.SelectedCells.Item(i).ColumnIndex)
        'Next

        'If selectedCols.Count <> 2 Then
        '    Throw New Exception("Must be only two columns selected")
        'End If

        Dim accuracy As Integer = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            accuracy += CheckAccuracy(DataGridView1, selectedClassIndex, selectedNNIndex, row.Index)
        Next

        MsgBox(100 * accuracy / DataGridView1.Rows.Count)
    End Sub


    Public Function CheckAccuracy(ByVal data As DataGridView, ByVal classColumnNo As Integer, ByVal nnColumnNo As Integer, ByVal currentRowNo As Integer) As Integer

        Dim nnVal As Double = CDec(data.Rows(currentRowNo).Cells(nnColumnNo).Value)
        Dim nnClass As Object = data.Rows(currentRowNo).Cells(classColumnNo).Value

        Dim test = (From x In data.Rows.Cast(Of DataGridViewRow)() Where x.Index <> currentRowNo Select dataClass = x.Cells(classColumnNo).Value, nn = CDbl(x.Cells(nnColumnNo).Value) Order By Math.Abs(nn - nnVal)).First

        Dim closestClass As Object = (From x In data.Rows.Cast(Of DataGridViewRow)() Where x.Index <> currentRowNo Select dataClass = x.Cells(classColumnNo).Value, nn = CDbl(x.Cells(nnColumnNo).Value) Order By Math.Abs(nn - nnVal)).First.dataClass

        If nnClass Is closestClass Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Private Sub btnSetClassField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetClassField.Click
        Dim selectedCols As New List(Of Integer)

        For i = 0 To DataGridView1.SelectedCells.Count - 1
            selectedCols.Add(DataGridView1.SelectedCells.Item(i).ColumnIndex)
        Next

        If selectedCols.Count <> 1 Then
            Throw New Exception("Must be only one column selected")
        End If

        selectedClassIndex = selectedCols.First
        lblClassField.Text = selectedClassIndex.ToString
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim selectedCols As New List(Of Integer)

        For i = 0 To DataGridView1.SelectedCells.Count - 1
            selectedCols.Add(DataGridView1.SelectedCells.Item(i).ColumnIndex)
        Next

        If selectedCols.Count <> 1 Then
            Throw New Exception("Must be only one column selected")
        End If

        selectedNNIndex = selectedCols.First
        lblNNField.Text = selectedNNIndex.ToString
    End Sub
End Class
