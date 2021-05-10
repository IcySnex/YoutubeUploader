<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_queue
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.UC_queue_delete = New System.Windows.Forms.Button()
        Me.UC_queue_path = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'UC_queue_delete
        '
        Me.UC_queue_delete.Location = New System.Drawing.Point(231, 2)
        Me.UC_queue_delete.Name = "UC_queue_delete"
        Me.UC_queue_delete.Size = New System.Drawing.Size(21, 21)
        Me.UC_queue_delete.TabIndex = 1
        Me.UC_queue_delete.Text = "X"
        Me.UC_queue_delete.UseVisualStyleBackColor = True
        '
        'UC_queue_path
        '
        Me.UC_queue_path.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UC_queue_path.Location = New System.Drawing.Point(1, 2)
        Me.UC_queue_path.Name = "UC_queue_path"
        Me.UC_queue_path.ReadOnly = True
        Me.UC_queue_path.Size = New System.Drawing.Size(229, 20)
        Me.UC_queue_path.TabIndex = 2
        '
        'UC_queue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.UC_queue_path)
        Me.Controls.Add(Me.UC_queue_delete)
        Me.Name = "UC_queue"
        Me.Size = New System.Drawing.Size(253, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UC_queue_delete As Button
    Friend WithEvents UC_queue_path As TextBox
End Class
