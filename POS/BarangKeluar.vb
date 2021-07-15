Imports System.Data.Odbc
Public Class BarangKeluar
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2, koneksi3 As OdbcConnection
    Dim TblBarangKeluar As New DataTable("Table")

    Private Sub BarangKeluar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV.DataSource = Nothing
        DGV.DataSource = TblBarangKeluar
        DTPTanggal.Format = DateTimePickerFormat.Custom
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        koneksi3 = New OdbcConnection(DSN)
        Call NoKeluar()
        Call TampilFaktur()
        Call CreateTable()
        Call LebarData()
    End Sub

    Private Sub NoKeluar()
        Dim sql As String = "SELECT TOP 1 * FROM [dbo].[barang_keluar] ORDER BY no_keluar DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            LblNoKeluar.Text = "00001"
        Else
            LblNoKeluar.Text = Format(Microsoft.VisualBasic.Right(dr.Item("no_keluar"), 5) + 1, "00000")
        End If
        koneksi.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM [dbo].[penjualan] WHERE faktur = '" + ListBox1.Text + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            LblNamaCustomer.Text = dr.Item("nama")
            DTPTanggal.Value = dr.Item("tanggal")
            Dim sql2 As String = "SELECT * FROM [dbo].[customer] WHERE nama = '" + LblNamaCustomer.Text + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            If dr2.HasRows Then
                LblKodeCustomer.Text = dr2.Item("kode_customer")
            End If

            Dim sql3 As String = "SELECT [dbo].[detail_jual].kode_barang, [dbo].[detail_jual].nama_barang, jumlah, [dbo].[barang].stok FROM [dbo].[detail_jual], [dbo].[barang] WHERE detail_jual.faktur = '" + ListBox1.Text + "' AND [dbo].[detail_jual].kode_barang = [dbo].[barang].kode_barang"
            Dim cmd3 As New OdbcCommand With {
                .CommandText = sql3,
                .Connection = koneksi3
            }
            koneksi3.Open()
            Dim dr3 As OdbcDataReader
            dr3 = cmd3.ExecuteReader
            While dr3.Read
                Call TampilGrid()
                Call LebarData()
                Dim stok_akhir As String = dr3.Item("stok") - dr3.Item("jumlah")
                TblBarangKeluar.Rows.Add(dr3.Item("kode_barang"), dr3.Item("nama_barang"), dr3.Item("stok"), dr3.Item("jumlah"), stok_akhir)
            End While
            Call JumlahKeluar()
            koneksi3.Close()
            koneksi2.Close()
        End If
        koneksi.Close()
    End Sub

    Private Sub TampilFaktur()
        Dim sql As String = "SELECT faktur FROM [dbo].[penjualan]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ListBox1.Items.Clear()
        While dr.Read
            ListBox1.Items.Add(dr.Item("faktur"))
        End While
        koneksi.Close()
    End Sub

    Private Sub CreateTable()
        TblBarangKeluar.Columns.Add("Kode Barang", Type.GetType("System.String"))
        TblBarangKeluar.Columns.Add("Nama Barang", Type.GetType("System.String"))
        TblBarangKeluar.Columns.Add("Stok", Type.GetType("System.String"))
        TblBarangKeluar.Columns.Add("Jumlah Keluar", Type.GetType("System.String"))
        TblBarangKeluar.Columns.Add("Stok Akhir", Type.GetType("System.String"))
    End Sub

    Private Sub LebarData()
        DGV.Columns(0).Width = 127
        DGV.Columns(1).Width = 205
        DGV.Columns(2).Width = 127
        DGV.Columns(3).Width = 127
        DGV.Columns(4).Width = 127
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If ListBox1.Text = "" Then
            MsgBox("Data tidak boleh kosong!", MsgBoxStyle.Exclamation)
        Else
            Dim no_keluar, tanggal, faktur, kode_customer, nama_customer, jumlah_keluar, nama_karyawan As String

            no_keluar = LblNoKeluar.Text
            tanggal = DTPTanggal.Value.ToString("dd MMMM yyyy")
            faktur = ListBox1.SelectedValue
            kode_customer = LblKodeCustomer.Text
            nama_customer = LblNamaCustomer.Text
            jumlah_keluar = LblJumlahBarangKeluar.Text
            nama_karyawan = MenuUtama.Panel2.Text
            Dim save As String = "INSERT INTO [dbo].[barang_keluar] VALUES('" + no_keluar + "', '" + faktur + "', '" + tanggal + "', '" + jumlah_keluar + "', '" + nama_customer + "', '" + nama_karyawan + "')"
            Dim cmd As New OdbcCommand With {
                .CommandText = save,
                .Connection = koneksi
            }
            koneksi.Open()
            cmd.ExecuteNonQuery()
            koneksi.Close()

            For x As Integer = 0 To DGV.Rows.Count - 2
                Dim kode_barang, nama_barang, stok, keluar, stok_akhir As String
                kode_barang = DGV.Rows(x).Cells(0).Value
                nama_barang = DGV.Rows(x).Cells(1).Value
                stok = DGV.Rows(x).Cells(2).Value
                keluar = DGV.Rows(x).Cells(3).Value
                stok_akhir = DGV.Rows(x).Cells(4).Value

                Dim simpan As String = "INSERT INTO [dbo].[detail_keluar] VALUES('" + no_keluar + "', '" + faktur + "', '" + kode_barang + "', '" + nama_barang + "', '" + stok + "', '" + keluar + "', '" + stok_akhir + "')"
                Dim cmd2 As New OdbcCommand With {
                    .CommandText = simpan,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd2.ExecuteNonQuery()
                koneksi.Close()

                Dim ubah As String = "UPDATE [dbo].[barang] SET stok = '" + stok_akhir + "' WHERE kode_barang = '" + kode_barang + "'"
                Dim cmd3 As New OdbcCommand With {
                    .CommandText = ubah,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd3.ExecuteNonQuery()
                koneksi.Close()
            Next

            Bersihkan()
            MsgBox("Data berhasil di tambahkan.", MsgBoxStyle.Information)
            MsgBox("Okk Rekk!")
        End If
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Bersihkan()
    End Sub

    Private Sub TampilGrid()
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Call Bersihkan()
        MenuUtama.Show()
        Me.Close()
    End Sub

    Private Sub JumlahKeluar()
        Dim hitung As Integer = 0
        For baris As Integer = 0 To DGV.Rows.Count - 1
            hitung = hitung + DGV.Rows(baris).Cells(3).Value
            LblJumlahBarangKeluar.Text = hitung
        Next
    End Sub

    Private Sub Bersihkan()
        LblNamaCustomer.Text = ""
        LblKodeCustomer.Text = ""
        TblBarangKeluar.Rows.Clear()
        LblJumlahBarangKeluar.Text = 0
    End Sub
End Class