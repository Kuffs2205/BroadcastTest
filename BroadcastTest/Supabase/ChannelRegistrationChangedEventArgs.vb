
Public Class ChannelRegistrationChangedEventArgs
    Inherits EventArgs

    Public ReadOnly Property Registered As Boolean
    Public ReadOnly Property ChannelName As String

    Public Sub New(registered As Boolean, channelName As String)
        Me.Registered = registered
        Me.ChannelName = channelName
    End Sub
End Class
