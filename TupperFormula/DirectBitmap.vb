Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

' Creadit: SaxxonPike (http://stackoverflow.com/users/3117338/saxxonpike)
' http://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-And-getpixel-for-bitmaps-for-windows-f

Public Class DirectBitmap
    Implements IDisposable

    Public ReadOnly Property Bitmap As Bitmap
    Public ReadOnly Property Width As Integer
    Public ReadOnly Property Height As Integer
    Public ReadOnly Property Bits As Byte()

    Private bitsHandle As GCHandle

    Public Sub New(w As Integer, h As Integer)
        Me.Width = w
        Me.Height = h
        ReDim Bits(w * h * 4)
        bitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned)
        Me.Bitmap = New Bitmap(w, h, w * 4, PixelFormat.Format32bppPArgb, bitsHandle.AddrOfPinnedObject())
    End Sub

    Public Shared Widening Operator CType(bmp As Bitmap) As DirectBitmap
        If bmp Is Nothing Then Return Nothing

        Dim dbmp As New DirectBitmap(bmp.Width, bmp.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.DrawImageUnscaled(bmp, Point.Empty)
        End Using

        Return dbmp
    End Operator

    Public Shared Narrowing Operator CType(dbmp As DirectBitmap) As Bitmap
        If dbmp Is Nothing Then Return Nothing
        Return dbmp.Bitmap
    End Operator

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                Bitmap.Dispose()
                bitsHandle.Free()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
