<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.bt_1 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.bt_2 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.lb_7 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.tb_2 = New Bunifu.Framework.UI.BunifuMetroTextbox()
        Me.BunifuCustomLabel1 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.tb_1 = New Bunifu.Framework.UI.BunifuMetroTextbox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.l1 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.t1 = New Bunifu.Framework.UI.BunifuMetroTextbox()
        Me.l2 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.t2 = New Bunifu.Framework.UI.BunifuMetroTextbox()
        Me.BunifuCustomLabel2 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BunifuCustomLabel3 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bt_1
        '
        Me.bt_1.ActiveBorderThickness = 1
        Me.bt_1.ActiveCornerRadius = 1
        Me.bt_1.ActiveFillColor = System.Drawing.Color.Maroon
        Me.bt_1.ActiveForecolor = System.Drawing.Color.White
        Me.bt_1.ActiveLineColor = System.Drawing.Color.Maroon
        Me.bt_1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bt_1.AutoScroll = True
        Me.bt_1.BackColor = System.Drawing.Color.White
        Me.bt_1.BackgroundImage = CType(resources.GetObject("bt_1.BackgroundImage"), System.Drawing.Image)
        Me.bt_1.ButtonText = "LOGIN"
        Me.bt_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_1.ForeColor = System.Drawing.Color.White
        Me.bt_1.IdleBorderThickness = 1
        Me.bt_1.IdleCornerRadius = 1
        Me.bt_1.IdleFillColor = System.Drawing.Color.Maroon
        Me.bt_1.IdleForecolor = System.Drawing.Color.White
        Me.bt_1.IdleLineColor = System.Drawing.Color.Maroon
        Me.bt_1.Location = New System.Drawing.Point(662, 485)
        Me.bt_1.Margin = New System.Windows.Forms.Padding(8)
        Me.bt_1.Name = "bt_1"
        Me.bt_1.Size = New System.Drawing.Size(160, 50)
        Me.bt_1.TabIndex = 4
        Me.bt_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bt_2
        '
        Me.bt_2.ActiveBorderThickness = 1
        Me.bt_2.ActiveCornerRadius = 1
        Me.bt_2.ActiveFillColor = System.Drawing.Color.White
        Me.bt_2.ActiveForecolor = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.bt_2.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.bt_2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bt_2.AutoScroll = True
        Me.bt_2.BackColor = System.Drawing.Color.White
        Me.bt_2.BackgroundImage = CType(resources.GetObject("bt_2.BackgroundImage"), System.Drawing.Image)
        Me.bt_2.ButtonText = "CLEAR"
        Me.bt_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.bt_2.IdleBorderThickness = 1
        Me.bt_2.IdleCornerRadius = 1
        Me.bt_2.IdleFillColor = System.Drawing.Color.White
        Me.bt_2.IdleForecolor = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.bt_2.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.bt_2.Location = New System.Drawing.Point(535, 485)
        Me.bt_2.Margin = New System.Windows.Forms.Padding(8)
        Me.bt_2.Name = "bt_2"
        Me.bt_2.Size = New System.Drawing.Size(115, 50)
        Me.bt_2.TabIndex = 5
        Me.bt_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb_7
        '
        Me.lb_7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lb_7.AutoSize = True
        Me.lb_7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_7.ForeColor = System.Drawing.Color.Black
        Me.lb_7.Location = New System.Drawing.Point(512, 396)
        Me.lb_7.Name = "lb_7"
        Me.lb_7.Size = New System.Drawing.Size(69, 17)
        Me.lb_7.TabIndex = 31
        Me.lb_7.Text = "Password"
        '
        'tb_2
        '
        Me.tb_2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tb_2.BorderColorFocused = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.tb_2.BorderColorIdle = System.Drawing.Color.Gray
        Me.tb_2.BorderColorMouseHover = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.tb_2.BorderThickness = 1
        Me.tb_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tb_2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_2.ForeColor = System.Drawing.Color.Black
        Me.tb_2.isPassword = True
        Me.tb_2.Location = New System.Drawing.Point(511, 418)
        Me.tb_2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.tb_2.Name = "tb_2"
        Me.tb_2.Size = New System.Drawing.Size(340, 36)
        Me.tb_2.TabIndex = 2
        Me.tb_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'BunifuCustomLabel1
        '
        Me.BunifuCustomLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BunifuCustomLabel1.AutoSize = True
        Me.BunifuCustomLabel1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuCustomLabel1.ForeColor = System.Drawing.Color.Black
        Me.BunifuCustomLabel1.Location = New System.Drawing.Point(511, 324)
        Me.BunifuCustomLabel1.Name = "BunifuCustomLabel1"
        Me.BunifuCustomLabel1.Size = New System.Drawing.Size(43, 17)
        Me.BunifuCustomLabel1.TabIndex = 86
        Me.BunifuCustomLabel1.Text = "Email"
        '
        'tb_1
        '
        Me.tb_1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tb_1.BorderColorFocused = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.tb_1.BorderColorIdle = System.Drawing.Color.Gray
        Me.tb_1.BorderColorMouseHover = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.tb_1.BorderThickness = 1
        Me.tb_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tb_1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_1.ForeColor = System.Drawing.Color.Black
        Me.tb_1.isPassword = False
        Me.tb_1.Location = New System.Drawing.Point(511, 342)
        Me.tb_1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.tb_1.Name = "tb_1"
        Me.tb_1.Size = New System.Drawing.Size(340, 36)
        Me.tb_1.TabIndex = 1
        Me.tb_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1361, 156)
        Me.Panel1.TabIndex = 87
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(1138, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 29)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "01-Jan-2020"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(1092, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 68)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "00:00:00"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(42, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(8)
        Me.PictureBox1.Size = New System.Drawing.Size(168, 146)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'l1
        '
        Me.l1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.l1.AutoSize = True
        Me.l1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l1.ForeColor = System.Drawing.Color.Black
        Me.l1.Location = New System.Drawing.Point(511, 593)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(46, 17)
        Me.l1.TabIndex = 151
        Me.l1.Text = "Server"
        Me.l1.Visible = False
        '
        't1
        '
        Me.t1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.t1.BorderColorFocused = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.t1.BorderColorIdle = System.Drawing.Color.Gray
        Me.t1.BorderColorMouseHover = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.t1.BorderThickness = 1
        Me.t1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.t1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t1.ForeColor = System.Drawing.Color.Black
        Me.t1.isPassword = False
        Me.t1.Location = New System.Drawing.Point(511, 611)
        Me.t1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(162, 36)
        Me.t1.TabIndex = 150
        Me.t1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.t1.Visible = False
        '
        'l2
        '
        Me.l2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.l2.AutoSize = True
        Me.l2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l2.ForeColor = System.Drawing.Color.Black
        Me.l2.Location = New System.Drawing.Point(689, 593)
        Me.l2.Name = "l2"
        Me.l2.Size = New System.Drawing.Size(33, 17)
        Me.l2.TabIndex = 153
        Me.l2.Text = "User"
        Me.l2.Visible = False
        '
        't2
        '
        Me.t2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.t2.BorderColorFocused = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.t2.BorderColorIdle = System.Drawing.Color.Gray
        Me.t2.BorderColorMouseHover = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.t2.BorderThickness = 1
        Me.t2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.t2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t2.ForeColor = System.Drawing.Color.Black
        Me.t2.isPassword = False
        Me.t2.Location = New System.Drawing.Point(689, 611)
        Me.t2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(162, 36)
        Me.t2.TabIndex = 152
        Me.t2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.t2.Visible = False
        '
        'BunifuCustomLabel2
        '
        Me.BunifuCustomLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BunifuCustomLabel2.AutoSize = True
        Me.BunifuCustomLabel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuCustomLabel2.Font = New System.Drawing.Font("Agency FB", 21.25!)
        Me.BunifuCustomLabel2.ForeColor = System.Drawing.Color.Gray
        Me.BunifuCustomLabel2.Location = New System.Drawing.Point(64, 728)
        Me.BunifuCustomLabel2.Name = "BunifuCustomLabel2"
        Me.BunifuCustomLabel2.Size = New System.Drawing.Size(115, 34)
        Me.BunifuCustomLabel2.TabIndex = 154
        Me.BunifuCustomLabel2.Text = "Instructions"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Location = New System.Drawing.Point(1240, 161)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(123, 38)
        Me.Panel2.TabIndex = 155
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1218, 728)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(103, 33)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 155
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(210, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(369, 29)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "India's Fastest Growing Assessment"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(205, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 29)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = " Olympiad"
        '
        'BunifuCustomLabel3
        '
        Me.BunifuCustomLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BunifuCustomLabel3.AutoSize = True
        Me.BunifuCustomLabel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuCustomLabel3.Font = New System.Drawing.Font("Agency FB", 14.0!)
        Me.BunifuCustomLabel3.ForeColor = System.Drawing.Color.Gray
        Me.BunifuCustomLabel3.Location = New System.Drawing.Point(1227, 700)
        Me.BunifuCustomLabel3.Name = "BunifuCustomLabel3"
        Me.BunifuCustomLabel3.Size = New System.Drawing.Size(89, 24)
        Me.BunifuCustomLabel3.TabIndex = 156
        Me.BunifuCustomLabel3.Text = "Organized By:"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1365, 784)
        Me.Controls.Add(Me.BunifuCustomLabel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.BunifuCustomLabel2)
        Me.Controls.Add(Me.l2)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.l1)
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BunifuCustomLabel1)
        Me.Controls.Add(Me.tb_1)
        Me.Controls.Add(Me.bt_1)
        Me.Controls.Add(Me.bt_2)
        Me.Controls.Add(Me.lb_7)
        Me.Controls.Add(Me.tb_2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_1 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents bt_2 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents lb_7 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents tb_2 As Bunifu.Framework.UI.BunifuMetroTextbox
    Friend WithEvents BunifuCustomLabel1 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents tb_1 As Bunifu.Framework.UI.BunifuMetroTextbox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents l1 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents t1 As Bunifu.Framework.UI.BunifuMetroTextbox
    Friend WithEvents l2 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents t2 As Bunifu.Framework.UI.BunifuMetroTextbox
    Friend WithEvents BunifuCustomLabel2 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BunifuCustomLabel3 As Bunifu.Framework.UI.BunifuCustomLabel
End Class
