Public Class Observaciones

    Public Property Operador As String
    Public Property Nivel As String

    Private Sub Observaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)
        Me.ABM_OBSTableAdapter.Fill(Me.ABMDataSet.ABM_OBS)
        TextBox30.Text = "Opera: " + Operador
        Label42.Text = DateTime.Now.ToString("dd/MM/yyyy")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox3.ReadOnly = False
        TextBox3.Select()
        Button1.Visible = True
        Button4.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newRow As DataRowView = DirectCast(ABM_OBSBindingSource.AddNew(), DataRowView)
        newRow("CUENTA") = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value
        newRow("OBSERVACION") = TextBox3.Text
        newRow("FECHA_ALTA") = DateTime.Now.ToString("dd/MM/yyyy")

        ABM_OBSBindingSource.EndEdit()
        ABM_OBSTableAdapter.Update(ABMDataSet.ABM_OBS)
        MessageBox.Show("Nueva observación cargada")

        TextBox3.Text = ""
        TextBox3.ReadOnly = True
        TextBox2.Select()
        Button4.Visible = True
        Button1.Visible = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        ABM_PERSONALBindingSource.Filter = "[DNI] = '" & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(6).Value & "'"
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength > 0 Then
            If IsNumeric(TextBox2.Text) Then
                ABM_PERSONALBindingSource.Filter = "[CUENTA] = '" & TextBox2.Text & "' Or [DNI] LIKE '" & TextBox2.Text & "%' Or [CUIL] LIKE '" & TextBox2.Text & "%'"
            Else
                ABM_PERSONALBindingSource.Filter = "[NOMBRE] LIKE '" & TextBox2.Text & "%' Or [APELLIDO] LIKE '" & TextBox2.Text & "%'"
            End If
            If ABM_PERSONALDataGridView.RowCount > 0 Then
                Panel8.Visible = True
                Busqueda()
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Busqueda2()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Busqueda2()
    End Sub

    Private Sub Busqueda()
        If TextBox2.TextLength > 0 Then
            If ABM_PERSONALDataGridView.RowCount > 0 Then
                ABM_OBSBindingSource.Filter = "[CUENTA] = '" & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value & "'"
            End If
        End If
    End Sub

    Private Sub Busqueda2()
        If TextBox2.Text = "" Then
            ABM_OBSBindingSource.Filter = "[FECHA_ALTA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA_ALTA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "#"
            Panel8.Visible = False
        Else
            ABM_OBSBindingSource.Filter = "[FECHA_ALTA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA_ALTA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [CUENTA] = '" & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value & "'"
        End If
    End Sub

    Private Sub ABM_OBSDataGridView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ABM_OBSDataGridView.CellEnter
        If ABM_OBSDataGridView.RowCount > 0 Then
            If IsDBNull(ABM_OBSDataGridView.Rows(ABM_OBSDataGridView.CurrentRow.Index).Cells(2).Value) Then
            Else
                TextBox1.Text = ABM_OBSDataGridView.Rows(ABM_OBSDataGridView.CurrentRow.Index).Cells(2).Value
                TextBox4.Text = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(2).Value & " " & ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(3).Value
            End If
        End If
    End Sub

    Private Sub Observaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Button4.PerformClick()
            Case Keys.Enter
                If Panel8.Visible = True Then
                    Busqueda()
                    Panel8.Visible = False
                Else
                    If Button1.Visible = True Then
                        Button1.PerformClick()
                    End If
                End If
            Case Keys.Down
                If Panel8.Visible = True Then
                    If Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex < Me.ABM_PERSONALDataGridView.RowCount - 1 Then
                        Me.ABM_PERSONALDataGridView.CurrentCell = Me.ABM_PERSONALDataGridView(Me.ABM_PERSONALDataGridView.CurrentCell.ColumnIndex, Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex + 1)
                    End If
                    e.Handled = True
                Else
                    If ABM_OBSDataGridView.RowCount = 0 Then
                    Else
                        If Me.ABM_OBSDataGridView.CurrentCell.RowIndex < Me.ABM_OBSDataGridView.RowCount - 1 Then
                            Me.ABM_OBSDataGridView.CurrentCell = Me.ABM_OBSDataGridView(Me.ABM_OBSDataGridView.CurrentCell.ColumnIndex, Me.ABM_OBSDataGridView.CurrentCell.RowIndex + 1)
                        End If
                    End If
                End If
                e.Handled = True
            Case Keys.Up
                If Panel8.Visible = True Then
                    If Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex > 0 Then
                        Me.ABM_PERSONALDataGridView.CurrentCell = Me.ABM_PERSONALDataGridView(Me.ABM_PERSONALDataGridView.CurrentCell.ColumnIndex, Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex - 1)
                    End If
                    e.Handled = True
                Else
                    If ABM_OBSDataGridView.RowCount = 0 Then
                    Else
                        If Me.ABM_OBSDataGridView.CurrentCell.RowIndex > 0 Then
                            Me.ABM_OBSDataGridView.CurrentCell = Me.ABM_OBSDataGridView(Me.ABM_OBSDataGridView.CurrentCell.ColumnIndex, Me.ABM_OBSDataGridView.CurrentCell.RowIndex - 1)
                        End If
                    End If
                End If
                e.Handled = True
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As Integer = MessageBox.Show("¿Guardar cambios?", "", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            ABM_OBSDataGridView.Rows(ABM_OBSDataGridView.CurrentRow.Index).Cells(2).Value = TextBox1.Text
            ABM_OBSBindingSource.EndEdit()
            ABM_OBSTableAdapter.Update(ABMDataSet.ABM_OBS)
        End If
    End Sub

    Private Sub ABM_PERSONALDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ABM_PERSONALDataGridView.CellClick
        Busqueda()
        Panel8.Visible = False
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button1.PerformClick()
        End Select
    End Sub
End Class