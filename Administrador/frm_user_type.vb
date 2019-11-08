'LIBRERIA DEVEXPRESS QUE PERMITE CODIGO PARA UTILIZAR UN XtraMessageBox SIMILAR A MessageBox
Imports DevExpress.XtraEditors
'LIBRERIAS SQL PARA EJECUTAR COMANDOS DESDE SQL COMMANDO EN EL SISTEMA
Imports System.Data
Imports System.Data.SqlClient
'LIBRERIA DEVEXPRESS QUE PERMITE CODIGO PARA LA PROPIEDAD DE UN ELEMENTO DE LA BARRA INFERIOR DEL FORMULARIO
Imports DevExpress.XtraBars
Public Class frm_user_type
    'METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO SP_SILV_USER_TYPE_VIEW PARA LLENAR EL CONTROL GRIDCONTROL Y MOSTRAR LOS REGISTROS DE LA TABLA CORRESPONDIENTE
    Sub FILL_DATA()
        Try
            'SE REALIZA LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_SILV_USER_TYPE_VIEW E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_SILV_USER_TYPE_VIEW", connection) With {.CommandType = CommandType.StoredProcedure}

            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USER_TYPE_VIEW
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_SILV_USER_TYPE_VIEW", connection)
                Rows = Command.ExecuteNonQuery


                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_SILV_USER_TYPE_VIEW SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
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
    'METODO PARA LIMPIAR LOS CAMPOS DEL FORMULARIO
    Sub CLEAN_FIELDS()
        TXT_ID.ResetText()
        TXT_NAME.ResetText()
        TXT_OBSERVATIONS.ResetText()
        C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked 'A ESTE CONTROL SE LE ASIGNA EL VALOR DE UNCHECKED PARA INDICAR QUE SE TRATA DE UN VALOR 0
    End Sub

    Private Sub frm_user_type_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FILL_DATA() 'SE CARGA LA VISTA DE LOS REGISTROS ACTUALES EJECUTANDO EL METODO QUE LLAMA AL PROCEDIMIENTO ALMACENADO
    End Sub

    Private Sub BTN_SAVE_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        'SE VERIFICA QUE EL VALOR DEL TIPO DE USUARIO NO SE ENCUENTRE COMO VACIO AL ENVIARLO COMO PARAMETRO A LA CONSULTA
        If (TXT_NAME.Text = "") Then 'SI LA CAJA DE TEXTO ESTA VACIA AL MOMENTO DE PRESIONAR EL BOTON GUARDAR ENTONCES
            'SE MUESTRA UN MENSAJE INDICANDO QUE SE DEBE DE ESPECIFICAR EL NOMBRE DEL TIPO DE USUARIO
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL TIPO DE USUARIO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_SAVE_ItemClick_1
        Else 'EN CASO CONTRARIO QUE EL USUARIO UNA VEZ QUE PRESIONO EL BOTON GUARDAR Y LA CAJA DE TEXTO NO ESTE VACIA ENTONCES
            Try
                'CONECTAR A LA BASE DE DATOS
                Connect_Database()
                'SE EJECUTA UN NUEVO COMANDO SP_SILV_USER_TYPE_INSERT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                Command = New SqlCommand("SP_SILV_USER_TYPE_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                With Command
                    ' E ENVIA EL NOMBRE DEL TIPO DE USUARIO AL PROCEDIMIENTO ALMACENADO SP_SILV_USER_TYPE_INSERT MEDIANTE EL TEXTO CONTENIDO EN TXT_NAME EN SU PROPIEDAD TEXT
                    .Parameters.Add("@US_T_NAME_USER", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text
                    'SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                    'SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                    If (TXT_OBSERVATIONS.Text = "") Then
                        .Parameters.AddWithValue("@US_T_OBSERVATIONS", DBNull.Value)
                    Else
                        .Parameters.Add("@US_T_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                    End If

                    'SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    .Parameters.Add("@US_T_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                    'SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                    .Parameters.Add("@US_T_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption




                    'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USER_TYPE_INSERT
                    Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                    'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output
                    'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    Command.Parameters.Add(Message)
                    'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USER_TYPE_INSERT", connection)
                    Rows = Command.ExecuteNonQuery

                    'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_USER_TYPE_INSERT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ESTADO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
        End If
        'SI LA VALIDACION DE LOS IF ANTERIORES AMBOS SON VERDADEROS O AL MENOS UNO DE ELLOS ENTONCES
        If (VALIDA = True) Then
            'MOSTRAMOS UN MENSAJE INDICANDO QUE EL USUARIO DEBE ESPECIFICARLO
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL   Private Sub BTN_EDIT_ItemClick
        Else ' EN CASO CONTRARIO QUE SE HAYA PROPORCIONADO LA INFORMACION SOLICITADA PARA LA MODIFICACION DEL REGISTRO ENTONCES
            'SE MUESTRA UN MENSAJE AL USUARIO INDICANDO SI SE DESEA PROCEDER CON LA MODIFICACION DEL REGISTRO
            'SI EL USUARIO PRESIONA NO ENTONCES
            If (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL TIPO DE USUARIO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub ' SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
            Else
                Try
                    'ABRIMOS LA CONEXION A LA BASE DE DATOS PARA EJECUTAR EL COMANDO QUE REALIZARA LA MODIFICACION DEL REGISTRO DEL TIPO DE USUARIO
                    Connect_Database()
                    'SE DECLARA UN COMANDO QUE ES UN PROCEDIMIENTO ALMACENADO CON EL NOMBRE DE SP_SILV_USER_TYPE_EDIT CON EL CODIGO With {.CommandType = CommandType.StoredProcedure} INDICAMOS QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    Command = New SqlCommand("SP_SILV_USER_TYPE_EDIT", connection) With {.CommandType = CommandType.StoredProcedure}
                    'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                    With Command
                        .Parameters.Add("@ID_USER_TYPE", SqlDbType.Int).Value = TXT_ID.Text 'SE ENVIA EL PARAMETRO DEL IDENTIFICADOR
                        .Parameters.Add("@US_T_NAME_USER", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text 'SE ENVIA EL NOMBRE DEL TIPO DE USUARIO DESDE EL VALOR DE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT



                        'SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                        'SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                        If (TXT_OBSERVATIONS.Text = "") Then
                            .Parameters.AddWithValue("@US_T_OBSERVATIONS", DBNull.Value)
                        Else
                            .Parameters.Add("@US_T_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                        End If

                        'SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                        .Parameters.Add("@US_T_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                        'SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO QUE MODIFICA OBLIGATORIO EN ESTA APLICACION
                        .Parameters.Add("@US_T_USER_UPDATE", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

                        'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USER_TYPE_EDIT
                        Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                        'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output
                        'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        Command.Parameters.Add(Message)
                        'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USER_TYPE_EDIT", connection)
                        Rows = Command.ExecuteNonQuery
                        'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_USER_TYPE_EDIT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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

    Private Sub TXT_ID_TextChanged(sender As Object, e As EventArgs) Handles TXT_ID.TextChanged
        'IF LA CAJA DE TEXTO EN SU PROPIEDAD TEXT ES VACIO ENTONCES
        If (TXT_ID.Text = "") Then
            BTN_DELETE.Enabled = False 'DESABILITAR BOTON ELIMINAR
            BTN_EDIT.Enabled = False ' DESABILITAR BOTON MODIFICAR
            BTN_SAVE.Enabled = True ' HABILITAR BOTON GUARDAR
        Else ' CA JACA DE TEXTO NO SE ENCUENTRA VACIA
            BTN_EDIT.Enabled = True 'SE HABILITA EL BOTON MODIFICAR
            BTN_DELETE.Enabled = True 'SE HABILITA EL BOTON ELIMINAR
            BTN_SAVE.Enabled = False ' SE DESABILITA EL BOTON GUARDAR

        End If
    End Sub
    'MEOTODO QUE REALIZA LA OPERACION DE ASIGNAR UN VALOR AL IDENTIFICADOR, NOMBRE Y OBSERVACIONES DEL TIPO DE USUARIO REALIZANDO UN DOBLE CLIC SOBRE UN REGISTRO
    Private Sub G_DATA_DoubleClick(sender As Object, e As EventArgs) Handles G_DATA.DoubleClick
        Try
            'LA CAJA DE TEXTO TXT_ID OBTENDRA EL VALOR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "ID"
            TXT_ID.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"), String)
            'LA CAJA DE TEXTO TXT_NAME OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "NOMBRE TIPO DE USUARIO"
            TXT_NAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE TIPO DE USUARIO"), String)


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

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick
        'VERIFICAMOS SI EL CAMPO TXT_ID SE ENCUENTRA VACIO, SI ES TRUE=ESTA VACIO ENTONCES SE MUESTRA UN MENSAJE AL USUARIO INDICANDO QUE SE DEBE DE PROPORCIONAR PARA CONTINUAR CON LA ELIMINACION DEL REGISTRO
        If (TXT_ID.Text = "") Then
            'EL USUARIO DEJO EL CAMPO VACIO
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
        Else 'EN CASO CONTRARIO EL CAMPO NO ESTA VACIO
            'SE PREGUNTA AL USUARIO SI SE DESEA ELIMINAR EL REGISTRO DE LAS OPCIONES EL USUARIO PUEDE ELEGIR SI O NO
            'EL USUARIO PRESIONO NO, SE MUESTRA EL MENSAJE
            If (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL TIPO DE USUARIO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub 'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
            Else 'EL USUARIO PRESIONO QUE SI DESEA ELIMINAR EL REGISTRO
                Try
                    'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                    Connect_Database()
                    'SE EJECUTA UN NUEVO COMANDO SP_SILV_USER_TYPE_DELETE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    Command = New SqlCommand("SP_SILV_USER_TYPE_DELETE", connection) With {.CommandType = CommandType.StoredProcedure}
                    'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                    With Command
                        .Parameters.Add("@ID_USER_TYPE", SqlDbType.Int).Value = TXT_ID.Text 'SE ENVIA EL PARAMETRO IDENTIFICADOR DEL REGISTRO ID_USER_TYPE DESDE EL TEXTO QUE CONTIENE LA CAJA DE TEXTO TXT_ID EN SU PROPIEDAD TEXT


                        'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_CITIES_DELETE
                        Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                        'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output
                        'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        Command.Parameters.Add(Message)
                        'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USER_TYPE_DELETE", connection)
                        Rows = Command.ExecuteNonQuery

                        'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_USER_TYPE_DELETE SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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

    Private Sub BTN_CLEAN_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_CLEAN.ItemClick
        CLEAN_FIELDS() 'SE LLAMA AL METODO QUE LIMPIA LOS CAMPOS DEL FORMULARIO

    End Sub

    Private Sub BTN_PRINT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_PRINT.ItemClick
        DGV_DATA.PrintDialog() 'SE LLAMA AL CUADRO DE DIALOGO PARA IMPRIMIR LOS REGISTROS

    End Sub

    Private Sub BTN_PREVIEW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_PREVIEW.ItemClick
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

    Private Sub BTN_SHOW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_SHOW.ItemClick
        FILL_DATA() 'SE CARGA LA VISTA DE LOS REGISTROS ACTUALES EJECUTANDO EL METODO QUE LLAMA AL PROCEDIMIENTO ALMACENADO
    End Sub
End Class