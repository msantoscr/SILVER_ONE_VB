<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_add_article
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BTN_CLOSE = New DevExpress.XtraBars.BarButtonItem()
        Me.LB_RESULT_U = New DevExpress.XtraBars.BarStaticItem()
        Me.LB_RESULT_MAT = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TXT_CANTIDAD = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.CB_ACCESORIO = New System.Windows.Forms.ComboBox()
        Me.CB_MATERIAL = New System.Windows.Forms.ComboBox()
        Me.TXT_LINEA = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.CB_DESCRIPCION = New System.Windows.Forms.ComboBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TXT_COSTO_UNIT = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TXT_PRECION_PUB = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TXT_IMPORTE = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.btn_add = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_CANTIDAD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_LINEA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_COSTO_UNIT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_PRECION_PUB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_IMPORTE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.BTN_CLOSE, Me.LB_RESULT_U, Me.LB_RESULT_MAT})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 4
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.RibbonControl.Size = New System.Drawing.Size(397, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BTN_CLOSE
        '
        Me.BTN_CLOSE.Caption = "SALIR"
        Me.BTN_CLOSE.Id = 1
        Me.BTN_CLOSE.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.close_32x32
        Me.BTN_CLOSE.Name = "BTN_CLOSE"
        '
        'LB_RESULT_U
        '
        Me.LB_RESULT_U.Caption = "..."
        Me.LB_RESULT_U.Id = 2
        Me.LB_RESULT_U.Name = "LB_RESULT_U"
        '
        'LB_RESULT_MAT
        '
        Me.LB_RESULT_MAT.Caption = "..."
        Me.LB_RESULT_MAT.Id = 3
        Me.LB_RESULT_MAT.Name = "LB_RESULT_MAT"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "OPCIONES"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BTN_CLOSE)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "OPCIONES"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.LB_RESULT_U)
        Me.RibbonStatusBar.ItemLinks.Add(Me.LB_RESULT_MAT)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 507)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(397, 31)
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 164)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "CANTIDAD"
        '
        'TXT_CANTIDAD
        '
        Me.TXT_CANTIDAD.Location = New System.Drawing.Point(12, 183)
        Me.TXT_CANTIDAD.MenuManager = Me.RibbonControl
        Me.TXT_CANTIDAD.Name = "TXT_CANTIDAD"
        Me.TXT_CANTIDAD.Size = New System.Drawing.Size(150, 20)
        Me.TXT_CANTIDAD.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 209)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "ACCESORIO"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(169, 209)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "MATERIAL"
        '
        'CB_ACCESORIO
        '
        Me.CB_ACCESORIO.FormattingEnabled = True
        Me.CB_ACCESORIO.Location = New System.Drawing.Point(12, 228)
        Me.CB_ACCESORIO.Name = "CB_ACCESORIO"
        Me.CB_ACCESORIO.Size = New System.Drawing.Size(121, 21)
        Me.CB_ACCESORIO.TabIndex = 6
        '
        'CB_MATERIAL
        '
        Me.CB_MATERIAL.FormattingEnabled = True
        Me.CB_MATERIAL.Location = New System.Drawing.Point(169, 228)
        Me.CB_MATERIAL.Name = "CB_MATERIAL"
        Me.CB_MATERIAL.Size = New System.Drawing.Size(121, 21)
        Me.CB_MATERIAL.TabIndex = 7
        '
        'TXT_LINEA
        '
        Me.TXT_LINEA.Location = New System.Drawing.Point(47, 273)
        Me.TXT_LINEA.MenuManager = Me.RibbonControl
        Me.TXT_LINEA.Name = "TXT_LINEA"
        Me.TXT_LINEA.Properties.ReadOnly = True
        Me.TXT_LINEA.Size = New System.Drawing.Size(150, 20)
        Me.TXT_LINEA.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 280)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "LINEA"
        '
        'CB_DESCRIPCION
        '
        Me.CB_DESCRIPCION.FormattingEnabled = True
        Me.CB_DESCRIPCION.Location = New System.Drawing.Point(12, 341)
        Me.CB_DESCRIPCION.Name = "CB_DESCRIPCION"
        Me.CB_DESCRIPCION.Size = New System.Drawing.Size(364, 21)
        Me.CB_DESCRIPCION.TabIndex = 11
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 322)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "DESCRIPCION"
        '
        'TXT_COSTO_UNIT
        '
        Me.TXT_COSTO_UNIT.Location = New System.Drawing.Point(12, 409)
        Me.TXT_COSTO_UNIT.MenuManager = Me.RibbonControl
        Me.TXT_COSTO_UNIT.Name = "TXT_COSTO_UNIT"
        Me.TXT_COSTO_UNIT.Size = New System.Drawing.Size(150, 20)
        Me.TXT_COSTO_UNIT.TabIndex = 13
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 390)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(88, 13)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "COSTO UNITARIO"
        '
        'TXT_PRECION_PUB
        '
        Me.TXT_PRECION_PUB.Location = New System.Drawing.Point(184, 409)
        Me.TXT_PRECION_PUB.MenuManager = Me.RibbonControl
        Me.TXT_PRECION_PUB.Name = "TXT_PRECION_PUB"
        Me.TXT_PRECION_PUB.Size = New System.Drawing.Size(150, 20)
        Me.TXT_PRECION_PUB.TabIndex = 15
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(184, 390)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl7.TabIndex = 14
        Me.LabelControl7.Text = "PRECIO PUBLICO"
        '
        'TXT_IMPORTE
        '
        Me.TXT_IMPORTE.Location = New System.Drawing.Point(12, 464)
        Me.TXT_IMPORTE.MenuManager = Me.RibbonControl
        Me.TXT_IMPORTE.Name = "TXT_IMPORTE"
        Me.TXT_IMPORTE.Size = New System.Drawing.Size(150, 20)
        Me.TXT_IMPORTE.TabIndex = 17
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(12, 445)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl8.TabIndex = 16
        Me.LabelControl8.Text = "IMPORTE"
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(347, 478)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(38, 23)
        Me.btn_add.TabIndex = 20
        Me.btn_add.Text = "..."
        '
        'frm_add_article
        '
        Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.[False]
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 538)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.TXT_IMPORTE)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.TXT_PRECION_PUB)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.TXT_COSTO_UNIT)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.CB_DESCRIPCION)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TXT_LINEA)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.CB_MATERIAL)
        Me.Controls.Add(Me.CB_ACCESORIO)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TXT_CANTIDAD)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_add_article"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "AÑADIR ARTICULO"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_CANTIDAD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_LINEA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_COSTO_UNIT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_PRECION_PUB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_IMPORTE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXT_CANTIDAD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CB_ACCESORIO As ComboBox
    Friend WithEvents CB_MATERIAL As ComboBox
    Friend WithEvents TXT_LINEA As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CB_DESCRIPCION As ComboBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXT_COSTO_UNIT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXT_PRECION_PUB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXT_IMPORTE As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BTN_CLOSE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LB_RESULT_U As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents LB_RESULT_MAT As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btn_add As DevExpress.XtraEditors.SimpleButton
End Class
