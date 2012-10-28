Public Class Form1

    Private data As DataTable
    Private classField As Integer
    Private Const classColName As String = "Class"


    Private Sub btnSelectSS_Click(sender As Object, e As EventArgs) Handles btnSelectSS.Click
        fdSelectSS.ShowDialog()
    End Sub


    Private Sub fdSelectSS_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles fdSelectSS.FileOk
        gvData.Columns.Clear()

        Try
            Dim oDb As New CooperSoftware.DataAccess.Database(CooperSoftware.DataAccess.DatabasePlatform.Excel)
            oDb.Name = fdSelectSS.FileName
            oDb.ExcelIMEX = 1
            oDb.ExcelHeader = True
            Dim oDal As New CooperSoftware.DataAccess.DAL(oDb)

            data = oDal.GetDataTable("SELECT * FROM [Sheet1$]")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
        gvData.DataSource = data
    End Sub


    Private Sub btnSetClassField_Click(sender As Object, e As EventArgs) Handles btnSetClassField.Click
        If gvData.SelectedCells.Count = 1 Then
            classField = gvData.SelectedCells(0).ColumnIndex
            lblClassField.Text = classField
        Else
            MsgBox("Only one column may be selected for the class field.")
        End If
    End Sub

    Private Sub btnGenBins_Click(sender As Object, e As EventArgs) Handles btnGenBins.Click

     
        Dim noBins As Integer = CInt(InputBox("Please enter the number of bins"))

        gvData.Columns.Add("Bin", "Bin")

        Dim minValue As Double = (From row As DataGridViewRow In gvData.Rows Select CDbl(row.Cells(classField).Value)).Min

        Dim maxValue As Double = (From row As DataGridViewRow In gvData.Rows Select CDbl(row.Cells(classField).Value)).Max

   


        Dim interval As Double = (maxValue - minValue) / noBins

        lblNoBins.Text = noBins

        For bin = 1 To noBins
            For Each row As DataGridViewRow In gvData.Rows
                Dim classValue As Double = CDbl(row.Cells(classField).Value)

                If row.Cells("Bin").Value Is Nothing Then
                    If classValue > ((bin - 1) * interval) AndAlso classValue <= (bin * interval) Then
                        row.Cells("Bin").Value = bin
                    ElseIf classValue = 0 Then
                        row.Cells("Bin").Value = 1
                    End If
                End If

                
            Next
        Next

    End Sub

    Private Sub btnRandomiseRows_Click(sender As Object, e As EventArgs) Handles btnRandomiseRows.Click
        data = getDataTable(gvData)

        Dim randomList As New List(Of DataRow)

        Dim rowsAllocated As New List(Of Integer)
        Dim noRows As Integer = gvData.Rows.Count
        Dim randomNoGen As New Random

        For index = 0 To noRows - 1
            If rowsAllocated.Count <> noRows - 1 Then
                ' Randomly generate index
                Dim randomNo As Integer = randomNoGen.Next(0, (noRows - 1))

                'Generate a new random no if row already allocated
                While rowsAllocated.Contains(randomNo)
                    randomNo = randomNoGen.Next(0, (noRows - 1))
                End While

                randomList.Add(data.Rows(randomNo))
                rowsAllocated.Add(randomNo)

            End If
        Next

        Dim newIndex As Integer = 0

        Dim randomDataTable As New DataTable

        For Each dtCol As DataColumn In data.Columns
            randomDataTable.Columns.Add(dtCol.ColumnName)
        Next

        For index = 0 To randomList.Count - 1
            randomDataTable.ImportRow(randomList(index))
            index += 1
        Next



        ' gvData.Columns.Clear()
        gvData.DataSource = randomDataTable
        MsgBox("here")

    End Sub

    Public Function getDataTable(ByVal gv As DataGridView) As DataTable
        Dim dt As New DataTable

        ' Add columns
        For Each col As DataGridViewColumn In gv.Columns
            dt.Columns.Add(col.Name)
        Next

        ' Add data

        For Each row As DataGridViewRow In gv.Rows
            Dim newRow As DataRow = dt.NewRow

            For Each cell As DataGridViewCell In row.Cells
                newRow.Item(cell.ColumnIndex) = cell.Value
            Next
            dt.Rows.Add(newRow)
        Next


        Return dt
    End Function

    Public Function calcStdDev(ByVal numbers As Double()) As Double
        Dim mean As Double = numbers.Sum / numbers.Length
        Dim noVals As Integer = numbers.Length - 1
        Dim sum As Double = 0

        For Each num In numbers
            sum += Math.Pow((num - mean), 2)
        Next

        Return Math.Sqrt((1 / noVals) * sum)
    End Function

    Public Function calcPearsonsR(ByVal f1 As Double(), ByVal f2 As Double()) As Double
        If f1.Length <> f2.Length Then
            Throw New Exception("Two fields must be same length (no of elements)")
        End If

        Dim noVals As Integer = f1.Length - 1

        Dim meanF1 As Double = f1.Sum / f1.Length
        Dim meanF2 As Double = f2.Sum / f2.Length

        Dim stdDevF1 As Double = calcStdDev(f1)
        Dim stdDevF2 As Double = calcStdDev(f2)

        Dim sum As Double = 0
        For i As Integer = 0 To noVals
            sum += ((f1(i) - meanF1) / stdDevF1) * ((f2(i) - meanF2) / stdDevF2)

        Next

        Return (1 / noVals) * sum
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Dim f1(8) As Double
        'Dim f2(8) As Double

        'f1 = {0.36, 0.06, 0.87, 0.04, 0.45, 1, 0.23, 0.04, 0.28}
        'f2 = {4, 1, 9, 1, 5, 10, 3, 1, 3}




        'MsgBox(calcPearsonsR(f1, f2))
    End Sub

    Private Sub btnCalculateCorrelation_Click(sender As Object, e As EventArgs) Handles btnCalculateCorrelation.Click
        Dim pctOfInstances As Integer = CInt(InputBox("Enter the number of instances (%) to account for"))
        Dim noInstances As Integer = data.Rows.Count * (pctOfInstances / 100)

        ' Generate the class field array
        Dim index As Integer = 0
        Dim classFieldVals(noInstances) As Double
        For Each row As DataRow In data.Rows
            classFieldVals(index) = row.Item(classColName)
            index += 1
            If index > noInstances Then
                Exit For
            End If
        Next

        Dim correlationValues As New List(Of PearsonsRCorrelation)

        For Each col As DataColumn In data.Columns
            If col.ColumnName <> classColName Then
                ' use this column.
                ' get the top x% of rows and calculate Pearons r

                ' Generate non class field array
                Dim nonClassFieldVals(noInstances) As Double

                index = 0
                For Each row As DataRow In data.Rows
                    nonClassFieldVals(index) = row.Item(col.ColumnName)
                    index += 1
                    If index > noInstances Then
                        Exit For
                    End If
                Next

                ' Calculate and store Pearsons r
                correlationValues.Add(New PearsonsRCorrelation(col.ColumnName, col.Ordinal, calcPearsonsR(nonClassFieldVals, classFieldVals)))
            End If
        Next

        gvPearsonsR.DataSource = correlationValues


    End Sub
End Class

Public Class PearsonsRCorrelation
    Property columnName As String
    Property columnIndex As Integer
    Property PearsonsRCorrelation As Double

    Public Sub New(colName As String, colIndex As Integer, correlation As Double)
        columnIndex = colIndex
        columnName = colName
        PearsonsRCorrelation = correlation
    End Sub
End Class
