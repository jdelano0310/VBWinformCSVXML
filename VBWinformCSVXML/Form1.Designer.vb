<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        txtExcelFile = New TextBox()
        btnSelectExcel = New Button()
        btnSelectXML = New Button()
        txtXMLFile = New TextBox()
        Label2 = New Label()
        btnRun = New Button()
        lblStatus = New Label()
        ofDLG = New OpenFileDialog()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(5, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(132, 25)
        Label1.TabIndex = 0
        Label1.Text = "Select Excel File"
        ' 
        ' txtExcelFile
        ' 
        txtExcelFile.Location = New Point(8, 38)
        txtExcelFile.Name = "txtExcelFile"
        txtExcelFile.ReadOnly = True
        txtExcelFile.Size = New Size(730, 31)
        txtExcelFile.TabIndex = 1
        ' 
        ' btnSelectExcel
        ' 
        btnSelectExcel.Location = New Point(744, 38)
        btnSelectExcel.Name = "btnSelectExcel"
        btnSelectExcel.Size = New Size(41, 30)
        btnSelectExcel.TabIndex = 2
        btnSelectExcel.Text = "..."
        btnSelectExcel.UseVisualStyleBackColor = True
        ' 
        ' btnSelectXML
        ' 
        btnSelectXML.Location = New Point(747, 111)
        btnSelectXML.Name = "btnSelectXML"
        btnSelectXML.Size = New Size(41, 30)
        btnSelectXML.TabIndex = 5
        btnSelectXML.Text = "..."
        btnSelectXML.UseVisualStyleBackColor = True
        ' 
        ' txtXMLFile
        ' 
        txtXMLFile.Location = New Point(11, 111)
        txtXMLFile.Name = "txtXMLFile"
        txtXMLFile.ReadOnly = True
        txtXMLFile.Size = New Size(730, 31)
        txtXMLFile.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(8, 83)
        Label2.Name = "Label2"
        Label2.Size = New Size(129, 25)
        Label2.TabIndex = 3
        Label2.Text = "Select XML File"
        ' 
        ' btnRun
        ' 
        btnRun.Location = New Point(656, 168)
        btnRun.Name = "btnRun"
        btnRun.Size = New Size(130, 36)
        btnRun.TabIndex = 6
        btnRun.Text = "Run"
        btnRun.UseVisualStyleBackColor = True
        ' 
        ' lblStatus
        ' 
        lblStatus.Location = New Point(21, 179)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(257, 32)
        lblStatus.TabIndex = 7
        ' 
        ' ofDLG
        ' 
        ofDLG.RestoreDirectory = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 227)
        Controls.Add(lblStatus)
        Controls.Add(btnRun)
        Controls.Add(btnSelectXML)
        Controls.Add(txtXMLFile)
        Controls.Add(Label2)
        Controls.Add(btnSelectExcel)
        Controls.Add(txtExcelFile)
        Controls.Add(Label1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtExcelFile As TextBox
    Friend WithEvents btnSelectExcel As Button
    Friend WithEvents btnSelectXML As Button
    Friend WithEvents txtXMLFile As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnRun As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents ofDLG As OpenFileDialog
End Class
