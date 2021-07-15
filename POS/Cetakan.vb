Imports System.ComponentModel

Public Class Cetakan
    Private Sub Cetakan_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub Cetakan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class