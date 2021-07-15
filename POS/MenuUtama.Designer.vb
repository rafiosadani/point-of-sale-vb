<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuUtama))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ManageDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KaryawanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DistributorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembelianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HutangPiutangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BayarHutangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerimaPiutangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanPenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanPembelianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HutangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PihutangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarAplikasiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip4 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UserToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.BtnKeluar = New System.Windows.Forms.Button()
        Me.BtnOut = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.BtnComplete = New System.Windows.Forms.Button()
        Me.BtnLaporanPembelian = New System.Windows.Forms.Button()
        Me.BtnLaporanPenjualan = New System.Windows.Forms.Button()
        Me.BtnPiutang = New System.Windows.Forms.Button()
        Me.BtnHutang = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnReturPembelian = New System.Windows.Forms.Button()
        Me.BtnReturPenjualan = New System.Windows.Forms.Button()
        Me.BtnPembelian = New System.Windows.Forms.Button()
        Me.BtnPenjualan = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.BtnKaryawan = New System.Windows.Forms.Button()
        Me.BtnDistributor = New System.Windows.Forms.Button()
        Me.BtnCustomer = New System.Windows.Forms.Button()
        Me.BtnUser = New System.Windows.Forms.Button()
        Me.BtnBarang = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.BtnBarangKeluar = New System.Windows.Forms.Button()
        Me.BtnBarangMasuk = New System.Windows.Forms.Button()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.BtnTerimaPiutang = New System.Windows.Forms.Button()
        Me.BtnBayarHutang = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.ContextMenuStrip4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Ivory
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageDataToolStripMenuItem, Me.TransaksiToolStripMenuItem, Me.HutangPiutangToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.KeluarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(915, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ManageDataToolStripMenuItem
        '
        Me.ManageDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsersToolStripMenuItem, Me.KaryawanToolStripMenuItem, Me.BarangToolStripMenuItem, Me.CustomerToolStripMenuItem, Me.DistributorToolStripMenuItem})
        Me.ManageDataToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ManageDataToolStripMenuItem.Name = "ManageDataToolStripMenuItem"
        Me.ManageDataToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ManageDataToolStripMenuItem.Text = "File"
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.Image = CType(resources.GetObject("UsersToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.UsersToolStripMenuItem.Text = "Users"
        '
        'KaryawanToolStripMenuItem
        '
        Me.KaryawanToolStripMenuItem.Image = CType(resources.GetObject("KaryawanToolStripMenuItem.Image"), System.Drawing.Image)
        Me.KaryawanToolStripMenuItem.Name = "KaryawanToolStripMenuItem"
        Me.KaryawanToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.KaryawanToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.KaryawanToolStripMenuItem.Text = "Karyawan"
        '
        'BarangToolStripMenuItem
        '
        Me.BarangToolStripMenuItem.Image = CType(resources.GetObject("BarangToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BarangToolStripMenuItem.Name = "BarangToolStripMenuItem"
        Me.BarangToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarangToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.BarangToolStripMenuItem.Text = "Barang"
        '
        'CustomerToolStripMenuItem
        '
        Me.CustomerToolStripMenuItem.Image = CType(resources.GetObject("CustomerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem"
        Me.CustomerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.CustomerToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CustomerToolStripMenuItem.Text = "Customer"
        '
        'DistributorToolStripMenuItem
        '
        Me.DistributorToolStripMenuItem.Image = CType(resources.GetObject("DistributorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DistributorToolStripMenuItem.Name = "DistributorToolStripMenuItem"
        Me.DistributorToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.DistributorToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DistributorToolStripMenuItem.Text = "Distributor"
        '
        'TransaksiToolStripMenuItem
        '
        Me.TransaksiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PenjualanToolStripMenuItem, Me.PembelianToolStripMenuItem})
        Me.TransaksiToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        Me.TransaksiToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.TransaksiToolStripMenuItem.Text = "Transaksi"
        '
        'PenjualanToolStripMenuItem
        '
        Me.PenjualanToolStripMenuItem.Image = CType(resources.GetObject("PenjualanToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PenjualanToolStripMenuItem.Name = "PenjualanToolStripMenuItem"
        Me.PenjualanToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.PenjualanToolStripMenuItem.Text = "Penjualan"
        '
        'PembelianToolStripMenuItem
        '
        Me.PembelianToolStripMenuItem.Image = CType(resources.GetObject("PembelianToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PembelianToolStripMenuItem.Name = "PembelianToolStripMenuItem"
        Me.PembelianToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.PembelianToolStripMenuItem.Text = "Pembelian"
        '
        'HutangPiutangToolStripMenuItem
        '
        Me.HutangPiutangToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BayarHutangToolStripMenuItem, Me.TerimaPiutangToolStripMenuItem})
        Me.HutangPiutangToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.HutangPiutangToolStripMenuItem.Name = "HutangPiutangToolStripMenuItem"
        Me.HutangPiutangToolStripMenuItem.Size = New System.Drawing.Size(103, 20)
        Me.HutangPiutangToolStripMenuItem.Text = "Hutang Piutang"
        '
        'BayarHutangToolStripMenuItem
        '
        Me.BayarHutangToolStripMenuItem.Image = CType(resources.GetObject("BayarHutangToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BayarHutangToolStripMenuItem.Name = "BayarHutangToolStripMenuItem"
        Me.BayarHutangToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.BayarHutangToolStripMenuItem.Text = "Bayar Hutang"
        '
        'TerimaPiutangToolStripMenuItem
        '
        Me.TerimaPiutangToolStripMenuItem.Image = CType(resources.GetObject("TerimaPiutangToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TerimaPiutangToolStripMenuItem.Name = "TerimaPiutangToolStripMenuItem"
        Me.TerimaPiutangToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.TerimaPiutangToolStripMenuItem.Text = "Terima Piutang"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaporanPenjualanToolStripMenuItem, Me.LaporanPembelianToolStripMenuItem, Me.HutangToolStripMenuItem, Me.PihutangToolStripMenuItem})
        Me.LaporanToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'LaporanPenjualanToolStripMenuItem
        '
        Me.LaporanPenjualanToolStripMenuItem.Name = "LaporanPenjualanToolStripMenuItem"
        Me.LaporanPenjualanToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.LaporanPenjualanToolStripMenuItem.Text = "Laporan Penjualan"
        '
        'LaporanPembelianToolStripMenuItem
        '
        Me.LaporanPembelianToolStripMenuItem.Name = "LaporanPembelianToolStripMenuItem"
        Me.LaporanPembelianToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.LaporanPembelianToolStripMenuItem.Text = "Laporan Pembelian"
        '
        'HutangToolStripMenuItem
        '
        Me.HutangToolStripMenuItem.Name = "HutangToolStripMenuItem"
        Me.HutangToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.HutangToolStripMenuItem.Text = "Hutang"
        '
        'PihutangToolStripMenuItem
        '
        Me.PihutangToolStripMenuItem.Name = "PihutangToolStripMenuItem"
        Me.PihutangToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.PihutangToolStripMenuItem.Text = "Pihutang"
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOutToolStripMenuItem, Me.KeluarAplikasiToolStripMenuItem})
        Me.KeluarToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.KeluarToolStripMenuItem.Text = "Keluar"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Image = CType(resources.GetObject("LogOutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'KeluarAplikasiToolStripMenuItem
        '
        Me.KeluarAplikasiToolStripMenuItem.Image = CType(resources.GetObject("KeluarAplikasiToolStripMenuItem.Image"), System.Drawing.Image)
        Me.KeluarAplikasiToolStripMenuItem.Name = "KeluarAplikasiToolStripMenuItem"
        Me.KeluarAplikasiToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.KeluarAplikasiToolStripMenuItem.Text = "Keluar Aplikasi "
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(98, 26)
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'ContextMenuStrip4
        '
        Me.ContextMenuStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem1})
        Me.ContextMenuStrip4.Name = "ContextMenuStrip4"
        Me.ContextMenuStrip4.Size = New System.Drawing.Size(98, 26)
        '
        'UserToolStripMenuItem1
        '
        Me.UserToolStripMenuItem1.Name = "UserToolStripMenuItem1"
        Me.UserToolStripMenuItem1.Size = New System.Drawing.Size(97, 22)
        Me.UserToolStripMenuItem1.Text = "User"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Panel1, Me.Panel2, Me.Panel3, Me.Panel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 486)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(915, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(0, 17)
        Me.Panel1.VisitedLinkColor = System.Drawing.Color.Purple
        '
        'Panel2
        '
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(0, 17)
        '
        'Panel3
        '
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(0, 17)
        '
        'Panel4
        '
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(0, 17)
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Ivory
        Me.TabPage4.Controls.Add(Me.BtnKeluar)
        Me.TabPage4.Controls.Add(Me.BtnOut)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(907, 64)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Keluar"
        '
        'BtnKeluar
        '
        Me.BtnKeluar.BackColor = System.Drawing.Color.Transparent
        Me.BtnKeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnKeluar.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnKeluar.FlatAppearance.BorderSize = 0
        Me.BtnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnKeluar.ForeColor = System.Drawing.Color.Black
        Me.BtnKeluar.Image = CType(resources.GetObject("BtnKeluar.Image"), System.Drawing.Image)
        Me.BtnKeluar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnKeluar.Location = New System.Drawing.Point(59, 3)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.Size = New System.Drawing.Size(56, 58)
        Me.BtnKeluar.TabIndex = 38
        Me.BtnKeluar.Text = "Keluar"
        Me.BtnKeluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnKeluar.UseVisualStyleBackColor = False
        '
        'BtnOut
        '
        Me.BtnOut.BackColor = System.Drawing.Color.Transparent
        Me.BtnOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOut.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnOut.FlatAppearance.BorderSize = 0
        Me.BtnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOut.ForeColor = System.Drawing.Color.Black
        Me.BtnOut.Image = CType(resources.GetObject("BtnOut.Image"), System.Drawing.Image)
        Me.BtnOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnOut.Location = New System.Drawing.Point(3, 3)
        Me.BtnOut.Name = "BtnOut"
        Me.BtnOut.Size = New System.Drawing.Size(56, 58)
        Me.BtnOut.TabIndex = 37
        Me.BtnOut.Text = "Log Out"
        Me.BtnOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnOut.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Ivory
        Me.TabPage3.Controls.Add(Me.BtnComplete)
        Me.TabPage3.Controls.Add(Me.BtnLaporanPembelian)
        Me.TabPage3.Controls.Add(Me.BtnLaporanPenjualan)
        Me.TabPage3.Controls.Add(Me.BtnPiutang)
        Me.TabPage3.Controls.Add(Me.BtnHutang)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(907, 64)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Laporan"
        '
        'BtnComplete
        '
        Me.BtnComplete.BackColor = System.Drawing.Color.Transparent
        Me.BtnComplete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnComplete.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnComplete.FlatAppearance.BorderSize = 0
        Me.BtnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnComplete.ForeColor = System.Drawing.Color.Black
        Me.BtnComplete.Image = CType(resources.GetObject("BtnComplete.Image"), System.Drawing.Image)
        Me.BtnComplete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnComplete.Location = New System.Drawing.Point(227, 3)
        Me.BtnComplete.Name = "BtnComplete"
        Me.BtnComplete.Size = New System.Drawing.Size(56, 58)
        Me.BtnComplete.TabIndex = 46
        Me.BtnComplete.Text = "Complete"
        Me.BtnComplete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnComplete.UseVisualStyleBackColor = False
        '
        'BtnLaporanPembelian
        '
        Me.BtnLaporanPembelian.BackColor = System.Drawing.Color.Transparent
        Me.BtnLaporanPembelian.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLaporanPembelian.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnLaporanPembelian.FlatAppearance.BorderSize = 0
        Me.BtnLaporanPembelian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLaporanPembelian.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLaporanPembelian.ForeColor = System.Drawing.Color.Black
        Me.BtnLaporanPembelian.Image = CType(resources.GetObject("BtnLaporanPembelian.Image"), System.Drawing.Image)
        Me.BtnLaporanPembelian.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnLaporanPembelian.Location = New System.Drawing.Point(171, 3)
        Me.BtnLaporanPembelian.Name = "BtnLaporanPembelian"
        Me.BtnLaporanPembelian.Size = New System.Drawing.Size(56, 58)
        Me.BtnLaporanPembelian.TabIndex = 45
        Me.BtnLaporanPembelian.Text = "Pembelian"
        Me.BtnLaporanPembelian.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnLaporanPembelian.UseVisualStyleBackColor = False
        '
        'BtnLaporanPenjualan
        '
        Me.BtnLaporanPenjualan.BackColor = System.Drawing.Color.Transparent
        Me.BtnLaporanPenjualan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLaporanPenjualan.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnLaporanPenjualan.FlatAppearance.BorderSize = 0
        Me.BtnLaporanPenjualan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLaporanPenjualan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLaporanPenjualan.ForeColor = System.Drawing.Color.Black
        Me.BtnLaporanPenjualan.Image = CType(resources.GetObject("BtnLaporanPenjualan.Image"), System.Drawing.Image)
        Me.BtnLaporanPenjualan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnLaporanPenjualan.Location = New System.Drawing.Point(115, 3)
        Me.BtnLaporanPenjualan.Name = "BtnLaporanPenjualan"
        Me.BtnLaporanPenjualan.Size = New System.Drawing.Size(56, 58)
        Me.BtnLaporanPenjualan.TabIndex = 44
        Me.BtnLaporanPenjualan.Text = "Penjualan"
        Me.BtnLaporanPenjualan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnLaporanPenjualan.UseVisualStyleBackColor = False
        '
        'BtnPiutang
        '
        Me.BtnPiutang.BackColor = System.Drawing.Color.Transparent
        Me.BtnPiutang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPiutang.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnPiutang.FlatAppearance.BorderSize = 0
        Me.BtnPiutang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPiutang.ForeColor = System.Drawing.Color.Black
        Me.BtnPiutang.Image = CType(resources.GetObject("BtnPiutang.Image"), System.Drawing.Image)
        Me.BtnPiutang.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnPiutang.Location = New System.Drawing.Point(59, 3)
        Me.BtnPiutang.Name = "BtnPiutang"
        Me.BtnPiutang.Size = New System.Drawing.Size(56, 58)
        Me.BtnPiutang.TabIndex = 42
        Me.BtnPiutang.Text = "Piutang"
        Me.BtnPiutang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnPiutang.UseVisualStyleBackColor = False
        '
        'BtnHutang
        '
        Me.BtnHutang.BackColor = System.Drawing.Color.Transparent
        Me.BtnHutang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnHutang.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnHutang.FlatAppearance.BorderSize = 0
        Me.BtnHutang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHutang.ForeColor = System.Drawing.Color.Black
        Me.BtnHutang.Image = CType(resources.GetObject("BtnHutang.Image"), System.Drawing.Image)
        Me.BtnHutang.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnHutang.Location = New System.Drawing.Point(3, 3)
        Me.BtnHutang.Name = "BtnHutang"
        Me.BtnHutang.Size = New System.Drawing.Size(56, 58)
        Me.BtnHutang.TabIndex = 41
        Me.BtnHutang.Text = "Hutang"
        Me.BtnHutang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnHutang.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Ivory
        Me.TabPage2.Controls.Add(Me.BtnReturPembelian)
        Me.TabPage2.Controls.Add(Me.BtnReturPenjualan)
        Me.TabPage2.Controls.Add(Me.BtnPembelian)
        Me.TabPage2.Controls.Add(Me.BtnPenjualan)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(907, 64)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Transaksi"
        '
        'BtnReturPembelian
        '
        Me.BtnReturPembelian.BackColor = System.Drawing.Color.Transparent
        Me.BtnReturPembelian.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReturPembelian.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnReturPembelian.FlatAppearance.BorderSize = 0
        Me.BtnReturPembelian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReturPembelian.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReturPembelian.ForeColor = System.Drawing.Color.Black
        Me.BtnReturPembelian.Image = CType(resources.GetObject("BtnReturPembelian.Image"), System.Drawing.Image)
        Me.BtnReturPembelian.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnReturPembelian.Location = New System.Drawing.Point(213, 3)
        Me.BtnReturPembelian.Name = "BtnReturPembelian"
        Me.BtnReturPembelian.Size = New System.Drawing.Size(70, 58)
        Me.BtnReturPembelian.TabIndex = 42
        Me.BtnReturPembelian.Text = "Retur Pembelian"
        Me.BtnReturPembelian.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnReturPembelian.UseVisualStyleBackColor = False
        '
        'BtnReturPenjualan
        '
        Me.BtnReturPenjualan.BackColor = System.Drawing.Color.Transparent
        Me.BtnReturPenjualan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReturPenjualan.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnReturPenjualan.FlatAppearance.BorderSize = 0
        Me.BtnReturPenjualan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReturPenjualan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReturPenjualan.ForeColor = System.Drawing.Color.Black
        Me.BtnReturPenjualan.Image = CType(resources.GetObject("BtnReturPenjualan.Image"), System.Drawing.Image)
        Me.BtnReturPenjualan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnReturPenjualan.Location = New System.Drawing.Point(143, 3)
        Me.BtnReturPenjualan.Name = "BtnReturPenjualan"
        Me.BtnReturPenjualan.Size = New System.Drawing.Size(70, 58)
        Me.BtnReturPenjualan.TabIndex = 41
        Me.BtnReturPenjualan.Text = "ReturPenjualan"
        Me.BtnReturPenjualan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnReturPenjualan.UseVisualStyleBackColor = False
        '
        'BtnPembelian
        '
        Me.BtnPembelian.BackColor = System.Drawing.Color.Transparent
        Me.BtnPembelian.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPembelian.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnPembelian.FlatAppearance.BorderSize = 0
        Me.BtnPembelian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPembelian.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPembelian.ForeColor = System.Drawing.Color.Black
        Me.BtnPembelian.Image = CType(resources.GetObject("BtnPembelian.Image"), System.Drawing.Image)
        Me.BtnPembelian.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnPembelian.Location = New System.Drawing.Point(73, 3)
        Me.BtnPembelian.Name = "BtnPembelian"
        Me.BtnPembelian.Size = New System.Drawing.Size(70, 58)
        Me.BtnPembelian.TabIndex = 40
        Me.BtnPembelian.Text = "Pembelian"
        Me.BtnPembelian.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnPembelian.UseVisualStyleBackColor = False
        '
        'BtnPenjualan
        '
        Me.BtnPenjualan.BackColor = System.Drawing.Color.Transparent
        Me.BtnPenjualan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPenjualan.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnPenjualan.FlatAppearance.BorderSize = 0
        Me.BtnPenjualan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPenjualan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPenjualan.ForeColor = System.Drawing.Color.Black
        Me.BtnPenjualan.Image = CType(resources.GetObject("BtnPenjualan.Image"), System.Drawing.Image)
        Me.BtnPenjualan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnPenjualan.Location = New System.Drawing.Point(3, 3)
        Me.BtnPenjualan.Name = "BtnPenjualan"
        Me.BtnPenjualan.Size = New System.Drawing.Size(70, 58)
        Me.BtnPenjualan.TabIndex = 39
        Me.BtnPenjualan.Text = "Penjualan"
        Me.BtnPenjualan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnPenjualan.UseVisualStyleBackColor = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Ivory
        Me.TabPage1.Controls.Add(Me.BtnKaryawan)
        Me.TabPage1.Controls.Add(Me.BtnDistributor)
        Me.TabPage1.Controls.Add(Me.BtnCustomer)
        Me.TabPage1.Controls.Add(Me.BtnUser)
        Me.TabPage1.Controls.Add(Me.BtnBarang)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(907, 64)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "File"
        '
        'BtnKaryawan
        '
        Me.BtnKaryawan.BackColor = System.Drawing.Color.White
        Me.BtnKaryawan.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnKaryawan.FlatAppearance.BorderSize = 0
        Me.BtnKaryawan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnKaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKaryawan.ForeColor = System.Drawing.Color.Black
        Me.BtnKaryawan.Image = CType(resources.GetObject("BtnKaryawan.Image"), System.Drawing.Image)
        Me.BtnKaryawan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnKaryawan.Location = New System.Drawing.Point(227, 3)
        Me.BtnKaryawan.Name = "BtnKaryawan"
        Me.BtnKaryawan.Size = New System.Drawing.Size(57, 58)
        Me.BtnKaryawan.TabIndex = 43
        Me.BtnKaryawan.Text = "Karyawan"
        Me.BtnKaryawan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnKaryawan.UseVisualStyleBackColor = False
        '
        'BtnDistributor
        '
        Me.BtnDistributor.BackColor = System.Drawing.Color.Transparent
        Me.BtnDistributor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDistributor.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnDistributor.FlatAppearance.BorderSize = 0
        Me.BtnDistributor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDistributor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDistributor.ForeColor = System.Drawing.Color.Black
        Me.BtnDistributor.Image = CType(resources.GetObject("BtnDistributor.Image"), System.Drawing.Image)
        Me.BtnDistributor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnDistributor.Location = New System.Drawing.Point(171, 3)
        Me.BtnDistributor.Name = "BtnDistributor"
        Me.BtnDistributor.Size = New System.Drawing.Size(56, 58)
        Me.BtnDistributor.TabIndex = 42
        Me.BtnDistributor.Text = "Distributor"
        Me.BtnDistributor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDistributor.UseVisualStyleBackColor = False
        '
        'BtnCustomer
        '
        Me.BtnCustomer.BackColor = System.Drawing.Color.Transparent
        Me.BtnCustomer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCustomer.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnCustomer.FlatAppearance.BorderSize = 0
        Me.BtnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCustomer.ForeColor = System.Drawing.Color.Black
        Me.BtnCustomer.Image = CType(resources.GetObject("BtnCustomer.Image"), System.Drawing.Image)
        Me.BtnCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCustomer.Location = New System.Drawing.Point(115, 3)
        Me.BtnCustomer.Name = "BtnCustomer"
        Me.BtnCustomer.Size = New System.Drawing.Size(56, 58)
        Me.BtnCustomer.TabIndex = 41
        Me.BtnCustomer.Text = "Customer"
        Me.BtnCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCustomer.UseVisualStyleBackColor = False
        '
        'BtnUser
        '
        Me.BtnUser.BackColor = System.Drawing.Color.Transparent
        Me.BtnUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUser.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnUser.FlatAppearance.BorderSize = 0
        Me.BtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUser.ForeColor = System.Drawing.Color.Black
        Me.BtnUser.Image = CType(resources.GetObject("BtnUser.Image"), System.Drawing.Image)
        Me.BtnUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnUser.Location = New System.Drawing.Point(59, 3)
        Me.BtnUser.Name = "BtnUser"
        Me.BtnUser.Size = New System.Drawing.Size(56, 58)
        Me.BtnUser.TabIndex = 35
        Me.BtnUser.Text = "Users"
        Me.BtnUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnUser.UseVisualStyleBackColor = False
        '
        'BtnBarang
        '
        Me.BtnBarang.BackColor = System.Drawing.Color.Transparent
        Me.BtnBarang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBarang.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnBarang.FlatAppearance.BorderSize = 0
        Me.BtnBarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBarang.ForeColor = System.Drawing.Color.Black
        Me.BtnBarang.Image = CType(resources.GetObject("BtnBarang.Image"), System.Drawing.Image)
        Me.BtnBarang.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBarang.Location = New System.Drawing.Point(3, 3)
        Me.BtnBarang.Name = "BtnBarang"
        Me.BtnBarang.Size = New System.Drawing.Size(56, 58)
        Me.BtnBarang.TabIndex = 39
        Me.BtnBarang.Text = "Barang"
        Me.BtnBarang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBarang.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(915, 90)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.BtnBarangKeluar)
        Me.TabPage5.Controls.Add(Me.BtnBarangMasuk)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(907, 64)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Transaksi Barang"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'BtnBarangKeluar
        '
        Me.BtnBarangKeluar.BackColor = System.Drawing.Color.White
        Me.BtnBarangKeluar.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnBarangKeluar.FlatAppearance.BorderSize = 0
        Me.BtnBarangKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBarangKeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBarangKeluar.ForeColor = System.Drawing.Color.Black
        Me.BtnBarangKeluar.Image = CType(resources.GetObject("BtnBarangKeluar.Image"), System.Drawing.Image)
        Me.BtnBarangKeluar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBarangKeluar.Location = New System.Drawing.Point(63, 0)
        Me.BtnBarangKeluar.Name = "BtnBarangKeluar"
        Me.BtnBarangKeluar.Size = New System.Drawing.Size(63, 64)
        Me.BtnBarangKeluar.TabIndex = 1
        Me.BtnBarangKeluar.Text = "Barang Keluar"
        Me.BtnBarangKeluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBarangKeluar.UseVisualStyleBackColor = False
        '
        'BtnBarangMasuk
        '
        Me.BtnBarangMasuk.BackColor = System.Drawing.Color.White
        Me.BtnBarangMasuk.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnBarangMasuk.FlatAppearance.BorderSize = 0
        Me.BtnBarangMasuk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBarangMasuk.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBarangMasuk.ForeColor = System.Drawing.Color.Black
        Me.BtnBarangMasuk.Image = CType(resources.GetObject("BtnBarangMasuk.Image"), System.Drawing.Image)
        Me.BtnBarangMasuk.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBarangMasuk.Location = New System.Drawing.Point(0, 0)
        Me.BtnBarangMasuk.Name = "BtnBarangMasuk"
        Me.BtnBarangMasuk.Size = New System.Drawing.Size(63, 64)
        Me.BtnBarangMasuk.TabIndex = 0
        Me.BtnBarangMasuk.Text = "Barang Masuk"
        Me.BtnBarangMasuk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBarangMasuk.UseVisualStyleBackColor = False
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.BtnTerimaPiutang)
        Me.TabPage6.Controls.Add(Me.BtnBayarHutang)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(907, 64)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Hutang Piutang"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'BtnTerimaPiutang
        '
        Me.BtnTerimaPiutang.BackColor = System.Drawing.Color.Transparent
        Me.BtnTerimaPiutang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTerimaPiutang.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnTerimaPiutang.FlatAppearance.BorderSize = 0
        Me.BtnTerimaPiutang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTerimaPiutang.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTerimaPiutang.ForeColor = System.Drawing.Color.Black
        Me.BtnTerimaPiutang.Image = CType(resources.GetObject("BtnTerimaPiutang.Image"), System.Drawing.Image)
        Me.BtnTerimaPiutang.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnTerimaPiutang.Location = New System.Drawing.Point(75, 0)
        Me.BtnTerimaPiutang.Name = "BtnTerimaPiutang"
        Me.BtnTerimaPiutang.Size = New System.Drawing.Size(75, 64)
        Me.BtnTerimaPiutang.TabIndex = 44
        Me.BtnTerimaPiutang.Text = "Terima Piutang"
        Me.BtnTerimaPiutang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnTerimaPiutang.UseVisualStyleBackColor = False
        '
        'BtnBayarHutang
        '
        Me.BtnBayarHutang.BackColor = System.Drawing.Color.Transparent
        Me.BtnBayarHutang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBayarHutang.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnBayarHutang.FlatAppearance.BorderSize = 0
        Me.BtnBayarHutang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBayarHutang.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBayarHutang.ForeColor = System.Drawing.Color.Black
        Me.BtnBayarHutang.Image = CType(resources.GetObject("BtnBayarHutang.Image"), System.Drawing.Image)
        Me.BtnBayarHutang.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBayarHutang.Location = New System.Drawing.Point(0, 0)
        Me.BtnBayarHutang.Name = "BtnBayarHutang"
        Me.BtnBayarHutang.Size = New System.Drawing.Size(75, 64)
        Me.BtnBayarHutang.TabIndex = 43
        Me.BtnBayarHutang.Text = "Bayar Hutang"
        Me.BtnBayarHutang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBayarHutang.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Ivory
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(915, 462)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'MenuUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Indigo
        Me.ClientSize = New System.Drawing.Size(915, 508)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ContextMenuStrip4.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ManageDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KaryawanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DistributorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PembelianToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanPenjualanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanPembelianToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HutangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PihutangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeluarAplikasiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents UserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip4 As ContextMenuStrip
    Friend WithEvents UserToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Panel1 As ToolStripStatusLabel
    Friend WithEvents Panel2 As ToolStripStatusLabel
    Friend WithEvents Panel3 As ToolStripStatusLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents BtnOut As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents BtnPiutang As Button
    Friend WithEvents BtnHutang As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents BtnPembelian As Button
    Friend WithEvents BtnPenjualan As Button
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents BtnDistributor As Button
    Friend WithEvents BtnCustomer As Button
    Friend WithEvents BtnUser As Button
    Friend WithEvents BtnBarang As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Panel4 As ToolStripStatusLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BtnKaryawan As Button
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents BtnBarangKeluar As Button
    Friend WithEvents BtnBarangMasuk As Button
    Friend WithEvents BtnLaporanPembelian As Button
    Friend WithEvents BtnLaporanPenjualan As Button
    Friend WithEvents BtnComplete As Button
    Friend WithEvents BtnReturPembelian As Button
    Friend WithEvents BtnReturPenjualan As Button
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents BtnTerimaPiutang As Button
    Friend WithEvents BtnBayarHutang As Button
    Friend WithEvents HutangPiutangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BayarHutangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TerimaPiutangToolStripMenuItem As ToolStripMenuItem
End Class
