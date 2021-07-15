Imports System.Data.Odbc
Public Class FormEditKaryawan
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    Dim TblEdit As New DataTable("Table")
    Dim status As String
    Dim satu As Integer
    Dim dua, kode_karyawan As String

    Private Sub FormEditKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        koneksi2 = New OdbcConnection(DSN)
        CreateTable()
        Awal()
        LoadTable()
        LebarData()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblJam.Text = Format(Now, "hh:mm:ss tt")
        LblTanggal.Text = Format(Now, "dddd, dd MMM yyyy")
    End Sub

    Private Sub LebarData()
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).Width = 170
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 200
    End Sub

    Private Sub Awal()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = TblEdit
        TxtKode.Enabled = False
        TxtNama.Enabled = False
        TxtAlamat.Enabled = False
        TxtTelepon.Enabled = False
        TxtEmail.Enabled = False
        RadioL.Enabled = False
        RadioP.Enabled = False

        BtnUbah.Enabled = True
        BtnSimpan.Enabled = False
        BtnBatal.Enabled = False
        BtnKembali.Enabled = False

        TxtNama.Clear()
        TxtAlamat.Clear()
        TxtTelepon.Clear()
        TxtEmail.Clear()
        RadioL.Checked = False
        RadioP.Checked = False
        TxtPassword.Clear()
    End Sub

    Private Sub BtnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        TxtKode.Enabled = True
        TxtNama.Enabled = True
        TxtAlamat.Enabled = True
        TxtTelepon.Enabled = True
        TxtEmail.Enabled = True
        RadioL.Enabled = True
        RadioP.Enabled = True

        BtnUbah.Enabled = False
        BtnSimpan.Enabled = True
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        TxtNama.Select()
        status = "Ubah"
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TxtKode.Text = DataGridView1.CurrentRow.Cells(0).Value
        TxtNama.Text = DataGridView1.CurrentRow.Cells(1).Value
        If DataGridView1.CurrentRow.Cells(2).Value = "L" Then
            RadioL.Checked = True
        Else
            RadioP.Checked = True
        End If
        TxtAlamat.Text = DataGridView1.CurrentRow.Cells(3).Value
        TxtTelepon.Text = DataGridView1.CurrentRow.Cells(4).Value
        TxtEmail.Text = DataGridView1.CurrentRow.Cells(5).Value
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If status = "Ubah" Then
            Dim jenis_kelamin As String
            If RadioL.Checked = True Then
                jenis_kelamin = "L"
            Else
                jenis_kelamin = "P"
            End If

            Dim ubah As String = "UPDATE [dbo].[karyawan] SET nama_karyawan = '" + TxtNama.Text + "', jk = '" + jenis_kelamin + "', alamat = '" + TxtAlamat.Text + "', no_telp = '" + TxtTelepon.Text + "', email = '" + TxtEmail.Text + "' WHERE id_karyawan = '" + TxtKode.Text + "'"
            Dim cmd As New OdbcCommand With {
                .CommandText = ubah,
                .Connection = koneksi
            }
            koneksi.Open()
            Dim ubah2 As String = "UPDATE [dbo].[user] SET password = '" + TxtPassword.Text + "' WHERE username = '" + TxtKode.Text + "'"
            Dim cmd2 As New OdbcCommand With {
                .CommandText = ubah2,
                .Connection = koneksi2
            }
            koneksi2.Open()
            If MsgBox("Apakah anda yakin mau merubah data ini?", MsgBoxStyle.YesNo, "Ubah") = MsgBoxResult.Yes Then
                cmd.ExecuteNonQuery()
                koneksi.Close()
                cmd2.ExecuteNonQuery()
                koneksi2.Close()
                MsgBox("Data berhasil di ubah", MsgBoxStyle.Information)
            Else
                MsgBox("Data gagal di ubah", MsgBoxStyle.Exclamation)
            End If
            koneksi2.Close()
            koneksi.Close()

            Awal()
            TblEdit.Rows.Clear()
            LoadTable()
        End If
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Awal()
        LebarData()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Awal()
        LebarData()
        FormLogin.Show()
        Me.Hide()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Awal()
        LebarData()
        FormLogin.Show()
        Me.Hide()
    End Sub


    Private Sub CreateTable()
        TblEdit.Columns.Add("Kode Karyawan", Type.GetType("System.String"))
        TblEdit.Columns.Add("Nama Karyawan", Type.GetType("System.String"))
        TblEdit.Columns.Add("Jenis Kelamin", Type.GetType("System.String"))
        TblEdit.Columns.Add("Alamat", Type.GetType("System.String"))
        TblEdit.Columns.Add("Telepon", Type.GetType("System.String"))
        TblEdit.Columns.Add("Email", Type.GetType("System.String"))
    End Sub

    Private Sub LoadTable()
        Dim sql As String = "SELECT * FROM [dbo].[karyawan]"
        Dim cmd As New OdbcCommand With {
            .Connection = koneksi,
            .CommandText = sql
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read

            LebarData()
            TblEdit.Rows.Add(dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString)
        End While
        DataGridView1.Refresh()
        koneksi.Close()
    End Sub
End Class