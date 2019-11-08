Imports DevExpress.XtraEditors
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraBars
Public Class frm_folios

#Region "METODOS"

    Sub CLEAN_FIELDS()
        TXT_ID.ResetText()
        TXT_NAME.ResetText()
        TXT_OBSERVATIONS.ResetText()
        C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked
    End Sub
    Sub FILL_DATA()
        Try
            Connect_Database()
            Command = New SqlCommand("SP_SILV_FOLIOS_VIEW", connection) With {.CommandType = CommandType.StoredProcedure}
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
    Sub LIST_TYPE_DOCTO()
        Try
            Connect_Database()
            Command = New SqlCommand("SP_LIST_TYPE_DOCTOS", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                ' .Parameters.Add("@ID_EMPLOYEE", SqlDbType.Int).Value = TXT_ID.Text.Trim
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                Message.Direction = ParameterDirection.Output
                Command.Parameters.Add(Message)
                Rows = Command.ExecuteNonQuery
                If (Rows > 0) Then
                    LBL_RESULT_FOLIO.Visibility = BarItemVisibility.Always
                    LBL_RESULT_FOLIO.Caption = Convert.ToString(Message.Value)
                Else
                    LBL_RESULT_FOLIO.Visibility = BarItemVisibility.Always
                    LBL_RESULT_FOLIO.Caption = Convert.ToString(Message.Value)
                End If
            End With
            Adapter.SelectCommand = Command
            DataT = New DataTable
            Adapter.Fill(DataT)
            With CB_TYPE_DOCTO
                .DataSource = DataT
                .ValueMember = "ID_FOLIOS_DOCTOS"
                .DisplayMember = "TY_NAME_TYPE_DOCTO"
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect_Database()

        End Try
    End Sub
    Sub LIST_VALUE_TYPE_DOCTO()
        Try
            Connect_Database()
            Command = New SqlCommand("SP_VALUE_FOLIOS_TYPE_DOCTOS", connection) With {.CommandType = CommandType.StoredProcedure}
            With Command
                .Parameters.Add("@ID_FOLIOS", SqlDbType.Int).Value = TXT_ID.Text.Trim
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                Message.Direction = ParameterDirection.Output
                Command.Parameters.Add(Message)
                Rows = Command.ExecuteNonQuery
                If (Rows > 0) Then
                    LBL_RESULT_FOLIO.Visibility = BarItemVisibility.Always
                    LBL_RESULT_FOLIO.Caption = Convert.ToString(Message.Value)
                Else
                    LBL_RESULT_FOLIO.Visibility = BarItemVisibility.Always
                    LBL_RESULT_FOLIO.Caption = Convert.ToString(Message.Value)
                End If
            End With
            Adapter.SelectCommand = Command
            DataT = New DataTable
            Adapter.Fill(DataT)
            With CB_TYPE_DOCTO
                .DataSource = DataT
                .ValueMember = "ID_FOLIOS_DOCTOS"
                .DisplayMember = "TY_NAME_TYPE_DOCTO"
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect_Database()

        End Try
    End Sub
#End Region

    Private Sub BTN_SAVE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        If (TXT_NAME.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL FOLIO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            Try
                Connect_Database()
                Command = New SqlCommand("SP_SILV_FOLIOS_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                With Command
                    ' .Parameters.Add("@ID_FOLIOS_DOCTOS", SqlDbType.Int).Value = CB_TYPE_DOCTO.SelectedValue
                    .Parameters.Add("@FO_NAME_SERIE_FOLIO", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text

                    'If (TXT_OBSERVATIONS.Text = "") Then
                    '    .Parameters.AddWithValue("@FO_OBSERVATIONS", DBNull.Value)
                    'Else
                    '    .Parameters.Add("@FO_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                    'End If
                    .Parameters.Add("@FO_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                    .Parameters.Add("@FO_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

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

    Private Sub BTN_REFRESH_TYPE_DOC_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_REFRESH_TYPE_DOC.ItemClick
        LIST_TYPE_DOCTO()
    End Sub

    Private Sub BTN_EDIT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_EDIT.ItemClick
        Dim VALIDA As Boolean = False
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If
        If (TXT_NAME.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA SERIE DEL FOLIO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub

        End If

        If (VALIDA = True) Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL FOLIO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub
            Else
                Try
                    Connect_Database()
                    Command = New SqlCommand("SP_SILV_FOLIOS_EDIT", connection) With {.CommandType = CommandType.StoredProcedure}
                    With Command
                        .Parameters.Add("@ID_FOLIOS", SqlDbType.Int).Value = TXT_ID.Text
                        .Parameters.Add("@ID_FOLIOS_DOCTOS", SqlDbType.Int).Value = CB_TYPE_DOCTO.SelectedValue
                        .Parameters.Add("@FO_NAME_SERIE_FOLIO", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text

                        If (TXT_OBSERVATIONS.Text = "") Then
                            .Parameters.AddWithValue("@FO_OBSERVATIONS", DBNull.Value)
                        Else
                            .Parameters.Add("@FO_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text
                        End If
                        .Parameters.Add("@FO_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState
                        .Parameters.Add("@FO_USER_UPDATE", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

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
            LIST_VALUE_TYPE_DOCTO()
        End If
    End Sub

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick
        Dim VALIDA As Boolean = False
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VALIDA = True
            Exit Sub
        End If

        If (VALIDA = True) Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL ESTADO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub
            Else
                Try
                    Connect_Database()
                    Command = New SqlCommand("SP_SILV_FOLIOS_DELETE", connection) With {.CommandType = CommandType.StoredProcedure}
                    With Command
                        .Parameters.Add("@ID_FOLIOS", SqlDbType.Int).Value = TXT_ID.Text

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

    Private Sub G_DATA_DoubleClick(sender As Object, e As EventArgs) Handles G_DATA.DoubleClick
        Try
            TXT_ID.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"), String)
            TXT_NAME.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "SERIE FOLIO"), String)

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

    Private Sub BTN_CLEAN_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_CLEAN.ItemClick
        CLEAN_FIELDS()

    End Sub

    Private Sub BTN_SHOW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_SHOW.ItemClick
        FILL_DATA()

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

    Private Sub CB_TYPE_DOCTO_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_TYPE_DOCTO.SelectedValueChanged
        If (CB_TYPE_DOCTO.Text = "P") Then
            TXT_OBSERVATIONS.Text = "SERIE DE CONSIGNACION"
        ElseIf (CB_TYPE_DOCTO.Text = "D") Then
            TXT_OBSERVATIONS.Text = "SERIE DEVOLUCION"
        ElseIf (CB_TYPE_DOCTO.Text = "R") Then
            TXT_OBSERVATIONS.Text = "SERIE REMISION"
        ElseIf (CB_TYPE_DOCTO.Text = "C") Then
            TXT_OBSERVATIONS.Text = "SERIE CLIENTE"
        ElseIf (CB_TYPE_DOCTO.Text = "G") Then
            TXT_OBSERVATIONS.Text = "SERIE GARANTIA"
        End If
    End Sub

    Private Sub frm_folios_Load(sender As Object, e As EventArgs) Handles Me.Load
        FILL_DATA()
    End Sub
End Class