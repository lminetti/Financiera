Public Class Ajustes
    Private Sub Ajustes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)
        Me.INTERESESTableAdapter.Fill(Me.DATABASEDataSet.INTERESES)
        Me.COEFICIENTESTableAdapter.Fill(Me.DATABASEDataSet.COEFICIENTES)

        If AJUSTESDataGridView.RowCount > 0 Then
            ComboBox1.Text = ""
            ComboBox2.Text = ""

            TextBox1.Text = AJUSTESDataGridView.Rows(0).Cells(1).Value
            TextBox2.Text = AJUSTESDataGridView.Rows(0).Cells(2).Value
            TextBox3.Text = AJUSTESDataGridView.Rows(0).Cells(3).Value
            TextBox4.Text = AJUSTESDataGridView.Rows(0).Cells(6).Value
            TextBox5.Text = AJUSTESDataGridView.Rows(0).Cells(5).Value
            TextBox6.Text = AJUSTESDataGridView.Rows(0).Cells(7).Value
            TextBox7.Text = AJUSTESDataGridView.Rows(0).Cells(8).Value
            TextBox12.Text = AJUSTESDataGridView.Rows(0).Cells(10).Value
            TextBox13.Text = AJUSTESDataGridView.Rows(0).Cells(11).Value
            If IsDBNull(AJUSTESDataGridView.Rows(0).Cells(12).Value) Then
                TextBox14.Text = "1"
            Else
                TextBox14.Text = AJUSTESDataGridView.Rows(0).Cells(12).Value
            End If

            If AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE INSCRIPTO" Then
                ComboBox1.SelectedText = "RESPONSABLE INSCRIPTO"
            ElseIf AJUSTESDataGridView.Rows(0).Cells(4).Value = "RESPONSABLE MONOTRIBUTO" Then
                ComboBox1.SelectedText = "RESPONSABLE MONOTRIBUTO"
            End If

            If AJUSTESDataGridView.Rows(0).Cells(9).Value = "PRODUCTOS" Then
                ComboBox2.SelectedText = "PRODUCTOS"
            ElseIf AJUSTESDataGridView.Rows(0).Cells(9).Value = "SERVICIOS" Then
                ComboBox2.SelectedText = "SERVICIOS"
            ElseIf AJUSTESDataGridView.Rows(0).Cells(9).Value = "PRODUCTOS Y SERVICIOS" Then
                ComboBox2.SelectedText = "PRODUCTOS Y SERVICIOS"
            End If
            TextBox8.Focus()

            If IMPRESION_AUTTextBox.Text = "SI" Then
                CheckBox1.CheckState = CheckState.Checked
                CheckBox2.CheckState = CheckState.Unchecked
            Else
                CheckBox1.CheckState = CheckState.Unchecked
                CheckBox2.CheckState = CheckState.Checked
            End If

        Else
            TextBox13.ReadOnly = True
            TextBox13.Text = "1"
            TextBox14.ReadOnly = True
            TextBox14.Text = "1"
            TextBox1.Focus()
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Then
            Me.Close()
        Else
            Modificar()
        End If
    End Sub

    Private Sub Modificar()

        AJUSTESDataGridView.Rows(0).Cells(1).Value = TextBox1.Text
        AJUSTESDataGridView.Rows(0).Cells(2).Value = TextBox2.Text
        AJUSTESDataGridView.Rows(0).Cells(3).Value = TextBox3.Text
        AJUSTESDataGridView.Rows(0).Cells(4).Value = ComboBox1.Text
        AJUSTESDataGridView.Rows(0).Cells(5).Value = TextBox5.Text
        AJUSTESDataGridView.Rows(0).Cells(6).Value = TextBox4.Text
        AJUSTESDataGridView.Rows(0).Cells(7).Value = TextBox6.Text
        AJUSTESDataGridView.Rows(0).Cells(8).Value = TextBox7.Text
        AJUSTESDataGridView.Rows(0).Cells(9).Value = ComboBox2.Text
        AJUSTESDataGridView.Rows(0).Cells(10).Value = TextBox12.Text

        Me.AJUSTESBindingSource.EndEdit()
        AJUSTESTableAdapter.Update(AJUSTESDataSet.AJUSTES)
        Me.Close()

    End Sub

    Private Sub Ajustes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Panel1.Visible = True Then
                    Panel1.Visible = False
                ElseIf Panel2.Visible = True Then
                    Me.AJUSTESBindingSource.EndEdit()
                    AJUSTESTableAdapter.Update(AJUSTESDataSet.AJUSTES)
                    Panel2.Visible = False
                ElseIf Panel1.Visible = False And Panel2.Visible = False Then
                    If AJUSTESDataGridView.RowCount = 0 Then
                        Button6.PerformClick()
                    Else
                        Modificar()
                    End If
                End If
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox9.Text = "" Then
            MessageBox.Show("Ingrese cantidad de cuotas")
            Exit Sub
        End If
        If TextBox8.Text = "" Then
            MessageBox.Show("Ingrese coeficiente")
            Exit Sub
        End If
        If ComboBox3.Text = "Seleccionar" Then
            MessageBox.Show("Seleccione una calificación")
            Exit Sub
        End If
        If ComboBox4.Text = "Seleccionar" Then
            MessageBox.Show("Seleccione un tipo de coeficiente")
            Exit Sub
        End If
        Dim newRow As DataRowView = DirectCast(COEFICIENTESBindingSource.AddNew(), DataRowView)
        newRow("CUOTAS") = CInt(TextBox9.Text)
        newRow("COEFICIENTE") = TextBox8.Text
        newRow("CALIFICACION") = ComboBox3.Text
        If ComboBox4.Text = "CREDITO" Then
            newRow("TIPO") = "CREDITO"
        ElseIf ComboBox4.Text = "REFINANCIACIÓN" Then
            newRow("TIPO") = "REF"
        End If
        COEFICIENTESBindingSource.EndEdit()
        COEFICIENTESTableAdapter.Update(DATABASEDataSet.COEFICIENTES)
        MessageBox.Show("Coeficiente ingresado")
        TextBox9.Text = ""
        TextBox8.Text = ""
        Me.COEFICIENTESTableAdapter.Fill(Me.DATABASEDataSet.COEFICIENTES)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If INTERESESDataGridView.RowCount = 1 Then
            MessageBox.Show("Ya hay intereses registrados")
            Exit Sub
        End If
        If TextBox10.Text = "" Then
            MessageBox.Show("Ingrese días de atraso")
            Exit Sub
        End If
        If TextBox11.Text = "" Then
            MessageBox.Show("Ingrese interés")
            Exit Sub
        End If

        Dim newRow As DataRowView = DirectCast(INTERESESBindingSource.AddNew(), DataRowView)
        newRow("DIAS") = TextBox10.Text
        newRow("INTERES") = TextBox11.Text
        INTERESESBindingSource.EndEdit()
        INTERESESTableAdapter.Update(DATABASEDataSet.INTERESES)
        MessageBox.Show("Interés ingresado")
        TextBox11.Text = ""
        TextBox10.Text = ""
        Me.INTERESESTableAdapter.Fill(Me.DATABASEDataSet.INTERESES)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        INTERESESBindingSource.RemoveCurrent()
        INTERESESBindingSource.EndEdit()
        INTERESESTableAdapter.Update(DATABASEDataSet.INTERESES)
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox2.Focus()
        End Select
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox12.Focus()
        End Select
    End Sub

    Private Sub TextBox12_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox12.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox3.Focus()
        End Select
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                ComboBox1.Select()
        End Select
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox5.Focus()
        End Select
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox4.Focus()
        End Select
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox6.Focus()
        End Select
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox7.Focus()
        End Select
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                ComboBox2.Select()
        End Select
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button6.PerformClick()
        End Select
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        COEFICIENTESBindingSource.RemoveCurrent()
        COEFICIENTESBindingSource.EndEdit()
        COEFICIENTESTableAdapter.Update(DATABASEDataSet.COEFICIENTES)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Dim Pagare = New Pagare()
        Pagare.Show()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Panel2.Visible = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            CheckBox2.CheckState = CheckState.Unchecked
            IMPRESION_AUTTextBox.Text = "SI"
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            CheckBox2.CheckState = CheckState.Checked
            IMPRESION_AUTTextBox.Text = "NO"
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            CheckBox1.CheckState = CheckState.Unchecked
            IMPRESION_AUTTextBox.Text = "NO"
        ElseIf CheckBox2.CheckState = CheckState.Unchecked Then
            CheckBox1.CheckState = CheckState.Checked
            IMPRESION_AUTTextBox.Text = "SI"
        End If
    End Sub

End Class