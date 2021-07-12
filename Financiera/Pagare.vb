Imports System
Imports System.IO
Public Class Pagare

    Dim lineasPagare As String = ""
    Dim tituloPagare As String = ""
    Public Property UltimaOperacion As String
    Public Property Monto As String
    Public Property Total As String
    Public Property Fecha As String
    Public Property DomicilioCliente As String
    Public Property LocalidadCliente As String
    Public Property Ref_Activo As String
    Dim decimalesMonto As String = ""
    Dim decimalesTotal As String = ""
    Dim MontoSinDec As String = ""
    Dim TotalSinDec As String = ""
    Dim myCulture As System.Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
    Dim dayOfWeek As DayOfWeek = myCulture.Calendar.GetDayOfWeek(Date.Today)
    Dim Dia_Hoy As String = myCulture.DateTimeFormat.GetDayName(dayOfWeek)
    Dim Dia_Numero As String = Date.Today.ToString("dd")
    Dim Mes_Nombre As String = Date.Today.ToString("MMMM")
    Dim Año_Numero As String = Date.Today.ToString("yyyy")
    Dim Financiera As String = ""
    Dim Domicilio As String = ""
    Dim Ciudad As String = ""
    Dim CUIT_FINANCIERA As String = ""
    Dim Provincia As String = "Provincia de Buenos Aires"
    Dim Selec_pagina As Integer = 0

    Private Sub Pagare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)
        CUIT_FINANCIERA = AJUSTESDataGridView.Rows(0).Cells(5).Value
        dayOfWeek = myCulture.Calendar.GetDayOfWeek(CDate(Fecha))
        Dia_Hoy = myCulture.DateTimeFormat.GetDayName(dayOfWeek)
        Dia_Numero = CDate(Fecha).ToString("dd")
        Mes_Nombre = CDate(Fecha).ToString("MMMM")
        Año_Numero = CDate(Fecha).ToString("yyyy")
        Financiera = AJUSTESDataGridView.Rows(0).Cells(1).Value
        Domicilio = AJUSTESDataGridView.Rows(0).Cells(3).Value
        Ciudad = AJUSTESDataGridView.Rows(0).Cells(10).Value
        Total = CDbl(Total).ToString("F2")
        decimalesMonto = Split(CStr(Monto), ",")(1)
        decimalesTotal = Split(CStr(Total), ",")(1)
        MontoSinDec = Split(CStr(Monto), ",")(0)
        TotalSinDec = Split(CStr(Total), ",")(0)
        Pagare()
        Dim printControl = New Drawing.Printing.StandardPrintController
        PrintDocument1.PrinterSettings.PrinterName = "CutePDF Writer"
        PrintDocument1.PrintController = printControl
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Pagare()


        If Ref_Activo = "SI" Then

            Dim TITULO As String = "               PAGARÉ A LA VISTA SIN PROTESTO"
            Dim TITULO2 As String = "                    REFINANCIACIÓN DE DEUDA"
            Dim NUMERO_Y_MONTO As String = "POR $" & Total & "                                                                                                               Operación Ref. N°" & UltimaOperacion
            Dim DIA As String = "                                                                	                                   	      " & Ciudad & ", " & Dia_Numero & " de " & Mes_Nombre & " de " & Año_Numero
            Dim LINEA1 As String = "A la vista pagaremos sin protesto a " & Financiera & ", CUIT N°" & CUIT_FINANCIERA & ", o a la orden de la misma"
            Dim LINEA2 As String = "la cantidad de pesos " & Num2Text(CInt(TotalSinDec)) & " CON " & decimalesTotal & "/100."
            Dim LINEA3 As String = "Por igual valor recibido a nuestra entera satisfacción, pagaderos en LOPEZ SERRANO 3657"
            Dim LINEA4 As String = "de la ciudad de " & Ciudad & ", " & Provincia & "."
            Dim LINEA5 As String = "El monto del presente pagare atento lo prescribe el art. 36 de la ley 24.240 se conforma por el"
            Dim LINEA6 As String = "importe en pesos recibidos en mano, a los que habrá de adicionarles los siguientes ítems: monto"
            Dim LINEA7 As String = "recibido en efectivo $_______________, gastos administrativos $______________,  sellado del"
            Dim LINEA8 As String = "pagaré $_______________ (12/00), informe de riesgo crediticio $_________________, intereses"
            Dim LINEA9 As String = "consolidados por el término del mutuo $_________________ , tasa mensual aplicada______%,  IVA"
            Dim LINEA10 As String = "sobre intereses $__________ (21%), tasa efectiva anual____ %, total de intereses a percibir"
            Dim LINEA11 As String = "$___________ sistema de amortización_____________ cantidad de cuotas mensuales__________ ,"
            Dim LINEA12 As String = "vencimiento de la primer cuota_______________________ y las sucesivas cada 30 días de la primera."
            Dim LINEA13 As String = "Declaro que los blancos del presente instrumento fueron llenados en mi presencia."
            Dim LINEA14 As String = "Se deja constancia que el librador amplía el plazo de presentación al cobro de este pagaré por el"
            Dim LINEA15 As String = "plazo de diez (10) años. (Art. 36 D.L. 5965/63)."
            Dim LINEA16 As String = "Si presentado este documento al cobro no fuere cancelado, se aplicará a partir de tal fecha"
            Dim LINEA17 As String = "(constitución en mora) un interés punitorio equivalente al___ por ciento (___%) del estipulado"
            Dim LINEA18 As String = "como compensatorio (y que se adicionará a este) que se devengará hasta la cancelación total de lo"
            Dim LINEA19 As String = "adeudado, capitalizándose en la forma prevista en el art. 770 del Código Civil y Comercial de la"
            Dim LINEA20 As String = "Nación, hasta la efectiva cancelación de lo adeudado."
            Dim LINEA21 As String = "Asimismo en mí carácter de deudor, acepto de conformidad, la opción que le corresponde al"
            Dim LINEA22 As String = "acreedor de recurrir contra bienes de mi propiedad o bien solicitar la afectación de mis haberes y/o"
            Dim LINEA23 As String = "ingresos personales de acuerdo a lo que dispone la ley ritual y con expresa renuncia al beneficio que"
            Dim LINEA24 As String = "me otorga el decreto 6754/43, en caso de corresponder, hasta resarcir al mismo hasta el pago total"
            Dim LINEA25 As String = "del crédito contraído con más los intereses costos y costas del proceso judicial en todas las instancias."
            Dim LINEA26 As String = "El deudor constituye domicilio especial en calle " & DomicilioCliente & " de la ciudad"
            Dim LINEA27 As String = "de " & LocalidadCliente & ", Provincia de Buenos Aires, donde se tendrán por válidas todas las notificaciones,"
            Dim LINEA28 As String = "comunicaciones, intimaciones extrajudiciales o judiciales que en el mismo se cursen, sometiéndose éste,"
            Dim LINEA29 As String = "a su vez, a la exclusiva jurisdicción y competencia del Juzgado de Paz Letrado de Saladillo, Provincia de"
            Dim LINEA30 As String = "Buenos Aires y/o a la de los juzgados civiles y comerciales del Departamento Judicial La Plata."
            Dim LINEA31 As String = "________________________           ________________________           ________________________"
            Dim LINEA32 As String = "                FIRMA                                           ACLARACION                                          DNI"
            Dim LINEA33 As String = "________________________           ________________________           ________________________"
            Dim LINEA34 As String = "             DOMICILIO                                      LOCALIDAD                                      TELEFONO"

            tituloPagare &= Environment.NewLine
            tituloPagare &= TITULO
            tituloPagare &= Environment.NewLine
            tituloPagare &= TITULO2
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= NUMERO_Y_MONTO
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= DIA
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA1
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA2
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA3
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA4
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA5
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA6
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA7
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA8
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA9
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA10
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA11
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA12
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA13
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA14
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA15
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA16
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA17
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA18
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA19
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA20
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA21
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA22
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA23
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA24
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA25
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA26
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA27
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA28
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA29
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA30
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA31
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA32
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA33
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA34
            lineasPagare &= Environment.NewLine

        Else

            Dim TITULO As String = "               PAGARÉ A LA VISTA SIN PROTESTO"
            Dim NUMERO_Y_MONTO As String = "POR $" & Total & "                                                                                                            Operación N°" & UltimaOperacion
            Dim DIA As String = "                                                                	                                   	      " & Ciudad & ", " & Dia_Numero & " de " & Mes_Nombre & " de " & Año_Numero
            Dim LINEA1 As String = "A la vista pagaremos sin protesto a " & Financiera & ", CUIT N°" & CUIT_FINANCIERA & ", o a la orden de la misma"
            Dim LINEA2 As String = "la cantidad de pesos " & Num2Text(CInt(TotalSinDec)) & " CON " & decimalesTotal & "/100."
            Dim LINEA3 As String = "Por igual valor recibido a nuestra entera satisfacción, pagaderos en LOPEZ SERRANO 3657"
            Dim LINEA4 As String = "de la ciudad de " & Ciudad & ", " & Provincia & "."
            Dim LINEA5 As String = "El monto del presente pagare atento lo prescribe el art. 36 de la ley 24.240 se conforma por el"
            Dim LINEA6 As String = "importe en pesos recibidos en mano, a los que habrá de adicionarles los siguientes ítems: monto"
            Dim LINEA7 As String = "recibido en efectivo $_______________, gastos administrativos $______________,  sellado del"
            Dim LINEA8 As String = "pagaré $_______________ (12/00), informe de riesgo crediticio $_________________, intereses"
            Dim LINEA9 As String = "consolidados por el término del mutuo $_________________ , tasa mensual aplicada______%,  IVA"
            Dim LINEA10 As String = "sobre intereses $__________ (21%), tasa efectiva anual____ %, total de intereses a percibir"
            Dim LINEA11 As String = "$___________ sistema de amortización_____________ cantidad de cuotas mensuales__________ ,"
            Dim LINEA12 As String = "vencimiento de la primer cuota_______________________ y las sucesivas cada 30 días de la primera."
            Dim LINEA13 As String = "Declaro que los blancos del presente instrumento fueron llenados en mi presencia."
            Dim LINEA14 As String = "Se deja constancia que el librador amplía el plazo de presentación al cobro de este pagaré por el"
            Dim LINEA15 As String = "plazo de diez (10) años. (Art. 36 D.L. 5965/63)."
            Dim LINEA16 As String = "Si presentado este documento al cobro no fuere cancelado, se aplicará a partir de tal fecha"
            Dim LINEA17 As String = "(constitución en mora) un interés punitorio equivalente al___ por ciento (___%) del estipulado"
            Dim LINEA18 As String = "como compensatorio (y que se adicionará a este) que se devengará hasta la cancelación total de lo"
            Dim LINEA19 As String = "adeudado, capitalizándose en la forma prevista en el art. 770 del Código Civil y Comercial de la"
            Dim LINEA20 As String = "Nación, hasta la efectiva cancelación de lo adeudado."
            Dim LINEA21 As String = "Asimismo en mí carácter de deudor, acepto de conformidad, la opción que le corresponde al"
            Dim LINEA22 As String = "acreedor de recurrir contra bienes de mi propiedad o bien solicitar la afectación de mis haberes y/o"
            Dim LINEA23 As String = "ingresos personales de acuerdo a lo que dispone la ley ritual y con expresa renuncia al beneficio que"
            Dim LINEA24 As String = "me otorga el decreto 6754/43, en caso de corresponder, hasta resarcir al mismo hasta el pago total"
            Dim LINEA25 As String = "del crédito contraído con más los intereses costos y costas del proceso judicial en todas las instancias."
            Dim LINEA26 As String = "El deudor constituye domicilio especial en calle " & DomicilioCliente & " de la ciudad"
            Dim LINEA27 As String = "de " & LocalidadCliente & ", Provincia de Buenos Aires, donde se tendrán por válidas todas las notificaciones,"
            Dim LINEA28 As String = "comunicaciones, intimaciones extrajudiciales o judiciales que en el mismo se cursen, sometiéndose éste,"
            Dim LINEA29 As String = "a su vez, a la exclusiva jurisdicción y competencia del Juzgado de Paz Letrado de Saladillo, Provincia de"
            Dim LINEA30 As String = "Buenos Aires y/o a la de los juzgados civiles y comerciales del Departamento Judicial La Plata."
            Dim LINEA31 As String = "________________________           ________________________           ________________________"
            Dim LINEA32 As String = "                FIRMA                                           ACLARACION                                          DNI"
            Dim LINEA33 As String = "________________________           ________________________           ________________________"
            Dim LINEA34 As String = "             DOMICILIO                                      LOCALIDAD                                      TELEFONO"

            tituloPagare &= Environment.NewLine
            tituloPagare &= TITULO
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= NUMERO_Y_MONTO
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= DIA
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA1
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA2
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA3
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA4
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA5
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA6
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA7
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA8
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA9
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA10
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA11
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA12
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA13
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA14
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA15
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA16
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA17
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA18
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA19
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA20
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA21
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA22
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA23
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA24
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA25
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA26
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA27
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA28
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA29
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA30
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA31
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA32
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA33
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA34
            lineasPagare &= Environment.NewLine

        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim StartIndex As Integer = 0
        Static currentChar As Integer

        Dim textfont As Font = New Font("Times New Roman", 12, FontStyle.Regular)

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
        e.Graphics.MeasureString(Mid(tituloPagare, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(tituloPagare.Substring(currentChar, chars), New Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, b, format)

        'Texto
        e.Graphics.MeasureString(Mid(lineasPagare, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(lineasPagare.Substring(currentChar, chars), New Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, b, format)

        e.HasMorePages = False

        Me.Close()

    End Sub

    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES"
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select

        Return Num2Text
    End Function
End Class