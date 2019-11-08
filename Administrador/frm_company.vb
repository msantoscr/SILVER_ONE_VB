Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports System.IO
Public Class frm_company
    Dim img() As Byte
#Region "Metodos Imagen"
    'funcion para convertir imagen a binario
    Private Function imagen_bytes(ByVal Imagen As Image) As Byte()
        If Not Imagen Is Nothing Then
            'variable de datos binarios
            Dim bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(bin, Imaging.ImageFormat.Jpeg)
            'RETORNA BINARIO
            Return bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    'funcion para convertir binario a imagen
    Private Function bytes_imagen(ByVal Imagen As Byte()) As Image
        Try
            ' si hay una imagen
            If Not Imagen Is Nothing Then
                '   capturamos el arreglo con memorystream hacia bin
                Dim bin As New MemoryStream(Imagen)
                '    con el metodo fromstream de image obtenemos la imagen
                Dim resultado As Image = Image.FromStream(bin)
                '   la retornamos
                Return resultado
            Else
                Return Nothing

            End If
        Catch ex As Exception
            Return Nothing

        End Try
    End Function
    Sub search_img()
        Try
            Connect_Database()
            Command = New SqlCommand("SP_OBTAIN_IMAGE_LOGO", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = TXT_ID.Text
                Dim msgparam As New SqlParameter("@MENSAJE", SqlDbType.VarChar, 100) With {.Direction = ParameterDirection.Output}
                .Parameters.Add(msgparam)
                Dim rowsAffected As Integer = Command.ExecuteNonQuery()
                Dim mensaje As String = ""
                If rowsAffected > 0 Then
                    'Convert.ToString(XtraMessageBox.Show(CType(COMANDO.Parameters("@MSG").Value, String), "SGI-TEBAEV", MessageBoxButtons.OK))
                    LBL_PHOTO.Visibility = CType(True, DevExpress.XtraBars.BarItemVisibility)

                    LBL_PHOTO.Caption = Convert.ToString(Command.Parameters("@MENSAJE").Value)
                Else
                    'Convert.ToString(XtraMessageBox.Show(CType(COMANDO.Parameters("@MSG").Value, String), "SGI-TEBAEV", MessageBoxButtons.OK))
                    LBL_PHOTO.Visibility = CType(True, DevExpress.XtraBars.BarItemVisibility)
                    LBL_PHOTO.Caption = Convert.ToString(Command.Parameters("@MENSAJE").Value)
                End If
            End With
            Dim lectores As SqlDataReader
            lectores = Command.ExecuteReader

            Do While lectores.Read
                Me.pc_img.Image = bytes_imagen(CType(lectores.GetValue(0), Byte()))
                Exit Do
            Loop
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect_Database()


        End Try
    End Sub

#End Region

    Sub CLEAN_FIELDS()
        TXT_ID.ResetText()
        TXT_NAME.ResetText()
        TX_ADDRESS.ResetText()
        'TXT_OBSERVATIONS.ResetText()
        C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked
        C_LOCAL.CheckState = CheckState.Unchecked
        C_SERVIDOR.CheckState = CheckState.Unchecked
        C_SERVIDOR_SUCURSAL.CheckState = CheckState.Unchecked
        txt_obs.ResetText()
        TXT_RFC.ResetText()
        TXT_USERNAME.ResetText()
        TXT_PASSWORD.ResetText()

        Me.pc_img.Image = Nothing
    End Sub
    Sub FILL_DATA()
        Try
            Connect_Database()
            Command = New SqlCommand("SP_SILV_COMPANY_VIEW", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                Message.Direction = ParameterDirection.Output
                Command.Parameters.Add(Message)
                Rows = Command.ExecuteNonQuery
                If (Rows > 0) Then
                    LBL_RESULT.Visibility = BarItemVisibility.Always
                    LBL_RESULT.Caption = Convert.ToString(Message.Value)
                Else
                    LBL_RESULT.Visibility = BarItemVisibility.Always
                    LBL_RESULT.Caption = Convert.ToString(Message.Value)
                End If
                Adapter = New SqlDataAdapter(Command)
                DataT = New DataTable
                Adapter.Fill(DataT)
                DGV_DATA.DataSource = DataT
                G_DATA.BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect_Database()
        End Try
    End Sub
    Private Sub BTN_PREVIEW_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_PREVIEW.ItemClick
        DGV_DATA.ShowRibbonPrintPreview()
    End Sub

    Private Sub BTN_PRINT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_PRINT.ItemClick
        DGV_DATA.PrintDialog()
    End Sub

    Private Sub SHOW_PANEL_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SHOW_PANEL.ItemClick
        Me.G_DATA.OptionsFind.AlwaysVisible = True
        SHOW_PANEL.Enabled = False
        HIDE_PANEL.Enabled = True
    End Sub

    Private Sub HIDE_PANEL_ItemClick(sender As Object, e As ItemClickEventArgs) Handles HIDE_PANEL.ItemClick
        Me.G_DATA.OptionsFind.AlwaysVisible = False
        SHOW_PANEL.Enabled = True
        HIDE_PANEL.Enabled = False
    End Sub

    Private Sub VIEW_AUTOFILTER_ItemClick(sender As Object, e As ItemClickEventArgs) Handles VIEW_AUTOFILTER.ItemClick
        Me.G_DATA.OptionsView.ShowAutoFilterRow = True
        VIEW_AUTOFILTER.Enabled = False
        HIDE_AUTOFILTER.Enabled = True
    End Sub

    Private Sub HIDE_AUTOFILTER_ItemClick(sender As Object, e As ItemClickEventArgs) Handles HIDE_AUTOFILTER.ItemClick
        Me.G_DATA.OptionsView.ShowAutoFilterRow = False
        VIEW_AUTOFILTER.Enabled = True
        HIDE_AUTOFILTER.Enabled = False
    End Sub

    Private Sub BTN_SAVE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        Dim VALIDA As Boolean = False


        If (TXT_NAME.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA EMPRESA", "SISTEMAS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If

        If (TXT_RFC.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL RFC DE LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        'SERVER
        If (TXT_SERVIDOR.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL SERVIDOR DE LA BASE DE DATOS ASIGNADO A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        'DATABASE
        If (TXT_DB.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA BASE DE DATOS ASIGNADA A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        'USER
        If (TXT_USERNAME.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO DE LA BASE DE DATOS ASIGNADO A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        'PASSWORD
        If (TXT_PASSWORD.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASEÑA DE LA BASE DE DATOS ASIGNADA A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If

        If (VALIDA = True) Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA REGISTRAR LA EMPRESA EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            Try
                Connect_Database()
                Command = New SqlCommand("SP_SILV_COMPANY_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                With Command
                    .Parameters.Add("@COM_NAME_COMPANY", SqlDbType.NVarChar, 200).Value = TXT_NAME.Text
                    If (TX_ADDRESS.Text = "") Then
                        .Parameters.AddWithValue("@COM_ADDRESS", DBNull.Value)
                    Else
                        .Parameters.Add("@COM_ADDRESS", SqlDbType.NVarChar, 100).Value = TX_ADDRESS.Text
                    End If

                    If (TXT_RFC.Text = "") Then
                        .Parameters.AddWithValue("@COM_RFC", DBNull.Value)
                    Else
                        .Parameters.Add("@COM_RFC", SqlDbType.NVarChar, 100).Value = TXT_RFC.Text
                    End If

                    If (txt_obs.Text = "") Then
                        .Parameters.AddWithValue("@COM_OBSERVATIONS", DBNull.Value)
                    Else
                        .Parameters.Add("@COM_OBSERVATIONS", SqlDbType.NVarChar, 100).Value = txt_obs.Text
                    End If

                    .Parameters.Add("@COM_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState

                    img = imagen_bytes(Me.pc_img.Image)
                    .Parameters.AddWithValue("@COM_LOGO", img)

                    .Parameters.Add("@COM_NUMBER_COMPANY", SqlDbType.NVarChar, 50).Value = CB_NUMERO.Text
                    .Parameters.Add("@COM_SERVER", SqlDbType.NVarChar, 50).Value = TXT_SERVIDOR.Text
                    .Parameters.Add("@COM_DB", SqlDbType.NVarChar, 50).Value = TXT_DB.Text
                    .Parameters.Add("@COM_USERNAME", SqlDbType.NVarChar, 50).Value = TXT_USERNAME.Text
                    .Parameters.Add("@COM_PASSWORD", SqlDbType.NVarChar, 50).Value = TXT_PASSWORD.Text

                    If (C_SERVIDOR.CheckState = CheckState.Unchecked) Then
                        .Parameters.AddWithValue("@COM_IS_SERVER", DBNull.Value)
                    Else
                        .Parameters.Add("@COM_IS_SERVER", SqlDbType.Int).Value = C_SERVIDOR.CheckState
                    End If

                    If (C_SERVIDOR_SUCURSAL.CheckState = CheckState.Unchecked) Then
                        .Parameters.AddWithValue("@COM_IS_SERVER_SUC", DBNull.Value)
                    Else
                        .Parameters.Add("@COM_IS_SERVER_SUC", SqlDbType.Int).Value = C_SERVIDOR_SUCURSAL.CheckState
                    End If

                    If (C_LOCAL.CheckState = CheckState.Unchecked) Then
                        .Parameters.AddWithValue("@COM_IS_LOCAL", DBNull.Value)
                    Else
                        .Parameters.Add("@COM_IS_LOCAL", SqlDbType.Int).Value = C_LOCAL.CheckState
                    End If

                    .Parameters.Add("@COM_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

                    Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                    Message.Direction = ParameterDirection.Output
                    Command.Parameters.Add(Message)
                    Rows = Command.ExecuteNonQuery
                    If (Rows > 0) Then
                        XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                    Else
                        XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                    End If
                End With
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Disconnect_Database()
                CLEAN_FIELDS()
                FILL_DATA()
            End Try
        End If
    End Sub

    Private Sub BTN_EDIT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_EDIT.ItemClick
        Dim VALIDA As Boolean = False
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If

        If (TXT_NAME.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA EMPRESA", "SISTEMAS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If

        If (TXT_RFC.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL RFC DE LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        'SERVER
        If (TXT_SERVIDOR.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL SERVIDOR DE LA BASE DE DATOS ASIGNADO A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        'DATABASE
        If (TXT_DB.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA BASE DE DATOS ASIGNADA A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        'USER
        If (TXT_USERNAME.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO DE LA BASE DE DATOS ASIGNADO A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        'PASSWORD
        If (TXT_PASSWORD.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASEÑA DE LA BASE DE DATOS ASIGNADA A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        If (VALIDA = True) Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If (XtraMessageBox.Show("¿DESEA MODIFICAR LA INFORMACION DE LA EMPRESA?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub
            Else
                Try
                    Connect_Database()
                    Command = New SqlCommand("SP_SILV_COMPANY_EDIT", connection) With {.CommandType = CommandType.StoredProcedure}
                    With Command
                        .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = TXT_ID.Text
                        .Parameters.Add("@COM_NAME_COMPANY", SqlDbType.NVarChar, 200).Value = TXT_NAME.Text
                        If (TX_ADDRESS.Text = "") Then
                            .Parameters.AddWithValue("@COM_ADDRESS", DBNull.Value)
                        Else
                            .Parameters.Add("@COM_ADDRESS", SqlDbType.NVarChar, 100).Value = TX_ADDRESS.Text
                        End If

                        If (TXT_RFC.Text = "") Then
                            .Parameters.AddWithValue("@COM_RFC", DBNull.Value)
                        Else
                            .Parameters.Add("@COM_RFC", SqlDbType.NVarChar, 100).Value = TXT_RFC.Text
                        End If


                        If (txt_obs.Text = "") Then
                            .Parameters.AddWithValue("@COM_OBSERVATIONS", DBNull.Value)
                        Else
                            .Parameters.Add("@COM_OBSERVATIONS", SqlDbType.NVarChar, 100).Value = txt_obs.Text
                        End If

                        .Parameters.Add("@COM_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState


                        img = imagen_bytes(Me.pc_img.Image)
                        .Parameters.AddWithValue("@COM_LOGO", img)
                        '*******************************************

                        .Parameters.Add("@COM_NUMBER_COMPANY", SqlDbType.NVarChar, 50).Value = CB_NUMERO.Text
                        .Parameters.Add("@COM_SERVER", SqlDbType.NVarChar, 50).Value = TXT_SERVIDOR.Text
                        .Parameters.Add("@COM_DB", SqlDbType.NVarChar, 50).Value = TXT_DB.Text
                        .Parameters.Add("@COM_USERNAME", SqlDbType.NVarChar, 50).Value = TXT_USERNAME.Text
                        .Parameters.Add("@COM_PASSWORD", SqlDbType.NVarChar, 50).Value = TXT_PASSWORD.Text

                        If (C_SERVIDOR.CheckState = CheckState.Unchecked) Then
                            .Parameters.AddWithValue("@COM_IS_SERVER", DBNull.Value)
                        Else
                            .Parameters.Add("@COM_IS_SERVER", SqlDbType.Int).Value = C_SERVIDOR.CheckState
                        End If

                        If (C_SERVIDOR_SUCURSAL.CheckState = CheckState.Unchecked) Then
                            .Parameters.AddWithValue("@COM_IS_SERVER_SUC", DBNull.Value)
                        Else
                            .Parameters.Add("@COM_IS_SERVER_SUC", SqlDbType.Int).Value = C_SERVIDOR_SUCURSAL.CheckState
                        End If

                        If (C_LOCAL.CheckState = CheckState.Unchecked) Then
                            .Parameters.AddWithValue("@COM_IS_LOCAL", DBNull.Value)
                        Else
                            .Parameters.Add("@COM_IS_LOCAL", SqlDbType.Int).Value = C_LOCAL.CheckState
                        End If
                        '*******************************************
                        .Parameters.Add("@COM_USER_UPDATE", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

                        Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                        Message.Direction = ParameterDirection.Output
                        Command.Parameters.Add(Message)
                        Rows = Command.ExecuteNonQuery
                        If (Rows > 0) Then
                            XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                        Else
                            XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                        End If
                    End With
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Disconnect_Database()
                    CLEAN_FIELDS()
                    FILL_DATA()
                End Try
            End If
        End If
    End Sub

    Private Sub TXT_ID_TextChanged(sender As Object, e As EventArgs) Handles TXT_ID.TextChanged
        If (TXT_ID.Text = "") Then
            BTN_DELETE.Enabled = False
            BTN_EDIT.Enabled = False
            BTN_SAVE.Enabled = True
        Else
            BTN_EDIT.Enabled = True
            BTN_DELETE.Enabled = True
            BTN_SAVE.Enabled = False
            search_img()
        End If
    End Sub

    Private Sub G_DATA_DoubleClick(sender As Object, e As EventArgs) Handles G_DATA.DoubleClick
        Try
            TXT_ID.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"), String)
            TXT_NAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE COMPAÑIA"), String)


            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "DIRECCION"))) Then
                TX_ADDRESS.Text = ""
            Else
                TX_ADDRESS.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "DIRECCION"), String)

            End If

            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "RFC"))) Then
                TXT_RFC.Text = ""
            Else
                TXT_RFC.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "RFC"), String)

            End If

            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"))) Then
                txt_obs.Text = ""
            Else
                txt_obs.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"), String)
            End If
            'NUMERO DE COMPAÑIA
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NUMERO COMPAÑIA"))) Then
                CB_NUMERO.Text = ""
            Else
                CB_NUMERO.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NUMERO COMPAÑIA"), String)
            End If
            'SERVIDOR
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "SERVIDOR"))) Then
                TXT_SERVIDOR.Text = ""
            Else
                TXT_SERVIDOR.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "SERVIDOR"), String)
            End If
            'BASE DE DATOS
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "BASE DATOS"))) Then
                TXT_DB.Text = ""
            Else
                TXT_DB.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "BASE DATOS"), String)
            End If
            'USUARIO
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "USUARIO"))) Then
                TXT_USERNAME.Text = ""
            Else
                TXT_USERNAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "USUARIO"), String)
            End If
            'PASSWORD
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CONTRASEÑA"))) Then
                TXT_PASSWORD.Text = ""
            Else
                TXT_PASSWORD.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CONTRASEÑA"), String)
            End If
            'ES SERVIDOR
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES SERVIDOR"))) Then
                C_SERVIDOR.CheckState = CheckState.Unchecked
            Else
                C_SERVIDOR.CheckState = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES SERVIDOR"), CheckState)
            End If
            'ES SUCURSAL
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES SUCURSAL"))) Then
                C_SERVIDOR_SUCURSAL.CheckState = CheckState.Unchecked
            Else
                C_SERVIDOR_SUCURSAL.CheckState = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES SUCURSAL"), CheckState)
            End If
            'ES LOCAL
            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES LOCAL"))) Then
                C_LOCAL.CheckState = CheckState.Unchecked
            Else
                C_LOCAL.CheckState = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES LOCAL"), CheckState)
            End If


            C_ACTIVE_INACTIVE.CheckState = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO"), CheckState)


        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim openFileDialog1 As New OpenFileDialog() 'declaramos un cuadro de dialogo referenciado por openfilediaog1
        Dim result As New DialogResult 'el resultado del cuadro que declaramos


        openFileDialog1.InitialDirectory = "Bibliotecas\Imágenes\Imagenes públicas\Imagenes de muestra" 'damos el directorio inicial es donde buscara primero
        openFileDialog1.Filter = "archivos de imagen (*.jpg)|*.png|All files (*.*)|*.*" 'le damos 
        openFileDialog1.FilterIndex = 3
        openFileDialog1.RestoreDirectory = True
        result = openFileDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            pc_img.Image = Image.FromFile(openFileDialog1.FileName)

        End If
    End Sub

    Private Sub BTN_SHOW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_SHOW.ItemClick
        FILL_DATA()
    End Sub

    Private Sub BTN_LOCAL_CONNECTION_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_LOCAL_CONNECTION.ItemClick
        Dim VALIDA As Boolean = False
        'SERVER STRING
        If (TXT_SERVIDOR.Text.Trim = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL SERVIDOR A CONFIGURAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            VALIDA = True
            Exit Sub
        End If
        'DABATASE STRING
        If (TXT_DB.Text.Trim = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA BASE DE DATOS A CONFIGURAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            VALIDA = True
            Exit Sub
        End If
        'USERNAME STRING
        If (TXT_USERNAME.Text.Trim = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE USUARIO DE LA BASE DE DATOS A CONFIGURAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            VALIDA = True
            Exit Sub
        End If
        'PASSWORD STRING
        If (TXT_PASSWORD.Text.Trim = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE USUARIO DE LA BASE DE DATOS A CONFIGURAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            VALIDA = True
            Exit Sub
        End If

        'EXPORT DATA TO COMBOBOX
        If (VALIDA = True) Then
            XtraMessageBox.Show("FALTA INFORMACION POR ESPECIFICAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            frn_main_form.LBL_SERVER.Caption = TXT_SERVIDOR.Text
            frn_main_form.LBL_DATABASE.Caption = TXT_DB.Text
            frn_main_form.LBL_USER_DB.Caption = TXT_USERNAME.Text
            frn_main_form.LB_PASSWORD.Caption = TXT_PASSWORD.Text
            XtraMessageBox.Show("AHORA PUEDE CONFIGURAR LA EMPRESA SERVIDOR-LOCAL Y EMPRESA SERVIDOR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub BTN_TEST_CONNECT_Click(sender As Object, e As EventArgs) Handles BTN_TEST_CONNECT.Click

    End Sub

    Private Sub frm_company_Load(sender As Object, e As EventArgs) Handles Me.Load
        FILL_DATA()
    End Sub

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick

    End Sub
End Class