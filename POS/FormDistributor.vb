Imports System.Data.Odbc
Public Class FormDistributor
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    Dim status As String
    Dim TblDistributor As New DataTable("Table")
    Dim satu As Integer
    Dim dua, kode_distributor As String

    Private Sub FormDistributor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        CreateTable()
        Awal()
        Lebar()
        LoadTable()
    End Sub

    Private Sub Awal()
        DGV.DataSource = Nothing
        DGV.DataSource = TblDistributor
        TxtKode.Enabled = False
        TxtNama.Enabled = False
        TxtAlamat.Enabled = False
        TxtTelepon.Enabled = False

        BtnTambah.Enabled = True
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnHapus2.Enabled = False
        BtnSimpan.Enabled = False
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
    End Sub

    Private Sub Tampilkan()
        TxtNama.Enabled = True
        TxtAlamat.Enabled = True
        TxtTelepon.Enabled = True

        BtnTambah.Enabled = False
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnHapus2.Enabled = False
        BtnSimpan.Enabled = True
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
    End Sub

    Private Sub Bersihkan()
        TxtKode.Clear()
        TxtNama.Clear()
        TxtAlamat.Clear()
        TxtTelepon.Clear()
    End Sub

    Private Sub CreateTable()
        TblDistributor.Columns.Add("Kode Distributor", Type.GetType("System.String"))
        TblDistributor.Columns.Add("Nama Distributor", Type.GetType("System.String"))
        TblDistributor.Columns.Add("Alamat", Type.GetType("System.String"))
        TblDistributor.Columns.Add("Telepon", Type.GetType("System.String"))
    End Sub

    Private Sub Lebar()
        DGV.Columns(0).Width = 122
        DGV.Columns(1).Width = 180
        DGV.Columns(2).Width = 120
        DGV.Columns(3).Width = 120
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        Tampilkan()
        TxtNama.Select()
        status = "Tambah"

        Dim sql As String = "SELECT TOP 1 kode_distributor FROM [dbo].[distributor] ORDER BY kode_distributor DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            satu = 1
            dua = "DIS000" + Convert.ToString(satu)
            kode_distributor = dua
        ElseIf dr.HasRows Then
            Dim s As String
            s = dr(0)
            satu = s.Substring(s.Length - 4) + 1
            If satu >= 10 Then
                dua = "DIS00" + Convert.ToString(satu)
                kode_distributor = dua
            ElseIf satu >= 100 Then
                dua = "DIS0" + Convert.ToString(satu)
                kode_distributor = dua
            ElseIf satu >= 1000 Then
                dua = "DIS" + Convert.ToString(satu)
                kode_distributor = dua
            Else
                dua = "DIS000" + Convert.ToString(satu)
                kode_distributor = dua
            End If
        End If
        TxtKode.Text = kode_distributor
        dr.Close()
        cmd.Dispose()
        koneksi.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If status = "Tambah" Then
            If TxtNama.Text = "" Or TxtAlamat.Text = "" Or TxtTelepon.Text = "" Then
                MsgBox("Data tidak boleh kosong", MsgBoxStyle.Critical)
            Else
                Dim nama, alamat, no_telp As String

                nama = TxtNama.Text
                alamat = TxtAlamat.Text
                no_telp = TxtTelepon.Text

                Dim sql As String = "INSERT INTO [dbo].[distributor] VALUES('" + TxtKode.Text + "', '" + nama + "', '" + alamat + "', '" + no_telp + "')"
                Dim cmd As New OdbcCommand With {
                    .CommandText = sql,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd.ExecuteNonQuery()
                koneksi.Close()

                Awal()
                Bersihkan()
                TblDistributor.Rows.Clear()
                LoadTable()
                MsgBox("Data berhasil di tambahkan.", MsgBoxStyle.Information)
                BtnTambah.Focus()
            End If
        ElseIf status = "Ubah" Then
            Dim sql2 As String = "UPDATE [dbo].[distributor] SET nama = '" + TxtNama.Text + "', alamat = '" + TxtAlamat.Text + "', no_telp = '" + TxtTelepon.Text + "' WHERE kode_distributor = '" + TxtKode.Text + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi
            }
            koneksi.Open()
            If MsgBox("Apakah anda yakin mau merubah data ini?", MsgBoxStyle.YesNo, "Ubah") = MsgBoxResult.Yes Then
                cmd2.ExecuteNonQuery()
                koneksi.Close()
                MsgBox("Data berhasil di ubah", MsgBoxStyle.Information)
                BtnTambah.Focus()
            ElseIf MsgBoxResult.No Then
                MsgBox("Data gagal di ubah.", MsgBoxStyle.Critical)
                BtnTambah.Focus()
            End If
            koneksi.Close()
            Awal()
            Bersihkan()
            TblDistributor.Rows.Clear()
            LoadTable()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblJam.Text = Format(Now, "hh:mm:ss tt")
        LblTanggal.Text = Format(Now, "dddd, dd MMMM yyyy")
    End Sub

    Private Sub BtnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        Tampilkan()
        TxtNama.Select()
        status = "Ubah"
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Awal()
        Bersihkan()
        Lebar()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Awal()
        Bersihkan()
        Lebar()
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub DGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellClick
        BtnUbah.Enabled = True
        BtnHapus.Enabled = True
        BtnTambah.Enabled = False

        TxtKode.Text = DGV.CurrentRow.Cells(0).Value
        TxtNama.Text = DGV.CurrentRow.Cells(1).Value
        TxtAlamat.Text = DGV.CurrentRow.Cells(2).Value
        TxtTelepon.Text = DGV.CurrentRow.Cells(3).Value
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        Tampilkan()
        BtnSimpan.Enabled = False
        BtnHapus2.Enabled = True
        TxtNama.Select()
        status = "Hapus"
    End Sub

    Private Sub BtnHapus2_Click(sender As Object, e As EventArgs) Handles BtnHapus2.Click
        If status = "Hapus" Then
            If TxtNama.Text = "" Or TxtAlamat.Text = "" Or TxtTelepon.Text = "" Then
                MsgBox("Data tidak boleh kosong", MsgBoxStyle.Exclamation)
            Else
                Dim delete As String = "DELETE FROM [dbo].[distributor] WHERE kode_distributor = '" + TxtKode.Text + "'"
                Dim cmd As New OdbcCommand With {
                    .CommandText = delete,
                    .Connection = koneksi
                }
                koneksi.Open()
                If MsgBox("Apakah anda yakin mau menghapus data ini?", MsgBoxStyle.YesNo, "Hapus") = MsgBoxResult.Yes Then
                    cmd.ExecuteNonQuery()
                    koneksi.Close()
                    MsgBox("Data berhasil di hapus", MsgBoxStyle.Information)
                    BtnTambah.Focus()
                ElseIf MsgBoxResult.No Then
                    MsgBox("Data gagal di hapus", MsgBoxStyle.Critical)
                    BtnTambah.Focus()
                End If
                koneksi.Close()
                Awal()
                Bersihkan()
                TblDistributor.Rows.Clear()
                LoadTable()
            End If
        End If
    End Sub

    Private Sub LoadTable()
        Dim query As String = "SELECT * FROM [dbo].[distributor]"
        Dim cmd As New OdbcCommand With {
            .CommandText = query,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            Lebar()
            TblDistributor.Rows.Add(dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString)
        End While
        DGV.Refresh()
        koneksi.Close()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Awal()
        Bersihkan()
        Lebar()
        MenuUtama.Show()
        Me.Hide()
    End Sub
End Class