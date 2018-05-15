Imports System.Numerics

Public Class TupperNumber
    Public ReadOnly Property Name As String
    Public Property Number As BigInteger
    Public ReadOnly Property FlipXY As Boolean
    Public ReadOnly Property InvertColors As Boolean

    Public Sub New(name As String, initialNumber As String, Optional flipXY As Boolean = False, Optional invertColors As Boolean = False)
        Me.Name = name
        Me.Number = BigInteger.Parse(initialNumber)
        Me.FlipXY = flipXY
        Me.InvertColors = invertColors
    End Sub

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
