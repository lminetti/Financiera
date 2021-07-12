Public Class Login

    Public Property Operador As String
    Public Property Cuenta As String
    Public Property Level As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("Ingrese una clave")
            Exit Sub
        Else
            OPERADORESBindingSource.Filter = "[CLAVE] = '" & TextBox1.Text & "'"
            If OPERADORESDataGridView.Rows(0).Cells(2).Value = TextBox1.Text Then
                Operador = OPERADORESDataGridView.Rows(0).Cells(1).Value
                Cuenta = OPERADORESDataGridView.Rows(0).Cells(0).Value
                Level = OPERADORESDataGridView.Rows(0).Cells(3).Value
                Dim Parent = New Parent()
                Parent.Operador = Operador
                Parent.Cuenta = Cuenta
                Parent.Level = Level
                Parent.Show()
                Me.Close()
            Else
                MessageBox.Show("Clave incorrecta")
                TextBox1.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pStart As New System.Diagnostics.Process
        pStart.StartInfo.FileName = "C:\Financiera\ini.bat"
        pStart.StartInfo.WorkingDirectory = "C:\Financiera" 'Set to where ever the files you want to convert are
        pStart.Start()

        System.Threading.Thread.Sleep(5000)
        Application.DoEvents()

        Me.OPERADORESTableAdapter.Fill(Me.AJUSTESDataSet.OPERADORES)

        'Si el terminal está seleccionado como 'Calculador de intereses' va a ejecutar el cálculo, sino no.
        'La detección se realiza si encuentra el archivo Intereses.TXT en la carpeta 'Configuración' del disco Z
        Dim SourcePath As String = "C:\Financiera\Configuración\Intereses.txt"
        Dim SaveDirectory As String = "C:\Financiera\Configuración"

        Dim Filename As String = System.IO.Path.GetFileName(SourcePath)
        Dim SavePath As String = System.IO.Path.Combine(SaveDirectory, Filename)

        TextBox1.Visible = False
        PictureBox2.Visible = False
        Label2.Text = "Calculando intereses..."

        System.Threading.Thread.Sleep(5000)

        If System.IO.File.Exists(SavePath) Then
            'Terminal seleccionada como calculadora de intereses
            CalcularIntereses()
        Else
            TextBox1.Visible = True
            PictureBox2.Visible = True
            Label2.Text = "Ingresar clave"
            TextBox1.Select()
        End If

    End Sub

    Private Sub CalcularIntereses()
        Dim Calcular_Intereses = New Calcular_Intereses()
        Calcular_Intereses.Show()
    End Sub

End Class