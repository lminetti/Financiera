Imports System.Net.Mail
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Creditos_Alta
    Public Property Operador As String
    Public Property UltimaOperacion As String
    Public Property Level As String
    Dim lastOperacion As String = ""
    Dim impresion As Integer = 0
    Dim lineasVencimiento As String = ""
    Dim lineasVencimiento1 As String = ""
    Dim total_seguro As String = "0"
    Dim total_facturado As String = "0"
    Dim Ref_Activo As String = "NO"
    Dim Op As String
    Dim fecha_ref As String = ""
    Dim pagare As String = ""
    Dim intereses As String = ""
    Dim capital As String = ""

    Private Sub Creditos_Alta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)
        Me.ABM_LABORALTableAdapter.Fill(Me.ABMDataSet.ABM_LABORAL)
        Me.OPERADORESTableAdapter.Fill(Me.AJUSTESDataSet.OPERADORES)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        Me.COEFICIENTESTableAdapter.Fill(Me.DATABASEDataSet.COEFICIENTES)
        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        TextBox30.Text = "Opera: " + Operador
        Label42.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox2.Select()

        DateTimePicker1.Value = DateTime.Now.ToString("dd/MM/yyyy")
        lastOperacion = AJUSTESDataGridView.Rows(0).Cells(11).Value

        'Obtener número de operacion
        TextBox1.Text = lastOperacion

    End Sub

    Private Sub Creditos_Alta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Button7.PerformClick()
            Case Keys.F8
                If Button3.Enabled = True Then
                    Button3.PerformClick()
                Else
                    Exit Sub
                End If
            Case Keys.F9
                If Button2.Enabled = True Then
                    Button2.PerformClick()
                Else
                    Exit Sub
                End If
            Case Keys.Escape
                If impresion = 3 Or impresion = 0 Then
                    Me.Close()
                Else
                    MessageBox.Show("No está impreso el contrato o el pagaré.")
                    Exit Sub
                End If
        End Select
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength > 0 Then
            ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' Or [DNI] = '" & TextBox2.Text & "' Or [CUIL] = '" & TextBox2.Text & "'"
            If ABM_PERSONALDataGridView.RowCount > 0 Then
                ABM_LABORALBindingSource.Filter = "[CUENTA] = '" & ABM_PERSONALDataGridView.Rows(0).Cells(1).Value & "'"
                TextBox3.Text = ABM_PERSONALDataGridView.Rows(0).Cells(2).Value
                TextBox4.Text = ABM_PERSONALDataGridView.Rows(0).Cells(3).Value
                TextBox5.Text = ABM_PERSONALDataGridView.Rows(0).Cells(6).Value
                If ABM_PERSONALDataGridView.Rows(0).Cells(15).Value = "NEUTRAL" Then
                    TextBox10.Text = "NEUTRAL"
                    TextBox10.ForeColor = Color.Orange
                ElseIf ABM_PERSONALDataGridView.Rows(0).Cells(15).Value = "NEGATIVA" Then
                    TextBox10.Text = "NEGATIVA"
                    TextBox10.ForeColor = Color.Red
                ElseIf ABM_PERSONALDataGridView.Rows(0).Cells(15).Value = "POSITIVA" Then
                    TextBox10.Text = "POSITIVA"
                    TextBox10.ForeColor = Color.Green
                ElseIf ABM_PERSONALDataGridView.Rows(0).Cells(15).Value = "" Then
                    TextBox10.Text = ""
                    TextBox10.ForeColor = Color.Green
                End If
            ElseIf ABM_PERSONALDataGridView.RowCount = 0 Then
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
            End If
        Else
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox6.Focus()
        End Select
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button5.PerformClick()
        End Select
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox8.Focus()
        End Select
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Dim result As Integer = MessageBox.Show("¿Dar de alta el crédito?", "Alta", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    TextBox6.Focus()
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    Button1.PerformClick()
                End If
        End Select
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PrimerCalculo()
    End Sub

    Private Sub PrimerCalculo()
        DataGridView1.Rows.Clear()

        If Ref_Activo = "SI" Then
            COEFICIENTESBindingSource.Filter = "[CALIFICACION] = '" & TextBox10.Text & "' AND [TIPO] = 'REF'"
        Else
            COEFICIENTESBindingSource.Filter = "[CALIFICACION] = '" & TextBox10.Text & "' AND [TIPO] = 'CREDITO'"
        End If

        COEFICIENTESDataGridView.Sort(COEFICIENTESDataGridView.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

        If COEFICIENTESDataGridView.RowCount > 0 Then
            'Lleno la datagridview con los cálculos
            COEFICIENTESDataGridView.CurrentCell = COEFICIENTESDataGridView.Rows(0).Cells(0)
            COEFICIENTESDataGridView.Rows(0).Selected = True
            Do
                Dim coeficiente As String = COEFICIENTESDataGridView.Rows(COEFICIENTESDataGridView.CurrentRow.Index).Cells(3).Value
                Dim valorcuota As String = "0"
                Dim montoFinal As String = "0"
                Dim intereses As String = ""
                Dim cuota As String = COEFICIENTESDataGridView.Rows(COEFICIENTESDataGridView.CurrentRow.Index).Cells(1).Value
                Dim seguro1 As String = SEGURO_VALOR1TextBox.Text
                Dim seguro2 As String = SEGURO_VALOR2TextBox.Text

                If SEGURO_VALOR1TextBox.TextLength > 0 And SEGURO_VALOR2TextBox.TextLength > 0 Then
                    montoFinal = CDbl(CDbl(TextBox6.Text) * CDbl(coeficiente)).ToString("F2")
                    total_seguro = CDbl((CDbl(montoFinal) / CDbl(seguro2)) * CDbl(seguro1)).ToString("F2")
                    total_seguro = CDbl(total_seguro) * CDbl(cuota)
                    montoFinal = CDbl(CDbl(montoFinal) + CDbl(total_seguro)).ToString("F2")
                Else
                    montoFinal = CDbl(CDbl(TextBox6.Text) * CDbl(coeficiente)).ToString("F2")
                End If

                intereses = CDbl(CDbl(montoFinal) - CDbl(TextBox6.Text)).ToString("F2")
                intereses = CDbl(CDbl(intereses) * 1.21).ToString("F2")
                montoFinal = CDbl(CDbl(intereses) + CDbl(TextBox6.Text)).ToString("F2")
                valorcuota = CDbl(CDbl(montoFinal) / CDbl(cuota)).ToString("F2")

                DataGridView1.Rows.Add(New String() {cuota, valorcuota, montoFinal})

                ' Selecciona la siguiente fila
                Dim counter As Integer = COEFICIENTESDataGridView.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = COEFICIENTESDataGridView.RowCount Then
                    Exit Do
                Else
                    nextRow = COEFICIENTESDataGridView.Rows(counter)
                End If
                COEFICIENTESDataGridView.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
            Loop
        Else
            MessageBox.Show("No existen coeficientes para la calificación asignada")
        End If

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.TopMost = False
        Button1.Enabled = False

        If TextBox5.Text = "" Then
            MessageBox.Show("No hay ninguna cuenta seleccionada")
        Else

            If Ref_Activo = "SI" Then
                'Si es REFINANCIACIÓN cancela crédito y cuotas
                fecha_ref = DIARIO_CREDITOSDataGridView.Rows(0).Cells(10).Value
                intereses = CDbl(CDbl(DIARIO_CREDITOSDataGridView.Rows(0).Cells(9).Value) - CDbl(DIARIO_CREDITOSDataGridView.Rows(0).Cells(7).Value)).ToString("F2")
                pagare = CDbl(DIARIO_CREDITOSDataGridView.Rows(0).Cells(11).Value).ToString("F2")
                capital = CDbl(DIARIO_CREDITOSDataGridView.Rows(0).Cells(7).Value).ToString("F2")

                DIARIO_CREDITOSDataGridView.Rows(0).Cells(13).Value = "CANCELADO REF. " & NUMERO_OPERACION_REFTextBox.Text
                DIARIO_CREDITOSDataGridView.Rows(0).Cells(11).Value = "0"

                DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
                DIARIO_CUOTASDataGridView.Rows(0).Selected = True

                Do
                    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(6).Value = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(11).Value
                    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(11).Value = "0,00"
                    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(7).Value = DateTime.Now.ToString("dd/MM/yyyy")
                    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(8).Value = "0"
                    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(9).Value = "0,00"
                    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(10).Value = "0,00"

                    ' Selecciona la siguiente fila
                    Dim counter2 As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index + 1
                    Dim nextRow As DataGridViewRow
                    If counter2 = DIARIO_CUOTASDataGridView.RowCount Then
                        Exit Do
                    Else
                        nextRow = DIARIO_CUOTASDataGridView.Rows(counter2)
                    End If
                    DIARIO_CUOTASDataGridView.CurrentCell = nextRow.Cells(0)
                    nextRow.Selected = True
                Loop

                DIARIO_CREDITOSBindingSource.EndEdit()
                DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)
                DIARIO_CUOTASBindingSource.EndEdit()
                DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)

            End If

            'Si no es simulación, chequear si el capital + total_facturado va a exceder el límite de facturación
            Dim fecha1 As Date = DateTime.Now.ToString("dd/MM/yyyy")
            fecha1 = "1/" & fecha1.Month & "/" & fecha1.Year
            Dim fecha2 As DateTime = New DateTime(fecha1.Year, fecha1.Month, 1)
            fecha2 = fecha2.AddMonths(1).AddDays(-1)

            DIARIO_CREDITOSBindingSource.Filter = "[SIMULACION] = 'NO' AND [FECHA] >= #" & fecha1.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & fecha2.ToString("MM/dd/yyyy") & "#"

            If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                Dim suma As Double = 0
                For i As Double = 0 To DIARIO_CREDITOSDataGridView.Rows.Count() - 1 Step +1
                    suma = suma + DIARIO_CREDITOSDataGridView.Rows(i).Cells(7).Value
                Next
                total_facturado = suma.ToString()
            Else
                total_facturado = "0"
            End If

            Dim agrega As String = "0"
            agrega = CDbl(total_facturado) + CDbl(TextBox6.Text)

            If CheckBox1.CheckState = CheckState.Unchecked Then
                If CDbl(agrega) > CDbl(LIMITADOR_BTextBox.Text) Then
                    Dim limite As Integer = MessageBox.Show("Con esta operación, supera el límite de facturación mensual. ¿Continuar como simulación?", "Facturación", MessageBoxButtons.YesNo)
                    If limite = DialogResult.No Then
                        Exit Sub
                    ElseIf limite = DialogResult.Yes Then
                        CheckBox1.CheckState = CheckState.Checked
                    End If
                End If
            End If

            DIARIO_CREDITOSBindingSource.Filter = "[Id] > 0"

            'Ingresar datos a Diario de créditos
            Dim newRow As DataRowView = DirectCast(DIARIO_CREDITOSBindingSource.AddNew(), DataRowView)

            If Ref_Activo = "SI" Then
                newRow("OPERACION") = NUMERO_OPERACION_REFTextBox.Text
                newRow("TIPO") = "REFINANCIACIÓN"
            Else
                newRow("OPERACION") = TextBox1.Text
                newRow("TIPO") = "CRÉDITO"
            End If

            newRow("CUENTA") = ABM_PERSONALDataGridView.Rows(0).Cells(1).Value
            newRow("NOMBRE") = ABM_PERSONALDataGridView.Rows(0).Cells(2).Value
            newRow("APELLIDO") = ABM_PERSONALDataGridView.Rows(0).Cells(3).Value
            newRow("CUIL") = ABM_PERSONALDataGridView.Rows(0).Cells(7).Value
            newRow("DNI") = ABM_PERSONALDataGridView.Rows(0).Cells(6).Value
            newRow("CAPITAL") = TextBox6.Text
            newRow("PAGARE") = TextBox9.Text
            newRow("CUOTA") = TextBox8.Text
            newRow("FECHA") = DateTimePicker1.Value.ToString("dd/MM/yyyy")
            newRow("DEUDA") = TextBox9.Text
            newRow("OPERADOR") = Operador
            newRow("FECHA_NACIMIENTO") = ABM_PERSONALDataGridView.Rows(0).Cells(4).Value
            newRow("VALOR_SEGURO") = total_seguro
            If CheckBox1.CheckState = CheckState.Checked Then
                newRow("SIMULACION") = "SI"
            ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
                newRow("SIMULACION") = "NO"
            End If
            newRow("ESTADO") = "EN CURSO"

            'Calcular IVA
            Dim IVA As Double = 0.00
            IVA = CDbl(CDbl(TextBox9.Text) - (CDbl(TextBox6.Text) * CDbl(TextBox11.Text))).ToString("F2")
            newRow("IVA") = IVA.ToString("F2")

            newRow("DIAS_MORA") = "0"

            DIARIO_CREDITOSBindingSource.EndEdit()
            DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)

            'Ingresar datos a Diario de cuotas
            Dim mes As Integer = 0
            Dim año As Integer = 0
            Dim fecha_seleccionada As String = InputBox("¿Qué día del mes va a vencer la cuota?", "Vencimiento de cuota", "")
            Dim cantCuotas As String = TextBox7.Text
            Dim counter As Integer = 1
            Dim fecha As Date = DateTimePicker1.Value.ToString("dd/MM/yyyy")
            Dim dia As Integer = fecha.Day

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
                If dia >= CInt(DIA_CAMBIO_MESTextBox.Text) Then
                    If DIA_PRIMERA_CUOTATextBox.Text = "" Or DIA_CAMBIO_MESTextBox.Text = "" Then
                        mes = fecha.Month
                        año = fecha.Year
                        fecha = fecha_seleccionada & "/" & mes & "/" & año
                    Else
                        mes = fecha.Month
                        año = fecha.Year
                        mes = mes + 1
                        If dia >= CInt(DIA_PRIMERA_CUOTATextBox.Text) Then
                            fecha = DIA_PRIMERA_CUOTATextBox.Text & "/" & mes & "/" & año
                        Else
                        End If
                    End If
                Else
                    mes = fecha.Month
                    año = fecha.Year
                    mes = mes
                    If dia >= CInt(DIA_PRIMERA_CUOTATextBox.Text) Then
                        fecha = DIA_PRIMERA_CUOTATextBox.Text & "/" & mes & "/" & año
                    Else
                    End If
                End If
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

                If Dia_Hoy.ToString = "domingo" Then
                    fecha = fecha.AddDays(1)
                    dayOfWeek = myCulture.Calendar.GetDayOfWeek(fecha)
                    Dia_Hoy = myCulture.DateTimeFormat.GetDayName(dayOfWeek)
                End If

                'If Dia_Hoy.ToString = "sábado" Then
                '    fecha = fecha.AddDays(2)
                '    dayOfWeek = myCulture.Calendar.GetDayOfWeek(fecha)
                '    Dia_Hoy = myCulture.DateTimeFormat.GetDayName(dayOfWeek)
                'ElseIf Dia_Hoy.ToString = "domingo" Then
                '    fecha = fecha.AddDays(1)
                '    dayOfWeek = myCulture.Calendar.GetDayOfWeek(fecha)
                '    Dia_Hoy = myCulture.DateTimeFormat.GetDayName(dayOfWeek)
                'End If

                Dim newRow2 As DataRowView = DirectCast(DIARIO_CUOTASBindingSource.AddNew(), DataRowView)

                If Ref_Activo = "SI" Then
                    newRow2("OPERACION") = NUMERO_OPERACION_REFTextBox.Text
                    newRow2("TIPO") = "REFINANCIACIÓN"
                Else
                    newRow2("OPERACION") = TextBox1.Text
                    newRow2("TIPO") = "CRÉDITO"
                End If

                newRow2("CUENTA") = ABM_PERSONALDataGridView.Rows(0).Cells(1).Value
                newRow2("CUOTA") = CInt(counter.ToString("00"))
                newRow2("VALOR_CUOTA") = TextBox8.Text
                newRow2("PAGARE") = TextBox9.Text
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
                If CheckBox1.CheckState = CheckState.Checked Then
                    newRow2("SIMULACION") = "SI"
                ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
                    newRow2("SIMULACION") = "NO"
                End If

                DIARIO_CUOTASBindingSource.EndEdit()
                DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)

                If counter = cantCuotas Then
                    Exit Do
                End If

                counter = counter + 1

            Loop

            impresion = 1

            If Ref_Activo = "SI" Then
            Else

                'Ingresar datos contables
                OPERADORESBindingSource.Filter = "[NOMBRE] = '" & Operador & "'"

                Dim CajaAsignada As String = "NINGUNA"
                If IsDBNull(OPERADORESDataGridView.Rows(0).Cells(5).Value) Then
                    MessageBox.Show("El operador no tiene ninguna caja asignada")
                Else
                    CajaAsignada = OPERADORESDataGridView.Rows(0).Cells(5).Value
                End If

                Dim Valor As Integer = 0
                Dim SaldoAnterior As String = ""

                CONTABLEBindingSource.Filter = "[CAJA] = '" & CajaAsignada & "'"

                CONTABLEDataGridView.Sort(CONTABLEDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

                If CONTABLEDataGridView.RowCount > 0 Then
                    Valor = CONTABLEDataGridView.RowCount - 1
                    SaldoAnterior = CONTABLEDataGridView.Rows(Valor).Cells(6).Value
                End If
                Dim Debe As String = "0"
                Dim Haber As String = TextBox6.Text
                Dim Saldo As String = "0"
                If CONTABLEDataGridView.RowCount > 0 Then
                    Debe = "0"
                    Saldo = CDbl(SaldoAnterior) - CDbl(Haber)
                Else
                    Debe = "0"
                    Saldo = "-" & Haber
                End If

                Dim newRow3 As DataRowView = DirectCast(CONTABLEBindingSource.AddNew(), DataRowView)

                newRow3("CODIGO") = "0"
                newRow3("CAJA") = CajaAsignada
                newRow3("ASIENTO") = "PRESTAMO Op: " & TextBox1.Text
                newRow3("DEBE") = Debe
                newRow3("HABER") = Haber
                newRow3("SALDO") = Saldo
                newRow3("OPERADOR") = Operador
                newRow3("FECHA") = Label42.Text

                CONTABLEBindingSource.EndEdit()
                CONTABLETableAdapter.Update(DATABASEDataSet.CONTABLE)

            End If

            If Ref_Activo = "SI" Then
                NUMERO_OPERACION_REFTextBox.Text = CInt(NUMERO_OPERACION_REFTextBox.Text) + 1
            Else
                AJUSTESDataGridView.Rows(0).Cells(11).Value = CDbl(TextBox1.Text) + 1
            End If
            AJUSTESBindingSource.EndEdit()
            AJUSTESTableAdapter.Update(AJUSTESDataSet.AJUSTES)

            If Ref_Activo = "SI" Then
                MessageBox.Show("¡Refinanciación exitosa!")
            Else
                MessageBox.Show("¡Alta de crédito exitosa!")
            End If

            'Enviar mail a aseguradora

            'If MAIL_FINANCIERATextBox.Text = "" Then
            '    'Envío deshabilitado
            'Else
            '    'Calcular edad
            '    Dim edad As Integer
            '    Dim nacimiento As Date = CDate(ABM_PERSONALDataGridView.Rows(0).Cells(4).Value)
            '    edad = Today.Year - nacimiento.Year
            '    If (nacimiento > Today.AddYears(-edad)) Then edad -= 1

            '    Dim cuerpo As String
            '    cuerpo = "Informe de alta de crédito, operación N°: " & TextBox1.Text & Environment.NewLine & Environment.NewLine & "NOMBRE: " & ABM_PERSONALDataGridView.Rows(0).Cells(2).Value & Environment.NewLine & "APELLIDO: " & ABM_PERSONALDataGridView.Rows(0).Cells(3).Value & Environment.NewLine & "EDAD: " & edad & Environment.NewLine & "DNI: " & ABM_PERSONALDataGridView.Rows(0).Cells(6).Value & Environment.NewLine & "CUIT/CUIL: " & ABM_PERSONALDataGridView.Rows(0).Cells(7).Value & Environment.NewLine & "FECHA DE ALTA: " & DateTimePicker1.Value.ToString("dd/MM/yyyy") & Environment.NewLine & "VALOR PAGARÉ: " & TextBox9.Text & Environment.NewLine & Environment.NewLine & "Informe enviado desde Crediworld."

            '    Try
            '        Dim Smtp_Server As New SmtpClient
            '        Dim e_mail As New MailMessage()
            '        Smtp_Server.UseDefaultCredentials = False
            '        Smtp_Server.Credentials = New Net.NetworkCredential(MAIL_FINANCIERATextBox.Text, PASS_MAIL_FINANCIERATextBox.Text)
            '        Smtp_Server.Port = 25
            '        Smtp_Server.EnableSsl = True
            '        Smtp_Server.Host = "smtp.dreamhost.com"

            '        e_mail = New MailMessage()
            '        e_mail.From = New MailAddress(MAIL_FINANCIERATextBox.Text)
            '        e_mail.To.Add(MAIL_SEGUROTextBox.Text & "," & MAIL_FINANCIERATextBox.Text)
            '        e_mail.Subject = "Reporte de crédito, operación N°:  " & TextBox1.Text
            '        e_mail.IsBodyHtml = False
            '        e_mail.Body = cuerpo
            '        Smtp_Server.Send(e_mail)
            '        MsgBox("Reporte electrónico enviado al Seguro.")

            '    Catch error_t As Exception
            '        MsgBox("Error al enviar reporte electrónico al Seguro.")
            '    End Try
            'End If

            Button3.Enabled = True
            Dim result2 As Integer = MessageBox.Show("¿Imprimir detalle de cuotas?", "Cuotas", MessageBoxButtons.YesNo)
            If result2 = DialogResult.No Then
            ElseIf result2 = DialogResult.Yes Then
                Imprimir_Vencimiento_Cuotas()
            End If
            Dim result As Integer = MessageBox.Show("¿Imprimir pagaré?", "Pagaré", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                Button3.PerformClick()
            End If

        End If

        Me.TopMost = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        impresion = 2
        Dim Pagare = New Pagare()
        If Ref_Activo = "SI" Then
            Pagare.Ref_Activo = "SI"
            Pagare.UltimaOperacion = CInt(NUMERO_OPERACION_REFTextBox.Text) - 1
        Else
            Pagare.UltimaOperacion = TextBox1.Text
        End If
        Pagare.Total = TextBox9.Text
        Pagare.Monto = TextBox9.Text
        Pagare.DomicilioCliente = ABM_PERSONALDataGridView.Rows(0).Cells(8).Value
        Pagare.LocalidadCliente = ABM_PERSONALDataGridView.Rows(0).Cells(9).Value
        Pagare.Fecha = DateTimePicker1.Value.ToString("dd/MM/yyyy")
        Pagare.Show()
        Button2.Enabled = True
        Dim result As Integer = MessageBox.Show("¿Imprimir contrato?", "Contrato", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        impresion = 3
        Dim Contrato = New Contrato()

        If Ref_Activo = "SI" Then

            Contrato.Ref_Activo = "SI"
            Contrato.Pagare = pagare
            Contrato.Intereses = intereses
            Contrato.Capital = capital
            Contrato.FechaAlta = fecha_ref

        End If

        Contrato.Total = TextBox9.Text
        Contrato.Monto = TextBox6.Text
        Contrato.cantCuotas = TextBox7.Text
        Contrato.valorCuotas = TextBox8.Text
        Contrato.Nombre_Cliente = ABM_PERSONALDataGridView.Rows(0).Cells(2).Value
        Contrato.Apellido_Cliente = ABM_PERSONALDataGridView.Rows(0).Cells(3).Value
        Contrato.DNI_Cliente = ABM_PERSONALDataGridView.Rows(0).Cells(6).Value
        Contrato.CUIL_Cliente = ABM_PERSONALDataGridView.Rows(0).Cells(7).Value
        Contrato.Empresa = ABM_LABORALDataGridView.Rows(0).Cells(10).Value
        Contrato.Domicilio_Empresa = ABM_LABORALDataGridView.Rows(0).Cells(2).Value
        Contrato.Localidad_Empresa = ABM_LABORALDataGridView.Rows(0).Cells(3).Value
        Contrato.UltimaOperacion = TextBox1.Text
        Contrato.Show()
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

        lineasVencimiento1 &= "LISTADO DE VENCIMIENTO DE CUOTAS"
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "CLIENTE: " & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(2).Value & " " & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(3).Value
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "CUENTA: " & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "OPERACIÓN: " & CDbl(TextBox1.Text).ToString("0000")
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "CAPITAL: " & CDbl(TextBox6.Text).ToString("F2")
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= "DETALLE DE CUOTAS"
        lineasVencimiento &= Environment.NewLine
        lineasVencimiento &= Environment.NewLine

        If Ref_Activo = "SI" Then
            Dim OPREF As String = CInt(NUMERO_OPERACION_REFTextBox.Text) - CInt(1)
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

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If Ref_Activo = "SI" Then
            COEFICIENTESBindingSource.Filter = "[CUOTAS] = '" & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value & "' AND [CALIFICACION] = '" & TextBox10.Text & "' AND [TIPO] = 'REF'"
        Else
            COEFICIENTESBindingSource.Filter = "[CUOTAS] = '" & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value & "' AND [CALIFICACION] = '" & TextBox10.Text & "' AND [TIPO] = 'CREDITO'"
        End If

        TextBox7.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        If COEFICIENTESDataGridView.RowCount > 0 Then
            Dim coeficiente As String = COEFICIENTESDataGridView.Rows(0).Cells(3).Value
            Dim valorcuota As String = "0"
            TextBox11.Text = coeficiente

            TextBox9.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
            TextBox8.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
        Else
            MessageBox.Show("No existe coeficiente para las cuotas indicadas")
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Me.TopMost = False

        If Ref_Activo = "NO" Then

            Dim result As Integer = MessageBox.Show("¿Abrimos Módulo de Refinanciación?", "Módulo de Refinanciación", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                TextBox2.Select()
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                'Activamos módulo
                Ref_Activo = "SI"
                Label5.Text = "Módulo de REFINANCIACIÓN"
                Me.Text = "Módulo de Refinanciación"
                DataGridView1.Rows.Clear()

                'Mostramos componentes del módulo
                Button7.Text = "ALTA CRÉD. (F1)"
                Label16.Visible = True
                NUMERO_OPERACION_REFTextBox.Visible = True
                If Level = "3" Then
                    TextBox6.ReadOnly = False
                Else
                    TextBox6.ReadOnly = True
                End If

                'Ingresamos número de operación
                NumOp()
                TextBox1.ReadOnly = True

                'Filtramos operación
                DIARIO_CREDITOSBindingSource.Filter = "[OPERACION] = '" & CInt(Op) & "'"
                DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & CInt(Op) & "'"

                If DIARIO_CREDITOSDataGridView.RowCount = 0 Then
                    MessageBox.Show("No existe la operación.")
                    Ref_Activo = "NO"
                    Button7.PerformClick()
                Else
                    'Cargamos datos del cliente
                    TextBox2.Text = DIARIO_CREDITOSDataGridView.Rows(0).Cells(5).Value
                    TextBox2.ReadOnly = True

                    TextBox2.Select()
                    TextBox6.Text = DIARIO_CREDITOSDataGridView.Rows(0).Cells(11).Value
                End If

            End If

        Else

            Dim result As Integer = MessageBox.Show("¿Abrimos Alta de Créditos?", "Alta de Créditos", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                TextBox2.Select()
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                'Activamos módulo
                Ref_Activo = "NO"
                Label5.Text = "ALTA de créditos"
                Me.Text = "Alta de créditos"
                DataGridView1.Rows.Clear()

                'Mostramos componentes del módulo
                Button7.Text = "MÓDULO REF. (F1)"
                Label16.Visible = False
                NUMERO_OPERACION_REFTextBox.Visible = False
                TextBox6.ReadOnly = False

                'Ingresamos número de operación
                TextBox1.Text = lastOperacion
                TextBox1.ReadOnly = True

                'Volvemos atrás la búsqueda del cliente
                TextBox2.Text = ""
                TextBox2.ReadOnly = False

                DIARIO_CREDITOSBindingSource.Filter = "[OPERACION] > '0'"
                DIARIO_CUOTASBindingSource.Filter = "[OPERACION] > '0'"
                TextBox2.Select()

                TextBox6.Text = ""

            End If

        End If

        Me.TopMost = True

    End Sub

    Private Sub NumOp()
        'Ingresamos número de operación
        Op = InputBox("Ingrese el número de operación a refinanciar", "Operación", "")
        TextBox1.Text = Op
    End Sub
End Class