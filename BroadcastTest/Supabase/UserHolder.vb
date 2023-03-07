Imports Supabase.Realtime

Public Class UserHolder

    Public Sub New(itm As RealtimePresence(Of UserPresence))
        itm.CurrentState.Values.ToList.ForEach(Sub(a) CurrentUsers.AddRange(a))
        itm.LastState.Values.ToList.ForEach(Sub(a) PreviousUsers.AddRange(a))
    End Sub

    Public ReadOnly Property CurrentUsers As New List(Of UserPresence)
    Public ReadOnly Property PreviousUsers As New List(Of UserPresence)

End Class
