Imports System.ComponentModel
Imports System.Text
'LIBRERIAS PARA MANEJO DE SQL Y MENSAJES PERSONALIZADOS DEVEXPRESS
Imports DevExpress.XtraEditors
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraBars

Partial Public Class Form1
    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'LOGICA--> SI EL USUARIO PRESIONA EL BOTON SALIR Y ESTE PRESIONA EL BOTON NO ENTONCES CANCELA LA OPERACION EN CASO CONTRARIO
        'SALIR COMPLETAMENTE DEL SISTEMA

        If (XtraMessageBox.Show("¿DESEA SALIR COMPLETAMENTE DEL SISTEMA?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            Application.ExitThread()
            Application.Exit()
        End If
    End Sub

    Private Sub btn_access_Click(sender As Object, e As EventArgs) Handles btn_access.Click
        Connect_Database()
        'Dim VALIDA As Boolean = False
        'If (txt_username.Text.Trim = "") Then
        '    XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    VALIDA = True
        '    txt_username.Focus()
        'End If
        'If (txt_password.Text.Trim = "") Then
        '    XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASEÑA DEL USUARIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    VALIDA = True
        '    txt_password.Focus()
        'End If

        ''SE ANEXA CODIGO PARA VALIDACION DE CLAVE MAESTRA
        'If (txt_username.Text = Username And txt_password.Text = Password) Then
        '    Me.Hide()
        '    frn_main_form.Show()
        '    txt_password.ResetText()
        '    txt_username.ResetText()
        'Else
        '    If (VALIDA = True) Then
        '        Exit Sub
        '    Else
        '        Try
        '            Connect_Database()
        '            'establece_conexion()

        '            If usuarioRegistrado(txt_username.Text) = True Then
        '                Dim contra As String = contrasena(txt_username.Text)
        '                If contra.Equals(txt_password.Text) = True Then
        '                    Me.Hide()
        '                    If ConsultarTipoUsuario(txt_username.Text) = 1 Then
        '                        frn_main_form.ShowDialog() ' ADMINISTRATOR

        '                    End If
        '                Else
        '                    XtraMessageBox.Show("CONTRASEÑA INVALIDA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    txt_username.Focus()
        '                End If
        '            Else
        '                XtraMessageBox.Show("EL USUARIO:--" + txt_username.Text + "--NO SE ENCUENTRA REGISTRADO O SU CUENTA ESTA DESACTIVADA")
        '                txt_username.Focus()
        '            End If
        '        Catch ex As Exception
        '            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Finally
        '            Disconnect_Database()

        '            txt_password.ResetText()
        '            txt_username.ResetText()
        '            txt_username.Focus()

        '            '  FRM_AUX.LB_USER.Caption = Me.TXT_USER.Text.Trim().ToUpper
        '        End Try
        '    End If
        'End If
    End Sub

    Private Sub LabelControl3_Click(sender As Object, e As EventArgs) Handles LabelControl3.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub txt_password_EditValueChanged(sender As Object, e As EventArgs) Handles txt_password.EditValueChanged

    End Sub

    Private Sub txt_username_EditValueChanged(sender As Object, e As EventArgs) Handles txt_username.EditValueChanged

    End Sub

    Private Sub LabelControl2_Click(sender As Object, e As EventArgs) Handles LabelControl2.Click

    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click

    End Sub
End Class
