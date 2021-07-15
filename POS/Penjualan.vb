Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Penjualan
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    'Dim Barang As New ListBox
    Dim satu As Integer
    Dim dua, faktur As String

    Private Sub Penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP.Format = DateTimePickerFormat.Custom
        koneksi = New OdbcConnection(DSN)
        LblTanggal.Text = Format(Now, "dd MMMM yyyy")
        Call FakturOtomatis()
        Call TampilCustomer()
        Call TampilList()
    End Sub

    Private Sub ComboKode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboKode.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM [dbo].[customer] WHERE kode_customer = '" + ComboKode.Text + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            LblNamaCustomer.Text = dr.Item("nama")
        Else
            MsgBox("Kode Customer tidak terdaftar", MsgBoxStyle.Exclamation)
        End If
        koneksi.Close()
    End Sub

    Private Sub TotalHarga()
        Dim hitung As Integer = 0
        For baris As Integer = 0 To DGV.Rows.Count - 1
            hitung = hitung + DGV.Rows(baris).Cells(4).Value
            TxtTotalHarga.Text = hitung
        Next
    End Sub

    Private Sub TotalBarang()
        Dim hitung As Integer = 0
        For baris As Integer = 0 To DGV.Rows.Count - 1
            hitung = hitung + DGV.Rows(baris).Cells(3).Value
            LblTotalBarang.Text = hitung
        Next
    End Sub

    Private Sub TampilList()
        Dim sql As String = "SELECT * FROM [dbo].[barang]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ListBox1.Items.Clear()
        While dr.Read
            ListBox1.Items.Add(dr.Item("kode_barang") + Space(4) + dr.Item("nama_barang"))
        End While
        ListBox1.Refresh()
        koneksi.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim baris As Integer = DGV.Rows.Count - 1
        DGV.Focus()
        On Error Resume Next
        DGV.Rows.Add(Microsoft.VisualBasic.Left(ListBox1.Text, 8))
        For barisatas As Integer = 0 To DGV.Rows.Count - 1
            For barisbawah As Integer = barisatas + 1 To DGV.Rows.Count - 1
                If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then
                    DGV.Rows(barisatas).Cells(3).Value = DGV.Rows(barisatas).Cells(3).Value + 1
                    DGV.Rows(barisatas).Cells(4).Value = DGV.Rows(barisatas).Cells(2).Value * DGV.Rows(barisatas).Cells(3).Value
                    DGV.Rows.RemoveAt(barisbawah)
                    Call TotalHarga()
                    Call TotalBarang()
                    Exit Sub
                End If
            Next
        Next
        Dim sql As String = "SELECT * FROM [dbo].[barang] WHERE kode_barang = '" + DGV.Rows(baris).Cells(0).Value + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            DGV.Rows(baris).Cells(1).Value = dr.Item("nama_barang")
            DGV.Rows(baris).Cells(2).Value = dr.Item("harga_jual")
            DGV.Rows(baris).Cells(3).Value = 1
            DGV.Rows(baris).Cells(4).Value = DGV.Rows(baris).Cells(2).Value * DGV.Rows(baris).Cells(3).Value
        End If
        koneksi.Close()
        Call TotalHarga()
        Call TotalBarang()
        Call TampilGrid()
    End Sub

    Private Sub BtnSelengkapnya_Click(sender As Object, e As EventArgs)
        ListBarang.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ListBox1.Items.Clear()
        '=======================================
        Dim sql As String = "SELECT * FROM [dbo].[barang] WHERE nama_barang LIKE'%" + TextBox1.Text + "%'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            ListBox1.Items.Add(dr.Item("kode_barang") + Space(4) + dr.Item("nama_barang"))
        End While
        ListBox1.Refresh()
        koneksi.Close()

        If TextBox1.Text = "" Then
            ListBox1.Items.Clear()
            TampilList()
        End If
    End Sub

    Private Sub FakturOtomatis()
        Dim sql As String = "SELECT * FROM [dbo].[penjualan] ORDER BY faktur DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            LblFaktur.Text = "FJ" + Format(Now, "yyMMdd") + "0001"
        Else
            If Microsoft.VisualBasic.Mid(dr.Item("faktur"), 3, 6) <> Format(Now, "yyMMdd") Then
                LblFaktur.Text = "TP" + Format(Now, "yyMMdd") + "0001"
            Else
                LblFaktur.Text = Microsoft.VisualBasic.Right(dr.Item("faktur"), 10) + 1
                LblFaktur.Text = "FJ" + LblFaktur.Text
            End If
        End If

        'If Not dr.HasRows Then
        '    satu = 1
        '    dua = Format(Now, "yyMMdd") + "000" + Convert.ToString(satu)
        '    faktur = dua
        'ElseIf dr.HasRows Then
        '    Dim s As String
        '    s = dr(0)
        '    satu = s.Substring(s.Length - 4) + 1
        '    If satu >= 10 Then
        '        dua = Format(Now, "yyMMdd") + "00" + Convert.ToString(satu)
        '        faktur = dua
        '    ElseIf satu >= 100 Then
        '        dua = Format(Now, "yyMMdd") + "0" + Convert.ToString(satu)
        '        faktur = dua
        '    ElseIf satu >= 1000 Then
        '        dua = Format(Now, "yyMMdd") + Convert.ToString(satu)
        '        faktur = dua
        '    Else
        '        dua = Format(Now, "yyMMdd") + Convert.ToString(satu)
        '        faktur = dua
        '    End If
        'Else
        '    satu = 1
        '    dua = Format(Now, "yyMMdd") + "000" + Convert.ToString(satu)
        '    faktur = dua
        'End If
        'LblFaktur.Text = faktur
        koneksi.Close()
    End Sub

    Private Sub TampilCustomer()
        Dim sql As String = "SELECT * FROM [dbo].[customer]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ComboKode.Items.Clear()
        While dr.Read
            ComboKode.Items.Add(dr.Item("kode_customer"))
        End While
        koneksi.Close()
    End Sub

    Private Sub TxtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBayar.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(13) Then
            If Val(TxtBayar.Text) < Val(TxtTotalHarga.Text) Then
                LblCaraJual.Text = "CREDIT"
                LblKembalian.Text = 0
                LblKurang.Text = Val(TxtTotalHarga.Text) - Val(TxtBayar.Text)
                LblStatusJual.Text = "BELUM LUNAS"
                DTP.Focus()
                Exit Sub
            ElseIf Val(TxtBayar.Text) = Val(TxtTotalHarga.Text) Then
                LblCaraJual.Text = "CASH"
                LblKurang.Text = 0
                LblStatusJual.Text = "LUNAS"
                LblKembalian.Text = 0
                DTP.Enabled = False
                BtnSimpan.Focus()
            ElseIf Val(TxtBayar.Text) > Val(TxtTotalHarga.Text) Then
                LblCaraJual.Text = "CASH"
                LblKurang.Text = 0
                LblStatusJual.Text = "LUNAS"
                DTP.Enabled = False
                LblKembalian.Text = Val(TxtBayar.Text) - Val(TxtTotalHarga.Text)
                BtnSimpan.Focus()
            End If

            If Char.IsLetter(e.KeyChar) = True Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 3 Then
            Try
                DGV.Rows(e.RowIndex).Cells(4).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
            Catch ex As Exception
                MsgBox("Harus Angka", MsgBoxStyle.Exclamation)
                SendKeys.Send("{UP}")
                DGV.Rows(e.RowIndex).Cells(3).Value = 1
                DGV.Rows(e.RowIndex).Cells(4).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
            End Try
        End If
        Call TotalBarang()
        Call TotalHarga()
        Call TampilGrid()
    End Sub

    Private Sub TampilGrid()
        DGV.Columns(2).DefaultCellStyle.Format = "#, ###"
        DGV.Columns(4).DefaultCellStyle.Format = "#, ###"
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        'Call Kosongkan() 
        MenuUtama.Show()
        Me.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If ComboKode.Text = "" Then
            MsgBox("Kode Customer tidak boleh kosong!", MsgBoxStyle.Exclamation)
        Else
            Dim faktur, tanggal, jumlah_barang, total_harga, bayar, kembali, nama_customer, nama_karyawan As String
            Dim status_jual, cara_jual, kurang As String
            Dim jatuh_tempo

            faktur = LblFaktur.Text
            tanggal = LblTanggal.Text
            jumlah_barang = LblTotalBarang.Text
            total_harga = TxtTotalHarga.Text
            bayar = TxtBayar.Text
            kembali = LblKembalian.Text
            nama_customer = LblNamaCustomer.Text
            nama_karyawan = MenuUtama.Panel2.Text
            status_jual = LblStatusJual.Text
            cara_jual = LblCaraJual.Text
            kurang = LblKurang.Text
            jatuh_tempo = DTP.Value.ToString("dd MMMM yyyy")

            Dim sql As String = "INSERT INTO [dbo].[penjualan] VALUES('" + faktur + "', '" + tanggal + "', " + jumlah_barang.ToString + ", " + total_harga.ToString + ", " + bayar.ToString + ", " + kembali.ToString + ", '" + nama_customer + "', '" + nama_karyawan + "',  '" + status_jual + "', '" + cara_jual + "',  " + kurang.ToString + ", '" + jatuh_tempo.ToString + "')"
            Dim cmd As New OdbcCommand With {
                .CommandText = sql,
                .Connection = koneksi
            }
            koneksi.Open()
            cmd.ExecuteNonQuery()
            koneksi.Close()

            For i As Integer = 0 To DGV.Rows.Count - 2
                Dim kode_barang, nama_barang, harga, jumlah, subtotal As String
                kode_barang = DGV.Rows(i).Cells(0).Value
                nama_barang = DGV.Rows(i).Cells(1).Value
                harga = DGV.Rows(i).Cells(2).Value
                jumlah = DGV.Rows(i).Cells(3).Value
                subtotal = DGV.Rows(i).Cells(4).Value

                Dim sql2 As String = "INSERT INTO [dbo].[detail_jual] VALUES('" + faktur + "', '" + kode_barang + "', '" + nama_barang + "', '" + harga.ToString + "', '" + jumlah.ToString + "', '" + subtotal.ToString + "')"
                Dim cmd2 As New OdbcCommand With {
                    .CommandText = sql2,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd2.ExecuteNonQuery()
                koneksi.Close()
            Next

            If MsgBox("Mau Cetak Faktur?", MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
                Dim rpt As New ReportDocument
                rpt.Load("C:\Users\User\source\repos\POS\POS\faktur.rpt")
                Cetakan.Show()

                Cetakan.CRV.ReportSource = Nothing
                Cetakan.CRV.ReportSource = rpt
                Cetakan.CRV.RefreshReport()
                Cetakan.CRV.Refresh()
            ElseIf MsgBoxResult.No Then
                Exit Sub
            End If

            MsgBox("Data berhasil di tambahkan.", MsgBoxStyle.Information)
            Call Kosongkan()
        End If

    End Sub


    Private Sub DGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGV.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then 'ESC
            DGV.Rows.Remove(DGV.CurrentRow)
            Call TotalHarga()
            Call TotalBarang()
            Call TampilGrid()
        End If

        If e.KeyChar = Chr(13) Then 'ENTER
            TxtBayar.Focus()
        End If
    End Sub

    Private Sub Kosongkan()
        ComboKode.Text = ""
        LblNamaCustomer.Text = ""
        TxtTotalHarga.Text = 0
        LblTotalBarang.Text = ""
        TxtBayar.Clear()
        LblKembalian.Text = 0
        LblCaraJual.Text = ""
        LblStatusJual.Text = ""
        DGV.Rows.Clear()
    End Sub

    Private Sub DTP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTP.KeyPress
        If e.KeyChar = Chr(13) Then
            BtnSimpan.Focus()
        End If
    End Sub

    'Private Sub TxtTempo_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Dim tambahhari As Integer = TxtTempo.Text
    '        LblJatuhTempo.Text = Format(DateAdd(DateInterval.Day, tambahhari, Today), "dd/MM/yyyy")
    '        BtnSimpan.Focus()
    '    End If
    'End Sub
End Class