<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.GB_user = New System.Windows.Forms.GroupBox()
        Me.BTN_removeuser = New System.Windows.Forms.Button()
        Me.BTN_adduser = New System.Windows.Forms.Button()
        Me.CB_user = New System.Windows.Forms.ComboBox()
        Me.LB_user = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LB_home_state = New System.Windows.Forms.Label()
        Me.BTN_home_load = New System.Windows.Forms.Button()
        Me.BTN_home_start = New System.Windows.Forms.Button()
        Me.LB_home_title = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GB_state = New System.Windows.Forms.GroupBox()
        Me.PNL_CB_bg = New System.Windows.Forms.Panel()
        Me.CB_fluentqueue = New System.Windows.Forms.CheckBox()
        Me.LB_CB_fluentqueue = New System.Windows.Forms.Label()
        Me.LB_CB_fluentqueue_info = New System.Windows.Forms.Label()
        Me.LB_state_state = New System.Windows.Forms.Label()
        Me.LB_state_progress = New System.Windows.Forms.Label()
        Me.PB_state_progress = New System.Windows.Forms.ProgressBar()
        Me.BTN_state_start = New System.Windows.Forms.Button()
        Me.GB_details = New System.Windows.Forms.GroupBox()
        Me.CB_details_privacy = New System.Windows.Forms.ComboBox()
        Me.LB_details_privacy = New System.Windows.Forms.Label()
        Me.TB_details_tags = New System.Windows.Forms.TextBox()
        Me.LB_details_tags = New System.Windows.Forms.Label()
        Me.TB_details_description = New System.Windows.Forms.TextBox()
        Me.LB_details_description = New System.Windows.Forms.Label()
        Me.TB_details_title = New System.Windows.Forms.TextBox()
        Me.LB_details_title = New System.Windows.Forms.Label()
        Me.LB_details_tags_info = New System.Windows.Forms.Label()
        Me.GB_video = New System.Windows.Forms.GroupBox()
        Me.BTN_video_dragdrop = New System.Windows.Forms.Button()
        Me.BTN_video_browse = New System.Windows.Forms.Button()
        Me.TB_video_path = New System.Windows.Forms.TextBox()
        Me.LB_video_path = New System.Windows.Forms.Label()
        Me.GB_queue = New System.Windows.Forms.GroupBox()
        Me.BTN_queue_dragdrop = New System.Windows.Forms.Button()
        Me.BTN_queue_folder = New System.Windows.Forms.Button()
        Me.BTN_queue_file = New System.Windows.Forms.Button()
        Me.BTN_clear = New System.Windows.Forms.Button()
        Me.FLY_queue = New System.Windows.Forms.FlowLayoutPanel()
        Me.OFD_clientsecrets = New System.Windows.Forms.OpenFileDialog()
        Me.OFD_loadvideo = New System.Windows.Forms.OpenFileDialog()
        Me.FBD_loadvideo = New System.Windows.Forms.FolderBrowserDialog()
        Me.LLB_getclientsecrets = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BTN_menubar_about = New System.Windows.Forms.Button()
        Me.BTN_menubar_googledocs = New System.Windows.Forms.Button()
        Me.GB_user.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GB_state.SuspendLayout()
        Me.PNL_CB_bg.SuspendLayout()
        Me.GB_details.SuspendLayout()
        Me.GB_video.SuspendLayout()
        Me.GB_queue.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GB_user
        '
        Me.GB_user.Controls.Add(Me.BTN_removeuser)
        Me.GB_user.Controls.Add(Me.BTN_adduser)
        Me.GB_user.Controls.Add(Me.CB_user)
        Me.GB_user.Controls.Add(Me.LB_user)
        Me.GB_user.Location = New System.Drawing.Point(12, 11)
        Me.GB_user.Name = "GB_user"
        Me.GB_user.Size = New System.Drawing.Size(430, 55)
        Me.GB_user.TabIndex = 0
        Me.GB_user.TabStop = False
        Me.GB_user.Text = "User"
        '
        'BTN_removeuser
        '
        Me.BTN_removeuser.Location = New System.Drawing.Point(300, 19)
        Me.BTN_removeuser.Name = "BTN_removeuser"
        Me.BTN_removeuser.Size = New System.Drawing.Size(60, 21)
        Me.BTN_removeuser.TabIndex = 3
        Me.BTN_removeuser.Text = "Remove"
        Me.BTN_removeuser.UseVisualStyleBackColor = True
        '
        'BTN_adduser
        '
        Me.BTN_adduser.Location = New System.Drawing.Point(358, 19)
        Me.BTN_adduser.Name = "BTN_adduser"
        Me.BTN_adduser.Size = New System.Drawing.Size(62, 21)
        Me.BTN_adduser.TabIndex = 2
        Me.BTN_adduser.Text = "Add User"
        Me.BTN_adduser.UseVisualStyleBackColor = True
        '
        'CB_user
        '
        Me.CB_user.FormattingEnabled = True
        Me.CB_user.Items.AddRange(New Object() {"Default"})
        Me.CB_user.Location = New System.Drawing.Point(82, 19)
        Me.CB_user.Name = "CB_user"
        Me.CB_user.Size = New System.Drawing.Size(219, 21)
        Me.CB_user.TabIndex = 1
        '
        'LB_user
        '
        Me.LB_user.AutoSize = True
        Me.LB_user.Location = New System.Drawing.Point(7, 22)
        Me.LB_user.Name = "LB_user"
        Me.LB_user.Size = New System.Drawing.Size(69, 13)
        Me.LB_user.TabIndex = 0
        Me.LB_user.Text = "Current User:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-4, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(761, 706)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.LLB_getclientsecrets)
        Me.TabPage1.Controls.Add(Me.LB_home_state)
        Me.TabPage1.Controls.Add(Me.BTN_home_load)
        Me.TabPage1.Controls.Add(Me.BTN_home_start)
        Me.TabPage1.Controls.Add(Me.LB_home_title)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(753, 680)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Start"
        '
        'LB_home_state
        '
        Me.LB_home_state.Location = New System.Drawing.Point(5, 166)
        Me.LB_home_state.Name = "LB_home_state"
        Me.LB_home_state.Size = New System.Drawing.Size(741, 17)
        Me.LB_home_state.TabIndex = 3
        Me.LB_home_state.Text = "Not logged in..."
        Me.LB_home_state.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BTN_home_load
        '
        Me.BTN_home_load.Location = New System.Drawing.Point(293, 249)
        Me.BTN_home_load.Name = "BTN_home_load"
        Me.BTN_home_load.Size = New System.Drawing.Size(156, 30)
        Me.BTN_home_load.TabIndex = 2
        Me.BTN_home_load.Text = "Load client_secrets.json"
        Me.BTN_home_load.UseVisualStyleBackColor = True
        '
        'BTN_home_start
        '
        Me.BTN_home_start.Location = New System.Drawing.Point(293, 186)
        Me.BTN_home_start.Name = "BTN_home_start"
        Me.BTN_home_start.Size = New System.Drawing.Size(156, 57)
        Me.BTN_home_start.TabIndex = 1
        Me.BTN_home_start.Text = "Start"
        Me.BTN_home_start.UseVisualStyleBackColor = True
        '
        'LB_home_title
        '
        Me.LB_home_title.AutoSize = True
        Me.LB_home_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 29.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_home_title.Location = New System.Drawing.Point(228, 96)
        Me.LB_home_title.Name = "LB_home_title"
        Me.LB_home_title.Size = New System.Drawing.Size(291, 44)
        Me.LB_home_title.TabIndex = 0
        Me.LB_home_title.Text = "Lets get startet!"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.GB_state)
        Me.TabPage2.Controls.Add(Me.GB_details)
        Me.TabPage2.Controls.Add(Me.GB_video)
        Me.TabPage2.Controls.Add(Me.GB_queue)
        Me.TabPage2.Controls.Add(Me.GB_user)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(753, 680)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Inside"
        '
        'GB_state
        '
        Me.GB_state.Controls.Add(Me.PNL_CB_bg)
        Me.GB_state.Controls.Add(Me.LB_CB_fluentqueue)
        Me.GB_state.Controls.Add(Me.LB_CB_fluentqueue_info)
        Me.GB_state.Controls.Add(Me.LB_state_state)
        Me.GB_state.Controls.Add(Me.LB_state_progress)
        Me.GB_state.Controls.Add(Me.PB_state_progress)
        Me.GB_state.Controls.Add(Me.BTN_state_start)
        Me.GB_state.Location = New System.Drawing.Point(12, 525)
        Me.GB_state.Name = "GB_state"
        Me.GB_state.Size = New System.Drawing.Size(430, 139)
        Me.GB_state.TabIndex = 4
        Me.GB_state.TabStop = False
        Me.GB_state.Text = "State"
        '
        'PNL_CB_bg
        '
        Me.PNL_CB_bg.BackColor = System.Drawing.SystemColors.ControlText
        Me.PNL_CB_bg.Controls.Add(Me.CB_fluentqueue)
        Me.PNL_CB_bg.Location = New System.Drawing.Point(156, 54)
        Me.PNL_CB_bg.Name = "PNL_CB_bg"
        Me.PNL_CB_bg.Size = New System.Drawing.Size(12, 12)
        Me.PNL_CB_bg.TabIndex = 26
        '
        'CB_fluentqueue
        '
        Me.CB_fluentqueue.Checked = True
        Me.CB_fluentqueue.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_fluentqueue.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.CB_fluentqueue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CB_fluentqueue.Location = New System.Drawing.Point(0, 1)
        Me.CB_fluentqueue.Name = "CB_fluentqueue"
        Me.CB_fluentqueue.Size = New System.Drawing.Size(11, 10)
        Me.CB_fluentqueue.TabIndex = 22
        Me.CB_fluentqueue.Text = "Use Fastmode"
        Me.CB_fluentqueue.UseVisualStyleBackColor = True
        '
        'LB_CB_fluentqueue
        '
        Me.LB_CB_fluentqueue.AutoSize = True
        Me.LB_CB_fluentqueue.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.LB_CB_fluentqueue.Location = New System.Drawing.Point(168, 54)
        Me.LB_CB_fluentqueue.Name = "LB_CB_fluentqueue"
        Me.LB_CB_fluentqueue.Size = New System.Drawing.Size(71, 13)
        Me.LB_CB_fluentqueue.TabIndex = 27
        Me.LB_CB_fluentqueue.Text = "Fluent Queue"
        '
        'LB_CB_fluentqueue_info
        '
        Me.LB_CB_fluentqueue_info.AutoSize = True
        Me.LB_CB_fluentqueue_info.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LB_CB_fluentqueue_info.ForeColor = System.Drawing.Color.DarkGray
        Me.LB_CB_fluentqueue_info.Location = New System.Drawing.Point(235, 54)
        Me.LB_CB_fluentqueue_info.Name = "LB_CB_fluentqueue_info"
        Me.LB_CB_fluentqueue_info.Size = New System.Drawing.Size(13, 13)
        Me.LB_CB_fluentqueue_info.TabIndex = 28
        Me.LB_CB_fluentqueue_info.Text = "?"
        '
        'LB_state_state
        '
        Me.LB_state_state.Location = New System.Drawing.Point(149, 88)
        Me.LB_state_state.Name = "LB_state_state"
        Me.LB_state_state.Size = New System.Drawing.Size(271, 13)
        Me.LB_state_state.TabIndex = 15
        Me.LB_state_state.Text = "Upload not startet..."
        Me.LB_state_state.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LB_state_progress
        '
        Me.LB_state_progress.AutoSize = True
        Me.LB_state_progress.Location = New System.Drawing.Point(7, 88)
        Me.LB_state_progress.Name = "LB_state_progress"
        Me.LB_state_progress.Size = New System.Drawing.Size(88, 13)
        Me.LB_state_progress.TabIndex = 14
        Me.LB_state_progress.Text = "Upload Progress:"
        '
        'PB_state_progress
        '
        Me.PB_state_progress.Location = New System.Drawing.Point(8, 104)
        Me.PB_state_progress.Name = "PB_state_progress"
        Me.PB_state_progress.Size = New System.Drawing.Size(413, 23)
        Me.PB_state_progress.TabIndex = 8
        '
        'BTN_state_start
        '
        Me.BTN_state_start.Location = New System.Drawing.Point(149, 19)
        Me.BTN_state_start.Name = "BTN_state_start"
        Me.BTN_state_start.Size = New System.Drawing.Size(107, 30)
        Me.BTN_state_start.TabIndex = 7
        Me.BTN_state_start.Text = "Start"
        Me.BTN_state_start.UseVisualStyleBackColor = True
        '
        'GB_details
        '
        Me.GB_details.Controls.Add(Me.CB_details_privacy)
        Me.GB_details.Controls.Add(Me.LB_details_privacy)
        Me.GB_details.Controls.Add(Me.TB_details_tags)
        Me.GB_details.Controls.Add(Me.LB_details_tags)
        Me.GB_details.Controls.Add(Me.TB_details_description)
        Me.GB_details.Controls.Add(Me.LB_details_description)
        Me.GB_details.Controls.Add(Me.TB_details_title)
        Me.GB_details.Controls.Add(Me.LB_details_title)
        Me.GB_details.Controls.Add(Me.LB_details_tags_info)
        Me.GB_details.Location = New System.Drawing.Point(12, 162)
        Me.GB_details.Name = "GB_details"
        Me.GB_details.Size = New System.Drawing.Size(430, 357)
        Me.GB_details.TabIndex = 3
        Me.GB_details.TabStop = False
        Me.GB_details.Text = "Video Details"
        '
        'CB_details_privacy
        '
        Me.CB_details_privacy.FormattingEnabled = True
        Me.CB_details_privacy.Items.AddRange(New Object() {"public", "private", "unlisted"})
        Me.CB_details_privacy.Location = New System.Drawing.Point(52, 294)
        Me.CB_details_privacy.Name = "CB_details_privacy"
        Me.CB_details_privacy.Size = New System.Drawing.Size(368, 21)
        Me.CB_details_privacy.TabIndex = 5
        '
        'LB_details_privacy
        '
        Me.LB_details_privacy.AutoSize = True
        Me.LB_details_privacy.Location = New System.Drawing.Point(1, 297)
        Me.LB_details_privacy.Name = "LB_details_privacy"
        Me.LB_details_privacy.Size = New System.Drawing.Size(45, 13)
        Me.LB_details_privacy.TabIndex = 4
        Me.LB_details_privacy.Text = "Privacy:"
        '
        'TB_details_tags
        '
        Me.TB_details_tags.Location = New System.Drawing.Point(47, 206)
        Me.TB_details_tags.Multiline = True
        Me.TB_details_tags.Name = "TB_details_tags"
        Me.TB_details_tags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TB_details_tags.Size = New System.Drawing.Size(373, 73)
        Me.TB_details_tags.TabIndex = 12
        '
        'LB_details_tags
        '
        Me.LB_details_tags.AutoSize = True
        Me.LB_details_tags.Location = New System.Drawing.Point(7, 209)
        Me.LB_details_tags.Name = "LB_details_tags"
        Me.LB_details_tags.Size = New System.Drawing.Size(34, 13)
        Me.LB_details_tags.TabIndex = 11
        Me.LB_details_tags.Text = "Tags:"
        '
        'TB_details_description
        '
        Me.TB_details_description.Location = New System.Drawing.Point(76, 45)
        Me.TB_details_description.Multiline = True
        Me.TB_details_description.Name = "TB_details_description"
        Me.TB_details_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TB_details_description.Size = New System.Drawing.Size(344, 155)
        Me.TB_details_description.TabIndex = 10
        '
        'LB_details_description
        '
        Me.LB_details_description.AutoSize = True
        Me.LB_details_description.Location = New System.Drawing.Point(7, 48)
        Me.LB_details_description.Name = "LB_details_description"
        Me.LB_details_description.Size = New System.Drawing.Size(63, 13)
        Me.LB_details_description.TabIndex = 9
        Me.LB_details_description.Text = "Description:"
        '
        'TB_details_title
        '
        Me.TB_details_title.Location = New System.Drawing.Point(43, 19)
        Me.TB_details_title.Name = "TB_details_title"
        Me.TB_details_title.Size = New System.Drawing.Size(377, 20)
        Me.TB_details_title.TabIndex = 8
        '
        'LB_details_title
        '
        Me.LB_details_title.AutoSize = True
        Me.LB_details_title.Location = New System.Drawing.Point(7, 22)
        Me.LB_details_title.Name = "LB_details_title"
        Me.LB_details_title.Size = New System.Drawing.Size(30, 13)
        Me.LB_details_title.TabIndex = 7
        Me.LB_details_title.Text = "Title:"
        '
        'LB_details_tags_info
        '
        Me.LB_details_tags_info.AutoSize = True
        Me.LB_details_tags_info.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.LB_details_tags_info.Location = New System.Drawing.Point(44, 278)
        Me.LB_details_tags_info.Name = "LB_details_tags_info"
        Me.LB_details_tags_info.Size = New System.Drawing.Size(74, 13)
        Me.LB_details_tags_info.TabIndex = 13
        Me.LB_details_tags_info.Text = "Use "","" to split"
        '
        'GB_video
        '
        Me.GB_video.Controls.Add(Me.BTN_video_dragdrop)
        Me.GB_video.Controls.Add(Me.BTN_video_browse)
        Me.GB_video.Controls.Add(Me.TB_video_path)
        Me.GB_video.Controls.Add(Me.LB_video_path)
        Me.GB_video.Location = New System.Drawing.Point(12, 72)
        Me.GB_video.Name = "GB_video"
        Me.GB_video.Size = New System.Drawing.Size(430, 84)
        Me.GB_video.TabIndex = 2
        Me.GB_video.TabStop = False
        Me.GB_video.Text = "Video Path"
        '
        'BTN_video_dragdrop
        '
        Me.BTN_video_dragdrop.AllowDrop = True
        Me.BTN_video_dragdrop.Location = New System.Drawing.Point(10, 45)
        Me.BTN_video_dragdrop.Name = "BTN_video_dragdrop"
        Me.BTN_video_dragdrop.Size = New System.Drawing.Size(410, 25)
        Me.BTN_video_dragdrop.TabIndex = 6
        Me.BTN_video_dragdrop.Text = "OR Drag and Drop your video here!"
        Me.BTN_video_dragdrop.UseVisualStyleBackColor = True
        '
        'BTN_video_browse
        '
        Me.BTN_video_browse.Location = New System.Drawing.Point(358, 19)
        Me.BTN_video_browse.Name = "BTN_video_browse"
        Me.BTN_video_browse.Size = New System.Drawing.Size(62, 20)
        Me.BTN_video_browse.TabIndex = 4
        Me.BTN_video_browse.Text = "Browse"
        Me.BTN_video_browse.UseVisualStyleBackColor = True
        '
        'TB_video_path
        '
        Me.TB_video_path.Location = New System.Drawing.Point(45, 19)
        Me.TB_video_path.Name = "TB_video_path"
        Me.TB_video_path.Size = New System.Drawing.Size(307, 20)
        Me.TB_video_path.TabIndex = 5
        '
        'LB_video_path
        '
        Me.LB_video_path.AutoSize = True
        Me.LB_video_path.Location = New System.Drawing.Point(7, 22)
        Me.LB_video_path.Name = "LB_video_path"
        Me.LB_video_path.Size = New System.Drawing.Size(32, 13)
        Me.LB_video_path.TabIndex = 4
        Me.LB_video_path.Text = "Path:"
        '
        'GB_queue
        '
        Me.GB_queue.Controls.Add(Me.BTN_queue_dragdrop)
        Me.GB_queue.Controls.Add(Me.BTN_queue_folder)
        Me.GB_queue.Controls.Add(Me.BTN_queue_file)
        Me.GB_queue.Controls.Add(Me.BTN_clear)
        Me.GB_queue.Controls.Add(Me.FLY_queue)
        Me.GB_queue.Location = New System.Drawing.Point(448, 11)
        Me.GB_queue.Name = "GB_queue"
        Me.GB_queue.Size = New System.Drawing.Size(294, 653)
        Me.GB_queue.TabIndex = 1
        Me.GB_queue.TabStop = False
        Me.GB_queue.Text = "Loaded Videos: 0"
        '
        'BTN_queue_dragdrop
        '
        Me.BTN_queue_dragdrop.AllowDrop = True
        Me.BTN_queue_dragdrop.Location = New System.Drawing.Point(7, 598)
        Me.BTN_queue_dragdrop.Name = "BTN_queue_dragdrop"
        Me.BTN_queue_dragdrop.Size = New System.Drawing.Size(281, 20)
        Me.BTN_queue_dragdrop.TabIndex = 10
        Me.BTN_queue_dragdrop.Text = "Drag and Drop File/s"
        Me.BTN_queue_dragdrop.UseVisualStyleBackColor = True
        '
        'BTN_queue_folder
        '
        Me.BTN_queue_folder.Location = New System.Drawing.Point(86, 624)
        Me.BTN_queue_folder.Name = "BTN_queue_folder"
        Me.BTN_queue_folder.Size = New System.Drawing.Size(73, 20)
        Me.BTN_queue_folder.TabIndex = 9
        Me.BTN_queue_folder.Text = "Add Folder"
        Me.BTN_queue_folder.UseVisualStyleBackColor = True
        '
        'BTN_queue_file
        '
        Me.BTN_queue_file.Location = New System.Drawing.Point(7, 624)
        Me.BTN_queue_file.Name = "BTN_queue_file"
        Me.BTN_queue_file.Size = New System.Drawing.Size(73, 20)
        Me.BTN_queue_file.TabIndex = 8
        Me.BTN_queue_file.Text = "Add File"
        Me.BTN_queue_file.UseVisualStyleBackColor = True
        '
        'BTN_clear
        '
        Me.BTN_clear.Location = New System.Drawing.Point(165, 624)
        Me.BTN_clear.Name = "BTN_clear"
        Me.BTN_clear.Size = New System.Drawing.Size(123, 20)
        Me.BTN_clear.TabIndex = 6
        Me.BTN_clear.Text = "Clear Queue"
        Me.BTN_clear.UseVisualStyleBackColor = True
        '
        'FLY_queue
        '
        Me.FLY_queue.AutoScroll = True
        Me.FLY_queue.Location = New System.Drawing.Point(7, 19)
        Me.FLY_queue.Name = "FLY_queue"
        Me.FLY_queue.Size = New System.Drawing.Size(281, 573)
        Me.FLY_queue.TabIndex = 7
        '
        'OFD_clientsecrets
        '
        Me.OFD_clientsecrets.FileName = "client_secrets.json"
        Me.OFD_clientsecrets.Filter = "client_secrets|*.json"
        '
        'OFD_loadvideo
        '
        Me.OFD_loadvideo.FileName = "video.mp4"
        Me.OFD_loadvideo.Filter = "mkv|*.mkv|webm|*.webm|flv|*.flv|avi|*.avi|mov|*.mov|mp4|*.mp4|mpg|*.mpg|mpeg|*.mp" &
    "eg|m4v|*.m4v"
        '
        'FBD_loadvideo
        '
        Me.FBD_loadvideo.Description = "Select the folder with all your videos you want to upload!"
        '
        'LLB_getclientsecrets
        '
        Me.LLB_getclientsecrets.AutoSize = True
        Me.LLB_getclientsecrets.Location = New System.Drawing.Point(291, 282)
        Me.LLB_getclientsecrets.Name = "LLB_getclientsecrets"
        Me.LLB_getclientsecrets.Size = New System.Drawing.Size(160, 13)
        Me.LLB_getclientsecrets.TabIndex = 4
        Me.LLB_getclientsecrets.TabStop = True
        Me.LLB_getclientsecrets.Text = "Get your own client_secrets.json"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(0, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 23)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'BTN_menubar_about
        '
        Me.BTN_menubar_about.Location = New System.Drawing.Point(0, 2)
        Me.BTN_menubar_about.Name = "BTN_menubar_about"
        Me.BTN_menubar_about.Size = New System.Drawing.Size(55, 22)
        Me.BTN_menubar_about.TabIndex = 6
        Me.BTN_menubar_about.Text = "About"
        Me.BTN_menubar_about.UseVisualStyleBackColor = True
        '
        'BTN_menubar_googledocs
        '
        Me.BTN_menubar_googledocs.Location = New System.Drawing.Point(53, 2)
        Me.BTN_menubar_googledocs.Name = "BTN_menubar_googledocs"
        Me.BTN_menubar_googledocs.Size = New System.Drawing.Size(132, 22)
        Me.BTN_menubar_googledocs.TabIndex = 7
        Me.BTN_menubar_googledocs.Text = "Google Documentation"
        Me.BTN_menubar_googledocs.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 700)
        Me.Controls.Add(Me.BTN_menubar_googledocs)
        Me.Controls.Add(Me.BTN_menubar_about)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "YoutubeUploader"
        Me.GB_user.ResumeLayout(False)
        Me.GB_user.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GB_state.ResumeLayout(False)
        Me.GB_state.PerformLayout()
        Me.PNL_CB_bg.ResumeLayout(False)
        Me.GB_details.ResumeLayout(False)
        Me.GB_details.PerformLayout()
        Me.GB_video.ResumeLayout(False)
        Me.GB_video.PerformLayout()
        Me.GB_queue.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GB_user As GroupBox
    Friend WithEvents BTN_adduser As Button
    Friend WithEvents CB_user As ComboBox
    Friend WithEvents LB_user As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GB_queue As GroupBox
    Friend WithEvents BTN_removeuser As Button
    Friend WithEvents BTN_home_start As Button
    Friend WithEvents LB_home_title As Label
    Friend WithEvents BTN_home_load As Button
    Friend WithEvents OFD_clientsecrets As OpenFileDialog
    Friend WithEvents LB_home_state As Label
    Friend WithEvents GB_video As GroupBox
    Friend WithEvents TB_video_path As TextBox
    Friend WithEvents LB_video_path As Label
    Friend WithEvents BTN_video_browse As Button
    Friend WithEvents OFD_loadvideo As OpenFileDialog
    Friend WithEvents BTN_video_dragdrop As Button
    Friend WithEvents GB_state As GroupBox
    Friend WithEvents LB_state_progress As Label
    Friend WithEvents PB_state_progress As ProgressBar
    Friend WithEvents BTN_state_start As Button
    Friend WithEvents GB_details As GroupBox
    Friend WithEvents TB_details_tags As TextBox
    Friend WithEvents LB_details_tags As Label
    Friend WithEvents TB_details_description As TextBox
    Friend WithEvents LB_details_description As Label
    Friend WithEvents TB_details_title As TextBox
    Friend WithEvents LB_details_title As Label
    Friend WithEvents LB_details_tags_info As Label
    Friend WithEvents CB_details_privacy As ComboBox
    Friend WithEvents LB_details_privacy As Label
    Friend WithEvents LB_state_state As Label
    Friend WithEvents BTN_queue_dragdrop As Button
    Friend WithEvents BTN_queue_folder As Button
    Friend WithEvents BTN_queue_file As Button
    Friend WithEvents BTN_clear As Button
    Friend WithEvents FLY_queue As FlowLayoutPanel
    Friend WithEvents FBD_loadvideo As FolderBrowserDialog
    Friend WithEvents PNL_CB_bg As Panel
    Friend WithEvents CB_fluentqueue As CheckBox
    Friend WithEvents LB_CB_fluentqueue As Label
    Friend WithEvents LB_CB_fluentqueue_info As Label
    Friend WithEvents LLB_getclientsecrets As LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BTN_menubar_about As Button
    Friend WithEvents BTN_menubar_googledocs As Button
End Class
