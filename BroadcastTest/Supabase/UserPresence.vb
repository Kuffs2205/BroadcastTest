Imports Supabase.Realtime.Models

Public Class UserPresence
    Inherits BasePresence

    Public Property LastSeen As Date
    Public Property Email As String
    Public Property Name As String
    Public Property ComputerName As String
    Public Property ID As Guid

    Public Shared Function GetDefault() As UserPresence
        Return New UserPresence() With {.ID = Guid.NewGuid,
                   .ComputerName = Environment.MachineName,
                   .Email = "test@test.com",
                   .LastSeen = Date.Now,
                   .Name = "Joe Bloggs"}
    End Function

    Public Overrides Function ToString() As String
        Return $"{ComputerName} {Email}"
    End Function

End Class
