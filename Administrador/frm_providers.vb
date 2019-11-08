Imports DevExpress.XtraEditors
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraBars
Public Class frm_providers
    Sub clean_fields()
        TXT_ID.ResetText()
        TXT_NAME.ResetText()
        TX_MAT.ResetText()
        TX_PAT.ResetText()
    End Sub
    Sub FILL_DATA()
        Try

            Connect_Database()
            Command = New SqlCommand("SP_SILV_PROVIDERS_VIEW", connection) With {.CommandType = CommandType.StoredProcedure}
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
    Private Sub BTN_SHOW_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_SHOW.ItemClick
        FILL_DATA()

    End Sub

    Private Sub BTN_SAVE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        Dim VALIDA As Boolean = False

        If (TXT_NAME.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA PERSONA PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If

        If (TX_PAT.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR SU APELLIDO PATERNO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        If (TX_MAT.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR SU APELLIDO MATERNO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If

        If (VALIDA = True) Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA EL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            Try

                Connect_Database()
                Command = New SqlCommand("SP_SILV_PROVIDERS_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                With Command
                    .Parameters.Add("@PROV_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text


                    If (TX_PAT.Text = "") Then
                        .Parameters.AddWithValue("@PROV_PATERN_SURNAME", DBNull.Value)
                    Else
                        .Parameters.Add("@PROV_PATERN_SURNAME", SqlDbType.NVarChar, 200).Value = TX_PAT.Text
                    End If
                    If (TX_MAT.Text = "") Then
                        .Parameters.AddWithValue("@PROV_MATERN_SURNAME", DBNull.Value)
                    Else
                        .Parameters.Add("@PROV_MATERN_SURNAME", SqlDbType.NVarChar, 200).Value = TX_MAT.Text
                    End If
                    .Parameters.Add("@PROV_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                    .Parameters.Add("@PROV_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

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
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        If (TXT_NAME.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL PROVEEDOR PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub

        End If


        If (VALIDA = True) Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEl PROVEEDOR?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub
            Else
                Try

                    Connect_Database()
                    Command = New SqlCommand("SP_SILV_PROVIDERS_EDIT", connection) With {.CommandType = CommandType.StoredProcedure}
                    With Command
                        .Parameters.Add("@ID_PROVIDERS", SqlDbType.Int).Value = TXT_ID.Text
                        .Parameters.Add("@PROV_NAME", SqlDbType.Int).Value = TXT_NAME.Text
                        If (TX_PAT.Text = "") Then
                            .Parameters.AddWithValue("@PROV_PATERN_SURNAME", DBNull.Value)
                        Else
                            .Parameters.Add("@PROV_PATERN_SURNAME", SqlDbType.NVarChar, 200).Value = TX_PAT.Text
                        End If
                        If (TX_MAT.Text = "") Then
                            .Parameters.AddWithValue("@PROV_MATERN_SURNAME", DBNull.Value)
                        Else
                            .Parameters.Add("@PROV_MATERN_SURNAME", SqlDbType.NVarChar, 200).Value = TX_MAT.Text
                        End If
                        .Parameters.Add("@PROV_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                        .Parameters.Add("@PROV_USER_UPDATE", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

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
                    clean_fields()
                    FILL_DATA()
                End Try
            End If
        End If


    End Sub

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL PROVEEDOR?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub
            Else
                Try

                    Connect_Database()
                    Command = New SqlCommand("SP_SILV_PROVIDERS_DELETE", connection) With {.CommandType = CommandType.StoredProcedure}
                    With Command
                        .Parameters.Add("@ID_PROVIDERS", SqlDbType.Int).Value = TXT_ID.Text


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
                    clean_fields()
                    FILL_DATA()
                End Try
            End If
        End If
    End Sub

    Private Sub BTN_CLEAR_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_CLEAR.ItemClick
        clean_fields()

    End Sub

    Private Sub BTN_PRINT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_PRINT.ItemClick
        DGV_DATA.PrintDialog()

    End Sub

    Private Sub BTN_PREVIEW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_PREVIEW.ItemClick
        DGV_DATA.ShowRibbonPrintPreview()
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

    Private Sub G_DATA_DoubleClick(sender As Object, e As EventArgs) Handles G_DATA.DoubleClick
        Try
            TXT_ID.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"), String)
            TXT_NAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE(s)"), String)



            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "APELLIDO PATERNO"))) Then
                TX_PAT.Text = ""
            Else
                TX_PAT.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "APELLIDO PATERNO"), String)

            End If


            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "APELLIDO MATERNO"))) Then
                TX_MAT.Text = ""
            Else
                TX_MAT.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "APELLIDO MATERNO"), String)

            End If


            C_ACTIVE_INACTIVE.CheckState = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO"), CheckState)


        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class