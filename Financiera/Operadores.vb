Public Class Operadores
    Private Sub Operadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Me.CAJASTableAdapter.Fill(Me.DATABASEDataSet.CAJAS)
        Me.OPERADORESTableAdapter.Fill(Me.AJUSTESDataSet.OPERADORES)
    End Sub

    Private Sub Operadores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                Button1.PerformClick()
            Case Keys.F6
                Button2.PerformClick()
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TextBox2.ReadOnly = False
        TextBox3.ReadOnly = False
        TextBox4.ReadOnly = False

        Button2.Enabled = False
        Button1.Visible = False
        Button3.Visible = True

        ComboBox1.Items.Clear()
        ComboBox1.Text = "Seleccionar"
        If CAJASDataGridView.RowCount > 0 Then
            For Each rw In CAJASDataGridView.Rows
                ComboBox1.Items.Add((rw.Cells(2)).Value).ToString()
            Next
        End If

        TextBox2.Focus()

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                TextBox3.Focus()
        End Select

    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                TextBox4.Focus()
        End Select

    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                ComboBox1.Select()
        End Select

    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                Button3.PerformClick()
        End Select

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        OPERADORESDataGridView.Sort(OPERADORESDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        Dim lastCuenta As String = ""

        If OPERADORESDataGridView.RowCount = 0 Then
            lastCuenta = 0
        Else
            lastCuenta = OPERADORESDataGridView.Rows(0).Cells(0).Value
        End If

        lastCuenta = CDbl(lastCuenta) + 1

        Dim Found As Boolean = False
        For Each row As DataGridViewRow In OPERADORESDataGridView.Rows
            If Convert.ToString(row.Cells(2).Value) = TextBox3.Text Then
                MessageBox.Show("Ya existe un operador con esa clave")
                Exit Sub
            End If
        Next
        If Not Found Then

            If TextBox2.Text = "" Then
                MessageBox.Show("Ingrese un nombre de operador")
                Exit Sub
            End If
            If TextBox3.Text = "" Then
                MessageBox.Show("Ingrese una clave")
                Exit Sub
            End If
            If TextBox4.Text = "" Then
                MessageBox.Show("Ingrese el nivel")
                Exit Sub
            End If
            If ComboBox1.Text = "Seleccionar" Then
                MessageBox.Show("Seleccione una caja predeterminada")
                Exit Sub
            End If

            Dim newRow As DataRowView = DirectCast(OPERADORESBindingSource.AddNew(), DataRowView)

            newRow("CUENTA") = lastCuenta
            newRow("NOMBRE") = TextBox2.Text
            newRow("CLAVE") = TextBox3.Text
            newRow("NIVEL") = TextBox4.Text
            newRow("CAJA") = ComboBox1.Text

            Button2.Enabled = True
            Button1.Visible = True
            Button3.Visible = False
            TextBox2.ReadOnly = True
            TextBox3.ReadOnly = True
            TextBox4.ReadOnly = True
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox2.Focus()

            OPERADORESBindingSource.EndEdit()
            OPERADORESTableAdapter.Update(AJUSTESDataSet.OPERADORES)

            ComboBox1.Items.Clear()
            ComboBox1.Text = "Seleccionar"

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If OPERADORESDataGridView.RowCount > 0 Then
            OPERADORESBindingSource.RemoveCurrent()
            Try
                OPERADORESBindingSource.EndEdit()
                OPERADORESTableAdapter.Update(AJUSTESDataSet.OPERADORES)
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class