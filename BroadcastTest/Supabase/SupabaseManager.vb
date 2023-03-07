Imports Websocket.Client.Logging

Public Class SupabaseManager

    Private Shared instance As SupabaseManager
    Private ReadOnly Property Client As Supabase.Client

    Private Const Url As String = "https://yoururl.supabase.co"
    Private Const Key As String = "enter your key"

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property GetInstance As SupabaseManager
        Get
            If instance Is Nothing Then instance = New SupabaseManager
            Return instance
        End Get
    End Property

    Public Async Function GetClient() As Task(Of Supabase.Client)
        Try

            If Client IsNot Nothing Then Return Client

            Dim c = New Supabase.Client(Url, Key, New Supabase.SupabaseOptions With {.AutoConnectRealtime = True})

            Dim x = Await c.InitializeAsync

            _Client = c
            Return _Client
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return Client IsNot Nothing
        End Get
    End Property

    Public Sub Disconnect()
        _Client = Nothing
    End Sub

End Class
