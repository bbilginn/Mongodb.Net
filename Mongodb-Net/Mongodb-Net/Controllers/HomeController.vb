Imports MongoDB.Bson
Imports MongoDB.Driver
Imports MongoDB.Driver.Builders
Imports Mongodb_Net.Connect

Public Class HomeController
    Inherits BaseController
    Implements IDisposable


    Function Index() As ActionResult
        Dim _Sanatcilar = mCon.GetArtists

        Return View(_Sanatcilar)
    End Function

    Function Sanatci(id As String) As ActionResult
        Dim oid = ObjectId.Parse(id)
        'Dim _Sanatci = mCon.GetArtists.FirstOrDefault(Function(x) x._id = oid)
        Dim _Sanatci = mCon.GetArtistFrom_id(oid)

        Return View(_Sanatci)
    End Function



End Class
