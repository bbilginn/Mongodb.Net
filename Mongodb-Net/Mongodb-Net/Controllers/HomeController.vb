Imports MongoDB.Bson
Imports MongoDB.Driver
Imports MongoDB.Driver.Builders
Imports Mongodb_Net.Connect

Public Class HomeController
    Inherits BaseController
    Implements IDisposable


    Function Index() As ActionResult
        Dim Sanatcilar = mCon.GetArtists

        Return View(Sanatcilar)
    End Function


End Class
