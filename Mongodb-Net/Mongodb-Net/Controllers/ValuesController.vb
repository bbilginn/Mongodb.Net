Imports System.Net
Imports System.Web.Http
Imports Mongodb_Net.Connect
Imports MongoDB.Bson

Public Class ValuesController
    Inherits ApiController

    Friend mCon As New Manager

    ' GET api/values
    <HttpOptions> <HttpGet>
    Public Function GetValues() As JsonResult
        Return New JsonResult() With {
            .Data = mCon.GetArtists.Select(Function(x) New With {._id = x._id.ToString,
                                                                 .Ad = x.Ad,
                                                                 .Albums = x.Albums.Select(Function(y) New With {
                                                                                               .Isim = y.Isim,
                                                                                               .Resim = y.Resim,
                                                                                               .Yil = y.Yil})}),
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            .ContentType = "Application/Json"}
    End Function

    ' GET api/values/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/values
    Public Function PostValue(value As Sanatci) As String
        Try
            value._id = ObjectId.GenerateNewId
            If mCon.CreateArtist(value) Then
                Return value._id.ToString
            Else
                Return False
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    ' PUT api/values/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/values/5
    Public Function DeleteValue(ByVal id As String)
        Dim oid = ObjectId.Parse(id)
        Dim _Artist = mCon.GetArtistFrom_id(oid)
        If _Artist IsNot Nothing Then
            Return mCon.DeleteArtist(_Artist)
        End If
        Return False
    End Function
End Class
