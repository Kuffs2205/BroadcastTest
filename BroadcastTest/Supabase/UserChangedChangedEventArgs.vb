
Public Class UserChangedChangedEventArgs
    Inherits EventArgs

    Public ReadOnly Property Users As UserHolder
    Public ReadOnly Property Type As String

    Public Sub New(Type As String, Users As UserHolder)
        Me.Type = Type
        Me.Users = Users
    End Sub
End Class
