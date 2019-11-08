Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars

Public Class frm_add_article
    Dim table As New DataTable("Table")

    Sub LIST_ACCESSORIES()
        Try
            'SE ESTABLECE LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_PROVIDERS E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_ACCESSORIES", connection) With {.CommandType = CommandType.StoredProcedure}
            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_PROVIDERS", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    LB_RESULT_U.Visibility = BarItemVisibility.Always
                    LB_RESULT_U.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_U.Visibility = BarItemVisibility.Always
                    LB_RESULT_U.Caption = Convert.ToString(Message.Value)
                End If
            End With
            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_PROVIDER LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_ACCESORIO
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "ID_ACCESSORIES" 'EL VALOR QUE TENDRA
                .DisplayMember = "AC_NAME_ACCESORIES" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR LIST_ACCESSORIES", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()
        End Try
    End Sub

    Sub LIST_MATERIAL()
        Try
            'SE ESTABLECE LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_MATERIAL E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_MATERIAL", connection) With {.CommandType = CommandType.StoredProcedure}
            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_PROVIDERS", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    LB_RESULT_MAT.Visibility = BarItemVisibility.Always
                    LB_RESULT_MAT.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_MAT.Visibility = BarItemVisibility.Always
                    LB_RESULT_MAT.Caption = Convert.ToString(Message.Value)
                End If
            End With
            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_PROVIDER LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_MATERIAL
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "ID_MATERIAL" 'EL VALOR QUE TENDRA
                .DisplayMember = "MA_NAME_MATERIAL" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR LIST_MATERIAL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()
        End Try
    End Sub


    Sub LIST_DESCRIPTION()
        Try
            'SE ESTABLECE LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_DESCRIPTION_ARTICLE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_DESCRIPTION_ARTICLE", connection) With {.CommandType = CommandType.StoredProcedure}
            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                .Parameters.Add("@PRD_CONCAT_MAT", SqlDbType.NVarChar, 100).Value = TXT_LINEA.Text
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_PROVIDERS", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    LB_RESULT_MAT.Visibility = BarItemVisibility.Always
                    LB_RESULT_MAT.Caption = Convert.ToString(Message.Value)
                Else
                    LB_RESULT_MAT.Visibility = BarItemVisibility.Always
                    LB_RESULT_MAT.Caption = Convert.ToString(Message.Value)
                End If
            End With
            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_PROVIDER LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_DESCRIPCION
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "PRD_NAME" 'EL VALOR QUE TENDRA
                .DisplayMember = "PRD_NAME" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR LIST_DESCRIPTION", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()
        End Try
    End Sub

    Private Sub BTN_CLOSE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_CLOSE.ItemClick
        Me.Close()

    End Sub

    Private Sub frm_add_article_Load(sender As Object, e As EventArgs) Handles Me.Load
        table.Columns.Add("Id", Type.GetType("System.Int32"))
        table.Columns.Add("First Name", Type.GetType("System.String"))
        table.Columns.Add("Last Name", Type.GetType("System.String"))
        table.Columns.Add("Age", Type.GetType("System.Int32"))




        LIST_ACCESSORIES()
        LIST_MATERIAL()
        TXT_LINEA.Text = CB_ACCESORIO.Text + CB_MATERIAL.Text
        LIST_DESCRIPTION()



    End Sub

    Private Sub CB_ACCESORIO_TextChanged(sender As Object, e As EventArgs) Handles CB_ACCESORIO.TextChanged
        TXT_LINEA.Text = CB_ACCESORIO.Text + CB_MATERIAL.Text
    End Sub

    Private Sub CB_MATERIAL_TextChanged(sender As Object, e As EventArgs) Handles CB_MATERIAL.TextChanged
        TXT_LINEA.Text = CB_ACCESORIO.Text + CB_MATERIAL.Text
    End Sub

    Private Sub CB_DESCRIPCION_Enter(sender As Object, e As EventArgs) Handles CB_DESCRIPCION.Enter
        LIST_DESCRIPTION()
    End Sub

    Private Sub TXT_COSTO_UNIT_TextChanged(sender As Object, e As EventArgs) Handles TXT_COSTO_UNIT.TextChanged
        TXT_PRECION_PUB.Text = CType(Val(TXT_COSTO_UNIT.Text) * 3, String)
        TXT_IMPORTE.Text = CType(Val(TXT_CANTIDAD.Text) * Val(TXT_COSTO_UNIT.Text), String)
    End Sub

    Private Sub TXT_CANTIDAD_TextChanged(sender As Object, e As EventArgs) Handles TXT_CANTIDAD.TextChanged
        TXT_IMPORTE.Text = CType(Val(TXT_CANTIDAD.Text) * Val(TXT_COSTO_UNIT.Text), String)
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        'frm_compras.dgv_data.Rows.Add()
        'frm_compras.dgv_data.Rows(0).Cells("CANTIDAD").Value = TXT_CANTIDAD.Text

    End Sub
End Class