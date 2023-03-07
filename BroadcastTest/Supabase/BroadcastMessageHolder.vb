
Public Class BroadcastMessageHolder

    Public Const Key As String = "BroadcastMessage"

    Public Property InstanceChanged As InstanceChangedMessage

    Public Sub New(ByVal i As InstanceChangedMessage)
        InstanceChanged = i
    End Sub

    Public Sub New()

    End Sub

End Class
