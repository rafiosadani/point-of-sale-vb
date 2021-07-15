Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.Odbc
Public Class LaporanPenjualan
    Const DSN = "DSN=db_pos"
    Dim koneksi As OdbcConnection

    Private Sub LaporanPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        Call TampilFaktur()
    End Sub

    Private Sub TampilFaktur()
        Dim sql As String = "SELECT * FROM [dbo].[penjualan]"
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

    Private Sub BtnTampilkan1_Click(sender As Object, e As EventArgs) Handles BtnTampilkan1.Click
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\penjualanumum.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({penjualan.tanggal}) = '" + DTPHarian.Text + "'"
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan2_Click(sender As Object, e As EventArgs) Handles BtnTampilkan2.Click
        Dim rpt2 As New ReportDocument
        rpt2.Load("C:\Users\User\source\repos\POS\POS\penjualanumum.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({penjualan.tanggal}) >= '" + DTPSatu.Text + "' AND Totext({penjualan.tanggal}) <= '" + DTPDua.Text + "'"
        CRV.ReportSource = rpt2
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan3_Click(sender As Object, e As EventArgs) Handles BtnTampilkan3.Click
        Dim rpt3 As New ReportDocument
        rpt3.Load("C:\Users\User\source\repos\POS\POS\penjualanumum.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Month({penjualan.tanggal}) = '" + Month(DTPBulanan.Text) + "' AND Year({penjualan.tanggal}) = '" + Year(DTPBulanan.Text) + "'"
        CRV.ReportSource = rpt3
        CRV.RefreshReport()
    End Sub

    Private Sub ListFaktur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListFaktur.SelectedIndexChanged
        Dim rpt4 As New ReportDocument
        rpt4.Load("C:\Users\User\source\repos\POS\POS\penjualanumum.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({penjualan.faktur}) = '" + ListFaktur.Text + "'"
        CRV.ReportSource = rpt4
        CRV.RefreshReport()
    End Sub
End Class