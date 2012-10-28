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
        Me.gvData = New System.Windows.Forms.DataGridView()
        Me.btnSetClassField = New System.Windows.Forms.Button()
        Me.btnGenBins = New System.Windows.Forms.Button()
        Me.btnSelectSS = New System.Windows.Forms.Button()
        Me.fdSelectSS = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblClassField = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNoBins = New System.Windows.Forms.Label()
        Me.btnRandomiseRows = New System.Windows.Forms.Button()
        Me.btnCalculateCorrelation = New System.Windows.Forms.Button()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvData
        '
        Me.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvData.Location = New System.Drawing.Point(13, 42)
        Me.gvData.Name = "gvData"
        Me.gvData.Size = New System.Drawing.Size(781, 399)
        Me.gvData.TabIndex = 0
        '
        'btnSetClassField
        '
        Me.btnSetClassField.Location = New System.Drawing.Point(93, 13)
        Me.btnSetClassField.Name = "btnSetClassField"
        Me.btnSetClassField.Size = New System.Drawing.Size(96, 23)
        Me.btnSetClassField.TabIndex = 1
        Me.btnSetClassField.Text = "Set Class Field"
        Me.btnSetClassField.UseVisualStyleBackColor = True
        '
        'btnGenBins
        '
        Me.btnGenBins.Location = New System.Drawing.Point(195, 13)
        Me.btnGenBins.Name = "btnGenBins"
        Me.btnGenBins.Size = New System.Drawing.Size(115, 23)
        Me.btnGenBins.TabIndex = 2
        Me.btnGenBins.Text = "Populate Bins"
        Me.btnGenBins.UseVisualStyleBackColor = True
        '
        'btnSelectSS
        '
        Me.btnSelectSS.Location = New System.Drawing.Point(12, 13)
        Me.btnSelectSS.Name = "btnSelectSS"
        Me.btnSelectSS.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectSS.TabIndex = 3
        Me.btnSelectSS.Text = "Select SS"
        Me.btnSelectSS.UseVisualStyleBackColor = True
        '
        'fdSelectSS
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 453)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Selected Class Field: "
        '
        'lblClassField
        '
        Me.lblClassField.AutoSize = True
        Me.lblClassField.Location = New System.Drawing.Point(127, 453)
        Me.lblClassField.Name = "lblClassField"
        Me.lblClassField.Size = New System.Drawing.Size(0, 13)
        Me.lblClassField.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(192, 453)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "No Bins:"
        '
        'lblNoBins
        '
        Me.lblNoBins.AutoSize = True
        Me.lblNoBins.Location = New System.Drawing.Point(246, 453)
        Me.lblNoBins.Name = "lblNoBins"
        Me.lblNoBins.Size = New System.Drawing.Size(0, 13)
        Me.lblNoBins.TabIndex = 7
        '
        'btnRandomiseRows
        '
        Me.btnRandomiseRows.Location = New System.Drawing.Point(317, 13)
        Me.btnRandomiseRows.Name = "btnRandomiseRows"
        Me.btnRandomiseRows.Size = New System.Drawing.Size(111, 23)
        Me.btnRandomiseRows.TabIndex = 8
        Me.btnRandomiseRows.Text = "Randomise Rows"
        Me.btnRandomiseRows.UseVisualStyleBackColor = True
        '
        'btnCalculateCorrelation
        '
        Me.btnCalculateCorrelation.Location = New System.Drawing.Point(435, 12)
        Me.btnCalculateCorrelation.Name = "btnCalculateCorrelation"
        Me.btnCalculateCorrelation.Size = New System.Drawing.Size(120, 23)
        Me.btnCalculateCorrelation.TabIndex = 9
        Me.btnCalculateCorrelation.Text = "Calculate Correlation"
        Me.btnCalculateCorrelation.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 475)
        Me.Controls.Add(Me.btnCalculateCorrelation)
        Me.Controls.Add(Me.btnRandomiseRows)
        Me.Controls.Add(Me.lblNoBins)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblClassField)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSelectSS)
        Me.Controls.Add(Me.btnGenBins)
        Me.Controls.Add(Me.btnSetClassField)
        Me.Controls.Add(Me.gvData)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvData As System.Windows.Forms.DataGridView
    Friend WithEvents btnSetClassField As System.Windows.Forms.Button
    Friend WithEvents btnGenBins As System.Windows.Forms.Button
    Friend WithEvents btnSelectSS As System.Windows.Forms.Button
    Friend WithEvents fdSelectSS As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblClassField As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNoBins As System.Windows.Forms.Label
    Friend WithEvents btnRandomiseRows As System.Windows.Forms.Button
    Friend WithEvents btnCalculateCorrelation As System.Windows.Forms.Button

End Class
