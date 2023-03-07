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
        BtnJoin = New Button()
        BtnBroadcast = New Button()
        BtnLeave = New Button()
        TextBox1 = New TextBox()
        TxtChannelName = New TextBox()
        BtnChangeChannel = New Button()
        SuspendLayout()
        ' 
        ' BtnJoin
        ' 
        BtnJoin.Location = New Point(34, 34)
        BtnJoin.Name = "BtnJoin"
        BtnJoin.Size = New Size(169, 46)
        BtnJoin.TabIndex = 0
        BtnJoin.Text = "Join"
        BtnJoin.UseVisualStyleBackColor = True
        ' 
        ' BtnBroadcast
        ' 
        BtnBroadcast.Enabled = False
        BtnBroadcast.Location = New Point(237, 34)
        BtnBroadcast.Name = "BtnBroadcast"
        BtnBroadcast.Size = New Size(169, 46)
        BtnBroadcast.TabIndex = 2
        BtnBroadcast.Text = "Broadcast"
        BtnBroadcast.UseVisualStyleBackColor = True
        ' 
        ' BtnLeave
        ' 
        BtnLeave.Enabled = False
        BtnLeave.Location = New Point(34, 86)
        BtnLeave.Name = "BtnLeave"
        BtnLeave.Size = New Size(169, 46)
        BtnLeave.TabIndex = 3
        BtnLeave.Text = "Leave"
        BtnLeave.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TextBox1.Location = New Point(12, 150)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(586, 198)
        TextBox1.TabIndex = 4
        ' 
        ' TxtChannelName
        ' 
        TxtChannelName.Enabled = False
        TxtChannelName.Location = New Point(237, 86)
        TxtChannelName.Name = "TxtChannelName"
        TxtChannelName.Size = New Size(344, 23)
        TxtChannelName.TabIndex = 5
        ' 
        ' BtnChangeChannel
        ' 
        BtnChangeChannel.Enabled = False
        BtnChangeChannel.Location = New Point(412, 34)
        BtnChangeChannel.Name = "BtnChangeChannel"
        BtnChangeChannel.Size = New Size(169, 46)
        BtnChangeChannel.TabIndex = 6
        BtnChangeChannel.Text = "Change Channel"
        BtnChangeChannel.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(610, 360)
        Controls.Add(BtnChangeChannel)
        Controls.Add(TxtChannelName)
        Controls.Add(TextBox1)
        Controls.Add(BtnLeave)
        Controls.Add(BtnBroadcast)
        Controls.Add(BtnJoin)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnJoin As Button
    Friend WithEvents BtnBroadcast As Button
    Friend WithEvents BtnLeave As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TxtChannelName As TextBox
    Friend WithEvents BtnChangeChannel As Button
End Class
