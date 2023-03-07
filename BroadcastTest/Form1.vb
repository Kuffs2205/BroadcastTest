Imports System.Threading

Public Class Form1

    Private WithEvents RTS As RealtimeService
    Private context As SynchronizationContext

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RTS = RealtimeService.GetInstance
        context = SynchronizationContext.Current
        If My.Settings.Channel = "" Then My.Settings.Channel = Guid.NewGuid.ToString
        TxtChannelName.Text = My.Settings.Channel
        SetButtons(False)
    End Sub

    Private Async Sub BtnJoin_Click(sender As Object, e As EventArgs) Handles BtnJoin.Click
        BtnJoin.Enabled = False
        Await RTS.Register(My.Settings.Channel)
    End Sub

    Private Sub RTS_ChannelRegistrationChanged(sender As Object, e As ChannelRegistrationChangedEventArgs) Handles RTS.ChannelRegistrationChanged

        context.Post(Sub()
                         SetButtons(e.Registered)
                         Log($"Register:{e.ChannelName} {If(e.Registered, "Online", "Offline")}")
                     End Sub, Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnBroadcast.Click
        RTS.BroadcastInstances()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnLeave.Click
        RTS.UnRegister(My.Settings.Channel)
        SetButtons(False)
    End Sub

    Private Sub Log(txt As String)
        context.Post(Sub()
                         TextBox1.Text = $"{TextBox1.Text}{vbCrLf}{txt}"
                         TextBox1.Select(TextBox1.Text.Length, 0)
                         TextBox1.ScrollToCaret()
                     End Sub, Nothing)
    End Sub

    Private Sub RTS_UserChanged(sender As Object, e As UserChangedChangedEventArgs) Handles RTS.UserChanged
        Dim Current = String.Join(",", e.Users.CurrentUsers.Select(Function(a) a.ComputerName))
        Log($"Current Users: {e.Type} -  {Current}")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TxtChannelName.TextChanged
        My.Settings.Channel = TxtChannelName.Text
        My.Settings.Save()
        Log($"New Channel: {My.Settings.Channel}")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnChangeChannel.Click, BtnChangeChannel.Click
        TxtChannelName.Text = Guid.NewGuid.ToString
    End Sub

    Private Sub RTS_BroadcastReceived(sender As Object, e As MessageBroadcast) Handles RTS.BroadcastReceived
        Log($"Broadcast: {e.Payload.InstanceChanged.Sender}")
    End Sub

    Private Sub SetButtons(Connected As Boolean)
        BtnJoin.Enabled = Not Connected
        BtnLeave.Enabled = Connected
        BtnBroadcast.Enabled = Connected
        BtnChangeChannel.Enabled = Not Connected
        TxtChannelName.Enabled = Not Connected
    End Sub

End Class
