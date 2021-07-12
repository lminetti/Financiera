Public Class Contabilidad
    Public Property Operador As String
    Public Property Level As String
    Dim lastCodigo As String = ""
    Dim derecha As Integer = 0
    Dim lineasCierreT As String = ""
    Dim lineasCierre1 As String = ""
    Dim lineasCierre2 As String = ""
    Dim lineasCierre3 As String = ""
    Dim lineasCierre4 As String = ""
    Dim noFecha As Integer = 0
    Dim noFechaSaldo As Double = 0

    Private Sub Contabilidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Me.OPERADORESTableAdapter.Fill(Me.AJUSTESDataSet.OPERADORES)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        Me.ASIENTOSTableAdapter.Fill(Me.DATABASEDataSet.ASIENTOS)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        Me.CAJASTableAdapter.Fill(Me.DATABASEDataSet.CAJAS)

        TextBox30.Text = "Opera: " + Operador
        Label42.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox1.Text = "Opera: " + Operador
        Label8.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox9.Text = "Opera: " + Operador
        Label17.Text = DateTime.Now.ToString("dd/MM/yyyy")

        OPERADORESBindingSource.Filter = "[NOMBRE] = '" & Operador & "'"

        ComboBox1.Select()

        NuevoAsiento()

        If Level = "3" Then
            MostrarCajas()
        End If

    End Sub

    Private Sub Contabilidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Button1.PerformClick()
            Case Keys.F2
                Button2.PerformClick()
            Case Keys.F3
                Button3.PerformClick()
            Case Keys.F4
                Button4.PerformClick()
            Case Keys.F7
                Button11.PerformClick()
            Case Keys.F8
                If Panel6.Visible = True Then
                    Button12.PerformClick()
                Else
                    Button10.PerformClick()
                End If
            Case Keys.F9
                Button13.PerformClick()
            Case Keys.Escape
                If Panel6.Visible = True Then
                    Panel6.Visible = False
                Else
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.ControlDark
        ComboBox1.Select()
        NuevoAsiento()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = False
        Panel3.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.ControlDark
        Button1.BackColor = SystemColors.Control
        Balances()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = True
        Panel5.Visible = False
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.ControlDark
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control
        ConfigurarCajas()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = True
        Button4.BackColor = SystemColors.ControlDark
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control
        ConfigurarAsientos()
    End Sub

    Private Sub ConfigurarCajas()

        'Limpiar y cargar combobox
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox3.Items.Clear()
        ComboBox3.Text = "Seleccionar"
        If CAJASDataGridView.RowCount > 0 Then
            For Each rw In CAJASDataGridView.Rows
                ComboBox3.Items.Add((rw.Cells(2)).Value).ToString()
            Next
        End If

        lastCodigo = 0

        'Obtener código de caja
        CAJASDataGridView.Sort(CAJASDataGridView.Columns(1), System.ComponentModel.ListSortDirection.Descending)
        If CAJASDataGridView.RowCount = 0 Then
            lastCodigo = 0
        Else
            lastCodigo = CAJASDataGridView.Rows(0).Cells(1).Value
        End If
        lastCodigo = CDbl(lastCodigo) + 1
        TextBox3.Text = lastCodigo

        TextBox4.Focus()

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        TextBox5.Text = ComboBox3.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Borrar caja
        CAJASBindingSource.Filter = "[NOMBRE_CAJA] = '" & TextBox5.Text & "'"

        CAJASBindingSource.RemoveCurrent()

        CAJASBindingSource.EndEdit()
        CAJASTableAdapter.Update(DATABASEDataSet.CAJAS)
        Me.CAJASTableAdapter.Fill(Me.DATABASEDataSet.CAJAS)
        CAJASBindingSource.Filter = String.Empty

        CAJASDataGridView.Refresh()

        ConfigurarCajas()

        MessageBox.Show("Caja eliminada")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Crear caja
        If TextBox4.Text = "" Then
            MessageBox.Show("Por favor, ingresá un nombre de caja")
            Exit Sub
        End If

        Dim newRow As DataRowView = DirectCast(CAJASBindingSource.AddNew(), DataRowView)

        newRow("CODIGO") = TextBox3.Text
        newRow("NOMBRE_CAJA") = TextBox4.Text

        CAJASBindingSource.EndEdit()
        CAJASTableAdapter.Update(DATABASEDataSet.CAJAS)
        Me.CAJASTableAdapter.Fill(Me.DATABASEDataSet.CAJAS)
        CAJASBindingSource.Filter = String.Empty

        CAJASDataGridView.Refresh()

        ConfigurarCajas()

        MessageBox.Show("Nueva caja ingresada")
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button7.PerformClick()
        End Select
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button6.PerformClick()
        End Select
    End Sub

    Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox11.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox12.Focus()
        End Select
    End Sub

    Private Sub TextBox12_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox12.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox13.Focus()
        End Select
    End Sub

    Private Sub TextBox13_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox13.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox14.Focus()
        End Select
    End Sub

    Private Sub TextBox14_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox14.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox15.Focus()
        End Select
    End Sub

    Private Sub TextBox15_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox15.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox16.Focus()
        End Select
    End Sub

    Private Sub TextBox16_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox16.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox22.Focus()
        End Select
    End Sub

    Private Sub TextBox17_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox17.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox24.Focus()
        End Select
    End Sub

    Private Sub TextBox18_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox18.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox17.Focus()
        End Select
    End Sub

    Private Sub TextBox19_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox19.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox18.Focus()
        End Select
    End Sub

    Private Sub TextBox20_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox20.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox19.Focus()
        End Select
    End Sub

    Private Sub TextBox21_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox21.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox20.Focus()
        End Select
    End Sub

    Private Sub TextBox22_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox22.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox21.Focus()
        End Select
    End Sub

    Private Sub TextBox23_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox23.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button12.Select()
        End Select
    End Sub

    Private Sub TextBox24_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox24.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox23.Focus()
        End Select
    End Sub

    Private Sub ConfigurarAsientos()

        'Limpiar y cargar combobox
        TextBox7.Text = ""
        TextBox6.Text = ""
        ComboBox4.Items.Clear()
        ComboBox4.Text = "Seleccionar"
        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
        If ASIENTOSDataGridView.RowCount > 0 Then
            For Each rw In ASIENTOSDataGridView.Rows
                ComboBox4.Items.Add((rw.Cells(2)).Value).ToString()
            Next
        End If

        lastCodigo = 0

        'Obtener código de asiento
        ASIENTOSDataGridView.Sort(ASIENTOSDataGridView.Columns(1), System.ComponentModel.ListSortDirection.Descending)
        If ASIENTOSDataGridView.RowCount = 0 Then
            lastCodigo = 0
        Else
            lastCodigo = ASIENTOSDataGridView.Rows(0).Cells(1).Value
        End If
        lastCodigo = CDbl(lastCodigo) + 1
        TextBox8.Text = lastCodigo

        TextBox7.Focus()
        ECUACIONTextBox.Visible = False

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        TextBox6.Text = ComboBox4.Text
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Borrar asiento
        ASIENTOSBindingSource.Filter = "[NOMBRE_ASIENTO] = '" & TextBox6.Text & "'"

        ASIENTOSBindingSource.RemoveCurrent()

        ASIENTOSBindingSource.EndEdit()
        ASIENTOSTableAdapter.Update(DATABASEDataSet.ASIENTOS)
        Me.ASIENTOSTableAdapter.Fill(Me.DATABASEDataSet.ASIENTOS)
        ASIENTOSBindingSource.Filter = String.Empty

        ASIENTOSDataGridView.Refresh()

        ConfigurarAsientos()

        MessageBox.Show("Asiento eliminado")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Crear asiento
        If TextBox7.Text = "" Then
            MessageBox.Show("Por favor, ingresá un nombre de asiento")
            Exit Sub
        End If
        If CheckBox1.CheckState = CheckState.Unchecked And CheckBox2.CheckState = CheckState.Unchecked Then
            MessageBox.Show("Por favor, seleccioná si el asiento resta o suma")
            Exit Sub
        End If

        Dim Ecuacion As String = ""
        If CheckBox1.CheckState = CheckState.Checked Then
            Ecuacion = "RESTA"
        End If
        If CheckBox2.CheckState = CheckState.Checked Then
            Ecuacion = "SUMA"
        End If

        Dim newRow As DataRowView = DirectCast(ASIENTOSBindingSource.AddNew(), DataRowView)

        newRow("CODIGO") = TextBox8.Text
        newRow("NOMBRE_ASIENTO") = TextBox7.Text
        newRow("CAJA") = ""
        newRow("ECUACION") = Ecuacion

        ASIENTOSBindingSource.EndEdit()
        ASIENTOSTableAdapter.Update(DATABASEDataSet.ASIENTOS)
        Me.ASIENTOSTableAdapter.Fill(Me.DATABASEDataSet.ASIENTOS)
        ASIENTOSBindingSource.Filter = String.Empty

        ASIENTOSDataGridView.Refresh()

        ConfigurarAsientos()

        MessageBox.Show("Nuevo asiento ingresado")
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                CheckBox1.Select()
                CheckBox1.BackColor = Color.DimGray
                CheckBox2.BackColor = SystemColors.ControlDark
        End Select
    End Sub

    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                CheckBox2.Select()
                CheckBox2.BackColor = Color.DimGray
                CheckBox1.BackColor = SystemColors.ControlDark
        End Select
    End Sub

    Private Sub CheckBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button5.PerformClick()
        End Select
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button8.PerformClick()
        End Select
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        ASIENTOSBindingSource.Filter = "[NOMBRE_ASIENTO] = '" & ComboBox4.Text & "'"
        ECUACIONTextBox.Visible = True
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox2.Focus()
        End Select
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button9.PerformClick()
        End Select
    End Sub

    Private Sub MostrarCajas()
        Label46.Visible = True
        ComboBox7.Visible = True
        'Limpiar y cargar combobox
        ComboBox7.Items.Clear()
        ComboBox7.Text = "Seleccionar"
        If CAJASDataGridView.RowCount > 0 Then
            For Each rw In CAJASDataGridView.Rows
                ComboBox7.Items.Add((rw.Cells(2)).Value).ToString()
            Next
        End If
    End Sub

    Private Sub NuevoAsiento()
        'Limpiar y cargar combobox
        TextBox2.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Text = "Seleccionar"
        If ASIENTOSDataGridView.RowCount > 0 Then
            For Each rw In ASIENTOSDataGridView.Rows
                ComboBox1.Items.Add((rw.Cells(2)).Value).ToString()
            Next
        End If
        ComboBox1.Select()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ComboBox1.Text = "Seleccionar" Or ComboBox1.Text = "" Then
            MessageBox.Show("Por favor, seleccioná un asiento")
            Exit Sub
        End If

        ASIENTOSBindingSource.Filter = "[NOMBRE_ASIENTO] = '" & ComboBox1.Text & "'"
        Dim CajaAsignada As String = ""
        Dim Codigo As String = ""
        Dim Debe As String = "0"
        Dim Haber As String = "0"
        Dim Saldo As String = "0"
        Dim Ecuacion As String = ""

        If ASIENTOSDataGridView.RowCount > 0 Then
            If Level = "3" Then
                If ComboBox7.Text = "Seleccionar" Then
                    MessageBox.Show("Por favor, seleccione una caja")
                    Exit Sub
                Else
                    CajaAsignada = ComboBox7.Text
                End If
            Else
                CajaAsignada = OPERADORESDataGridView.Rows(0).Cells(5).Value
            End If
            Codigo = ASIENTOSDataGridView.Rows(0).Cells(1).Value
            Ecuacion = ASIENTOSDataGridView.Rows(0).Cells(4).Value
        End If

        Dim Valor As Integer = 0
        Dim SaldoAnterior As String = ""

        CONTABLEBindingSource.Filter = "[CAJA] = '" & CajaAsignada & "'"

        CONTABLEDataGridView.Sort(CONTABLEDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        If CONTABLEDataGridView.RowCount > 0 Then
            Valor = CONTABLEDataGridView.RowCount - 1
            SaldoAnterior = CONTABLEDataGridView.Rows(Valor).Cells(6).Value
        End If


        Dim a As String = TextBox2.Text
        Dim b As String = a.Replace(".", ",")

        TextBox2.Text = b

        If Ecuacion = "RESTA" Then
            'Resta
            If CONTABLEDataGridView.RowCount > 0 Then
                Haber = TextBox2.Text
                Debe = "0"
                Saldo = CDbl(SaldoAnterior) - CDbl(Haber)
            Else
                Haber = TextBox2.Text
                Debe = "0"
                Saldo = TextBox2.Text
            End If
        End If

        If Ecuacion = "SUMA" Then
            'Suma
            If CONTABLEDataGridView.RowCount > 0 Then
                Haber = "0"
                Debe = TextBox2.Text
                Saldo = CDbl(SaldoAnterior) + CDbl(Debe)
            Else
                Haber = "0"
                Debe = TextBox2.Text
                Saldo = TextBox2.Text
            End If
        End If

        Dim newRow As DataRowView = DirectCast(CONTABLEBindingSource.AddNew(), DataRowView)

        newRow("CODIGO") = Codigo
        newRow("CAJA") = CajaAsignada
        newRow("ASIENTO") = ComboBox1.Text
        newRow("DEBE") = Debe
        newRow("HABER") = Haber
        newRow("SALDO") = Saldo
        newRow("OPERADOR") = Operador
        newRow("FECHA") = Label42.Text

        CONTABLEBindingSource.EndEdit()
        CONTABLETableAdapter.Update(DATABASEDataSet.CONTABLE)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        CONTABLEBindingSource.Filter = String.Empty

        CONTABLEDataGridView.Refresh()

        ASIENTOSBindingSource.Filter = String.Empty
        NuevoAsiento()

        MessageBox.Show("Nuevo asiento ingresado")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            CheckBox2.CheckState = CheckState.Unchecked
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            CheckBox2.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            CheckBox1.CheckState = CheckState.Unchecked
        ElseIf CheckBox2.CheckState = CheckState.Unchecked Then
            CheckBox1.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub Balances()
        'Limpiar y cargar combobox
        CONTABLEBindingSource.Filter = "[CAJA] = ''"
        DateTimePicker1.Value = DateTime.Now.ToString("dd/MM/yyyy")
        DateTimePicker2.Value = DateTime.Now.ToString("dd/MM/yyyy")
        ComboBox2.Items.Clear()
        ComboBox2.Text = "Seleccionar"
        ComboBox6.Items.Clear()
        ComboBox6.Text = "Seleccionar"
        ComboBox6.Items.Add("TODOS")
        ComboBox6.Items.Add("COBRANZA")
        ComboBox6.Items.Add("PRESTAMO")
        If ASIENTOSDataGridView.RowCount > 0 Then
            For Each rw In ASIENTOSDataGridView.Rows
                ComboBox6.Items.Add((rw.Cells(2)).Value).ToString()
            Next
        End If
        If CAJASDataGridView.RowCount > 0 Then
            For Each rw In CAJASDataGridView.Rows
                ComboBox2.Items.Add((rw.Cells(2)).Value).ToString()
            Next
        End If
        ComboBox2.Select()
    End Sub

    Private Sub BuscarCONTABLE()
        If ComboBox6.Text = "TODOS" Then
            CONTABLEBindingSource.Filter = "[CAJA] = '" & ComboBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "#"
            CONTABLEDataGridView.Sort(CONTABLEDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim Saldo As String = "0,00"
            If CONTABLEDataGridView.RowCount > 0 Then
                Dim Valor As Integer = CONTABLEDataGridView.RowCount - 1
                Saldo = CONTABLEDataGridView.Rows(Valor).Cells(6).Value
            End If
            TextBox10.Text = "Saldo: $" + CDbl(Saldo).ToString("F2")
        Else
            CONTABLEBindingSource.Filter = "[CAJA] = '" & ComboBox2.Text & "' AND [FECHA] >= #" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "# AND [FECHA] <= #" & DateTimePicker2.Value.ToString("MM/dd/yyyy") & "# AND [ASIENTO] LIKE '" & ComboBox6.Text & "%'"
            TextBox10.Text = ""
        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        BuscarCONTABLE()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        BuscarCONTABLE()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        BuscarCONTABLE()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        BuscarCONTABLE()
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                ComboBox6.Select()
        End Select
    End Sub

    Private Sub ComboBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox6.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                DateTimePicker1.Select()
        End Select
    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If derecha = 2 Then
                    DateTimePicker2.Select()
                    derecha = 0
                Else
                    PasarValor()
                End If
        End Select
    End Sub

    Private Sub DateTimePicker2_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If derecha = 2 Then
                    ComboBox2.Select()
                    derecha = 0
                Else
                    PasarValor()
                End If
        End Select
    End Sub

    Private Sub PasarValor()
        SendKeys.Send("{RIGHT}")
        derecha = derecha + 1
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        If CONTABLEDataGridView.RowCount = 0 Then
            MessageBox.Show("No hay datos. Se va a tomar el saldo del último día con movimientos.")
            CONTABLEBindingSource.Filter = "[CAJA] = '" & ComboBox2.Text & "'"
            CONTABLEDataGridView.Sort(CONTABLEDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            noFecha = 1
        ElseIf TextBox10.Text = "Saldo: Sólo se calcula si están seleccionados todos los asientos." Then
            MessageBox.Show("No están seleccionados todos los asientos")
            Exit Sub
        End If

        'Buscar saldo

        Dim Saldo As String = "0,00"
        If CONTABLEDataGridView.RowCount > 0 Then
            Dim Valor As Integer = CONTABLEDataGridView.RowCount - 1
            Saldo = CONTABLEDataGridView.Rows(Valor).Cells(6).Value
            If noFecha = 1 Then
                noFechaSaldo = CDbl(Saldo)
            End If
        End If

        'Mostrar panel
        Panel6.Visible = True

        'Escribir saldo en el textbox
        TextBox26.Text = CDbl(Saldo).ToString("F2")

    End Sub

    Private Sub Arqueo()

        If TextBox11.Text = "" Or TextBox12.Text = "" Or TextBox13.Text = "" Or TextBox14.Text = "" Or TextBox15.Text = "" Or TextBox16.Text = "" Or TextBox17.Text = "" Or TextBox18.Text = "" Or TextBox19.Text = "" Or TextBox20.Text = "" Or TextBox21.Text = "" Or TextBox22.Text = "" Or TextBox23.Text = "" Or TextBox24.Text = "" Then
            Exit Sub
        End If

        Dim mil As Double = CDbl(TextBox11.Text) * 1000
        Dim quinientos As Double = CDbl(TextBox12.Text) * 500
        Dim doscientos As Double = CDbl(TextBox13.Text) * 200
        Dim cien As Double = CDbl(TextBox14.Text) * 100
        Dim cincuenta As Double = CDbl(TextBox15.Text) * 50
        Dim veinte As Double = CDbl(TextBox16.Text) * 20
        Dim diez As Double = CDbl(TextBox22.Text) * 10
        Dim cinco As Double = CDbl(TextBox21.Text) * 5
        Dim dos As Double = CDbl(TextBox20.Text) * 2
        Dim uno As Double = CDbl(TextBox19.Text) * 1
        Dim cerocincuenta As Double = CDbl(TextBox18.Text) * 0.5
        Dim ceroveinticinco As Double = CDbl(TextBox17.Text) * 0.25
        Dim cerodiez As Double = CDbl(TextBox24.Text) * 0.1
        Dim cerocerocinco As Double = CDbl(TextBox23.Text) * 0.05

        TextBox25.Text = CDbl(mil + quinientos + doscientos + cien + cincuenta + veinte + diez + cinco + dos + uno + cerocincuenta + ceroveinticinco + cerodiez + cerocerocinco).ToString("F2")

    End Sub

    Private Sub CierreCaja()
        Dim Value1 As String = ""
        Dim Value2 As String = ""
        Dim Value3 As String = ""
        Dim Value4 As String = ""
        Dim SumaCobranza As String = "0"
        Dim UltSaldo As String = "0"

        If noFecha = 1 Then

        Else
            CONTABLEDataGridView.CurrentCell = CONTABLEDataGridView.Rows(0).Cells(0)
            CONTABLEDataGridView.Rows(0).Selected = True

            Do
                Value1 = CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(3).Value
                Value2 = CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(4).Value
                Value3 = CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(5).Value
                Value4 = CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(6).Value

                If Value1 = "COBRANZA" Then
                    SumaCobranza = CDbl(CDbl(SumaCobranza) + CDbl(Value2)).ToString("F2")
                Else
                    If Value2 = "0" Then
                        UltSaldo = CDbl(CDbl(UltSaldo) - CDbl(Value3)).ToString("F2")
                    ElseIf Value3 = "0" Then
                        UltSaldo = CDbl(CDbl(UltSaldo) + CDbl(Value2)).ToString("F2")
                    End If
                    Value4 = UltSaldo
                    DataGridView1.Rows.Add(New String() {Value1, Value2, Value3, Value4})
                End If

                ' Selecciona la siguiente fila
                Dim counter As Integer = CONTABLEDataGridView.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = CONTABLEDataGridView.RowCount Then
                    Exit Do
                Else
                    nextRow = CONTABLEDataGridView.Rows(counter)
                End If
                CONTABLEDataGridView.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
            Loop

            Value4 = CDbl(CDbl(UltSaldo) + CDbl(SumaCobranza)).ToString("F2")
            If SumaCobranza = "0" Then
            Else
                DataGridView1.Rows.Add(New String() {"COBRANZAS", SumaCobranza, "0", Value4})
            End If

        End If

        Impresion_Cierre_Caja()
    End Sub

    Private Sub Impresion_Cierre_Caja()
        Cierre_Caja()
        Dim printControl = New Drawing.Printing.StandardPrintController
        PrintDocument1.PrintController = printControl
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cierre_Caja()

        Dim espacio1 As New String(" "c, Math.Round(100))
        Dim espacio2 As New String(" "c, Math.Round(120))
        Dim espacio3 As New String(" "c, Math.Round(140))

        'Titulo
        lineasCierreT &= "CIERRE DE: " & ComboBox2.Text
        lineasCierreT &= Environment.NewLine
        If noFecha = 1 Then
            lineasCierreT &= "FECHA: " & DateTime.Now.ToString("dd/MM/yyyy")
        Else
            lineasCierreT &= "FECHA: " & DateTimePicker1.Value.ToString("dd/MM/yyyy")
        End If

        'Columna1
        lineasCierre1 &= Environment.NewLine
        lineasCierre1 &= Environment.NewLine
        lineasCierre1 &= Environment.NewLine
        lineasCierre1 &= Environment.NewLine
        If noFecha = 1 Then
            lineasCierre1 &= "APERTURA DE CAJA: $" & noFechaSaldo.ToString("F2")
        Else
            If CONTABLEDataGridView.Rows(0).Cells(4).Value = "0" Then
                lineasCierre1 &= "APERTURA DE CAJA: $" & CDbl(CDbl(CONTABLEDataGridView.Rows(0).Cells(6).Value) + CDbl(CONTABLEDataGridView.Rows(0).Cells(5).Value)).ToString("F2")
            ElseIf CONTABLEDataGridView.Rows(0).Cells(5).Value = "0" Then
                lineasCierre1 &= "APERTURA DE CAJA: $" & CDbl(CDbl(CONTABLEDataGridView.Rows(0).Cells(6).Value) - CDbl(CONTABLEDataGridView.Rows(0).Cells(4).Value)).ToString("F2")
            End If
        End If
        lineasCierre1 &= Environment.NewLine
        lineasCierre1 &= Environment.NewLine
        lineasCierre1 &= "ASIENTO"
        lineasCierre1 &= Environment.NewLine
        lineasCierre1 &= Environment.NewLine

        If noFecha = 1 Then
        Else
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)
            DataGridView1.Rows(0).Selected = True
            Do
                lineasCierre1 &= DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
                lineasCierre1 &= Environment.NewLine
                ' Selecciona la siguiente fila
                Dim counter As Integer = DataGridView1.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = DataGridView1.RowCount Then
                    Exit Do
                Else
                    nextRow = DataGridView1.Rows(counter)
                End If
                DataGridView1.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
            Loop
        End If

        'Columna2
        lineasCierre2 &= Environment.NewLine
        lineasCierre2 &= Environment.NewLine
        lineasCierre2 &= Environment.NewLine
        lineasCierre2 &= Environment.NewLine
        lineasCierre2 &= Environment.NewLine
        lineasCierre2 &= Environment.NewLine
        lineasCierre2 &= espacio1 & "DEBE"
        lineasCierre2 &= Environment.NewLine
        lineasCierre2 &= Environment.NewLine

        If noFecha = 1 Then
        Else
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)
            DataGridView1.Rows(0).Selected = True
            Do
                lineasCierre2 &= espacio1 & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
                lineasCierre2 &= Environment.NewLine
                ' Selecciona la siguiente fila
                Dim counter As Integer = DataGridView1.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = DataGridView1.RowCount Then
                    Exit Do
                Else
                    nextRow = DataGridView1.Rows(counter)
                End If
                DataGridView1.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
            Loop
        End If


        'Columna3
        lineasCierre3 &= Environment.NewLine
        lineasCierre3 &= Environment.NewLine
        lineasCierre3 &= Environment.NewLine
        lineasCierre3 &= Environment.NewLine
        lineasCierre3 &= Environment.NewLine
        lineasCierre3 &= Environment.NewLine
        lineasCierre3 &= espacio2 & "HABER"
        lineasCierre3 &= Environment.NewLine
        lineasCierre3 &= Environment.NewLine

        If noFecha = 1 Then
        Else
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)
            DataGridView1.Rows(0).Selected = True
            Do
                lineasCierre3 &= espacio2 & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
                lineasCierre3 &= Environment.NewLine
                ' Selecciona la siguiente fila
                Dim counter As Integer = DataGridView1.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = DataGridView1.RowCount Then
                    Exit Do
                Else
                    nextRow = DataGridView1.Rows(counter)
                End If
                DataGridView1.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
            Loop
        End If

        'Columna4
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        'lineasCierre4 &= espacio3 & "SALDO"
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine

        If noFecha = 1 Then
        Else
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)
            DataGridView1.Rows(0).Selected = True
            Do
                'lineasCierre4 &= espacio3 & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
                lineasCierre4 &= espacio3
                lineasCierre4 &= Environment.NewLine
                ' Selecciona la siguiente fila
                Dim counter As Integer = DataGridView1.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = DataGridView1.RowCount Then
                    Exit Do
                Else
                    nextRow = DataGridView1.Rows(counter)
                End If
                DataGridView1.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
            Loop
        End If

        Dim saldo As String = ""
        Dim valor As Integer = 0
        If noFecha = 1 Then
            saldo = noFechaSaldo.ToString("F2")
        Else
            valor = CONTABLEDataGridView.RowCount - 1
            saldo = CONTABLEDataGridView.Rows(valor).Cells(6).Value
        End If

        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= "SALDO: $" & saldo
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= "FIRMA: _________________________________"
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= Environment.NewLine
        lineasCierre4 &= "ACLARACIÓN: ____________________________"


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

        'Título
        e.Graphics.MeasureString(Mid(lineasCierreT, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasCierreT.Substring(currentChar, chars), New Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, b, format)

        'Listado
        e.Graphics.MeasureString(Mid(lineasCierre1, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasCierre1.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)
        e.Graphics.MeasureString(Mid(lineasCierre2, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasCierre2.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)
        e.Graphics.MeasureString(Mid(lineasCierre3, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasCierre3.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)
        e.Graphics.MeasureString(Mid(lineasCierre4, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasCierre4.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)

        e.HasMorePages = False
        DataGridView1.Rows.Clear()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        If Level = "3" Then
        Else
            MessageBox.Show("Solo operadores nivel 3 pueden borrar asientos")
            Exit Sub
        End If

        If ComboBox6.Text = "TODOS" Then
        Else
            DateTimePicker2.Value = DateTime.Now.ToString("dd/MM/yyyy")
            ComboBox6.Text = "TODOS"
        End If

        Dim result As Integer = MessageBox.Show("¿Borrar asiento?", "", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
        End If

        'Si es el cobro de una cuota filtra primero el diario de cuotas y retrotrae la ecuación
        If CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(3).Value = "COBRANZA" Then
            Dim op As String = CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(10).Value
            Dim ct As String = CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(9).Value
            Dim cuotasiguiente As Integer = CInt(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(9).Value) + 1
            Dim valorcuotasiguiente As String = "0"

            'Filtrar para detectar valor de cuota siguiente
            DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & op & "' AND [CUOTA] = '" & cuotasiguiente & "'"
            If DIARIO_CUOTASDataGridView.RowCount > 0 Then
                valorcuotasiguiente = DIARIO_CUOTASDataGridView.Rows(0).Cells(11).Value
            Else
                'Si no existe la cuota siguiente (o sea, es última cuota), filtrar sólo por operación y dividir el pagaré por la cantidad de cuotas
                Dim cantCuotas As Integer = 0
                DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & op & "'"
                cantCuotas = DIARIO_CUOTASDataGridView.RowCount
                valorcuotasiguiente = CDbl(DIARIO_CUOTASDataGridView.Rows(0).Cells(4).Value) / cantCuotas
                valorcuotasiguiente = CDbl(valorcuotasiguiente).ToString("F2")
            End If

            'Filtrar para encontrar la cuota a retrotraer
            DIARIO_CUOTASBindingSource.Filter = "[OPERACION] = '" & op & "' AND [CUOTA] = '" & ct & "'"
            If DIARIO_CUOTASDataGridView.RowCount > 0 Then
                DIARIO_CUOTASDataGridView.Rows(0).Cells(6).Value = "0"
                DIARIO_CUOTASDataGridView.Rows(0).Cells(7).Value = ""
                DIARIO_CUOTASDataGridView.Rows(0).Cells(11).Value = valorcuotasiguiente
                DIARIO_CUOTASDataGridView.Rows(0).Cells(10).Value = "0"
                DIARIO_CUOTASDataGridView.Rows(0).Cells(9).Value = "0"
                DIARIO_CUOTASBindingSource.EndEdit()
                DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)
                MessageBox.Show("Valores retrotraídos en el Diario de Cuotas. Si la cuota estaba vencida, recomendamos calcular intereses manualmente.")
            End If
        End If

        Dim ultSaldo As Double = 0
        Dim ultValor As Double = 0
        Dim primeraFila As Integer = 0

        If CONTABLEDataGridView.CurrentRow.Index = 0 Then
            primeraFila = 1
        Else
            primeraFila = 0
        End If

        If primeraFila = 1 Then
            'Calculo saldo
            ultSaldo = CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(6).Value
            If CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(4).Value = "0" Then
                ultSaldo = ultSaldo + CDbl(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(5).Value)
            ElseIf CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(5).Value = "0" Then
                ultSaldo = ultSaldo - CDbl(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(4).Value)
            End If
            'Borro fila
            CONTABLEBindingSource.RemoveCurrent()
            CONTABLEBindingSource.EndEdit()
            CONTABLETableAdapter.Update(DATABASEDataSet.CONTABLE)
            'Asigno nuevos valores a fila siguiente
            If CONTABLEDataGridView.RowCount = 0 Then
            Else
                Do
                    If CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(4).Value = "0" Then
                        CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(6).Value = ultSaldo - CDbl(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(5).Value)
                    ElseIf CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(5).Value = "0" Then
                        CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(6).Value = ultSaldo + CDbl(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(4).Value)
                    End If
                    ultSaldo = CDbl(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(6).Value)
                    ' Selecciona la siguiente fila
                    Dim counter As Integer = CONTABLEDataGridView.CurrentRow.Index + 1
                    Dim nextRow As DataGridViewRow
                    If counter = CONTABLEDataGridView.RowCount Then
                        CONTABLEBindingSource.EndEdit()
                        CONTABLETableAdapter.Update(DATABASEDataSet.CONTABLE)
                        Exit Sub
                    Else
                        nextRow = CONTABLEDataGridView.Rows(counter)
                    End If
                    CONTABLEDataGridView.CurrentCell = nextRow.Cells(0)
                    nextRow.Selected = True
                Loop
            End If
        ElseIf primeraFila = 0 Then
            'Borro fila
            CONTABLEBindingSource.RemoveCurrent()
            CONTABLEBindingSource.EndEdit()
            CONTABLETableAdapter.Update(DATABASEDataSet.CONTABLE)

            'Recalculo saldos
            Dim saldo As Double = CDbl(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(6).Value)

            If CONTABLEDataGridView.RowCount = 1 Then
            Else
                Do
                    If CONTABLEDataGridView.CurrentRow.Index = 0 Then
                    Else
                        If CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(4).Value = "0" Then
                            CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(6).Value = saldo - CDbl(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(5).Value)
                        ElseIf CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(5).Value = "0" Then
                            CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(6).Value = saldo + CDbl(CONTABLEDataGridView.Rows(CONTABLEDataGridView.CurrentRow.Index).Cells(4).Value)
                        End If
                    End If

                    ' Selecciona la siguiente fila
                    Dim counter As Integer = CONTABLEDataGridView.CurrentRow.Index + 1
                    Dim nextRow As DataGridViewRow
                    If counter = CONTABLEDataGridView.RowCount Then
                        CONTABLEBindingSource.EndEdit()
                        CONTABLETableAdapter.Update(DATABASEDataSet.CONTABLE)
                        Exit Sub
                    Else
                        nextRow = CONTABLEDataGridView.Rows(counter)
                    End If
                    CONTABLEDataGridView.CurrentCell = nextRow.Cells(0)
                    nextRow.Selected = True
                Loop
            End If

        End If

        CONTABLEBindingSource.EndEdit()
        CONTABLETableAdapter.Update(DATABASEDataSet.CONTABLE)

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

        If TextBox11.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

        If TextBox12.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

        If TextBox13.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

        If TextBox14.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged

        If TextBox15.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged

        If TextBox16.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged

        If TextBox17.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged

        If TextBox18.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged

        If TextBox19.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged

        If TextBox20.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged

        If TextBox21.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged

        If TextBox22.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged

        If TextBox23.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs) Handles TextBox24.TextChanged

        If TextBox24.TextLength > 0 Then
            Arqueo()
        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        'Cierre de caja
        Dim diferencia As Double = 0
        If TextBox26.TextLength > 0 Then
            diferencia = CDbl(TextBox25.Text) - CDbl(TextBox26.Text)
        End If

        If diferencia > 10 Or diferencia < -10 Then
            MessageBox.Show("Hay una diferencia mayor a $10 entre el efectivo en caja y el saldo contable.")
            Exit Sub
        Else
            If noFecha = 1 Then
                BuscarCONTABLE()
            End If
            CierreCaja()
            Panel6.Visible = False
        End If

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        'Exportar a excel
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
    End Sub
    
End Class