Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.Odbc
Public Class LaporanPembelian
    Const DSN = "DSN=db_pos"
    Dim koneksi As OdbcConnection

    Private Sub LaporanPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        TampilFaktur()
    End Sub

    Private Sub BtnTampilkan1_Click(sender As Object, e As EventArgs) Handles BtnTampilkan1.Click
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\pembelianumum.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({pembelian.tanggal}) = '" + DTPHarian.Text + "'"
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan2_Click(sender As Object, e As EventArgs) Handles BtnTampilkan2.Click
        Dim rpt1 As New ReportDocument
        rpt1.Load("C:\Users\User\source\repos\POS\POS\pembelianumum.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({pembelian.tanggal}) >= '" + DTPSatu.Text + "' AND Totext({pembelian.tanggal}) <= '" + DTPDua.Text + "'"
        CRV.ReportSource = rpt1
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan3_Click(sender As Object, e As EventArgs) Handles BtnTampilkan3.Click
        Dim rpt2 As New ReportDocument
        rpt2.Load("C:\Users\User\source\repos\POS\POS\pembelianumum.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Month({pembelian.tanggal}) = '" + Month(DTPBulanan.Value) + "' AND year({pembelian.tanggal})= '" + Year(DTPBulanan.Value) + "'"
        CRV.ReportSource = rpt2
        CRV.RefreshReport()
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
        ListFaktur.Items.Clear()
        While dr.Read
            ListFaktur.Items.Add(dr.Item("faktur"))
        End While
        koneksi.Close()
    End Sub

    Private Sub ListFaktur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListFaktur.SelectedIndexChanged
        Dim rpt3 As New ReportDocument
        rpt3.Load("C:\Users\User\source\repos\POS\POS\pembelianumum.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "totext({pembelian.faktur}) = '" + ListFaktur.Text + "'"
        CRV.ReportSource = rpt3
        CRV.RefreshReport()
    End Sub
End Class