Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Public Class frm_warehouse
    Sub LIST_COMPANY()
        Try

            Connect_Database()
            Command = New SqlCommand("SP_LIST_COMPANY_LOGIN", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                ' .Parameters.Add("@ID_EMPLOYEE", SqlDbType.Int).Value = TXT_ID.Text.Trim
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                Message.Direction = ParameterDirection.Output
                Command.Parameters.Add(Message)
                Rows = Command.ExecuteNonQuery
                If (Rows > 0) Then
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value)
                End If
            End With
            Adapter.SelectCommand = Command
            DataT = New DataTable
            Adapter.Fill(DataT)
            With CB_COMPANY
                .DataSource = DataT
                .ValueMember = "ID_COMPANY"
                .DisplayMember = "COM_NAME_COMPANY"
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            Disconnect_Database()

        End Try
    End Sub
    Sub LIST_VALUE_AGENTS()
        Try

            Connect_Database()
            Command = New SqlCommand("SP_VALUE_AGENTS_WAREHOUSE", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                .Parameters.Add("@ID_AGENT", SqlDbType.Int).Value = TXT_ID.Text.Trim
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                Message.Direction = ParameterDirection.Output
                Command.Parameters.Add(Message)
                Rows = Command.ExecuteNonQuery
                If (Rows > 0) Then
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value)
                End If
            End With
            Adapter.SelectCommand = Command
            DataT = New DataTable
            Adapter.Fill(DataT)
            With CB_AGENTS
                .DataSource = DataT
                .ValueMember = "ID_AGENTS"
                .DisplayMember = "AG_NAME_AGENT"
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            Disconnect_Database()

        End Try
    End Sub
    Sub LIST_VALUE_COMPANY()
        Try

            Connect_Database()
            Command = New SqlCommand("SP_VALUE_COMPANY_WAREHOUSE", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = TXT_ID.Text.Trim
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                Message.Direction = ParameterDirection.Output
                Command.Parameters.Add(Message)
                Rows = Command.ExecuteNonQuery
                If (Rows > 0) Then
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value)
                End If
            End With
            Adapter.SelectCommand = Command
            DataT = New DataTable
            Adapter.Fill(DataT)
            With CB_COMPANY
                .DataSource = DataT
                .ValueMember = "ID_COMPANY"
                .DisplayMember = "COM_NAME_COMPANY"
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            Disconnect_Database()

        End Try
    End Sub
    Sub FILL_DATA()
        Try

            Connect_Database()
            Command = New SqlCommand("SP_SILV_WAREHOUSE_VIEW", connection) With {.CommandType = CommandType.StoredProcedure}
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
    Sub LIST_AGENTS()
        Try

            Connect_Database()
            Command = New SqlCommand("SP_LIST_AGENTS", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                ' .Parameters.Add("@ID_EMPLOYEE", SqlDbType.Int).Value = TXT_ID.Text.Trim
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                Message.Direction = ParameterDirection.Output
                Command.Parameters.Add(Message)
                Rows = Command.ExecuteNonQuery
                If (Rows > 0) Then
                    LBL_RESULT_AGENTS.Visibility = BarItemVisibility.Always
                    LBL_RESULT_AGENTS.Caption = Convert.ToString(Message.Value)
                Else
                    LBL_RESULT_AGENTS.Visibility = BarItemVisibility.Always
                    LBL_RESULT_AGENTS.Caption = Convert.ToString(Message.Value)
                End If
            End With
            Adapter.SelectCommand = Command
            DataT = New DataTable
            Adapter.Fill(DataT)
            With CB_AGENTS
                .DataSource = DataT
                .ValueMember = "ID_AGENTS"
                .DisplayMember = "AG_NAME_AGENT"
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            Disconnect_Database()

        End Try
    End Sub
    Sub CLEAN_FIELDS()
        TXT_ID.ResetText()
        TXT_NAME.ResetText()
        TXT_OBSERVATIONS.ResetText()
        C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked
        CB_NUMERO.ResetText()

    End Sub
    Private Sub BTN_SAVE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        Dim VALIDA As Boolean = False

        If (TXT_NAME.Text.Trim = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ALMACEN", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            Try
                Connect_Database()
                Command = New SqlCommand("SP_SILV_WAREHOUSE_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                With Command
                    .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = CB_COMPANY.SelectedValue
                    .Parameters.Add("@ID_AGENTS", SqlDbType.Int).Value = CB_AGENTS.SelectedValue
                    .Parameters.Add("@ALM_NUMBER_WAREHOUSE", SqlDbType.NVarChar, 10).Value = CB_NUMERO.Text
                    .Parameters.Add("@ALM_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text


                    If (TXT_OBSERVATIONS.Text = "") Then
                        .Parameters.AddWithValue("@ALM_OBSERVATIONS", DBNull.Value)
                    Else
                        .Parameters.Add("@ALM_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                    End If
                    .Parameters.Add("@ALM_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                    .Parameters.Add("@ALM_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

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
                FILL_DATA()

            End Try
        End If
    End Sub

    Private Sub G_DATA_DoubleClick(sender As Object, e As EventArgs) Handles G_DATA.DoubleClick
        Try
            TXT_ID.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "IDENTIFICADOR"), String)
            TXT_NAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE ALMACEN"), String)

            CB_NUMERO.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NUMERO ALMACEN"), String)


            If (IsDBNull(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"))) Then
                TXT_OBSERVATIONS.Text = ""
            Else
                TXT_OBSERVATIONS.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"), String)

            End If
            C_ACTIVE_INACTIVE.CheckState = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO"), CheckState)


        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            LIST_VALUE_COMPANY()
            LIST_VALUE_AGENTS()

        End If
    End Sub

    Private Sub BTN_EDIT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_EDIT.ItemClick
        Dim valida As Boolean = False
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        If (CB_NUMERO.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NUMERO DE ALMACEN PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (valida = True) Then
            XtraMessageBox.Show("FALTA INFORMACION POR INGRESAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If (XtraMessageBox.Show("¿DESEA MODIFICAR LA INFORMACION DEL ALMACEN?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub
            Else
                Try
                    Connect_Database()
                    Command = New SqlCommand("SP_SILV_WAREHOUSE_EDIT", connection) With {.CommandType = CommandType.StoredProcedure}
                    With Command
                        .Parameters.Add("@ID_WAREHOUSE", SqlDbType.Int).Value = TXT_ID.Text
                        .Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = CB_COMPANY.SelectedValue
                        .Parameters.Add("@ID_AGENTS", SqlDbType.Int).Value = CB_AGENTS.SelectedValue

                        .Parameters.Add("@ALM_NUMBER_WAREHOUSE", SqlDbType.NVarChar, 10).Value = CB_NUMERO.Text
                        .Parameters.Add("@ALM_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text


                        If (TXT_OBSERVATIONS.Text = "") Then
                            .Parameters.AddWithValue("@ALM_OBSERVATIONS", DBNull.Value)
                        Else
                            .Parameters.Add("@ALM_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                        End If
                        .Parameters.Add("@ALM_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                        .Parameters.Add("@ALM_USER_UPDATE", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

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
                    FILL_DATA()
                End Try
            End If

        End If
    End Sub

    Private Sub BTN_CLEAN_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_CLEAN.ItemClick
        CLEAN_FIELDS()
    End Sub

    Private Sub BTN_SHOW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_SHOW.ItemClick
        FILL_DATA()
    End Sub

    Private Sub REFRESH_AGENTS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles REFRESH_AGENTS.ItemClick
        LIST_AGENTS()
    End Sub

    Private Sub REFRESH_COMPANY_ItemClick(sender As Object, e As ItemClickEventArgs) Handles REFRESH_COMPANY.ItemClick
        LIST_COMPANY()
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

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick
        Dim valida As Boolean = False
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (valida = True) Then
            XtraMessageBox.Show("FALTA INFORMACION POR INGRESAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If (XtraMessageBox.Show("¿DESEA ELIMINAR LA INFORMACION DEL ALMACEN?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub
            Else
                Try
                    Connect_Database()
                    Command = New SqlCommand("SP_SILV_WAREHOUSE_DELETE", connection) With {.CommandType = CommandType.StoredProcedure}
                    With Command
                        .Parameters.Add("@ID_WAREHOUSE", SqlDbType.Int).Value = TXT_ID.Text


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
                    FILL_DATA()
                End Try
            End If

        End If
    End Sub

    Private Sub frm_warehouse_Load(sender As Object, e As EventArgs) Handles Me.Load
        FILL_DATA()
    End Sub
End Class