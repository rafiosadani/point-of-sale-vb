Imports System.ComponentModel
Imports System.Data.Odbc
Public Class EditProfile
    Dim DSN = "DSN=db_pos"
    Dim koneksi As OdbcConnection
    Private Sub EditProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
    End Sub

    Private Sub Bersihkan()
        TxtNama.Clear()
        RadioL.Checked = False
        RadioP.Checked = False
        TxtAlamat.Clear()
        TxtTelepon.Clear()
        TxtEmail.Clear()
        TxtPassword.Clear()
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Bersihkan()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Call Bersihkan()
        KaryawanPenjualan.Show()
        Me.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        Dim a As String
        If RadioL.Checked = True Then
            a = "L"
        ElseIf RadioP.Checked = True Then
            a = "P"
        End If
        Dim update As String = "UPDATE [dbo].[karyawan] SET nama_karyawan = '" + TxtNama.Text + "', jk = '" + a + "', alamat = '" + TxtAlamat.Text + "', no_telp = '" + TxtTelepon.Text + "', email = '" + TxtEmail.Text + "' WHERE kode_karyawan = '" + My.Settings.username + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = update,
            .Connection = koneksi
        }
        koneksi.Open()
        cmd.ExecuteNonQuery()
        koneksi.Close()

        Dim update2 As String = "UPDATE [dbo].[user] SET password = '" + TxtPassword.Text + "' WHERE username = '" + My.Settings.username + "'"
        Dim cmd2 As New OdbcCommand With {
            .CommandText = update2,
           .Connection = koneksi
        }
        koneksi.Open()
        cmd2.ExecuteNonQuery()
        koneksi.Close()

        MsgBox("Data berhasil di edit gan..", MsgBoxStyle.Information)
        Bersihkan()
        BtnKembali.Focus()
    End Sub

    'Private Sub EditProfile_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    '    KaryawanPenjualan.Show()
    '    Me.Hide()
    'End Sub
End Class