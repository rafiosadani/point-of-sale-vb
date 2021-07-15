Imports System.ComponentModel
Imports System.Data.Odbc
Public Class KaryawanPembelian
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection

    Private Sub KaryawanPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        LblNama.Text = My.Settings.name
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim sql As String = "SELECT * FROM [dbo].[user] WHERE username = '" + My.Settings.username + "'"
        Dim cmd As New OdbcCommand With {
          .CommandText = sql,
          .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.Read Then
            Dim sql2 As String = "SELECT * FROM [dbo].[karyawan] WHERE kode_karyawan = '" + My.Settings.username + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            If dr2.Read Then
                EditProfile.TxtNama.Text = dr2.Item("nama_karyawan")
                If dr2.Item("jk") = "L" Then
                    EditProfile.RadioL.Checked = True
                ElseIf dr2.Item("jk") = "P" Then
                    EditProfile.RadioP.Checked = True
                End If
                EditProfile.TxtAlamat.Text = dr2.Item("alamat")
                EditProfile.TxtTelepon.Text = dr2.Item("no_telp")
                EditProfile.TxtEmail.Text = dr2.Item("email")
                EditProfile.TxtPassword.Text = dr.Item("password")
            End If
            koneksi2.Close()
        End If
        koneksi.Close()
        EditProfile.TxtPassword.Select()
        EditProfile.Show()
        Me.Hide()
    End Sub

    Private Sub BtnPembelian_Click(sender As Object, e As EventArgs) Handles BtnPembelian.Click
        Dim sql As String = "SELECT * FROM [dbo].[karyawan] WHERE kode_karyawan = '" + My.Settings.username + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.Read Then
            MenuUtama.Panel1.Text = dr.Item("kode_karyawan")
            MenuUtama.Panel2.Text = dr.Item("nama_karyawan")
            MenuUtama.Panel3.Text = "Pembelian"
            MenuUtama.Panel4.Text = Format(Now, "dd MMMM yyyy")

            MenuUtama.UsersToolStripMenuItem.Visible = False
            MenuUtama.KaryawanToolStripMenuItem.Visible = False
            MenuUtama.CustomerToolStripMenuItem.Visible = False
            MenuUtama.PenjualanToolStripMenuItem.Visible = False
            MenuUtama.LaporanToolStripMenuItem.Visible = False
            MenuUtama.TerimaPiutangToolStripMenuItem.Visible = False
            MenuUtama.BtnUser.Visible = False
            MenuUtama.BtnKaryawan.Visible = False
            MenuUtama.BtnCustomer.Visible = False
            MenuUtama.BtnPenjualan.Visible = False
            MenuUtama.BtnBarangKeluar.Visible = False
            MenuUtama.BtnReturPenjualan.Visible = False
            MenuUtama.BtnTerimaPiutang.Visible = False
            MenuUtama.TabPage3.Visible = False
            MenuUtama.BtnHutang.Visible = False
            MenuUtama.BtnPiutang.Visible = False
            MenuUtama.BtnComplete.Visible = False
            MenuUtama.BtnLaporanPembelian.Visible = False
            MenuUtama.BtnLaporanPenjualan.Visible = False

            MsgBox("Selamat Datang..", MsgBoxStyle.Information)
            MenuUtama.Show()
            Me.Hide()
        End If
        koneksi.Close()
    End Sub

    Private Sub KaryawanPembelian_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FormLogin.Show()
        Me.Hide()
    End Sub
End Class