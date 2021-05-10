<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class new_user
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
        Me.TB_username = New System.Windows.Forms.TextBox()
        Me.LB_username = New System.Windows.Forms.Label()
        Me.BTN_create = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TB_username
        '
        Me.TB_username.Location = New System.Drawing.Point(76, 12)
        Me.TB_username.Name = "TB_username"
        Me.TB_username.Size = New System.Drawing.Size(223, 20)
        Me.TB_username.TabIndex = 0
        '
        'LB_username
        '
        Me.LB_username.AutoSize = True
        Me.LB_username.Location = New System.Drawing.Point(12, 15)
        Me.LB_username.Name = "LB_username"
        Me.LB_username.Size = New System.Drawing.Size(58, 13)
        Me.LB_username.TabIndex = 1
        Me.LB_username.Text = "Username:"
        '
        'BTN_create
        '
        Me.BTN_create.Location = New System.Drawing.Point(115, 48)
        Me.BTN_create.Name = "BTN_create"
        Me.BTN_create.Size = New System.Drawing.Size(75, 23)
        Me.BTN_create.TabIndex = 2
        Me.BTN_create.Text = "Create"
        Me.BTN_create.UseVisualStyleBackColor = True
        '
        'new_user
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 84)
        Me.Controls.Add(Me.BTN_create)
        Me.Controls.Add(Me.LB_username)
        Me.Controls.Add(Me.TB_username)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "new_user"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TB_username As TextBox
    Friend WithEvents LB_username As Label
    Friend WithEvents BTN_create As Button
End Class
