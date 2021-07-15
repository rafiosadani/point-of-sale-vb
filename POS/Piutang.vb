Imports System.Data.Odbc
Public Class Piutang
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2, koneksi3 As OdbcConnection

    Private Sub Piutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        koneksi3 = New OdbcConnection(DSN)
        Call TampilFaktur()
        Call NomorOto()
    End Sub

    Private Sub TampilFaktur()
        Dim sql As String = "SELECT * FROM [dbo].[penjualan] WHERE status_jual = 'BELUM LUNAS'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi2
        }
        koneksi2.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ListBox1.Items.Clear()
        While dr.Read
            ListBox1.Items.Add(dr.Item("faktur"))
        End While
        koneksi2.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM [dbo].[penjualan] WHERE faktur = '" + ListBox1.Text + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi3
        }
        koneksi3.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            LblTotalBarang.Text = dr.Item("jumlah_barang")
            LblStatus.Text = dr.Item("status_jual")
            LblCara.Text = dr.Item("cara_jual")
            LblTanggalJual.Text = dr.Item("tanggal")
            LblBayarAwal.Text = dr.Item("dibayar")
            LblPiutang.Text = dr.Item("kurang")
            LblTotalHarga.Text = dr.Item("total_harga")
            LblNamaCustomer.Text = dr.Item("nama")
            LblJatuhTempo.Text = dr.Item("jatuh_tempo")

            Dim sql2 As String = "SELECT * FROM [dbo].[customer] WHERE nama = '" + dr.Item("nama") + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            dr2.Read()
            If dr2.HasRows Then
                LblKodeCustomer.Text = dr2.Item("kode_customer")
            End If
            koneksi2.Close()
        End If
        koneksi3.Close()
        TxtTerimaPiutang.Select()
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Bersihkan()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Call Bersihkan()
        Me.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If LblStatus.Text = "" Then
            MsgBox("Data tidak boleh kosong!", MsgBoxStyle.Exclamation)
        Else
            Dim status, cara As String
            Dim piutang As Integer
            Dim noterima, tanggal_terima, faktur, tanggal, kode_customer, nama_customer As String
            Dim jumlah_barang, dibayar_awal, total_harga, terima_piutang, kembali As Integer
            piutang = LblPiutang.Text
            status = LblStatus.Text
            cara = LblCara.Text

            Dim sql As String = "UPDATE [dbo].[penjualan] SET kurang = " + piutang.ToString + ", status_jual = '" + status + "', cara_jual = '" + cara + "' WHERE faktur = '" + ListBox1.Text + "'"
            Dim cmd As New OdbcCommand With {
                .CommandText = sql,
                .Connection = koneksi2
            }
            koneksi2.Open()
            cmd.ExecuteNonQuery()
            koneksi2.Close()

            If LblStatus.Text = "LUNAS" Then
                noterima = LblNoTerima.Text
                tanggal_terima = DTP.Value.ToString("dd MMMM yyyy")
                faktur = ListBox1.Text
                tanggal = LblTanggalJual.Text
                kode_customer = LblKodeCustomer.Text
                nama_customer = LblNamaCustomer.Text
                jumlah_barang = LblTotalBarang.Text
                dibayar_awal = LblBayarAwal.Text
                total_harga = LblTotalHarga.Text
                terima_piutang = TxtTerimaPiutang.Text
                kembali = LblKembali.Text

                Dim sql2 As String = "INSERT INTO [dbo].[piutang] VALUES('" + noterima + "', '" + tanggal_terima.ToString + "', '" + faktur + "', " + jumlah_barang.ToString + ", '" + status + "', '" + cara + "', '" + tanggal + "', " + dibayar_awal.ToString + ", " + piutang.ToString + ", " + total_harga.ToString + ", " + terima_piutang.ToString + ", " + kembali.ToString + ",'" + kode_customer + "', '" + nama_customer + "')"
                Dim cmd2 As New OdbcCommand With {
                    .CommandText = sql2,
                    .Connection = koneksi2
                }
                koneksi2.Open()
                cmd2.ExecuteNonQuery()
                koneksi2.Close()
            End If

            MsgBox("Data berhasil di simpan.", MsgBoxStyle.Information)
            Call Bersihkan()
            Call TampilFaktur()
        End If
    End Sub

    Private Sub NomorOto()
        Dim sql As String = "SELECT * FROM [dbo].[piutang]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            LblNoTerima.Text = "TP" + Format(Now, "yyMMdd") + "001"
        Else
            If Microsoft.VisualBasic.Mid(dr.Item("noterima"), 3, 6) <> Format(Now, "yyMMdd") Then
                LblNoTerima.Text = "TP" + Format(Now, "yyMMdd") + "001"
            Else
                LblNoTerima.Text = Microsoft.VisualBasic.Right(dr.Item("noterima"), 9) + 1
                LblNoTerima.Text = "TP" + LblNoTerima.Text
            End If
        End If
    End Sub

    Private Sub Bersihkan()
        LblTotalBarang.Text = ""
        LblStatus.Text = ""
        LblCara.Text = ""
        LblTanggalJual.Text = ""
        LblBayarAwal.Text = ""
        LblPiutang.Text = 0
        LblNamaCustomer.Text = ""
        LblKodeCustomer.Text = ""
        LblTotalHarga.Text = ""
        LblKembali.Text = 0
        TxtTerimaPiutang.Text = ""
        LblJatuhTempo.Text = ""
    End Sub

    Private Sub TxtTerimaPiutang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTerimaPiutang.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then 'ENTER
            If Val(TxtTerimaPiutang.Text) < Val(LblPiutang.Text) Then
                LblPiutang.Text = Val(LblPiutang.Text) - Val(TxtTerimaPiutang.Text)
                MsgBox("Sisa Piutang adalah Rp. " + LblPiutang.Text + "", MsgBoxStyle.Exclamation)
                LblKembali.Text = 0
                BtnSimpan.Focus()
            ElseIf Val(TxtTerimaPiutang.Text) = Val(LblPiutang.Text) Then
                LblPiutang.Text = 0
                LblStatus.Text = "LUNAS"
                LblCara.Text = "CASH"
                LblKembali.Text = 0
                MsgBox("Hutang Lunas", MsgBoxStyle.Information)
                BtnSimpan.Focus()
            ElseIf Val(TxtTerimaPiutang.Text) > Val(LblPiutang.Text) Then
                LblStatus.Text = "LUNAS"
                LblCara.Text = "CASH"
                LblKembali.Text = Val(TxtTerimaPiutang.Text) - Val(LblPiutang.Text)
                MsgBox("Uang Kembali Rp. " + LblKembali.Text + "")
                MsgBox("Hutang Lunas", MsgBoxStyle.Information)
                LblPiutang.Text = 0
                BtnSimpan.Focus()
            End If
        End If
    End Sub
End Class