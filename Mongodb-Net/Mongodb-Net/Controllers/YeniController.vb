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
                Return RedirectToAction("Index", "Home")
            End If

        End If

        Return View()
    End Function


    Function Album() As ActionResult
        Return View()
    End Function

End Class