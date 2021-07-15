<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanComplete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LaporanComplete))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnTutup = New System.Windows.Forms.Button()
        Me.BtnCustomer = New System.Windows.Forms.Button()
        Me.BtnDistributor = New System.Windows.Forms.Button()
        Me.BtnBarang = New System.Windows.Forms.Button()
        Me.BtnKaryawan = New System.Windows.Forms.Button()
        Me.BtnUser = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnTutup)
        Me.GroupBox1.Controls.Add(Me.BtnCustomer)
        Me.GroupBox1.Controls.Add(Me.BtnDistributor)
        Me.GroupBox1.Controls.Add(Me.BtnBarang)
        Me.GroupBox1.Controls.Add(Me.BtnKaryawan)
        Me.GroupBox1.Controls.Add(Me.BtnUser)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 74)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data"
        '
        'BtnTutup
        '
        Me.BtnTutup.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnTutup.FlatAppearance.BorderSize = 0
        Me.BtnTutup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTutup.Image = CType(resources.GetObject("BtnTutup.Image"), System.Drawing.Image)
        Me.BtnTutup.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnTutup.Location = New System.Drawing.Point(300, 16)
        Me.BtnTutup.Name = "BtnTutup"
        Me.BtnTutup.Size = New System.Drawing.Size(56, 55)
        Me.BtnTutup.TabIndex = 9
        Me.BtnTutup.Text = "Tutup"
        Me.BtnTutup.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnTutup.UseVisualStyleBackColor = True
        '
        'BtnCustomer
        '
        Me.BtnCustomer.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnCustomer.FlatAppearance.BorderSize = 0
        Me.BtnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCustomer.Image = CType(resources.GetObject("BtnCustomer.Image"), System.Drawing.Image)
        Me.BtnCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCustomer.Location = New System.Drawing.Point(244, 16)
        Me.BtnCustomer.Name = "BtnCustomer"
        Me.BtnCustomer.Size = New System.Drawing.Size(56, 55)
        Me.BtnCustomer.TabIndex = 8
        Me.BtnCustomer.Text = "Customer"
        Me.BtnCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCustomer.UseVisualStyleBackColor = True
        '
        'BtnDistributor
        '
        Me.BtnDistributor.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnDistributor.FlatAppearance.BorderSize = 0
        Me.BtnDistributor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDistributor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDistributor.Image = CType(resources.GetObject("BtnDistributor.Image"), System.Drawing.Image)
        Me.BtnDistributor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnDistributor.Location = New System.Drawing.Point(184, 16)
        Me.BtnDistributor.Name = "BtnDistributor"
        Me.BtnDistributor.Size = New System.Drawing.Size(60, 55)
        Me.BtnDistributor.TabIndex = 7
        Me.BtnDistributor.Text = "Distributor"
        Me.BtnDistributor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDistributor.UseVisualStyleBackColor = True
        '
        'BtnBarang
        '
        Me.BtnBarang.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnBarang.FlatAppearance.BorderSize = 0
        Me.BtnBarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBarang.Image = CType(resources.GetObject("BtnBarang.Image"), System.Drawing.Image)
        Me.BtnBarang.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBarang.Location = New System.Drawing.Point(128, 16)
        Me.BtnBarang.Name = "BtnBarang"
        Me.BtnBarang.Size = New System.Drawing.Size(56, 55)
        Me.BtnBarang.TabIndex = 6
        Me.BtnBarang.Text = "Barang"
        Me.BtnBarang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBarang.UseVisualStyleBackColor = True
        '
        'BtnKaryawan
        '
        Me.BtnKaryawan.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnKaryawan.FlatAppearance.BorderSize = 0
        Me.BtnKaryawan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnKaryawan.Image = CType(resources.GetObject("BtnKaryawan.Image"), System.Drawing.Image)
        Me.BtnKaryawan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnKaryawan.Location = New System.Drawing.Point(59, 16)
        Me.BtnKaryawan.Name = "BtnKaryawan"
        Me.BtnKaryawan.Size = New System.Drawing.Size(69, 55)
        Me.BtnKaryawan.TabIndex = 5
        Me.BtnKaryawan.Text = "Karyawan"
        Me.BtnKaryawan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnKaryawan.UseVisualStyleBackColor = True
        '
        'BtnUser
        '
        Me.BtnUser.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnUser.FlatAppearance.BorderSize = 0
        Me.BtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUser.Image = CType(resources.GetObject("BtnUser.Image"), System.Drawing.Image)
        Me.BtnUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnUser.Location = New System.Drawing.Point(3, 16)
        Me.BtnUser.Name = "BtnUser"
        Me.BtnUser.Size = New System.Drawing.Size(56, 55)
        Me.BtnUser.TabIndex = 0
        Me.BtnUser.Text = "User"
        Me.BtnUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnUser.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CRV)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(800, 376)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cetakan"
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.Location = New System.Drawing.Point(3, 16)
        Me.CRV.Name = "CRV"
        Me.CRV.ShowGroupTreeButton = False
        Me.CRV.Size = New System.Drawing.Size(794, 357)
        Me.CRV.TabIndex = 0
        Me.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'LaporanComplete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "LaporanComplete"
        Me.Text = "LaporanComplete"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents BtnUser As Button
    Friend WithEvents BtnTutup As Button
    Friend WithEvents BtnCustomer As Button
    Friend WithEvents BtnDistributor As Button
    Friend WithEvents BtnBarang As Button
    Friend WithEvents BtnKaryawan As Button
End Class
