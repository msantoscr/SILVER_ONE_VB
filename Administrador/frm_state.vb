'LIBRERIA DEVEXPRESS QUE PERMITE CODIGO PARA UTILIZAR UN XtraMessageBox SIMILAR A MessageBox
Imports DevExpress.XtraEditors
'LIBRERIAS SQL PARA EJECUTAR COMANDOS DESDE SQL COMMANDO EN EL SISTEMA
Imports System.Data
Imports System.Data.SqlClient
'LIBRERIA DEVEXPRESS QUE PERMITE CODIGO PARA LA PROPIEDAD DE UN ELEMENTO DE LA BARRA INFERIOR DEL FORMULARIO
Imports DevExpress.XtraBars

Public Class frm_state
    'METODO PARA LIMPIAR LAS CAJAS DE TEXTO Y CONTROLES DEL FORMULARIO
    Sub CLEAN_FIELDS()
        TXT_ID.ResetText()
        TXT_NAME.ResetText()
        TXT_OBSERVATIONS.ResetText()
        C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked
    End Sub

    'METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_VIEW PARA LLENAR EL CONTROL GRIDCONTROL Y MOSTRAR LOS REGISTROS DE LA TABLA CORRESPONDIENTE
    Sub FILL_DATA()
        'SE INICIA CON UN BLOQUE DE CODIGO TRY-CATCH POR SI OCURRE UN ERROR ESTE PUEDA SER CAPTURADO AL OCURRIR Y DEPURARLO
        Try
            'SE ESTABLECE LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_SILV_ESTATES_VIEW E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_SILV_ESTATES_VIEW", connection) With {.CommandType = CommandType.StoredProcedure}

            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_VIEW
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_SILV_ESTATES_VIEW", connection)
                Rows = Command.ExecuteNonQuery


                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_VIEW SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)

                If (Rows > 0) Then
                    LB_RESULT.Visibility = BarItemVisibility.Always
                    LB_RESULT.Caption = Convert.ToString(Message.Value)

                Else
                    LB_RESULT.Visibility = BarItemVisibility.Always
                    LB_RESULT.Caption = Convert.ToString(Message.Value)
                End If
                'CREAMOS UN ADAPTADOR PARA EL COMANDO
                Adapter = New SqlDataAdapter(Command)
                'SE CREA UN NUEVO DATATABLE
                DataT = New DataTable
                'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                Adapter.Fill(DataT)
                'INDICAMOS QUE LA FUENTE DE DATOS DEL CONTROL GRIDCONTROL SERA UN DATATABLE
                DGV_DATA.DataSource = DataT
                'AL GRIDVIEW QUE SE CONTIENE DESDE EL GRIDCONTROL SE AJUSTARAN SUS COLUMNAS AL CONTENIDO DEL TEXTO 
                G_DATA.BestFitColumns()
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()
        End Try
    End Sub

    'METODO QUE LISTA LOS PAISES EN EL CONTROL COMBOBOX
    Sub LIST_COUNTRY()
        Try
            'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_SILV_COUNTRY E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_SILV_COUNTRY", connection) With {.CommandType = CommandType.StoredProcedure}

            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_SILV_COUNTRY
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_SILV_COUNTRY", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_SILV_COUNTRIES_VIEW SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)

                If (Rows > 0) Then
                    LB_RESULT_COUNTRY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COUNTRY.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_COUNTRY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COUNTRY.Caption = Convert.ToString(Message.Value)
                End If
            End With
            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_SILV_COUNTRY
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_PAIS LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_PAIS
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "ID_COUNTRY" 'EL VALOR QUE TENDRA
                .DisplayMember = "CO_NAME" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()

        End Try
    End Sub
    'EL SIGUIENTE METODO ES SIMILAR AL METODO LIS_COUNTRY LA FINALIDAD DE ESTE METODO ES OBTENER EL VALOR DEL PAIS UNA VEZ QUE SE HA HECHO DOBLE CLIC SOBRE UN REGISTRO A PARTIR DEL ID
    'DEL REGISTRO
    Sub LIST_VALUE_COUNTRY()
        Try
            'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_VALUE_SILV_COUNTRY_ESTATE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_VALUE_SILV_COUNTRY_ESTATE", connection) With {.CommandType = CommandType.StoredProcedure}

            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                .Parameters.Add("@ID_COUNTRY", SqlDbType.Int).Value = TXT_ID.Text.Trim 'SE AGREGA EL SIGUIENTE PARAMETRO COMO ADICIONAL AL PROCEDIMIENTO SP_VALUE_SILV_COUNTRY_ESTATE


                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_VALUE_SILV_COUNTRY_ESTATE
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_VALUE_SILV_COUNTRY_ESTATE", connection)
                Rows = Command.ExecuteNonQuery

                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_VALUE_SILV_COUNTRY_ESTATE SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)

                If (Rows > 0) Then
                    LB_RESULT_COUNTRY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COUNTRY.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_COUNTRY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COUNTRY.Caption = Convert.ToString(Message.Value)
                End If
            End With

            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_VALUE_SILV_COUNTRY_ESTATE
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_PAIS LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_PAIS
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .DataSource = DataT
                .ValueMember = "ID_COUNTRY" 'EL VALOR QUE TENDRA
                .DisplayMember = "CO_NAME" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()

        End Try
    End Sub

    Private Sub frm_state_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FILL_DATA() 'LLAMAMOS AL METODO DE CARGAR LOS REGISTROS
    End Sub

    Private Sub BTN_SAVE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        'VERIFICAMOS SI EL VALOR DEL CAMPO DE NOMBRE DEL ESTADO NO ESTA VACIO PARA REGISTRARLO EN LA BD
        If (TXT_NAME.Text = "") Then 'SI EL VALOR ESTA VACIO ENTONCES
            'MUESTRA UN MENSAJE INDICANDO QUE DEBE ESPECIFICAR EL NOMBRE DEL ESTADO
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ESTADO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub 'CANCELA LA OPERACION ACTUAL   Private Sub BTN_SAVE_ItemClick
        Else 'EN CASO CONTRARIO QUE EL VALOR NO ESTE VACIO ENTONCES
            Try
                'CONECTAR  A LA BASE DE DATOS
                Connect_Database()
                'SE EJECUTA UN NUEVO COMANDO SP_SILV_ESTATES_INSERT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                Command = New SqlCommand("SP_SILV_ESTATES_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                With Command
                    'ASIGNAMOS EL PARAMETRO QUE IDENTIFICA EL PAIS
                    .Parameters.Add("@ID_COUNTRY", SqlDbType.Int).Value = CB_PAIS.SelectedValue
                    'SE ENVIA EL PARAMETRO QUE CONTIENE EL NOMBRE DEL ESTADO DESDE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT
                    .Parameters.Add("@ES_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text
                    'SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                    'SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                    If (TXT_OBSERVATIONS.Text = "") Then
                        .Parameters.AddWithValue("@ES_OBSERVATIONS", DBNull.Value)
                    Else 'EN CASO CONTRARIO SE ENVIALA INFORMACION QUE CONTENGA LA CAJA DE TEXTO DE OBSERVACIONES TXT_OBSERVATIONS.Text
                        .Parameters.Add("@ES_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                    End If


                    'SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    .Parameters.Add("@ES_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                    'SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                    .Parameters.Add("@ES_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption



                    'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_INSERT
                    Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                    'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output
                    'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    Command.Parameters.Add(Message)
                    'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_ESTATES_INSERT", connection)
                    Rows = Command.ExecuteNonQuery
                    'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_COUNTRIES_INSERT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
                    If (Rows > 0) Then
                        XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                    Else
                        XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                    End If

                End With
            Catch ex As Exception
                'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'CERRAMOS LA CONEXION A LA BASE DE DATOS
                Disconnect_Database()
                'LIMPIAMOS LOS CAMPOS
                CLEAN_FIELDS()
                'LLENAMOS EL CONTROL GRIDCONTROL CON LA EJECUCION DEL METODO ENCARGADO DE LA EJECUCION DEL PROCEDIMIENTO ALMACENADO
                FILL_DATA()

            End Try
        End If
    End Sub


    Private Sub BTN_CLEAR_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_CLEAR.ItemClick
        CLEAN_FIELDS() 'SE LLAMA AL METODO DE LIMPIAR CAMPOS
    End Sub

    Private Sub BTN_PRINT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_PRINT.ItemClick
        DGV_DATA.PrintDialog() 'SE LLAMA AL CUADRO DE DIALOGO PARA IMPRIMIR LOS REGISTROS

    End Sub

    Private Sub BTN_PREVIEW_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BTN_PREVIEW.ItemClick
        DGV_DATA.ShowRibbonPrintPreview() 'MANDAMOS A LLAMAR EL CONTROL DE VISTA PREVIA DEL CONTROL GRIDCONTROL

    End Sub

    Private Sub SHOW_PANEL_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SHOW_PANEL.ItemClick
        'ESTE CODIGO NOS MUESTRA UN PANEL DE BUSQUEDA DE NUESTRO CONTROL GRIDCONTROL
        Me.G_DATA.OptionsFind.AlwaysVisible = True
        'DESABILITAMOS ESTE BOTON SHOW_PANEL
        SHOW_PANEL.Enabled = False
        'HABILITAMOS EL BOTON HIDE_PANEL
        HIDE_PANEL.Enabled = True
    End Sub

    Private Sub HIDE_PANEL_ItemClick(sender As Object, e As ItemClickEventArgs) Handles HIDE_PANEL.ItemClick
        'ESTE CODIGO NOS OCULTA EL PANEL DE BUSQUEDA DE NUESTRO CONTROL GRIDCONTROL
        Me.G_DATA.OptionsFind.AlwaysVisible = False
        'HABILITAMOS ESTE BOTON SHOW_PANEL
        SHOW_PANEL.Enabled = True
        'DESABILITAMOS EL BOTON HIDE_PANEL
        HIDE_PANEL.Enabled = False
    End Sub

    Private Sub VIEW_AUTOFILTER_ItemClick(sender As Object, e As ItemClickEventArgs) Handles VIEW_AUTOFILTER.ItemClick
        'MUESTRA UNA FILA QUE PERMITE EL AUTOFILTRO DE REGISTROS DE NUESTRO CONTROL GRIDCONTROL
        Me.G_DATA.OptionsView.ShowAutoFilterRow = True
        'SE DESABILITA EL BOTON VIEW_AUTOFILTER CON EL CODIGO Enabled = False
        VIEW_AUTOFILTER.Enabled = False
        'SE HABILITA EL BOTON HIDE_AUTOFILTER CON EL CODIGO Enabled = True
        HIDE_AUTOFILTER.Enabled = True
    End Sub

    Private Sub HIDE_AUTOFILTER_ItemClick(sender As Object, e As ItemClickEventArgs) Handles HIDE_AUTOFILTER.ItemClick
        'SE OCULTA LA FILA QUE PERMIE EL AUTOFILTRO DE REGISTROS DE NUESTRO CONTROL GRIDCONTROL
        Me.G_DATA.OptionsView.ShowAutoFilterRow = False
        'SE HABILITA EL BOTON DE VIEW_AUTOFILTER CON EL CODIGO Enabled = True
        VIEW_AUTOFILTER.Enabled = True
        'SE DESABILITA EL BOTON HIDE_AUTOFILTER CON EL CODIGO Enabled = False
        HIDE_AUTOFILTER.Enabled = False
    End Sub


    'MEOTODO QUE REALIZA LA OPERACION DE ASIGNAR UN VALOR AL IDENTIFICADOR, NOMBRE Y OBSERVACIONES DEL ESTADO REALIZANDO UN DOBLE CLIC SOBRE UN REGISTRO
    Private Sub G_DATA_DoubleClick(sender As Object, e As EventArgs) Handles G_DATA.DoubleClick
        Try
            'LA CAJA DE TEXTO TXT_ID OBTENDRA EL VALOR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "ID"
            TXT_ID.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"), String)
            'LA CAJA DE TEXTO TXT_NAME OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "NOMBRE DE ESTADO"
            TXT_NAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE DE ESTADO"), String)


            'ESTE CODIGO VERIFICA SI EL VALOR QUE CONTIENE LA COLUMNA  G_DATA.FocusedRowHandle, "OBSERVACIONES" NO SE ENCUENTRA EN UN VALOR NULL
            'DE TRATARSE DE UN VALOR VACIO ESTE NO ASIGNARA VALOR ALGUNO A LA CAJA DE TEXTO
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"))) Then
                TXT_OBSERVATIONS.Text = ""
            Else
                TXT_OBSERVATIONS.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"), String)

            End If

            'SE ASIGNA EL VALOR DE LA COLUMNA ACTIVO/INACTIVO AL CONTROL C_ACTIVE_INACTIVE.CheckState
            C_ACTIVE_INACTIVE.CheckState = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO"), CheckState)


        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TXT_ID_TextChanged(sender As Object, e As EventArgs) Handles TXT_ID.TextChanged
        'IF LA CAJA DE TEXTO EN SU PROPIEDAD TEXT ES VACIO ENTONCES 
        If (TXT_ID.Text = "") Then
            BTN_DELETE.Enabled = False 'DESBILITAR BOTON ELIMINAR
            BTN_EDIT.Enabled = False 'DESABILITAR BOTON MODIFICAR
            BTN_SAVE.Enabled = True 'HABILITAR BOTON GUARDAR
        Else 'EN CASO CONTARRIO QUE LA CAJA DE TEXTO SI CONTENGA ALGUN IDENTIFICADOR (ID)
            BTN_EDIT.Enabled = True 'HABILITAR BOTON MODIFICAR
            BTN_DELETE.Enabled = True 'HABILITAR BOTON ELIMINAR
            BTN_SAVE.Enabled = False 'DESABILITAR BOTON GUARDAR
            LIST_VALUE_COUNTRY() 'EJECUTAMOS ESTE METODO PARA OBTENER EL VALOR DEL PAIS UNA VEZ QUE SE DE DOBLE CLIC SOBRE UN REGISTRO
        End If
    End Sub

    Private Sub BTN_EDIT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_EDIT.ItemClick
        'DECLARAMOS UNA VARIABLE QUE SE ENCARGA DE LA VALIDACION DE UN CAMPO VACIO INCIALIZADO EN FALSO
        'MODIFICACION DEL REGISTRO MEDIANTE UN IDENTIFICADOR =ID DE LA TABLA SQL
        Dim VALIDA As Boolean = False
        'LOGICA:SI EL CAMPO TXT_ID QUE SE ENCARGA DE ALMACENAR EL TEXTO IDENTIFICADOR DEL REGISTRO ESTA VACIO ENTONCES
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        If (TXT_NAME.Text = "") Then
            'MOSTRAMOS UN MENSAJE INDICANDO QUE EL USUARIO DEBE ESPECIFICARLO
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ESTADO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick

        End If


        'SI LA VALIDACION DE LOS IF ANTERIORES AMBOS SON VERDADEROS O AL MENOS UNO DE ELLOS ENTONCES
        If (VALIDA = True) Then
            'SE MUESTRA UN MENSAJE INDICANDO QUE FALTA INFORMACION POR ESPECIFICAR PARA PROCEDER A LA MODIFICACION DEL REGISTRO
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL   Private Sub BTN_EDIT_ItemClick
        Else ' EN CASO CONTRARIO QUE SE HAYA PROPORCIONADO LA INFORMACION SOLICITADA PARA LA MODIFICACION DEL REGISTRO ENTONCES
            'SE MUESTRA UN MENSAJE AL USUARIO INDICANDO SI SE DESEA PROCEDER CON LA MODIFICACION DEL REGISTRO
            'SI EL USUARIO PRESIONA NO ENTONCES
            If (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL ESTADO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub ' SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
            Else 'EN CASO CONTRARIO EL USUARIO PRESIONO QUE SI DESEA MODIFICAR EL REGISTRO ENTONCES
                Try 'INTENTAR

                    Connect_Database() 'ABRIMOS LA CONEXION A LA BASE DE DATOS PARA EJECUTAR EL COMANDO QUE REALIZARA LA MODIFICACION DEL REGISTRO DEL PAIS
                    'SE DECLARA UN COMANDO QUE ES UN PROCEDIMIENTO ALMACENADO CON EL NOMBRE DE SP_SILV_ESTATES_EDIT CON EL CODIGO With {.CommandType = CommandType.StoredProcedure} INDICAMOS QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    Command = New SqlCommand("SP_SILV_ESTATES_EDIT", connection) With {.CommandType = CommandType.StoredProcedure}
                    'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                    With Command
                        .Parameters.Add("@ID_ESTATES", SqlDbType.Int).Value = TXT_ID.Text 'SE ENVIA EL VALOR DEL IDENTIFICADOR DEL REGISTRO QUE ES DE TIPO ENTERO (INT) DESDE LA CAJA DE TEXTO TXT_ID
                        .Parameters.Add("@ID_COUNTRY", SqlDbType.Int).Value = CB_PAIS.SelectedValue 'SE ENVIA EL VALOR DEL ID DEL PAIS MEDIANTE LA SELECCION DE UNA VALOR DE LA LISTA
                        .Parameters.Add("@ES_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text 'SE ENVIA EL VALOR DEL NOMBRE DEL ESTADO MEDIANTE LA CAJA DE TEXTO TXT_NAME



                        'SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                        'SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                        If (TXT_OBSERVATIONS.Text = "") Then
                            .Parameters.AddWithValue("@ES_OBSERVATIONS", DBNull.Value)
                        Else
                            .Parameters.Add("@ES_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                        End If

                        'SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                        .Parameters.Add("@ES_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                        'SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO QUE MODIFICA OBLIGATORIO EN ESTA APLICACION
                        .Parameters.Add("@ES_USER_UPDATE", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption


                        'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_EDIT
                        Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                        'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output
                        'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        Command.Parameters.Add(Message)
                        'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_ESTATES_EDIT", connection)
                        Rows = Command.ExecuteNonQuery
                        'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_ESTATES_EDIT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
                        If (Rows > 0) Then
                            XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                        Else
                            XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                        End If

                    End With
                Catch ex As Exception
                    'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    'CERRAMOS LA CONEION A LA BASE DE DATOS
                    Disconnect_Database()
                    'LIMPIAMOS LOS CAMPOS
                    CLEAN_FIELDS()
                    'REFRESCAMOS LA VISTA DE LOS REGISTROS LLAMANDO EL METODO ENCARGADO DE EJECUTAR ESTE PROCEDIMIENTO ALMACENADO
                    FILL_DATA()
                End Try
            End If
        End If
    End Sub

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick
        'VERIFICAMOS SI EL CAMPO TXT_ID SE ENCUENTRA VACIO, SI ES TRUE=ESTA VACIO ENTONCES SE MUESTRA UN MENSAJE AL USUARIO INDICANDO QUE SE DEBE DE PROPORCIONAR PARA CONTINUAR CON LA ELIMINACION DEL REGISTRO
        If (TXT_ID.Text = "") Then
            'EL USUARIO DEJO EL CAMPO VACIO
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
        Else 'EN CASO CONTRARIO EL CAMPO NO ESTA VACIO

            'SE PREGUNTA AL USUARIO SI SE DESEA ELIMINAR EL REGISTRO DE LAS OPCIONES EL USUARIO PUEDE ELEGIR SI O NO
            'EL USUARIO PRESIONO NO, SE MUESTRA EL MENSAJE
            If (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL ESTADO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub  'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
            Else 'EL USUARIO PRESIONO QUE SI DESEA ELIMINAR EL REGISTRO
                Try
                    'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                    Connect_Database()
                    'SE EJECUTA UN NUEVO COMANDO SP_SILV_ESTATES_DELETE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    Command = New SqlCommand("SP_SILV_ESTATES_DELETE", connection) With {.CommandType = CommandType.StoredProcedure}
                    'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                    With Command
                        'SE ENVIA EL VALOR DEL INDENTIFICADOR DEL REGISTRO Y ESTE LO ALMACENA LA CAJA DE TEXTO TXT_ID CON SU PROPIEDAD TEXT
                        .Parameters.Add("@ID_ESTATES", SqlDbType.Int).Value = TXT_ID.Text

                        'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_DELETE
                        Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                        'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output
                        'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        Command.Parameters.Add(Message)
                        'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_SILV_ESTATES_DELETE", connection)
                        Rows = Command.ExecuteNonQuery
                        'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_ESTATES_DELETE SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
                        If (Rows > 0) Then
                            XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                        Else
                            XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                        End If

                    End With
                Catch ex As Exception
                    'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    'CERRAMOS LA CONEXION A LA BASE DE DATOS
                    Disconnect_Database()
                    'LIMPIAMOS LOS CAMPOS
                    CLEAN_FIELDS()
                    'REFRESCAMOS LA VISTA DE LOS REGISTROS LLAMANDO EL METODO ENCARGADO DE EJECUTAR ESTE PROCEDIMIENTO ALMACENADO
                    FILL_DATA()

                End Try
            End If
        End If
    End Sub

    Private Sub BTN_LIST_COUNTRY_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_LIST_COUNTRY.ItemClick
        LIST_COUNTRY() 'LLAMAR AL METODO DE LISTAR LOS PAISES
    End Sub

    Private Sub BTN_SHOW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_SHOW.ItemClick
        FILL_DATA()  'REFRESCAMOS LA VISTA DE LOS REGISTROS LLAMANDO EL METODO ENCARGADO DE EJECUTAR ESTE PROCEDIMIENTO ALMACENADO

    End Sub
End Class