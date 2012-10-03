<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnSelectSpreadsheet = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnMinMax = New System.Windows.Forms.Button()
        Me.btnCalcAccuracy = New System.Windows.Forms.Button()
        Me.btnSetClassField = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblClassField = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNNField = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSelectSpreadsheet
        '
        Me.btnSelectSpreadsheet.Location = New System.Drawing.Point(12, 12)
        Me.btnSelectSpreadsheet.Name = "btnSelectSpreadsheet"
        Me.btnSelectSpreadsheet.Size = New System.Drawing.Size(134, 23)
        Me.btnSelectSpreadsheet.TabIndex = 0
        Me.btnSelectSpreadsheet.Text = "Select Spreadsheet"
        Me.btnSelectSpreadsheet.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 42)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(978, 357)
        Me.DataGridView1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 413)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(342, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(184, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "1-NN on Selected Cols"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnMinMax
        '
        Me.btnMinMax.Location = New System.Drawing.Point(152, 12)
        Me.btnMinMax.Name = "btnMinMax"
        Me.btnMinMax.Size = New System.Drawing.Size(184, 23)
        Me.btnMinMax.TabIndex = 5
        Me.btnMinMax.Text = "Min-Max Normalisation"
        Me.btnMinMax.UseVisualStyleBackColor = True
        '
        'btnCalcAccuracy
        '
        Me.btnCalcAccuracy.Location = New System.Drawing.Point(532, 12)
        Me.btnCalcAccuracy.Name = "btnCalcAccuracy"
        Me.btnCalcAccuracy.Size = New System.Drawing.Size(184, 23)
        Me.btnCalcAccuracy.TabIndex = 6
        Me.btnCalcAccuracy.Text = "Calculate Accuracy"
        Me.btnCalcAccuracy.UseVisualStyleBackColor = True
        '
        'btnSetClassField
        '
        Me.btnSetClassField.Location = New System.Drawing.Point(723, 11)
        Me.btnSetClassField.Name = "btnSetClassField"
        Me.btnSetClassField.Size = New System.Drawing.Size(115, 23)
        Me.btnSetClassField.TabIndex = 7
        Me.btnSetClassField.Text = "Set Class Field"
        Me.btnSetClassField.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(885, 402)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Class Field:"
        '
        'lblClassField
        '
        Me.lblClassField.AutoSize = True
        Me.lblClassField.Location = New System.Drawing.Point(951, 402)
        Me.lblClassField.Name = "lblClassField"
        Me.lblClassField.Size = New System.Drawing.Size(0, 13)
        Me.lblClassField.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(736, 402)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "NN Field:"
        '
        'lblNNField
        '
        Me.lblNNField.AutoSize = True
        Me.lblNNField.Location = New System.Drawing.Point(793, 402)
        Me.lblNNField.Name = "lblNNField"
        Me.lblNNField.Size = New System.Drawing.Size(0, 13)
        Me.lblNNField.TabIndex = 12
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(844, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 23)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Set NN Field"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 438)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblNNField)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblClassField)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSetClassField)
        Me.Controls.Add(Me.btnCalcAccuracy)
        Me.Controls.Add(Me.btnMinMax)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSelectSpreadsheet)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSelectSpreadsheet As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnMinMax As System.Windows.Forms.Button
    Friend WithEvents btnCalcAccuracy As System.Windows.Forms.Button
    Friend WithEvents btnSetClassField As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblClassField As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNNField As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
