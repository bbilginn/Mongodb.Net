Imports MongoDB.Bson
Imports MongoDB.Driver
Imports MongoDB.Driver.Builders
Imports Mongodb_Net.Connect

Public Class YeniController
    Inherits BaseController

    '
    ' GET: /Yeni

    Function Sanatci() As ActionResult
        Return View()
    End Function
    <HttpPost>
    Function Sanatci(model As Sanatci) As ActionResult
        If ModelState.IsValid Then
            Dim kayit = mCon.CreateArtist(model)
            If kayit Then
                Return RedirectToAction("Sanatci", "Home", New With {.id = model._id})
            End If

        End If

        Return View()
    End Function


    Function Album() As ActionResult
        Return View()
    End Function
    <HttpPost>
    Function Album(id As String, model As Album) As ActionResult
        If ModelState.IsValid Then
            Dim oid = ObjectId.Parse(id)
            Dim ekle = mCon.CreateAlbum(oid, model)
            If ekle Then
                Return RedirectToAction("Sanatci", "Home", New With {.id = id})
            End If

        End If

        Return View()
    End Function

End Class