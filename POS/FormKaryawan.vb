Imports System.Data.Odbc
Public Class FormKaryawan
    Const DSN = "DSN=db_pos"
    'Dim TblKaryawan As New DataTable("Table")
    Dim koneksi, koneksi2 As OdbcConnection
    Dim status As String
    Dim satu As Integer
    Dim dua, kode_karyawan As String

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblJam.Text = Format(Now, "hh:mm:ss tt")
        LblTanggal.Text = Format(Now, "dddd, dd MMMM yyyy")
    End Sub

    Private Sub Awal()
        'DGV.DataSource = Nothing
        'DGV.DataSource = TblKaryawan
        TxtKode.Enabled = False
        TxtNama.Enabled = False
        RadioL.Enabled = False
        RadioP.Enabled = False
        TxtAlamat.Enabled = False
        TxtTelepon.Enabled = False
        TxtEmail.Enabled = False
        ComboPosisi.Enabled = False
        CheckBox2.Enabled = True
        TxtPassword.Enabled = False

        BtnTambah.Enabled = True
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = False
        BtnHapus2.Enabled = False
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True

        'keluar
        CheckBox2.Checked = True
        Label6.Visible = False
        Label12.Visible = False
        ComboStatus.Visible = False

        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamat.Text = ""
        TxtTelepon.Text = ""
        TxtEmail.Text = ""
        TxtPassword.Text = ""
        RadioL.Checked = False
        RadioP.Checked = False
        ComboPosisi.Text = ""
        ComboStatus.Text = ""
    End Sub

    Private Sub TampilGrid()
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub LoadTable()
        Dim sql As String = "SELECT * FROM [dbo].[karyawan] WHERE status = 1"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            Dim sql2 As String = "SELECT password, role FROM [dbo].[user] WHERE username = '" + dr(1).ToString + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            While dr2.Read
                Dim i As String
                If dr2("role") = 1 Then
                    i = "Pembelian"
                ElseIf dr2("role") = 0 Then
                    i = "Admin"
                ElseIf dr2("role") = 2 Then
                    i = "Penjualan"
                End If
                'LebarData()
                TampilGrid()
                DGV.Rows.Add(dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, i, dr2(0).ToString)
            End While
            koneksi2.Close()
        End While
        koneksi.Close()
        DGV.Refresh()
    End Sub

    Private Sub LoadTable0()
        Dim sql As String = "SELECT * FROM [dbo].[karyawan] WHERE status = 0"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            Dim sql2 As String = "SELECT password, role FROM [dbo].[user] WHERE username = '" + dr(1).ToString + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            While dr2.Read
                Dim i As String
                If dr2("role") = 1 Then
                    i = "Pembelian"
                ElseIf dr2("role") = 0 Then
                    i = "Admin"
                ElseIf dr2("role") = 2 Then
                    i = "Penjualan"
                End If
                'LebarData()
                TampilGrid()
                DGV.Rows.Add(dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, i, dr2(0).ToString)
            End While
            koneksi2.Close()
        End While
        koneksi.Close()
        DGV.Refresh()
    End Sub

    Private Sub KaryawanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        Awal()
        CheckBox2.Checked = True
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Awal()
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If status = "Tambah" Then
            If TxtNama.Text = "" Or TxtAlamat.Text = "" Or TxtTelepon.Text = "" Or TxtEmail.Text = "" Or TxtPassword.Text = "" Then
                MsgBox("Data tidak boleh kosong", MsgBoxStyle.Exclamation)
            Else
                Dim nama, alamat, telp, email, password, jenis_kelamin As String
                Dim status, role As String

                nama = TxtNama.Text
                alamat = TxtAlamat.Text
                telp = TxtTelepon.Text
                email = TxtEmail.Text
                If RadioL.Checked Then
                    jenis_kelamin = "L"
                ElseIf RadioP.Checked Then
                    jenis_kelamin = "P"
                End If
                status = 1

                If ComboPosisi.Text = "Admin" Then
                    role = 0
                ElseIf ComboPosisi.Text = "Pembelian" Then
                    role = 1
                ElseIf ComboPosisi.Text = "Penjualan" Then
                    role = 2
                End If

                password = TxtPassword.Text


                Dim sql As String = "INSERT INTO [dbo].[karyawan] VALUES('" + TxtKode.Text + "', '" + nama + "', '" + jenis_kelamin + "','" + alamat + "', '" + telp + "', '" + email + "', '" + status + "')"
                    Dim cmd As New OdbcCommand With {
                    .CommandText = sql,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd.ExecuteNonQuery()
                koneksi.Close()

                Dim sql2 As String = "INSERT INTO [dbo].[user] VALUES('" + kode_karyawan + "', '" + kode_karyawan + "', '" + password + "', '" + role + "', '" + status + "')"
                Dim cmd2 As New OdbcCommand With {
                    .CommandText = sql2,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd2.ExecuteNonQuery()
                koneksi.Close()

                Awal()
                DGV.Rows.Clear()
                LoadTable()
                MsgBox("Data berhasil di tambahkan.", MsgBoxStyle.Information)
                'MsgBox("Username anda adalah '" + kode_karyawan + "' dan password anda adalah '" + password + "'", MsgBoxStyle.Information)
            End If
        ElseIf status = "Ubah" Then
            If TxtNama.Text = "" Or TxtTelepon.Text = "" Or TxtAlamat.Text = "" Or TxtEmail.Text = "" Then
                MsgBox("Data gagal di ubah.", MsgBoxStyle.Exclamation)
            Else
                Dim jk As String
                Dim role As String
                Dim status
                If RadioL.Checked Then
                    jk = "L"
                Else
                    jk = "P"
                End If

                If ComboPosisi.Text = "Admin" Then
                    role = 0
                ElseIf ComboPosisi.Text = "Pembelian" Then
                    role = 1
                ElseIf ComboPosisi.Text = "Penjualan" Then
                    role = 2
                End If


                If ComboStatus.Text = "Aktif" Then
                    status = 1
                ElseIf ComboStatus.Text = "Tidak Aktif" Then
                    status = 0
                End If

                Dim edit = "UPDATE [dbo].[karyawan] SET nama_karyawan = '" + TxtNama.Text + "', jk = '" + jk + "', alamat = '" + TxtAlamat.Text + "', no_telp = '" + TxtTelepon.Text + "', email = '" + TxtEmail.Text + "', status = " + status.ToString + " WHERE kode_karyawan = '" + TxtKode.Text + "'"
                Dim cmd3 As New OdbcCommand With {
                    .CommandText = edit,
                    .Connection = koneksi
                }
                koneksi.Open()
                Dim edit2 = "UPDATE [dbo].[user] SET password = '" + TxtPassword.Text + "', role = '" + role + "', status = " + status.ToString + " WHERE username = '" + TxtKode.Text + "'"
                Dim cmd4 As New OdbcCommand With {
                    .CommandText = edit2,
                    .Connection = koneksi2
                }
                koneksi2.Open()
                If MsgBox("Apakah kamu yakin mau merubah data ini?", MsgBoxStyle.YesNo, "Edit") = MsgBoxResult.Yes Then
                    cmd3.ExecuteNonQuery()
                    koneksi.Close()
                    cmd4.ExecuteNonQuery()
                    koneksi2.Close()
                    MsgBox("Data berhasil di ubah", MsgBoxStyle.Information)
                ElseIf MsgBoxResult.No Then
                    MsgBox("Data tidak jadi di ubah", MsgBoxStyle.Information)
                End If
                koneksi2.Close()
                koneksi.Close()
                Awal()
                DGV.Rows.Clear()
                LoadTable()
            End If
        Else
            MsgBox("Lakukan perubahan data", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        TxtNama.Enabled = True
        TxtAlamat.Enabled = True
        TxtTelepon.Enabled = True
        TxtEmail.Enabled = True
        TxtPassword.Enabled = True
        RadioP.Enabled = True
        RadioL.Enabled = True
        ComboPosisi.Enabled = True
        CheckBox2.Enabled = False

        BtnTambah.Enabled = False
        BtnHapus.Enabled = False
        BtnUbah.Enabled = False
        BtnSimpan.Enabled = True
        BtnHapus2.Enabled = False
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        TxtNama.Select()
        status = "Tambah"

        Dim sql As String = "SELECT TOP 1 kode_karyawan FROM [dbo].[karyawan] ORDER BY kode_karyawan DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            satu = 1
            dua = "K000" + Convert.ToString(satu)
            kode_karyawan = dua
        ElseIf dr.HasRows Then
            Dim s As String
            s = dr(0)
            satu = s.Substring(s.Length - 4) + 1
            If satu >= 10 Then
                dua = "K00" + Convert.ToString(satu)
                kode_karyawan = dua
            ElseIf satu >= 100 Then
                dua = "K0" + Convert.ToString(satu)
                kode_karyawan = dua
            ElseIf satu >= 1000 Then
                dua = "K" + Convert.ToString(satu)
                kode_karyawan = dua
            Else
                dua = "K000" + Convert.ToString(satu)
                kode_karyawan = dua
            End If
        End If
        TxtKode.Text = kode_karyawan
        dr.Close()
        cmd.Dispose()
        koneksi.Close()
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Awal()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Awal()
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub BtnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        TxtNama.Enabled = True
        TxtAlamat.Enabled = True
        TxtTelepon.Enabled = True
        TxtEmail.Enabled = True
        TxtPassword.Enabled = True
        RadioL.Enabled = True
        RadioP.Enabled = True
        ComboPosisi.Enabled = True

        BtnTambah.Enabled = False
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = True
        BtnHapus2.Enabled = False
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        TxtNama.Select()
        status = "Ubah"

        If CheckBox2.Checked = False Then
            ComboStatus.Enabled = True
            ComboStatus.Select()
        End If
    End Sub

    Private Sub DGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellClick
        BtnUbah.Enabled = True
        BtnHapus.Enabled = True
        BtnTambah.Enabled = False
        On Error Resume Next
        TxtKode.Text = DGV.CurrentRow.Cells(0).Value
        TxtNama.Text = DGV.CurrentRow.Cells(1).Value
        If DGV.CurrentRow.Cells(2).Value = "L" Then
            RadioL.Checked = True
        ElseIf DGV.CurrentRow.Cells(2).Value = "P" Then
            RadioP.Checked = True
        End If
        TxtAlamat.Text = DGV.CurrentRow.Cells(3).Value
        TxtTelepon.Text = DGV.CurrentRow.Cells(4).Value
        TxtEmail.Text = DGV.CurrentRow.Cells(5).Value
        If DGV.CurrentRow.Cells(7).Value = "Pembelian" Then
            ComboPosisi.Text = "Pembelian"
        ElseIf DGV.CurrentRow.Cells(7).Value = "Penjualan" Then
            ComboPosisi.Text = "Penjualan"
        ElseIf DGV.CurrentRow.Cells(7).Value = "Admin" Then
            ComboPosisi.Text = "Admin"
        End If
        TxtPassword.Text = DGV.CurrentRow.Cells(8).Value

        If CheckBox2.Checked = False Then
            If DGV.Rows(e.RowIndex).Cells(6).Value = "0" Then
                ComboStatus.Text = "Tidak Aktif"
            ElseIf DGV.Rows(e.RowIndex).Cells(6).Value = "1" Then
                ComboStatus.Text = "Aktif"
            End If
        End If
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        TxtNama.Enabled = True
        TxtAlamat.Enabled = True
        TxtTelepon.Enabled = True
        TxtEmail.Enabled = True
        TxtPassword.Enabled = True
        RadioL.Enabled = True
        RadioP.Enabled = True
        ComboPosisi.Enabled = True

        BtnTambah.Enabled = False
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = False
        BtnHapus2.Enabled = True
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        TxtNama.Select()
        status = "Hapus"
    End Sub

    Private Sub BtnHapus2_Click(sender As Object, e As EventArgs) Handles BtnHapus2.Click
        If status = "Hapus" Then
            'Dim delete As String = "DELETE FROM [dbo].[karyawan] WHERE id_karyawan = '" + TxtKode.Text + "'"
            'Dim cmd As New OdbcCommand With {
            '    .CommandText = delete,
            '    .Connection = koneksi
            '}
            'koneksi.Open()
            'Dim delete2 As String = "DELETE FROM [dbo].[user] WHERE username = '" + TxtKode.Text + "'"
            'Dim cmd2 As New OdbcCommand With {
            '    .CommandText = delete2,
            '    .Connection = koneksi2
            '}
            'koneksi2.Open()
            'If MsgBox("Apakah anda yakin akan menghapus data ini?", MsgBoxStyle.YesNo, "Hapus") = MsgBoxResult.Yes Then
            '    cmd.ExecuteNonQuery()
            '    koneksi.Close()
            '    cmd2.ExecuteNonQuery()
            '    koneksi2.Close()
            '    MsgBox("Data berhasil di hapus", MsgBoxStyle.Information)
            'ElseIf MsgBoxResult.No Then
            '    MsgBox("Data gagal di hapus!", MsgBoxStyle.Exclamation)
            'End If
            'koneksi2.Close()
            'koneksi.Close()

            Dim delete As String = "UPDATE [dbo].[karyawan] SET status = 0 WHERE kode_karyawan = '" + TxtKode.Text + "'"
            Dim cmd As New OdbcCommand With {
                .CommandText = delete,
                .Connection = koneksi
            }
            koneksi.Open()
            Dim delete2 As String = "UPDATE [dbo].[user] SET status = 0 WHERE kode_karyawan = '" + TxtKode.Text + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = delete2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            If MsgBox("Apakah anda yakin mau menghapus / menonaktif data ini?", MsgBoxStyle.YesNo, "Hapus") = MsgBoxResult.Yes Then
                cmd.ExecuteNonQuery()
                koneksi.Close()
                cmd2.ExecuteNonQuery()
                koneksi2.Close()
                MsgBox("Data berhasil dihapus / dinonaktifkan", MsgBoxStyle.Information)
            ElseIf MsgBoxResult.No Then
                MsgBox("Data gagal dihapus / dinonaktifkan", MsgBoxStyle.Exclamation)
            End If
            koneksi2.Close()
            koneksi.Close()
            Awal()
            DGV.Rows.Clear()
            LoadTable()
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Awal()
            CheckBox2.Text = "Bekerja"
            BtnTambah.Enabled = True
            DGV.Rows.Clear()
            LoadTable()
        ElseIf CheckBox2.Checked = False Then
            ComboStatus.Enabled = False
            BtnTambah.Enabled = False
            CheckBox2.Text = "Keluar"
            Label6.Visible = True
            Label12.Visible = True
            ComboStatus.Visible = True
            DGV.Rows.Clear()
            LoadTable0()
        End If
    End Sub

    Private Sub TxtTelepon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTelepon.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
        End If
    End Sub
End Class