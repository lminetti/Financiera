Public Class REPORTES

    Private Sub REPORTES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Me.CAJASTableAdapter.Fill(Me.DATABASEDataSet.CAJAS)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)
    End Sub

    Private Sub Reportes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                If Panel1.Visible = True Then
                    Button1.PerformClick()
                ElseIf Panel2.Visible = True Then
                    Button2.PerformClick()
                ElseIf Panel3.Visible = True Then
                    Button3.PerformClick()
                ElseIf Panel1.Visible = False And Panel2.Visible = False And Panel3.Visible = False Then
                    Button4.PerformClick()
                End If
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ListBox1.SelectedItem = "CLIENTES" Then
            Exc1()
        ElseIf ListBox1.SelectedItem = "CLIENTES CON MORA" Then
            Panel2.Visible = True
        ElseIf ListBox1.SelectedItem = "CRÉDITOS OTORGADOS" Then
            Exc3()
        ElseIf ListBox1.SelectedItem = "CUOTAS POR FECHA" Then
            Panel3.Visible = True
        ElseIf ListBox1.SelectedItem = "MOVIMIENTOS DE CAJA POR FECHA" Then
            ComboBox2.Items.Clear()
            ComboBox2.Text = "Seleccionar"
            If CAJASDataGridView.RowCount > 0 Then
                For Each rw In CAJASDataGridView.Rows
                    ComboBox2.Items.Add((rw.Cells(2)).Value).ToString()
                Next
            End If
            Panel1.Visible = True
        ElseIf ListBox1.SelectedItem = "RESUMEN DE CUOTAS" Then
            Panel3.Visible = True
            PictureBox1.Visible = True
        ElseIf ListBox1.SelectedItem = "REPORTE PARA ASEGURADORA" Then
            Panel3.Visible = True
        End If
    End Sub

    Private Sub Exc1()
        'Ordenar por apellido
        ABM_PERSONALDataGridView.Sort(ABM_PERSONALDataGridView.Columns(2), System.ComponentModel.ListSortDirection.Ascending)

        'Exportar a excel
        Dim App_xls As Object
        Dim fila, columna As Integer
        App_xls = CreateObject("Excel.Application")
        App_xls.workbooks.add()

        App_xls.Visible = True

        Try
            For columna = 0 To ABM_PERSONALDataGridView.ColumnCount - 1
                App_xls.ActiveSheet.cells(1, columna + 1).value = ABM_PERSONALDataGridView.Columns(columna).HeaderText
            Next
            For fila = 0 To ABM_PERSONALDataGridView.Rows.Count - 1
                For columna = 0 To ABM_PERSONALDataGridView.ColumnCount - 1
                    If IsNumeric(ABM_PERSONALDataGridView.Item(columna, fila).Value) Then
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CDbl(ABM_PERSONALDataGridView.Item(columna, fila).Value)
                    Else
                        If IsDate(ABM_PERSONALDataGridView.Item(columna, fila).Value) Then
                            App_xls.ActiveSheet.Cells(fila + 2, columna + 1) = Convert.ToDateTime(ABM_PERSONALDataGridView.Item(columna, fila).Value).GetDateTimeFormats(Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
                        Else
                            App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = ABM_PERSONALDataGridView.Item(columna, fila).Value
                        End If
                    End If
                Next
            Next

        Catch ex As Exception

        End Try

        Me.Close()
    End Sub

    Private Sub Exc2()
        'Filtrar cuotas con mora
        If DIARIO_CUOTASDataGridView.RowCount > 0 Then
            If CheckBox1.CheckState = CheckState.Checked Then
                DIARIO_CUOTASBindingSource.Filter = "[VALOR_CUOTA] > [PAGADO] AND [DIAS_MORA] > 0"
            Else
                DIARIO_CUOTASBindingSource.Filter = "[VALOR_CUOTA] > [PAGADO] AND [DIAS_MORA] > 0 AND [FECHA_VENCIMIENTO] >= #" & DateTimePicker4.Value.ToString("MM/dd/yyyy") & "# AND [FECHA_VENCIMIENTO] <= #" & DateTimePicker3.Value.ToString("MM/dd/yyyy") & "#"
            End If
        End If

        'Ordenar por fecha
        DIARIO_CUOTASDataGridView.Sort(DIARIO_CUOTASDataGridView.Columns(4), System.ComponentModel.ListSortDirection.Ascending)

        'Exportar a excel
        Dim App_xls As Object
        Dim fila, columna As Integer
        App_xls = CreateObject("Excel.Application")
        App_xls.workbooks.add()

        App_xls.Visible = True

        'Columna en formato texto para que no invierta la fecha
        App_xls.Columns(5).NumberFormat = "@"

        Try
            For columna = 0 To DIARIO_CUOTASDataGridView.ColumnCount - 1
                App_xls.ActiveSheet.cells(1, columna + 1).value = DIARIO_CUOTASDataGridView.Columns(columna).HeaderText
            Next
            For fila = 0 To DIARIO_CUOTASDataGridView.Rows.Count - 1
                For columna = 0 To DIARIO_CUOTASDataGridView.ColumnCount - 1
                    If IsDate(DIARIO_CUOTASDataGridView.Item(columna, fila).Value) Then
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CStr(DIARIO_CUOTASDataGridView.Item(columna, fila).Value)
                    Else
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = DIARIO_CUOTASDataGridView.Item(columna, fila).Value
                    End If
                Next
            Next

        Catch ex As Exception

        End Try

        Me.Close()
    End Sub

    Private Sub Exc3()
        'Ordenar por cuenta
        DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
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
                        If IsDate(DIARIO_CREDITOSDataGridView.Item(columna, fila).Value) Then
                            App_xls.ActiveSheet.Cells(fila + 2, columna + 1) = Convert.ToDateTime(DIARIO_CREDITOSDataGridView.Item(columna, fila).Value).GetDateTimeFormats(Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
                        Else
                            App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = DIARIO_CREDITOSDataGridView.Item(columna, fila).Value
                        End If
                    End If
                Next
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Exc4()

        Dim result As Integer = MessageBox.Show("¿Ver cuotas saldadas?", "", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            If DIARIO_CUOTASDataGridView.RowCount > 0 Then
                DIARIO_CUOTASBindingSource.Filter = "[FECHA_VENCIMIENTO] >= #" & DateTimePicker6.Value.ToString("MM/dd/yyyy") & "# AND [FECHA_VENCIMIENTO] <= #" & DateTimePicker5.Value.ToString("MM/dd/yyyy") & "# AND [VALOR_CUOTA] >= '1' OR [FECHA_VENCIMIENTO] >= #" & DateTimePicker6.Value.ToString("MM/dd/yyyy") & "# AND [FECHA_VENCIMIENTO] <= #" & DateTimePicker5.Value.ToString("MM/dd/yyyy") & "# AND [VALOR_CUOTA] > '0,00'"
            End If
        ElseIf result = DialogResult.Yes Then
            If DIARIO_CUOTASDataGridView.RowCount > 0 Then
                DIARIO_CUOTASBindingSource.Filter = "[FECHA_VENCIMIENTO] >= #" & DateTimePicker6.Value.ToString("MM/dd/yyyy") & "# AND [FECHA_VENCIMIENTO] <= #" & DateTimePicker5.Value.ToString("MM/dd/yyyy") & "#"
            End If
        End If

        'Ordenar por fecha
        DIARIO_CUOTASDataGridView.Sort(DIARIO_CUOTASDataGridView.Columns(4), System.ComponentModel.ListSortDirection.Ascending)

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

    Private Sub Exc5()

        CONTABLEBindingSource.Filter = "[CAJA] = '" & ComboBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "#"

        Dim App_xls As Object
        Dim fila, columna As Integer
        App_xls = CreateObject("Excel.Application")
        App_xls.workbooks.add()

        App_xls.Visible = True

        Try
            For columna = 0 To CONTABLEDataGridView.ColumnCount - 1
                App_xls.ActiveSheet.cells(1, columna + 1).value = CONTABLEDataGridView.Columns(columna).HeaderText
            Next
            For fila = 0 To CONTABLEDataGridView.Rows.Count - 1
                For columna = 0 To CONTABLEDataGridView.ColumnCount - 1
                    If IsNumeric(CONTABLEDataGridView.Item(columna, fila).Value) Then
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CDbl(CONTABLEDataGridView.Item(columna, fila).Value)
                    Else
                        If IsDate(CONTABLEDataGridView.Item(columna, fila).Value) Then
                            App_xls.ActiveSheet.Cells(fila + 2, columna + 1) = Convert.ToDateTime(CONTABLEDataGridView.Item(columna, fila).Value).GetDateTimeFormats(Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
                        Else
                            App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CONTABLEDataGridView.Item(columna, fila).Value
                        End If
                    End If
                Next
            Next

        Catch ex As Exception

        End Try

        Me.Close()
    End Sub

    Private Sub Exc6()

        If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
            DIARIO_CREDITOSBindingSource.Filter = "[FECHA] >= #" & DateTimePicker6.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker5.Value.ToString("MM/dd/yyyy") & "# AND [DEUDA] NOT LIKE '0%'"
        End If

        'Ordenar por fecha
        DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

        DIARIO_CREDITOSDataGridView.CurrentCell = DIARIO_CREDITOSDataGridView.Rows(0).Cells(0)
        DIARIO_CREDITOSDataGridView.Rows(0).Selected = True

        Do
            Dim nombre As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(2).Value
            Dim apellido As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(3).Value
            Dim edad As Integer
            Dim f_nacimiento As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(14).Value
            Dim dni As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(4).Value
            Dim cuitcuil As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(5).Value
            Dim fecha As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(11).Value
            Dim deuda As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(12).Value

            Dim nacimiento As Date = CDate(DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(14).Value)
            edad = Today.Year - nacimiento.Year
            If (nacimiento > Today.AddYears(-edad)) Then edad -= 1

            DataGridView1.Rows.Add(New String() {nombre, apellido, edad, f_nacimiento, dni, cuitcuil, fecha, deuda})

            ' Selecciona la siguiente fila
            Dim counter As Integer = DIARIO_CREDITOSDataGridView.CurrentRow.Index + 1
            Dim nextRow As DataGridViewRow
            If counter = DIARIO_CREDITOSDataGridView.RowCount Then
                Exit Do
            Else
                nextRow = DIARIO_CREDITOSDataGridView.Rows(counter)
            End If
            DIARIO_CREDITOSDataGridView.CurrentCell = nextRow.Cells(0)
            nextRow.Selected = True

        Loop

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
                        If IsDate(DataGridView1.Item(columna, fila).Value) Then
                            App_xls.ActiveSheet.Cells(fila + 2, columna + 1) = Convert.ToDateTime(DataGridView1.Item(columna, fila).Value).GetDateTimeFormats(Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
                        Else
                            App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = DataGridView1.Item(columna, fila).Value
                        End If
                    End If
                Next
            Next

        Catch ex As Exception

        End Try

        Me.Close()
    End Sub

    Private Sub Exc7()

        Dim operacion As String = "0"
        Dim fecha1 As DateTime = DateTimePicker6.Value.ToString("dd/MM/yyyy")
        Dim dia As Integer = 1
        Dim año As Integer = fecha1.Year
        Dim mes As Integer = fecha1.Month + 1
        If mes > 12 Then
            mes = 12
        End If
        Dim fecha2 As DateTime = (dia & "/" & mes & "/" & año)

        DIARIO_CUOTASBindingSource.Filter = "[VALOR_CUOTA] >= '1' AND [FECHA_VENCIMIENTO] < #" & fecha2.ToString("MM/dd/yyyy") & "#"

        'Ordenar por fecha
        DIARIO_CUOTASDataGridView.Sort(DIARIO_CUOTASDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
        DIARIO_CUOTASDataGridView.Rows(0).Selected = True

        Do

            If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = operacion Then
                ' Selecciona la siguiente fila
                Dim counter2 As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index + 1
                Dim nextRow2 As DataGridViewRow
                If counter2 = DIARIO_CUOTASDataGridView.RowCount Then
                    Exit Do
                Else
                    nextRow2 = DIARIO_CUOTASDataGridView.Rows(counter2)
                End If
                DIARIO_CUOTASDataGridView.CurrentCell = nextRow2.Cells(0)
                nextRow2.Selected = True
            Else
                operacion = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value
                DIARIO_CREDITOSBindingSource.Filter = "[OPERACION] = '" & CInt(operacion) & "'"

                Dim fecha As String = DIARIO_CREDITOSDataGridView.Rows(0).Cells(11).Value
                Dim nombre As String = DIARIO_CREDITOSDataGridView.Rows(0).Cells(2).Value
                Dim apellido As String = DIARIO_CREDITOSDataGridView.Rows(0).Cells(3).Value
                Dim capital As String = DIARIO_CREDITOSDataGridView.Rows(0).Cells(6).Value
                Dim pagare As String = DIARIO_CREDITOSDataGridView.Rows(0).Cells(8).Value

                Dim RowIndex As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index

                DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(operacion) & "'"

                Dim cantCuotas As String = DIARIO_CUOTASDataGridView.RowCount
                Dim deudaCorriente As String = "0"

                Dim itemCount As Integer = 0
                Dim itemCount2 As Integer = 0

                For i As Integer = 0 To DIARIO_CUOTASDataGridView.Rows.Count - 1
                    If DIARIO_CUOTASDataGridView.Rows(i).Cells(3).Value = "0" Or DIARIO_CUOTASDataGridView.Rows(i).Cells(3).Value = "0,00" Then
                        itemCount = itemCount + 1
                    Else
                        itemCount2 = itemCount2 + 1
                    End If
                Next

                DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(operacion) & "' AND [FECHA_VENCIMIENTO] < #" & fecha2.ToString("MM/dd/yyyy") & "#"

                For i As Integer = 0 To DIARIO_CUOTASDataGridView.Rows.Count - 1
                    If DIARIO_CUOTASDataGridView.Rows(i).Cells(8).Value = "0" Then
                        deudaCorriente = CDbl(deudaCorriente) + CDbl(DIARIO_CUOTASDataGridView.Rows(i).Cells(3).Value)
                    Else
                        deudaCorriente = CDbl(deudaCorriente) + CDbl(DIARIO_CUOTASDataGridView.Rows(i).Cells(8).Value)
                    End If
                Next

                Dim cuotasSaldadas As String = itemCount
                Dim cuotasRestan As String = itemCount2

                itemCount = 0

                DIARIO_CUOTASBindingSource.Filter = "[VALOR_CUOTA] >= '1' AND [FECHA_VENCIMIENTO] < #" & fecha2.ToString("MM/dd/yyyy") & "#"

                'Ordenar por fecha
                DIARIO_CUOTASDataGridView.Sort(DIARIO_CUOTASDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

                DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(RowIndex).Cells(0)
                DIARIO_CUOTASDataGridView.Rows(RowIndex).Selected = True

                Dim cuotaInteres As String = "0"
                If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(8).Value <> "0" Then
                    cuotaInteres = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(8).Value
                End If
                Dim cuotaCorriente As String = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(3).Value
                Dim vencimiento As String = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(4).Value

                DataGridView2.Rows.Add(New String() {fecha, operacion, nombre, apellido, capital, cantCuotas, pagare, cuotaCorriente, vencimiento, cuotaInteres, deudaCorriente, cuotasSaldadas, cuotasRestan})

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
            End If

        Loop

        'Exportar a excel
        Dim App_xls As Object
        Dim fila, columna As Integer
        App_xls = CreateObject("Excel.Application")
        App_xls.workbooks.add()

        App_xls.Visible = True

        Try
            For columna = 0 To DataGridView2.ColumnCount - 1
                App_xls.ActiveSheet.cells(1, columna + 1).value = DataGridView2.Columns(columna).HeaderText
            Next
            For fila = 0 To DataGridView2.Rows.Count - 1
                For columna = 0 To DataGridView2.ColumnCount - 1
                    If IsNumeric(DataGridView2.Item(columna, fila).Value) Then
                        App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = CDbl(DataGridView2.Item(columna, fila).Value)
                    Else
                        If IsDate(DataGridView2.Item(columna, fila).Value) Then
                            App_xls.ActiveSheet.Cells(fila + 2, columna + 1) = Convert.ToDateTime(DataGridView2.Item(columna, fila).Value).GetDateTimeFormats(Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
                        Else
                            App_xls.ActiveSheet.cells(fila + 2, columna + 1).Value = DataGridView2.Item(columna, fila).Value
                        End If
                    End If
                Next
            Next

        Catch ex As Exception

        End Try

        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox2.Text = "Seleccionar" Then
            MessageBox.Show("Seleccione una caja")
        Else
            Exc5()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Exc2()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListBox1.SelectedItem = "CUOTAS POR FECHA" Then
            Exc4()
        ElseIf ListBox1.SelectedItem = "REPORTE PARA ASEGURADORA" Then
            Exc6()
        ElseIf ListBox1.SelectedItem = "RESUMEN DE CUOTAS" Then
            Exc7()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            DateTimePicker3.Enabled = True
            DateTimePicker4.Enabled = True
        End If
    End Sub

End Class