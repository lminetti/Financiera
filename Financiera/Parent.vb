Public Class Parent

    Public Property Operador As String
    Public Property Cuenta As String
    Public Property Level As String

    Private Sub Parent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)
        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)
        Me.OPERADORESTableAdapter.Fill(Me.AJUSTESDataSet.OPERADORES)

        Panel7.Top = (Panel4.Height - Panel7.Height) / 2
        Panel7.Left = (Panel4.Width - Panel7.Width) / 2
        Panel8.Top = (Me.Height - Panel8.Height) / 2
        Panel8.Left = (Me.Width - Panel8.Width) / 2

        Label2.Text = "Está operando: " & Operador & ", nivel " & Level & "."
        Label4.Text = DateTime.Now.ToString("dd/MM/yyyy")

        PictureBox3.BackgroundImage = Image.FromFile("Z:\logo.png")

        'Primer inicio
        Dim primerinicio As Integer = 0
        If AJUSTESDataGridView.RowCount = 0 Then
            primerinicio = 1
        End If

        If primerinicio = 1 Then
            MessageBox.Show("¡Hola! Detectamos que este es tu primer inicio del sistema." & Environment.NewLine & "Algunas recomendaciones para el funcionamiento correcto del mismo:" & Environment.NewLine & Environment.NewLine & "1. Ingresar a AJUSTES, y cargar los datos de la empresa." & Environment.NewLine & "2. Ingresar a AJUSTES, y cargar coeficientes e intereses." & Environment.NewLine & "3. Ingresar a CONTABILIDAD, y crear cajas para asignar luego a cada operador." & Environment.NewLine & "4. Ingresar a OPERADORES, y crear nuevos operadores con cajas asignadas." & Environment.NewLine & "5. Ingresar a ABM CLIENTES, y cargar un nuevo cliente." & Environment.NewLine & Environment.NewLine & "Al cerrar este mensaje, vas a encontrar un botón en el menú para ver estos consejos cuando quieras durante el primer funcionamiento.", "Primer inicio")
            Button9.Visible = True
        Else

            'Si el terminal está seleccionado como 'Calculador de intereses' va a ejecutar el cálculo, sino no.
            'La detección se realiza si encuentra el archivo Intereses.TXT en la carpeta 'Configuración' del disco Z
            Dim SourcePath As String = "C:\Financiera\Configuración\Intereses.txt"
            Dim SaveDirectory As String = "C:\Financiera\Configuración"

            Dim Filename As String = System.IO.Path.GetFileName(SourcePath)
            Dim SavePath As String = System.IO.Path.Combine(SaveDirectory, Filename)

            If System.IO.File.Exists(SavePath) Then
            Else
                'Continua con la apertura de caja
                'Apertura de caja
                OPERADORESBindingSource.Filter = "[NOMBRE] = '" & Operador & "'"
                CONTABLEBindingSource.Filter = "[CAJA] = '" & OPERADORESDataGridView.Rows(0).Cells(5).Value & "'"
                CONTABLEDataGridView.Sort(CONTABLEDataGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

                Dim total As String = ""
                If CONTABLEDataGridView.RowCount > 0 Then
                    Dim Valor As Integer = 0
                    Valor = CONTABLEDataGridView.RowCount - 1
                    total = CDbl(CONTABLEDataGridView.Rows(Valor).Cells(6).Value).ToString("F2")
                    MessageBox.Show("Hola, " + Operador + ". Este es el monto de apertura en caja: $" + total, "Apertura")
                Else
                    MessageBox.Show("No se puede hacer apertura porque no hay caja asignada.")
                End If
            End If

        End If

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim Login = New Login()
        Login.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim result As Integer = MessageBox.Show("¿Cerrar sistema?", "", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Parent_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Button1.PerformClick()
            Case Keys.F2
                Button2.PerformClick()
            Case Keys.F3
                Button4.PerformClick()
            Case Keys.F4
                Button3.PerformClick()
            Case Keys.F5
                Button5.PerformClick()
            Case Keys.F6
                Button10.PerformClick()
            Case Keys.F7
                Button11.PerformClick()
            Case Keys.F8
                Button12.PerformClick()
            Case Keys.F9
                Button7.PerformClick()
            Case Keys.F10
                Button8.PerformClick()
            Case Keys.Escape
                Button6.PerformClick()
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Level = "3" Or Level = "2" Then
            Dim ABM = New ABM()
            ABM.Operador = Operador
            ABM.Level = Level
            ABM.Show()
        Else
            MessageBox.Show("Acceso restringido para este nivel")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Level = "3" Or Level = "2" Then
            Dim Creditos_Alta = New Creditos_Alta()
            Creditos_Alta.Operador = Operador
            Creditos_Alta.Level = Level
            Creditos_Alta.Show()
        Else
            MessageBox.Show("Acceso restringido para este nivel")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Level = "3" Or Level = "2" Then
            Dim Contabilidad = New Contabilidad()
            Contabilidad.Operador = Operador
            Contabilidad.Level = Level
            Contabilidad.Show()
        Else
            MessageBox.Show("Acceso restringido para este nivel")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Level = "3" Or Level = "2" Then
            Dim Creditos_Otorgados = New Creditos_Otorgados()
            Creditos_Otorgados.Operador = Operador
            Creditos_Otorgados.Level = Level
            Creditos_Otorgados.Show()
        Else
            MessageBox.Show("Acceso restringido para este nivel")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Cobranzas = New Cobranzas()
        Cobranzas.Operador = Operador
        Cobranzas.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Reportes")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Level = "3" Then
            Dim Ajustes = New Ajustes()
            Ajustes.Show()
        Else
            MessageBox.Show("Acceso restringido para este nivel")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Level = "3" Then
            Dim Operadores = New Operadores()
            Operadores.Show()
        Else
            MessageBox.Show("Acceso restringido para este nivel")
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim Ficha_C = New FICHA_C()
        Ficha_C.Operador = Operador
        Ficha_C.Nivel = Level
        Ficha_C.Show()
    End Sub

    Private Sub Parent_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Panel7.Top = (Panel4.Height - Panel7.Height) / 2
        Panel7.Left = (Panel4.Width - Panel7.Width) / 2
    End Sub

    Private Sub AJUSTESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AJUSTESBindingSource.EndEdit()
        Me.TableAdapterManager1.UpdateAll(Me.AJUSTESDataSet)

    End Sub

    Private Sub AJUSTESBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AJUSTESBindingSource.EndEdit()
        Me.TableAdapterManager1.UpdateAll(Me.AJUSTESDataSet)

    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        MessageBox.Show("Algunas recomendaciones para el funcionamiento correcto del sistema:" & Environment.NewLine & Environment.NewLine & "1. Ingresar a AJUSTES, y cargar los datos de la empresa." & Environment.NewLine & "2. Ingresar a AJUSTES, y cargar coeficientes e intereses." & Environment.NewLine & "3. Ingresar a CONTABILIDAD, y crear cajas para asignar luego a cada operador." & Environment.NewLine & "4. Ingresar a OPERADORES, y crear nuevos operadores con cajas asignadas." & Environment.NewLine & "5. Ingresar a ABM CLIENTES, y cargar un nuevo cliente.", "Primer inicio")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim Observaciones = New Observaciones()
        Observaciones.Operador = Operador
        Observaciones.Nivel = Level
        Observaciones.Show()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim Reportes = New REPORTES()
        Reportes.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Panel8.Visible = True
        Button9.Visible = False
        Dim Calcular_Intereses = New Calcular_Intereses()
        Calcular_Intereses.Show()
        Panel8.Visible = False
    End Sub

    Private Sub Parent_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class