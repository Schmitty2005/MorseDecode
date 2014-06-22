<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.about_label = New System.Windows.Forms.Label()
        Me.close_button = New System.Windows.Forms.Button()
        Me.about_title = New System.Windows.Forms.Label()
        Me.about_link = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'about_label
        '
        Me.about_label.AutoSize = True
        Me.about_label.Location = New System.Drawing.Point(32, 47)
        Me.about_label.Name = "about_label"
        Me.about_label.Size = New System.Drawing.Size(390, 182)
        Me.about_label.TabIndex = 0
        Me.about_label.Text = resources.GetString("about_label.Text")
        Me.about_label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'close_button
        '
        Me.close_button.Location = New System.Drawing.Point(189, 230)
        Me.close_button.Name = "close_button"
        Me.close_button.Size = New System.Drawing.Size(75, 23)
        Me.close_button.TabIndex = 1
        Me.close_button.Text = "Close"
        Me.close_button.UseVisualStyleBackColor = True
        '
        'about_title
        '
        Me.about_title.AutoSize = True
        Me.about_title.Font = New System.Drawing.Font("Stencil", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.about_title.Location = New System.Drawing.Point(28, 9)
        Me.about_title.Name = "about_title"
        Me.about_title.Size = New System.Drawing.Size(135, 38)
        Me.about_title.TabIndex = 2
        Me.about_title.Text = "ABOUT:"
        '
        'about_link
        '
        Me.about_link.AutoSize = True
        Me.about_link.Location = New System.Drawing.Point(355, 9)
        Me.about_link.Name = "about_link"
        Me.about_link.Size = New System.Drawing.Size(93, 13)
        Me.about_link.TabIndex = 3
        Me.about_link.TabStop = True
        Me.about_link.Text = "Authors Webpage"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 265)
        Me.Controls.Add(Me.about_link)
        Me.Controls.Add(Me.about_title)
        Me.Controls.Add(Me.close_button)
        Me.Controls.Add(Me.about_label)
        Me.Name = "About"
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents about_label As System.Windows.Forms.Label
    Friend WithEvents close_button As System.Windows.Forms.Button
    Friend WithEvents about_title As System.Windows.Forms.Label
    Friend WithEvents about_link As System.Windows.Forms.LinkLabel
End Class
