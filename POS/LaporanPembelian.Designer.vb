﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanPembelian
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnTampilkan3 = New System.Windows.Forms.Button()
        Me.DTPBulanan = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnTampilkan1 = New System.Windows.Forms.Button()
        Me.DTPHarian = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnTampilkan2 = New System.Windows.Forms.Button()
        Me.DTPDua = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPSatu = New System.Windows.Forms.DateTimePicker()
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ListFaktur = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(870, 114)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Laporan Pembelian"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnTampilkan3)
        Me.GroupBox3.Controls.Add(Me.DTPBulanan)
        Me.GroupBox3.Location = New System.Drawing.Point(434, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(169, 89)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Bulanan"
        '
        'BtnTampilkan3
        '
        Me.BtnTampilkan3.Location = New System.Drawing.Point(46, 45)
        Me.BtnTampilkan3.Name = "BtnTampilkan3"
        Me.BtnTampilkan3.Size = New System.Drawing.Size(81, 28)
        Me.BtnTampilkan3.TabIndex = 2
        Me.BtnTampilkan3.Text = "Tampilkan"
        Me.BtnTampilkan3.UseVisualStyleBackColor = True
        '
        'DTPBulanan
        '
        Me.DTPBulanan.CustomFormat = "MMMM yyyy"
        Me.DTPBulanan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPBulanan.Location = New System.Drawing.Point(8, 19)
        Me.DTPBulanan.Name = "DTPBulanan"
        Me.DTPBulanan.Size = New System.Drawing.Size(150, 20)
        Me.DTPBulanan.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnTampilkan1)
        Me.GroupBox4.Controls.Add(Me.DTPHarian)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(163, 87)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Harian"
        '
        'BtnTampilkan1
        '
        Me.BtnTampilkan1.Location = New System.Drawing.Point(37, 45)
        Me.BtnTampilkan1.Name = "BtnTampilkan1"
        Me.BtnTampilkan1.Size = New System.Drawing.Size(81, 28)
        Me.BtnTampilkan1.TabIndex = 1
        Me.BtnTampilkan1.Text = "Tampilkan"
        Me.BtnTampilkan1.UseVisualStyleBackColor = True
        '
        'DTPHarian
        '
        Me.DTPHarian.Checked = False
        Me.DTPHarian.CustomFormat = "dd MMMM yyyy"
        Me.DTPHarian.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPHarian.Location = New System.Drawing.Point(12, 19)
        Me.DTPHarian.Name = "DTPHarian"
        Me.DTPHarian.Size = New System.Drawing.Size(140, 20)
        Me.DTPHarian.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnTampilkan2)
        Me.GroupBox2.Controls.Add(Me.DTPDua)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DTPSatu)
        Me.GroupBox2.Location = New System.Drawing.Point(175, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(253, 87)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'BtnTampilkan2
        '
        Me.BtnTampilkan2.Location = New System.Drawing.Point(154, 19)
        Me.BtnTampilkan2.Name = "BtnTampilkan2"
        Me.BtnTampilkan2.Size = New System.Drawing.Size(90, 59)
        Me.BtnTampilkan2.TabIndex = 3
        Me.BtnTampilkan2.Text = "Tampilkan"
        Me.BtnTampilkan2.UseVisualStyleBackColor = True
        '
        'DTPDua
        '
        Me.DTPDua.CustomFormat = "dd MMMM yyyy"
        Me.DTPDua.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPDua.Location = New System.Drawing.Point(8, 59)
        Me.DTPDua.Name = "DTPDua"
        Me.DTPDua.Size = New System.Drawing.Size(140, 20)
        Me.DTPDua.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sampai"
        '
        'DTPSatu
        '
        Me.DTPSatu.CustomFormat = "dd MMMM yyyy"
        Me.DTPSatu.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPSatu.Location = New System.Drawing.Point(8, 20)
        Me.DTPSatu.Name = "DTPSatu"
        Me.DTPSatu.Size = New System.Drawing.Size(140, 20)
        Me.DTPSatu.TabIndex = 0
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.Location = New System.Drawing.Point(0, 114)
        Me.CRV.Name = "CRV"
        Me.CRV.ShowGroupTreeButton = False
        Me.CRV.Size = New System.Drawing.Size(870, 304)
        Me.CRV.TabIndex = 1
        Me.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ListFaktur)
        Me.GroupBox5.Location = New System.Drawing.Point(610, 20)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(170, 88)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "No Faktur Pembelian"
        '
        'ListFaktur
        '
        Me.ListFaktur.FormattingEnabled = True
        Me.ListFaktur.Location = New System.Drawing.Point(7, 13)
        Me.ListFaktur.Name = "ListFaktur"
        Me.ListFaktur.Size = New System.Drawing.Size(157, 69)
        Me.ListFaktur.TabIndex = 0
        '
        'LaporanPembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 418)
        Me.Controls.Add(Me.CRV)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "LaporanPembelian"
        Me.Text = "LaporanPembelian"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BtnTampilkan3 As Button
    Friend WithEvents DTPBulanan As DateTimePicker
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnTampilkan1 As Button
    Friend WithEvents DTPHarian As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnTampilkan2 As Button
    Friend WithEvents DTPDua As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPSatu As DateTimePicker
    Friend WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ListFaktur As ListBox
End Class
