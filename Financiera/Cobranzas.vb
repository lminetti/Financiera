Public Class Cobranzas
    Public Property Operador As String
    Dim cta As String = ""
    Dim Debe As String = ""
    Dim TextBoxCounter As Integer = 1
    Dim final As String = "0"
    Dim operacion As String = ""
    Dim fecha As String = ""
    Dim cuenta As String = ""
    Dim cantCuotas As Integer = 0
    Dim nuevoImporte As String = "0"
    Dim pagoParcial As Integer = 0
    Dim FACTURADO As Integer = 0
    Dim NROFACTURA As String = 0
    Dim r_CAE As String = ""
    Dim r_FCAE As String = ""
    Dim r_SUBTOTAL As String = ""
    Dim r_IVA As String = ""
    Dim checked As Integer = 0
    Dim unchecked As Integer = 0

    Private Sub Cobranzas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = False

        Me.DIARIO_RECIBOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_RECIBOS)
        Me.DETALLE_RECIBOSTableAdapter.Fill(Me.DATABASEDataSet.DETALLE_RECIBOS)
        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        Me.OPERACIONES_ALTATableAdapter.Fill(Me.DATABASEDataSet.OPERACIONES_ALTA)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        Me.OPERADORESTableAdapter.Fill(Me.AJUSTESDataSet.OPERADORES)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        ABM_PERSONALBindingSource.Filter = "[CUENTA] = '0'"
        DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '0'"

        TextBox30.Text = "Opera: " + Operador
        Label42.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox7.Select()

        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = "0"
        TextBox4.Text = "0,00"
        TextBox6.Text = "0,00"

    End Sub

    Private Sub Cobranzas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                If Panel5.Visible = True Then
                    If Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex < Me.ABM_PERSONALDataGridView.RowCount - 1 Then
                        Me.ABM_PERSONALDataGridView.CurrentCell = Me.ABM_PERSONALDataGridView(Me.ABM_PERSONALDataGridView.CurrentCell.ColumnIndex, Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex + 1)
                    End If
                    e.Handled = True
                Else
                    If DIARIO_CUOTASDataGridView.RowCount = 0 Then
                    Else
                        If Me.DIARIO_CUOTASDataGridView.CurrentCell.RowIndex < Me.DIARIO_CUOTASDataGridView.RowCount - 1 Then
                            Me.DIARIO_CUOTASDataGridView.CurrentCell = Me.DIARIO_CUOTASDataGridView(Me.DIARIO_CUOTASDataGridView.CurrentCell.ColumnIndex, Me.DIARIO_CUOTASDataGridView.CurrentCell.RowIndex + 1)
                        End If
                    End If
                    e.Handled = True
                End If
            Case Keys.Up
                If Panel5.Visible = True Then
                    If Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex > 0 Then
                        Me.ABM_PERSONALDataGridView.CurrentCell = Me.ABM_PERSONALDataGridView(Me.ABM_PERSONALDataGridView.CurrentCell.ColumnIndex, Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex - 1)
                    End If
                    e.Handled = True
                Else
                    If DIARIO_CUOTASDataGridView.RowCount = 0 Then
                    Else
                        If Me.DIARIO_CUOTASDataGridView.CurrentCell.RowIndex > 0 Then
                            Me.DIARIO_CUOTASDataGridView.CurrentCell = Me.DIARIO_CUOTASDataGridView(Me.DIARIO_CUOTASDataGridView.CurrentCell.ColumnIndex, Me.DIARIO_CUOTASDataGridView.CurrentCell.RowIndex - 1)
                        End If
                    End If
                    e.Handled = True
                End If
            Case Keys.F8
                Button3.PerformClick()
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                If Panel5.Visible = True Then
                    SacarCheck()
                    final = "0"
                    TextBox26.Text = "0,00"
                    checked = 0
                    unchecked = 0
                    Buscar()
                End If
        End Select
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DIARIO_CUOTASDataGridView.RowCount = 0 Then
            MessageBox.Show("Ninguna cuota seleccionada")
            Exit Sub
        Else
            Dim currentRow As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index

            TextBox8.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
            final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value)

            Dim Impresion_Recibo = New Impresion_Recibo()
            Impresion_Recibo.Nombre = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(2).Value & " " & ABM_PERSONALDataGridView.Rows(0).Cells(3).Value
            Impresion_Recibo.Domicilio_cliente = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(8).Value
            Impresion_Recibo.Condicion_iva_cliente = "CONSUMIDOR FINAL"
            Impresion_Recibo.Localidad = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(9).Value
            Impresion_Recibo.Dni = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(6).Value
            Impresion_Recibo.Cuenta = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value

            Impresion_Recibo.Detalle1 = TextBox8.Text
            Impresion_Recibo.Detalle2 = TextBox9.Text
            Impresion_Recibo.Detalle3 = TextBox10.Text
            Impresion_Recibo.Detalle4 = TextBox11.Text
            Impresion_Recibo.Detalle5 = TextBox12.Text
            Impresion_Recibo.Detalle6 = TextBox13.Text
            Impresion_Recibo.Detalle7 = TextBox14.Text
            Impresion_Recibo.Detalle8 = TextBox15.Text
            Impresion_Recibo.Detalle9 = TextBox16.Text
            Impresion_Recibo.Detalle10 = TextBox17.Text
            Impresion_Recibo.Detalle11 = TextBox18.Text
            Impresion_Recibo.Detalle12 = TextBox19.Text
            Impresion_Recibo.Detalle13 = TextBox20.Text
            Impresion_Recibo.Detalle14 = TextBox21.Text
            Impresion_Recibo.Detalle15 = TextBox22.Text
            Impresion_Recibo.Detalle16 = TextBox23.Text
            Impresion_Recibo.Detalle17 = TextBox24.Text
            Impresion_Recibo.Detalle18 = TextBox25.Text

            Impresion_Recibo.Total = CDbl(final).ToString("F2")
            Impresion_Recibo.Operacion = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value
            Impresion_Recibo.Fecha = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(8).Value
            Impresion_Recibo.Cuenta = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value
            Impresion_Recibo.Show()
            Me.Close()
        End If
    End Sub

    Private Sub DIARIO_CUOTASDataGridView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DIARIO_CUOTASDataGridView.CellEnter

        TextBox1.Text = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(3).Value
        TextBox3.Text = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(4).Value
        TextBox5.Text = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(9).Value
        TextBox4.Text = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(10).Value
        TextBox6.Text = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(11).Value

        Button1.Enabled = False

        If DIARIO_CUOTASDataGridView.RowCount > 0 Then
            If DIARIO_CUOTASDataGridView.CurrentRow.Index = 0 Then
                Button1.Enabled = True
            Else
                If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index - 1).Cells(7).Value = "0" Then
                    Button1.Enabled = False
                    If DIARIO_CUOTASDataGridView.Rows(0).Cells(0).Value = 1 Then
                        Button1.Enabled = True
                    End If
                Else
                    Button1.Enabled = True
                End If
            End If
        End If

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.TextLength > 0 Then
            If IsNumeric(TextBox7.Text) Then
                ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & TextBox7.Text & "' Or [DNI] LIKE '" & TextBox7.Text & "%' Or [CUIL] LIKE '" & TextBox7.Text & "%'"
            Else
                ABM_PERSONALBindingSource.Filter = "[NOMBRE] LIKE '" & TextBox7.Text & "%' Or [APELLIDO] LIKE '" & TextBox7.Text & "%'"
            End If
            If ABM_PERSONALDataGridView.RowCount > 0 Then
                Panel5.Visible = True
                DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(0).Cells(1).Value) & "' AND [ESTADO] = 'EN CURSO'"
                cta = ABM_PERSONALDataGridView.Rows(0).Cells(1).Value
                TextBox2.Text = cta
                ComboBox1.Items.Clear()
                ComboBox1.Text = "Seleccionar"
                If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                    For Each rw In DIARIO_CREDITOSDataGridView.Rows
                        ComboBox1.Items.Add((rw.Cells(1)).Value).ToString()
                    Next
                End If

            End If
            Else
            Panel5.Visible = False
            ABM_PERSONALBindingSource.Filter = "[CUENTA] = '0'"
        End If
    End Sub

    Private Sub Buscar()
        If ABM_PERSONALDataGridView.RowCount > 0 Then
            Panel5.Visible = True
            DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & CInt(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value) & "' AND [ESTADO] = 'EN CURSO'"
            cta = ABM_PERSONALDataGridView.Rows(0).Cells(1).Value
            TextBox2.Text = cta
            ComboBox1.Items.Clear()
            ComboBox1.Text = "Seleccionar"
            If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                For Each rw In DIARIO_CREDITOSDataGridView.Rows
                    ComboBox1.Items.Add((rw.Cells(1)).Value).ToString()
                Next
            End If
            If DIARIO_CREDITOSDataGridView.RowCount = 1 Then
                ComboBox1.Items.Clear()
                ComboBox1.Text = (DIARIO_CREDITOSDataGridView.Rows(0).Cells(1).Value).ToString()
                SeleccionComboBox()
            End If
        End If
        Panel5.Visible = False
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                ComboBox1.Select()
                final = "0"
                TextBox26.Text = "0,00"
                checked = 0
                unchecked = 0
                Buscar()
                SacarCheck()
        End Select
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button1.PerformClick()
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.TopMost = False

        'Muestro panel de vuelto
        Panel4.Visible = True
        TextBox27.Select()

    End Sub

    Private Sub RealizarCobranza()

        If DIARIO_CUOTASDataGridView.RowCount = 0 Then
            MessageBox.Show("Ninguna cuota seleccionada")
            Exit Sub
        Else

            Dim ImporteTotal As Double = 0
            If pagoParcial = 1 Then
                ImporteTotal = CDbl(TextBox27.Text)
                DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(6).Value = DateTime.Now.ToString("dd/MM/yyyy")
            Else
                ImporteTotal = CDbl(TextBox26.Text)
            End If

            DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
            DIARIO_CUOTASDataGridView.Rows(0).Selected = True

            OPERADORESBindingSource.Filter = "[NOMBRE] = '" & Operador & "'"
            If IsDBNull(OPERADORESDataGridView.Rows(0).Cells(5).Value) Then
                MessageBox.Show("El operador no tiene ninguna caja asignada")
                Exit Sub
            End If
            If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(12).Value = "NO" Then
                FACTURADO = 1
                Label14.Visible = True
                Label15.Visible = True
            Else
                FACTURADO = 0
                Label14.Visible = False
                Label15.Visible = False
            End If

            Dim PagoTotal As Double = ImporteTotal
            Dim Restante As Double = 0
            Dim pagadoFinal As Double = 0

            Do

                If DIARIO_CUOTASDataGridView.RowCount = 0 Then
                    Exit Do
                End If

                TextBox26.Text = ImporteTotal

                If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 1 Then
                    'Aplica la cuota
                    'Ingresar datos a la fila seleccionada

                    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 0

                    Dim currentRow As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index

                    If DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value = "0,00" Or DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value = "0" Then

                        If PagoTotal < DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(4).Value Then
                            Restante = PagoTotal
                        ElseIf PagoTotal >= DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(4).Value Then
                            PagoTotal = PagoTotal - CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(4).Value)
                        End If

                    Else

                        If PagoTotal < DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value Then
                            Restante = PagoTotal
                        ElseIf PagoTotal >= DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value Then
                            PagoTotal = PagoTotal - CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value)
                        End If

                    End If

                    If Restante > 0 Then
                        nuevoImporte = Restante
                        If TextBox6.Text = "0" Or TextBox6.Text = "0,00" Then
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value = CDbl(nuevoImporte).ToString("F2")
                            Debe = CDbl(nuevoImporte).ToString("F2")
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(4).Value = CDbl(CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(4).Value) - CDbl(nuevoImporte)).ToString("F2")
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value = "0,00"
                        Else
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value = CDbl(nuevoImporte).ToString("F2")
                            Debe = CDbl(nuevoImporte).ToString("F2")
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(4).Value = CDbl(CDbl(TextBox6.Text) - CDbl(nuevoImporte)).ToString("F2")
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value = "0,00"
                        End If
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(10).Value = "0,00"
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(9).Value = "0"
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(8).Value = Date.Today.ToString("dd/MM/yyyy")
                    ElseIf Restante = 0 Then
                        If TextBox6.Text = "0" Or TextBox6.Text = "0,00" Then
                            pagadoFinal = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + TextBox3.Text
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value = TextBox3.Text
                            Debe = TextBox3.Text
                        Else
                            pagadoFinal = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + TextBox6.Text
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value = TextBox6.Text
                            Debe = TextBox6.Text
                        End If
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value = "0,00"
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(10).Value = "0,00"
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(9).Value = "0"
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(8).Value = Date.Today.ToString("dd/MM/yyyy")
                    End If

                    If TextBoxCounter = 1 Then
                        TextBox8.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 2 Then
                        TextBox9.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 3 Then
                        TextBox10.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 4 Then
                        TextBox11.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 5 Then
                        TextBox12.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 6 Then
                        TextBox13.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 7 Then
                        TextBox14.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 8 Then
                        TextBox15.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 9 Then
                        TextBox16.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 10 Then
                        TextBox17.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 11 Then
                        TextBox18.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 12 Then
                        TextBox19.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 13 Then
                        TextBox20.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 14 Then
                        TextBox21.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 15 Then
                        TextBox22.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 16 Then
                        TextBox23.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 17 Then
                        TextBox24.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If
                    If TextBoxCounter = 18 Then
                        TextBox25.Text = "OPERACIÓN: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value & " - " & "CUOTA: " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value & " de " & cantCuotas & " - " & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value & " --- $" & DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value
                        final = CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value) + CDbl(final)
                    End If

                    'Ingresar datos contables
                    Dim CajaAsignada As String = OPERADORESDataGridView.Rows(0).Cells(5).Value

                    Dim Valor As Integer = 0
                    Dim SaldoAnterior As String = ""

                    CONTABLEBindingSource.Filter = "[CAJA] = '" & CajaAsignada & "'"

                    CONTABLEDataGridView.Sort(CONTABLEDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

                    If CONTABLEDataGridView.RowCount > 0 Then
                        Valor = CONTABLEDataGridView.RowCount - 1
                        SaldoAnterior = CONTABLEDataGridView.Rows(Valor).Cells(6).Value
                    End If
                    Dim Haber As String = "0"
                    Dim Saldo As String = "0"
                    If CONTABLEDataGridView.RowCount > 0 Then
                        Haber = "0"
                        Saldo = CDbl(SaldoAnterior) + CDbl(Debe)
                    Else
                        Haber = "0"
                        Saldo = Debe
                    End If

                    Dim newRow As DataRowView = DirectCast(CONTABLEBindingSource.AddNew(), DataRowView)

                    newRow("CODIGO") = "0"
                    newRow("CAJA") = CajaAsignada
                    newRow("ASIENTO") = "COBRANZA"
                    newRow("DEBE") = Debe
                    newRow("HABER") = Haber
                    newRow("SALDO") = Saldo
                    newRow("OPERADOR") = Operador
                    newRow("FECHA") = Label42.Text
                    newRow("CUOTA") = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(3).Value
                    newRow("OPERACION") = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(1).Value

                    CONTABLEBindingSource.EndEdit()
                    CONTABLETableAdapter.Update(DATABASEDataSet.CONTABLE)
                    Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)

                    'Ajustar deuda en Diario_Créditos
                    Dim op As String = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(1).Value
                    Dim cta As String = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(2).Value

                    DIARIO_CREDITOSBindingSource.Filter = "[OPERACION] = '" & op & "' AND [CUENTA] = '" & cta & "'"

                    Dim deuda As String = "0"
                    Dim importe As String = "0"

                    If pagoParcial = 1 Then
                        If TextBox6.Text = "0" Then
                            importe = CDbl(nuevoImporte).ToString("F2")
                        Else
                            importe = CDbl(nuevoImporte).ToString("F2")
                        End If
                    ElseIf pagoParcial = 0 Then
                        If TextBox6.Text = "0" Then
                            importe = TextBox3.Text
                        Else
                            importe = TextBox6.Text
                        End If
                    End If

                    If DIARIO_CREDITOSDataGridView.RowCount > 0 Then
                        deuda = DIARIO_CREDITOSDataGridView.Rows(0).Cells(11).Value
                        deuda = CDbl(deuda) - CDbl(importe)

                        'Si la deuda es menor a $10, cambia el estado del credito a CANCELADO
                        If deuda <= 10 Then
                            DIARIO_CREDITOSDataGridView.Rows(0).Cells(13).Value = "CANCELADO"
                        End If

                        DIARIO_CREDITOSDataGridView.Rows(0).Cells(11).Value = CDbl(deuda).ToString("F2")
                        DIARIO_CREDITOSBindingSource.EndEdit()
                        DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)
                    End If

                    'Ingresar datos a DETALLE_RECIBOS

                    Dim newRow2 As DataRowView = DirectCast(DETALLE_RECIBOSBindingSource.AddNew(), DataRowView)

                    If FACTURADO = 1 Then
                        'Guardar datos de factura
                        Dim nro As Double
                        Dim PtoVta As Integer = AJUSTESDataGridView.Rows(0).Cells(8).Value
                        Dim TipoComp As Integer
                        Dim letraComp = ""

                        ''''''' CARGO TIPO DE FACTURA
                        'Si quien emite es Monotributista
                        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE MONOTRIBUTO" Then
                            letraComp = "FCC"
                            TipoComp = 11
                        End If
                        'Si quien emite es Responsable Inscripto
                        If IsDBNull(ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value) Then
                            ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "CONSUMIDOR FINAL"
                        End If
                        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" And ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "CONSUMIDOR FINAL" Then
                            letraComp = "FCB"
                            TipoComp = 6
                        End If
                        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" And ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "EXENTO FISCAL" Then
                            letraComp = "FCB"
                            TipoComp = 6
                        End If
                        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" And ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "MONOTRIBUTISTA" Then
                            letraComp = "FCB"
                            TipoComp = 6
                        End If
                        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" And ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "RESPONSABLE INSCRIPTO" Then
                            letraComp = "FCA"
                            TipoComp = 1
                        End If
                        newRow2("TIPO") = letraComp

                        '''''''''''' CARGO NÚMERO DE FACTURA
                        'URLs de autenticacion y negocio. Cambiarlas por las de producción al implementarlas en el cliente(abajo)
                        Const URLWSAA = "https://wsaa.afip.gov.ar/ws/services/LoginCms"
                        ' Homologación: https://wsaahomo.afip.gov.ar/ws/services/LoginCms 
                        Const URLWSW = "https://servicios1.afip.gov.ar/wsfev1/service.asmx"
                        ' Homologación: https://wswhomo.afip.gov.ar/wsfev1/service.asmx
                        ' Si esta linea falla es porque no agrego la referencia en a FEAFIPLib desde el menu de proyecto
                        Dim wsfev1 As FEAFIPLib.wsfev1
                        If wsfev1.login("Z:\crt.crt", "Z:\key.key", URLWSAA) Then
                            If Not wsfev1.RecuperaLastCMP(PtoVta, TipoComp, nro) Then
                                MsgBox(wsfev1.ErrorDesc)
                            End If
                            nro = nro + 1
                            wsfev1.Reset()
                        End If
                        newRow2("NUMERO") = PtoVta.ToString("D4") & nro.ToString("D8")
                    Else
                        newRow2("TIPO") = "SIM"
                        newRow2("NUMERO") = AJUSTESDataGridView.Rows(0).Cells(12).Value
                    End If

                    newRow2("FECHA") = Date.Today.ToString("dd/MM/yyyy")
                    newRow2("CUENTA") = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value
                    newRow2("OPERACION") = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value
                    newRow2("CUOTA") = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value
                    newRow2("FECHA_VENCIMIENTO") = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(6).Value
                    newRow2("IMPORTE") = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value

                    DETALLE_RECIBOSBindingSource.EndEdit()
                    DETALLE_RECIBOSTableAdapter.Update(DATABASEDataSet.DETALLE_RECIBOS)

                    If Restante = 0 Then
                        If TextBox6.Text = "0" Or TextBox6.Text = "0,00" Then
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value = pagadoFinal
                            Debe = TextBox3.Text
                        Else
                            DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value = pagadoFinal
                            Debe = TextBox6.Text
                        End If
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(4).Value = "0,00"
                    End If

                    If TextBoxCounter = 7 Then
                        'Terminar
                        MessageBox.Show("El dibujo de cobranza sólo tiene espacio para 7 registros de pagos.")
                        DIARIO_CUOTASBindingSource.EndEdit()
                        DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)
                        Exit Do
                    Else
                        DIARIO_CUOTASBindingSource.EndEdit()
                        DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)
                        TextBoxCounter = TextBoxCounter + 1
                    End If

                    If checked = 1 Then
                        Exit Do
                    Else
                        If DIARIO_CUOTASDataGridView.RowCount > 0 Then
                            DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
                            DIARIO_CUOTASDataGridView.Rows(0).Selected = True
                        End If
                    End If

                Else
                    Exit Do
                End If

            Loop

        End If

        pagoParcial = 0
        nuevoImporte = "0"

    End Sub

    Private Sub IniciarImpresion()
        If FACTURADO = 1 Then
            'Realizar facturación electrónica
            FacturacionElectronica()
        End If

        Dim Impresion_Recibo = New Impresion_Recibo()
        Impresion_Recibo.Nombre = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(2).Value & " " & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(3).Value
        Impresion_Recibo.Domicilio_cliente = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(8).Value
        Impresion_Recibo.Localidad = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(9).Value
        Impresion_Recibo.Dni = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(6).Value
        Impresion_Recibo.Cuenta = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value
        If FACTURADO = 1 Then
            Impresion_Recibo.FACTURA = 1
            Impresion_Recibo.NROFACTURA = NROFACTURA
            Impresion_Recibo.Condicion_iva_cliente = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value
            Impresion_Recibo.CAE = r_CAE
            Impresion_Recibo.FCAE = r_FCAE
            Impresion_Recibo.SUBTOTAL = r_SUBTOTAL
            Impresion_Recibo.IVA = r_IVA
        Else
            Impresion_Recibo.FACTURA = 0
            Impresion_Recibo.Condicion_iva_cliente = "CONSUMIDOR FINAL"
        End If

        Impresion_Recibo.Detalle1 = TextBox8.Text
        Impresion_Recibo.Detalle2 = TextBox9.Text
        Impresion_Recibo.Detalle3 = TextBox10.Text
        Impresion_Recibo.Detalle4 = TextBox11.Text
        Impresion_Recibo.Detalle5 = TextBox12.Text
        Impresion_Recibo.Detalle6 = TextBox13.Text
        Impresion_Recibo.Detalle7 = TextBox14.Text
        Impresion_Recibo.Detalle8 = TextBox15.Text
        Impresion_Recibo.Detalle9 = TextBox16.Text
        Impresion_Recibo.Detalle10 = TextBox17.Text
        Impresion_Recibo.Detalle11 = TextBox18.Text
        Impresion_Recibo.Detalle12 = TextBox19.Text
        Impresion_Recibo.Detalle13 = TextBox20.Text
        Impresion_Recibo.Detalle14 = TextBox21.Text
        Impresion_Recibo.Detalle15 = TextBox22.Text
        Impresion_Recibo.Detalle16 = TextBox23.Text
        Impresion_Recibo.Detalle17 = TextBox24.Text
        Impresion_Recibo.Detalle18 = TextBox25.Text

        Impresion_Recibo.Total = CDbl(TextBox26.Text).ToString("F2")
        Impresion_Recibo.Operacion = operacion
        Impresion_Recibo.Fecha = fecha
        Impresion_Recibo.Show()

        Dim NuevaCobranza = New Cobranzas()
        NuevaCobranza.Operador = Operador
        NuevaCobranza.Show()
        Me.Close()

    End Sub

    Private Sub Impresion()

        If IMPRESION_AUTTextBox.Text = "SI" Then
            IniciarImpresion()
        Else
            Dim result As Integer = MessageBox.Show("¿Imprimir recibo?", "Impresión", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                IniciarImpresion()
            End If
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If TextBox2.TextLength > 0 And ComboBox1.Text IsNot "Seleccionar" Then
            DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '" & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value & "' AND [OPERACION] = '" & ComboBox1.Text & "'"
            cantCuotas = DIARIO_CUOTASDataGridView.RowCount
            DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '" & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value & "' AND [VALOR_CUOTA] > '0,00' AND [OPERACION] = '" & ComboBox1.Text & "'"
            DIARIO_CUOTASDataGridView.Sort(DIARIO_CUOTASDataGridView.Columns(12), System.ComponentModel.ListSortDirection.Ascending)
            SacarCheck()
        Else
            DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '0'"
        End If
    End Sub

    Private Sub SeleccionComboBox()
        DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '" & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value & "' AND [OPERACION] = '" & ComboBox1.Text & "'"
        cantCuotas = DIARIO_CUOTASDataGridView.RowCount
        DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '" & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value & "' AND [VALOR_CUOTA] > '0,00' AND [OPERACION] = '" & ComboBox1.Text & "'"
        DIARIO_CUOTASDataGridView.Sort(DIARIO_CUOTASDataGridView.Columns(3), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub TextBox27_TextChanged(sender As Object, e As EventArgs) Handles TextBox27.TextChanged
        If TextBox27.TextLength > 0 Then
            TextBox28.Text = CDbl(CDbl(TextBox27.Text) - CDbl(TextBox26.Text)).ToString("F2")
        End If
    End Sub

    Private Sub FinalizarOperacion()

        If TextBox26.Text = "0,00" Then
            If DIARIO_CUOTASDataGridView.RowCount > 0 Then
                DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
                DIARIO_CUOTASDataGridView.Rows(0).Selected = True
                For Each rw In DIARIO_CUOTASDataGridView.Rows
                    If DIARIO_CUOTASDataGridView.Rows(rw).Cells(0).Value = 0 Then
                    ElseIf DIARIO_CUOTASDataGridView.Rows(rw).Cells(0).Value = 1 Then
                        TextBox26.Text = CDbl(TextBox26.Text) + CDbl(DIARIO_CUOTASDataGridView.Rows(rw).Cells(4).Value)
                    End If
                Next
            End If
        End If

        If TextBox27.Text = "0" Or TextBox27.Text = "" Or TextBox27.Text = "0,00" Then
            MessageBox.Show("Ingrese un monto de pago.")
            TextBox27.Select()
            Exit Sub
        End If

        Dim result As Integer = MessageBox.Show("¿Aplicar pago?", "Pagos", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then

            Dim currentRow As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index
            Dim currentRow2 As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index
            operacion = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(1).Value
            fecha = DateTime.Now.ToString("dd/MM/yyyy")
            cuenta = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(3).Value

            If CDbl(TextBox27.Text) < CDbl(TextBox26.Text) Then
                pagoParcial = 1
                RealizarCobranza()
            Else
                pagoParcial = 0
                RealizarCobranza()
            End If

            Panel4.Visible = False

            DIARIO_CUOTASBindingSource.EndEdit()
            DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)
            Impresion()

        End If



    End Sub

    Private Sub TextBox27_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox27.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                FinalizarOperacion()
        End Select
    End Sub

    Private Sub FacturacionElectronica()

        'PARÁMETROS DE FACTURACIÓN ELECTRÓNICA
        'URLs de autenticacion y negocio. Cambiarlas por las de producción al implementarlas en el cliente(abajo)
        Const URLWSAA = "https://wsaa.afip.gov.ar/ws/services/LoginCms"
        ' Homologación: https://wsaahomo.afip.gov.ar/ws/services/LoginCms 
        Const URLWSW = "https://servicios1.afip.gov.ar/wsfev1/service.asmx"
        ' Homologación: https://wswhomo.afip.gov.ar/wsfev1/service.asmx

        ' Si esta linea falla es porque no agrego la referencia en a FEAFIPLib desde el menu de proyecto
        Dim wsfev1 As FEAFIPLib.wsfev1
        Dim nro As Double
        Dim Resultado As String
        Dim Reproceso As String
        Dim PtoVta As Integer
        Dim TipoComp As Integer
        Dim FechaComp As String
        Dim CAE As String
        Dim Vencimiento As String
        Dim letraComp As String = 0

        CAE = ""
        Vencimiento = ""
        Resultado = ""
        Reproceso = ""
        nro = 0
        PtoVta = AJUSTESDataGridView.Rows(0).Cells(8).Value

        'TIPO DE COMPROBANTE Y TIPO DE DOCUMENTO SEGÚN CONDICIÓN FRENTE AL IVA
        Dim Tipo As String
        'Si quien emite es Monotributista
        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE MONOTRIBUTO" Then
            TipoComp = 11
            letraComp = "FCC"
            If ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "CONSUMIDOR FINAL" Then
                Tipo = "96"
            ElseIf ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "EXENTO FISCAL" Then
                Tipo = "80"
            ElseIf ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "MONOTRIBUTISTA" Then
                Tipo = "80"
            ElseIf ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "RESPONSABLE INSCRIPTO" Then
                Tipo = "80"
            End If
        End If

        'Si quien emite es Responsable Inscripto
        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" And ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "CONSUMIDOR FINAL" Then
            TipoComp = 6
            Tipo = "96"
            letraComp = "FCB"
        End If
        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" And ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "EXENTO FISCAL" Then
            TipoComp = 6
            Tipo = "80"
            letraComp = "FCB"
        End If
        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" And ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "MONOTRIBUTISTA" Then
            TipoComp = 6
            Tipo = "80"
            letraComp = "FCB"
        End If
        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" And ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(16).Value = "RESPONSABLE INSCRIPTO" Then
            TipoComp = 1
            Tipo = "80"
            letraComp = "FCA"
        End If

        FechaComp = Date.Today.ToString("yyyyMMdd")

        Dim Concepto As String
        Dim Documento As String
        Dim FchDesde As String
        Dim FchHasta As String
        Dim FchVencimiento As String
        Dim ImporteTotal As Double
        Dim ImporteSinIVA As Double

        If AJUSTESDataGridView.Rows(0).Cells(9).Value = "SERVICIOS" Then
            Concepto = 3
        ElseIf AJUSTESDataGridView.Rows(0).Cells(9).Value = "PRODUCTOS Y SERVICIOS" Then
            Concepto = 2
        ElseIf AJUSTESDataGridView.Rows(0).Cells(9).Value = "PRODUCTOS" Then
            Concepto = 1
        End If

        Dim IVATOTAL As Double = 0
        If Tipo = "96" Then
            Documento = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(6).Value
        ElseIf Tipo = "80" Then
            Documento = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(7).Value
        End If
        ImporteSinIVA = CDbl(TextBox26.Text) / 1.21
        IVATOTAL = CDbl(TextBox26.Text) - CDbl(ImporteSinIVA)
        ImporteTotal = CDbl(ImporteSinIVA) + CDbl(IVATOTAL)

        FchDesde = ""
        FchHasta = ""
        FchVencimiento = ""

        If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE MONOTRIBUTO" Then
            ImporteTotal = CDbl(TextBox26.Text)
            ImporteTotal = ImporteTotal.ToString("N2")
            FchDesde = DateTime.Now.ToString("yyyyMMdd")
            FchHasta = DateTime.Now.ToString("yyyyMMdd")
            FchVencimiento = DateTime.Now.ToString("yyyyMMdd")
        End If

        wsfev1 = New FEAFIPLib.wsfev1
        wsfev1.CUIT = AJUSTESDataGridView.Rows(0).Cells(5).Value ' Cuit del vendedor
        wsfev1.URL = URLWSW
        If wsfev1.login("Z:\crt.crt", "Z:\key.key", URLWSAA) Then
            If Not wsfev1.RecuperaLastCMP(PtoVta, TipoComp, nro) Then
                MsgBox(wsfev1.ErrorDesc)
            End If
            nro = nro + 1
            NROFACTURA = nro
            wsfev1.Reset()

            ImporteTotal = ImporteTotal.ToString("N2")
            ImporteSinIVA = ImporteSinIVA.ToString("N2")
            IVATOTAL = IVATOTAL.ToString("N2")

            If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE MONOTRIBUTO" Then
                'wsfev1.AgregaFactura(concepto (1:productos, 2:servicios, 3:productos y servicios): 1, tipo de cuit (80:cuit, 96:dni, 86:cuil): 80, cuit: 30707219072, nro, nro, FechaComp, Importe total: 121, 0, Importe sin iva: 100, 0, "", "", "", "PES", 1)
                wsfev1.AgregaFactura(Concepto, Tipo, Documento, nro, nro, FechaComp, ImporteTotal, 0, ImporteTotal, 0, FchDesde, FchHasta, FchVencimiento, "PES", 1)
            Else
                'wsfev1.AgregaFactura(concepto (1:productos, 2:servicios, 3:productos y servicios): 1, tipo de cuit (80:cuit, 96:dni, 86:cuil): 80, cuit: 30707219072, nro, nro, FechaComp, Importe total: 121, 0, Importe sin iva: 100, 0, "", "", "", "PES", 1)
                wsfev1.AgregaFactura(Concepto, Tipo, Documento, nro, nro, FechaComp, ImporteTotal, 0, ImporteSinIVA, 0, FchDesde, FchHasta, FchVencimiento, "PES", 1)
            End If

            'AGREGAR IVA
            'wsfev1.AgregaIVA(0, 0, 0) 'ir a http://www.bitingenieria.com.ar/codigos.html
            If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE MONOTRIBUTO" Then
                'No calcula IVA
                IVATOTAL = 0
                ImporteSinIVA = ImporteTotal
            Else
                'Calcula IVA
                'Agrega 21
                wsfev1.AgregaIVA(5, ImporteSinIVA, IVATOTAL)
            End If

            If wsfev1.Autorizar(PtoVta, TipoComp) Then
                wsfev1.AutorizarRespuesta(0, CAE, Vencimiento, Resultado, Reproceso)
                If Resultado = "A" Then
                    ' MsgBox("Factura emitida. CAE y Vencimiento: " &
                    'CAE + " " + Vencimiento)
                    VTOTEXTBOX.Text = Vencimiento
                    CAETEXTBOX.Text = CAE
                Else
                    MsgBox(wsfev1.AutorizarRespuestaObs(0))
                    Exit Sub
                End If
            Else
                MsgBox(wsfev1.ErrorDesc)
            End If
        Else
            MsgBox(wsfev1.ErrorDesc)
        End If

        If CAETEXTBOX.Text = "" Then
            MessageBox.Show("No se pudo obtener el Código de Autorización Electrónico.")
        Else

            'Ingresar datos a DIARIO_RECIBOS

            Dim newRow As DataRowView = DirectCast(DIARIO_RECIBOSBindingSource.AddNew(), DataRowView)

            newRow("TIPO") = letraComp
            newRow("NUMERO") = PtoVta.ToString("D4") & nro.ToString("D8")
            newRow("FECHA") = Date.Today.ToString("dd/MM/yyyy")
            newRow("CUENTA") = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value
            newRow("NOMBRE") = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(2).Value
            newRow("APELLIDO") = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(3).Value
            newRow("DOMICILIO") = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(8).Value
            newRow("LOCALIDAD") = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(9).Value
            newRow("CUIT") = Documento
            newRow("SUBTOTAL") = ImporteSinIVA
            newRow("GRAVADO") = ImporteSinIVA
            newRow("IVA") = IVATOTAL
            newRow("TOTAL") = TextBox26.Text
            newRow("CAE") = CAETEXTBOX.Text
            newRow("FCAE") = VTOTEXTBOX.Text
            newRow("CONDICION") = "CONTADO"

            DIARIO_RECIBOSBindingSource.EndEdit()
            DIARIO_RECIBOSTableAdapter.Update(DATABASEDataSet.DIARIO_RECIBOS)

            'Datos para impresión de comprobante
            r_CAE = CAETEXTBOX.Text
            r_FCAE = VTOTEXTBOX.Text
            r_SUBTOTAL = ImporteSinIVA.ToString("N2")
            r_IVA = IVATOTAL.ToString("N2")

            'CARGAR CÓDIGO DE BARRA
            'Indicar código de factura
            Dim Cod_Factura_Presupuesto As String = ""

            If TipoComp = 1 Then
                Cod_Factura_Presupuesto = "01"
            End If
            If TipoComp = 6 Then
                Cod_Factura_Presupuesto = "06"
            End If
            If TipoComp = 11 Then
                Cod_Factura_Presupuesto = "11"
            End If

            Dim Punto_De_Venta As Integer = AJUSTESDataGridView.Rows(0).Cells(8).Value

        End If

    End Sub

    Private Sub DIARIO_CUOTASDataGridView_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DIARIO_CUOTASDataGridView.CurrentCellDirtyStateChanged
        If DIARIO_CUOTASDataGridView.IsCurrentCellDirty Then
            DIARIO_CUOTASDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            For Each dgv As DataGridViewRow In DIARIO_CUOTASDataGridView.Rows

                dgv.Cells(0).Value = 1
                Dim cuota As Double = dgv.Cells(4).Value
                Dim interes As Double = dgv.Cells(11).Value

                If interes = "0,00" Then
                    final = CDbl(final) + CDbl(cuota)
                Else
                    final = CDbl(final) + CDbl(interes)
                End If

                TextBox26.Text = CDbl(final).ToString("F2")

            Next
        Else
            For Each dgv As DataGridViewRow In DIARIO_CUOTASDataGridView.Rows

                dgv.Cells(0).Value = 0
                Dim cuota As Double = dgv.Cells(4).Value
                Dim interes As Double = dgv.Cells(11).Value

                If interes = "0,00" Then
                    final = CDbl(final) - CDbl(cuota)
                Else
                    final = CDbl(final) - CDbl(interes)
                End If

                TextBox26.Text = CDbl(final).ToString("F2")

            Next
        End If
    End Sub

    Private Sub SacarCheck()
        If DIARIO_CUOTASDataGridView.RowCount > 0 Then
            DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = False
            DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 0
            DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
            DIARIO_CUOTASDataGridView.Rows(0).Selected = True
            For Each rw In DIARIO_CUOTASDataGridView.Rows
                rw.Cells(0).Value = 0
            Next
        Else
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FinalizarOperacion()
    End Sub

    Private Sub DIARIO_CUOTASDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DIARIO_CUOTASDataGridView.CellContentClick

        DIARIO_CUOTASDataGridView.ReadOnly = False

        If e.ColumnIndex = 0 Then

            DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(e.RowIndex).Cells(0)
            DIARIO_CUOTASDataGridView.Rows(e.RowIndex).Selected = True

            'If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 1 Then
            '    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 0
            'Else
            '    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 1
            'End If

            If checked >= 29 Then
                MessageBox.Show("El dibujo de cobranza sólo tiene espacio para 7 registros de pagos. Generá el comprobante por 7 cuotas y luego generá otro por las cuotas restantes.")
                final = "0"
                TextBox26.Text = "0,00"
                SacarCheck()
            Else
                Dim cuota As Double = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(4).Value
                Dim interes As Double = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(11).Value

                If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 1 Then
                    If unchecked = DIARIO_CUOTASDataGridView.RowCount Then
                        final = "0"
                    Else
                        If interes = "0,00" Or interes = "0" Then
                            final = CDbl(final) + CDbl(cuota)
                        Else
                            final = CDbl(final) + CDbl(interes)
                        End If
                    End If
                ElseIf DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 0 Then
                    If unchecked = DIARIO_CUOTASDataGridView.RowCount Then
                        final = "0"
                    Else
                        If interes = "0,00" Or interes = "0" Then
                            final = CDbl(final) - CDbl(cuota)
                        Else
                            final = CDbl(final) - CDbl(interes)
                        End If
                    End If
                End If

                TextBox26.Text = CDbl(final).ToString("F2")
            End If

        End If

        If checked >= 29 Then
            SacarCheck()
            checked = 0
            DIARIO_CUOTASDataGridView.ReadOnly = True
        End If
    End Sub

    Private Sub DIARIO_CUOTASDataGridView_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DIARIO_CUOTASDataGridView.CellContentDoubleClick
        DIARIO_CUOTASDataGridView.ReadOnly = False

        If e.ColumnIndex = 0 Then

            DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(e.RowIndex).Cells(0)
            DIARIO_CUOTASDataGridView.Rows(e.RowIndex).Selected = True

            'If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 1 Then
            '    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 0
            'Else
            '    DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 1
            'End If

            If checked >= 29 Then
                MessageBox.Show("El dibujo de cobranza sólo tiene espacio para 7 registros de pagos. Generá el comprobante por 7 cuotas y luego generá otro por las cuotas restantes.")
                final = "0"
                TextBox26.Text = "0,00"
                SacarCheck()
            Else
                Dim cuota As Double = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(4).Value
                Dim interes As Double = DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(11).Value

                If DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 1 Then
                    If unchecked = DIARIO_CUOTASDataGridView.RowCount Then
                        final = "0"
                    Else
                        If interes = "0,00" Or interes = "0" Then
                            final = CDbl(final) + CDbl(cuota)
                        Else
                            final = CDbl(final) + CDbl(interes)
                        End If
                    End If
                ElseIf DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(0).Value = 0 Then
                    If unchecked = DIARIO_CUOTASDataGridView.RowCount Then
                        final = "0"
                    Else
                        If interes = "0,00" Or interes = "0" Then
                            final = CDbl(final) - CDbl(cuota)
                        Else
                            final = CDbl(final) - CDbl(interes)
                        End If
                    End If
                End If

                TextBox26.Text = CDbl(final).ToString("F2")
            End If

        End If

        If checked >= 29 Then
            SacarCheck()
            checked = 0
            DIARIO_CUOTASDataGridView.ReadOnly = True
        End If
    End Sub

    Private Sub TextBox7_Click(sender As Object, e As EventArgs) Handles TextBox7.Click
        TextBox7.Text = ""
        DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '0'"
    End Sub
End Class