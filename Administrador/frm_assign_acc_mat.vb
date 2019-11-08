Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports System.Data
Imports System.Data.SqlClient


Public Class frm_assign_acc_mat
    Sub FILL_DATA()
        Try
            Connect_Database()
            Command = New SqlCommand("SP_SILV_PRODUCTS_DATA_VIEW", connection) With {.CommandType = CommandType.StoredProcedure}
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
    Sub CLEAN_FIELDS()
        TXT_ID.ResetText()
        TXT_ACC.ResetText()
        TXT_DESC_ACC.ResetText()
        TXT_MAT.ResetText()
        TXT_LINE.ResetText()
        TXT_DESC_MAT.ResetText()
        TXT_ACC.Focus()
    End Sub

    Private Sub BTN_SAVE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        Dim valida As Boolean = False
        If (TXT_ACC.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ACCESORIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        If (TXT_DESC_ACC.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DEL ACCESORIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (TXT_MAT.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL MATERIAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        If (TXT_DESC_MAT.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DEL MATERIAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (TXT_LINE.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA LINEA DEL PRODUCTO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (valida = True) Then
            XtraMessageBox.Show("FALTA INFORMACION POR AGREGAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Try
                Connect_Database()
                Command = New SqlCommand("SP_SILV_PRODUCTS_DATA_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                With Command
                    .Parameters.Add("@PRD_ACC_NAME", SqlDbType.NVarChar, 50).Value = TXT_ACC.Text
                    .Parameters.Add("@PRD_MAT_NAME", SqlDbType.NVarChar, 50).Value = TXT_DESC_ACC.Text
                    .Parameters.Add("@PRD_CONCAT_MAT", SqlDbType.NVarChar, 50).Value = TXT_LINE.Text
                    .Parameters.Add("@PRD_NAME_ACC_DESC", SqlDbType.NVarChar, 100).Value = TXT_MAT.Text
                    .Parameters.Add("@PRD_NAME_MAT_DESC", SqlDbType.NVarChar, 100).Value = TXT_DESC_MAT.Text

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

    Private Sub TXT_ACC_TextChanged(sender As Object, e As EventArgs) Handles TXT_ACC.TextChanged
        TXT_LINE.Text = TXT_ACC.Text + TXT_MAT.Text
    End Sub

    Private Sub TXT_MAT_TextChanged(sender As Object, e As EventArgs) Handles TXT_MAT.TextChanged
        TXT_LINE.Text = TXT_ACC.Text + TXT_MAT.Text
    End Sub

    Private Sub frm_assign_acc_mat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FILL_DATA()
    End Sub

    Private Sub BTN_SHOW_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_SHOW.ItemClick
        FILL_DATA()

    End Sub

    Private Sub BTN_CLEAR_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_CLEAR.ItemClick
        CLEAN_FIELDS()

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
            TXT_ACC.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACCESORIO"), String)
            TXT_DESC_ACC.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "DESCRIPCION ACCESORIO"), String)
            TXT_MAT.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "MATERIAL"), String)
            TXT_DESC_MAT.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "DESCRIPCION MATERIAL"), String)

            TXT_LINE.Text = CType(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "LINEA"), String)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BTN_EDIT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_EDIT.ItemClick
        Dim valida As Boolean = False
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        If (TXT_ACC.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ACCESORIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        If (TXT_DESC_ACC.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DEL ACCESORIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (TXT_MAT.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL MATERIAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        If (TXT_DESC_MAT.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DEL MATERIAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (TXT_LINE.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA LINEA DEL PRODUCTO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (valida = True) Then
            XtraMessageBox.Show("FALTA INFORMACION POR ESPECIFICAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If (XtraMessageBox.Show("¿DESEA MODIFICAR LA INFORMACION DEL PRODUCTO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Exit Sub
            Else
                Try
                    Connect_Database()
                    Command = New SqlCommand("SP_SILV_PRODUCTS_DATA_EDIT", connection) With {.CommandType = CommandType.StoredProcedure}
                    With Command
                        .Parameters.Add("@ID_PRODUCTS_DATA", SqlDbType.Int).Value = TXT_ID.Text
                        .Parameters.Add("@PRD_ACC_NAME", SqlDbType.NVarChar, 50).Value = TXT_ACC.Text
                        .Parameters.Add("@PRD_MAT_NAME", SqlDbType.NVarChar, 50).Value = TXT_DESC_ACC.Text
                        .Parameters.Add("@PRD_CONCAT_MAT", SqlDbType.NVarChar, 50).Value = TXT_LINE.Text
                        .Parameters.Add("@PRD_NAME_ACC_DESC", SqlDbType.NVarChar, 100).Value = TXT_MAT.Text
                        .Parameters.Add("@PRD_NAME_MAT_DESC", SqlDbType.NVarChar, 100).Value = TXT_DESC_MAT.Text

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

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick
        Dim valida As Boolean = False
        If (TXT_ID.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        If (valida = True) Then
            Exit Sub
        Else
            Try
                Connect_Database()
                Command = New SqlCommand("SP_SILV_PRODUCTS_DATA_DELETE", connection) With {.CommandType = CommandType.StoredProcedure}
                With Command
                    .Parameters.Add("@ID_PRODUCTS_DATA", SqlDbType.Int).Value = TXT_ID.Text
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
End Class