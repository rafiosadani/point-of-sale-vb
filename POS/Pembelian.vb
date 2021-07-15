Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Pembelian
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    Dim status As String
    Dim TblPembelian As New DataTable("Table")
    Dim TblBarang As New DataTable("Table")
    Dim satu As Integer
    Dim dua, faktur As String

    Private Sub Pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        LblTanggal.Text = Format(Now, "dd MMMM yyyy")
        FakturOtomatis()
        TampilDistributor()
        DGVBarang.DataSource = Nothing
        DGVBarang.DataSource = TblBarang
        Call CreateTable()
        Call LoadTable()
        Call Lebar()
        Kosongkan()
    End Sub

    Private Sub Pembelian_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim query As String = "SELECT * FROM [dbo].[distributor] WHERE kode_distributor = '" + ComboBox1.Text + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = query,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            LblNamaDistributor.Text = dr.Item("nama")
        Else
            MsgBox("Kode Distributor tidak terdaftar", MsgBoxStyle.Exclamation)
        End If
        koneksi.Close()
    End Sub

    Private Sub FakturOtomatis()
        Dim sql As String = "SELECT TOP 1 faktur FROM [dbo].[pembelian] ORDER BY faktur DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            LblFaktur.Text = "FB" + Format(Now, "yyMMdd") + "0001"
        Else
            If Microsoft.VisualBasic.Mid(dr.Item("faktur"), 3, 6) <> Format(Now, "yyMMdd") Then
                LblFaktur.Text = "FB" + Format(Now, "yyMMdd") + "0001"
            Else
                LblFaktur.Text = Microsoft.VisualBasic.Right(dr.Item("faktur"), 10) + 1
                LblFaktur.Text = "FB" + LblFaktur.Text
            End If
        End If
        'If Not dr.HasRows Then
        '    satu = 1
        '    dua = "FK" & Format(Now, "yyMMdd") & "000" + Convert.ToString(satu)
        '    faktur = dua
        'ElseIf dr.HasRows Then
        '    Dim a As String
        '    a = dr(0)
        '    satu = a.Substring(a.Length - 4) + 1
        '    If satu >= 10 Then
        '        dua = "FK" & Format(Now, "yyMMdd") & "00" + Convert.ToString(satu)
        '        faktur = dua
        '    ElseIf satu >= 100 Then
        '        dua = "FK" & Format(Now, "yyMMdd") & "0" + Convert.ToString(satu)
        '        faktur = dua
        '    ElseIf satu >= 1000 Then
        '        dua = "FK" & Format(Now, "yyMMdd") + Convert.ToString(satu)
        '        faktur = dua
        '    Else
        '        dua = "FK" & Format(Now, "yyMMdd") & "000" + Convert.ToString(satu)
        '        faktur = dua
        '    End If
        'Else
        '    satu = 1
        '    dua = "FK" & Format(Now, "yyMMdd") & "000" + Convert.ToString(satu)
        '    faktur = dua
        'End If
        'LblFaktur.Text = faktur
        koneksi.Close()
    End Sub

    Private Sub TampilDistributor()
        Dim sql As String = "SELECT kode_distributor FROM [dbo].[distributor]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        While dr.Read
            ComboBox1.Items.Add(dr.Item("kode_distributor"))
        End While
        dr.Close()
        koneksi.Close()
    End Sub

    Private Sub CreateTable()
        TblBarang.Columns.Add("Kode Barang", Type.GetType("System.String"))
        TblBarang.Columns.Add("Nama Barang", Type.GetType("System.String"))
        TblBarang.Columns.Add("Satuan", Type.GetType("System.String"))
        TblBarang.Columns.Add("Kategori", Type.GetType("System.String"))
        TblBarang.Columns.Add("Harga Jual", Type.GetType("System.String"))
        TblBarang.Columns.Add("Stok", Type.GetType("System.String"))
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
            Lebar()
            TblBarang.Rows.Add(dr(1).ToString, dr(2).ToString, dr(7).ToString, dr(3).ToString, dr(6).ToString, dr(4).ToString)
        End While
        DGVBarang.Refresh()
        koneksi.Close()
    End Sub

    Private Sub DGVBarang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVBarang.CellClick
        Dim baris As Integer = DGV.Rows.Count - 1
        On Error Resume Next
        DGV.Rows.Add(DGVBarang.Rows(e.RowIndex).Cells(0).Value, DGVBarang.Rows(e.RowIndex).Cells(1).Value, DGVBarang.Rows(e.RowIndex).Cells(4).Value, 1, 1 * DGVBarang.Rows(e.RowIndex).Cells(4).Value)
        For i As Integer = 0 To DGV.RowCount - 1
            For j As Integer = i + 1 To DGV.RowCount - 1
                If DGV.Rows(i).Cells(0).Value = DGV.Rows(j).Cells(0).Value Then
                    DGV.Rows(i).Cells(3).Value = DGV.Rows(i).Cells(3).Value + 1
                    DGV.Rows(i).Cells(4).Value = DGV.Rows(i).Cells(2).Value * DGV.Rows(i).Cells(3).Value
                    DGV.Rows.RemoveAt(j)
                    Call TotalHarga()
                    Call TotalBarang()
                    Exit Sub
                End If
            Next
        Next
        DGV.Rows(baris).Cells(4).Value = DGV.Rows(baris).Cells(2).Value * DGV.Rows(baris).Cells(3).Value
        Call TotalBarang()
        Call TotalHarga()
        Call Barang()
    End Sub

    Private Sub TotalBarang()
        Dim hitung As Integer
        For baris As Integer = 0 To DGV.RowCount - 1
            hitung = hitung + DGV.Rows(baris).Cells(3).Value
            LblTotalBarang.Text = hitung
        Next
    End Sub

    Private Sub TxtCari_TextChanged(sender As Object, e As EventArgs) Handles TxtCari.TextChanged
        TblBarang.Rows.Clear()
        Dim sql As String = "SELECT * FROM [dbo].[barang] WHERE nama_barang Like'%" + TxtCari.Text + "%'"
                Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            TblBarang.Rows.Add(dr(1).ToString, dr(2).ToString, dr(7).ToString, dr(3).ToString, dr(6).ToString, dr(4).ToString)
        End While
        DGVBarang.Refresh()
        koneksi.Close()

        If TxtCari.Text = "" Then
            TblBarang.Rows.Clear()
            LoadTable()
        End If
    End Sub

    Private Sub TotalHarga()
        Dim hitung As Integer
        For baris As Integer = 0 To DGV.RowCount - 1
            hitung = hitung + DGV.Rows(baris).Cells(4).Value
            LblTotalHarga.Text = hitung
        Next
    End Sub

    Private Sub TxtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBayar.KeyPress
        If e.KeyChar = Chr(13) Then 'ENTER
            If Val(TxtBayar.Text) < Val(LblTotalHarga.Text) Then
                LblKembalian.Text = 0
                LblStatusBeli.Text = "BELUM LUNAS"
                LblCaraBeli.Text = "KREDIT"
                LblHutang.Text = Val(LblTotalHarga.Text) - Val(TxtBayar.Text)
                LblJatuhTempo.Text = LblTanggal.Text
                TxtTempo.Focus()
                Exit Sub
            ElseIf Val(TxtBayar.Text) = Val(LblTotalHarga.Text) Then
                LblKembalian.Text = 0
                LblStatusBeli.Text = "LUNAS"
                LblCaraBeli.Text = "TUNAI"
                LblHutang.Text = 0
                LblJatuhTempo.Text = LblTanggal.Text
                TxtTempo.Text = 0
                TxtTempo.Enabled = False
                BtnSimpan.Focus()
            ElseIf Val(TxtBayar.Text) > Val(LblTotalHarga.Text) Then
                LblKembalian.Text = Val(TxtBayar.Text) - Val(LblTotalHarga.Text)
                LblStatusBeli.Text = "LUNAS"
                LblCaraBeli.Text = "TUNAI"
                LblHutang.Text = 0
                LblJatuhTempo.Text = LblTanggal.Text
                TxtTempo.Enabled = False
                TxtTempo.Text = 0
                BtnSimpan.Focus()
            End If
        End If

        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
        End If
    End Sub

    Private Sub Lebar()
        DGVBarang.Columns(0).Width = 100
        DGVBarang.Columns(1).Width = 200
        DGVBarang.Columns(2).Width = 100
        DGVBarang.Columns(3).Width = 100
        DGVBarang.Columns(4).Width = 100
        DGVBarang.Columns(5).Width = 100
    End Sub

    Private Sub Barang()
        DGV.Columns(2).DefaultCellStyle.Format = "#, ###"
        DGV.Columns(4).DefaultCellStyle.Format = "#, ###"
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Kosongkan()
    End Sub

    Private Sub Kosongkan()
        ComboBox1.Text = ""
        LblNamaDistributor.Text = ""
        LblTotalHarga.Text = 0
        LblTotalBarang.Text = ""
        LblKembalian.Text = ""
        TxtBayar.Clear()
        DGV.Rows.Clear()
    End Sub

    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        'Kosongkan()
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If LblFaktur.Text = "" Or LblTanggal.Text = "" Or ComboBox1.Text = "" Or LblNamaDistributor.Text = "" Or TxtBayar.Text = "" Then
            MsgBox("Data tidak boleh kosong", MsgBoxStyle.Exclamation)
        Else
            Dim faktur, tanggal, kode_distributor, distributor, nama_karyawan As String
            Dim bayar, kembalian, jumlah_barang, total_harga
            Dim kode_barang, nama_barang As String
            Dim Harga, Jumlah, subtotal
            Dim status_beli, cara_beli, kurang, tempo, jatuh_tempo As String

            faktur = LblFaktur.Text
            tanggal = LblTanggal.Text
            kode_distributor = ComboBox1.Text
            distributor = LblNamaDistributor.Text
            bayar = TxtBayar.Text
            kembalian = LblKembalian.Text
            jumlah_barang = LblTotalBarang.Text
            total_harga = LblTotalHarga.Text
            nama_karyawan = MenuUtama.Panel2.Text
            status_beli = LblStatusBeli.Text
            cara_beli = LblCaraBeli.Text
            kurang = LblHutang.Text
            tempo = TxtTempo.Text
            jatuh_tempo = LblJatuhTempo.Text

            Dim sql = "INSERT INTO [dbo].[pembelian] VALUES('" + faktur + "', '" + tanggal + "', " + jumlah_barang.ToString + ", " + total_harga.ToString + ", " + bayar.ToString + ", " + kembalian.ToString + ", '" + distributor + "', '" + nama_karyawan + "', '" + status_beli + "', '" + cara_beli + "', " + kurang.ToString + ", " + tempo.ToString + ", '" + jatuh_tempo.ToString + "')"
            Dim cmd As New OdbcCommand With {
                .CommandText = sql,
                .Connection = koneksi
            }
            koneksi.Open()
            cmd.ExecuteNonQuery()
            koneksi.Close()


            For x As Integer = 0 To DGV.Rows.Count - 2
                kode_barang = DGV.Rows(x).Cells(0).Value
                nama_barang = DGV.Rows(x).Cells(1).Value
                Harga = DGV.Rows(x).Cells(2).Value
                Jumlah = DGV.Rows(x).Cells(3).Value
                subtotal = DGV.Rows(x).Cells(4).Value

                Dim sql2 = "INSERT INTO [dbo].[detail_beli] VALUES('" + faktur + "', '" + kode_barang + "', '" + nama_barang + "', " + Harga.ToString + ", " + Jumlah.ToString + ", " + subtotal.ToString + ")"
                Dim cmd2 As New OdbcCommand With {
                    .CommandText = sql2,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd2.ExecuteNonQuery()
                koneksi.Close()
            Next

            If MsgBox("Cetak Faktur", MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
                    Dim rpt As New ReportDocument

                    rpt.Load("C:\Users\User\source\repos\POS\POS\laporan.rpt")
                    Cetakan.Show()
                    Cetakan.CRV.ReportSource = Nothing
                    Cetakan.CRV.ReportSource = rpt
                    Cetakan.CRV.RefreshReport()
                ElseIf MsgBoxResult.No Then
                    Exit Sub
                End If
                MsgBox("Data berhasil disimpan", MsgBoxStyle.Information)
                Kosongkan()
            End If
    End Sub

    Private Sub DGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGV.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then 'ESC
            DGV.Rows.Remove(DGV.CurrentRow)
            Call TotalBarang()
            Call TotalHarga()
            Call Barang()
        End If

        If e.KeyChar = Chr(13) Then 'ENTER
            TxtBayar.Focus()
        End If
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 3 Then
            Try
                DGV.Rows(e.RowIndex).Cells(4).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
            Catch ex As Exception
                MsgBox("Harus Angka")
                SendKeys.Send("{UP}")
                DGV.Rows(e.RowIndex).Cells(3).Value = 1
                DGV.Rows(e.RowIndex).Cells(4).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
            End Try
        End If
        Call TotalHarga()
        Call TotalBarang()
        Call Barang()
    End Sub

    Private Sub TxtTempo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTempo.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim tambahhari As Integer = TxtTempo.Text
            LblJatuhTempo.Text = Format(DateAdd(DateInterval.Day, tambahhari, Today), "dd MMMM yyyy")
            BtnSimpan.Focus()
        End If
    End Sub
End Class