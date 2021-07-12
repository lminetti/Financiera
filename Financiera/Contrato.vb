Imports System
Imports System.IO
Public Class Contrato

    Dim lineasPagare As String = ""
    Dim lineasPagare2 As String = ""
    Dim lineasPagare3 As String = ""
    Dim tituloContrato As String = ""
    Public Property UltimaOperacion As String
    Public Property Monto As String
    Public Property Total As String
    Public Property Nombre_Cliente As String
    Public Property Apellido_Cliente As String
    Public Property DNI_Cliente As String
    Public Property CUIL_Cliente As String
    Public Property cantCuotas As String
    Public Property valorCuotas As String
    Dim myCulture As System.Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
    Dim dayOfWeek As DayOfWeek = myCulture.Calendar.GetDayOfWeek(Date.Today)
    Dim Dia_Hoy As String = myCulture.DateTimeFormat.GetDayName(dayOfWeek)
    Dim Dia_Numero As String = Date.Today.ToString("dd")
    Dim Mes_Nombre As String = Date.Today.ToString("MMMM")
    Dim Año_Numero As String = Date.Today.ToString("yyyy")
    Dim Financiera As String = ""
    Dim Cuit As String = ""
    Dim Cuil As String = ""
    Dim Domicilio As String = ""
    Dim Ciudad As String = ""
    Dim decimalesMonto As String = ""
    Dim decimalesTotal As String = ""
    Dim decimalesCuotas As String = ""
    Dim MontoSinDec As String = ""
    Dim TotalSinDec As String = ""
    Dim ValorCuotasSinDec As String = ""
    Public Property Empresa As String
    Public Property Domicilio_Empresa As String
    Public Property Localidad_Empresa As String
    Public Property Ref_Activo As String
    Public Property Capital As String
    Public Property Pagare As String
    Public Property Intereses As String
    Public Property FechaAlta As String
    Dim Selec_pagina As Integer = 0

    Dim pagina As Integer = 1

    Private Sub Contrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)
        Me.AJUSTESTableAdapter.Fill(Me.AJUSTESDataSet.AJUSTES)
        Financiera = AJUSTESDataGridView.Rows(0).Cells(1).Value
        Domicilio = AJUSTESDataGridView.Rows(0).Cells(3).Value
        Ciudad = AJUSTESDataGridView.Rows(0).Cells(10).Value
        Cuit = AJUSTESDataGridView.Rows(0).Cells(5).Value
        Monto = CDbl(Monto).ToString("F2")
        Total = CDbl(Total).ToString("F2")
        valorCuotas = CDbl(valorCuotas).ToString("F2")
        decimalesMonto = Split(CStr(Monto), ",")(1)
        decimalesTotal = Split(CStr(Total), ",")(1)
        decimalesCuotas = Split(CStr(valorCuotas), ",")(1)
        ValorCuotasSinDec = Split(CStr(valorCuotas), ",")(0)
        MontoSinDec = Split(CStr(Monto), ",")(0)
        TotalSinDec = Split(CStr(Total), ",")(0)
        Contrato()
        Dim printControl = New Drawing.Printing.StandardPrintController
        PrintDocument1.PrintController = printControl
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Contrato()

        If Ref_Activo = "SI" Then

            Dim TITULO As String = "                    RECONOCIMIENTO DE DEUDA"
            Dim TITULO2 As String = "           REFINANCIACIÓN - CONVENIO DE PAGO"
            Dim LINEA1 As String = "En la ciudad de " & Ciudad & ", Provincia de Buenos Aires, a los " & Dia_Numero & " días del mes de " & Mes_Nombre & " del año " & Año_Numero & ","
            Dim LINEA2 As String = "entre " & Financiera & ", prestadora de servicios CUIT N° " & Cuit & ", con domicilio legal en la calle"
            Dim LINEA3 As String = "LOPEZ SERRANO 3657 de la ciudad de " & Ciudad & " Provincia de Buenos Aires, en adelante"
            Dim LINEA4 As String = "EL ACREEDOR por una parte; y por la otra el Sr./ra: " & Nombre_Cliente & " " & Apellido_Cliente & ","
            Dim LINEA5 As String = "DNI N°" & DNI_Cliente & ", CUIL N° " & CUIL_Cliente & ", empleado en " & Empresa & ","
            Dim LINEA6 As String = "en la calle " & Domicilio_Empresa & ", de la localidad de " & Localidad_Empresa & ", con domicilio"
            Dim LINEA7 As String = "en adelante EL DEUDOR, convienen el celebrar el presente convenio de refinanciación de la deuda y su pago,"
            Dim LINEA8 As String = "el que se regirá por la libre autonomía de las partes y la buena fe contractual (art. 9 del CCC), bajo las siguientes"
            Dim LINEA8_1 As String = "clausulas:"

            Dim LINEA9 As String = "PRIMERA: EL DEUDOR reconoce adeudar AL ACREEDOR, la suma de"
            Dim LINEA10 As String = Num2Text(CInt(MontoSinDec)) & " CON " & decimalesMonto & "/100 ($" & Monto & ")" & " (comprensiva de: capital,"
            Dim LINEA11 As String = "intereses e intereses punitorios) en virtud del saldo deudor de $" & Pagare & " del contrato de mutuo firmado por"
            Dim LINEA12 As String = "las partes con fecha " & FechaAlta & ", fecha de mora: _________________. Se adjunta al presente"
            Dim LINEA13 As String = "fotocopia de dicho contrato de mutuo y su respectivo pagaré firmados por EL DEUDOR."

            Dim LINEA14 As String = "SEGUNDA: La deuda reconocida por EL DEUDOR en la cláusula precedente, será abonada en " & Num2Text(CInt(cantCuotas)) & " (" & cantCuotas & ") cuotas"
            Dim LINEA15 As String = "mensuales, sucesivas e iguales de " & Num2Text(CInt(ValorCuotasSinDec)) & " CON " & decimalesCuotas & "/100 ($" & valorCuotas & ")."
            Dim LINEA16 As String = "Las cuotas serán abonadas del 1 al 10 de cada mes."

            Dim LINEA17 As String = "TERCERA: El incumplimiento de cualquiera de las cuotas pactadas, producirá el decaimiento de los plazos"
            Dim LINEA18 As String = "otorgados sin necesidad de interpelación alguna, haciéndose exigible la totalidad de la deuda con deducción"
            Dim LINEA19 As String = "de lo que efectivamente hubiera abonado EL DEUDOR. La mora se producirá en forma automática, devengando"
            Dim LINEA20 As String = "un interés del _______% mensual sobre el monto atrasado."

            Dim LINEA21 As String = "CUARTA: En garantía, EL DEUDOR suscribe en este acto, un pagaré a la vista por la suma de"
            Dim LINEA22 As String = Num2Text(CInt(TotalSinDec)) & " CON " & decimalesTotal & "/100 ($" & Total & ")."

            Dim LINEA23 As String = "QUINTA: Para todos los efectos legales derivados del presente convenio, las partes constituyen"
            Dim LINEA24 As String = "domicilio en los indicados en el encabezamiento, lugares donde serán válidas las notificaciones que"
            Dim LINEA25 As String = "deban cursarse, como así se someten a la jurisdicción exclusiva del Juzgado de Paz Letrado de Saladillo,"
            Dim LINEA26 As String = "Provincia de Buenos Aires y/o a la de los juzgados civiles y comerciales del Departamento Judicial"
            Dim LINEA27 As String = "La Plata, y renuncian a cualquier objeción que pudieran tener en la actualidad o en el futuro con"
            Dim LINEA28 As String = "respecto a la inconveniencia de la jurisdicción estipulada."

            Dim LINEA29 As String = "Se firman en prueba de conformidad dos ejemplares de un mismo tenor y a un solo efecto en la ciudad de"
            Dim LINEA30 As String = Ciudad & ", Provincia de Buenos Aires, a los " & Dia_Numero & " días del mes de " & Mes_Nombre & " del año " & Año_Numero & "."

            Dim LINEA31 As String = "________________________           ________________________           ________________________"
            Dim LINEA32 As String = "                FIRMA                                           ACLARACION                                          DNI"
            Dim LINEA33 As String = "________________________           ________________________           ________________________"
            Dim LINEA34 As String = "             DOMICILIO                                      LOCALIDAD                                      TELEFONO"

            'Título
            tituloContrato &= TITULO
            tituloContrato &= Environment.NewLine
            tituloContrato &= TITULO2

            'Página 1
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
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
            lineasPagare &= LINEA8_1
            lineasPagare &= Environment.NewLine
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
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA14
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA15
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA16
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA17
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA18
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA19
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA20
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA21
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA22
            lineasPagare &= Environment.NewLine
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
            lineasPagare &= LINEA31
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA32
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA33
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA34

        Else

            Dim TITULO As String = "                          CONTRATO DE MUTUO"
            Dim LINEA1 As String = "En la ciudad de " & Ciudad & ", Provincia de Buenos Aires, a los " & Dia_Numero & " días del mes de " & Mes_Nombre & " del año " & Año_Numero & ","
            Dim LINEA2 As String = "entre " & Financiera & ", prestadora de servicios CUIT N° " & Cuit & ", con domicilio legal en la calle"
            Dim LINEA3 As String = "LOPEZ SERRANO 3657 de la ciudad de " & Ciudad & " Provincia de Buenos Aires, en adelante"
            Dim LINEA4 As String = "EL MUTUANTE por una parte; y por la otra el Sr./ra: " & Nombre_Cliente & " " & Apellido_Cliente & ","
            Dim LINEA5 As String = "DNI N°" & DNI_Cliente & ", CUIL N° " & CUIL_Cliente & ", empleado en " & Empresa & ","
            Dim LINEA6 As String = "en la calle" & Domicilio_Empresa & ", de la localidad de " & Localidad_Empresa & ", con domicilio"
            Dim LINEA7 As String = "en adelante denominado EL MUTUARIO, convienen el celebrar el presente contrato, el que se regirá por"
            Dim LINEA8 As String = "la libre autonomía de las partes y la buena fe contractual (art. 9 del CCC), bajo las siguientes clausulas:"
            Dim LINEA9 As String = "PRIMERA: EL MUTUANTE da en préstamo AL MUTUARIO, a pedido de éste, la suma de"
            Dim LINEA10 As String = Num2Text(CInt(MontoSinDec)) & " CON " & decimalesMonto & "/100 ($" & Monto & ")" & " en efectivo, tratándose del capital nominal que se entrega y que"
            Dim LINEA11 As String = "se incrementará por los intereses pactados voluntariamente y pagaderos de la manera que se establece,"
            Dim LINEA12 As String = "con más los gastos ocasionados conformidad presta EL MUTUARIO. Dicha suma entregada en dinero en"
            Dim LINEA13 As String = "efectivo será cancelable en " & Num2Text(CInt(cantCuotas)) & " (" & cantCuotas & ") cuotas mensuales de " & Num2Text(CInt(ValorCuotasSinDec))
            Dim LINEA14 As String = "CON " & decimalesCuotas & "/100 ($" & valorCuotas & ") cada una."
            Dim LINEA15 As String = "SEGUNDA: En garantía, EL MUTUARIO suscribe en este acto, un pagaré a la vista por la suma de"
            Dim LINEA16 As String = "de " & Num2Text(CInt(TotalSinDec)) & " CON " & decimalesTotal & "/100 ($" & Total & ") y en los términos"
            Dim LINEA17 As String = "prescriptos en el art. 36 de la Ley 24.240, a cuyos efectos se establece: a) La entrega que se le hace"
            Dim LINEA18 As String = "al MUTUARIO es en dinero en efectivo que se consigna y por el valor que realmente recibe en mano,"
            Dim LINEA19 As String = "o sea " & Num2Text(CInt(MontoSinDec)) & " CON " & decimalesMonto & "/100 ($" & Monto & ")."
            Dim LINEA20 As String = "b) El total de intereses devengados y a cobrar asciende a la suma de_____________ ($_______)"
            Dim LINEA21 As String = "c) Los intereses son calculados mediante el sistema francés;"
            Dim LINEA22 As String = "d) la cuota mensual es de " & Num2Text(CInt(ValorCuotasSinDec)) & " CON " & decimalesCuotas & "/100 ($" & valorCuotas & ") cada una,"
            Dim LINEA23 As String = " las mismas ascienden a la cantidad de " & cantCuotas & " cuotas, la primera se devengará el día_______; y las restantes todos los"
            Dim LINEA24 As String = "días ____ de cada mes con una tolerancia de cinco (5) días, aplicándose un interés punitivo"
            Dim LINEA25 As String = "del __________(%____) diario y acumulativo."
            Dim LINEA26 As String = "e) La presente operación devengará un gasto administrativo de _______________ ($____________),"
            Dim LINEA27 As String = "un seguro de vida del MUTUARIO a favor del MUTUANTE cuyo monto total es de_______________"
            Dim LINEA28 As String = "($_________), y se abonara en cuotas______ de___________ ($________) cada una. Sumas todas"
            Dim LINEA29 As String = "estas que las partes convienen adicional al capital recibido en caso de ejecución."
            Dim LINEA30 As String = "TERCERA: La restitución del prestamo, se garantiza con un pagaré por la suma de"
            Dim LINEA31 As String = Num2Text(CInt(TotalSinDec)) & " CON " & decimalesTotal & "/100 ($" & Total & "), importe equivalente al"
            Dim LINEA32 As String = "que EL MUTUARIO recibe en mano al cual se le adiciona los gastos que surgen de la operación, con"
            Dim LINEA33 As String = "más los intereses devengados desde el momento del otorgamiento del crédito y hasta el pago de la"
            Dim LINEA34 As String = "última cuota. Si presentado este documento al cobro no fuere cancelado, se aplicará a partir de tal fecha"
            Dim LINEA35 As String = "(constitución en mora) un interés punitorio equivalente al___ por ciento (___%) del estipulado como"
            Dim LINEA36 As String = "compensatorio (y que se adicionará a este) que se devengará hasta la cancelación total de"
            Dim LINEA37 As String = "lo adeudado, capitalizándose en la forma prevista en el art. 770 del Código Civil y Comercial"
            Dim LINEA38 As String = "de la Nación, hasta la efectiva cancelación de lo adeudado. EL MUTUARIO acepta expresamente que el"
            Dim LINEA39 As String = "pagaré tendrá carácter circulatorio, prestando conformidad a que EL MUTUANTE pueda endosarlo a"
            Dim LINEA40 As String = "terceros, descontarlos en entidades bancarias, siempre y cuando se respete los términos del presente mutuo"
            Dim LINEA41 As String = "CUARTA: El incumplimiento de cualesquiera obligaciones contractuales, facultará al MUTUANTE a dar"
            Dim LINEA42 As String = "por caducados los plazos de las cuotas adeudadas, pudiendo reclamar el pago total de ellas como"
            Dim LINEA43 As String = "si fuesen vencidas y exigibles."
            Dim LINEA44 As String = "QUINTA: A todo efecto se tienen por legales los domicilios que figuran en los documentos de identidad"
            Dim LINEA45 As String = "del MUTUARIO y que debe ser coincidente con algún recibo de servicio público a su nombre."
            Dim LINEA46 As String = "SEXTA: En este acto EL MUTUARIO manifiesta bajo juramento de ley, que el presente instrumento como"
            Dim LINEA47 As String = "asimismo el pagaré que suscribe fue perfeccionado de manera manuscrita en su presencia, instrumentos"
            Dim LINEA48 As String = "estos que se le ha facilitado para su lectura, y por ende lo suscribe sin reserva alguna por no tener"
            Dim LINEA49 As String = "nada que objetar, en tanto que los mismo esta ceñidos a lo convenido."
            Dim LINEA50 As String = "SEPTIMA: Si ocurriera cualquiera de los hechos que a continuación se consignan:"
            Dim LINEA51 As String = "El no pago de las cuotas del capital, intereses, o cualquier otro importe adeudado por EL MUTUARIO al"
            Dim LINEA52 As String = "MUTUANTE en la fecha en que debiera ser pagado en virtud del presente o en virtud de cualquier"
            Dim LINEA53 As String = "otra operación con el MUTUANTE; o EL MUTUARIO no cumpliera con alguna obligación a su cargo"
            Dim LINEA54 As String = "o clausula bajo el presente, o cualquiera de las declaraciones o garantías efectuadas en este"
            Dim LINEA55 As String = "contrato no fuera cierta o no se mantuviera vigente o no fuera cumplimentada durante el lapso de"
            Dim LINEA56 As String = "duración de este contrato; o la falta de pago de cualquier otra obligación de cualquier índole,"
            Dim LINEA57 As String = "asumida por EL MUTUARIO respecto de terceros acreedores en la fecha que debiera ser pagada"
            Dim LINEA58 As String = "(ya sea al vencimiento estipulado, por caducidad de plazos o aceleración, o que de otro modo"
            Dim LINEA59 As String = "se encuentre de plazo vencido); o la falta de cumplimiento de obligaciones o condiciones"
            Dim LINEA60 As String = "contractuales relacionadas con esas deudas si tal incumplimiento puede ocasionar el aceleramiento"
            Dim LINEA61 As String = "o la caducidad de plazos de esas deudas; o la declaración de que esas deudas deban ser pagadas"
            Dim LINEA62 As String = "antes del vencimiento originalmente estipulado; o se trabara embargo o se dictara cualquier otra"
            Dim LINEA63 As String = "medida cautelar sobre los bienes del MUTUARIO y no fuera levantada en la primera oportunidad"
            Dim LINEA64 As String = "procesal disponible; o si EL MUTUARIO admitiera su inhabilidad de pagar sus deudas, o se presentara"
            Dim LINEA65 As String = "solicitando su concurso preventivo, su propia quiebra o ésta fuera solicitada por un acreedor"
            Dim LINEA66 As String = "y no levantada por EL MUTUARIO en la primera oportunidad procesal disponible, o si entrara cesación"
            Dim LINEA67 As String = "de pagos en los términos de los artículos 78 y 79 de la Ley 24.522; o, si como consecuencia de un"
            Dim LINEA68 As String = "cambio en las leyes o reglamentaciones o sus respectivas interpretaciones o principios de aplicación,"
            Dim LINEA69 As String = "o como consecuencia de una orden gubernamental o administrativa el MUTUANTE quedara sujeto a"
            Dim LINEA70 As String = "requisitos de reserva, gravámenes o impuestos que gravaran el préstamo o alteraran la base imponible de los"
            Dim LINEA71 As String = "importes adeudados bajo el presente, se impusiera al MUTUANTE límites de carteras, relaciones técnicas,"
            Dim LINEA72 As String = "tasas de interés obligatorias, indicativas u orientativas, depósitos especiales o encajes aplicables"
            Dim LINEA73 As String = "respecto de los activos o depósitos necesarios para el mantenimiento del préstamo o tales requisitos"
            Dim LINEA74 As String = "fueran modificados o considerados aplicables al MUTUANTE por la autoridad competente y el resultado"
            Dim LINEA75 As String = "de todo esto consistiera en la modificación del costo del MUTUANTE para mantener el préstamo o de"
            Dim LINEA76 As String = "las sumas a percibir por el MUTUANTE bajo el presente, o la imposibilidad para el MUTUANTE de"
            Dim LINEA77 As String = "mantener vigente el préstamo en las condiciones pactadas; o si ocurriera un cambio sustantivo"
            Dim LINEA78 As String = "desfavorable o un acontecimiento que en opinión del MUTUANTE diera motivo razonable para suponer que"
            Dim LINEA79 As String = "EL MUTUARIO no podrá cumplir u observar normalmente sus obligaciones conforme a las estipulaciones"
            Dim LINEA80 As String = "del presente. Si cualquiera de las cuentas corrientes que EL MUTUARIO tiene o tuviera abiertas en"
            Dim LINEA81 As String = "el sistema bancario local, fuese/sen cerrada/s por libramiento de cheques sin fondos o de"
            Dim LINEA82 As String = "autorización para girar en descubierto, o se dispusiera la inhabilitación del mismo para operar"
            Dim LINEA83 As String = "las mentadas cuentas. El MUTUANTE en cualquiera de estos casos podrá considerar la deuda como de plazo"
            Dim LINEA84 As String = "vencido sin necesidad de intimación extrajudicial o judicial previa, declarándose caducos todos los"
            Dim LINEA85 As String = "plazos o planes de pago estipulados bajo el presente. En consecuencia, la mora ante cualquier"
            Dim LINEA86 As String = "incumplimiento será automática por el solo transcurso de los términos por haberse producido alguno"
            Dim LINEA87 As String = "de los eventos estipulados, y sin necesidad de intimación extrajudicial o judicial previa, declarándose"
            Dim LINEA88 As String = "la deuda en su totalidad con intereses devengados, como de plazo vencido, pudiendo EL MUTUANTE, exigir"
            Dim LINEA89 As String = "el integro pago del capital e intereses devengados, costos y costas. Para dicho caso de mora, EL MUTUARIO"
            Dim LINEA90 As String = "acepta pagar en adición a la tasa de interés indicada en la cláusula SEGUNDA del presente, en concepto"
            Dim LINEA91 As String = "de interés punitorio, una tasa que a opción del MUTUANTE ascenderá a la máxima permitida por las normas"
            Dim LINEA92 As String = "legales en vigencia o al ___________ (%____) de la tasa de interés prevista en el art. 770 del CCC"
            Dim LINEA93 As String = "hasta la efectiva cancelación de lo adeudado."
            Dim LINEA94 As String = "OCTAVA: EL MUTUARIO declara que la presente operación no afecta sus necesidades mínimas y vitales"
            Dim LINEA95 As String = "ni las de su familia, y que el dinero lo obtiene para la adquisición de bienes que no conforman la"
            Dim LINEA96 As String = "canasta básica, para uso personal y de su familia."
            Dim LINEA97 As String = "NOVENA: En estos términos, yo EL MUTUARIO, acepto expresamente para el caso de que no cumpla"
            Dim LINEA98 As String = "con mi obligación, a que EL MUTUANTE pueda solicitar judicialmente se me embarguen los"
            Dim LINEA99 As String = "haberes que percibo por todo concepto y en la proporción de ley."
            Dim LINEA100 As String = "DECIMA: Se deja constancia que el presente contrato reviste el carácter de título ejecutivo, conforme el"
            Dim LINEA101 As String = "art. 521, inc. 2) del CPCC, siendo las del MUTUARIO las únicas obligaciones pendientes de cumplimiento."
            Dim LINEA102 As String = "EL MUTUARIO y EL MUTUANTE se someten a la jurisdicción exclusiva del Juzgado de Paz Letrado"
            Dim LINEA103 As String = "de Saladillo, Provincia de Buenos Aires y/o a la de los juzgados civiles y comerciales del Departamento"
            Dim LINEA104 As String = "Judicial La Plata, y renuncian a cualquier objeción que pudieran tener en la actualidad o en el futuro con"
            Dim LINEA105 As String = "respecto a la inconveniencia de la jurisdicción estipulada y constituyen a tal efecto domicilio legal"
            Dim LINEA106 As String = "en el detallado en el encabezamiento, donde se tendrán por validas todas las notificaciones extrajudiciales"
            Dim LINEA107 As String = "y judiciales que se cursen al mismo, no pudiendo EL MUTUARIO, modificar dicho domicilio sin previo"
            Dim LINEA108 As String = "consentimiento por escrito del MUTUANTE."
            Dim LINEA109 As String = "Nada de lo mencionado en esta cláusula puede afectar el derecho del MUTUANTE de notificar citaciones"
            Dim LINEA110 As String = "legales de cualquier otro modo autorizado por la ley, ni afectar el derecho del MUTUANTE de iniciar"
            Dim LINEA111 As String = "cualquier acción o proceso contra EL MUTUARIO, o sus bienes ante los juzgados y/o tribunales de"
            Dim LINEA112 As String = "cualquier otra jurisdicción."
            Dim LINEA113 As String = "En la medida en que EL MUTUARIO posea, o pudiera adquirir en el futuro, cualquier inmunidad con"
            Dim LINEA114 As String = "respecto a la jurisdicción de cualquier tribunal y/o juzgado o de cualquier otro procedimiento legal"
            Dim LINEA115 As String = "(ya sea a través del diligenciamiento o notificación, embargo preventivo, embargo ejecutivo,"
            Dim LINEA116 As String = "ejecución o de cualquier otro modo) sobre sí mismo o sus bienes, EL MUTUARIO conviene con carácter"
            Dim LINEA117 As String = "irrevocable por el presente renunciar a tal inmunidad con respecto a sus obligaciones del presente."
            Dim LINEA118 As String = "La falta de ejercicio o demora en el ejercicio por EL MUTUANTE, de cualquier derecho, facultad o"
            Dim LINEA119 As String = "privilegio en virtud del presente, no se considerará una renuncia al mismo, ni tampoco el ejercicio"
            Dim LINEA120 As String = "singular o parcial de todo otro derecho, facultad o privilegio en virtud del presente enervará el"
            Dim LINEA121 As String = "ejercicio de cualquier otro derecho. Los derechos y recursos aquí expuestos son acumulativos y no"
            Dim LINEA122 As String = "excluyentes de todo otro derecho o recurso dispuesto por la ley."
            Dim LINEA123 As String = "Se firman en prueba de conformidad dos ejemplares de un mismo tenor y a un solo efecto en la ciudad de"
            Dim LINEA124 As String = Ciudad & ", Provincia de Buenos Aires, a los " & Dia_Numero & " días del mes de " & Mes_Nombre & " del año " & Año_Numero & "."

            Dim LINEA125 As String = "________________________           ________________________           ________________________"
            Dim LINEA126 As String = "                FIRMA                                           ACLARACION                                          DNI"
            Dim LINEA127 As String = "________________________           ________________________           ________________________"
            Dim LINEA128 As String = "             DOMICILIO                                      LOCALIDAD                                      TELEFONO"

            'Título
            tituloContrato &= TITULO

            'Página 1
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
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
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA30
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA31
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA32
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA33
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA34
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA35
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA36
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA37
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA38
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA39
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA40
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA41
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA42
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA43
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA44
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA45
            lineasPagare &= Environment.NewLine
            lineasPagare &= Environment.NewLine
            lineasPagare &= LINEA46

            'Página 2
            lineasPagare2 &= LINEA47
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA48
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA49
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA50
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA51
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA52
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA53
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA54
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA55
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA56
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA57
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA58
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA59
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA60
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA61
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA62
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA63
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA64
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA65
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA66
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA67
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA68
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA69
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA70
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA71
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA72
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA73
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA74
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA75
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA76
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA77
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA78
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA79
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA80
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA81
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA82
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA83
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA84
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA85
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA86
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA87
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA88
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA89
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA90
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA91
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA92
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA93
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA94
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA95
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA96
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA97
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA98
            lineasPagare2 &= Environment.NewLine
            lineasPagare2 &= LINEA99

            'Página 3
            lineasPagare3 &= LINEA100
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA101
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA102
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA103
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA104
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA105
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA106
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA107
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA108
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA109
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA110
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA111
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA112
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA113
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA114
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA115
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA116
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA117
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA118
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA119
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA120
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA121
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA122
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA123
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA124
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA125
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA126
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA127
            lineasPagare3 &= Environment.NewLine
            lineasPagare3 &= LINEA128

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

        If Ref_Activo = "SI" Then

            'Título
            e.Graphics.MeasureString(Mid(tituloContrato, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
            e.Graphics.DrawString(tituloContrato.Substring(currentChar, chars), New Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, b, format)

            'Texto
            e.Graphics.MeasureString(Mid(lineasPagare, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
            e.Graphics.DrawString(lineasPagare.Substring(currentChar, chars), New Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, b, format)

            e.HasMorePages = False

        Else
            If Selec_pagina = 1 Then
                Do
                    Dim pagina_seleccionada As String = InputBox("¿Qué página desea imprimir?", "Página", "")
                    If pagina_seleccionada = "1" Then
                        pagina = 1
                        Exit Do
                    ElseIf pagina_seleccionada = "2" Then
                        pagina = 2
                        Exit Do
                    ElseIf pagina_seleccionada = "3" Then
                        pagina = 3
                        Exit Do
                    ElseIf pagina_seleccionada > 3 Then
                        MessageBox.Show("No existe esa página, por favor seleccione 1, 2 o 3.")
                    End If
                Loop

            End If

            If Selec_pagina = 0 Then
                Dim result As Integer = MessageBox.Show("¿Desea imprimir sólo una página del contrato?", "Contrato", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Selec_pagina = 3
                ElseIf result = DialogResult.Yes Then
                    Selec_pagina = 1
                    If Selec_pagina = 1 Then
                        Do
                            Dim pagina_seleccionada As String = InputBox("¿Qué página desea imprimir?", "Página", "")
                            If pagina_seleccionada = "1" Then
                                pagina = 1
                                Exit Do
                            ElseIf pagina_seleccionada = "2" Then
                                pagina = 2
                                Exit Do
                            ElseIf pagina_seleccionada = "3" Then
                                pagina = 3
                                Exit Do
                            ElseIf pagina_seleccionada > 3 Then
                                MessageBox.Show("No existe esa página, por favor seleccione 1, 2 o 3.")
                            End If
                        Loop
                    End If
                End If
            End If

            If pagina = 1 Then
                'Título
                e.Graphics.MeasureString(Mid(tituloContrato, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
                e.Graphics.DrawString(tituloContrato.Substring(currentChar, chars), New Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, b, format)

                'Texto
                e.Graphics.MeasureString(Mid(lineasPagare, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
                e.Graphics.DrawString(lineasPagare.Substring(currentChar, chars), New Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, b, format)

                If Selec_pagina = 1 Then
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                End If

                pagina = 2
            ElseIf pagina = 2 Then
                'Texto
                e.Graphics.MeasureString(Mid(lineasPagare2, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
                e.Graphics.DrawString(lineasPagare2.Substring(currentChar, chars), New Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, b, format)

                If Selec_pagina = 1 Then
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                End If

                pagina = 3
            ElseIf pagina = 3 Then
                'Texto
                e.Graphics.MeasureString(Mid(lineasPagare3, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
                e.Graphics.DrawString(lineasPagare3.Substring(currentChar, chars), New Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, b, format)
                e.HasMorePages = False
                pagina = 0
            End If
        End If

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