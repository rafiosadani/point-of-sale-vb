Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class LaporanPiutang
    Const DSN = "DSN=db_pos"
    Dim koneksi As OdbcConnection
    Private Sub LaporanPiutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        Call TampilFaktur()
    End Sub

    Private Sub TampilFaktur()
        Dim sql As String = "SELECT * FROM [dbo].[piutang]"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        ListFaktur.Items.Clear()
        While dr.Read
            ListFaktur.Items.Add(dr.Item("noterima"))
        End While
        koneksi.Close()
    End Sub

    Private Sub ListFaktur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListFaktur.SelectedIndexChanged
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\terimapiutang.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({piutang.noterima}) = '" + ListFaktur.Text + "'"
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan1_Click(sender As Object, e As EventArgs) Handles BtnTampilkan1.Click
        Dim rpt2 As New ReportDocument
        rpt2.Load("C:\Users\User\source\repos\POS\POS\terimapiutang.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({piutang.tanggal_terima}) = '" + DTPHarian.Text + "'"
        CRV.ReportSource = rpt2
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan2_Click(sender As Object, e As EventArgs) Handles BtnTampilkan2.Click
        Dim rpt3 As New ReportDocument
        rpt3.Load("C:\Users\User\source\repos\POS\POS\terimapiutang.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Totext({piutang.tanggal_terima}) >= '" + DTPSatu.Text + "' AND Totext({piutang.tanggal_terima}) <= '" + DTPDua.Text + "'"
        CRV.ReportSource = rpt3
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTampilkan3_Click(sender As Object, e As EventArgs) Handles BtnTampilkan3.Click
        Dim rpt4 As New ReportDocument
        rpt4.Load("C:\Users\User\source\repos\POS\POS\terimapiutang.rpt")
        CRV.ReportSource = Nothing
        CRV.SelectionFormula = "Month({piutang.tanggal_terima}) = '" + Month(DTPBulanan.Text) + "')" And "Year({piutang.tanggal_terima}) = '" + Year(DTPBulanan.Text) + "'"
        CRV.ReportSource = rpt4
        CRV.RefreshReport()
    End Sub
End Class