Imports Npgsql
Imports System.Configuration 

Public Class DatabaseHelper
    ' Variable to hold the connection string internally
    Private connectionString As String

    ' Constructor: Runs automatically when you create a New DatabaseHelper()
    Public Sub New()
        ' Fetch the connection string from App.config by its name
        connectionString = ConfigurationManager.ConnectionStrings("UniversityEventsDB").ConnectionString
    End Sub

    ' Method to create and return a new database connection object
    Public Function GetConnection() As NpgsqlConnection
        ' Create a new connection using the string we loaded earlier
        Return New NpgsqlConnection(connectionString)
    End Function

    ' Test method to verify database connectivity
    Public Function TestConnection() As Boolean
        Try
            Using conn As NpgsqlConnection = GetConnection()
                conn.Open() ' Attempt to open the connection
                Return True ' If we get here, it worked!
            End Using ' "Using" automatically closes the connection here
        Catch ex As Exception
            ' If it fails, print the error to the Output window
            System.Diagnostics.Debug.WriteLine("Connection Error: " & ex.Message)
            Return False
        End Try
    End Function

End Class
