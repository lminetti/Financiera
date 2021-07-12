Public Class Apertura_Caja
    Public Property Operador As String
    Dim ValorApertura As String = ""
    Dim lineasCierreT As String = ""
    Dim lineasCierre1 As String = ""
    Dim lineasCierre2 As String = ""
    Dim lineasCierre3 As String = ""
    Dim lineasCierre4 As String = ""
    Dim caja As String = ""
    Dim total As String = ""

    Private Sub Apertura_Caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.OPERADORESTableAdapter.Fill(Me.AJUSTESDataSet.OPERADORES)
        Me.CONTABLETableAdapter.Fill(Me.DATABASEDataSet.CONTABLE)

    End Sub

End Class