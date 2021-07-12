Public Class Ficha_Clientes
    Public Property Operador As String
    Public Property Nivel As String

    Private Sub Ficha_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ABM_OBSTableAdapter.Fill(Me.ABMDataSet.ABM_OBS)
        Me.ABM_EXTRASTableAdapter.Fill(Me.ABMDataSet.ABM_EXTRAS)
        Me.ABM_LABORALTableAdapter.Fill(Me.ABMDataSet.ABM_LABORAL)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)

        DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '0'"

        TextBox30.Text = "Opera: " + Operador
        Label42.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox2.Select()
    End Sub

    Private Sub Ficha_Clientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F10
                Button1.PerformClick()
            Case Keys.F9
                Button3.PerformClick()
            Case Keys.F8
                Button4.PerformClick()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Busqueda()
        If ABM_PERSONALDataGridView.RowCount > 0 Then
            ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(0).Cells(1).Value) & "'"
            ABM_LABORALBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(0).Cells(1).Value) & "'"
            ABM_OBSBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(0).Cells(1).Value) & "'"
            DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(0).Cells(1).Value) & "'"
            DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(0).Cells(1).Value) & "'"
            DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)

            'Datos personales
            TextBox1.Text = ABM_PERSONALDataGridView.Rows(0).Cells(2).Value
            TextBox3.Text = ABM_PERSONALDataGridView.Rows(0).Cells(3).Value
            TextBox4.Text = ABM_PERSONALDataGridView.Rows(0).Cells(4).Value
            TextBox5.Text = ABM_PERSONALDataGridView.Rows(0).Cells(5).Value
            TextBox6.Text = ABM_PERSONALDataGridView.Rows(0).Cells(6).Value
            TextBox7.Text = ABM_PERSONALDataGridView.Rows(0).Cells(7).Value
            TextBox8.Text = ABM_PERSONALDataGridView.Rows(0).Cells(8).Value
            TextBox9.Text = ABM_PERSONALDataGridView.Rows(0).Cells(9).Value
            TextBox10.Text = ABM_PERSONALDataGridView.Rows(0).Cells(11).Value
            TextBox11.Text = ABM_PERSONALDataGridView.Rows(0).Cells(12).Value
            ComboBox3.Text = ABM_PERSONALDataGridView.Rows(0).Cells(15).Value
            'Datos laborales
            TextBox17.Text = ABM_LABORALDataGridView.Rows(0).Cells(10).Value
            TextBox16.Text = ABM_LABORALDataGridView.Rows(0).Cells(2).Value
            TextBox15.Text = ABM_LABORALDataGridView.Rows(0).Cells(3).Value
            TextBox14.Text = ABM_LABORALDataGridView.Rows(0).Cells(7).Value
            TextBox13.Text = ABM_LABORALDataGridView.Rows(0).Cells(8).Value
            'Contactos extras
            ComboBox1.Items.Clear()
            ComboBox1.Text = "Seleccionar"
            If ABM_EXTRASDataGridView.RowCount > 0 Then
                For Each rw In ABM_EXTRASDataGridView.Rows
                    ComboBox1.Items.Add((rw.Cells(2)).Value & " " & (rw.Cells(3)).Value).ToString()
                Next
                TextBox22.Text = ABM_EXTRASDataGridView.Rows(0).Cells(2).Value & " " & ABM_EXTRASDataGridView.Rows(0).Cells(3).Value
                TextBox21.Text = ABM_EXTRASDataGridView.Rows(0).Cells(8).Value
                TextBox18.Text = ABM_EXTRASDataGridView.Rows(0).Cells(6).Value
            End If
            'Observaciones
            ComboBox2.Items.Clear()
            ComboBox2.Text = "Seleccionar"
            If ABM_OBSDataGridView.RowCount > 0 Then
                For Each rw In ABM_OBSDataGridView.Rows
                    ComboBox2.Items.Add((rw.Cells(0)).Value & " " & (rw.Cells(3)).Value).ToString()
                Next
                TextBox19.Text = ABM_OBSDataGridView.Rows(0).Cells(2).Value
            End If

            If DIARIO_CUOTASDataGridView.RowCount > 0 Then
                For Each rw In DIARIO_CUOTASDataGridView.Rows
                    If rw.Cells(5).Value < rw.Cells(10).Value Then
                        TextBox12.Text = "El cliente registra mora."
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        If TextBox20.TextLength > 0 Or TextBox23.TextLength > 0 Then
            ABM_PERSONALBindingSource.Filter = "[NOMBRE] LIKE '" & TextBox20.Text & "%' AND [APELLIDO] LIKE '" & TextBox23.Text & "%'"
            Busqueda()
        Else
            DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '0'"
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
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

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged
        If TextBox20.TextLength > 0 Or TextBox23.TextLength > 0 Then
            ABM_PERSONALBindingSource.Filter = "[NOMBRE] LIKE '" & TextBox20.Text & "%' AND [APELLIDO] LIKE '" & TextBox23.Text & "%'"
            Busqueda()
        Else
            DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '0'"
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength > 0 Then
            ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' Or [DNI] = '" & TextBox2.Text & "' Or [CUIL] = '" & TextBox2.Text & "'"
            Busqueda()
        Else
            DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '0'"
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'CAMBIAR OBSERVACIÓN
        If ComboBox2.Text = "Seleccionar" Then
        Else
            ABM_OBSBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(0).Cells(1).Value) & "' AND [ID] = '" & ComboBox2.Text.Substring(0, ComboBox2.Text.IndexOf(" ")) & "'"
            TextBox19.Text = ABM_OBSDataGridView.Rows(0).Cells(2).Value
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'CAMBIAR CONTACTO
        If ComboBox1.Text = "Seleccionar" Then
        Else
            ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(0).Cells(1).Value) & "' AND [NOMBRE] = '" & ComboBox1.Text.Substring(0, ComboBox1.Text.IndexOf(" ")) & "'"
            TextBox22.Text = ABM_EXTRASDataGridView.Rows(0).Cells(2).Value & " " & ABM_EXTRASDataGridView.Rows(0).Cells(3).Value
            TextBox21.Text = ABM_EXTRASDataGridView.Rows(0).Cells(8).Value
            TextBox18.Text = ABM_EXTRASDataGridView.Rows(0).Cells(6).Value
        End If
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        Label19.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim App_xls As Object
        Dim fila, columna As Integer
        App_xls = CreateObject("Excel.Application")
        App_xls.workbooks.add()

        App_xls.Visible = True

        Try
            For columna = 0 To DIARIO_CREDITOSDataGridView.ColumnCount - 1
                App_xls.ActiveSheet.cells(1, columna + 1).value = DIARIO_CREDITOSDataGridView.Columns(columna).HeaderText
            Next
            For fila = 0 To DIARIO_CREDITOSDataGridView.Rows.Count - 1
                For columna = 0 To DIARIO_CREDITOSDataGridView.ColumnCount - 1
                    If IsNumeric(DIARIO_CREDITOSDataGridView.Item(columna, fila).Value) Then
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CDbl(DIARIO_CREDITOSDataGridView.Item(columna, fila).Value)
                    Else
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = DIARIO_CREDITOSDataGridView.Item(columna, fila).Value
                    End If
                Next
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Filtrar cuotas con mora
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
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

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Cambiar calificacion
        If Nivel = "3" Then
            If ComboBox3.Text = ABM_PERSONALDataGridView.Rows(0).Cells(15).Value Then
                Exit Sub
            ElseIf TextBox1.Text = "" Then
                Exit Sub
            Else
                Dim result As Integer = MessageBox.Show("¿Cambiar calificación de cliente?", "Calificación", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    ABM_PERSONALDataGridView.Rows(0).Cells(15).Value = ComboBox3.Text
                    ABM_PERSONALBindingSource.EndEdit()
                    ABM_PERSONALTableAdapter.Update(ABMDataSet.ABM_PERSONAL)
                End If
            End If
        Else
            MessageBox.Show("Operadores con nivel menor a 3 no pueden cambiar la calificación del cliente")
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Filtrar cuotas que vencen este mes
        Dim sourceDate As DateTime = DateTime.Now.ToString("dd/MM/yyyy")
        Dim firstDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        lastDay = lastDay.AddMonths(1).AddDays(-1)

        Dim fecha1 As Date = firstDay.ToString("dd/MM/yyyy")
        Dim fecha2 As Date = lastDay.ToString("dd/MM/yyyy")

        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
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
End Class