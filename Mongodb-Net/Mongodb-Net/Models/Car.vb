Imports MongoDB.Bson

Class Car
    Public Property _id As ObjectId
    Public Property Marka As String = String.Empty
    Public Property Model As Integer = 0

    Public Sub New()
        _id = New ObjectId()
    End Sub

End Class