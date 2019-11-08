<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_city
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
        Me.components = New System.ComponentModel.Container()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BTN_SAVE = New DevExpress.XtraBars.BarButtonItem()
        Me.BTN_EDIT = New DevExpress.XtraBars.BarButtonItem()
        Me.BTN_CLEAR = New DevExpress.XtraBars.BarButtonItem()
        Me.BTN_VIEW = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BTN_REFRESH = New DevExpress.XtraBars.BarButtonItem()
        Me.BTN_PRINT = New DevExpress.XtraBars.BarButtonItem()
        Me.BTN_PREVIEW = New DevExpress.XtraBars.BarButtonItem()
        Me.HIDE_PANEL = New DevExpress.XtraBars.BarButtonItem()
        Me.VIEW_AUTOFILTER = New DevExpress.XtraBars.BarButtonItem()
        Me.HIDE_AUTOFILTER = New DevExpress.XtraBars.BarButtonItem()
        Me.LBL_RESULT = New DevExpress.XtraBars.BarStaticItem()
        Me.LBL_RESULT_ESTATE = New DevExpress.XtraBars.BarStaticItem()
        Me.SHOW_PANEL = New DevExpress.XtraBars.BarButtonItem()
        Me.BTN_DELETE = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageCategory1 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageCategory2 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TXT_OBSERVATIONS = New DevExpress.XtraEditors.TextEdit()
        Me.CB_ESTADO = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.C_ACTIVE_INACTIVE = New DevExpress.XtraEditors.CheckEdit()
        Me.TXT_NAME = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TXT_ID = New DevExpress.XtraEditors.TextEdit()
        Me.DGV_DATA = New DevExpress.XtraGrid.GridControl()
        Me.G_DATA = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPAIS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colESTADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCIUDAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOBSERVACIONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colUSUARIOCREADOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHAMODIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHADEREGISTRO = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.TXT_OBSERVATIONS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_ACTIVE_INACTIVE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_NAME.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_DATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G_DATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.BTN_SAVE, Me.BTN_EDIT, Me.BTN_CLEAR, Me.BTN_VIEW, Me.BarSubItem1, Me.BTN_REFRESH, Me.BTN_PRINT, Me.BTN_PREVIEW, Me.HIDE_PANEL, Me.VIEW_AUTOFILTER, Me.HIDE_AUTOFILTER, Me.LBL_RESULT, Me.LBL_RESULT_ESTATE, Me.SHOW_PANEL, Me.BTN_DELETE})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 19
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategory1, Me.RibbonPageCategory2})
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.RibbonControl.Size = New System.Drawing.Size(923, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BTN_SAVE
        '
        Me.BTN_SAVE.Caption = "GUARDAR REGISTRO"
        Me.BTN_SAVE.Id = 1
        Me.BTN_SAVE.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.save_32x32
        Me.BTN_SAVE.Name = "BTN_SAVE"
        '
        'BTN_EDIT
        '
        Me.BTN_EDIT.Caption = "MODIFICAR REGISTRO"
        Me.BTN_EDIT.Enabled = False
        Me.BTN_EDIT.Id = 2
        Me.BTN_EDIT.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.renamedatasource_32x32
        Me.BTN_EDIT.Name = "BTN_EDIT"
        '
        'BTN_CLEAR
        '
        Me.BTN_CLEAR.Caption = "LIMPIAR CAMPOS"
        Me.BTN_CLEAR.Id = 4
        Me.BTN_CLEAR.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.richeditclearformatting_32x32
        Me.BTN_CLEAR.Name = "BTN_CLEAR"
        '
        'BTN_VIEW
        '
        Me.BTN_VIEW.Caption = "VER REGISTROS"
        Me.BTN_VIEW.Id = 5
        Me.BTN_VIEW.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.show_32x32
        Me.BTN_VIEW.Name = "BTN_VIEW"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "ESTADOS"
        Me.BarSubItem1.Id = 6
        Me.BarSubItem1.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.shapelabels_32x32
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BTN_REFRESH)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BTN_REFRESH
        '
        Me.BTN_REFRESH.Caption = "ACTUALIZAR LISTADO"
        Me.BTN_REFRESH.Id = 7
        Me.BTN_REFRESH.ImageOptions.Image = Global.SILVER_ONE_ERP.My.Resources.Resources.refresh_32x32
        Me.BTN_REFRESH.Name = "BTN_REFRESH"
        '
        'BTN_PRINT
        '
        Me.BTN_PRINT.Caption = "IMPRESION RAPIDA"
        Me.BTN_PRINT.Id = 8
        Me.BTN_PRINT.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.printer_32x32
        Me.BTN_PRINT.Name = "BTN_PRINT"
        '
        'BTN_PREVIEW
        '
        Me.BTN_PREVIEW.Caption = "VISTA PREVIA"
        Me.BTN_PREVIEW.Id = 9
        Me.BTN_PREVIEW.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.preview_32x32
        Me.BTN_PREVIEW.Name = "BTN_PREVIEW"
        '
        'HIDE_PANEL
        '
        Me.HIDE_PANEL.Caption = "OCULTAR PANEL DE BUSQUEDA"
        Me.HIDE_PANEL.Enabled = False
        Me.HIDE_PANEL.Id = 11
        Me.HIDE_PANEL.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.legendnone2_32x32
        Me.HIDE_PANEL.Name = "HIDE_PANEL"
        '
        'VIEW_AUTOFILTER
        '
        Me.VIEW_AUTOFILTER.Caption = "VER AUTOFILTROS"
        Me.VIEW_AUTOFILTER.Id = 12
        Me.VIEW_AUTOFILTER.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.masterfilter_32x32
        Me.VIEW_AUTOFILTER.Name = "VIEW_AUTOFILTER"
        '
        'HIDE_AUTOFILTER
        '
        Me.HIDE_AUTOFILTER.Caption = "OCULTAR AUTOFILTROS"
        Me.HIDE_AUTOFILTER.Enabled = False
        Me.HIDE_AUTOFILTER.Id = 13
        Me.HIDE_AUTOFILTER.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.ignoremasterfilter_32x32
        Me.HIDE_AUTOFILTER.Name = "HIDE_AUTOFILTER"
        '
        'LBL_RESULT
        '
        Me.LBL_RESULT.Caption = "..."
        Me.LBL_RESULT.Id = 14
        Me.LBL_RESULT.ImageOptions.Image = Global.SILVER_ONE_ERP.My.Resources.Resources.tableproperties_32x32
        Me.LBL_RESULT.Name = "LBL_RESULT"
        '
        'LBL_RESULT_ESTATE
        '
        Me.LBL_RESULT_ESTATE.Caption = "..."
        Me.LBL_RESULT_ESTATE.Id = 15
        Me.LBL_RESULT_ESTATE.ImageOptions.Image = Global.SILVER_ONE_ERP.My.Resources.Resources.shapelabels_32x32
        Me.LBL_RESULT_ESTATE.Name = "LBL_RESULT_ESTATE"
        '
        'SHOW_PANEL
        '
        Me.SHOW_PANEL.Caption = "MOSTRAR PANEL DE BUSQUEDA"
        Me.SHOW_PANEL.Id = 17
        Me.SHOW_PANEL.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.inlinesizelegend_32x32
        Me.SHOW_PANEL.Name = "SHOW_PANEL"
        '
        'BTN_DELETE
        '
        Me.BTN_DELETE.Caption = "ELIMINAR REGISTRO"
        Me.BTN_DELETE.Enabled = False
        Me.BTN_DELETE.Id = 18
        Me.BTN_DELETE.ImageOptions.LargeImage = Global.SILVER_ONE_ERP.My.Resources.Resources.deletelist_32x32
        Me.BTN_DELETE.Name = "BTN_DELETE"
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Name = "RibbonPageCategory1"
        Me.RibbonPageCategory1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2})
        Me.RibbonPageCategory1.Text = "IMPRESION Y EXPORTACION"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup3})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "OPCIONES IMPRIMIR Y EXPORTAR"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BTN_PRINT)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BTN_PREVIEW)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "IMPRIMIR Y EXPORTAR"
        '
        'RibbonPageCategory2
        '
        Me.RibbonPageCategory2.Name = "RibbonPageCategory2"
        Me.RibbonPageCategory2.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage3})
        Me.RibbonPageCategory2.Text = "BUSQUEDAS Y FILTROS AVANZADOS"
        '
        'RibbonPage3
        '
        Me.RibbonPage3.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup4, Me.RibbonPageGroup5})
        Me.RibbonPage3.Name = "RibbonPage3"
        Me.RibbonPage3.Text = "OPCIONES BUSQUEDAS Y FILTROS"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.SHOW_PANEL)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.HIDE_PANEL)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "BUSQUEDAS AVANZADAS"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.VIEW_AUTOFILTER)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.HIDE_AUTOFILTER)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        Me.RibbonPageGroup5.Text = "FILTROS AVANZADOS"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "OPCIONES BASICAS"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BTN_SAVE)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BTN_EDIT)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BTN_DELETE)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BTN_CLEAR)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BTN_VIEW)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "OPCIONES"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarSubItem1)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "LISTADO"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.LBL_RESULT)
        Me.RibbonStatusBar.ItemLinks.Add(Me.LBL_RESULT_ESTATE)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 586)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(923, 31)
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("58729124-7673-41e8-b007-2c9ca71975c2")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 143)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(270, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(270, 443)
        Me.DockPanel1.Text = "INFORMACION DE LA CIUDAD"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LabelControl3)
        Me.DockPanel1_Container.Controls.Add(Me.TXT_OBSERVATIONS)
        Me.DockPanel1_Container.Controls.Add(Me.CB_ESTADO)
        Me.DockPanel1_Container.Controls.Add(Me.LabelControl1)
        Me.DockPanel1_Container.Controls.Add(Me.C_ACTIVE_INACTIVE)
        Me.DockPanel1_Container.Controls.Add(Me.TXT_NAME)
        Me.DockPanel1_Container.Controls.Add(Me.LabelControl2)
        Me.DockPanel1_Container.Controls.Add(Me.TXT_ID)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 23)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(261, 416)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(8, 85)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(101, 13)
        Me.LabelControl3.TabIndex = 29
        Me.LabelControl3.Text = "NOMBRE DE ESTADO"
        '
        'TXT_OBSERVATIONS
        '
        Me.TXT_OBSERVATIONS.Location = New System.Drawing.Point(3, 246)
        Me.TXT_OBSERVATIONS.MenuManager = Me.RibbonControl
        Me.TXT_OBSERVATIONS.Name = "TXT_OBSERVATIONS"
        Me.TXT_OBSERVATIONS.Size = New System.Drawing.Size(228, 20)
        Me.TXT_OBSERVATIONS.TabIndex = 31
        '
        'CB_ESTADO
        '
        Me.CB_ESTADO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ESTADO.FormattingEnabled = True
        Me.CB_ESTADO.Location = New System.Drawing.Point(8, 104)
        Me.CB_ESTADO.Name = "CB_ESTADO"
        Me.CB_ESTADO.Size = New System.Drawing.Size(168, 21)
        Me.CB_ESTADO.TabIndex = 33
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 141)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(100, 13)
        Me.LabelControl1.TabIndex = 28
        Me.LabelControl1.Text = "NOMBRE DE CIUDAD"
        '
        'C_ACTIVE_INACTIVE
        '
        Me.C_ACTIVE_INACTIVE.Location = New System.Drawing.Point(8, 312)
        Me.C_ACTIVE_INACTIVE.MenuManager = Me.RibbonControl
        Me.C_ACTIVE_INACTIVE.Name = "C_ACTIVE_INACTIVE"
        Me.C_ACTIVE_INACTIVE.Properties.Caption = "ACTIVO/INACTIVO"
        Me.C_ACTIVE_INACTIVE.Properties.ValueChecked = 1
        Me.C_ACTIVE_INACTIVE.Properties.ValueUnchecked = 0
        Me.C_ACTIVE_INACTIVE.Size = New System.Drawing.Size(145, 19)
        Me.C_ACTIVE_INACTIVE.TabIndex = 32
        '
        'TXT_NAME
        '
        Me.TXT_NAME.Location = New System.Drawing.Point(8, 160)
        Me.TXT_NAME.MenuManager = Me.RibbonControl
        Me.TXT_NAME.Name = "TXT_NAME"
        Me.TXT_NAME.Size = New System.Drawing.Size(168, 20)
        Me.TXT_NAME.TabIndex = 27
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(8, 227)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl2.TabIndex = 30
        Me.LabelControl2.Text = "OBSERVACIONES"
        '
        'TXT_ID
        '
        Me.TXT_ID.Location = New System.Drawing.Point(8, 14)
        Me.TXT_ID.MenuManager = Me.RibbonControl
        Me.TXT_ID.Name = "TXT_ID"
        Me.TXT_ID.Properties.ReadOnly = True
        Me.TXT_ID.Size = New System.Drawing.Size(100, 20)
        Me.TXT_ID.TabIndex = 26
        '
        'DGV_DATA
        '
        Me.DGV_DATA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_DATA.Location = New System.Drawing.Point(270, 143)
        Me.DGV_DATA.MainView = Me.G_DATA
        Me.DGV_DATA.Name = "DGV_DATA"
        Me.DGV_DATA.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.DGV_DATA.Size = New System.Drawing.Size(653, 443)
        Me.DGV_DATA.TabIndex = 7
        Me.DGV_DATA.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.G_DATA})
        '
        'G_DATA
        '
        Me.G_DATA.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colPAIS, Me.colESTADO, Me.colCIUDAD, Me.colOBSERVACIONES, Me.GridColumn1, Me.colUSUARIOCREADOR, Me.GridColumn2, Me.colFECHAMODIFICACION, Me.colFECHADEREGISTRO})
        Me.G_DATA.GridControl = Me.DGV_DATA
        Me.G_DATA.Name = "G_DATA"
        Me.G_DATA.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.G_DATA.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.G_DATA.OptionsBehavior.Editable = False
        Me.G_DATA.OptionsView.ColumnAutoWidth = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        '
        'colPAIS
        '
        Me.colPAIS.FieldName = "PAIS"
        Me.colPAIS.Name = "colPAIS"
        Me.colPAIS.Visible = True
        Me.colPAIS.VisibleIndex = 1
        '
        'colESTADO
        '
        Me.colESTADO.FieldName = "ESTADO"
        Me.colESTADO.Name = "colESTADO"
        Me.colESTADO.Visible = True
        Me.colESTADO.VisibleIndex = 2
        '
        'colCIUDAD
        '
        Me.colCIUDAD.FieldName = "CIUDAD"
        Me.colCIUDAD.Name = "colCIUDAD"
        Me.colCIUDAD.Visible = True
        Me.colCIUDAD.VisibleIndex = 3
        '
        'colOBSERVACIONES
        '
        Me.colOBSERVACIONES.FieldName = "OBSERVACIONES"
        Me.colOBSERVACIONES.Name = "colOBSERVACIONES"
        Me.colOBSERVACIONES.Visible = True
        Me.colOBSERVACIONES.VisibleIndex = 4
        '
        'GridColumn1
        '
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn1.FieldName = "ACTIVO/INACTIVO"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = 1
        Me.RepositoryItemCheckEdit1.ValueUnchecked = 0
        '
        'colUSUARIOCREADOR
        '
        Me.colUSUARIOCREADOR.FieldName = "USUARIO CREADOR"
        Me.colUSUARIOCREADOR.Name = "colUSUARIOCREADOR"
        Me.colUSUARIOCREADOR.Visible = True
        Me.colUSUARIOCREADOR.VisibleIndex = 6
        '
        'GridColumn2
        '
        Me.GridColumn2.FieldName = "USUARIO MODIFICA" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 7
        '
        'colFECHAMODIFICACION
        '
        Me.colFECHAMODIFICACION.FieldName = "FECHA MODIFICACION"
        Me.colFECHAMODIFICACION.Name = "colFECHAMODIFICACION"
        Me.colFECHAMODIFICACION.Visible = True
        Me.colFECHAMODIFICACION.VisibleIndex = 8
        '
        'colFECHADEREGISTRO
        '
        Me.colFECHADEREGISTRO.FieldName = "FECHA DE REGISTRO"
        Me.colFECHADEREGISTRO.Name = "colFECHADEREGISTRO"
        Me.colFECHADEREGISTRO.Visible = True
        Me.colFECHADEREGISTRO.VisibleIndex = 9
        '
        'frm_city
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 617)
        Me.Controls.Add(Me.DGV_DATA)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Name = "frm_city"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "GESTION DE CIUDADES"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        Me.DockPanel1_Container.PerformLayout()
        CType(Me.TXT_OBSERVATIONS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_ACTIVE_INACTIVE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_NAME.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_DATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G_DATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents BTN_SAVE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BTN_EDIT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BTN_CLEAR As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BTN_VIEW As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BTN_REFRESH As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategory1 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageCategory2 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RibbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BTN_PRINT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BTN_PREVIEW As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents HIDE_PANEL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents VIEW_AUTOFILTER As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents HIDE_AUTOFILTER As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXT_OBSERVATIONS As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CB_ESTADO As ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents C_ACTIVE_INACTIVE As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TXT_NAME As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXT_ID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LBL_RESULT As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents LBL_RESULT_ESTATE As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents SHOW_PANEL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BTN_DELETE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DGV_DATA As DevExpress.XtraGrid.GridControl
    Friend WithEvents G_DATA As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPAIS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colESTADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCIUDAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOBSERVACIONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUSUARIOCREADOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHAMODIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHADEREGISTRO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
