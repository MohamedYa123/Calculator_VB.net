<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.l2 = New System.Windows.Forms.ListBox()
        Me.l1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(21, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "تحديث"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'l2
        '
        Me.l2.FormattingEnabled = True
        Me.l2.Location = New System.Drawing.Point(42, 152)
        Me.l2.Name = "l2"
        Me.l2.Size = New System.Drawing.Size(213, 108)
        Me.l2.TabIndex = 1
        Me.l2.Visible = False
        '
        'l1
        '
        Me.l1.FormattingEnabled = True
        Me.l1.Location = New System.Drawing.Point(42, 299)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(213, 108)
        Me.l1.TabIndex = 2
        Me.l1.Visible = False
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlueViolet
        Me.ClientSize = New System.Drawing.Size(483, 565)
        Me.Controls.Add(Me.l1)
        Me.Controls.Add(Me.l2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Form6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "حاسبة شباب التقنية- نظام الرسم"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents l2 As System.Windows.Forms.ListBox
    Friend WithEvents l1 As System.Windows.Forms.ListBox
End Class
