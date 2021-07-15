Imports System.Data.Odbc
Public Class FormUser

    Dim DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    Dim TblUser As New DataTable("Table")

    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = TblUser
        CreateTable()
        LoadTable()
        LebarData()
    End Sub

    Private Sub Awal()

    End Sub

    Private Sub CreateTable()
        TblUser.Columns.Add("Kode Karyawan", Type.GetType("System.String"))
        TblUser.Columns.Add("Nama Karyawan", Type.GetType("System.String"))
        TblUser.Columns.Add("Username", Type.GetType("System.String"))
        TblUser.Columns.Add("Password", Type.GetType("System.String"))
        TblUser.Columns.Add("Role", Type.GetType("System.String"))
        TblUser.Columns.Add("Status", Type.GetType("System.String"))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblTanggal.Text = Format(Now, "dddd, dd MMMM yyyy")
        LblJam.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub LoadTable()
        Dim sql As String = "SELECT * FROM [dbo].[user]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim DR As OdbcDataReader
        DR = cmd.ExecuteReader
        While DR.Read
            Dim sql2 As String = "SELECT nama_karyawan FROM [dbo].[karyawan] WHERE kode_karyawan = '" + DR(2).ToString + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim DR2 As OdbcDataReader
            DR2 = cmd2.ExecuteReader
            While DR2.Read
                Dim i As String
                If DR(4) = 1 Then
                    i = "Pembelian"
                ElseIf DR(4) = 2 Then
                    i = "Penjualan"
                End If
                TblUser.Rows.Add(DR(1).ToString, DR2(0).ToString, DR(2).ToString, DR(3).ToString, i, DR(5).ToString)
            End While
            koneksi2.Close()
        End While
        DataGridView1.Refresh()
        koneksi.Close()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub LebarData()
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).Width = 136
        DataGridView1.Columns(2).Width = 130
    End Sub
End Class