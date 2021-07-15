Imports System.ComponentModel
Imports System.Data.Odbc
Public Class KaryawanPenjualan
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim s As String = "SELECT * FROM [dbo].[user] WHERE username = '" + My.Settings.username + "'"
        Dim c As New OdbcCommand With {
            .CommandText = s,
            .Connection = koneksi2
        }
        koneksi2.Open()
        Dim d As OdbcDataReader
        d = c.ExecuteReader
        If d.Read Then
            Dim sql As String = "SELECT * FROM [dbo].[karyawan] WHERE kode_karyawan = '" + My.Settings.username + "'"
            Dim cmd As New OdbcCommand With {
                .CommandText = sql,
                .Connection = koneksi
            }
            koneksi.Open()
            Dim dr As OdbcDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                EditProfile.TxtNama.Text = dr.Item("nama_karyawan")
                If dr.Item("jk") = "L" Then
                    EditProfile.RadioL.Checked = True
                ElseIf dr.Item("jk") = "P" Then
                    EditProfile.RadioP.Checked = True
                End If
                EditProfile.TxtAlamat.Text = dr.Item("alamat")
                EditProfile.TxtTelepon.Text = dr.Item("no_telp")
                EditProfile.TxtEmail.Text = dr.Item("email")
                EditProfile.TxtPassword.Text = d.Item("password")
            End If
            koneksi.Close()
        End If
        koneksi2.Close()
        EditProfile.TxtPassword.Select()
        EditProfile.Show()
        Me.Hide()
    End Sub

    Private Sub BtnPenjualan_Click(sender As Object, e As EventArgs) Handles BtnPenjualan.Click
        Dim sql As String = "SELECT * FROM [dbo].[karyawan] WHERE kode_karyawan = '" + My.Settings.username + "' AND status = 1"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi2
        }
        koneksi2.Open()
        Dim dr2 As OdbcDataReader
        dr2 = cmd.ExecuteReader
        If dr2.Read Then
            MenuUtama.Panel1.Text = dr2.Item("kode_karyawan")
            MenuUtama.Panel2.Text = dr2.Item("nama_karyawan")
            MenuUtama.Panel3.Text = "Penjualan"
            MenuUtama.Panel4.Text = Format(Now, "dd MMMM yyyy")

            MenuUtama.UsersToolStripMenuItem.Visible = False
            MenuUtama.KaryawanToolStripMenuItem.Visible = False
            MenuUtama.DistributorToolStripMenuItem.Visible = False
            MenuUtama.PembelianToolStripMenuItem.Visible = False
            MenuUtama.LaporanToolStripMenuItem.Visible = False
            MenuUtama.BayarHutangToolStripMenuItem.Visible = False
            MenuUtama.BtnUser.Visible = False
            MenuUtama.BtnKaryawan.Visible = False
            MenuUtama.BtnDistributor.Visible = False
            MenuUtama.BtnPembelian.Visible = False
            MenuUtama.BtnReturPembelian.Visible = False
            MenuUtama.BtnHutang.Visible = False
            MenuUtama.BtnPiutang.Visible = False
            MenuUtama.BtnBarangMasuk.Visible = False
            MenuUtama.BtnBayarHutang.Visible = False
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
        koneksi2.Close()
    End Sub

    Private Sub KaryawanPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        LblNama.Text = My.Settings.name
    End Sub

    Private Sub KaryawanPenjualan_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FormLogin.Show()
        Me.Hide()
    End Sub
End Class