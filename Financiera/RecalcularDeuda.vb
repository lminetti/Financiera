Public Class RecalcularDeuda

    Private Sub RecalcularDeuda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        Recalcular()
    End Sub

    Private Sub Recalcular()
        Dim deuda As Double = 0
        DIARIO_CREDITOSDataGridView.Sort(DIARIO_CREDITOSDataGridView.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        DIARIO_CREDITOSDataGridView.CurrentCell = DIARIO_CREDITOSDataGridView.Rows(0).Cells(0)
        DIARIO_CREDITOSDataGridView.Rows(0).Selected = True

        Do

            Dim op As Integer = DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(1).Value
            DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & op & "'"
            deuda = 0

            For Each row As DataGridViewRow In DIARIO_CUOTASDataGridView.Rows
                If row.Cells(11).Value = "0,00" And row.Cells(10).Value = "0,00" Then
                    'Nada
                ElseIf row.Cells(10).Value = "0" Then
                    deuda = deuda + CDbl(row.Cells(11).Value)
                ElseIf row.Cells(10).Value IsNot "0" And row.Cells(10).Value IsNot "0,00" Then
                    deuda = deuda + CDbl(row.Cells(10).Value)
                End If
            Next

            'MessageBox.Show("Op." & DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(1).Value & " Deuda: " & deuda & " En Grid: " & DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(11).Value)

            DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(11).Value = deuda.ToString("F2")
            DIARIO_CREDITOSBindingSource.EndEdit()
            DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)

            ' Selecciona la siguiente fila

            Dim counter2 As Integer = DIARIO_CREDITOSDataGridView.CurrentRow.Index + 1
            Dim nextRow2 As DataGridViewRow
            If counter2 = DIARIO_CREDITOSDataGridView.RowCount Then
                Application.Exit()
                Me.Close()
                Exit Do
            Else
                nextRow2 = DIARIO_CREDITOSDataGridView.Rows(counter2)
            End If

            DIARIO_CREDITOSDataGridView.CurrentCell = nextRow2.Cells(0)
            nextRow2.Selected = True

        Loop
    End Sub
End Class