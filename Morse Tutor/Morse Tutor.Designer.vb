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
        Me.components = New System.ComponentModel.Container()
        Me.display_chr = New System.Windows.Forms.Label()
        Me.start_button = New System.Windows.Forms.Button()
        Me.exit_button = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DonateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.charDisplay_tooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.nudWPMSpeed = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmboFreqHz = New System.Windows.Forms.ComboBox()
        Me.btnCustomSpacing = New System.Windows.Forms.RadioButton()
        Me.btnSpacingRegular = New System.Windows.Forms.RadioButton()
        Me.farnsworthBool = New System.Windows.Forms.RadioButton()
        Me.nudFarnsworth = New System.Windows.Forms.NumericUpDown()
        Me.labelWPM = New System.Windows.Forms.Label()
        Me.labelSpacing = New System.Windows.Forms.Label()
        Me.display_test = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.MyApplicationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.boxLearning = New System.Windows.Forms.GroupBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.udboxRepetitions = New System.Windows.Forms.NumericUpDown()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.label_Timer = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.nudWPMSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudFarnsworth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyApplicationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.boxLearning.SuspendLayout()
        CType(Me.udboxRepetitions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'display_chr
        '
        Me.display_chr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.display_chr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.display_chr.Font = New System.Drawing.Font("Microsoft Sans Serif", 195.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.display_chr.Location = New System.Drawing.Point(634, 43)
        Me.display_chr.Name = "display_chr"
        Me.display_chr.Size = New System.Drawing.Size(301, 298)
        Me.display_chr.TabIndex = 2
        Me.display_chr.Text = "A"
        Me.display_chr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.display_chr.UseMnemonic = False
        '
        'start_button
        '
        Me.start_button.Location = New System.Drawing.Point(12, 427)
        Me.start_button.Name = "start_button"
        Me.start_button.Size = New System.Drawing.Size(75, 23)
        Me.start_button.TabIndex = 3
        Me.start_button.Text = "Start"
        Me.start_button.UseVisualStyleBackColor = True
        '
        'exit_button
        '
        Me.exit_button.Location = New System.Drawing.Point(93, 427)
        Me.exit_button.Name = "exit_button"
        Me.exit_button.Size = New System.Drawing.Size(75, 23)
        Me.exit_button.TabIndex = 4
        Me.exit_button.Text = "Exit"
        Me.exit_button.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.InfoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(984, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem, Me.WebsiteToolStripMenuItem, Me.DonateToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'WebsiteToolStripMenuItem
        '
        Me.WebsiteToolStripMenuItem.Name = "WebsiteToolStripMenuItem"
        Me.WebsiteToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.WebsiteToolStripMenuItem.Text = "Website"
        '
        'DonateToolStripMenuItem
        '
        Me.DonateToolStripMenuItem.Name = "DonateToolStripMenuItem"
        Me.DonateToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.DonateToolStripMenuItem.Text = "Donate $$"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'charDisplay_tooltip
        '
        Me.charDisplay_tooltip.Tag = "This displays a tooltip"
        Me.charDisplay_tooltip.ToolTipTitle = "display_tooltip"
        '
        'nudWPMSpeed
        '
        Me.nudWPMSpeed.Location = New System.Drawing.Point(133, 27)
        Me.nudWPMSpeed.Maximum = New Decimal(New Integer() {70, 0, 0, 0})
        Me.nudWPMSpeed.Minimum = New Decimal(New Integer() {18, 0, 0, 0})
        Me.nudWPMSpeed.Name = "nudWPMSpeed"
        Me.nudWPMSpeed.Size = New System.Drawing.Size(49, 20)
        Me.nudWPMSpeed.TabIndex = 18
        Me.charDisplay_tooltip.SetToolTip(Me.nudWPMSpeed, "Adjust WPM 5 to 50")
        Me.nudWPMSpeed.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmboFreqHz)
        Me.GroupBox1.Controls.Add(Me.btnCustomSpacing)
        Me.GroupBox1.Controls.Add(Me.btnSpacingRegular)
        Me.GroupBox1.Controls.Add(Me.farnsworthBool)
        Me.GroupBox1.Controls.Add(Me.nudFarnsworth)
        Me.GroupBox1.Controls.Add(Me.nudWPMSpeed)
        Me.GroupBox1.Controls.Add(Me.labelWPM)
        Me.GroupBox1.Controls.Add(Me.labelSpacing)
        Me.GroupBox1.Location = New System.Drawing.Point(397, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 249)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Morse Properties"
        Me.charDisplay_tooltip.SetToolTip(Me.GroupBox1, "Playback speed settings")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "CW Freq in Hz"
        '
        'cmboFreqHz
        '
        Me.cmboFreqHz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboFreqHz.DropDownWidth = 80
        Me.cmboFreqHz.FormattingEnabled = True
        Me.cmboFreqHz.Items.AddRange(New Object() {"500", "600", "700", "800", "1000", "1200"})
        Me.cmboFreqHz.Location = New System.Drawing.Point(136, 160)
        Me.cmboFreqHz.Name = "cmboFreqHz"
        Me.cmboFreqHz.Size = New System.Drawing.Size(49, 21)
        Me.cmboFreqHz.TabIndex = 26
        '
        'btnCustomSpacing
        '
        Me.btnCustomSpacing.AutoSize = True
        Me.btnCustomSpacing.Location = New System.Drawing.Point(9, 108)
        Me.btnCustomSpacing.Name = "btnCustomSpacing"
        Me.btnCustomSpacing.Size = New System.Drawing.Size(121, 17)
        Me.btnCustomSpacing.TabIndex = 25
        Me.btnCustomSpacing.Text = "Custom CW spacing"
        Me.btnCustomSpacing.UseVisualStyleBackColor = True
        '
        'btnSpacingRegular
        '
        Me.btnSpacingRegular.AutoSize = True
        Me.btnSpacingRegular.Checked = True
        Me.btnSpacingRegular.Location = New System.Drawing.Point(9, 62)
        Me.btnSpacingRegular.Name = "btnSpacingRegular"
        Me.btnSpacingRegular.Size = New System.Drawing.Size(131, 17)
        Me.btnSpacingRegular.TabIndex = 24
        Me.btnSpacingRegular.TabStop = True
        Me.btnSpacingRegular.Text = "Standard CW Spacing"
        Me.btnSpacingRegular.UseVisualStyleBackColor = True
        '
        'farnsworthBool
        '
        Me.farnsworthBool.AutoSize = True
        Me.farnsworthBool.Location = New System.Drawing.Point(9, 85)
        Me.farnsworthBool.Name = "farnsworthBool"
        Me.farnsworthBool.Size = New System.Drawing.Size(119, 17)
        Me.farnsworthBool.TabIndex = 23
        Me.farnsworthBool.Text = "Farnsworth Spacing"
        Me.charDisplay_tooltip.SetToolTip(Me.farnsworthBool, "Farnsworth Spacing ON/OFF")
        Me.farnsworthBool.UseVisualStyleBackColor = True
        '
        'nudFarnsworth
        '
        Me.nudFarnsworth.Location = New System.Drawing.Point(136, 128)
        Me.nudFarnsworth.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudFarnsworth.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudFarnsworth.Name = "nudFarnsworth"
        Me.nudFarnsworth.Size = New System.Drawing.Size(49, 20)
        Me.nudFarnsworth.TabIndex = 22
        Me.charDisplay_tooltip.SetToolTip(Me.nudFarnsworth, "Adjust Farnsworth character spacing 5 to 50 WPM")
        Me.nudFarnsworth.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'labelWPM
        '
        Me.labelWPM.AutoSize = True
        Me.labelWPM.Location = New System.Drawing.Point(6, 30)
        Me.labelWPM.Name = "labelWPM"
        Me.labelWPM.Size = New System.Drawing.Size(68, 13)
        Me.labelWPM.TabIndex = 19
        Me.labelWPM.Text = "WPM Speed"
        '
        'labelSpacing
        '
        Me.labelSpacing.AutoSize = True
        Me.labelSpacing.Location = New System.Drawing.Point(9, 130)
        Me.labelSpacing.Name = "labelSpacing"
        Me.labelSpacing.Size = New System.Drawing.Size(73, 13)
        Me.labelSpacing.TabIndex = 20
        Me.labelSpacing.Text = "Spacing Type"
        '
        'display_test
        '
        Me.display_test.AutoSize = True
        Me.display_test.Font = New System.Drawing.Font("Microsoft Sans Serif", 64.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.display_test.Location = New System.Drawing.Point(737, 353)
        Me.display_test.Name = "display_test"
        Me.display_test.Size = New System.Drawing.Size(95, 97)
        Me.display_test.TabIndex = 6
        Me.display_test.Text = ".-"
        Me.display_test.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.charDisplay_tooltip.SetToolTip(Me.display_test, "Morse Code is Displayed")
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 298)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(211, 75)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Test Audio Playback"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.ForeColor = System.Drawing.Color.Red
        Me.Button5.Location = New System.Drawing.Point(114, 353)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(94, 40)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "Write Stream as Wave"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button6
        '
        Me.Button6.ForeColor = System.Drawing.Color.Red
        Me.Button6.Location = New System.Drawing.Point(12, 298)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(96, 43)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "Test String Wave"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button7
        '
        Me.Button7.ForeColor = System.Drawing.Color.Red
        Me.Button7.Location = New System.Drawing.Point(214, 353)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(106, 40)
        Me.Button7.TabIndex = 15
        Me.Button7.Text = "Add Wave header and playback"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Button8
        '
        Me.Button8.ForeColor = System.Drawing.Color.Red
        Me.Button8.Location = New System.Drawing.Point(117, 298)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(203, 43)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "Strip Header, Combine PCM, Create Wave Header, PLayback"
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'MyApplicationBindingSource
        '
        Me.MyApplicationBindingSource.DataSource = GetType(Morse_Tutor.My.MyApplication)
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(12, 353)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 40)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Test Character Wave"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'boxLearning
        '
        Me.boxLearning.Controls.Add(Me.CheckBox3)
        Me.boxLearning.Controls.Add(Me.CheckBox2)
        Me.boxLearning.Controls.Add(Me.CheckBox1)
        Me.boxLearning.Controls.Add(Me.Label2)
        Me.boxLearning.Controls.Add(Me.udboxRepetitions)
        Me.boxLearning.Location = New System.Drawing.Point(13, 43)
        Me.boxLearning.Name = "boxLearning"
        Me.boxLearning.Size = New System.Drawing.Size(378, 249)
        Me.boxLearning.TabIndex = 22
        Me.boxLearning.TabStop = False
        Me.boxLearning.Text = "Learning Settings"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(19, 109)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(76, 17)
        Me.CheckBox3.TabIndex = 4
        Me.CheckBox3.Text = "H O N V C"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(19, 86)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(72, 17)
        Me.CheckBox2.TabIndex = 3
        Me.CheckBox2.Text = "S L U Q J"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(19, 62)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(82, 17)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "5 0 E T A R"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Character Repetitions"
        '
        'udboxRepetitions
        '
        Me.udboxRepetitions.Location = New System.Drawing.Point(151, 31)
        Me.udboxRepetitions.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.udboxRepetitions.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udboxRepetitions.Name = "udboxRepetitions"
        Me.udboxRepetitions.Size = New System.Drawing.Size(63, 20)
        Me.udboxRepetitions.TabIndex = 0
        Me.udboxRepetitions.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label_Timer
        '
        Me.label_Timer.AutoSize = True
        Me.label_Timer.Font = New System.Drawing.Font("Comic Sans MS", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Timer.Location = New System.Drawing.Point(191, 408)
        Me.label_Timer.Name = "label_Timer"
        Me.label_Timer.Size = New System.Drawing.Size(94, 45)
        Me.label_Timer.TabIndex = 23
        Me.label_Timer.Text = "5:00"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(522, 298)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 75)
        Me.Button3.TabIndex = 24
        Me.Button3.Text = "Check Word Wave"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 462)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.label_Timer)
        Me.Controls.Add(Me.boxLearning)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.display_test)
        Me.Controls.Add(Me.exit_button)
        Me.Controls.Add(Me.start_button)
        Me.Controls.Add(Me.display_chr)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Morse Learner V 0.30alpha"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.nudWPMSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudFarnsworth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyApplicationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.boxLearning.ResumeLayout(False)
        Me.boxLearning.PerformLayout()
        CType(Me.udboxRepetitions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents display_chr As System.Windows.Forms.Label
    Friend WithEvents start_button As System.Windows.Forms.Button
    Friend WithEvents exit_button As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebsiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DonateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents charDisplay_tooltip As System.Windows.Forms.ToolTip
    Friend WithEvents display_test As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MyApplicationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents nudWPMSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents labelWPM As System.Windows.Forms.Label
    Friend WithEvents labelSpacing As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents nudFarnsworth As System.Windows.Forms.NumericUpDown
    Friend WithEvents farnsworthBool As System.Windows.Forms.RadioButton
    Friend WithEvents btnCustomSpacing As System.Windows.Forms.RadioButton
    Friend WithEvents btnSpacingRegular As System.Windows.Forms.RadioButton
    Friend WithEvents cmboFreqHz As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents boxLearning As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents udboxRepetitions As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents label_Timer As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
