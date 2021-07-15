Imports System.Data.Odbc
Public Class Hutang
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2, koneksi3 As OdbcConnection

    Private Sub Hutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        koneksi3 = New OdbcConnection(DSN)
        Call NoBayar()
        Call TampilFaktur()
    End Sub

    Private Sub NoBayar()
        Dim sql As String = "SELECT * FROM [dbo].[hutang]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If Not dr.HasRows Then
            LblNoBayar.Text = "TH" + Format(Now, "yyMMdd") + "001"
        Else
            If Microsoft.VisualBasic.Mid(dr.Item("nobayar"), 3, 6) <> Format(Now, "yyMMdd") Then
                LblNoBayar.Text = "TH" + Format(Now, "yyMMdd") + "001"
            Else
                LblNoBayar.Text = Microsoft.VisualBasic.Right(dr.Item("nobayar"), 9) + 1
                LblNoBayar.Text = "TH" + LblNoBayar.Text
            End If
        End If
        koneksi.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM [dbo].[pembelian] WHERE faktur = '" + ListBox1.Text + "'"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
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
            LblBayarAwal.Text = dr.Item("dibayar")
            LblHutang.Text = dr.Item("kurang")
            LblTotalBarang.Text = dr.Item("jumlah_barang")
            LblTotalHarga.Text = dr.Item("total_harga")
            LblNamaDistributor.Text = dr.Item("nama")
            LblJatuhTempo.Text = dr.Item("jatuh_tempo")

            Dim sql2 As String = "SELECT * FROM [dbo].[distributor] WHERE nama = '" + dr.Item("nama") + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = sql2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            Dim dr2 As OdbcDataReader
            dr2 = cmd2.ExecuteReader
            If dr2.Read Then
                LblKodeDistributor.Text = dr2.Item("kode_distributor")
            End If
            koneksi2.Close()
        End If
        koneksi.Close()
        TxtBayarHutang.Select()
    End Sub

    Private Sub TampilFaktur()
        Dim sql As String = "SELECT * FROM [dbo].[pembelian] WHERE status_beli = 'BELUM LUNAS'"
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

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub TxtBayarHutang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBayarHutang.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then 'ENTER
            If Val(TxtBayarHutang.Text) < Val(LblHutang.Text) Then
                LblHutang.Text = Val(LblHutang.Text) - Val(TxtBayarHutang.Text)
                MsgBox("Sisa hutang adalah Rp. " + LblHutang.Text + "", MsgBoxStyle.Exclamation)
                LblKembali.Text = 0
                BtnSimpan.Focus()
            ElseIf Val(TxtBayarHutang.Text) = Val(LblHutang.Text) Then
                LblHutang.Text = 0
                LblStatus.Text = "LUNAS"
                LblCara.Text = "CASH"
                LblKembali.Text = 0
                MsgBox("Hutang Lunas", MsgBoxStyle.Information)
                BtnSimpan.Focus()
            ElseIf Val(TxtBayarHutang.Text) > Val(LblHutang.Text) Then
                LblStatus.Text = "LUNAS"
                LblCara.Text = "CASH"
                LblKembali.Text = Val(TxtBayarHutang.Text) - Val(LblHutang.Text)
                MsgBox("Uang Kembali Rp. " + LblKembali.Text + "")
                MsgBox("Hutang Lunas", MsgBoxStyle.Information)
                LblHutang.Text = 0
                BtnSimpan.Focus()
            End If
        End If
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Call Kosongkan()
        Me.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If LblStatus.Text = "" Then
            MsgBox("Data tidak boleh kosong!", MsgBoxStyle.Exclamation)
        Else
            Dim nobayar, tanggal_bayar, faktur, status, cara, tanggal, kode_distributor, nama_distributor As String
            Dim jumlah_barang, dibayar_awal, hutang, total_harga, bayar_hutang, kembali As Integer

            nobayar = LblNoBayar.Text
            tanggal_bayar = DTP.Value.ToString("dd MMMM yyyy")
            faktur = ListBox1.Text
            status = LblStatus.Text
            cara = LblCara.Text
            tanggal = LblTanggalBeli.Text
            kode_distributor = LblKodeDistributor.Text
            nama_distributor = LblNamaDistributor.Text
            jumlah_barang = LblTotalBarang.Text
            dibayar_awal = LblBayarAwal.Text
            hutang = LblHutang.Text
            total_harga = LblTotalHarga.Text
            bayar_hutang = TxtBayarHutang.Text
            kembali = LblKembali.Text

            Dim s As String = "UPDATE [dbo].[pembelian] SET status_beli = '" + LblStatus.Text + "', cara_beli = '" + LblCara.Text + "', kurang =" + LblHutang.Text + " WHERE faktur = '" + ListBox1.Text + "'"
            Dim c As New OdbcCommand With {
                .CommandText = s,
                .Connection = koneksi2
            }
            koneksi2.Open()
            c.ExecuteNonQuery()
            koneksi2.Close()

            If LblStatus.Text = "LUNAS" Or LblCara.Text = "CASH" Then
                Dim simpan As String = "INSERT INTO [dbo].[hutang] VALUES('" + nobayar + "', '" + tanggal_bayar.ToString + "', '" + faktur + "', " + jumlah_barang.ToString + ", '" + status + "', '" + cara + "', '" + tanggal + "', " + dibayar_awal.ToString + ", " + hutang.ToString + ", " + total_harga.ToString + ", " + bayar_hutang.ToString + ", " + kembali.ToString + ", '" + kode_distributor + "', '" + nama_distributor + "')"
                Dim cmd As New OdbcCommand With {
                    .CommandText = simpan,
                    .Connection = koneksi3
                }
                koneksi3.Open()
                cmd.ExecuteNonQuery()
                koneksi3.Close()
            End If

            MsgBox("Data berhasil di simpan", MsgBoxStyle.Information)
            Call Kosongkan()
            Call TampilFaktur()
        End If
    End Sub

    Private Sub Kosongkan()
        LblStatus.Text = ""
        LblCara.Text = ""
        LblTanggalBeli.Text = ""
        LblBayarAwal.Text = ""
        LblHutang.Text = 0
        TxtBayarHutang.Text = ""
        LblTotalBarang.Text = ""
        LblNamaDistributor.Text = ""
        LblKodeDistributor.Text = ""
        LblTotalHarga.Text = ""
        LblKembali.Text = 0
        LblJatuhTempo.Text = ""
    End Sub
End Class