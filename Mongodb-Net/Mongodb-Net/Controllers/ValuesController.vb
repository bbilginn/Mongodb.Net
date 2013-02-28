Imports System.Net
Imports System.Web.Http
Imports Mongodb_Net.Connect

Public Class ValuesController
    Inherits ApiController

    Friend mCon As New Manager

    ' GET api/values
    Public Function GetValues() As IEnumerable(Of Sanatci)
        Return mCon.GetArtists
    End Function

    ' GET api/values/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/values
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/values/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/values/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
