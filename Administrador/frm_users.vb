'LIBRERIA DEVEXPRESS QUE PERMITE CODIGO PARA UTILIZAR UN XtraMessageBox SIMILAR A MessageBox
Imports DevExpress.XtraEditors
'LIBRERIAS SQL PARA EJECUTAR COMANDOS DESDE SQL COMMANDO EN EL SISTEMA
Imports System.Data
Imports System.Data.SqlClient
'LIBRERIA DEVEXPRESS QUE PERMITE CODIGO PARA LA PROPIEDAD DE UN ELEMENTO DE LA BARRA INFERIOR DEL FORMULARIO
Imports DevExpress.XtraBars
Public Class frm_users
    'METODO PARA LIMPIAR LOS CAMPOS DEL FORMULARIO
    Sub CLEAN_FIELDS()
        TXT_ID.ResetText()
        TXT_NAME.ResetText()
        TXT_PASSWORD.ResetText()
        TXT_USERNAME.ResetText()
        TXT_OBSERVATIONS.ResetText()
        C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked 'A ESTE CONTROL SE LE ASIGNA EL VALOR DE UNCHECKED PARA INDICAR QUE SE TRATA DE UN VALOR 0
    End Sub
    'METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO SP_SILV_USERS_VIEW PARA LLENAR EL CONTROL GRIDCONTROL Y MOSTRAR LOS REGISTROS DE LA TABLA CORRESPONDIENTE
    Sub FILL_DATA()
        Try
            'SE REALIZA LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_SILV_USERS_VIEW E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_SILV_USERS_VIEW", connection) With {.CommandType = CommandType.StoredProcedure}

            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_VIEW
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_SILV_USERS_VIEW", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_VIEW SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    LBL_RESULT.Visibility = BarItemVisibility.Always
                    LBL_RESULT.Caption = Convert.ToString(Message.Value)

                Else
                    LBL_RESULT.Visibility = BarItemVisibility.Always
                    LBL_RESULT.Caption = Convert.ToString(Message.Value)
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
    'METODO QUE LISTA LOS TIPOS DE USUARIO EN EL CONTROL COMBOBOX
    Sub LIST_USER_TYPE()
        Try
            'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_USER_TYPE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_USER_TYPE", connection) With {.CommandType = CommandType.StoredProcedure}
            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_USER_TYPE
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_USER_TYPE", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_USER_TYPE SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    LB_RESULT_TYPE_USER.Visibility = BarItemVisibility.Always
                    LB_RESULT_TYPE_USER.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_TYPE_USER.Visibility = BarItemVisibility.Always
                    LB_RESULT_TYPE_USER.Caption = Convert.ToString(Message.Value)
                End If
            End With
            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_USER_TYPE
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_TYPE LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_TYPE
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "ID_USER_TYPE" 'EL VALOR QUE TENDRA
                .DisplayMember = "US_T_NAME_USER" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()
        End Try
    End Sub
    'METODO QYE OBTIENE EL VALOR DEL TIPO DE USUARIO AL HACER DOBLE CLIC SOBRE UN REGISTRO
    Sub LIST_VALUE_USER_TYPE()
        Try
            'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_VALUE_USER_TYPE_USERS E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_VALUE_USER_TYPE_USERS", connection) With {.CommandType = CommandType.StoredProcedure}
            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                'SE ENVIA COMO PARAMETRO EL ID DEL REGISTRO PARA HACER UNA EVALUACION EN EL PROCEDIMIENTO ALMACENADO SQL SP_VALUE_USER_TYPE_USERS
                .Parameters.Add("@ID_USER_TYPE", SqlDbType.Int).Value = TXT_ID.Text.Trim

                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_VALUE_USER_TYPE_USERS
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_VALUE_USER_TYPE_USERS", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_VALUE_USER_TYPE_USERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    LB_RESULT_TYPE_USER.Visibility = BarItemVisibility.Always
                    LB_RESULT_TYPE_USER.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_TYPE_USER.Visibility = BarItemVisibility.Always
                    LB_RESULT_TYPE_USER.Caption = Convert.ToString(Message.Value)
                End If
            End With

            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_VALUE_USER_TYPE_USERS
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_TYPE LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_TYPE
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "ID_USER_TYPE" 'EL VALOR QUE TENDRA
                .DisplayMember = "US_T_NAME_USER" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()

        End Try
    End Sub
    Sub LIST_AGENTS()
        Try
            'SE REALIZA LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_AGENTS E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_AGENTS", connection) With {.CommandType = CommandType.StoredProcedure}

            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_AGENTS
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_AGENTS", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_AGENTS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    LBL_RESULT_CLIENT.Visibility = BarItemVisibility.Always
                    LBL_RESULT_CLIENT.Caption = Convert.ToString(Message.Value)
                Else
                    LBL_RESULT_CLIENT.Visibility = BarItemVisibility.Always
                    LBL_RESULT_CLIENT.Caption = Convert.ToString(Message.Value)
                End If
            End With


            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_AGENTS
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_CLIENT LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_CLIENT
                .DataSource = DataT
                .ValueMember = "ID_AGENTS"
                .DisplayMember = "AG_NAME_AGENT"
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()

        End Try
    End Sub
    Sub LIST_FOLIOS_DISTINCT()
        Try
            'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_DISTINCT_FOLIOS_USER E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_DISTINCT_FOLIOS_USER", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_DISTINCT_FOLIOS_USER
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_DISTINCT_FOLIOS_USER", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_DISTINCT_FOLIOS_USER SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    BarStaticItem1.Visibility = BarItemVisibility.Always
                    BarStaticItem1.Caption = Convert.ToString(Message.Value)
                Else
                    BarStaticItem1.Visibility = BarItemVisibility.Always
                    BarStaticItem1.Caption = Convert.ToString(Message.Value)
                End If
            End With
            'CREAMOS UN ADAPTADOR PARA EL COMANDO
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_SERIE LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_SERIE
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "ID_FOLIOS" 'EL VALOR QUE TENDRA
                .DisplayMember = "FO_NAME_SERIE_FOLIO" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()

        End Try
    End Sub
    Private Sub frm_users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FILL_DATA() 'SE LLAMA AL METODO QUE LLENA LA TABLA DE LOS REGISTROS EXISTENTES EN EL SISTEMA
    End Sub

    Private Sub BTN_SAVE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        'SE DECLARA UNA VARIABLE DE TIPO BOOLEAN INICIALIZADA EN FALSE PARA LA VALIDACION DEL LOS CAMPOS
        Dim VALIDA As Boolean = False
        'LOGICA SI AL COMPARAR EL VALOR CONTENIDO EN ALGUNA DE LAS CAJAS DE TEXTO EN SU PROPIEDAD TEXT ES IGUAL A UN VALOR VACIO ENTONCES MOSTRAR UN MENSAJE INDICANDO QUE HACE FALTA UN VALOR
        'SE ASIGNA A LA VARIABLE VALIDA EL VALOR DE TRUE PARA LA ULTIMA VALIDACION ANTES DEL REGISTRO

        If (TXT_NAME.Text = "") Then 'SI EL CAMPO TXT_NAME EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
            'MOSTRAR MENSAJE INDICANDO QUE FALTA LLENAR ESTE CAMPO
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA PERSONA PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_SAVE_ItemClick
        End If

        If (TXT_USERNAME.Text = "") Then 'SI EL CAMPO TXT_USERNAME EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
            'MOSTRAR MENSAJE INDICANDO QUE FALTA LLENAR ESTE CAMPO
            XtraMessageBox.Show("DEBE ESPECIFICAR SU NOMBRE DE ACCESO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_SAVE_ItemClick
        End If




        If (TXT_PASSWORD.Text = "") Then 'SI EL CAMPO TXT_PASSWORD EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
            'MOSTRAR MENSAJE INDICANDO QUE FALTA LLENAR ESTE CAMPO
            XtraMessageBox.Show("DEBE ESPECIFICAR SU CONTRASEÑA DE ACCESO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_SAVE_ItemClick
        End If

        'SI ALGUNO DE LOS CAMPOS ANTERIORES SE ENCUENTRA VACIO ENTONCES ENTRA A ESTA VALIDACION DONDE DEBE ESPECIFICARSE TODA LA INFORMACION
        If (VALIDA = True) Then
            'MOSTRAR MENSAJE DE ESPECIFICACION DE DATOS
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA EL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub ' SE CANCELA LA OPERACION ACTUAL
        Else 'EN CASO CONTRARIO QUE TODOS LOS CAMPOS ESTEN LLENOS Y NO FALTE NINGUN DATO
            Try
                'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                Connect_Database()
                'SE EJECUTA UN NUEVO COMANDO SP_SILV_USERS_INSERT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                Command = New SqlCommand("SP_SILV_USERS_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                With Command
                    .Parameters.Add("@ID_USER_TYPE", SqlDbType.Int).Value = CB_TYPE.SelectedValue 'SE ENVIA EL VALOR DEL TIPO DE USUARIO DESDE LA SELECCION DEL VALOR DE LA LISTA
                    .Parameters.Add("@ID_AGENTS", SqlDbType.Int).Value = CB_CLIENT.SelectedValue 'SE ENVIA EL VALOR DEL AGENTE DESDE LA SELECCION DEL VALOR DE LA LISTA
                    .Parameters.Add("@ID_FOLIOS", SqlDbType.Int).Value = CB_SERIE.SelectedValue ' SE ENVIA EL VALOR DEL FOLIO DESDE LA SELECCION DEL VALOR DE LA LISTA
                    .Parameters.Add("@US_NAME", SqlDbType.NVarChar, 200).Value = TXT_NAME.Text 'SE ENVIA EL VALOR DEL  NOMBRE DEL USUARIO DESDE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT
                    .Parameters.Add("@US_USERNAME", SqlDbType.NVarChar, 50).Value = TXT_USERNAME.Text 'SE ENVIA EL VALOR DEL USERNAME DEL USUARIO DESDE LA CAJA DE TEXTO TXT_USERNAME EN SU PROPIEDAD TEXT
                    .Parameters.Add("@US_PASSWORD", SqlDbType.NVarChar, 100).Value = TXT_PASSWORD.Text 'SE ENVIA EL VALOR DE LA CONTRASEÑA DESDE LA CAJA DE TEXTO TXT_PASSWORD EN SU PROPIEDAD TEXT

                    'SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                    'SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                    If (TXT_OBSERVATIONS.Text = "") Then
                        .Parameters.AddWithValue("@US_OBSERVATIONS", DBNull.Value)
                    Else
                        .Parameters.Add("@US_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                    End If

                    'SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    .Parameters.Add("@US_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                    'SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                    .Parameters.Add("@US_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption



                    'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_INSERT
                    Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                    'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output
                    'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    Command.Parameters.Add(Message)
                    'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USERS_INSERT", connection)
                    Rows = Command.ExecuteNonQuery

                    'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_USERS_INSERT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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

    Private Sub BTN_REFRESH_TYPE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_REFRESH_TYPE.ItemClick
        LIST_USER_TYPE() 'LLAMAMOS AL METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO QUE ACTUALIZA LA LISTA DE LOS TIPOS DE USUARIO
    End Sub

    Private Sub BTN_REFRESH_CLIENT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_REFRESH_CLIENT.ItemClick
        LIST_AGENTS() 'LLAMAMOS AL METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO QUE ACTUALIZA LA LISTA DE LOS CLIENTES/VENDEDOR
    End Sub

    Private Sub BTN_REFRESH_FOLIOS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_REFRESH_FOLIOS.ItemClick
        LIST_FOLIOS_DISTINCT() 'LLAMAMOS AL METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO QUE ACTUALIZA LA LISTA DE LOS FOLIOS
    End Sub

    Private Sub BTN_EDIT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_EDIT.ItemClick
        'SE DECLARA UNA VARIABLE DE TIPO BOOLEAN INICIALIZADA EN FALSE PARA LA VALIDACION DEL LOS CAMPOS
        Dim VALIDA As Boolean = False
        'LOGICA SI AL COMPARAR EL VALOR CONTENIDO EN ALGUNA DE LAS CAJAS DE TEXTO EN SU PROPIEDAD TEXT ES IGUAL A UN VALOR VACIO ENTONCES MOSTRAR UN MENSAJE INDICANDO QUE HACE FALTA UN VALOR
        'SE ASIGNA A LA VARIABLE VALIDA EL VALOR DE TRUE PARA LA ULTIMA VALIDACION ANTES DEL REGISTRO


        If (TXT_ID.Text = "") Then 'SI EL CAMPO TXT_ID EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
            'MOSTRAR UN MENSAJE INDICANDO QUE FALTA UN VALOR POR ESPECIFICAR
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
        End If


        If (TXT_NAME.Text = "") Then 'SI EL CAMPO TXT_NAME EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
            'MOSTRAR UN MENSAJE INDICANDO QUE FALTA UN VALOR POR ESPECIFICAR
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA PERSONA PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
        End If

        If (TXT_USERNAME.Text = "") Then 'SI EL CAMPO TXT_USERNAME EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
            'MOSTRAR UN MENSAJE INDICANDO QUE FALTA UN VALOR POR ESPECIFICAR
            XtraMessageBox.Show("DEBE ESPECIFICAR SU NOMBRE DE ACCESO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
        End If


        If (TXT_PASSWORD.Text = "") Then 'SI EL CAMPO TXT_PASSWORD EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
            'MOSTRAR UN MENSAJE INDICANDO QUE FALTA UN VALOR POR ESPECIFICAR
            XtraMessageBox.Show("DEBE ESPECIFICAR SU CONTRASEÑA DE ACCESO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True 'SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
        End If

        'SI ALGUNO DE LOS CAMPOS ANTERIORES SE ENCUENTRA VACIO ENTONCES ENTRA A ESTA VALIDACION DONDE DEBE ESPECIFICARSE TODA LA INFORMACION
        If (VALIDA = True) Then
            'MOSTRAR MENSAJE DE ESPECIFICACION DE DATOS
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA EL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub ' SE CANCELA LA OPERACION ACTUAL Private Sub BTN_EDIT_ItemClick
        Else 'EN CASO CONTRARIO QUE NO FALTE INFORMACION POR ESPECIFICAR ENTONCES PREGUNTAR SI SE DESEA MODIFICAR EL REGISTRO, SI EL USUARIO PRESIONA NO ENTONCES
            If (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL USUARIO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub 'CANCELA LA OPERACION ACTUAL Private Sub BTN_EDIT_ItemClick
            Else 'EL USUARIO PRESIONO QUE SI DESEA MODIFICAR EL REGISTRO ENTONCES
                Try
                    'ESTABLECER UNA CONEXION CON LA BASE DE DATOS
                    Connect_Database()
                    'SE EJECUTA UN NUEVO COMANDO SP_SILV_USERS_EDIT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    Command = New SqlCommand("SP_SILV_USERS_EDIT", connection) With {.CommandType = CommandType.StoredProcedure}
                    'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                    With Command
                        .Parameters.Add("@ID_USER", SqlDbType.Int).Value = TXT_ID.Text 'SE ENVIA EL PARAMETRO ID_USER MEDIANTE LA CAJA DE TEXTO TXT_ID EN SU PROPIEDAD TEXT
                        .Parameters.Add("@ID_USER_TYPE", SqlDbType.Int).Value = CB_TYPE.SelectedValue 'SE ENVIA EL PARAMETRO ID_USER_TYPE MEDIANTE LA SELECCION DEL VALOR DE LA LISTA TIPO DE USUARIO
                        .Parameters.Add("@US_NAME", SqlDbType.NVarChar, 200).Value = TXT_NAME.Text 'SE ENVIA EL PARAMETRO US_NAME MEDIANTE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT
                        .Parameters.Add("@US_USERNAME", SqlDbType.NVarChar, 50).Value = TXT_USERNAME.Text ' SE ENVIA EL PARAMETRO US_USERNAME MEDIANTE LA CAJA DE TEXTO TXT_USERNAME EN SU PROPIEDAD TEXT
                        .Parameters.Add("@US_PASSWORD", SqlDbType.NVarChar, 100).Value = TXT_PASSWORD.Text ' SE ENVIA EL PARAMETRO US_PASSWORD MEDIANTE LA CAJA DE TEXTO TXT_PASSWORD EN SU PROPIEDAD TEXT


                        'SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                        'SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                        If (TXT_OBSERVATIONS.Text = "") Then
                            .Parameters.AddWithValue("@US_OBSERVATIONS", DBNull.Value)
                        Else
                            .Parameters.Add("@US_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                        End If

                        'SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                        .Parameters.Add("@US_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                        'SE ENVIA EL PARAMETRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                        .Parameters.Add("@US_USER_UPDATE", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

                        'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_EDIT
                        Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                        'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output
                        'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        Command.Parameters.Add(Message)
                        'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USERS_EDIT", connection)
                        Rows = Command.ExecuteNonQuery
                        'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_USERS_EDIT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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
        End If
    End Sub

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick
        'SE VERIFICA QUE ANTES DE REALIZAR UNA ELIMINACION DE UN REGISTRO ESTE COINCIDA CON EL QUE SE REQUIERE ELIMINAR Y ESTO SE REALIZA MEDIANTE EL VALOR DE LA CAJA DE TEXTO TXT_ID EN SU PROPIEDAD TEXT

        If (TXT_ID.Text = "") Then 'SI LA CAJA DE TEXTO TXT_ID ESTA VACIA ENTONCES
            'SE MUESTRA UN MENSAJE INDICANDO QUE SE DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO A ELIMINAR
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub 'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
        Else 'EN CASO CONTRARIO DE QUE SI SE HAYA ESPECIFICADO EL IDENTIFICADOR DEL REGISTRO
            'SE PREGUNTA AL USUARIO SI SE DESEA ELIMINAR EL REGISTRO, SI EL USUARIO PRESIONO EL BOTON NO ENTONCES
            If (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL USUARIO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub 'SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
            Else 'EN CASO CONTRARIO QUE EL USUARIO HAYA PRESIONADO QUE SI ENTONCES
                Try
                    'SE ESTABLECE LA CONEXION CON LA BASE DE DATOS
                    Connect_Database()
                    'SE EJECUTA UN NUEVO COMANDO SP_SILV_USERS_DELETE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    Command = New SqlCommand("SP_SILV_USERS_DELETE", connection) With {.CommandType = CommandType.StoredProcedure}
                    'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                    With Command

                        .Parameters.Add("@ID_USER", SqlDbType.Int).Value = TXT_ID.Text 'SE ESPECIFICA EL VALOR DEL PARAMETRO ID_USER MEDIANTE LA CAJA DE TEXTO TXT_ID EN SU PROPIEDAD TEXT

                        'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_DELETE
                        Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                        'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output
                        'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        Command.Parameters.Add(Message)
                        'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USERS_DELETE", connection)
                        Rows = Command.ExecuteNonQuery
                        'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_USERS_DELETE SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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

        End If
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
            LIST_VALUE_USER_TYPE() 'EJECUTAMOS ESTE METODO PARA OBTENER EL VALOR DEL TIPO DE USUARIO UNA VEZ QUE SE DA DOBLE CLIC SOBRE UN REGISTRO
        End If
    End Sub

    Private Sub BTN_CLEAN_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_CLEAN.ItemClick
        CLEAN_FIELDS() 'SE LLAMA A ESTE METODO PARA LIMPIAR LOS CAMPOS DE TEXTO DEL FORMULARIO

    End Sub

    Private Sub BTN_SHOW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_SHOW.ItemClick
        FILL_DATA() 'SE LLAMA A ESTE METODO PARA ACTUALIZAR LA VISTA DE LOS REGISTROS

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


    'METODO QUE REALIZA LA OPERACION DE ASIGNAR UN VALOR AL IDENTIFICADOR, NOMBRE Y OBSERVACIONES DE LA CIUDAD REALIZANDO UN DOBLE CLIC SOBRE UN REGISTRO
    Private Sub G_DATA_DoubleClick(sender As Object, e As EventArgs) Handles G_DATA.DoubleClick

        Try
            'LA CAJA DE TEXTO TXT_ID OBTENDRA EL VALOR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "ID"
            TXT_ID.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"), String)
            'LA CAJA DE TEXTO TXT_NAME OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "NOMBRE DEL USUARIO"
            TXT_NAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE DEL USUARIO"), String)
            'LA CAJA DE TEXTO TXT_USERNAME OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "USUARIO"
            TXT_USERNAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "USUARIO"), String)
            'LA CAJA DE TEXTO TXT_PASSWORD OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "USUARIO"
            TXT_PASSWORD.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CONTRASEÑA"), String)


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
End Class