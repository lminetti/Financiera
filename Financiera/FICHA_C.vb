Public Class FICHA_C

    Public Property Operador As String
    Public Property Nivel As String
    Dim Detalle1 As String = ""
    Dim Detalle2 As String = ""
    Dim Detalle3 As String = ""
    Dim Detalle4 As String = ""
    Dim Detalle5 As String = ""
    Dim Detalle6 As String = ""
    Dim Detalle7 As String = ""
    Dim Detalle8 As String = ""
    Dim Detalle9 As String = ""
    Dim Detalle10 As String = ""
    Dim Detalle11 As String = ""
    Dim Detalle12 As String = ""
    Dim Detalle13 As String = ""
    Dim Detalle14 As String = ""
    Dim Detalle15 As String = ""
    Dim Detalle16 As String = ""
    Dim Detalle17 As String = ""
    Dim Detalle18 As String = ""

    Private Sub FICHA_C_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DETALLE_RECIBOSTableAdapter.Fill(Me.DATABASEDataSet.DETALLE_RECIBOS)
        Me.RecibosTableAdapter.Fill(Me.DATABASEDataSet.Recibos)
        Me.TopMost = True

        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)
        Me.ABM_OBSTableAdapter.Fill(Me.ABMDataSet.ABM_OBS)
        Me.ABM_EXTRASTableAdapter.Fill(Me.ABMDataSet.ABM_EXTRAS)
        Me.ABM_LABORALTableAdapter.Fill(Me.ABMDataSet.ABM_LABORAL)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)

        TextBox1.Select()
        TextBox300.Text = "Opera: " + Operador
        Label42.Text = DateTime.Now.ToString("dd/MM/yyyy")

    End Sub

    Private Sub FICHA_C_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Panel8.Visible = True Then
                    Buscar()
                End If
            Case Keys.F1
                Button1.PerformClick()
            Case Keys.F2
                Button2.PerformClick()
            Case Keys.F3
                Button3.PerformClick()
            Case Keys.F4
                Button4.PerformClick()
            Case Keys.F5
                Button5.PerformClick()
            Case Keys.F10
                If Panel7.Visible = True Then
                    Button6.PerformClick()
                End If
            Case Keys.Escape
                Me.Close()
            Case Keys.Down
                If Panel8.Visible = True Then
                    If Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex < Me.ABM_PERSONALDataGridView.RowCount - 1 Then
                        Me.ABM_PERSONALDataGridView.CurrentCell = Me.ABM_PERSONALDataGridView(Me.ABM_PERSONALDataGridView.CurrentCell.ColumnIndex, Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex + 1)
                    End If
                    e.Handled = True
                End If
            Case Keys.Up
                If Panel8.Visible = True Then
                    If Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex > 0 Then
                        Me.ABM_PERSONALDataGridView.CurrentCell = Me.ABM_PERSONALDataGridView(Me.ABM_PERSONALDataGridView.CurrentCell.ColumnIndex, Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex - 1)
                    End If
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Panel3.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False
        Panel9.Visible = False
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.ControlDark
        Button8.BackColor = SystemColors.Control

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        Panel3.Visible = False
        Panel4.Visible = True
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False
        Panel9.Visible = False
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.ControlDark
        Button1.BackColor = SystemColors.Control
        Button8.BackColor = SystemColors.Control

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = True
        Panel6.Visible = False
        Panel7.Visible = False
        Panel9.Visible = False
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.ControlDark
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control
        Button8.BackColor = SystemColors.Control

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = True
        Panel7.Visible = False
        Panel9.Visible = False
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.ControlDark
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control
        Button8.BackColor = SystemColors.Control

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = True
        Panel9.Visible = False
        Button5.BackColor = SystemColors.ControlDark
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control
        Button8.BackColor = SystemColors.Control

        If DIARIO_CREDITOSDataGridView.RowCount = 1 Then
        End If

    End Sub


    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False
        Panel9.Visible = True
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control
        Button8.BackColor = SystemColors.ControlDark

    End Sub

    Private Sub Busqueda()

        If ABM_PERSONALDataGridView.RowCount > 0 Then
            ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value) & "'"
            ABM_LABORALBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value) & "'"
            ABM_OBSBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value) & "'"
            DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value) & "'"
            DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value) & "'"
            DIARIO_CUOTASBindingSource.Sort = "[CUOTA] ASC"
            RecibosBindingSource.Filter = "[ÚltimoDeCUENTA] = '" & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value & "'"
            RecibosBindingSource.Sort = "[NUMERO] ASC"
            DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)

            'Datos personales
            TextBox4.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(2).Value
            TextBox5.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(3).Value
            TextBox6.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(4).Value
            TextBox7.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(6).Value
            TextBox8.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(7).Value
            TextBox9.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(5).Value
            TextBox10.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(8).Value
            TextBox11.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(9).Value
            TextBox12.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(11).Value
            TextBox13.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(12).Value
            ComboBox3.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(15).Value
            TextBox26.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(10).Value
            If IsDBNull(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value) Then
                TextBox24.Text = ""
            Else
                TextBox24.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value
            End If
            If IsDBNull(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(17).Value) Then
                TextBox25.Text = ""
            Else
                TextBox25.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(17).Value
            End If

            If ABM_LABORALDataGridView.RowCount > 0 Then
                'Datos laborales
                TextBox14.Text = ABM_LABORALDataGridView.Rows(0).Cells(10).Value
                TextBox15.Text = ABM_LABORALDataGridView.Rows(0).Cells(2).Value
                TextBox16.Text = ABM_LABORALDataGridView.Rows(0).Cells(3).Value
                TextBox17.Text = ABM_LABORALDataGridView.Rows(0).Cells(7).Value
                TextBox18.Text = ABM_LABORALDataGridView.Rows(0).Cells(8).Value
                TextBox27.Text = ABM_LABORALDataGridView.Rows(0).Cells(4).Value
                TextBox28.Text = ABM_LABORALDataGridView.Rows(0).Cells(5).Value
                TextBox29.Text = ABM_LABORALDataGridView.Rows(0).Cells(6).Value
            End If

            If ABM_EXTRASDataGridView.RowCount > 0 Then
                'Contactos extras
                ComboBox1.Items.Clear()
                ComboBox1.Text = "Seleccionar"
                If ABM_EXTRASDataGridView.RowCount > 0 Then
                    For Each rw In ABM_EXTRASDataGridView.Rows
                        ComboBox1.Items.Add((rw.Cells(2)).Value & " " & (rw.Cells(3)).Value).ToString()
                    Next
                    TextBox22.Text = ABM_EXTRASDataGridView.Rows(0).Cells(2).Value & " " & ABM_EXTRASDataGridView.Rows(0).Cells(3).Value
                    TextBox21.Text = ABM_EXTRASDataGridView.Rows(0).Cells(8).Value
                    TextBox19.Text = ABM_EXTRASDataGridView.Rows(0).Cells(6).Value
                    TextBox30.Text = ABM_EXTRASDataGridView.Rows(0).Cells(4).Value
                    TextBox31.Text = ABM_EXTRASDataGridView.Rows(0).Cells(5).Value
                End If
            End If

            If ABM_OBSDataGridView.RowCount > 0 Then
                'Observaciones
                ComboBox2.Items.Clear()
                ComboBox2.Text = "Seleccionar"
                If ABM_OBSDataGridView.RowCount > 0 Then
                    For Each rw In ABM_OBSDataGridView.Rows
                        ComboBox2.Items.Add((rw.Cells(0)).Value & " " & (rw.Cells(3)).Value).ToString()
                    Next
                    TextBox20.Text = ABM_OBSDataGridView.Rows(0).Cells(2).Value
                End If
            End If

            If DataGridView1.RowCount > 0 Then
                DataGridView1.Rows.Clear()
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox23.Text = ""
            End If

            If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                'Créditos otorgados
                ComboBox4.Items.Clear()
                ComboBox4.Text = "Seleccionar"
                If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                    For Each rw In DIARIO_CREDITOSDataGridView.Rows
                        ComboBox4.Items.Add((rw.Cells(0)).Value).ToString()
                    Next
                End If
            End If

        End If
    End Sub

    Private Sub Buscar()
        Busqueda()
        Panel8.Visible = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.TextLength > 0 Then
            If IsNumeric(TextBox1.Text) Then
                ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & TextBox1.Text & "' Or [DNI] LIKE '" & TextBox1.Text & "%' Or [CUIL] LIKE '" & TextBox1.Text & "%'"
            Else
                ABM_PERSONALBindingSource.Filter = "[NOMBRE] LIKE '" & TextBox1.Text & "%' Or [APELLIDO] LIKE '" & TextBox1.Text & "%'"
            End If
            If ABM_PERSONALDataGridView.RowCount > 0 Then
                Panel8.Visible = True
                Busqueda()
            End If
        End If

        If TextBox1.Text = "" Or ABM_PERSONALDataGridView.RowCount = 0 Then
            Panel8.Visible = False
            ABM_PERSONALBindingSource.Filter = "[CUENTA] = '0'"
            DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '0'"
            DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '0'"
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            TextBox11.Text = ""
            TextBox12.Text = ""
            ComboBox3.Text = ""
        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'Cambiar calificacion
        If Nivel = "3" Then
            If ComboBox3.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(15).Value Then
                Exit Sub
            ElseIf TextBox1.Text = "" Then
                Exit Sub
            Else
                Dim result As Integer = MessageBox.Show("¿Cambiar calificación de cliente?", "Calificación", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(15).Value = ComboBox3.Text
                    ABM_PERSONALBindingSource.EndEdit()
                    ABM_PERSONALTableAdapter.Update(ABMDataSet.ABM_PERSONAL)
                End If
            End If
        Else
            MessageBox.Show("Operadores con nivel menor a 3 no pueden cambiar la calificación del cliente")
            Exit Sub
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'CAMBIAR OBSERVACIÓN
        If ComboBox2.Text = "Seleccionar" Then
        Else
            ABM_OBSBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value) & "' AND [ID] = '" & ComboBox2.Text.Substring(0, ComboBox2.Text.IndexOf(" ")) & "'"
            TextBox20.Text = ABM_OBSDataGridView.Rows(0).Cells(2).Value
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'CAMBIAR CONTACTO
        If ComboBox1.Text = "Seleccionar" Then
        Else
            ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value) & "' AND [NOMBRE] = '" & ComboBox1.Text.Substring(0, ComboBox1.Text.IndexOf(" ")) & "'"
            TextBox22.Text = ABM_EXTRASDataGridView.Rows(0).Cells(2).Value & " " & ABM_EXTRASDataGridView.Rows(0).Cells(3).Value
            TextBox21.Text = ABM_EXTRASDataGridView.Rows(0).Cells(8).Value
            TextBox19.Text = ABM_EXTRASDataGridView.Rows(0).Cells(6).Value
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Excel1()
    End Sub

    Private Sub Excel1()
        Dim App_xls As Object
        Dim fila, columna As Integer
        App_xls = CreateObject("Excel.Application")
        App_xls.workbooks.add()

        App_xls.Visible = True

        Try
            For columna = 0 To DataGridView1.ColumnCount - 1
                App_xls.ActiveSheet.cells(1, columna + 1).value = DataGridView1.Columns(columna).HeaderText
            Next
            For fila = 0 To DataGridView1.Rows.Count - 1
                For columna = 0 To DataGridView1.ColumnCount - 1
                    If IsNumeric(DataGridView1.Item(columna, fila).Value) Then
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CDbl(DataGridView1.Item(columna, fila).Value)
                    Else
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = DataGridView1.Item(columna, fila).Value
                    End If
                Next
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        'Filtrar cuotas con mora
        If DIARIO_CUOTASDataGridView.RowCount > 0 Then
            DIARIO_CUOTASBindingSource.Filter = "[VALOR_CUOTA] > [PAGADO] AND [DIAS_MORA] > 0"
        End If

        Me.DIARIO_CUOTASDataGridView.Columns.RemoveAt(0)
        Me.DIARIO_CUOTASDataGridView.Columns.RemoveAt(4)
        Me.DIARIO_CUOTASDataGridView.Columns.RemoveAt(4)

        'Ordenar por cuenta
        DIARIO_CUOTASDataGridView.Sort(DIARIO_CUOTASDataGridView.Columns(2), System.ComponentModel.ListSortDirection.Ascending)

        'Exportar a excel
        Dim App_xls As Object
        Dim fila, columna As Integer
        App_xls = CreateObject("Excel.Application")
        App_xls.workbooks.add()

        App_xls.Visible = True

        Try
            For columna = 0 To DIARIO_CUOTASDataGridView.ColumnCount - 1
                App_xls.ActiveSheet.cells(1, columna + 1).value = DIARIO_CUOTASDataGridView.Columns(columna).HeaderText
            Next
            For fila = 0 To DIARIO_CUOTASDataGridView.Rows.Count - 1
                For columna = 0 To DIARIO_CUOTASDataGridView.ColumnCount - 1
                    If IsNumeric(DIARIO_CUOTASDataGridView.Item(columna, fila).Value) Then
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CDbl(DIARIO_CUOTASDataGridView.Item(columna, fila).Value)
                    Else
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = DIARIO_CUOTASDataGridView.Item(columna, fila).Value
                    End If
                Next
            Next

        Catch ex As Exception

        End Try

        Me.Close()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        'Filtrar cuotas que vencen este mes
        Dim sourceDate As DateTime = DateTime.Now.ToString("dd/MM/yyyy")
        Dim firstDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        lastDay = lastDay.AddMonths(1).AddDays(-1)

        Dim fecha1 As Date = firstDay.ToString("dd/MM/yyyy")
        Dim fecha2 As Date = lastDay.ToString("dd/MM/yyyy")

        If DIARIO_CUOTASDataGridView.RowCount > 0 Then
            DIARIO_CUOTASBindingSource.Filter = "[FECHA_VENCIMIENTO] >= #" & fecha1.ToString("MM/dd/yyyy") & "# AND [FECHA_VENCIMIENTO] <= #" & fecha2.ToString("MM/dd/yyyy") & "#"
        End If

        Me.DIARIO_CUOTASDataGridView.Columns.RemoveAt(0)

        'Ordenar por fecha
        DIARIO_CUOTASDataGridView.Sort(DIARIO_CUOTASDataGridView.Columns(6), System.ComponentModel.ListSortDirection.Ascending)

        'Exportar a excel
        Dim App_xls As Object
        Dim fila, columna As Integer
        App_xls = CreateObject("Excel.Application")
        App_xls.workbooks.add()

        App_xls.Visible = True

        Try
            For columna = 0 To DIARIO_CUOTASDataGridView.ColumnCount - 1
                App_xls.ActiveSheet.cells(1, columna + 1).value = DIARIO_CUOTASDataGridView.Columns(columna).HeaderText
            Next
            For fila = 0 To DIARIO_CUOTASDataGridView.Rows.Count - 1
                For columna = 0 To DIARIO_CUOTASDataGridView.ColumnCount - 1
                    If IsNumeric(DIARIO_CUOTASDataGridView.Item(columna, fila).Value) Then
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CDbl(DIARIO_CUOTASDataGridView.Item(columna, fila).Value)
                    Else
                        If IsDate(DIARIO_CUOTASDataGridView.Item(columna, fila).Value) Then
                            App_xls.ActiveSheet.Cells(fila + 2, columna + 1) = Convert.ToDateTime(DIARIO_CUOTASDataGridView.Item(columna, fila).Value).GetDateTimeFormats(Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
                        Else
                            App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = DIARIO_CUOTASDataGridView.Item(columna, fila).Value
                        End If
                    End If
                Next
            Next

        Catch ex As Exception

        End Try

        Me.Close()

    End Sub

    Private Sub ABM_PERSONALDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ABM_PERSONALDataGridView.CellClick
        Buscar()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

        If DataGridView1.RowCount > 0 Then
            DataGridView1.Rows.Clear()
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox23.Text = ""
        End If
        LlenarDataGrid_Cred()

    End Sub

    Private Sub LlenarDataGrid_Cred()

        Dim op As Integer = 0

        If ComboBox4.Text = "Seleccionar" Then
        Else
            op = CInt(ComboBox4.Text)
        End If

        DIARIO_CREDITOSBindingSource.Filter = "[OPERACION] = '" & op & "'"
        DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & op & "'"
        DIARIO_CUOTASBindingSource.Sort = "[CUOTA] ASC"

        If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
            TextBox2.Text = DIARIO_CREDITOSDataGridView.Rows(0).Cells(2).Value
            TextBox3.Text = DIARIO_CREDITOSDataGridView.Rows(0).Cells(1).Value
            TextBox23.Text = DIARIO_CREDITOSDataGridView.Rows(0).Cells(0).Value
        End If

        If DIARIO_CUOTASDataGridView.RowCount > 0 Then

            DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
            DIARIO_CUOTASDataGridView.Rows(0).Selected = True

            Do

                Dim cuota As String = ""
                Dim valor As String = ""
                Dim fecha_pago As String = ""
                Dim dias_mora As String = ""
                Dim punitorios As String = ""
                Dim vto As String = ""
                Dim total As String = ""

                If IsDBNull(DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(1).Value) Then
                    cuota = ""
                Else
                    cuota = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(1).Value
                End If
                If IsDBNull(DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(2).Value) Then
                    valor = ""
                Else
                    valor = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(2).Value
                End If
                If IsDBNull(DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(8).Value) Then
                    fecha_pago = ""
                Else
                    fecha_pago = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(8).Value
                End If
                If IsDBNull(DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(5).Value) Then
                    dias_mora = ""
                Else
                    dias_mora = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(5).Value
                End If
                If IsDBNull(DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(6).Value) Then
                    punitorios = ""
                Else
                    punitorios = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(6).Value
                End If
                If IsDBNull(DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(4).Value) Then
                    vto = ""
                Else
                    vto = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(4).Value
                End If
                If IsDBNull(DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(7).Value) Then
                    total = ""
                Else
                    total = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(7).Value
                End If

                DataGridView1.Rows.Add(New String() {cuota, valor, fecha_pago, dias_mora, punitorios, vto, total})

                ' Selecciona la siguiente fila

                Dim counter As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = DIARIO_CUOTASDataGridView.RowCount Then
                    Exit Do
                Else
                    nextRow = DIARIO_CUOTASDataGridView.Rows(counter)
                End If

                DIARIO_CUOTASDataGridView.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True

            Loop
        End If

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click

        DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '" & RecibosDataGridView.Rows(RecibosDataGridView.CurrentRow.Index).Cells(2).Value & "' AND [OPERACION] = '" & RecibosDataGridView.Rows(RecibosDataGridView.CurrentRow.Index).Cells(3).Value & "'"
        DETALLE_RECIBOSBindingSource.Filter = "[CUENTA] = '" & RecibosDataGridView.Rows(RecibosDataGridView.CurrentRow.Index).Cells(2).Value & "' AND [NUMERO] = '" & RecibosDataGridView.Rows(RecibosDataGridView.CurrentRow.Index).Cells(1).Value & "'"
        DETALLE_RECIBOSDataGridView.AllowUserToAddRows = False

        Dim cantFilas As Integer = DETALLE_RECIBOSDataGridView.RowCount
        Dim currentRow As Integer = DETALLE_RECIBOSDataGridView.CurrentRow.Index
        Dim cantCuotas As Integer = DIARIO_CUOTASDataGridView.RowCount

        If cantFilas > 0 Then
            Detalle1 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(0).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(0).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(0).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(0).Cells(8).Value
        End If
        If cantFilas > 1 Then
            Detalle2 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(1).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(1).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(1).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(1).Cells(8).Value
        End If
        If cantFilas > 2 Then
            Detalle3 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(2).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(2).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(2).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(2).Cells(8).Value
        End If
        If cantFilas > 3 Then
            Detalle4 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(3).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(3).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(3).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(3).Cells(8).Value
        End If
        If cantFilas > 4 Then
            Detalle5 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(4).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(4).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(4).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(4).Cells(8).Value
        End If
        If cantFilas > 5 Then
            Detalle6 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(5).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(5).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(5).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(5).Cells(8).Value
        End If
        If cantFilas > 6 Then
            Detalle7 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(6).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(6).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(6).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(6).Cells(8).Value
        End If
        If cantFilas > 7 Then
            Detalle8 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(7).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(7).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(7).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(7).Cells(8).Value
        End If
        If cantFilas > 8 Then
            Detalle9 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(8).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(8).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(8).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(8).Cells(8).Value
        End If
        If cantFilas > 9 Then
            Detalle10 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(9).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(9).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(9).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(9).Cells(8).Value
        End If
        If cantFilas > 10 Then
            Detalle11 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(10).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(10).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(10).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(10).Cells(8).Value
        End If
        If cantFilas > 11 Then
            Detalle12 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(11).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(11).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(11).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(11).Cells(8).Value
        End If
        If cantFilas > 12 Then
            Detalle13 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(12).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(12).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(12).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(12).Cells(8).Value
        End If
        If cantFilas > 13 Then
            Detalle14 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(13).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(13).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(13).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(13).Cells(8).Value
        End If
        If cantFilas > 14 Then
            Detalle15 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(14).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(14).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(14).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(14).Cells(8).Value
        End If
        If cantFilas > 15 Then
            Detalle16 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(15).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(15).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(15).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(15).Cells(8).Value
        End If
        If cantFilas > 16 Then
            Detalle17 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(16).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(16).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(16).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(16).Cells(8).Value
        End If
        If cantFilas > 17 Then
            Detalle18 = "OPERACIÓN: " & DETALLE_RECIBOSDataGridView.Rows(17).Cells(5).Value & " - " & "CUOTA: " & DETALLE_RECIBOSDataGridView.Rows(17).Cells(6).Value & " de " & cantCuotas & " - " & DETALLE_RECIBOSDataGridView.Rows(17).Cells(7).Value & " --- $" & DETALLE_RECIBOSDataGridView.Rows(17).Cells(8).Value
        End If

        If DETALLE_RECIBOSDataGridView.RowCount > 0 Then
            Dim Impresion_Recibo = New Impresion_Recibo()
            Impresion_Recibo.Nombre = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(2).Value & " " & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(3).Value
            Impresion_Recibo.Domicilio_cliente = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(8).Value
            Impresion_Recibo.Localidad = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(9).Value
            Impresion_Recibo.Dni = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(6).Value
            Impresion_Recibo.Cuenta = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value

            Impresion_Recibo.FACTURA = 0
            Impresion_Recibo.Condicion_iva_cliente = "CONSUMIDOR FINAL"

            Impresion_Recibo.Detalle1 = Detalle1
            Impresion_Recibo.Detalle2 = Detalle2
            Impresion_Recibo.Detalle3 = Detalle3
            Impresion_Recibo.Detalle4 = Detalle4
            Impresion_Recibo.Detalle5 = Detalle5
            Impresion_Recibo.Detalle6 = Detalle6
            Impresion_Recibo.Detalle7 = Detalle7
            Impresion_Recibo.Detalle8 = Detalle8
            Impresion_Recibo.Detalle9 = Detalle9
            Impresion_Recibo.Detalle10 = Detalle10
            Impresion_Recibo.Detalle11 = Detalle11
            Impresion_Recibo.Detalle12 = Detalle12
            Impresion_Recibo.Detalle13 = Detalle13
            Impresion_Recibo.Detalle14 = Detalle14
            Impresion_Recibo.Detalle15 = Detalle15
            Impresion_Recibo.Detalle16 = Detalle16
            Impresion_Recibo.Detalle17 = Detalle17
            Impresion_Recibo.Detalle18 = Detalle18

            Impresion_Recibo.EsCopia = "SI"
            Impresion_Recibo.CompteNro = RecibosDataGridView.Rows(RecibosDataGridView.CurrentRow.Index).Cells(1).Value

            Impresion_Recibo.Total = RecibosDataGridView.Rows(RecibosDataGridView.CurrentRow.Index).Cells(5).Value
            Impresion_Recibo.Operacion = RecibosDataGridView.Rows(RecibosDataGridView.CurrentRow.Index).Cells(3).Value
            Impresion_Recibo.Fecha = RecibosDataGridView.Rows(RecibosDataGridView.CurrentRow.Index).Cells(4).Value
            Impresion_Recibo.Show()
        Else
            MessageBox.Show("No existen datos.")
        End If

    End Sub

End Class