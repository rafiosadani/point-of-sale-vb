Imports System.Data.Odbc
Public Class CustomerForm
    Const DSN = "DSN=db_pos"
    Dim koneksi, koneksi2 As OdbcConnection
    Dim status As String
    Dim TblCustomer As New DataTable("Table")
    Dim satu As Integer
    Dim dua, kode_customer As String

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblJam.Text = Format(Now, "hh:mm:ss tt")
        LblTanggal.Text = Format(Now, "dddd, dd MMMM yyyy")
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Awal()
        Bersihkan()
        LebarData()
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Awal()
        Bersihkan()
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub Awal()
        DGV.DataSource = Nothing
        DGV.DataSource = TblCustomer
        TxtKode.Enabled = False
        TxtNama.Enabled = False
        TxtAlamat.Enabled = False
        TxtTelepon.Enabled = False
        TxtEmail.Enabled = False

        BtnTambah.Enabled = True
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = False
        BtnHapus2.Enabled = False
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
    End Sub

    Private Sub Bersihkan()
        TxtKode.Text = ""
        TxtNama.Text = ""
        TxtAlamat.Text = ""
        TxtTelepon.Text = ""
        TxtEmail.Text = ""
    End Sub

    Private Sub CreateTable()
        TblCustomer.Columns.Add("Kode Customer", Type.GetType("System.String"))
        TblCustomer.Columns.Add("Nama Customer", Type.GetType("System.String"))
        TblCustomer.Columns.Add("Alamat", Type.GetType("System.String"))
        TblCustomer.Columns.Add("Telepon", Type.GetType("System.String"))
        TblCustomer.Columns.Add("Email", Type.GetType("System.String"))
    End Sub

    Private Sub Tampilkan()
        TxtNama.Enabled = True
        TxtAlamat.Enabled = True
        TxtTelepon.Enabled = True
        TxtEmail.Enabled = True

        BtnUbah.Enabled = False
        BtnTambah.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = True
        BtnBatal.Enabled = True
        BtnKembali.Enabled = True
        BtnHapus2.Enabled = False
    End Sub

    Private Sub CustomerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = New OdbcConnection(DSN)
        Awal()
        CreateTable()
        LebarData()
        LoadTable()
    End Sub

    Private Sub LoadTable()
        Dim query As String = "SELECT * FROM [dbo].[customer]"
        Dim cmd As New OdbcCommand With {
            .CommandText = query,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            LebarData()
            TblCustomer.Rows.Add(dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString)
        End While
        DGV.Refresh()
        koneksi.Close()
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        Tampilkan()
        TxtNama.Select()
        status = "Tambah"
        Dim sql As String = "SELECT TOP 1 kode_customer FROM [dbo].[customer] ORDER BY kode_customer DESC"
        Dim cmd As New OdbcCommand With {
            .CommandText = sql,
            .Connection = koneksi
        }
        koneksi.Open()
        Dim dr As OdbcDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            satu = 1
            dua = "CUS000" + Convert.ToString(satu)
            kode_customer = dua
        ElseIf dr.HasRows Then
            Dim s As String
            s = dr(0)
            satu = s.Substring(s.Length - 4) + 1
            If satu >= 10 Then
                dua = "CUS00" + Convert.ToString(satu)
                kode_customer = dua
            ElseIf satu >= 100 Then
                dua = "CUS0" + Convert.ToString(satu)
                kode_customer = dua
            ElseIf satu >= 1000 Then
                dua = "CUS" + Convert.ToString(satu)
                kode_customer = dua
            Else
                dua = "CUS000" + Convert.ToString(satu)
                kode_customer = dua
            End If
        End If
        TxtKode.Text = kode_customer
        dr.Close()
        cmd.Dispose()
        koneksi.Close()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If status = "Tambah" Then
            If TxtNama.Text = "" Or TxtAlamat.Text = "" Or TxtTelepon.Text = "" Then
                MsgBox("Data tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Else
                Dim nama, alamat, telp, email As String

                nama = TxtNama.Text
                alamat = TxtAlamat.Text
                telp = TxtTelepon.Text
                email = TxtEmail.Text

                Dim sql As String = "INSERT INTO [dbo].[customer] VALUES('" + TxtKode.Text + "', '" + nama + "', '" + alamat + "', '" + telp + "', '" + email + "')"
                Dim cmd As New OdbcCommand With {
                    .CommandText = sql,
                    .Connection = koneksi
                }
                koneksi.Open()
                cmd.ExecuteNonQuery()
                koneksi.Close()

                Awal()
                Bersihkan()
                TblCustomer.Rows.Clear()
                LoadTable()
                MsgBox("Data berhasil ditambahkan.", MsgBoxStyle.Information)
            End If
        ElseIf status = "Ubah" Then
            If TxtNama.Text = "" Or TxtAlamat.Text = "" Or TxtTelepon.Text = "" Then
                MsgBox("Data gagal di ubah.", MsgBoxStyle.Exclamation)
            Else
                Dim query As String = "UPDATE [dbo].[customer] SET nama = '" + TxtNama.Text + "', alamat = '" + TxtAlamat.Text + "', no_telp = '" + TxtTelepon.Text + "', email = '" + TxtEmail.Text + "' WHERE kode_customer = '" + TxtKode.Text + "'"
                Dim cmd2 As New OdbcCommand With {
                    .CommandText = query,
                    .Connection = koneksi
                }
                koneksi.Open()
                If MsgBox("Apakah anda yakin mau merubah data ini?", MsgBoxStyle.YesNo, "Ubah") = MsgBoxResult.Yes Then
                    cmd2.ExecuteNonQuery()
                    koneksi.Close()
                    MsgBox("Data berhasil di ubah", MsgBoxStyle.Information)
                ElseIf MsgBoxResult.No Then
                    MsgBox("Data gagal di ubah", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                koneksi.Close()

                Awal()
                Bersihkan()
                TblCustomer.Rows.Clear()
                LoadTable()
            End If
        End If
    End Sub

    Private Sub BtnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        Tampilkan()
        TxtNama.Select()
        status = "Ubah"
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        Tampilkan()
        BtnHapus2.Enabled = True
        BtnSimpan.Enabled = False
        TxtNama.Select()
        status = "Hapus"
    End Sub

    Private Sub BtnHapus2_Click(sender As Object, e As EventArgs) Handles BtnHapus2.Click
        If status = "Hapus" Then
            Dim sql As String = "DELETE FROM [dbo].[customer] WHERE kode_customer = '" + TxtKode.Text + "'"
            Dim cmd As New OdbcCommand With {
                .CommandText = sql,
                .Connection = koneksi
            }
            koneksi.Open()
            If MsgBox("Apakah anda yakin mau menghapus data ini?", MsgBoxStyle.YesNo, "Hapus") = MsgBoxResult.Yes Then
                cmd.ExecuteNonQuery()
                koneksi.Close()
                MsgBox("Data berhasil di hapus.", MsgBoxStyle.Information)
            ElseIf MsgBoxResult.No Then
                MsgBox("Data tidak jadi di hapus.", MsgBoxStyle.Exclamation)
            End If
            koneksi.Close()
            Awal()
            Bersihkan()
            TblCustomer.Rows.Clear()
            LoadTable()
        End If
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Awal()
        Bersihkan()
        LebarData()
    End Sub

    Private Sub DGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellClick
        BtnUbah.Enabled = True
        BtnHapus.Enabled = True
        BtnTambah.Enabled = False

        TxtKode.Text = DGV.CurrentRow.Cells(0).Value
        TxtNama.Text = DGV.CurrentRow.Cells(1).Value
        TxtAlamat.Text = DGV.CurrentRow.Cells(2).Value
        TxtTelepon.Text = DGV.CurrentRow.Cells(3).Value
        TxtEmail.Text = DGV.CurrentRow.Cells(4).Value
    End Sub

    Private Sub LebarData()
        DGV.Columns(0).Width = 120
        DGV.Columns(1).Width = 180
        DGV.Columns(2).Width = 120
        DGV.Columns(3).Width = 120
        DGV.Columns(4).Width = 180
    End Sub

    Private Sub TxtTelepon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTelepon.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
        End If
    End Sub
End Class