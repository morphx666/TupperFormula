Imports System.Numerics

Public Class TupperNumber
    Public Property InitialNumber As BigInteger
    Public ReadOnly Property FlipXY As Boolean
    Public ReadOnly Property InvertColors As Boolean

    Public Sub New(initialNumber As String, Optional flipXY As Boolean = False, Optional invertColors As Boolean = False)
        Me.InitialNumber = BigInteger.Parse(initialNumber)
        Me.FlipXY = flipXY
        Me.InvertColors = invertColors
    End Sub
End Class
