Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class LaporanHutang
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    Private Sub LaporanHutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        Call TampilFaktur()
    End Sub

    Private Sub ListFaktur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListFaktur.SelectedIndexChanged
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\bayarhutang.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({hutang.nobayar}) = '" + ListFaktur.Text + "'"
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan1_Click(sender As Object, e As EventArgs) Handles BtnTampilkan1.Click
        Dim rpt2 As New ReportDocument
        rpt2.Load("C:\Users\User\source\repos\POS\POS\bayarhutang.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({hutang.tanggal_bayar}) = '" + DTPHarian.Text + "'"
        CRV.ReportSource = rpt2
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan2_Click(sender As Object, e As EventArgs) Handles BtnTampilkan2.Click
        Dim rpt3 As New ReportDocument
        rpt3.Load("C:\Users\User\source\repos\POS\POS\bayarhutang.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({hutang.tanggal_bayar}) >= '" + DTPSatu.Text + "' AND Totext({hutang.tanggal_bayar}) <= '" + DTPDua.Text + "'"
        CRV.ReportSource = rpt3
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan3_Click(sender As Object, e As EventArgs) Handles BtnTampilkan3.Click
        Dim rpt4 As New ReportDocument
        rpt4.Load("C:\Users\User\source\repos\POS\POS\bayarhutang.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "month({hutang.tanggal_bayar}) = (" & Month(DTPBulanan.Text) & ") and year({hutang.tanggal_bayar}) = (" & Year(DTPBulanan.Text) & ")"
        CRV.ReportSource = rpt4
        CRV.RefreshReport()
    End Sub

    Private Sub TampilFaktur()
        Dim sql As String = "SELECT * FROM [dbo].[hutang]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ListFaktur.Items.Clear()
        While dr.Read
            ListFaktur.Items.Add(dr.Item("nobayar"))
        End While
        koneksi.Close()
    End Sub
End Class