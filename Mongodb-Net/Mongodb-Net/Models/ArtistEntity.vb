Imports MongoDB.Bson

Public Class Sanatci
    Public Property _id As ObjectId
    Public Property Ad As String = String.Empty
    Public Property Albums As List(Of Album)

    Public Sub New()
        _id = New ObjectId()
    End Sub
End Class

Public Class Album
    Public Property Isim As String = String.Empty
    Public Property Yil As Short = 0
    Public Property Resim As String = String.Empty
End Class
