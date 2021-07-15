Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Returpenjualan
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2, koneksi3 As OdbcConnection
    Dim TblRetur As New DataTable("Table")

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblJam.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub Returpenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi3 = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = TblRetur
        Call ReturJual()
        Call FakturJual()
        Call CreateTable()
        Call Lebar()
        Call TampilGrid()
        ComboFaktur.Select()
    End Sub

    Private Sub ReturJual()
        Dim sql As String = "SELECT * FROM [dbo].[returjual] ORDER BY returjual DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi3
        }
        koneksi3.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            LblNoReturJual.Text = "RJ" + Format(Now, "yyMMdd") + "001"
        Else
            If Microsoft.VisualBasic.Mid(dr.Item("returjual"), 3, 6) <> Format(Now, "yyMMdd") Then
                LblNoReturJual.Text = "RJ" + Format(Now, "yyMMdd") + "001"
            Else
                LblNoReturJual.Text = Microsoft.VisualBasic.Right(dr.Item("returjual"), 9) + 1
                LblNoReturJual.Text = "RJ" + LblNoReturJual.Text
            End If
        End If
        koneksi3.Close()
    End Sub

    Private Sub ComboFaktur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboFaktur.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM [dbo].[penjualan]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi2
        }
        koneksi2.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            LblStatus.Text = dr.Item("status_jual")
            LblCara.Text = dr.Item("cara_jual")
            LblTanggalJual.Text = dr.Item("tanggal")
            LblJatuhTempo.Text = dr.Item("jatuh_tempo")
            LblHutang.Text = dr.Item("kurang")

            Dim sql2 As String = "SELECT [dbo].[detail_jual].faktur, [dbo].[detail_jual].kode_barang, [dbo].[detail_jual].nama_barang, [dbo].[detail_jual].jumlah, [dbo].[barang].kode_barang FROM [dbo].[detail_jual], [dbo].[barang] WHERE [dbo].[detail_jual].faktur = '" + ComboFaktur.Text + "' AND [dbo].[detail_jual].kode_barang = [dbo].[barang].kode_barang"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi3
            }
            koneksi3.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            While dr2.Read
                TblRetur.Rows.Add(dr2.Item("kode_barang"), dr2.Item("nama_barang"), dr2.Item("jumlah"), 1)
            End While
            koneksi3.Close()
        End If
        koneksi2.Close()
        Call TampilGrid()
        Call BarangRetur()
    End Sub

    Private Sub FakturJual()
        Dim sql As String = "SELECT * FROM [dbo].[penjualan]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi2
        }
        koneksi2.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ComboFaktur.Items.Clear()
        While dr.Read
            ComboFaktur.Items.Add(dr.Item("faktur"))
        End While
        koneksi2.Close()
    End Sub

    Private Sub CreateTable()
        TblRetur.Columns.Add("Kode Barang", Type.GetType("System.String"))
        TblRetur.Columns.Add("Nama Barang", Type.GetType("System.String"))
        TblRetur.Columns.Add("Jumlah Jual", Type.GetType("System.String"))
        TblRetur.Columns.Add("Jumlah Retur", Type.GetType("System.String"))
        TblRetur.Columns.Add("Alasan", Type.GetType("System.String"))
    End Sub

    Private Sub Kosongkan()
        ComboFaktur.Text = ""
        LblStatus.Text = ""
        LblCara.Text = ""
        LblTanggalJual.Text = ""
        LblJatuhTempo.Text = ""
        LblJumlahRetur.Text = ""
        LblHutang.Text = 0
        TblRetur.Rows.Clear()
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub BarangRetur()
        Dim hitung As Integer
        For baris As Integer = 0 To DataGridView1.Rows.Count - 1
            hitung = hitung + DataGridView1.Rows(baris).Cells(3).Value
            LblJumlahRetur.Text = hitung
        Next
    End Sub

    Private Sub Lebar()
        DataGridView1.Columns(1).Width = 194
    End Sub

    Private Sub TampilGrid()
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Call Kosongkan()
        Me.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If ComboFaktur.Text = "" Then
            MsgBox("Data tidak boleh kosong!", MsgBoxStyle.Exclamation)
        Else
            Dim returjual, tanggalretur, faktur, status, cara, tanggajual, jatuhtempo As String
            Dim jumlahretur, hutang As Integer

            returjual = LblNoReturJual.Text
            tanggalretur = DTPTanggal.Text
            faktur = ComboFaktur.Text
            status = LblStatus.Text
            cara = LblCara.Text
            tanggajual = LblTanggalJual.Text
            jatuhtempo = LblJatuhTempo.Text
            jumlahretur = LblJumlahRetur.Text
            hutang = LblHutang.Text

            Dim save As String = "INSERT INTO [dbo].[returjual] VALUES('" + returjual + "', '" + tanggalretur + "', '" + faktur + "', " + jumlahretur.ToString + ", " + hutang.ToString + ", '" + status + "', '" + cara + "', '" + tanggajual + "', '" + jatuhtempo + "')"
            Dim cmd As New OdbcCommand With {
                .CommandText = save,
                .Connection = koneksi2
            }
            koneksi2.Open()
            cmd.ExecuteNonQuery()
            koneksi2.Close()

            For baris As Integer = 0 To DataGridView1.Rows.Count - 2
                Dim kode, nama, alasan As String
                Dim jumlah, jumlah_retur As Integer

                kode = DataGridView1.Rows(baris).Cells(0).Value
                nama = DataGridView1.Rows(baris).Cells(1).Value
                jumlah = DataGridView1.Rows(baris).Cells(2).Value
                jumlah_retur = DataGridView1.Rows(baris).Cells(3).Value
                alasan = DataGridView1.Rows(baris).Cells(4).Value

                Dim sql As String = "INSERT INTO [dbo].[detail_retur_jual] VALUES('" + returjual + "', '" + kode + "', '" + nama + "', " + jumlah.ToString + ", " + jumlah_retur.ToString + ", '" + alasan + "')"
                Dim cmd2 As New OdbcCommand With {
                    .CommandText = sql,
                    .Connection = koneksi3
                }
                koneksi3.Open()
                cmd2.ExecuteNonQuery()
                koneksi3.Close()
            Next

            MsgBox("Data berhasil di tambahkan.", MsgBoxStyle.Information)
            Call Kosongkan()
            ComboFaktur.Select()
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.ColumnIndex = 3 Then
            For x As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(x).Cells(3).Value > DataGridView1.Rows(x).Cells(2).Value Then
                    MsgBox("Jumlah retur tidak boleh melebihi jumlah beli", MsgBoxStyle.Exclamation)
                    SendKeys.Send("{UP}")
                    DataGridView1.Rows(x).Cells(3).Value = 1
                End If
            Next
            Call BarangRetur()
        End If
    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then 'ESC
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Call BarangRetur()
        End If

        If e.KeyChar = Chr(13) Then 'ENTER
            BtnSimpan.Focus()
        End If
    End Sub
End Class