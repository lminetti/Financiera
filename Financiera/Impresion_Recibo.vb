Public Class Impresion_Recibo

    Dim Letra As String = ""
    Dim Letra2 As String = ""
    Dim lineasRecibo1 As String = ""
    Dim lineasRecibo2 As String = ""
    Dim lineasRecibo3 As String = ""
    Dim lineasRecibo4 As String = ""
    Dim razon As String = ""
    Dim nombre_fantasia As String = ""
    Dim domicilio As String = ""
    Dim condicion_iva As String = ""
    Dim cuit As String = ""
    Dim iibb As String = ""
    Dim inicio_act As String = ""
    Dim pdv As String = ""
    Dim nro As String = ""
    Public Property Operacion As String
    Public Property FACTURA As Integer
    Public Property NROFACTURA As Integer

    Public Property Detalle1 As String
    Public Property Detalle2 As String
    Public Property Detalle3 As String
    Public Property Detalle4 As String
    Public Property Detalle5 As String
    Public Property Detalle6 As String
    Public Property Detalle7 As String
    Public Property Detalle8 As String
    Public Property Detalle9 As String
    Public Property Detalle10 As String
    Public Property Detalle11 As String
    Public Property Detalle12 As String
    Public Property Detalle13 As String
    Public Property Detalle14 As String
    Public Property Detalle15 As String
    Public Property Detalle16 As String
    Public Property Detalle17 As String
    Public Property Detalle18 As String

    Public Property Nombre As String
    Public Property Domicilio_cliente As String
    Public Property Condicion_iva_cliente As String
    Public Property Localidad As String
    Public Property Dni As String
    Public Property Detalle As String
    Public Property Total As String
    Public Property Fecha As String
    Public Property Cuenta As String

    Public Property CAE As String
    Public Property FCAE As String
    Public Property SUBTOTAL As String
    Public Property IVA As String
    Public Property EsCopia As String
    Public Property CompteNro As String

    Dim copia As Integer = 0

    Private Sub Impresion_Recibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)

        'Asignar datos
        razon = AJUSTESDataGridView.Rows(0).Cells(1).Value
        If IsDBNull(AJUSTESDataGridView.Rows(0).Cells(2).Value) Then
            nombre_fantasia = ""
        Else
            nombre_fantasia = AJUSTESDataGridView.Rows(0).Cells(2).Value
        End If
        domicilio = AJUSTESDataGridView.Rows(0).Cells(3).Value
        condicion_iva = AJUSTESDataGridView.Rows(0).Cells(4).Value
        cuit = AJUSTESDataGridView.Rows(0).Cells(5).Value
        iibb = AJUSTESDataGridView.Rows(0).Cells(6).Value
        inicio_act = AJUSTESDataGridView.Rows(0).Cells(7).Value
        pdv = AJUSTESDataGridView.Rows(0).Cells(8).Value
        If FACTURA = 1 Then
            nro = NROFACTURA
        ElseIf FACTURA = 0 Then
            If EsCopia = "SI" Then
                nro = CompteNro
            Else
                If IsDBNull(AJUSTESDataGridView.Rows(0).Cells(12).Value) Then
                    AJUSTESDataGridView.Rows(0).Cells(12).Value = "1"
                    nro = 1
                Else
                    nro = AJUSTESDataGridView.Rows(0).Cells(12).Value
                End If
                'Sumar un número en nro de compte en Ajustes
                AJUSTESDataGridView.Rows(0).Cells(12).Value = AJUSTESDataGridView.Rows(0).Cells(12).Value + 1
                AJUSTESBindingSource.EndEdit()
                AJUSTESTableAdapter.Update(AJUSTESDataSet.AJUSTES)
            End If
        End If

        Recibo()
        Dim printControl = New Drawing.Printing.StandardPrintController
        PrintDocument1.PrintController = printControl
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Recibo()

        Dim espacio1 As New String(" "c, Math.Round(110))
        Dim espacio2 As New String(" "c, Math.Round(47))
        Dim espacio3 As New String(" "c, Math.Round(18))

        'Encabezado
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= nombre_fantasia
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= "de " & razon
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= "Domicilio: " & domicilio
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= "Cond. IVA: " & condicion_iva

        lineasRecibo2 &= espacio1 & "FECHA: " & fecha
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= espacio1 & "Comprobante Nro° " & CInt(pdv).ToString("D4") & " " & CInt(nro).ToString("D8")
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= espacio1 & "CUIT: " & cuit
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= espacio1 & "IIBB: " & iibb
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= espacio1 & "Inicio de actividades: " & inicio_act

        Letra &= espacio2 & "X"

        'Datos cliente
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= "Nombre: " & Nombre
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= "Domicilio: " & Domicilio_cliente
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= "Localidad: " & Localidad

        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= espacio1 & "DNI: " & Dni
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= espacio1 & "Cond. IVA: " & Condicion_iva_cliente
        lineasRecibo2 &= Environment.NewLine
        lineasRecibo2 &= espacio1 & "Cuenta: " & Cuenta

        'Detalle
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= "D E T A L L E"
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Detalle1
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Detalle2
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Detalle3
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Detalle4
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Detalle5
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Detalle6
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Detalle7
        lineasRecibo1 &= Environment.NewLine
        lineasRecibo1 &= Detalle8

        If FACTURA = 1 Then
            'Total
            lineasRecibo1 &= Environment.NewLine
            lineasRecibo1 &= "Condición: EFECTIVO"

            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= espacio3 & "Subtotal: $" & SUBTOTAL & " IVA 21%: " & IVA & " Total: $" & Total
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= espacio3 & "CAE: " & CAE & " | Vto: " & FCAE
        Else
            'Total
            lineasRecibo1 &= Environment.NewLine
            lineasRecibo1 &= Environment.NewLine
            lineasRecibo1 &= "Condición: EFECTIVO"

            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= Environment.NewLine
            lineasRecibo2 &= espacio1 & "                              " & "Total: $" & Total

            'Leyenda
            lineasRecibo1 &= espacio3 & "COMPROBANTE NO VÁLIDO COMO FACTURA"

        End If

        ''''''''''''''''''''''''''''''''''
        '2da copia

        'Encabezado
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= nombre_fantasia
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= "de " & razon
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= "Domicilio: " & domicilio
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= "Cond. IVA: " & condicion_iva

        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= espacio1 & "FECHA: " & Fecha
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= espacio1 & "Comprobante Nro° " & CInt(pdv).ToString("D4") & " " & CInt(nro).ToString("D8")
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= espacio1 & "CUIT: " & cuit
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= espacio1 & "IIBB: " & iibb
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= espacio1 & "Inicio de actividades: " & inicio_act

        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= Environment.NewLine
        Letra2 &= espacio2 & "X"

        'Datos cliente
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= "Nombre: " & Nombre
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= "Domicilio: " & Domicilio_cliente
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= "Localidad: " & Localidad

        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= espacio1 & "DNI: " & Dni
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= espacio1 & "Cond. IVA: " & Condicion_iva_cliente
        lineasRecibo4 &= Environment.NewLine
        lineasRecibo4 &= espacio1 & "Cuenta: " & Cuenta

        'Detalle
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= "D E T A L L E"
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Detalle1
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Detalle2
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Detalle3
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Detalle4
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Detalle5
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Detalle6
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Detalle7
        lineasRecibo3 &= Environment.NewLine
        lineasRecibo3 &= Detalle8

        If FACTURA = 1 Then
            'Total
            lineasRecibo3 &= Environment.NewLine
            lineasRecibo3 &= "Condición: EFECTIVO"

            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= espacio3 & "Subtotal: $" & SUBTOTAL & " IVA 21%: " & IVA & " Total: $" & Total
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= espacio3 & "CAE: " & CAE & " | Vto: " & FCAE
        Else
            'Total
            lineasRecibo3 &= Environment.NewLine
            lineasRecibo3 &= Environment.NewLine
            lineasRecibo3 &= "Condición: EFECTIVO"

            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= Environment.NewLine
            lineasRecibo4 &= espacio1 & "                              " & "Total: $" & Total

            'Leyenda
            lineasRecibo3 &= espacio3 & "COMPROBANTE NO VÁLIDO COMO FACTURA"
        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim StartIndex As Integer = 0
        Static currentChar As Integer

        Dim dibujo As Image = Image.FromFile("Z:\Dibujos\Recibo.jpg")
        Dim dibujoLocation As Point = New Point(-10, 10)

        Dim logo As Image = Image.FromFile("Z:\logo_empresa.jpg")
        Dim logoLocation As Point = New Point(60, 40)

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

        'Dibujo
        e.Graphics.DrawImage(dibujo, dibujoLocation)

        'Logo
        e.Graphics.DrawImage(logo, logoLocation)

        'Encabezado
        e.Graphics.MeasureString(Mid(lineasRecibo1, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasRecibo1.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)
        e.Graphics.MeasureString(Mid(lineasRecibo2, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasRecibo2.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)
        e.Graphics.MeasureString(Mid(Letra, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(Letra.Substring(currentChar, chars), New Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, b, format)

        Dim logo2 As Image = Image.FromFile("Z:\logo_empresa.jpg")
        Dim logo2Location As Point = New Point(60, 586)

        'Logo2
        e.Graphics.DrawImage(logo2, logo2Location)

        'Encabezado2
        e.Graphics.MeasureString(Mid(lineasRecibo3, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasRecibo3.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)
        e.Graphics.MeasureString(Mid(lineasRecibo4, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasRecibo4.Substring(currentChar, chars), New Font("Segoe UI", 11, FontStyle.Regular), Brushes.Black, b, format)
        e.Graphics.MeasureString(Mid(Letra2, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(Letra2.Substring(currentChar, chars), New Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, b, format)

        Me.Close()
    End Sub

End Class