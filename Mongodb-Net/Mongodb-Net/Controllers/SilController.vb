Imports MongoDB.Bson
Imports MongoDB.Driver
Imports MongoDB.Driver.Builders
Imports Mongodb_Net.Connect

Public Class SilController
    Inherits BaseController

    '
    ' GET: /Sil

    Function Album(id As String) As ActionResult
        Dim oid = ObjectId.Parse(id)
        Dim _Album = mCon.GetAlbumFrom_id(oid)
        MsgBox(_Album.Isim)
        Return View()
    End Function

    Function Sanatci() As ActionResult
        Return View()
    End Function

End Class
