'LIBRERIAS PARA MANEJO DE SQL Y MENSAJES PERSONALIZADOS DEVEXPRESS
Imports DevExpress.XtraEditors
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraBars
Imports SILVER_ONE_ERP.ServicioDatos
Public Class frm_login


    '#Region "METODOS"
    '    Sub LIST_COMPANY()
    '        Try
    '            Connect_Database()
    '            Command = New SqlCommand("SP_LIST_COMPANY_LOGIN", connection) With {.CommandType = CommandType.StoredProcedure}
    '            With Command
    '                ' .Parameters.Add("@ID_EMPLOYEE", SqlDbType.Int).Value = TXT_ID.Text.Trim
    '                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
    '                Message.Direction = ParameterDirection.Output
    '                Command.Parameters.Add(Message)
    '                Rows = Command.ExecuteNonQuery
    '                If (Rows > 0) Then
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                Else
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                End If
    '            End With
    '            Adapter.SelectCommand = Command
    '            DataT = New DataTable
    '            Adapter.Fill(DataT)
    '            With CB_COMPANY
    '                .DataSource = DataT
    '                .ValueMember = "ID_COMPANY"
    '                .DisplayMember = "COM_NAME_COMPANY"
    '            End With
    '        Catch ex As Exception
    '            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            Disconnect_Database()

    '        End Try
    '    End Sub
    '    Sub LIST_DATA_SOURCE()
    '        Try
    '            Connect_Database()
    '            Command = New SqlCommand("SP_LIST_DATA_SOURCE_COMPANY_LOGIN", connection) With {.CommandType = CommandType.StoredProcedure}
    '            With Command
    '                .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = CB_COMPANY.SelectedValue
    '                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
    '                Message.Direction = ParameterDirection.Output
    '                Command.Parameters.Add(Message)
    '                Rows = Command.ExecuteNonQuery
    '                If (Rows > 0) Then
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                Else
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                End If
    '            End With
    '            Adapter.SelectCommand = Command
    '            DataT = New DataTable
    '            Adapter.Fill(DataT)
    '            With frn_main_form.CB_SERVER
    '                .DataSource = DataT
    '                .ValueMember = "ID_COMPANY"
    '                .DisplayMember = "COM_SERVER"
    '            End With
    '        Catch ex As Exception
    '            '  XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            Disconnect_Database()

    '        End Try
    '    End Sub
    '    Sub LIST_DATABASE()
    '        Try
    '            Connect_Database()
    '            Command = New SqlCommand("SP_LIST_DATABASE_COMPANY_LOGIN", connection) With {.CommandType = CommandType.StoredProcedure}
    '            With Command
    '                .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = CB_COMPANY.SelectedValue
    '                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
    '                Message.Direction = ParameterDirection.Output
    '                Command.Parameters.Add(Message)
    '                Rows = Command.ExecuteNonQuery
    '                If (Rows > 0) Then
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                Else
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                End If
    '            End With
    '            Adapter.SelectCommand = Command
    '            DataT = New DataTable
    '            Adapter.Fill(DataT)
    '            With frn_main_form.CB_DATABASE
    '                .DataSource = DataT
    '                .ValueMember = "ID_COMPANY"
    '                .DisplayMember = "COM_DB"
    '            End With
    '        Catch ex As Exception
    '            '  XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            Disconnect_Database()

    '        End Try
    '    End Sub
    '    Sub LIST_USERNAME()
    '        Try
    '            Connect_Database()
    '            Command = New SqlCommand("SP_LIST_USERNAME_LOGIN", connection) With {.CommandType = CommandType.StoredProcedure}
    '            With Command
    '                .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = CB_COMPANY.SelectedValue
    '                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
    '                Message.Direction = ParameterDirection.Output
    '                Command.Parameters.Add(Message)
    '                Rows = Command.ExecuteNonQuery
    '                If (Rows > 0) Then
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                Else
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                End If
    '            End With
    '            Adapter.SelectCommand = Command
    '            DataT = New DataTable
    '            Adapter.Fill(DataT)
    '            With frn_main_form.CB_USERNAME
    '                .DataSource = DataT
    '                .ValueMember = "ID_COMPANY"
    '                .DisplayMember = "COM_USERNAME"
    '            End With
    '        Catch ex As Exception
    '            ' XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            Disconnect_Database()

    '        End Try
    '    End Sub
    '    Sub LIST_PASSWORD()
    '        Try
    '            Connect_Database()
    '            Command = New SqlCommand("SP_LIST_PASSWORD_LOGIN", connection) With {.CommandType = CommandType.StoredProcedure}
    '            With Command
    '                .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = CB_COMPANY.SelectedValue
    '                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
    '                Message.Direction = ParameterDirection.Output
    '                Command.Parameters.Add(Message)
    '                Rows = Command.ExecuteNonQuery
    '                If (Rows > 0) Then
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                Else
    '                    LBL_CONTROL.Visible = BarItemVisibility.Always
    '                    LBL_CONTROL.Text = Convert.ToString(Message.Value)
    '                End If
    '            End With
    '            Adapter.SelectCommand = Command
    '            DataT = New DataTable
    '            Adapter.Fill(DataT)
    '            With frn_main_form.CB_PASSWORD
    '                .DataSource = DataT
    '                .ValueMember = "ID_COMPANY"
    '                .DisplayMember = "COM_PASSWORD"
    '            End With
    '        Catch ex As Exception
    '            '  XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            Disconnect_Database()

    '        End Try
    '    End Sub
    '#End Region


    Private Sub btn_access_Click(sender As Object, e As EventArgs) Handles btn_access.Click
        'Declaramos una variable de tipo boolean inicializada en falso para evaluar los siguientes casos
        Dim VALIDA As Boolean = False

        'Si la caja de texto nombre de usuario esta vacia entonces
        If (txt_username.Text.Trim = "") Then
            'mostramos un mensaje al usuario indicando que el campo no pude quedar vacio
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'asignamos el valor de verdadero a la variable
            VALIDA = True
            'asignamos el foco (cursor) a la caja de texto nombre de usuario
            txt_username.Focus()
        End If
        'si la caja de texto de la contraseña esta vacia entonces
        If (txt_password.Text.Trim = "") Then
            'mostramos un mensaje al usuario indicando que el campo no pude quedar vacio
            XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASEÑA DEL USUARIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'asignamos el valor de verdadero a la variable
            VALIDA = True
            'asignamos el foco (cursor) a la caja de texto contraseña
            txt_password.Focus()
        End If

        'SE ANEXA CODIGO PARA VALIDACION DE USUARIO Y CONTRASEÑA MAESTRA QUE SE ENCUENTRA DECLARADA EN EL MODULO MetodosClases
        'SI EL TEXTO DE LAS CAJAS DE TEXTO COINCIDE CON EL USUARIO Y CONTRASEÑA MAESTRA ENTONCES
        If (txt_username.Text = Username And txt_password.Text = Password) Then
            'ESCONDEMOS ESTE FORMULARIO (frm_login)
            Me.Hide()
            'MOSTRAMOS EL FORMULARIO PRINCIPAL DEL SISTEMA
            frn_main_form.Show()
            'LIMPIAMOS AMBAS CAJAS DE TEXTO
            txt_password.ResetText()
            txt_username.ResetText()
        Else 'EN CASO CONTRARIO QUE NO COINCIDA EL TEXTO 
            If (VALIDA = True) Then ' SI LA VALIDACION DE LOS CAMPOS VACIOS ES VERDADERA (SE ENCONTRO UN VALOR VACIO ENTONCES
                Exit Sub 'CANCELAMOS LA OPERACION ACTUAL (Private Sub btn_access_Click) EL CLIC DEL BOTON
            Else 'EN CASO CONTRARIO
                Try 'INTENTAR
                    'SE REALIZA LA CONEXION A LA BASE DE DATOS
                    Connect_Database()
                    'establece_conexion()

                    '*METODOS usuarioregistrado y ConsultarTipoUsuario se encuentran en el modulo Metodosclases
                    'SI LA EVALUACION DE UN REGISTRO COINCIDE CON EL NOMBRE DE USUARIO PROPORCIONADO ENTONCES
                    If UsuarioRegistrado(txt_username.Text) = True Then
                        'DECLARAMOS UNA VARIABLE QUE ALMACENE EL NOMBRE DEL USUARIO Y PASAR COMO PARAMETRO A LA FUNCION CONTRASENA
                        Dim contra As String = Contrasena(txt_username.Text)
                        'SI EL VALOR RESULTANTE ES IGUAL (.EQUALS) A LA INFORMACION QUE TENGA LA CAJA DE TEXTO TXT_PASSWORD ENTONCES
                        'USUARIO Y CONTRASEÑA ESTAN CORRECTOS Y COINCIDEN CON UN REGISTRO DE LA BD
                        If contra.Equals(txt_password.Text) = True Then
                            Me.Hide() ' ESCONDEMOS ESTE FORMULARIO (frm_login)
                            'SE REALIZA UNA ULTIMA EVALUACION QUE NOS INDIQUE EL TIPO DE USUARIO DEL SISTEMA
                            'SI EL TIPO DE USUARIO ES 1=ADMIN ENTONCES
                            If ConsultarTipoUsuario(txt_username.Text) = 1 Then
                                frn_main_form.ShowDialog() ' ADMINISTRATOR
                                '  ElseIf ConsultarTipoUsuario(txt_username.Text) = 2 Then
                            End If
                        Else
                            'LA CONTRASEÑA ESTA INCORRECTA Y SE ASIGNA EL FOCO A TXT_USERNAME 
                            XtraMessageBox.Show("CONTRASEÑA INVALIDA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txt_username.Focus()
                        End If
                    Else ' EN CASO CONTRARIO EL USUARIO NO SE ENCUENTRA REGISTRADO EN LA BASE DE DATOS
                        XtraMessageBox.Show("EL USUARIO:--" + txt_username.Text + "--NO SE ENCUENTRA REGISTRADO O SU CUENTA ESTA DESACTIVADA")
                        ' SE ASIGNA EL FOCO A TXT_USERNAME 
                        txt_username.Focus()
                    End If
                Catch ex As Exception
                    'MENSAJE DE ERROR EN CASO DE QUE SUCEDA UN ERROR DENTRO DEL CODIGO TRY
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'FINALMENTE
                Finally
                    'CERRAMOS LA CONEXION A LA BASE DE DATOS
                    Disconnect_Database()
                    'SE LIMPIAN LAS CAJAS DE TEXTO
                    txt_password.ResetText()
                    txt_username.ResetText()
                    'SE ASIGNA EL FOCO A LA CAJA DE TEXTO DEL NOMBRE DEL USUARIO
                    txt_username.Focus()
                    '  FRM_AUX.LB_USER.Caption = Me.TXT_USER.Text.Trim().ToUpper
                End Try
            End If
        End If
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'LOGICA--> SI EL USUARIO PRESIONA EL BOTON SALIR Y ESTE PRESIONA EL BOTON NO ENTONCES CANCELA LA OPERACION EN CASO CONTRARIO
        'SALIR COMPLETAMENTE DEL SISTEMA
        If (XtraMessageBox.Show("¿DESEA SALIR COMPLETAMENTE DEL SISTEMA?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            Exit Sub
        Else
            Me.Close() 'SE CIERRA ESTE FORMULARIO
            Application.ExitThread() 'SE LIBERAN LOS RECURSOS DE LA APLICACION
            Application.Exit() 'SE SALE COMPLETAMENTE DE LA APLICACION
        End If
    End Sub

    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If VerificaInstancia() = False Then
            CheckForIllegalCrossThreadCalls = False
            Dim mac As String = getMacAddressLocal()
            Dim serviceDatos As New ServicioDatos.WebService1SoapClient()


        End If


    End Sub
End Class