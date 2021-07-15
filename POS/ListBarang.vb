Imports System.Data.Odbc
Public Class ListBarang
    Const DSN = "DSN=db_pos"
    Dim koneksi As OdbcConnection
    Dim TblBarang As New DataTable("Table")

    Private Sub ListBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        DGVBarang.DataSource = Nothing
        DGVBarang.DataSource = TblBarang
        Call CreateTable()
        Call LoadTable()
        Call TampilGrid()
        Call Lebar()
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

    Private Sub TampilGrid()
        DGVBarang.Columns(4).DefaultCellStyle.Format = "#, ###"
        DGVBarang.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBarang.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBarang.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVBarang.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TblBarang.Rows.Clear()
        '================================
        Dim sql As String = "SELECT * FROM [dbo].[barang] WHERE nama_barang LIKE'%" + TextBox1.Text + "%'"
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

        If TextBox1.Text = "" Then
            TblBarang.Rows.Clear()
            LoadTable()
        End If
    End Sub

    Private Sub Lebar()
        DGVBarang.Columns(1).Width = 200
    End Sub

    'Private Sub TotalHarga()
    '    Dim hitung As Integer = 0
    '    For baris As Integer = 0 To Penjualan.DGV.Rows.Count - 1
    '        hitung = hitung + Penjualan.DGV.Rows(baris).Cells(4).Value
    '        Penjualan.LblTotalHarga = hitung
    '    Next
    'End Sub

    'Private Sub TotalBarang()
    '    Dim hitung As Integer
    '    For baris As Integer = 0 To Penjualan.DGV.Rows.Count - 1
    '        hitung = hitung + Penjualan.DGV.Rows(baris).Cells(3).Value
    '        Penjualan.LblTotalBarang = hitung
    '    Next
    'End Sub

    'Private Sub DGVBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVBarang.CellContentClick
    'Penjualan.DGV.Rows.Add(DGVBarang.Rows(e.RowIndex).Cells(0).Value, DGVBarang.Rows(e.RowIndex).Cells(1).Value, DGVBarang.Rows(e.RowIndex).Cells(4).Value, 1, 1 * DGVBarang.Rows(e.RowIndex).Cells(4).Value)
    'For barisatas As Integer = 0 To Penjualan.DGV.Rows.Count - 1
    '    For barisbawah As Integer = barisatas + 1 To Penjualan.DGV.Rows.Count - 1
    '        If Penjualan.DGV.Rows(barisbawah).Cells(0).Value = Penjualan.DGV.Rows(barisatas).Cells(0) Then
    '            Penjualan.DGV.Rows(barisatas).Cells(3).Value = Penjualan.DGV.Rows(barisatas).Cells(3).Value + 1
    '            Penjualan.DGV.Rows(barisatas).Cells(4).Value = Penjualan.DGV.Rows(barisatas).Cells(2).Value * Penjualan.DGV.Rows(barisatas).Cells(3).Value
    '            Penjualan.DGV.Rows.RemoveAt(barisbawah)
    '            Exit Sub
    '        End If
    '    Next
    'Next
    'End Sub

    Private Sub DGVBarang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVBarang.CellClick
        Penjualan.DGV.Rows.Add(DGVBarang.Rows(e.RowIndex).Cells(0).Value, DGVBarang.Rows(e.RowIndex).Cells(1).Value, DGVBarang.Rows(e.RowIndex).Cells(4).Value, 1, 1 * DGVBarang.Rows(e.RowIndex).Cells(4).Value)
    End Sub

End Class