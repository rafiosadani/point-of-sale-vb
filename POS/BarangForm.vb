Imports System.Data.Odbc
Public Class BarangForm
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    Dim TblBarang As New DataTable()
    Dim status As String
    Dim satu As Integer
    Dim dua, kode_barang As String

    Private Sub BarangForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        Awal()
        CreateTable()
        LebarData()
        LoadTable()
        TampilGrid()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblJam.Text = Format(Now, "HH:mm:ss")
    End Sub

    Private Sub Awal()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = TblBarang
        TxtKode.Enabled = False
        TxtNama.Enabled = False
        ComboSatuan.Enabled = False
        TxtHargaBeli.Enabled = False
        ComboKategori.Enabled = False
        TxtHargaJual.Enabled = False
        TxtStok.Enabled = False
        TxtCari.Enabled = True

        BtnTambah.Enabled = True
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = False
        BtnHapus2.Enabled = False
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        BtnCari.Enabled = True

        TxtKode.Clear()
        TxtNama.Clear()
        ComboSatuan.Text = ""
        TxtHargaBeli.Clear()
        ComboKategori.Text = ""
        TxtHargaJual.Clear()
        TxtStok.Clear()
        TxtCari.Clear()
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        TxtNama.Enabled = True
        ComboSatuan.Enabled = True
        TxtHargaBeli.Enabled = True
        ComboKategori.Enabled = True
        TxtHargaJual.Enabled = True
        TxtStok.Enabled = True
        TxtCari.Enabled = False

        BtnTambah.Enabled = False
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = True
        BtnHapus2.Enabled = False
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        BtnCari.Enabled = False
        TxtNama.Select()
        status = "Tambah"

        Dim sql As String = "SELECT TOP 1 kode_barang FROM [dbo].[barang] ORDER BY kode_barang DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            satu = 1
            dua = "BRG0000" + Convert.ToString(satu)
            kode_barang = dua
        ElseIf dr.HasRows Then
            Dim a As String
            a = dr(0)
            satu = a.Substring(a.Length - 5) + 1
            If satu >= 10 Then
                dua = "BRG000" + Convert.ToString(satu)
                kode_barang = dua
            ElseIf satu >= 100 Then
                dua = "BRG00" + Convert.ToString(satu)
                kode_barang = dua
            ElseIf satu >= 1000 Then
                dua = "BRG0" + Convert.ToString(satu)
                kode_barang = dua
            ElseIf satu >= 10000 Then
                dua = "BRG" + Convert.ToString(satu)
                kode_barang = dua
            Else
                dua = "BRG0000" + Convert.ToString(satu)
                kode_barang = dua
            End If
        End If
        TxtKode.Text = kode_barang
        dr.Close()
        cmd.Dispose()
        koneksi.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If status = "Tambah" Then
            If TxtNama.Text = "" Or TxtHargaBeli.Text = "" Or TxtHargaJual.Text = "" Or TxtStok.Text = "" Then
                MsgBox("Data tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Else
                Dim nama, satuan, harga_beli, kategori, harga_jual, stok As String

                nama = TxtNama.Text
                satuan = ComboSatuan.Text
                harga_beli = TxtHargaBeli.Text
                kategori = ComboKategori.Text
                harga_jual = TxtHargaJual.Text
                stok = TxtStok.Text

                Dim query As String = "INSERT INTO [dbo].[barang] VALUES('" + TxtKode.Text + "', '" + TxtNama.Text + "', '" + ComboKategori.Text + "', '" + TxtStok.Text + "', '" + TxtHargaBeli.Text + "', '" + TxtHargaJual.Text + "', '" + ComboSatuan.Text + "')"
                Dim cmd As New OdbcCommand With {
                    .CommandText = query,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd.ExecuteNonQuery()
                koneksi.Close()

                Awal()
                TblBarang.Rows.Clear()
                LoadTable()
                MsgBox("Data berhasil di tambahkan.", MsgBoxStyle.Information)
            End If
        ElseIf status = "Ubah" Then
            Dim edit As String = "UPDATE [dbo].[barang] SET nama_barang = '" + TxtNama.Text + "', kategori = '" + ComboKategori.Text + "', stok = '" + TxtStok.Text + "', harga_beli = '" + TxtHargaBeli.Text + "', harga_jual = '" + TxtHargaJual.Text + "', satuan = '" + ComboSatuan.Text + "' WHERE kode_barang = '" + TxtKode.Text + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = edit,
                .Connection = koneksi2
            }
            koneksi2.Open()
            If MsgBox("Apakah anda yakin mau merubah data ini?", MsgBoxStyle.YesNo, "Ubah") = MsgBoxResult.Yes Then
                cmd2.ExecuteNonQuery()
                koneksi2.Close()
                MsgBox("Data berhasil di ubah", MsgBoxStyle.Information)
            ElseIf MsgBoxResult.No Then
                MsgBox("Data gagal di ubah", MsgBoxStyle.Exclamation)
            End If
            koneksi2.Close()
            Awal()
            TblBarang.Rows.Clear()
            LoadTable()
        Else
            MsgBox("Lakukan perubahan data", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub CreateTable()
        TblBarang.Columns.Add("Kode Barang", Type.GetType("System.String"))
        TblBarang.Columns.Add("Nama Barang", Type.GetType("System.String"))
        TblBarang.Columns.Add("Satuan", Type.GetType("System.String"))
        TblBarang.Columns.Add("Harga Beli", Type.GetType("System.String"))
        TblBarang.Columns.Add("Kategori", Type.GetType("System.String"))
        TblBarang.Columns.Add("Harga Jual", Type.GetType("System.String"))
        TblBarang.Columns.Add("Stok", Type.GetType("System.String"))
    End Sub

    Private Sub TampilGrid()
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(3).DefaultCellStyle.Format = "#, ###"
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(5).DefaultCellStyle.Format = "#, ###"
        DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub BtnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        TxtNama.Enabled = True
        ComboSatuan.Enabled = True
        TxtHargaBeli.Enabled = True
        ComboKategori.Enabled = True
        TxtHargaJual.Enabled = True
        TxtStok.Enabled = True
        TxtCari.Enabled = False

        BtnTambah.Enabled = False
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = True
        BtnHapus2.Enabled = False
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        BtnCari.Enabled = False
        TxtNama.Select()
        status = "Ubah"
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Awal()
        LebarData()
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        BtnUbah.Enabled = True
        BtnHapus.Enabled = True
        BtnTambah.Enabled = False

        TxtKode.Text = DataGridView1.CurrentRow.Cells(0).Value
        TxtNama.Text = DataGridView1.CurrentRow.Cells(1).Value
        ComboSatuan.Text = DataGridView1.CurrentRow.Cells(2).Value
        TxtHargaBeli.Text = DataGridView1.CurrentRow.Cells(3).Value
        ComboKategori.Text = DataGridView1.CurrentRow.Cells(4).Value
        TxtHargaJual.Text = DataGridView1.CurrentRow.Cells(5).Value
        TxtStok.Text = DataGridView1.CurrentRow.Cells(6).Value
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Awal()
        LebarData()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Awal()
        LebarData()
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        TxtNama.Enabled = True
        ComboSatuan.Enabled = True
        TxtHargaBeli.Enabled = True
        ComboKategori.Enabled = True
        TxtHargaJual.Enabled = True
        TxtStok.Enabled = True
        TxtCari.Enabled = False

        BtnTambah.Enabled = False
        BtnUbah.Enabled = False
        BtnSimpan.Enabled = False
        BtnHapus.Enabled = False
        BtnHapus2.Enabled = True
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        BtnCari.Enabled = False
        TxtNama.Select()
        status = "Hapus"
    End Sub

    Private Sub BtnHapus2_Click(sender As Object, e As EventArgs) Handles BtnHapus2.Click
        If status = "Hapus" Then
            Dim delete As String = "DELETE FROM [dbo].[barang] WHERE kode_barang = '" + TxtKode.Text + "'"
            Dim cmd As New OdbcCommand With {
                .CommandText = delete,
                .Connection = koneksi
            }
            koneksi.Open()
            If MsgBox("Apakah anda yakin mau menghapus data ini?", MsgBoxStyle.YesNo, "Hapus") = MsgBoxResult.Yes Then
                cmd.ExecuteNonQuery()
                koneksi.Close()
                MsgBox("Data berhasil di hapus", MsgBoxStyle.Information)
            ElseIf MsgBoxResult.No Then
                MsgBox("Data gagal di hapus", MsgBoxStyle.Exclamation)
            End If
            koneksi.Close()
            Awal()
            TblBarang.Rows.Clear()
            LoadTable()
        End If
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        TblBarang.Rows.Clear()

        Dim sql As String = "SELECT * FROM [dbo].[barang] WHERE kategori AND nama_barang LIKE'%" + TxtCari.Text + "%'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            LebarData()
            TblBarang.Rows.Add(dr(1).ToString, dr(2).ToString, dr(7).ToString, dr(5).ToString, dr(3).ToString, dr(6).ToString, dr(4).ToString)
        End While
        DataGridView1.Refresh()
        koneksi.Close()
    End Sub

    Private Sub TxtCari_TextChanged(sender As Object, e As EventArgs) Handles TxtCari.TextChanged
        If TxtCari.Text = "" Then
            TblBarang.Rows.Clear()
            LoadTable()
        End If
    End Sub

    Private Sub LebarData()
        DataGridView1.Columns(0).Width = 110
        DataGridView1.Columns(1).Width = 195
        DataGridView1.Columns(2).Width = 110
        DataGridView1.Columns(3).Width = 110
        DataGridView1.Columns(4).Width = 120
        DataGridView1.Columns(5).Width = 110
        DataGridView1.Columns(6).Width = 110
    End Sub

    Private Sub LoadTable()
        Dim sql As String = "SELECT * FROM [dbo].[barang]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            LebarData()
            TblBarang.Rows.Add(dr(1).ToString, dr(2).ToString, dr(7).ToString, dr(5).ToString, dr(3).ToString, dr(6).ToString, dr(4).ToString)
        End While
        DataGridView1.Refresh()
        koneksi.Close()
    End Sub
End Class