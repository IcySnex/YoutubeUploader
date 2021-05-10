<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class about
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(about))
        Me.LB_title = New System.Windows.Forms.Label()
        Me.LB_desc = New System.Windows.Forms.Label()
        Me.RTB_about = New System.Windows.Forms.RichTextBox()
        Me.BTN_close = New System.Windows.Forms.Button()
        Me.BTN_github = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LB_title
        '
        Me.LB_title.AutoSize = True
        Me.LB_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.25!, System.Drawing.FontStyle.Underline)
        Me.LB_title.Location = New System.Drawing.Point(32, 20)
        Me.LB_title.Name = "LB_title"
        Me.LB_title.Size = New System.Drawing.Size(255, 35)
        Me.LB_title.TabIndex = 1
        Me.LB_title.Text = "YoutubeUploader"
        '
        'LB_desc
        '
        Me.LB_desc.AutoSize = True
        Me.LB_desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_desc.Location = New System.Drawing.Point(22, 55)
        Me.LB_desc.Name = "LB_desc"
        Me.LB_desc.Size = New System.Drawing.Size(273, 24)
        Me.LB_desc.TabIndex = 2
        Me.LB_desc.Text = "Fully written in VB.net - IcySnex"
        '
        'RTB_about
        '
        Me.RTB_about.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RTB_about.Location = New System.Drawing.Point(11, 99)
        Me.RTB_about.Name = "RTB_about"
        Me.RTB_about.ReadOnly = True
        Me.RTB_about.Size = New System.Drawing.Size(293, 156)
        Me.RTB_about.TabIndex = 3
        Me.RTB_about.Text = resources.GetString("RTB_about.Text")
        '
        'BTN_close
        '
        Me.BTN_close.Location = New System.Drawing.Point(120, 299)
        Me.BTN_close.Name = "BTN_close"
        Me.BTN_close.Size = New System.Drawing.Size(75, 23)
        Me.BTN_close.TabIndex = 4
        Me.BTN_close.Text = "Close"
        Me.BTN_close.UseVisualStyleBackColor = True
        '
        'BTN_github
        '
        Me.BTN_github.Location = New System.Drawing.Point(11, 255)
        Me.BTN_github.Name = "BTN_github"
        Me.BTN_github.Size = New System.Drawing.Size(293, 23)
        Me.BTN_github.TabIndex = 5
        Me.BTN_github.Text = "Open Github-Repo"
        Me.BTN_github.UseVisualStyleBackColor = True
        '
        'about
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 339)
        Me.Controls.Add(Me.BTN_close)
        Me.Controls.Add(Me.RTB_about)
        Me.Controls.Add(Me.LB_desc)
        Me.Controls.Add(Me.LB_title)
        Me.Controls.Add(Me.BTN_github)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "about"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About YoutubeUploader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LB_title As Label
    Friend WithEvents LB_desc As Label
    Friend WithEvents RTB_about As RichTextBox
    Friend WithEvents BTN_close As Button
    Friend WithEvents BTN_github As Button
End Class
