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
        If _Album IsNot Nothing Then
            Dim sil = mCon.DeleteAlbum(_Album)
            If sil Then
                Return RedirectToAction("Index")
            End If
        End If
        Return View()
    End Function

    Function Sanatci(id As String) As ActionResult
        Dim oid = ObjectId.Parse(id)
        Dim _Artist = mCon.GetArtistFrom_id(oid)
        If _Artist IsNot Nothing Then
            Dim sil = mCon.DeleteArtist(_Artist)
            If sil Then
                Return RedirectToAction("Index")
            End If
        End If
        Return View()
    End Function

End Class
