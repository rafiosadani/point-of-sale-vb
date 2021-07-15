Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class MenuUtama
    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Load("panda.jpg")
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
    End Sub

    Private Sub BtnOut_Click(sender As Object, e As EventArgs) Handles BtnOut.Click
        If MsgBox("Apakah anda ingin Log Out Bos?", MsgBoxStyle.YesNo, "Keluar") = MsgBoxResult.Yes Then
            MsgBox("Terimakasih atas kunjungannya Bos (^.^) :)")
            Application.Restart()
            FormLogin.Show()
            Me.Hide()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If MsgBox("Apakah anda ingin keluar Bos?", MsgBoxStyle.YesNo, "Keluar") = MsgBoxResult.Yes Then
            MsgBox("Terimakasih atas kunjungannya Bos (^.^) :)")
            'TabControl1.SelectedTab = TabPage1
            'TabControl1.Refresh()
            'MenuStrip1.Refresh()
            Application.Exit()
            Me.Hide()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnUser_Click(sender As Object, e As EventArgs) Handles BtnUser.Click
        FormUser.Show()
    End Sub

    Private Sub BtnBarang_Click(sender As Object, e As EventArgs) Handles BtnBarang.Click
        BarangForm.Show()
    End Sub

    Private Sub BtnCustomer_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click
        CustomerForm.Show()
    End Sub

    Private Sub BtnDistributor_Click(sender As Object, e As EventArgs) Handles BtnDistributor.Click
        FormDistributor.Show()
    End Sub

    Private Sub BtnPenjualan_Click(sender As Object, e As EventArgs) Handles BtnPenjualan.Click
        Penjualan.Show()
    End Sub

    Private Sub BtnPembelian_Click(sender As Object, e As EventArgs) Handles BtnPembelian.Click
        Pembelian.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        If MsgBox("Apakah anda ingin Log Out Bos?", MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
            MsgBox("Terimakasih atas kunjungannya :)")
            Application.Restart()
            FormLogin.Show()
            Me.Hide()
        ElseIf MsgBoxResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub KeluarAplikasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarAplikasiToolStripMenuItem.Click
        If MsgBox("Apakah anda ingin Keluar Bos?", MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
            MsgBox("Terimakasih atas kunjungannya :)")
            'TabControl1.SelectedTab = TabPage1
            'TabControl1.Refresh()
            'MenuStrip1.Refresh()
            Application.Exit()
            Me.Hide()
        ElseIf MsgBoxResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        Pembelian.Show()
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        Penjualan.Show()
    End Sub

    Private Sub KaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KaryawanToolStripMenuItem.Click
        FormKaryawan.Show()
    End Sub

    Private Sub BtnKaryawan_Click(sender As Object, e As EventArgs) Handles BtnKaryawan.Click
        FormKaryawan.Show()
    End Sub

    Private Sub LaporanDataBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Dim rpt As New ReportDocument
        rpt.Load("C:\Users\User\source\repos\POS\POS\data_barang.rpt")
        Cetakan.Show()
        Cetakan.CRV.ReportSource = Nothing
        Cetakan.CRV.ReportSource = rpt
        Cetakan.CRV.RefreshReport()
        Cetakan.CRV.Refresh()
    End Sub

    Private Sub DataKaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim kry As New ReportDocument
        kry.Load("C:\Users\User\source\repos\POS\POS\karyawan.rpt")
        Cetakan.Show()
        Cetakan.CRV.ReportSource = Nothing
        Cetakan.CRV.ReportSource = kry
        Cetakan.CRV.RefreshReport()
        Cetakan.CRV.Refresh()
    End Sub

    Private Sub BtnBarangMasuk_Click(sender As Object, e As EventArgs) Handles BtnBarangMasuk.Click
        BarangMasuk.Show()
    End Sub

    Private Sub BtnBarangKeluar_Click(sender As Object, e As EventArgs) Handles BtnBarangKeluar.Click
        BarangKeluar.Show()
    End Sub

    Private Sub BtnComplete_Click(sender As Object, e As EventArgs) Handles BtnComplete.Click
        LaporanComplete.Show()
    End Sub

    Private Sub BtnReturPenjualan_Click(sender As Object, e As EventArgs) Handles BtnReturPenjualan.Click
        Returpenjualan.Show()
    End Sub

    Private Sub BtnReturPembelian_Click(sender As Object, e As EventArgs) Handles BtnReturPembelian.Click
        ReturPembelian.Show()
    End Sub

    Private Sub BtnBayarHutang_Click(sender As Object, e As EventArgs) Handles BtnBayarHutang.Click
        Hutang.Show()
    End Sub

    Private Sub BtnTerimaPiutang_Click(sender As Object, e As EventArgs) Handles BtnTerimaPiutang.Click
        Piutang.Show()
    End Sub

    Private Sub BtnHutang_Click(sender As Object, e As EventArgs) Handles BtnHutang.Click
        LaporanHutang.Show()
    End Sub

    Private Sub BtnPiutang_Click(sender As Object, e As EventArgs) Handles BtnPiutang.Click
        LaporanPiutang.Show()
    End Sub

    Private Sub LaporanPenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPenjualanToolStripMenuItem.Click
        LaporanPenjualan.Show()
    End Sub

    Private Sub LaporanPembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPembelianToolStripMenuItem.Click
        LaporanPembelian.Show()
    End Sub

    Private Sub HutangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HutangToolStripMenuItem.Click
        LaporanHutang.Show()
    End Sub

    Private Sub PihutangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PihutangToolStripMenuItem.Click
        LaporanPiutang.Show()
    End Sub

    Private Sub BayarHutangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BayarHutangToolStripMenuItem.Click
        Hutang.Show()
    End Sub

    Private Sub TerimaPiutangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerimaPiutangToolStripMenuItem.Click
        Piutang.Show()
    End Sub
End Class