Imports System.ComponentModel
Imports System.Data.Odbc

Public Class KaryawanBaru
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    Dim kode_karyawan, dua As String
    Dim satu As Integer

    Private Sub KaryawanBaru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        LblJam.Text = Format(Now, "hh:mm:ss tt")
        LblTanggal.Text = Format(Now, "dd MMMM yyyy")
        Call Awal()
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        Call Tampilkan()
        Call KodeKaryawan()
        TxtNama.Select()
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Awal()
    End Sub

    Private Sub KodeKaryawan()
        Dim sql As String = "SELECT TOP 1 * FROM [dbo].[karyawan] ORDER BY kode_karyawan DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            satu = 1
            dua = "K000" + Convert.ToString(satu)
            kode_karyawan = dua
        Else
            Dim a As String
            a = dr(1)
            satu = a.Substring(a.Length - 4) + 1
            If satu >= 10 Then
                dua = "K00" + Convert.ToString(satu)
                kode_karyawan = dua
            ElseIf satu >= 100 Then
                dua = "K0" + Convert.ToString(satu)
                kode_karyawan = dua
            ElseIf satu >= 1000 Then
                dua = "K" = Convert.ToString(satu)
                kode_karyawan = dua
            Else
                dua = "K000" + Convert.ToString(satu)
                kode_karyawan = dua
            End If
        End If
        koneksi.Close()
        TxtKode.Text = kode_karyawan
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If TxtNama.Text = "" Or TxtAlamat.Text = "" Or TxtTelepon.Text = "" Or TxtPassword.Text = "" Then
            MsgBox("Data tidak boleh kosong!.", MsgBoxStyle.Exclamation)
        Else
            Dim nama, alamat, no_telp, email, jk, password As String
            Dim status, role As String

            nama = TxtNama.Text
            alamat = TxtAlamat.Text
            no_telp = TxtTelepon.Text
            email = TxtEmail.Text
            If RadioL.Checked = True Then
                jk = "L"
            ElseIf RadioP.Checked = True Then
                jk = "P"
            End If
            status = 1
            password = TxtPassword.Text

            If CheckPosisi.Checked = True Then
                role = 1
            ElseIf CheckPosisi.Checked = False Then
                role = 2
            End If

            Dim sql As String = "INSERT INTO [dbo].[karyawan] VALUES('" + TxtKode.Text + "', '" + nama + "', '" + jk + "', '" + alamat + "', '" + no_telp + "', '" + email + "', '" + status + "')"
            Dim cmd As New OdbcCommand With {
                .CommandText = sql,
                .Connection = koneksi
            }
            koneksi.Open()
            cmd.ExecuteNonQuery()
            koneksi.Close()

            Dim sql2 As String = "INSERT INTO [dbo].[user] VALUES('" + TxtKode.Text + "', '" + TxtKode.Text + "','" + password + "', '" + role + "', '" + status + "')"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi
            }
            koneksi.Open()
            cmd2.ExecuteNonQuery()
            koneksi.Close()

            Call Awal()
            MsgBox("Data berhasil ditambahkan.", MsgBoxStyle.Information)
            MsgBox("Selamat anda menjadi karyawan baru di UD. SUMBER REJEKI , username anda adalah '" + My.Settings.username + "' dan password anda adalah '" + password + "'")
            InfoKaryawan.Show()
            InfoKaryawan.LblUsername.Text = kode_karyawan
            InfoKaryawan.LblPassword.Text = password
        End If
    End Sub

    Private Sub CheckPosisi_CheckedChanged(sender As Object, e As EventArgs) Handles CheckPosisi.CheckedChanged
        If CheckPosisi.Checked = True Then
            CheckPosisi.Text = "Pembelian"
        ElseIf CheckPosisi.Checked = False Then
            CheckPosisi.Text = "Penjualan"
        End If
    End Sub

    Private Sub Awal()
        TxtKode.Enabled = False
        TxtNama.Enabled = False
        TxtAlamat.Enabled = False
        TxtTelepon.Enabled = False
        TxtEmail.Enabled = False
        TxtPassword.Enabled = False
        CheckPosisi.Enabled = False
        RadioL.Enabled = False
        RadioP.Enabled = False

        BtnSimpan.Enabled = False
        BtnBatal.Enabled = False
        BtnTambah.Enabled = True

        TxtPassword.Clear()
        TxtKode.Clear()
        TxtNama.Clear()
        TxtAlamat.Clear()
        TxtTelepon.Clear()
        TxtEmail.Clear()
        RadioL.Checked = False
        RadioP.Checked = False
        CheckPosisi.Checked = False
    End Sub

    Private Sub Tampilkan()
        TxtNama.Enabled = True
        TxtAlamat.Enabled = True
        TxtTelepon.Enabled = True
        TxtEmail.Enabled = True
        TxtPassword.Enabled = True
        CheckPosisi.Enabled = True
        RadioL.Enabled = True
        RadioP.Enabled = True

        BtnSimpan.Enabled = True
        BtnBatal.Enabled = True
        BtnTambah.Enabled = False
    End Sub

    Private Sub KaryawanBaru_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Index.Show()
        Me.Hide()
    End Sub

    Private Sub TxtTelepon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTelepon.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
        End If
    End Sub
End Class