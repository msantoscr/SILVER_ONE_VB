Imports DevExpress.XtraEditors

Public Class frn_main_form
    Private Sub BTN_EXIT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_EXIT.ItemClick
        'SE VERIFICA SI EL USUARIO AL MOMENTO DE PRESIONAR SALIR SELECCIONA SI O NO
        If (XtraMessageBox.Show("DESEA SALIR DEL SISTEMA", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            'SI EL USAURIO PRESIONO LA OPCION NO ENTONCES CANCELA LA OPERACION ACTUAL  Private Sub BTN_EXIT_ItemClick
            Exit Sub
        Else 'EL USUARIO PRESIONO SI
            'CERRAMOS EL FORMULARIO ACTUAL frm_main_form
            Me.Close()
            'mostramos el formulario del acceso al sistema
            frm_login.Show()

        End If
    End Sub

    Private Sub frn_main_form_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBL_USERNAME.Caption = frm_login.txt_username.Text.Trim().ToUpper 'LE ASIGNAMOS A LA ETIQUETA EL NOMBRE DE USUARIO CON EL CUAL INICIAMOS SESION EN EL SISTEMA
        'ASIGNAMOS A LA ETIQUETA EL NOMBRE DEL SERVIDOR (DATASOURCE) EN EL CUAL ESTAMOS CONECTADOS ACTUALMENTE
        LBL_SERVER.Caption = connection.DataSource.ToString
        'ASIGNAMOS A LA ETIQUETA EL NOMBRE DE LA BASE DE DATOS (DATABASE) A LA CUAL ESTAMOS CONECTADOS
        LBL_DATABASE.Caption = connection.Database.ToString

    End Sub

    Private Sub BTN_COUNTRY_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_COUNTRY.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_country
        Dim FRMC As New frm_country
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_STATES_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_STATES.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_state
        Dim FRMC As New frm_state
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_CITY_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_CITY.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_city
        Dim FRMC As New frm_city
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_USER_TYPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_USER_TYPE.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_user_type
        Dim FRMC As New frm_user_type
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_USERS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_USERS.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_user_type
        Dim FRMC As New frm_users
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_STATUS_C_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_STATUS_C.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_status_clients
        Dim FRMC As New frm_status_clients
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_CLIENTS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_CLIENTS.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_clients
        Dim FRMC As New frm_clients
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_TYPE_DOCTO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_TYPE_DOCTO.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_type_doctos
        Dim FRMC As New frm_type_doctos
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_FOLIOS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_FOLIOS.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_folios
        Dim FRMC As New frm_folios
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_ROUTE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_ROUTE.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_route
        Dim FRMC As New frm_route
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_AGENTS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_AGENTS.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_agents
        Dim FRMC As New frm_agents
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_COMPANY_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_COMPANY.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_company
        Dim FRMC As New frm_company
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_MATERIALES_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_MATERIALES.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_material
        Dim FRMC As New frm_material
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_ACCESORIES_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_ACCESORIES.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_accessories
        Dim FRMC As New frm_accessories
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_EXCEL_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_EXCEL.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_excel
        Dim FRMC As New frm_excel
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_PDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_PDF.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_pdf
        Dim FRMC As New frm_pdf
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_word
        Dim FRMC As New frm_word
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_ARTICLES_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_ARTICLES.ItemClick
        Dim FRMC As New frm_assign_acc_mat
        FRMC.MdiParent = Me
        FRMC.Show()
    End Sub

    Private Sub BTN_WAREHOUSE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_WAREHOUSE.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_warehouse
        Dim FRMC As New frm_warehouse
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_PROVIDERS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_PROVIDERS.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_providers
        Dim FRMC As New frm_providers
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub

    Private Sub BTN_COMPRS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_COMPRS.ItemClick
        'DECLARAMOS UNA VARIABLE QUE HACE INSTANCIA A LA FORMULARIO frm_providers
        Dim FRMC As New frm_compras
        'ASIGNAMOS EL PADRE DE ESTE FORMULARIO A frm_main_form
        FRMC.MdiParent = Me
        'MOSTRAMOS EL FORMULARIO
        FRMC.Show()
    End Sub
End Class