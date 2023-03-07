Imports Newtonsoft.Json
Imports Supabase.Realtime

Public Class RealtimeService

    Private Shared instance As RealtimeService
    Private WithEvents Channel As RealtimeChannel
    Private WithEvents Presence As RealtimePresence(Of UserPresence)
    Private WithEvents Broadcast As RealtimeBroadcast(Of MessageBroadcast)

    Public Event ChannelRegistrationChanged(sender As Object, e As ChannelRegistrationChangedEventArgs)
    Public Event UserChanged(sender As Object, e As UserChangedChangedEventArgs)
    Public Event BroadcastReceived(sender As Object, e As MessageBroadcast)

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property GetInstance As RealtimeService
        Get
            If instance Is Nothing Then instance = New RealtimeService
            Return instance
        End Get
    End Property

    Public Async Function Register(ChannelName As String) As Task(Of Boolean)

        Dim result = Await Task.Run(Async Function()
                                        Try
                                            Dim client = Await SupabaseManager.GetInstance.GetClient
                                            Channel = client.Realtime.Channel(ChannelName)
                                            Presence = Channel.Register(Of UserPresence)(Guid.NewGuid.ToString)
                                            Broadcast = Channel.Register(Of MessageBroadcast)(True, False)

                                            Await Channel.Subscribe

                                            Debug.WriteLine($"Channel state {Channel.State}")

                                            If Not Channel.IsJoined Then
                                                RaiseEvent ChannelRegistrationChanged(Me, New ChannelRegistrationChangedEventArgs(False, ChannelName))
                                                Return False
                                            End If

                                            Debug.WriteLine($"Channel Joined: {ChannelName}")

                                            RaiseEvent ChannelRegistrationChanged(Me, New ChannelRegistrationChangedEventArgs(True, ChannelName))
                                            Presence.Track(UserPresence.GetDefault)

                                        Catch ex As Exception
                                            Channel = Nothing
                                            RaiseEvent ChannelRegistrationChanged(Me, New ChannelRegistrationChangedEventArgs(False, ChannelName))
                                            Return False
                                        End Try

                                        Return True
                                    End Function)
        Return result

    End Function

    Public Async Sub UnRegister(ChannelName As String)

        If Channel Is Nothing Then Return

        Channel.Unsubscribe()

        Dim client = Await SupabaseManager.GetInstance.GetClient
        client.Realtime.Remove(Channel)
        Channel = Nothing

        RaiseEvent ChannelRegistrationChanged(Me, New ChannelRegistrationChangedEventArgs(False, ChannelName))
        Debug.WriteLine($"Channel Unregistered: {ChannelName}")
        instance = Nothing
    End Sub

    Private Sub Presence_OnJoin(sender As Object, e As EventArgs) Handles Presence.OnJoin
        Dim Users = New UserHolder(sender)
        RaiseEvent UserChanged(Me, New UserChangedChangedEventArgs("Join", Users))
    End Sub

    Private Sub Presence_OnLeave(sender As Object, e As EventArgs) Handles Presence.OnLeave
        Dim Users = New UserHolder(sender)
        RaiseEvent UserChanged(Me, New UserChangedChangedEventArgs("Leave", Users))
    End Sub

    Private Sub Presence_OnSync(sender As Object, e As EventArgs) Handles Presence.OnSync
        Dim Users = New UserHolder(sender)
        RaiseEvent UserChanged(Me, New UserChangedChangedEventArgs("Sync", Users))
    End Sub

    Private Sub Broadcast_OnBroadcast(sender As Object, e As EventArgs) Handles Broadcast.OnBroadcast
        RaiseEvent BroadcastReceived(sender, Broadcast.Current)
    End Sub

    Sub BroadcastInstances()
        If Channel Is Nothing Then Return

        Dim i = New InstanceChangedMessage With {.Sender = Environment.MachineName}

        Broadcast.Send("TEST", New MessageBroadcast() With {.[Event] = "TEST", .Payload = New BroadcastMessageHolder(i)})

    End Sub

End Class
