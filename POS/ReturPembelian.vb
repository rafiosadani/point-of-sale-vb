Imports System.Data.Odbc
Public Class ReturPembelian
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblJam.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub ReturPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        Call FakturBeli()
        Call TampilFaktur()
        ComboFaktur.Select()
    End Sub

    Private Sub FakturBeli()
        Dim sql As String = "SELECT * FROM [dbo].[returbeli] ORDER BY returbeli DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            LblNoReturBeli.Text = "RB" + Format(Now, "yyMMdd") + "001"
        Else
            If Microsoft.VisualBasic.Mid(dr.Item("returbeli"), 3, 6) <> Format(Now, "yyMMdd") Then
                LblNoReturBeli.Text = "RB" + Format(Now, "yyMMdd") + "001"
            Else
                LblNoReturBeli.Text = Microsoft.VisualBasic.Right(dr.Item("returbeli"), 9) + 1
                LblNoReturBeli.Text = "RB" + LblNoReturBeli.Text
            End If
        End If
        koneksi.Close()
    End Sub

    Private Sub TampilGrid()
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub ComboFaktur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboFaktur.SelectedIndexChanged
        Dim tampil As String = "SELECT * FROM [dbo].[pembelian] WHERE faktur = '" + ComboFaktur.Text + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = tampil,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            LblStatus.Text = dr.Item("status_beli")
            LblCara.Text = dr.Item("cara_beli")
            LblTanggalBeli.Text = dr.Item("tanggal")
            LblJatuhTempo.Text = dr.Item("jatuh_tempo")
            LblHutang.Text = dr.Item("kurang")

            Dim sql As String = "SELECT [dbo].[detail_beli].faktur, [dbo].[detail_beli].kode_barang, [dbo].[detail_beli].nama_barang, [dbo].[detail_beli].jumlah, [dbo].[barang].kode_barang FROM [dbo].[detail_beli], [dbo].[barang] WHERE [dbo].[detail_beli].kode_barang = [dbo].[barang].kode_barang AND [dbo].[detail_beli].faktur = '" + ComboFaktur.Text + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            DGV.Rows.Clear()
            While dr2.Read
                DGV.Rows.Add(dr2.Item("kode_barang"), dr2.Item("nama_barang"), dr2.Item("jumlah"), 1)
            End While
            koneksi2.Close()
        End If
        koneksi.Close()
        Call TampilGrid()
        Call BarangRetur()
    End Sub

    Private Sub TampilFaktur()
        Dim sql As String = "SELECT * FROM [dbo].[pembelian]"
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

    Private Sub BarangRetur()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.Rows.Count - 1
            x = x + DGV.Rows(baris).Cells(3).Value
            LblJumlahRetur.Text = x
        Next
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 3 Then
            For baris As Integer = 0 To DGV.Rows.Count - 1
                If DGV.Rows(baris).Cells(2).Value < DGV.Rows(baris).Cells(3).Value Then
                    MsgBox("Jumlah retur tidak boleh melebihi jumlah beli", MsgBoxStyle.Exclamation)
                    SendKeys.Send("{UP}")
                    DGV.Rows(baris).Cells(3).Value = 1
                End If
            Next
            Call BarangRetur()
        End If
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Bersihkan()
    End Sub

    Private Sub Bersihkan()
        LblStatus.Text = ""
        LblCara.Text = ""
        LblTanggalBeli.Text = ""
        LblJatuhTempo.Text = ""
        ComboFaktur.Text = ""
        LblJumlahRetur.Text = ""
        LblHutang.Text = 0
        DGV.Rows.Clear()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Call Bersihkan()
        Me.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If ComboFaktur.Text = "" Then
            MsgBox("Data tidak boleh kosong!", MsgBoxStyle.Exclamation)
        Else
            Dim returbeli, tanggalretur, faktur, status, cara, tanggal, jatuhtempo As String
            Dim barangretur, hutang As Integer

            returbeli = LblNoReturBeli.Text
            tanggalretur = DTPTanggal.Text
            faktur = ComboFaktur.Text
            status = LblStatus.Text
            cara = LblCara.Text
            tanggal = LblTanggalBeli.Text
            jatuhtempo = LblJatuhTempo.Text
            barangretur = LblJumlahRetur.Text
            hutang = LblHutang.Text

            Dim simpan As String = "INSERT INTO [dbo].[returbeli] VALUES('" + returbeli + "', '" + tanggalretur + "',  '" + faktur + "'," + barangretur.ToString + ", " + hutang.ToString + ", '" + status + "', '" + cara + "', '" + tanggal + "', '" + jatuhtempo + "')"
            Dim cmd As New OdbcCommand With {
                .CommandText = simpan,
                .Connection = koneksi
            }
            koneksi.Open()
            cmd.ExecuteNonQuery()
            koneksi.Close()

            For a As Integer = 0 To DGV.Rows.Count - 2
                Dim kode, nama, alasan As String
                Dim jumlah, jumlah_retur As Integer

                kode = DGV.Rows(a).Cells(0).Value
                nama = DGV.Rows(a).Cells(1).Value
                jumlah = DGV.Rows(a).Cells(2).Value
                jumlah_retur = DGV.Rows(a).Cells(3).Value
                alasan = DGV.Rows(a).Cells(4).Value

                Dim sql As String = "INSERT INTO [dbo].[detail_retur_beli] VALUES('" + returbeli + "', '" + kode + "', '" + nama + "', " + jumlah.ToString + ", " + jumlah_retur.ToString + ", '" + alasan + "')"
                Dim cmd2 As New OdbcCommand With {
                    .CommandText = sql,
                    .Connection = koneksi2
                }
                koneksi2.Open()
                cmd2.ExecuteNonQuery()
                koneksi2.Close()
            Next

            MsgBox("Data berhasil di tambahkan.", MsgBoxStyle.Information)
            Call Bersihkan()
            ComboFaktur.Select()
        End If

    End Sub

    Private Sub DGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGV.KeyPress
        If e.KeyChar = Chr(27) Then 'ESC
            DGV.Rows.Remove(DGV.CurrentRow)
            Call BarangRetur()
        End If

        If e.KeyChar = Chr(13) Then 'ENTER
            BtnSimpan.Focus()
        End If
    End Sub
End Class