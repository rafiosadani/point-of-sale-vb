Imports System.Data.Odbc
Public Class BarangMasuk
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2, koneksi3 As OdbcConnection
    Dim TBlBarangMasuk As New DataTable("Table")
    Dim satu As Integer
    Dim faktur, dua As String

    Private Sub BarangMasuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        koneksi3 = New OdbcConnection(DSN)
        DTPTanggal.Format = DateTimePickerFormat.Custom
        Call NoMasuk()
        Call TampilFaktur()
    End Sub

    Private Sub NoMasuk()
        Dim sql As String = "SELECT TOP 1 no_masuk FROM [dbo].[barang_masuk] ORDER BY no_masuk DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            satu = 1
            dua = "0000" + Convert.ToString(satu)
            faktur = dua
        ElseIf dr.HasRows Then
            Dim s As String
            s = dr.Item("no_masuk")
            satu = s.Substring(s.Length - 5) + 1
            If satu >= 10 Then
                dua = "000" + Convert.ToString(satu)
                faktur = dua
            ElseIf satu >= 100 Then
                dua = "00" + Convert.ToString(satu)
                faktur = dua
            ElseIf satu >= 1000 Then
                dua = "0" + Convert.ToString(satu)
                faktur = dua
            ElseIf satu >= 10000 Then
                dua = Convert.ToString(satu)
                faktur = dua
            Else
                dua = "0000" + Convert.ToString(satu)
                faktur = dua
            End If
        End If
        LblNoMasuk.Text = faktur
        koneksi.Close()
    End Sub

    Private Sub TampilFaktur()
        Dim sql As String = "SELECT faktur FROM [dbo].[pembelian]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ComboFaktur.Items.Clear()
        While dr.Read
            ComboFaktur.Items.Add(dr.Item("faktur"))
        End While
        koneksi.Close()
    End Sub

    Private Sub Bersihkan()
        ComboFaktur.Text = ""
        LblKodeDistributor.Text = ""
        LblNamaDistributor.Text = ""
        DGV.Rows.Clear()
        LblbarangMasuk.Text = 0
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If ComboFaktur.Text = "" Then
            MsgBox("Data tidak boleh kosong!", MsgBoxStyle.Exclamation)
        Else
            Dim no_masuk, faktur, tanggal, jumlah_masuk, nama, nama_karyawan As String
            no_masuk = LblNoMasuk.Text
            faktur = ComboFaktur.Text
            tanggal = DTPTanggal.Value.ToString("dd MMMM yyyy")
            jumlah_masuk = LblbarangMasuk.Text
            nama = LblNamaDistributor.Text
            nama_karyawan = MenuUtama.Panel2.Text

            Dim save As String = "INSERT INTO [dbo].[barang_masuk] VALUES('" + no_masuk + "', '" + faktur + "', '" + tanggal + "', '" + jumlah_masuk + "', '" + nama + "', '" + nama_karyawan + "')"
            Dim cmd As New OdbcCommand With {
                .CommandText = save,
                .Connection = koneksi
            }
            koneksi.Open()
            cmd.ExecuteNonQuery()
            koneksi.Close()

            For baris As Integer = 0 To DGV.Rows.Count - 2
                Dim kode_barang, nama_barang, stok_awal, masuk, stok_akhir As String

                kode_barang = DGV.Rows(baris).Cells(0).Value
                nama_barang = DGV.Rows(baris).Cells(1).Value
                stok_awal = DGV.Rows(baris).Cells(2).Value
                masuk = DGV.Rows(baris).Cells(3).Value
                stok_akhir = DGV.Rows(baris).Cells(4).Value

                Dim simpan As String = "INSERT INTO [dbo].[detail_masuk] VALUES('" + no_masuk + "', '" + faktur + "', '" + kode_barang + "', '" + nama_barang + "', '" + stok_awal + "', '" + masuk + "', '" + stok_akhir + "')"
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
            MsgBox("Data Berhasil di tambahkan.", MsgBoxStyle.Information)
            MsgBox("Oke Slurr")
        End If
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Bersihkan()
    End Sub

    Private Sub BtbKembali_Click(sender As Object, e As EventArgs) Handles BtbKembali.Click
        Call Bersihkan()
        MenuUtama.Show()
        Me.Close()
    End Sub

    Private Sub ComboFaktur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboFaktur.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM [dbo].[pembelian] WHERE faktur = '" + ComboFaktur.Text + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            LblNamaDistributor.Text = dr.Item("nama")
            Dim query As String = "SELECT * FROM [dbo].[distributor] WHERE nama = '" + LblNamaDistributor.Text + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = query,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            If dr2.HasRows Then
                LblKodeDistributor.Text = dr2.Item("kode_distributor")
            End If

            Dim sql2 As String = "SELECT [dbo].[detail_beli].kode_barang, [dbo].[detail_beli].nama_barang, jumlah, [dbo].[barang].stok FROM [dbo].[detail_beli], [dbo].[barang] WHERE [dbo].[detail_beli].faktur = '" + ComboFaktur.Text + "' AND [dbo].[detail_beli].kode_barang = [dbo].[barang].kode_barang"
            Dim cmd3 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi3
            }
            koneksi3.Open()
            Dim dr3 As OdbcDataReader
            dr3 = cmd3.ExecuteReader
            While dr3.Read
                Dim stokakhir As String = dr3.Item("stok") + dr3.Item("jumlah")
                DGV.Rows.Add(dr3.Item("kode_barang"), dr3.Item("nama_barang"), dr3.Item("stok"), dr3.Item("jumlah"), stokakhir)
            End While
            Call TotalBarang()
            koneksi3.Close()
            koneksi2.Close()
        End If
        koneksi.Close()
    End Sub

    Private Sub TotalBarang()
        Dim hitung As Integer = 0
        For baris As Integer = 0 To DGV.Rows.Count - 1
            hitung = hitung + DGV.Rows(baris).Cells(3).Value
            LblbarangMasuk.Text = hitung
        Next
    End Sub
End Class