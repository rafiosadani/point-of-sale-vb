Public Class Index
    Private Sub BtnMasuk_Click(sender As Object, e As EventArgs) Handles BtnMasuk.Click
        FormLogin.Show()
        Me.Hide()
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs)
        FormKaryawan.Show()
        Me.Hide()
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If MsgBox("Apakah anda yakin ingin keluar?", MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
            Application.Exit()
        ElseIf MsgBoxResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub Index_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnKaryawanBaru_Click(sender As Object, e As EventArgs) Handles BtnKaryawanBaru.Click
        KaryawanBaru.Show()
        Me.Hide()
    End Sub
End Class