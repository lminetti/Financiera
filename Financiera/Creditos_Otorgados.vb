Public Class Creditos_Otorgados

    Public Property Level As String
    Public Property Operador As String
    Dim lineasVencimiento As String = ""
    Dim lineasVencimiento1 As String = ""
    Dim CantidadCuotas As Integer = 0
    Dim Ref_Activo As String = "NO"

    Private Sub Creditos_Otorgados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)
        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)
        Me.ABM_LABORALTableAdapter.Fill(Me.ABMDataSet.ABM_LABORAL)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        TextBox30.Text = "Opera: " + Operador
        Label42.Text = DateTime.Now.ToString("dd/MM/yyyy")
        DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        TextBox2.Focus()

        If Level = "3" Then
            DIARIO_CREDITOSDataGridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            DIARIO_CREDITOSDataGridView.ReadOnly = False
            Button7.Visible = True
            DIARIO_CREDITOSDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect
        Else
            DIARIO_CREDITOSDataGridView.ReadOnly = True
            Button7.Visible = False
        End If

    End Sub

    Private Sub Creditos_Otorgados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                Button4.PerformClick()
            Case Keys.F8
                Button3.PerformClick()
            Case Keys.F9
                Button2.PerformClick()
            Case Keys.F10
                Button1.PerformClick()
            Case Keys.Escape
                Me.Close()
        End Select
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Buscar()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If DIARIO_CREDITOSDataGridView.RowCount = 0 Then
            MessageBox.Show("No hay ningún préstamo seleccionado")
            Exit Sub
        Else

            If DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(14).Value = "REFINANCIACIÓN" Then
                Ref_Activo = "SI"
            End If

            Dim Pagare = New Pagare()
            Dim Fecha As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(10).Value
            Dim Total As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(9).Value
            Dim Monto As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(9).Value
            Dim Operacion As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value

            If DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(14).Value = "REFINANCIACIÓN" Then
                Pagare.Ref_Activo = "SI"
                Pagare.UltimaOperacion = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value
            Else
                Pagare.UltimaOperacion = Operacion
            End If
            Pagare.Total = Total
            Pagare.Monto = Monto
            Pagare.DomicilioCliente = ABM_PERSONALDataGridView.Rows(0).Cells(8).Value
            Pagare.LocalidadCliente = ABM_PERSONALDataGridView.Rows(0).Cells(9).Value
            Pagare.Fecha = Fecha
            Pagare.Show()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.TopMost = False

        If DIARIO_CREDITOSDataGridView.RowCount = 0 Then
            MessageBox.Show("No hay ningún préstamo seleccionado")
            Exit Sub
        Else

            Dim Fecha As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(10).Value
            Dim Total As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(9).Value
            Dim Monto As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(7).Value
            Dim Operacion As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value
            Dim cantidadCuotas As String = DIARIO_CUOTASDataGridView.RowCount
            Dim Contrato = New Contrato()

            If DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(14).Value = "REFINANCIACIÓN" Then

                Dim nroRef As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value

                DIARIO_CREDITOSBindingSource.Filter = "[OPERACION] = '" & nroRef & "' AND [TIPO] = 'REFINANCIACIÓN'"

                Contrato.Ref_Activo = "SI"
                Total = DIARIO_CREDITOSDataGridView.Rows(0).Cells(9).Value
                Monto = DIARIO_CREDITOSDataGridView.Rows(0).Cells(7).Value

                Contrato.Pagare = Total
                Contrato.Intereses = CDbl(CDbl(Total) - CDbl(Monto).ToString("F2"))
                Contrato.Capital = CDbl(Monto).ToString("F2")
                Contrato.FechaAlta = DIARIO_CREDITOSDataGridView.Rows(0).Cells(10).Value

            End If

            Contrato.Total = Total
            Contrato.Monto = Monto
            Contrato.cantCuotas = cantidadCuotas
            Contrato.valorCuotas = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(8).Value
            Contrato.Nombre_Cliente = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(2).Value
            Contrato.Apellido_Cliente = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(3).Value
            Contrato.DNI_Cliente = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(4).Value
            Contrato.CUIL_Cliente = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(5).Value
            Contrato.Empresa = ABM_LABORALDataGridView.Rows(0).Cells(10).Value
            Contrato.Domicilio_Empresa = ABM_LABORALDataGridView.Rows(0).Cells(2).Value
            Contrato.Localidad_Empresa = ABM_LABORALDataGridView.Rows(0).Cells(3).Value
            Contrato.UltimaOperacion = Operacion

            Contrato.Show()
            Me.Close()

        End If

        Me.TopMost = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Imprimir_Vencimiento_Cuotas()
        Me.Close()
    End Sub

    Private Sub Imprimir_Vencimiento_Cuotas()
        Vencimiento_Cuotas()
        Dim printControl = New Drawing.Printing.StandardPrintController
        PrintDocument1.PrintController = printControl
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Vencimiento_Cuotas()

        If DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(14).Value = "REFINANCIACIÓN" Then
            Ref_Activo = "SI"
        End If

        lineasVencimiento1 &= "LISTADO DE VENCIMIENTO DE CUOTAS"
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "CLIENTE: " & DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(2).Value & " " & DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(3).Value
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "CUENTA: " & DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(1).Value
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "OPERACIÓN: " & CDbl(DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value).ToString("0000")
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "CAPITAL: " & CDbl(DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(7).Value).ToString("F2")
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "DETALLE DE CUOTAS"
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine

        If Ref_Activo = "SI" Then
            Dim OPREF As String = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value
            DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & OPREF & "' AND [TIPO] = 'REFINANCIACIÓN'"
        Else
            DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & TextBox1.Text & "' AND [TIPO] = 'CRÉDITO'"
        End If

        DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
        DIARIO_CUOTASDataGridView.Rows(0).Selected = True

        Do
            lineasVencimiento &= "- Cuota: " & DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(3).Value & "   -   Vencimiento: " & DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(5).Value & "   -   Importe: $" & DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(11).Value
            lineasVencimiento &= Environment.NewLine
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

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim StartIndex As Integer = 0
        Static currentChar As Integer

        Dim textfont As Font = New Font("Segoe UI", 11, FontStyle.Regular)

        Dim h, w As Integer
        Dim left, top As Integer
        With PrintDocument1.DefaultPageSettings
            h = 0
            w = 0
            left = 60
            top = 60
        End With

        Dim lines As Integer = CInt(Math.Round(h / 1))
        Dim b As New Rectangle(left, top, w, h)
        Dim format As StringFormat
        format = New StringFormat(StringFormatFlags.LineLimit)
        Dim line, chars As Integer

        'Listado
        e.Graphics.MeasureString(Mid(lineasVencimiento, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasVencimiento.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)
        e.Graphics.MeasureString(Mid(lineasVencimiento1, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasVencimiento1.Substring(currentChar, chars), New Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, b, format)

        e.HasMorePages = False

        Me.Close()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Buscar()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Buscar()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Level = "3" Then

            Me.TopMost = False

            Dim result As Integer = MessageBox.Show("¿Cambiar fecha?", "Fecha", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
            ElseIf result = DialogResult.Yes Then

                'Borrar cuotas otorgadas
                DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value & "'"
                Do
                    If DIARIO_CUOTASDataGridView.RowCount = 0 Then
                        Exit Do
                    Else
                        Dim currentRow As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index
                        ' Selecciona la siguiente fila
                        Dim counter2 As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index
                        Dim nextRow As DataGridViewRow
                        nextRow = DIARIO_CUOTASDataGridView.Rows(counter2)
                        DIARIO_CUOTASDataGridView.CurrentCell = nextRow.Cells(0)
                        nextRow.Selected = True

                        DIARIO_CUOTASBindingSource.RemoveCurrent()

                        If DIARIO_CUOTASDataGridView.RowCount = 0 Then
                            Exit Do
                        End If

                    End If
                Loop

                'Cambiar fecha en crédito
                Dim nueva_fecha As String = InputBox("Ingrese una fecha en este formato: dd/MM/yyyy", "Fecha", "")
                DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(9).Value = nueva_fecha

                DIARIO_CREDITOSBindingSource.EndEdit()
                DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)
                DIARIO_CUOTASBindingSource.EndEdit()
                DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)

                'Asignar nuevas cuotas
                Dim cantCuotas As String = CStr(CantidadCuotas)
                Dim counter As Integer = 1
                Dim fecha As Date = CDate(nueva_fecha).ToString("dd/MM/yyyy")
                Dim dia As Integer = fecha.Day
                Dim mes As Integer = 0
                Dim año As Integer = 0
                Dim fecha_seleccionada As String = InputBox("¿Qué día del mes va a vencer la cuota?", "Vencimiento de cuota", "")
                If fecha_seleccionada = "" Then
                    If dia >= CInt(DIA_CAMBIO_MESTextBox.Text) Then
                        If DIA_PRIMERA_CUOTATextBox.Text = "" Or DIA_CAMBIO_MESTextBox.Text = "" Then
                        Else
                            mes = fecha.Month
                            año = fecha.Year
                            If dia >= CInt(DIA_PRIMERA_CUOTATextBox.Text) Then
                                fecha = DIA_PRIMERA_CUOTATextBox.Text & "/" & mes & "/" & año
                                fecha = fecha.AddMonths(1)
                            Else
                            End If
                        End If
                    End If
                Else
                    mes = fecha.Month
                    año = fecha.Year
                    fecha = fecha_seleccionada & "/" & mes & "/" & año
                End If

                Do
                    'fecha = fecha.AddDays(30)
                    mes = mes + 1
                    If mes > 12 Then
                        año = año + 1
                        mes = 1
                    End If
                    fecha = fecha_seleccionada & "/" & mes & "/" & año
                    Dim myCulture As System.Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
                    Dim dayOfWeek As DayOfWeek = myCulture.Calendar.GetDayOfWeek(fecha)
                    Dim Dia_Hoy As String = myCulture.DateTimeFormat.GetDayName(dayOfWeek)

                    If Dia_Hoy.ToString = "sábado" Then
                        fecha = fecha.AddDays(2)
                        dayOfWeek = myCulture.Calendar.GetDayOfWeek(fecha)
                        Dia_Hoy = myCulture.DateTimeFormat.GetDayName(dayOfWeek)
                    ElseIf Dia_Hoy.ToString = "domingo" Then
                        fecha = fecha.AddDays(1)
                        dayOfWeek = myCulture.Calendar.GetDayOfWeek(fecha)
                        Dia_Hoy = myCulture.DateTimeFormat.GetDayName(dayOfWeek)
                    End If

                    Dim newRow2 As DataRowView = DirectCast(DIARIO_CUOTASBindingSource.AddNew(), DataRowView)

                    newRow2("OPERACION") = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value
                    newRow2("CUENTA") = ABM_PERSONALDataGridView.Rows(0).Cells(1).Value
                    newRow2("CUOTA") = counter
                    newRow2("VALOR_CUOTA") = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(8).Value
                    newRow2("PAGARE") = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(9).Value
                    newRow2("FECHA_VENCIMIENTO") = fecha.ToString("dd/MM/yyyy")
                    newRow2("PAGADO") = "0"
                    newRow2("FECHA_PAGO") = ""
                    newRow2("DIAS_MORA") = "0"
                    newRow2("PUNITORIOS") = "0"
                    newRow2("CUOTA_INTERES") = "0"
                    newRow2("NOMBRE") = ABM_PERSONALDataGridView.Rows(0).Cells(2).Value
                    newRow2("APELLIDO") = ABM_PERSONALDataGridView.Rows(0).Cells(3).Value
                    newRow2("TELEFONO1") = ABM_PERSONALDataGridView.Rows(0).Cells(11).Value
                    newRow2("TELEFONO2") = ABM_PERSONALDataGridView.Rows(0).Cells(12).Value
                    newRow2("DIRECCION") = ABM_PERSONALDataGridView.Rows(0).Cells(8).Value

                    DIARIO_CUOTASBindingSource.EndEdit()
                    DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)

                    If counter = cantCuotas Then
                        Exit Do
                    End If

                    counter = counter + 1

                Loop

                MessageBox.Show("Fecha de alta cambiada. Vamos a imprimir nuevo pagaré y nuevo mutuo.")
                Button3.PerformClick()
                Button2.PerformClick()
                Dim result2 As Integer = MessageBox.Show("¿Desea imprimir el detalle de cuotas?", "Detalle de cuotas", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    'Nada
                ElseIf result = DialogResult.Yes Then
                    Button4.PerformClick()
                End If

                Me.TopMost = False

            End If
        Else
            MessageBox.Show("Sólo nivel 3 puede cambiar fechas")
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If Level = "3" Then
            Dim result As Integer = MessageBox.Show("¿Dar de baja crédito?", "Baja", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
            ElseIf result = DialogResult.Yes Then

                'Borrar cuotas
                DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value & "'"
                Do
                    If DIARIO_CUOTASDataGridView.RowCount = 0 Then
                        Exit Do
                    Else
                        Dim currentRow As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index
                        ' Selecciona la siguiente fila
                        Dim counter As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index
                        Dim nextRow As DataGridViewRow
                        nextRow = DIARIO_CUOTASDataGridView.Rows(counter)
                        DIARIO_CUOTASDataGridView.CurrentCell = nextRow.Cells(0)
                        nextRow.Selected = True

                        DIARIO_CUOTASBindingSource.RemoveCurrent()

                        If DIARIO_CUOTASDataGridView.RowCount = 0 Then
                            Exit Do
                        End If

                    End If
                Loop

                'Dar de baja credito
                DIARIO_CREDITOSBindingSource.RemoveCurrent()

                DIARIO_CREDITOSBindingSource.EndEdit()
                DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)
                DIARIO_CUOTASBindingSource.EndEdit()
                DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)

                MessageBox.Show("Crédito dado de baja")
            End If
        Else
            MessageBox.Show("Sólo nivel 3 puede dar de baja créditos")
        End If

    End Sub

    Private Sub DIARIO_CREDITOSDataGridView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DIARIO_CREDITOSDataGridView.CellEnter
        If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
            ABM_LABORALBindingSource.Filter = "[CUENTA] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(1).Value) & "'"
            ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(1).Value) & "'"
            DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(0).Value) & "'"
            CantidadCuotas = DIARIO_CUOTASDataGridView.RowCount
            TextBox1.Text = "Cantidad de cuotas: " & CantidadCuotas & "."
        Else
            TextBox1.Text = "Cantidad de cuotas: 0."
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        DIARIO_CREDITOSBindingSource.EndEdit()
        DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)
        MessageBox.Show("Cambios guardados!")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Buscar()
    End Sub

    Private Sub Buscar()
        If ComboBox1.Text = "ESTADO" Then
            If TextBox2.TextLength > 0 Then
                If CheckBox1.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'CRÉDITO' Or [DNI] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'CRÉDITO' Or [CUIL] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'CRÉDITO' Or [NOMBRE] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'CRÉDITO' Or [APELLIDO] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'CRÉDITO'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                ElseIf CheckBox2.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'REFINANCIACIÓN' Or [DNI] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'REFINANCIACIÓN' Or [CUIL] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'REFINANCIACIÓN' Or [NOMBRE] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'REFINANCIACIÓN' Or [APELLIDO] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'REFINANCIACIÓN'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                End If
                If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                    ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(1).Value) & "'"
                    DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(0).Value) & "'"
                End If
            Else
                If CheckBox1.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'CRÉDITO'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                ElseIf CheckBox2.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [TIPO] = 'REFINANCIACIÓN'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                End If
                If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                    ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(1).Value) & "'"
                    DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(0).Value) & "'"
                End If
            End If
        ElseIf ComboBox1.Text = "EN CURSO" Then
            If TextBox2.TextLength > 0 Then
                If CheckBox1.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'CRÉDITO' Or [DNI] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'CRÉDITO' Or [CUIL] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'CRÉDITO' Or [NOMBRE] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'CRÉDITO' Or [APELLIDO] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'CRÉDITO'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                ElseIf CheckBox2.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'REFINANCIACIÓN' Or [DNI] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'REFINANCIACIÓN' Or [CUIL] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'REFINANCIACIÓN' Or [NOMBRE] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'REFINANCIACIÓN' Or [APELLIDO] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'REFINANCIACIÓN'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                End If
                If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                    ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(1).Value) & "'"
                    DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(0).Value) & "'"
                End If
            Else
                If CheckBox1.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'CRÉDITO'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                ElseIf CheckBox2.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] = 'EN CURSO' AND [TIPO] = 'REFINANCIACIÓN'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                End If
                If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                    ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(1).Value) & "'"
                    DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(0).Value) & "'"
                End If
            End If
        ElseIf ComboBox1.Text = "CANCELADO" Then
            If TextBox2.TextLength > 0 Then
                If CheckBox1.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'CRÉDITO' Or [DNI] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'CRÉDITO' Or [CUIL] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'CRÉDITO' Or [NOMBRE] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'CRÉDITO' Or [APELLIDO] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'CRÉDITO'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                ElseIf CheckBox2.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'REFINANCIACIÓN' Or [DNI] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'REFINANCIACIÓN' Or [CUIL] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'REFINANCIACIÓN' Or [NOMBRE] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'REFINANCIACIÓN' Or [APELLIDO] = '" & TextBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'REFINANCIACIÓN'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                End If
                If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                    ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(1).Value) & "'"
                    DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(0).Value) & "'"
                End If
            Else
                If CheckBox1.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'CRÉDITO'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                ElseIf CheckBox2.CheckState = CheckState.Checked Then
                    DIARIO_CREDITOSBindingSource.Filter = "[FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ESTADO] LIKE 'CANCELADO' AND [TIPO] = 'REFINANCIACIÓN'"
                    DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                End If
                If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                    ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(1).Value) & "'"
                    DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(DIARIO_CREDITOSDataGridView.Rows(0).Cells(0).Value) & "'"
                End If
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            CheckBox2.CheckState = CheckState.Unchecked
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            CheckBox2.CheckState = CheckState.Checked
        End If
        Buscar()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            CheckBox1.CheckState = CheckState.Unchecked
        ElseIf CheckBox2.CheckState = CheckState.Unchecked Then
            CheckBox1.CheckState = CheckState.Checked
        End If
        Buscar()
    End Sub
End Class