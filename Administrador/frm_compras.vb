'LIBRERIAS SQL PARA EJECUTAR COMANDOS DESDE SQL COMMANDO EN EL SISTEMA
Imports System.Data
Imports System.Data.SqlClient
'LIBRERIA DEVEXPRESS QUE PERMITE CODIGO PARA UTILIZAR UN XtraMessageBox SIMILAR A MessageBox
Imports DevExpress.XtraEditors
'LIBRERIA DEVEXPRESS QUE PERMITE CODIGO PARA LA PROPIEDAD DE UN ELEMENTO DE LA BARRA INFERIOR DEL FORMULARIO
Imports DevExpress.XtraBars

Public Class frm_compras
    Dim table As New DataTable("Table")
    'METODO PARA LISTAR LOS PROVEEDORES DEL SISTEMA PARA COMPRA
    Sub LIST_PROVIDERS()
        Try
            'SE ESTABLECE LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_PROVIDERS E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_PROVIDERS", connection) With {.CommandType = CommandType.StoredProcedure}
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
                    LBL_RESULT_PROVIDER.Visibility = BarItemVisibility.Always
                    LBL_RESULT_PROVIDER.Caption = Convert.ToString(Message.Value)
                Else
                    LBL_RESULT_PROVIDER.Visibility = BarItemVisibility.Always
                    LBL_RESULT_PROVIDER.Caption = Convert.ToString(Message.Value)
                End If
            End With
            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_PROVIDER LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_PROVIDER
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "ID_PROVIDERS" 'EL VALOR QUE TENDRA
                .DisplayMember = "PROVEEDOR" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()

        End Try
    End Sub
    Sub LIST_WAREHOUSE()
        Try
            'ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            'SE EJECUTA UN NUEVO COMANDO SP_LIST_WAREHOUSE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            Command = New SqlCommand("SP_LIST_WAREHOUSE", connection) With {.CommandType = CommandType.StoredProcedure}


            'INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
            With Command
                'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_WAREHOUSE
                Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output
                'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                Command.Parameters.Add(Message)
                'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_WAREHOUSE", connection)
                Rows = Command.ExecuteNonQuery
                'SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                'LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                'SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                'LB_RESULT.Caption = Convert.ToString(Message.Value)
                If (Rows > 0) Then
                    LBL_RESULT_WAREH.Visibility = BarItemVisibility.Always
                    LBL_RESULT_WAREH.Caption = Convert.ToString(Message.Value)
                Else
                    LBL_RESULT_WAREH.Visibility = BarItemVisibility.Always
                    LBL_RESULT_WAREH.Caption = Convert.ToString(Message.Value)
                End If
            End With

            'UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_WAREHOUSE
            Adapter.SelectCommand = Command
            'SE CREA UN NUEVO DATATABLE
            DataT = New DataTable
            'INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
            Adapter.Fill(DataT)
            'AL CONTROL CB_ALMACEN LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
            With CB_ALMACEN
                .DataSource = DataT
                'VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                'DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                .ValueMember = "ID_WAREHOUSE" 'EL VALOR QUE TENDRA
                .DisplayMember = "ALM_NUMBER_WAREHOUSE" 'EL VALOR QUE SE MOSTRARA
            End With
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
            Disconnect_Database()

        End Try
    End Sub

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
                    lbl_result_acc.Visibility = BarItemVisibility.Always
                    lbl_result_acc.Caption = Convert.ToString(Message.Value)
                Else
                    lbl_result_acc.Visibility = BarItemVisibility.Always
                    lbl_result_acc.Caption = Convert.ToString(Message.Value)
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
                    lbl_result_mat.Visibility = BarItemVisibility.Always
                    lbl_result_mat.Caption = Convert.ToString(Message.Value)
                Else
                    lbl_result_mat.Visibility = BarItemVisibility.Always
                    lbl_result_mat.Caption = Convert.ToString(Message.Value)
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

    Sub fSumar()
        Dim total As Double = 0
        For Each fila As DataGridViewRow In dgv_data.Rows
            If fila.Cells("IMPORTE").Value Is Nothing Then
                Exit Sub
            Else
                total += Convert.ToDouble(fila.Cells("IMPORTE").Value)
            End If

        Next
        txt_totales.Text = Format(total, "#,##0.00")
        txt_t_subtotal.Text = Format(total, "#,##0.00")
    End Sub


    Sub Sumar_Piezas()
        Dim total As Double = 0
        For Each fila As DataGridViewRow In dgv_data.Rows
            If fila.Cells("CANTIDAD").Value Is Nothing Then
                Exit Sub
            Else
                total += Convert.ToDouble(fila.Cells("CANTIDAD").Value)
            End If

        Next
        'txt_totales.Text = Format(total, "#,##0.00")
        txt_piezas.Text = CType(total, String)
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
                    lbl_result_desc.Visibility = BarItemVisibility.Always
                    lbl_result_desc.Caption = Convert.ToString(Message.Value)
                Else
                    lbl_result_desc.Visibility = BarItemVisibility.Always
                    lbl_result_desc.Caption = Convert.ToString(Message.Value)
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

    Sub CLEAR_FIELDS()
        TXT_CANTIDAD.ResetText()
        TXT_COSTO_UNIT.ResetText()
        TXT_ID.ResetText()
        TXT_IMPORTE.ResetText()
        'TXT_LINEA.ResetText()
        TXT_PRECION_PUB.ResetText()
        TXT_T_COMPRA.ResetText()
        TXT_CANTIDAD.Focus()
    End Sub
    Sub UPDATE_GENERATOR()
        Try
            Connect_Database()
            Command = New SqlCommand("SP_UPDATE_GENERATOR", connection) With {.CommandType = CommandType.StoredProcedure}
            Command.ExecuteNonQuery()
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect_Database()
        End Try
    End Sub
    Private Sub BTN_SAVE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTN_SAVE.ItemClick
        'For Each Row As DataGridViewRow In dgv_data.Rows
        '    Dim Cantidad As String = CType(Row.Cells("col_cantidad").Value, String)
        '    Dim Costo As Double = CType(Row.Cells("col_costo_unit").Value, Double)
        '    Dim Importe As Double = Val(Cantidad) * Val(Costo)

        '    'asignamos a la columna importe el valor de la operacion Val(Cantidad) * (Costo)
        '    Row.Cells("col_importe").Value = Importe
        '    'asignamos a la columna precio publico el total del costo unitario multiplicado por 3
        '    Row.Cells("col_precio_pub").Value = Val(Costo) * 3
        '    'dgv_data.Rows.RemoveAt(dgv_data.Rows.Count - 1)
        '    'asignamos a la columna de la linea el valor de la columna accesorio concatenado con el valor de la columna del material
        '    'creando asi la linea del producto
        '    Row.Cells("col_linea").Value = Row.Cells("col_accesorio").Value + Row.Cells("col_material").Value

        'Next

        Try
            'ESTABLECER LA CONEXION A LA BASE DE DATOS
            Connect_Database()
            For Each row As DataGridViewRow In dgv_data.Rows

                Dim Cantidad As String = CType(row.Cells("CANTIDAD").Value, String)
                Dim Accesorio As String = CType(row.Cells("ACCESORIO").Value, String)
                Dim Material As String = CType(row.Cells("MATERIAL").Value, String)
                Dim Linea As String = CType(row.Cells("LINEA").Value, String)
                Dim Descripcion As String = CType(row.Cells("DESCRIPCION").Value, String)
                Dim Costo_Unit As String = CType(row.Cells("COSTO UNITARIO").Value, String)
                Dim Precio_Pub As String = CType(row.Cells("PRECIO PUBLICO").Value, String)
                Dim Importe As String = CType(row.Cells("IMPORTE").Value, String)

                Command = New SqlCommand("SP_SILV_COMPRAS_INSERT", connection) With {.CommandType = CommandType.StoredProcedure}
                With Command
                    .Parameters.Add("@COM_PROVEEDOR", SqlDbType.NVarChar, 100).Value = CB_PROVIDER.Text
                    .Parameters.Add("@COM_WAREHOUSE", SqlDbType.NVarChar, 100).Value = CB_ALMACEN.Text
                    .Parameters.Add("@COM_FOLIO_DOCUMENT", SqlDbType.NVarChar, 50).Value = TXT_FOLIO_DOC.EditValue
                    .Parameters.Add("@COM_FECHA_CMP", SqlDbType.Date).Value = DT_FECHA.EditValue
                    .Parameters.Add("@COM_CANTIDAD", SqlDbType.Int).Value = Cantidad
                    .Parameters.Add("@COM_ACCESORIO", SqlDbType.NVarChar, 10).Value = Accesorio

                    .Parameters.Add("@COM_MATERIAL", SqlDbType.NVarChar, 10).Value = Material
                    .Parameters.Add("@COM_LINEA", SqlDbType.NVarChar, 50).Value = Linea
                    .Parameters.Add("@COM_DESCRIPCION", SqlDbType.NVarChar, 200).Value = Descripcion
                    .Parameters.Add("@COM_PIEZAS", SqlDbType.Int).Value = txt_piezas.Text
                    .Parameters.Add("@COM_PARTIDAS", SqlDbType.Int).Value = txt_partidas.Text
                    .Parameters.Add("@COM_COSTO_UNIT", SqlDbType.Float).Value = Costo_Unit
                    .Parameters.Add("@COM_PRECIO_PUB", SqlDbType.Float).Value = Precio_Pub
                    .Parameters.Add("@COM_IMPORTE", SqlDbType.Float).Value = Importe
                    .Parameters.Add("@COM_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_main_form.LBL_USERNAME.Caption

                    'DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_COUNTRIES_INSERT
                    Dim Message As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200)
                    'INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output
                    'A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    Command.Parameters.Add(Message)
                    'LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_COUNTRIES_INSERT", connection)
                    Rows = Command.ExecuteNonQuery
                    'SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_COUNTRIES_INSERT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
                    If (Rows > 0) Then
                        XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                    Else
                        XtraMessageBox.Show(CType(Message.Value, String), "SISTEMA", MessageBoxButtons.OK)
                    End If
                End With
            Next

        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'FINALMENTE NOS DESCONECTAMOS DE LA BASE DE DATOS
            Disconnect_Database()
            'LIMPIAMOS LOS CAMPOS
            CLEAR_FIELDS()
            '  dgv_data.DataSource = Nothing
            UPDATE_GENERATOR()
            Me.TXT_FOLIO_DOC.Text = Generadores("COM_PARAMETRO")
        End Try

    End Sub



    Private Sub frm_compras_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.TXT_FOLIO_DOC.Text = Generadores("COM_PARAMETRO")
        TXT_CANTIDAD.Focus()
        table.Columns.Add("CANTIDAD", Type.GetType("System.Int32"))
        table.Columns.Add("ACCESORIO", Type.GetType("System.String"))
        table.Columns.Add("MATERIAL", Type.GetType("System.String"))
        table.Columns.Add("LINEA", Type.GetType("System.String"))
        table.Columns.Add("DESCRIPCION", Type.GetType("System.String"))
        table.Columns.Add("COSTO UNITARIO", Type.GetType("System.String"))
        table.Columns.Add("PRECIO PUBLICO", Type.GetType("System.String"))
        table.Columns.Add("IMPORTE", Type.GetType("System.String"))

        dgv_data.DataSource = table

        'Inicializamos el control de la fecha con el valor similar a getdate()'
        'para obtener la fecha y esta se asigne automaticamente al documento
        DT_FECHA.EditValue = DateTime.Now
        'Realizamos el listado del PROVEEDOR
        LIST_PROVIDERS()
        'Realizamos el listado de los almacenes disponibles
        LIST_WAREHOUSE()


        'listados adicionales
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

    Private Sub TXT_COSTO_UNIT_TextChanged(sender As Object, e As EventArgs) Handles TXT_COSTO_UNIT.TextChanged
        TXT_PRECION_PUB.Text = CType(Val(TXT_COSTO_UNIT.Text) * 3, String)
        TXT_IMPORTE.Text = CType(Val(TXT_CANTIDAD.Text) * Val(TXT_COSTO_UNIT.Text), String)
    End Sub

    Private Sub TXT_CANTIDAD_TextChanged(sender As Object, e As EventArgs) Handles TXT_CANTIDAD.TextChanged
        TXT_IMPORTE.Text = CType(Val(TXT_CANTIDAD.Text) * Val(TXT_COSTO_UNIT.Text), String)
    End Sub

    Private Sub CB_DESCRIPCION_Enter(sender As Object, e As EventArgs) Handles CB_DESCRIPCION.Enter
        LIST_DESCRIPTION()
    End Sub

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        Dim valida As Boolean = False
        If (TXT_CANTIDAD.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA CANTIDAD DE LAS PIEZAS", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        'ACCESORIO
        If (CB_ACCESORIO.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL ACCESORIO DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        'MATERIAL
        If (CB_MATERIAL.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL ACCESORIO DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        'LINEA
        If (TXT_LINEA.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA LINEA DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        'DESCRIPCION
        If (CB_DESCRIPCION.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        'COSTO UNITARIO
        If (TXT_COSTO_UNIT.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL COSTO UNITARIO DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        'PRECIO PUBLICO
        If (TXT_PRECION_PUB.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL PRECIO PUBLICO DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If
        'IMPORTE
        If (TXT_IMPORTE.Text = "") Then
            XtraMessageBox.Show("DEBE ESPECIFICAR EL IMPORTE DE LAS PIEZAS", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            valida = True
            Exit Sub
        End If

        table.Rows.Add(TXT_CANTIDAD.Text, CB_ACCESORIO.Text, CB_MATERIAL.Text, TXT_LINEA.Text, CB_DESCRIPCION.Text, TXT_COSTO_UNIT.Text, TXT_PRECION_PUB.Text, TXT_IMPORTE.Text)
        dgv_data.DataSource = table
        CLEAR_FIELDS()
        fSumar()
        Sumar_Piezas()
        txt_partidas.Text = Me.dgv_data.RowCount.ToString
    End Sub

    Private Sub BTN_DELETE_ROW_SELEC_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE_ROW_SELEC.ItemClick
        Try
            dgv_data.Rows.Remove(dgv_data.CurrentRow)
            CLEAR_FIELDS()
            fSumar()
            Sumar_Piezas()
            txt_partidas.Text = Me.dgv_data.RowCount.ToString
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BTN_DELETE_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_DELETE.ItemClick

        Try
            For Each row As DataGridViewRow In dgv_data.Rows
                dgv_data.Rows.Remove(row)
            Next
            'dgv_data.Rows.Clear()
        Catch ex As Exception
            'SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_data_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_data.CellValueChanged

        ' dgv_data.Rows.Remove(dgv_data.CurrentRow)
        '  CLEAR_FIELDS()
        fSumar()
        Sumar_Piezas()
        txt_partidas.Text = Me.dgv_data.RowCount.ToString
    End Sub

    Private Sub CB_MATERIAL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CB_MATERIAL.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub CB_ACCESORIO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CB_ACCESORIO.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub TXT_CANTIDAD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_CANTIDAD.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTN_ADD_PR_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BTN_ADD_PR.ItemClick

    End Sub
End Class
'se hace este modulo con la finalidad de agregar articulos en una sola compra a traves de un gridcontrol