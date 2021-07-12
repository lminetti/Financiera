Public Class Calcular_Intereses

    Private Sub Calcular_Intereses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        Me.INTERESESTableAdapter.Fill(Me.DATABASEDataSet.INTERESES)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)

        Dim dias_mora As String = 0
        Dim fecha_vencimiento As Date = Date.Today.ToString("dd/MM/yyyy")
        Dim interes As String = "1"
        Dim punitorios As String = 0
        Dim cuota_intereses As String = 0
        Dim hoy As Date = Date.Today.ToString("dd/MM/yyyy")
        Dim suma_punitorios As String = "0"
        Dim deuda_inicial As String = "0"


        If INTERESESDataGridView.RowCount > 0 Then
            interes = INTERESESDataGridView.Rows(0).Cells(2).Value
        Else
            MessageBox.Show("No hay ningún coeficiente de interés cargado")
            Me.Close()
        End If

        DIARIO_CUOTASBindingSource.Filter = "[FECHA_VENCIMIENTO] < #" & hoy.ToString("MM/dd/yyyy") & "# And [VALOR_CUOTA] > '0' OR [FECHA_VENCIMIENTO] < #" & hoy.ToString("MM/dd/yyyy") & "# And [VALOR_CUOTA] > '0,00'"

        If DIARIO_CUOTASDataGridView.RowCount > 0 Then

            Dim cantFilas As Integer = DIARIO_CUOTASDataGridView.RowCount
            Dim counter2 As Integer = 1

            DIARIO_CREDITOSBindingSource.Filter = "[OPERACION] = '" & DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(1).Value & "'"

            Do
                Dim currentRow As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index

                'Obtengo datos principales: fecha de vto y días de mora registrados
                fecha_vencimiento = CDate(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(5).Value)
                dias_mora = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(8).Value

                'Obtengo dias de mora reales sin contar los días de fin de semana (domingo)
                Dim dias_de_atraso As Integer = 0
                Do
                    Dim myCulture As System.Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
                    Dim dayOfWeek As DayOfWeek = myCulture.Calendar.GetDayOfWeek(fecha_vencimiento)
                    Dim Dia_Hoy As String = myCulture.DateTimeFormat.GetDayName(dayOfWeek)

                    If Dia_Hoy.ToString = "domingo" Then
                        'Nada
                    Else
                        dias_de_atraso = dias_de_atraso + 1
                    End If

                    fecha_vencimiento = fecha_vencimiento.AddDays(1)

                    If fecha_vencimiento = hoy Then
                        Exit Do
                    End If
                Loop

                'Obtengo diferencia entre días de mora registrados y días de mora reales
                Dim diferencia_dias As Integer = dias_de_atraso - CInt(dias_mora)

                'Loopeo aplicando interés según la diferencia de días
                If diferencia_dias > 0 Then
                    MessageBox.Show("Diferencia de días mayor a 0")

                    Dim counter As Integer = 1
                    Do
                        If DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(7).Value = "" Then
                            cuota_intereses = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(10).Value
                            MessageBox.Show("Todavía no pagó")
                        Else
                            'Hizo pago parcial
                            MessageBox.Show("Hizo pago parcial")
                            cuota_intereses = DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value
                        End If
                        cuota_intereses = CDbl(cuota_intereses) * CDbl(interes)
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(10).Value = CDbl(cuota_intereses).ToString("F2")
                        DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(9).Value = CDbl(CDbl(cuota_intereses) - CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(11).Value)).ToString("F2")

                        DIARIO_CUOTASBindingSource.EndEdit()
                        DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)

                        If counter = diferencia_dias Then
                            Exit Do
                        End If
                        counter = counter + 1
                    Loop

                Else
                    MessageBox.Show("No hay diferencia de días")
                End If

                'Obtengo punitorios del registro de cuota para recalcular deuda
                suma_punitorios = CDbl(CDbl(DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(9).Value) + CDbl(suma_punitorios)).ToString("F2")

                DIARIO_CUOTASDataGridView.Rows(currentRow).Cells(8).Value = dias_de_atraso
                DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(14).Value = dias_de_atraso

                DIARIO_CUOTASBindingSource.EndEdit()
                DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)

                ' Selecciona la siguiente fila

                Dim counter3 As Integer = DIARIO_CUOTASDataGridView.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter3 = DIARIO_CUOTASDataGridView.RowCount Then
                    Exit Do
                Else
                    nextRow = DIARIO_CUOTASDataGridView.Rows(counter3)
                End If

                DIARIO_CUOTASDataGridView.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True

                If counter2 = cantFilas Then
                    Exit Do
                End If

                counter2 = counter2 + 1

            Loop

            'Actualizar deuda en Diario de créditos
            deuda_inicial = DIARIO_CREDITOSDataGridView.Rows(0).Cells(9).Value
            DIARIO_CREDITOSDataGridView.Rows(0).Cells(11).Value = CDbl(CDbl(deuda_inicial) + CDbl(suma_punitorios)).ToString("F2")
            DIARIO_CREDITOSBindingSource.EndEdit()
            DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)

            'Modificar calificación a NEGATIVA en ABM
            ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & DIARIO_CREDITOSDataGridView.Rows(0).Cells(2).Value & "'"
            ABM_PERSONALDataGridView.Rows(0).Cells(15).Value = "NEGATIVA"
            ABM_PERSONALBindingSource.EndEdit()
            ABM_PERSONALTableAdapter.Update(ABMDataSet.ABM_PERSONAL)

        End If

        Me.Close()

    End Sub

End Class