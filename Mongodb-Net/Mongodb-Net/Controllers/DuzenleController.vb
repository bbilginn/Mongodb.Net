Imports MongoDB.Bson
Imports MongoDB.Driver
Imports MongoDB.Driver.Builders
Imports Mongodb_Net.Connect

Public Class DuzenleController
    Inherits BaseController

    '
    ' GET: /Duzenle


    Function Album(id As String) As ActionResult
        Dim oid = ObjectId.Parse(id)
        Dim _Album = mCon.GetAlbumFrom_id(oid)
        Return View(_Album)
    End Function
    <HttpPost>
    Function Album(id As String, model As Album) As ActionResult
        If ModelState.IsValid Then
            model._id = ObjectId.Parse(id)
            If mCon.UpdateAlbum(model) Then
                Return Redirect(Request.UrlReferrer.AbsoluteUri)
            End If

        End If

        Return View(model)
    End Function

    Function Sanatci(id As String) As ActionResult
        Dim oid = ObjectId.Parse(id)
        Dim _Sanatci = mCon.GetArtistFrom_id(oid)
        Return View(_Sanatci)
    End Function
    <HttpPost>
    Function Sanatci(id As String, model As Sanatci) As ActionResult
        If ModelState.IsValid Then
            model._id = ObjectId.Parse(id)
            If mCon.UpdateArtist(model) Then
                Return Redirect(Request.UrlReferrer.AbsoluteUri)
            End If

        End If

        Return View(model)
    End Function


End Class

