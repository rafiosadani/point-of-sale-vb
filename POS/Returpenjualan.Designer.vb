<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Returpenjualan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Returpenjualan))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.LblHutang = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.BtnBatal = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblJumlahRetur = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblJam = New System.Windows.Forms.Label()
        Me.ComboFaktur = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblTanggalJual = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblJatuhTempo = New System.Windows.Forms.Label()
        Me.LblCara = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblNoReturJual = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DTPTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnKembali)
        Me.GroupBox4.Controls.Add(Me.LblHutang)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.BtnBatal)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.BtnSimpan)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.LblJumlahRetur)
        Me.GroupBox4.Location = New System.Drawing.Point(309, 252)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(652, 100)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'BtnKembali
        '
        Me.BtnKembali.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnKembali.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.Image = CType(resources.GetObject("BtnKembali.Image"), System.Drawing.Image)
        Me.BtnKembali.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnKembali.Location = New System.Drawing.Point(153, 16)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(75, 81)
        Me.BtnKembali.TabIndex = 2
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LblHutang
        '
        Me.LblHutang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblHutang.Location = New System.Drawing.Point(452, 59)
        Me.LblHutang.Name = "LblHutang"
        Me.LblHutang.Size = New System.Drawing.Size(130, 26)
        Me.LblHutang.TabIndex = 47
        Me.LblHutang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(436, 66)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(10, 13)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = ":"
        '
        'BtnBatal
        '
        Me.BtnBatal.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBatal.Image = CType(resources.GetObject("BtnBatal.Image"), System.Drawing.Image)
        Me.BtnBatal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBatal.Location = New System.Drawing.Point(78, 16)
        Me.BtnBatal.Name = "BtnBatal"
        Me.BtnBatal.Size = New System.Drawing.Size(75, 81)
        Me.BtnBatal.TabIndex = 1
        Me.BtnBatal.Text = "Batal"
        Me.BtnBatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBatal.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Location = New System.Drawing.Point(310, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 26)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "Hutang"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSimpan.Image = CType(resources.GetObject("BtnSimpan.Image"), System.Drawing.Image)
        Me.BtnSimpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSimpan.Location = New System.Drawing.Point(3, 16)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(75, 81)
        Me.BtnSimpan.TabIndex = 0
        Me.BtnSimpan.Text = "Simpan"
        Me.BtnSimpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Location = New System.Drawing.Point(310, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 26)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Jumlah Retur Barang"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(436, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 13)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = ":"
        '
        'LblJumlahRetur
        '
        Me.LblJumlahRetur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblJumlahRetur.Location = New System.Drawing.Point(452, 20)
        Me.LblJumlahRetur.Name = "LblJumlahRetur"
        Me.LblJumlahRetur.Size = New System.Drawing.Size(130, 26)
        Me.LblJumlahRetur.TabIndex = 35
        Me.LblJumlahRetur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Location = New System.Drawing.Point(309, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(652, 241)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Data Barang"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(7, 20)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(639, 213)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblJam)
        Me.GroupBox1.Controls.Add(Me.ComboFaktur)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LblTanggalJual)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblJatuhTempo)
        Me.GroupBox1.Controls.Add(Me.LblCara)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.LblNoReturJual)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.DTPTanggal)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblStatus)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 347)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'LblJam
        '
        Me.LblJam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJam.Location = New System.Drawing.Point(66, 292)
        Me.LblJam.Name = "LblJam"
        Me.LblJam.Size = New System.Drawing.Size(149, 23)
        Me.LblJam.TabIndex = 48
        Me.LblJam.Text = "00:00:00 AM"
        Me.LblJam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboFaktur
        '
        Me.ComboFaktur.FormattingEnabled = True
        Me.ComboFaktur.Location = New System.Drawing.Point(153, 94)
        Me.ComboFaktur.Name = "ComboFaktur"
        Me.ComboFaktur.Size = New System.Drawing.Size(128, 21)
        Me.ComboFaktur.TabIndex = 44
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(136, 97)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(10, 13)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = ":"
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Location = New System.Drawing.Point(10, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 26)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Faktur Jual"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTanggalJual
        '
        Me.LblTanggalJual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTanggalJual.Location = New System.Drawing.Point(152, 196)
        Me.LblTanggalJual.Name = "LblTanggalJual"
        Me.LblTanggalJual.Size = New System.Drawing.Size(130, 26)
        Me.LblTanggalJual.TabIndex = 41
        Me.LblTanggalJual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = ":"
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Location = New System.Drawing.Point(10, 196)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 26)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Tanggal Jual"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 26)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "No Retur Jual"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblJatuhTempo
        '
        Me.LblJatuhTempo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblJatuhTempo.Location = New System.Drawing.Point(152, 234)
        Me.LblJatuhTempo.Name = "LblJatuhTempo"
        Me.LblJatuhTempo.Size = New System.Drawing.Size(130, 26)
        Me.LblJatuhTempo.TabIndex = 34
        Me.LblJatuhTempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCara
        '
        Me.LblCara.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCara.Location = New System.Drawing.Point(152, 159)
        Me.LblCara.Name = "LblCara"
        Me.LblCara.Size = New System.Drawing.Size(130, 26)
        Me.LblCara.TabIndex = 33
        Me.LblCara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(136, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = ":"
        '
        'LblNoReturJual
        '
        Me.LblNoReturJual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNoReturJual.Location = New System.Drawing.Point(152, 16)
        Me.LblNoReturJual.Name = "LblNoReturJual"
        Me.LblNoReturJual.Size = New System.Drawing.Size(130, 26)
        Me.LblNoReturJual.TabIndex = 22
        Me.LblNoReturJual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(136, 241)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = ":"
        '
        'DTPTanggal
        '
        Me.DTPTanggal.CustomFormat = "dd MMMM yyyy"
        Me.DTPTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTanggal.Location = New System.Drawing.Point(152, 59)
        Me.DTPTanggal.Name = "DTPTanggal"
        Me.DTPTanggal.Size = New System.Drawing.Size(130, 20)
        Me.DTPTanggal.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(136, 166)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(136, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(136, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = ":"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Location = New System.Drawing.Point(10, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 26)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Jatuh Tempo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblStatus
        '
        Me.LblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblStatus.Location = New System.Drawing.Point(152, 126)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(130, 26)
        Me.LblStatus.TabIndex = 23
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Location = New System.Drawing.Point(10, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 26)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Cara Jual"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(10, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 26)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tanggal Retur"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(10, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 26)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Status Jual"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Returpenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 357)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Returpenjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retur Penjualan"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnKembali As Button
    Friend WithEvents LblHutang As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents BtnBatal As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents LblJumlahRetur As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblJam As Label
    Friend WithEvents ComboFaktur As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblTanggalJual As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblJatuhTempo As Label
    Friend WithEvents LblCara As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblNoReturJual As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents DTPTanggal As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblStatus As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
End Class
