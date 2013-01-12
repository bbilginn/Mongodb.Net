Imports Mongodb_Net.Connect

    Public Class BaseController
        Inherits System.Web.Mvc.Controller

        Friend mCon As New Manager
        Private Disposed As Boolean = False


#Region "IDisposable"

        Protected Shadows Sub Dispose()
            Me.Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Shadows Sub Dispose(disposing As Boolean)
            If Not Me.Disposed Then
                If disposing Then
                Me.mCon.Dispose()
                End If
            End If

            Me.Disposed = True
        End Sub

#End Region

End Class