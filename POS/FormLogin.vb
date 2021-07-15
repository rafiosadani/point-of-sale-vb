Imports System.Data.Odbc
Public Class FormLogin

    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As New OdbcConnection

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        If TxtUsername.Text = "" Or TxtPassword.Text = "" Then
            MsgBox("Username dan Password tidak boleh kosong!", MsgBoxStyle.Exclamation)
        Else
            Dim cmd As New OdbcCommand
            Dim q = "SELECT * FROM [dbo].[user] WHERE username = '" + TxtUsername.Text + "' AND password = '" + TxtPassword.Text + "'"
            cmd.CommandText = q
            cmd.Connection = koneksi
            koneksi.Open()
            Dim dr As OdbcDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                My.Settings.username = dr(2).ToString
                Select Case dr("role")
                    Case 0
                        Dim sql As String = "SELECT * FROM [dbo].[karyawan] WHERE kode_karyawan = '" + dr(2).ToString + "' AND status = 1"
                        Dim cmd1 As New OdbcCommand With {
                            .CommandText = sql,
                            .Connection = koneksi2
                        }
                        koneksi2.Open()
                        Dim dr2 As OdbcDataReader
                        dr2 = cmd1.ExecuteReader
                        If dr2.Read Then
                            My.Settings.name = dr2(2).ToString
                            MenuUtama.Panel1.Text = dr2.Item("kode_karyawan")
                            MenuUtama.Panel2.Text = dr2.Item("nama_karyawan")
                            Dim i As String
                            If dr(4) = 0 Then
                                i = "Admin"
                            ElseIf dr(4) = 1 Then
                                i = "Pembelian"
                            ElseIf dr(4) = 2 Then
                                i = "Penjualan"
                            End If
                            MenuUtama.Panel3.Text = i
                            MenuUtama.Panel4.Text = Format(Now, "dd MMMM yyyy")
                        End If
                        koneksi2.Close()
                        My.Settings.Save()
                        TxtUsername.Clear()
                        TxtPassword.Clear()
                        CheckBox1.Checked = False
                        TxtUsername.Select()
                        MsgBox("Anda berhasil login.", MsgBoxStyle.Information)
                        MenuUtama.Show()
                        Me.Hide()
                    Case 1
                        Dim sql2 As String = "SELECT * FROM [dbo].[karyawan] WHERE kode_karyawan = '" + dr(2).ToString + "' AND status = 1"
                        Dim cmd2 As New OdbcCommand With {
                            .CommandText = sql2,
                            .Connection = koneksi2
                        }
                        koneksi2.Open()
                        Dim dr2 As OdbcDataReader
                        dr2 = cmd2.ExecuteReader
                        If dr2.Read Then
                            My.Settings.name = dr2(2).ToString
                        End If
                        koneksi2.Close()
                        My.Settings.Save()
                        TxtUsername.Text = ""
                        TxtPassword.Text = ""
                        CheckBox1.Checked = False
                        TxtUsername.Select()
                        MsgBox("Anda berhasil Login.", MsgBoxStyle.Information)
                        KaryawanPembelian.Show()
                        Me.Hide()
                    Case 2
                        Dim sql3 As String = "SELECT * FROM [dbo].[karyawan] WHERE kode_karyawan = '" + dr(2).ToString + "' AND status = 1"
                        Dim cmd3 As New OdbcCommand With {
                            .CommandText = sql3,
                            .Connection = koneksi2
                        }
                        koneksi2.Open()
                        Dim dr2 As OdbcDataReader
                        dr2 = cmd3.ExecuteReader
                        If dr2.Read Then
                            My.Settings.name = dr2(2).ToString
                        End If
                        koneksi2.Close()
                        My.Settings.Save()
                        TxtUsername.Clear()
                        TxtPassword.Clear()
                        CheckBox1.Checked = False
                        TxtUsername.Select()
                        MsgBox("Anda berhasil Login.", MsgBoxStyle.Information)
                        KaryawanPenjualan.Show()
                        Me.Hide()
                End Select
            Else
                MsgBox("User tidak di temukan.", MsgBoxStyle.Information)
            End If
            koneksi.Close()
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Index.Show()
        Me.Hide()
        TxtUsername.Text = ""
        TxtPassword.Text = ""
        CheckBox1.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TxtPassword.UseSystemPasswordChar = False
        Else
            TxtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        TxtPassword.UseSystemPasswordChar = True
        TxtUsername.Select()
    End Sub

End Class
