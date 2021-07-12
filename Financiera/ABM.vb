Public Class ABM

    Dim derecha As Integer = 0
    Dim lastCuenta As String = ""
    Dim cuenta As Integer = 0
    Public Property Operador As String
    Public Property Level As String

    Private Sub ABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Me.DIARIO_CUOTASTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CUOTAS)
        Me.DIARIO_CREDITOSTableAdapter.Fill(Me.DATABASEDataSet.DIARIO_CREDITOS)
        Me.ABM_OBSTableAdapter.Fill(Me.ABMDataSet.ABM_OBS)
        Me.ABM_EXTRASTableAdapter.Fill(Me.ABMDataSet.ABM_EXTRAS)
        Me.ABM_LABORALTableAdapter.Fill(Me.ABMDataSet.ABM_LABORAL)
        Me.ABM_PERSONALTableAdapter.Fill(Me.ABMDataSet.ABM_PERSONAL)

        ABM_PERSONALDataGridView.AllowUserToAddRows = False
        ABM_LABORALDataGridView.AllowUserToAddRows = False
        ABM_EXTRASDataGridView.AllowUserToAddRows = False
        ABM_OBSDataGridView.AllowUserToAddRows = False

        TextBox11.Text = "Opera: " + Operador
        Label19.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox12.Text = "Opera: " + Operador
        Label18.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox16.Text = "Opera: " + Operador
        Label24.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox30.Text = "Opera: " + Operador
        Label42.Text = DateTime.Now.ToString("dd/MM/yyyy")

        TextBox2.Select()

        'Obtener número de cuenta
        ABM_PERSONALDataGridView.Sort(ABM_PERSONALDataGridView.Columns(1), System.ComponentModel.ListSortDirection.Descending)

        If ABM_PERSONALDataGridView.RowCount = 0 Then
            lastCuenta = 0
        Else
            lastCuenta = ABM_PERSONALDataGridView.Rows(0).Cells(1).Value
        End If

        lastCuenta = CDbl(lastCuenta) + 1

        TextBox1.Text = lastCuenta

        TextBox2.CharacterCasing = CharacterCasing.Upper
        TextBox3.CharacterCasing = CharacterCasing.Upper
        TextBox4.CharacterCasing = CharacterCasing.Upper
        TextBox5.CharacterCasing = CharacterCasing.Upper
        TextBox6.CharacterCasing = CharacterCasing.Upper
        TextBox7.CharacterCasing = CharacterCasing.Upper
        TextBox21.CharacterCasing = CharacterCasing.Upper
        TextBox20.CharacterCasing = CharacterCasing.Upper
        TextBox15.CharacterCasing = CharacterCasing.Upper
        TextBox17.CharacterCasing = CharacterCasing.Upper
        TextBox14.CharacterCasing = CharacterCasing.Upper
        TextBox13.CharacterCasing = CharacterCasing.Upper
        TextBox25.CharacterCasing = CharacterCasing.Upper
        TextBox24.CharacterCasing = CharacterCasing.Upper
        TextBox23.CharacterCasing = CharacterCasing.Upper
        TextBox19.CharacterCasing = CharacterCasing.Upper
        TextBox18.CharacterCasing = CharacterCasing.Upper
        TextBox27.CharacterCasing = CharacterCasing.Upper

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Close()
    End Sub

    Private Sub AMB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Button1.PerformClick()
            Case Keys.F2
                Button2.PerformClick()
            Case Keys.F3
                Button3.PerformClick()
            Case Keys.F4
                Button4.PerformClick()
            Case Keys.F5
                If Panel12.Visible = True Then
                    Button17.PerformClick()
                ElseIf Panel11.Visible = True Then
                    Button14.PerformClick()
                ElseIf Panel12.Visible = False And Panel11.Visible = False Then
                    Button5.PerformClick()
                End If
            Case Keys.F6
                If Panel13.Visible = True Then
                    Button18.PerformClick()
                Else
                    Button13.PerformClick()
                End If
            Case Keys.F7
                Button12.PerformClick()
            Case Keys.Right
                If Panel8.Visible = True Then
                    CambiarPanel()
                End If
            Case Keys.Left
                If Panel8.Visible = True Then
                    CambiarPanel2()
                End If
            Case Keys.Enter
                If Panel14.Visible = True Then
                    If Panel8.Visible = True Then
                        Buscar3()
                    ElseIf Panel13.Visible = True Then
                        Buscar4()
                    End If
                End If
            Case Keys.Down
                If Panel14.Visible = True Then
                    If Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex < Me.ABM_PERSONALDataGridView.RowCount - 1 Then
                        Me.ABM_PERSONALDataGridView.CurrentCell = Me.ABM_PERSONALDataGridView(Me.ABM_PERSONALDataGridView.CurrentCell.ColumnIndex, Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex + 1)
                    End If
                    e.Handled = True
                End If
            Case Keys.Up
                If Panel14.Visible = True Then
                    If Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex > 0 Then
                        Me.ABM_PERSONALDataGridView.CurrentCell = Me.ABM_PERSONALDataGridView(Me.ABM_PERSONALDataGridView.CurrentCell.ColumnIndex, Me.ABM_PERSONALDataGridView.CurrentCell.RowIndex - 1)
                    End If
                    e.Handled = True
                End If
            Case Keys.Escape
                If Panel14.Visible = True Then
                    Panel14.Visible = False
                End If
                If Panel8.Visible = True And Level = "2" Or Panel8.Visible = True And Level = "3" Then
                    Button10.PerformClick()
                ElseIf Panel8.Visible = True And Level = "1" Then
                    Button10.PerformClick()
                ElseIf Panel13.Visible = True Then
                    Panel13.Visible = False
                Else
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.ControlDark
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = False
        Panel3.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.ControlDark
        Button1.BackColor = SystemColors.Control
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = True
        Panel5.Visible = False
        Panel6.Visible = False
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.ControlDark
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        TextBox35.Text = TextBox26.Text

        System.IO.Directory.CreateDirectory("Z:\Base Clientes\" + TextBox2.Text + " " + TextBox3.Text + " " + TextBox4.Text)

        Dim dni As String = ""
        If TextBox4.Text = "" Then
            dni = TextBox5.Text
        End If
        If TextBox5.Text = "" Then
            dni = TextBox4.Text
        End If

        If System.IO.File.Exists("Z:\Base Clientes\DNI.jpg") Then
            PictureBox15.Image = Image.FromFile("Z:\Base Clientes\DNI.jpg")
            PictureBox15.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        If System.IO.File.Exists("Z:\Base Clientes\Recibo.jpg") Then
            PictureBox16.Image = Image.FromFile("Z:\Base Clientes\Recibo.jpg")
            PictureBox16.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        If System.IO.File.Exists("Z:\Base Clientes\Servicio.jpg") Then
            PictureBox17.Image = Image.FromFile("Z:\Base Clientes\Servicio.jpg")
            PictureBox17.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = True
        Panel6.Visible = False
        Button5.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.ControlDark
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control

        TextBox37.Text = TextBox35.Text
        Button9.Select()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = True
        Button5.BackColor = SystemColors.ControlDark
        Button4.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button1.BackColor = SystemColors.Control

        TextBox33.Focus()
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox3.Focus()
            Case Keys.Tab
                TextBox3.Focus()
        End Select
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                DateTimePicker1.Select()
            Case Keys.Tab
                DateTimePicker1.Select()
        End Select
    End Sub

    Private Sub PasarValor()
        SendKeys.Send("{RIGHT}")
        derecha = derecha + 1
    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If derecha = 2 Then
                    TextBox4.Focus()
                Else
                    PasarValor()
                End If
            Case Keys.Tab
                If derecha = 2 Then
                    TextBox4.Focus()
                Else
                    PasarValor()
                End If
        End Select
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox5.Focus()
            Case Keys.Tab
                TextBox5.Focus()
        End Select
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                CheckBox1.BackColor = Color.DimGray
                CheckBox1.Select()
            Case Keys.Tab
                CheckBox1.BackColor = Color.DimGray
                CheckBox1.Select()
        End Select
    End Sub

    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                CheckBox1.BackColor = SystemColors.ControlDark
                CheckBox2.BackColor = Color.DimGray
                CheckBox2.Select()
            Case Keys.Tab
                CheckBox1.BackColor = SystemColors.ControlDark
                CheckBox2.BackColor = Color.DimGray
                CheckBox2.Select()
        End Select
    End Sub

    Private Sub CheckBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                CheckBox2.BackColor = SystemColors.ControlDark
                TextBox6.Focus()
            Case Keys.Tab
                CheckBox2.BackColor = SystemColors.ControlDark
                TextBox6.Focus()
        End Select
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox7.Focus()
            Case Keys.Tab
                TextBox7.Focus()
        End Select
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox8.Focus()
            Case Keys.Tab
                TextBox8.Focus()
        End Select
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox9.Focus()
            Case Keys.Tab
                TextBox9.Focus()
        End Select
    End Sub

    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox10.Focus()
            Case Keys.Tab
                TextBox10.Focus()
        End Select
    End Sub

    Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox10.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox44.Focus()
            Case Keys.Tab
                TextBox44.Focus()
        End Select
    End Sub

    Private Sub TextBox44_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox44.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox45.Focus()
            Case Keys.Tab
                TextBox45.Focus()
        End Select
    End Sub

    Private Sub TextBox45_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox45.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                ComboBox3.Select()
            Case Keys.Tab
                ComboBox3.Select()
        End Select
    End Sub

    Private Sub ComboBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox3.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button6.PerformClick()
            Case Keys.Tab
                Button6.PerformClick()
        End Select
    End Sub

    ' CARGA ABM_PERSONAL

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim Found As Boolean = False
        For Each row As DataGridViewRow In ABM_PERSONALDataGridView.Rows
            If Convert.ToString(row.Cells(6).Value) = TextBox4.Text Or Convert.ToString(row.Cells(7).Value) = TextBox5.Text Then
                MessageBox.Show("Ya existe el cliente")
                Exit Sub
            End If
        Next
        If Not Found Then

            If TextBox2.Text = "" Then
                MessageBox.Show("Ingresá un nombre")
                Exit Sub
            End If
            If TextBox3.Text = "" Then
                MessageBox.Show("Ingresá un apellido")
                Exit Sub
            End If
            If TextBox4.Text = "" Then
                MessageBox.Show("Ingresá un DNI")
                Exit Sub
            End If
            If TextBox5.Text = "" Then
                MessageBox.Show("Ingresá un CUIL")
                Exit Sub
            End If
            If CheckBox1.CheckState = CheckState.Unchecked And CheckBox2.CheckState = CheckState.Unchecked Then
                MessageBox.Show("Ingresá el estado civil")
                Exit Sub
            End If
            If TextBox6.Text = "" Then
                MessageBox.Show("Ingresá una dirección")
                Exit Sub
            End If
            If TextBox7.Text = "" Then
                MessageBox.Show("Ingresá una localidad")
                Exit Sub
            End If
            If TextBox8.Text = "" Then
                MessageBox.Show("Ingresá un código postal")
                Exit Sub
            End If
            If TextBox9.Text = "" Then
                MessageBox.Show("Falta ingresar un teléfono")
                Exit Sub
            End If
            If TextBox10.Text = "" Then
                MessageBox.Show("Falta ingresar un teléfono")
                Exit Sub
            End If
            If TextBox44.Text = "" Then
                MessageBox.Show("Falta ingresar un mail")
                Exit Sub
            End If
            If TextBox45.Text = "" Then
                MessageBox.Show("Falta ingresar un mail")
                Exit Sub
            End If

            Dim newRow As DataRowView = DirectCast(ABM_PERSONALBindingSource.AddNew(), DataRowView)

            newRow("CUENTA") = TextBox1.Text
            newRow("NOMBRE") = TextBox2.Text
            newRow("APELLIDO") = TextBox3.Text
            newRow("FECHA_NACIMIENTO") = DateTimePicker1.Value.ToString("dd/MM/yyyy")
            If CheckBox1.CheckState = CheckState.Checked Then
                newRow("ESTADO_CIVIL") = "CASADO/A"
            End If
            If CheckBox2.CheckState = CheckState.Checked Then
                newRow("ESTADO_CIVIL") = "SOLTERO/A"
            End If
            newRow("DNI") = TextBox4.Text
            newRow("CUIL") = TextBox5.Text
            newRow("DIRECCION") = TextBox6.Text
            newRow("LOCALIDAD") = TextBox7.Text
            newRow("C_POSTAL") = TextBox8.Text
            newRow("TELEFONO1") = TextBox9.Text
            newRow("TELEFONO2") = TextBox10.Text
            newRow("FECHA_ALTA") = DateTime.Now.ToString("dd/MM/yyyy")
            newRow("OPERADOR") = Operador
            newRow("CALIFICACION") = "NEUTRAL"
            newRow("CONDICION_IVA") = ComboBox3.Text
            newRow("MAIL1") = TextBox44.Text
            newRow("MAIL2") = TextBox45.Text

            ABM_PERSONALBindingSource.EndEdit()
            ABM_PERSONALTableAdapter.Update(ABMDataSet.ABM_PERSONAL)
            Button2.PerformClick()

            TextBox22.Text = TextBox1.Text
            TextBox43.Select()
            derecha = 0

        End If

    End Sub

    Private Sub TextBox43_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox43.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox21.Focus()
            Case Keys.Tab
                TextBox21.Focus()
        End Select
    End Sub

    Private Sub TextBox21_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox21.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox20.Focus()
            Case Keys.Tab
                TextBox20.Focus()
        End Select
    End Sub

    Private Sub TextBox20_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox20.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox15.Focus()
            Case Keys.Tab
                TextBox15.Focus()
        End Select
    End Sub

    Private Sub TextBox15_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox15.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                DateTimePicker2.Select()
            Case Keys.Tab
                DateTimePicker2.Select()
        End Select
    End Sub

    Private Sub DateTimePicker2_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If derecha = 2 Then
                    TextBox17.Focus()
                Else
                    PasarValor()
                End If
            Case Keys.Tab
                If derecha = 2 Then
                    TextBox17.Focus()
                Else
                    PasarValor()
                End If
        End Select
    End Sub

    Private Sub TextBox17_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox17.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox14.Focus()
            Case Keys.Tab
                TextBox14.Focus()
        End Select
    End Sub

    Private Sub TextBox14_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox14.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox13.Focus()
            Case Keys.Tab
                TextBox13.Focus()
        End Select
    End Sub

    Private Sub TextBox13_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox13.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button7.PerformClick()
            Case Keys.Tab
                Button7.PerformClick()
        End Select
    End Sub

    ' CARGA ABM LABORAL

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If TextBox21.Text = "" Then
            MessageBox.Show("Ingresá una dirección")
            Exit Sub
        End If
        If TextBox20.Text = "" Then
            MessageBox.Show("Ingresá una localidad")
            Exit Sub
        End If
        If TextBox15.Text = "" Then
            MessageBox.Show("Ingresá un código postal")
            Exit Sub
        End If
        If TextBox17.Text = "" Then
            MessageBox.Show("Ingresá un ingreso mensual")
            Exit Sub
        End If
        If TextBox14.Text = "" Then
            MessageBox.Show("Falta ingresar un teléfono")
            Exit Sub
        End If
        If TextBox13.Text = "" Then
            MessageBox.Show("Falta ingresar un teléfono")
            Exit Sub
        End If

        Dim newRow As DataRowView = DirectCast(ABM_LABORALBindingSource.AddNew(), DataRowView)

        newRow("CUENTA") = TextBox22.Text
        newRow("NOMBRE_EMPRESA") = TextBox43.Text
        newRow("DIRECCION") = TextBox21.Text
        newRow("LOCALIDAD") = TextBox20.Text
        newRow("C_POSTAL") = TextBox15.Text
        newRow("INICIO_ACTIVIDADES") = DateTimePicker2.Value.ToString("dd/MM/yyyy")
        newRow("INGRESO_MENSUAL") = TextBox17.Text
        newRow("TELEFONO1") = TextBox14.Text
        newRow("TELEFONO2") = TextBox13.Text
        newRow("FECHA_ALTA") = DateTime.Now.ToString("dd/MM/yyyy")

        ABM_LABORALBindingSource.EndEdit()
        ABM_LABORALTableAdapter.Update(ABMDataSet.ABM_LABORAL)
        Button3.PerformClick()

        TextBox26.Text = TextBox22.Text
        TextBox25.Select()
        derecha = 0

    End Sub

    Private Sub TextBox25_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox25.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox24.Focus()
            Case Keys.Tab
                TextBox24.Focus()
        End Select
    End Sub

    Private Sub TextBox24_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox24.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox23.Focus()
            Case Keys.Tab
                TextBox23.Focus()
        End Select
    End Sub

    Private Sub TextBox23_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox23.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox19.Focus()
            Case Keys.Tab
                TextBox19.Focus()
        End Select
    End Sub

    Private Sub TextBox19_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox19.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox18.Focus()
            Case Keys.Tab
                TextBox18.Focus()
        End Select
    End Sub

    Private Sub TextBox18_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox18.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox27.Focus()
            Case Keys.Tab
                TextBox27.Focus()
        End Select
    End Sub

    Private Sub TextBox27_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox27.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button8.PerformClick()
            Case Keys.Tab
                Button8.PerformClick()
        End Select
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox25.Text = "" Then
            MessageBox.Show("Ingresá un nombre")
            Exit Sub
        End If
        If TextBox24.Text = "" Then
            MessageBox.Show("Ingresá un apellido")
            Exit Sub
        End If
        If TextBox23.Text = "" Then
            MessageBox.Show("Ingresá una dirección")
            Exit Sub
        End If
        If TextBox19.Text = "" Then
            MessageBox.Show("Ingresá una localidad")
            Exit Sub
        End If
        If TextBox18.Text = "" Then
            MessageBox.Show("Ingresá el parentesco")
            Exit Sub
        End If
        If TextBox27.Text = "" Then
            MessageBox.Show("Falta ingresar un teléfono")
            Exit Sub
        End If

        Dim result As Integer = MessageBox.Show("¿Desea agregar otro contacto extra?", "", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            ABMExtras()
            ABMExtras_Guardar()
            Button4.PerformClick()
        ElseIf result = DialogResult.Yes Then
            ABMExtras()
            ABMExtras_Guardar()
            ABMExtras_TextBox()
            ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & TextBox26.Text & "'"
            ListBox1.Items.Clear()
            If ABM_EXTRASDataGridView.RowCount > 0 Then
                For Each rw In ABM_EXTRASDataGridView.Rows
                    Dim nombre As String = rw.Cells(2).Value
                    Dim apellido As String = rw.Cells(3).Value
                    Dim nombreapellido As String = nombre & " " & apellido & "."
                    ListBox1.Items.Add(nombreapellido)
                Next
            End If
            TextBox25.Select()
            ABM_EXTRASBindingSource.Filter = String.Empty
        End If
    End Sub

    'AGREGA ABM_EXTRAS
    Private Sub ABMExtras()

        If TextBox25.Text = "" Then
            MessageBox.Show("Ingresá un nombre")
            Exit Sub
        End If
        If TextBox24.Text = "" Then
            MessageBox.Show("Ingresá un apellido")
            Exit Sub
        End If
        If TextBox23.Text = "" Then
            MessageBox.Show("Ingresá una dirección")
            Exit Sub
        End If
        If TextBox19.Text = "" Then
            MessageBox.Show("Ingresá una localidad")
            Exit Sub
        End If
        If TextBox18.Text = "" Then
            MessageBox.Show("Ingresá el parentesco")
            Exit Sub
        End If
        If TextBox27.Text = "" Then
            MessageBox.Show("Falta ingresar un teléfono")
            Exit Sub
        End If

        Dim newRow As DataRowView = DirectCast(ABM_EXTRASBindingSource.AddNew(), DataRowView)

        newRow("CUENTA") = TextBox26.Text
        newRow("NOMBRE") = TextBox25.Text
        newRow("APELLIDO") = TextBox24.Text
        newRow("DIRECCION") = TextBox23.Text
        newRow("LOCALIDAD") = TextBox19.Text
        newRow("PARENTESCO") = TextBox27.Text
        newRow("TELEFONO") = TextBox18.Text
        newRow("FECHA_ALTA") = DateTime.Now.ToString("dd/MM/yyyy")

    End Sub

    Private Sub ABMExtras_Guardar()

        ABM_EXTRASBindingSource.EndEdit()
        ABM_EXTRASTableAdapter.Update(ABMDataSet.ABM_EXTRAS)

    End Sub

    Private Sub ABMExtras_TextBox()

        TextBox25.Text = ""
        TextBox24.Text = ""
        TextBox23.Text = ""
        TextBox19.Text = ""
        TextBox18.Text = ""
        TextBox27.Text = ""

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)

        Dim openFileDlg As New OpenFileDialog
        With openFileDlg
            .InitialDirectory = "Z:\Documentos\" + TextBox35.Text
            .Filter = "Word document|*.docx;*.doc|All files|*.*"
        End With
        ' --
        Dim fileName As String = ""
        If (openFileDlg.ShowDialog = DialogResult.OK) Then
            fileName = openFileDlg.FileName
            System.Diagnostics.Process.Start(fileName)
        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button5.PerformClick()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        Dim newRow As DataRowView = DirectCast(ABM_OBSBindingSource.AddNew(), DataRowView)

        newRow("CUENTA") = TextBox37.Text
        newRow("OBSERVACION") = TextBox33.Text
        newRow("FECHA_ALTA") = DateTime.Now.ToString("dd/MM/yyyy")

        ABM_OBSBindingSource.EndEdit()
        ABM_OBSTableAdapter.Update(ABMDataSet.ABM_OBS)

        Dim result As Integer = MessageBox.Show("¿Desea dar de alta a otro cliente?", "", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Me.Close()
        ElseIf result = DialogResult.Yes Then
            Dim ABM = New ABM()
            ABM.Operador = Operador
            ABM.Show()
            Me.Close()
        End If

    End Sub

    Private Sub TextBox33_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox33.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button11.PerformClick()
            Case Keys.Tab
                Button11.PerformClick()
        End Select
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Panel8.Visible = True
        Button10.Visible = True
        ABM_PERSONALBindingSource.Filter = "[DNI] = '" & TextBox28.Text & "' OR [CUIL] = '" & TextBox28.Text & "'"
        TextBox28.Select()
    End Sub

    Private Sub PictureBox20_Click(sender As Object, e As EventArgs) Handles PictureBox20.Click
        ABM_PERSONALBindingSource.EndEdit()
        ABM_PERSONALTableAdapter.Update(ABMDataSet.ABM_PERSONAL)
        ABM_LABORALBindingSource.EndEdit()
        ABM_LABORALTableAdapter.Update(ABMDataSet.ABM_LABORAL)
        ABM_EXTRASBindingSource.EndEdit()
        ABM_EXTRASTableAdapter.Update(ABMDataSet.ABM_EXTRAS)
        ABM_OBSBindingSource.EndEdit()
        ABM_OBSTableAdapter.Update(ABMDataSet.ABM_OBS)
        Panel8.Visible = False
        TextBox28.Focus()
        TextBox28.Select()
        If Panel14.Visible = True Then
            Panel14.Visible = False
        End If
        Button10.Visible = False
    End Sub

    Private Sub PictureBox21_Click(sender As Object, e As EventArgs) Handles PictureBox21.Click
        CambiarPanel()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        'Nuevo contacto
        TextBox32.Visible = True
        TextBox34.Visible = True
        TextBox36.Visible = True
        TextBox38.Visible = True
        TextBox39.Visible = True
        TextBox40.Visible = True

        Button15.Visible = True
        Button14.Visible = False
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        'Finalizar carga de nuevo contacto
        If TextBox32.Text = "" Then
            MessageBox.Show("Ingresá un nombre")
            Exit Sub
        End If
        If TextBox34.Text = "" Then
            MessageBox.Show("Ingresá un apellido")
            Exit Sub
        End If
        If TextBox36.Text = "" Then
            MessageBox.Show("Ingresá una dirección")
            Exit Sub
        End If
        If TextBox38.Text = "" Then
            MessageBox.Show("Ingresá una localidad")
            Exit Sub
        End If
        If TextBox39.Text = "" Then
            MessageBox.Show("Ingresá el parentesco")
            Exit Sub
        End If
        If TextBox40.Text = "" Then
            MessageBox.Show("Falta ingresar un teléfono")
            Exit Sub
        End If

        Dim newRow As DataRowView = DirectCast(ABM_EXTRASBindingSource.AddNew(), DataRowView)

        newRow("CUENTA") = cuenta
        newRow("NOMBRE") = TextBox32.Text
        newRow("APELLIDO") = TextBox34.Text
        newRow("DIRECCION") = TextBox36.Text
        newRow("LOCALIDAD") = TextBox38.Text
        newRow("PARENTESCO") = TextBox39.Text
        newRow("TELEFONO") = TextBox40.Text
        newRow("FECHA_ALTA") = DateTime.Now.ToString("dd/MM/yyyy")

        ABM_EXTRASBindingSource.EndEdit()
        ABM_EXTRASTableAdapter.Update(ABMDataSet.ABM_EXTRAS)
        MessageBox.Show("¡Nuevo contacto ingresado!")
        Button15.Visible = False
        Button14.Visible = True
        TextBox32.Visible = False
        TextBox34.Visible = False
        TextBox36.Visible = False
        TextBox38.Visible = False
        TextBox39.Visible = False
        TextBox40.Visible = False
        Buscar()
    End Sub

    Private Sub TextBox28_TextChanged(sender As Object, e As EventArgs) Handles TextBox28.TextChanged
        Buscar()
    End Sub

    Private Sub Buscar3()
        If ABM_PERSONALDataGridView.RowCount > 0 Then
            cuenta = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value
            ABM_LABORALBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
            ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
            ABM_OBSBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"

            If FECHA_NACIMIENTOTextBox.Text = "" Then
            Else
                If FECHA_NACIMIENTOTextBox.Text IsNot "" Then
                    DateTimePicker3.Value = FECHA_NACIMIENTOTextBox.Text
                End If
                If ESTADO_CIVILTextBox.Text = "CASADO/A" Then
                    CheckBox3.CheckState = CheckState.Checked
                Else
                    CheckBox4.CheckState = CheckState.Unchecked
                End If
                If INICIO_ACTIVIDADESTextBox.Text IsNot "" Then
                    DateTimePicker4.Value = INICIO_ACTIVIDADESTextBox.Text
                End If
                If ABM_EXTRASDataGridView.RowCount > 0 Then
                    For Each rw In ABM_EXTRASDataGridView.Rows
                        ComboBox1.Items.Add((rw.Cells(2)).Value).ToString()
                    Next
                End If
                If ABM_OBSDataGridView.RowCount > 0 Then
                    For Each rw In ABM_OBSDataGridView.Rows
                        ComboBox2.Items.Add((rw.Cells(0)).Value & " " & (rw.Cells(3)).Value).ToString()
                    Next
                End If
            End If
            Panel14.Visible = False
        End If
    End Sub

    Private Sub ABM_PERSONALDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ABM_PERSONALDataGridView.CellDoubleClick

        If Panel12.Visible = True Then
            Buscar3()
        ElseIf Panel13.Visible = True Then
            Buscar4()
        End If

    End Sub

    Private Sub Buscar()

        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox1.Text = "Seleccionar"
        ComboBox2.Text = "Seleccionar"
        If IsNumeric(TextBox28.Text) Then
            ABM_PERSONALBindingSource.Filter = "[DNI] LIKE '" & TextBox28.Text & "%' OR [CUIL] LIKE '" & TextBox28.Text & "%' OR [CUENTA] = '" & TextBox28.Text & "'"
        Else
            ABM_PERSONALBindingSource.Filter = "[NOMBRE] LIKE '" & TextBox28.Text & "%' OR [APELLIDO] LIKE '" & TextBox28.Text & "%'"
        End If

        If ABM_EXTRASDataGridView.RowCount > 0 And TextBox28.TextLength > 0 Then
            Panel14.Visible = True
        End If

        If Panel14.Visible = True Then
        Else
            If ABM_PERSONALDataGridView.RowCount > 0 Then
                cuenta = ABM_PERSONALDataGridView.Rows(0).Cells(1).Value
                ABM_LABORALBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
                ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
                ABM_OBSBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"

                If FECHA_NACIMIENTOTextBox.Text = "" Then
                Else
                    If FECHA_NACIMIENTOTextBox.Text IsNot "" Then
                        DateTimePicker3.Value = FECHA_NACIMIENTOTextBox.Text
                    End If
                    If ESTADO_CIVILTextBox.Text = "CASADO/A" Then
                        CheckBox3.CheckState = CheckState.Checked
                    Else
                        CheckBox4.CheckState = CheckState.Unchecked
                    End If
                    If INICIO_ACTIVIDADESTextBox.Text IsNot "" Then
                        DateTimePicker4.Value = INICIO_ACTIVIDADESTextBox.Text
                    End If
                    If ABM_EXTRASDataGridView.RowCount > 0 Then
                        For Each rw In ABM_EXTRASDataGridView.Rows
                            ComboBox1.Items.Add((rw.Cells(2)).Value).ToString()
                        Next
                    End If
                    If ABM_OBSDataGridView.RowCount > 0 Then
                        For Each rw In ABM_OBSDataGridView.Rows
                            ComboBox2.Items.Add((rw.Cells(0)).Value & " " & (rw.Cells(3)).Value).ToString()
                        Next
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = CheckState.Checked Then
            CheckBox4.CheckState = CheckState.Unchecked
            ESTADO_CIVILTextBox.Text = "CASADO/A"
        ElseIf CheckBox3.CheckState = CheckState.Unchecked Then
            CheckBox4.CheckState = CheckState.Checked
            ESTADO_CIVILTextBox.Text = "SOLTERO/A"
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.CheckState = CheckState.Checked Then
            CheckBox3.CheckState = CheckState.Unchecked
            ESTADO_CIVILTextBox.Text = "SOLTERO/A"
        ElseIf CheckBox4.CheckState = CheckState.Unchecked Then
            CheckBox3.CheckState = CheckState.Checked
            ESTADO_CIVILTextBox.Text = "CASADO/A"
        End If
    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged
        'CAMBIAR INICIO DE ACTIVIDADES
        INICIO_ACTIVIDADESTextBox.Text = DateTimePicker4.Value.ToString("dd/MM/yyyy")
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        'CAMBIAR FECHA DE NACIMIENTO
        FECHA_NACIMIENTOTextBox.Text = DateTimePicker3.Value.ToString("dd/MM/yyyy")
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'CAMBIAR OBSERVACIÓN
        If ComboBox2.Text = "Seleccionar" Then
        Else
            ABM_OBSBindingSource.Filter = "[CUENTA] = '" & cuenta & "' AND [ID] = '" & ComboBox2.Text.Substring(0, ComboBox2.Text.IndexOf(" ")) & "'"
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'CAMBIAR CONTACTO
        If ComboBox1.Text = "Seleccionar" Then
        Else
            ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & cuenta & "' AND [NOMBRE] = '" & ComboBox1.Text & "'"
        End If
    End Sub

    Private Sub TextBox32_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox32.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox34.Focus()
            Case Keys.Tab
                TextBox34.Focus()
        End Select
    End Sub

    Private Sub TextBox34_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox34.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox36.Focus()
            Case Keys.Tab
                TextBox36.Focus()
        End Select
    End Sub

    Private Sub TextBox36_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox36.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox38.Focus()
            Case Keys.Tab
                TextBox38.Focus()
        End Select
    End Sub

    Private Sub TextBox38_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox38.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox39.Focus()
            Case Keys.Tab
                TextBox39.Focus()
        End Select
    End Sub

    Private Sub TextBox39_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox39.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TextBox40.Focus()
            Case Keys.Tab
                TextBox40.Focus()
        End Select
    End Sub

    Private Sub TextBox40_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox40.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button15.PerformClick()
            Case Keys.Tab
                Button15.PerformClick()
        End Select
    End Sub

    Private Sub TextBox41_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox41.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button16.PerformClick()
            Case Keys.Tab
                Button16.PerformClick()
        End Select
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        'Nueva observación
        TextBox41.Visible = True
        Button16.Visible = True
        Button17.Visible = False
        TextBox41.Focus()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        'Guardar nueva observación
        Dim newRow As DataRowView = DirectCast(ABM_OBSBindingSource.AddNew(), DataRowView)

        newRow("CUENTA") = cuenta
        newRow("OBSERVACION") = TextBox41.Text
        newRow("FECHA_ALTA") = DateTime.Now.ToString("dd/MM/yyyy")

        ABM_OBSBindingSource.EndEdit()
        ABM_OBSTableAdapter.Update(ABMDataSet.ABM_OBS)
        MessageBox.Show("¡Nuevo observación ingresada!")
        Button16.Visible = False
        Button17.Visible = True
        TextBox41.Visible = False
        Buscar()
    End Sub

    Private Sub CambiarPanel()
        If Panel9.Visible = True Then
            Panel12.Visible = False
            Panel9.Visible = False
            Panel11.Visible = False
            TextBox31.Text = "Datos laborales"
            Panel10.Visible = True
            If INICIO_ACTIVIDADESTextBox.Text = "" Then
            Else
                DateTimePicker4.Value = INICIO_ACTIVIDADESTextBox.Text
            End If
        ElseIf Panel10.Visible = True Then
            Panel12.Visible = False
            Panel10.Visible = False
            Panel9.Visible = False
            TextBox31.Text = "Contactos extra"
            Panel11.Visible = True
        ElseIf Panel11.Visible = True Then
            Panel10.Visible = False
            Panel11.Visible = False
            Panel9.Visible = False
            TextBox31.Text = "Observaciones"
            Panel12.Visible = True
            If FECHA_ALTATextBox.Text = "" Then
            Else
                DateTimePicker5.Value = FECHA_ALTATextBox.Text
            End If
        ElseIf Panel12.Visible = True Then
            Panel12.Visible = False
            Panel10.Visible = False
            Panel11.Visible = False
            TextBox31.Text = "Datos personales"
            Panel9.Visible = True
        End If
    End Sub

    Private Sub CambiarPanel2()
        If Panel9.Visible = True Then
            Panel10.Visible = False
            Panel11.Visible = False
            Panel9.Visible = False
            TextBox31.Text = "Observaciones"
            Panel12.Visible = True
            If FECHA_ALTATextBox.Text = "" Then
            Else
                DateTimePicker5.Value = FECHA_ALTATextBox.Text
            End If
        ElseIf Panel12.Visible = True Then
            Panel12.Visible = False
            Panel10.Visible = False
            Panel9.Visible = False
            TextBox31.Text = "Contactos extra"
            Panel11.Visible = True
        ElseIf Panel11.Visible = True Then
            Panel12.Visible = False
            Panel9.Visible = False
            Panel11.Visible = False
            TextBox31.Text = "Datos laborales"
            Panel10.Visible = True
            If INICIO_ACTIVIDADESTextBox.Text = "" Then
            Else
                DateTimePicker4.Value = INICIO_ACTIVIDADESTextBox.Text
            End If
        ElseIf Panel10.Visible = True Then
            Panel12.Visible = False
            Panel10.Visible = False
            Panel11.Visible = False
            TextBox31.Text = "Datos personales"
            Panel9.Visible = True
        End If
    End Sub

    Private Sub TextBox42_TextChanged(sender As Object, e As EventArgs) Handles TextBox42.TextChanged
        Buscar2()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If Level = "3" Then
            ABM_PERSONALBindingSource.Filter = "[DNI] = '" & TextBox28.Text & "' OR [CUIL] = '" & TextBox28.Text & "'"
            Panel13.Visible = True
            TextBox42.Select()
        Else
            MessageBox.Show("Acceso restringido para este nivel")
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        ABM_PERSONALBindingSource.RemoveCurrent()
        ABM_LABORALBindingSource.RemoveCurrent()
        ABM_OBSBindingSource.RemoveCurrent()
        ABM_EXTRASBindingSource.RemoveCurrent()

        'Borrar contactos extras
        Do
            If ABM_EXTRASDataGridView.RowCount = 0 Then
                Exit Do
            Else
                Dim currentRow As Integer = ABM_EXTRASDataGridView.CurrentRow.Index
                ' Selecciona la siguiente fila
                Dim counter As Integer = ABM_EXTRASDataGridView.CurrentRow.Index + 1
                If ABM_EXTRASDataGridView.RowCount = 1 Then
                    counter = ABM_EXTRASDataGridView.CurrentRow.Index
                End If
                Dim nextRow As DataGridViewRow
                nextRow = ABM_EXTRASDataGridView.Rows(counter)
                ABM_EXTRASDataGridView.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True

                ABM_EXTRASBindingSource.RemoveCurrent()

                If ABM_EXTRASDataGridView.RowCount = 1 Then
                    Exit Do
                End If

            End If
        Loop

        'Borrar observaciones
        Do
            If ABM_OBSDataGridView.RowCount = 0 Then
                Exit Do
            Else
                ' Selecciona la siguiente fila               
                Dim currentRow As Integer = ABM_OBSDataGridView.CurrentRow.Index
                Dim counter As Integer = ABM_OBSDataGridView.CurrentRow.Index + 1
                If ABM_OBSDataGridView.RowCount = 1 Then
                    counter = ABM_OBSDataGridView.CurrentRow.Index
                End If
                Dim nextRow As DataGridViewRow
                nextRow = ABM_OBSDataGridView.Rows(counter)
                ABM_OBSDataGridView.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True

                ABM_OBSBindingSource.RemoveCurrent()

                If ABM_OBSDataGridView.RowCount = 1 Then
                    Exit Do
                End If

            End If
        Loop

        ABM_PERSONALBindingSource.EndEdit()
        ABM_PERSONALTableAdapter.Update(ABMDataSet.ABM_PERSONAL)
        ABM_LABORALBindingSource.EndEdit()
        ABM_LABORALTableAdapter.Update(ABMDataSet.ABM_LABORAL)
        ABM_EXTRASBindingSource.EndEdit()
        ABM_EXTRASTableAdapter.Update(ABMDataSet.ABM_EXTRAS)
        ABM_OBSBindingSource.EndEdit()
        ABM_OBSTableAdapter.Update(ABMDataSet.ABM_OBS)

        MessageBox.Show("Cliente dado de baja")

        ABM_EXTRASDataGridView.AllowUserToAddRows = False
        ABM_OBSDataGridView.AllowUserToAddRows = False

    End Sub

    Private Sub Buscar4()
        If ABM_PERSONALDataGridView.RowCount > 0 Then
            cuenta = ABM_PERSONALDataGridView.Rows(ABM_PERSONALDataGridView.CurrentRow.Index).Cells(1).Value
            ABM_LABORALBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
            ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
            ABM_OBSBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
            Panel14.Visible = False
        End If
    End Sub

    Private Sub Buscar2()
        If IsNumeric(TextBox42.Text) Then
            ABM_PERSONALBindingSource.Filter = "[DNI] LIKE '" & TextBox42.Text & "%' OR [CUIL] LIKE '" & TextBox42.Text & "%' OR [CUENTA] = '" & TextBox42.Text & "'"
        Else
            ABM_PERSONALBindingSource.Filter = "[NOMBRE] LIKE '" & TextBox42.Text & "%' OR [APELLIDO] LIKE '" & TextBox42.Text & "%'"
        End If

        If ABM_PERSONALDataGridView.RowCount > 0 And TextBox42.TextLength > 0 Then
            Panel14.Visible = True
            Panel14.BringToFront()
        End If

        If Panel14.Visible = True Then
        Else
            If ABM_PERSONALDataGridView.RowCount > 0 Then
                cuenta = ABM_PERSONALDataGridView.Rows(0).Cells(1).Value
                ABM_LABORALBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
                ABM_EXTRASBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
                ABM_OBSBindingSource.Filter = "[CUENTA] = '" & cuenta & "'"
            End If
        End If

    End Sub

    Private Sub PictureBox26_Click_1(sender As Object, e As EventArgs) Handles PictureBox26.Click
        CambiarPanel2()
    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        If Panel8.Visible = True And Level = "2" Or Panel8.Visible = True And Level = "3" Then

            'Modifico datos en DIARIO_CREDITOS y DIARIO_CUOTAS
            DIARIO_CREDITOSBindingSource.Filter = "[CUENTA] = '" & ABM_PERSONALDataGridView.Rows(0).Cells(1).Value & "'"
            DIARIO_CUOTASBindingSource.Filter = "[CUENTA] = '" & ABM_PERSONALDataGridView.Rows(0).Cells(1).Value & "'"

            'Loopeo para modificar Nombre, Apellido, DNI y CUIL
            DIARIO_CREDITOSDataGridView.CurrentCell = DIARIO_CREDITOSDataGridView.Rows(0).Cells(0)
            DIARIO_CREDITOSDataGridView.Rows(0).Selected = True
            Do
                DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(3).Value = NOMBRETextBox.Text
                DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(4).Value = APELLIDOTextBox.Text
                DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(5).Value = DNITextBox.Text
                DIARIO_CREDITOSDataGridView.Rows(DIARIO_CREDITOSDataGridView.CurrentRow.Index).Cells(6).Value = CUILTextBox.Text

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

            DIARIO_CUOTASDataGridView.CurrentCell = DIARIO_CUOTASDataGridView.Rows(0).Cells(0)
            DIARIO_CUOTASDataGridView.Rows(0).Selected = True
            Do
                DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(12).Value = NOMBRETextBox.Text
                DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(13).Value = APELLIDOTextBox.Text
                DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(14).Value = TELEFONO1TextBox.Text
                DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(15).Value = TELEFONO2TextBox.Text
                DIARIO_CUOTASDataGridView.Rows(DIARIO_CUOTASDataGridView.CurrentRow.Index).Cells(16).Value = DIRECCIONTextBox.Text
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

            DIARIO_CREDITOSBindingSource.EndEdit()
            DIARIO_CREDITOSTableAdapter.Update(DATABASEDataSet.DIARIO_CREDITOS)
            DIARIO_CUOTASBindingSource.EndEdit()
            DIARIO_CUOTASTableAdapter.Update(DATABASEDataSet.DIARIO_CUOTAS)
            ABM_PERSONALBindingSource.EndEdit()
            ABM_PERSONALTableAdapter.Update(ABMDataSet.ABM_PERSONAL)
            ABM_LABORALBindingSource.EndEdit()
            ABM_LABORALTableAdapter.Update(ABMDataSet.ABM_LABORAL)
            ABM_EXTRASBindingSource.EndEdit()
            ABM_EXTRASTableAdapter.Update(ABMDataSet.ABM_EXTRAS)
            ABM_OBSBindingSource.EndEdit()
            ABM_OBSTableAdapter.Update(ABMDataSet.ABM_OBS)
            Panel8.Visible = False
        ElseIf Panel8.Visible = True And Level = "1" Then
            ABM_EXTRASBindingSource.EndEdit()
            ABM_EXTRASTableAdapter.Update(ABMDataSet.ABM_EXTRAS)
            ABM_OBSBindingSource.EndEdit()
            ABM_OBSTableAdapter.Update(ABMDataSet.ABM_OBS)
            Panel8.Visible = False
        End If
        Button10.Visible = False
    End Sub
End Class