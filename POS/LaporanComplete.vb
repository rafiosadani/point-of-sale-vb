Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class LaporanComplete
    Private Sub BtnUser_Click(sender As Object, e As EventArgs) Handles BtnUser.Click
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\User.rpt")
        CRV.ReportSource = Nothing
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub BtnKaryawan_Click(sender As Object, e As EventArgs) Handles BtnKaryawan.Click
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\karyawan.rpt")
        CRV.ReportSource = Nothing
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub BtnBarang_Click(sender As Object, e As EventArgs) Handles BtnBarang.Click
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\data_barang.rpt")
        CRV.ReportSource = Nothing
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub BtnDistributor_Click(sender As Object, e As EventArgs) Handles BtnDistributor.Click
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\distributor.rpt")
        CRV.ReportSource = Nothing
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        Me.Close()
    End Sub

    Private Sub BtnCustomer_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\customer.rpt")
        CRV.ReportSource = Nothing
        CRV.ReportSource = rpt
        CRV.RefreshReport()
    End Sub

    Private Sub LaporanComplete_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MenuUtama.Show()
        Me.Hide()
    End Sub
End Class