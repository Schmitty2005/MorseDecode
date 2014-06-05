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
        Me.display_test = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.MyApplicationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.MyApplicationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'display_chr
        '
        Me.display_chr.AutoSize = True
        Me.display_chr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.display_chr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.display_chr.Font = New System.Drawing.Font("Monospac821 BT", 195.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.display_chr.Location = New System.Drawing.Point(627, 43)
        Me.display_chr.Name = "display_chr"
        Me.display_chr.Size = New System.Drawing.Size(291, 315)
        Me.display_chr.TabIndex = 2
        Me.display_chr.Text = "A"
        Me.display_chr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.display_chr.UseMnemonic = False
        '
        'start_button
        '
        Me.start_button.Location = New System.Drawing.Point(59, 242)
        Me.start_button.Name = "start_button"
        Me.start_button.Size = New System.Drawing.Size(75, 23)
        Me.start_button.TabIndex = 3
        Me.start_button.Text = "Start"
        Me.start_button.UseVisualStyleBackColor = True
        '
        'exit_button
        '
        Me.exit_button.Location = New System.Drawing.Point(521, 335)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(942, 24)
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
        'display_test
        '
        Me.display_test.AutoSize = True
        Me.display_test.Font = New System.Drawing.Font("Microsoft Sans Serif", 64.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.display_test.Location = New System.Drawing.Point(42, 27)
        Me.display_test.Name = "display_test"
        Me.display_test.Size = New System.Drawing.Size(335, 97)
        Me.display_test.TabIndex = 6
        Me.display_test.Text = "Dah-Dit"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(271, 242)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 59)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Test Audio Playback"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(190, 244)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 54)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "Write Stream as Wave"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(59, 128)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(106, 95)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "Strip Wave Header"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(171, 127)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(94, 95)
        Me.Button7.TabIndex = 15
        Me.Button7.Text = "Add Wave header and playback"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(271, 128)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(200, 95)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "Strip Header, Combine PCM, Create Wave Header, PLayback"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'MyApplicationBindingSource
        '
        Me.MyApplicationBindingSource.DataSource = GetType(Morse_Tutor.My.MyApplication)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 396)
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
        Me.Text = "Morse Learner V 0.01alpha"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.MyApplicationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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

End Class
