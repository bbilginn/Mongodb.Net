Imports MongoDB.Driver
Imports MongoDB.Driver.Builders
Imports MongoDB.Bson


Namespace Connect


    Public Class Manager
        Implements IDisposable

        Private Disposed As Boolean = False
        Private ConnectionString = "server=ds047107.mongolab.com:47107;database=sanatcidb;safe=true;username=SanatciAdmin;Password=123456"
        Private Builder = New MongoConnectionStringBuilder(ConnectionString)

        Private Server As MongoServer = MongoServer.Create(Builder)
        Private db As MongoDatabase = Server("sanatcidb")

        Friend Collection As MongoCollection(Of Sanatci)


        Public Function GetArtists() As IEnumerable(Of Sanatci)
            Try
                Return Collection.FindAll().ToList
            Catch generatedExceptionName As MongoConnectionException
                Return New List(Of Sanatci)()
            End Try
        End Function

        Public Function GetArtistFrom_id(id As ObjectId) As Sanatci
            Try
                'Dim qry = Query.EQ("_id", id)
                'Dim qry = Query(Of Sanatci).EQ(Function(x) x._id = id)

                Return Collection.FindOneByIdAs(Of Sanatci)(id) 'Collection.FindOneAs(Of Sanatci)(qry)

            Catch generatedExceptionName As MongoConnectionException
                Return Nothing
            End Try
        End Function

        Public Function GetArtistFromAlbum_id(id As ObjectId) As Sanatci
            Try
                Dim qry = Query.EQ("Albums._id", id)

                Return Collection.FindOneAs(Of Sanatci)(qry)

            Catch generatedExceptionName As MongoConnectionException
                Return Nothing
            End Try
        End Function

        Public Function GetAlbumFrom_id(id As ObjectId) As Album
            Try
                Dim qry = Query.EQ("Albums._id", id)

                Return Collection.FindOneAs(Of Sanatci)(qry).Albums.FirstOrDefault(Function(x) x._id = id)

            Catch generatedExceptionName As MongoConnectionException
                Return Nothing
            End Try
        End Function

        Public Function CreateArtist(Sanatci As Sanatci) As Boolean
            Try
                Return Collection.Insert(Sanatci, SafeMode.True).Ok
            Catch ex As MongoCommandException
                Dim msgLog As String = ex.Message
                Return False
            End Try
        End Function

        Public Function CreateAlbum(Sanatci_id As ObjectId, Album As Album) As Boolean
            Try
                Dim Artist = GetArtistFrom_id(Sanatci_id)
                Album._id = ObjectId.GenerateNewId
                Artist.Albums.Add(Album)
                Return Collection.Save(Artist, SafeMode.True).Ok
            Catch ex As MongoCommandException
                Dim msgLog As String = ex.Message
                Return False
            End Try
        End Function

        Public Function DeleteArtist(sanatci As Sanatci) As Boolean
            Try
                Return Collection.Remove(Query.EQ("_id", sanatci._id)).Ok
            Catch ex As MongoCommandException
                Dim msgLog As String = ex.Message
                Return False
            End Try
        End Function

        Public Function DeleteAlbum(Artist As Sanatci, album As Album) As Boolean
            Try
                'Artist.Albums.Remove(album)
                'Return Collection.Save(Artist, SafeMode.True).Ok

                'Return Collection.Update(
                'Query.EQ("Albums._id", album._id),
                'Update.Pull("Albums.$", BsonDocumentWrapper.Create(Of Album)(album)), SafeMode.True
                ').Ok

                Return Collection.Update(
                Query.EQ("Albums._id", album._id),
                Update.Pull("Albums", Query.EQ("_id", album._id)), SafeMode.True
                ).Ok
            Catch ex As MongoCommandException
                Dim msgLog As String = ex.Message
                Return False
            End Try
        End Function

        Public Function UpdateAlbum(album As Album) As Boolean
            Try
                Return Collection.Update(
                Query.EQ("Albums._id", album._id),
                Update.Set("Albums.$", BsonDocumentWrapper.Create(Of Album)(album)), SafeMode.True
                ).Ok
            Catch ex As MongoCommandException
                Dim msgLog As String = ex.Message
                Return False
            End Try
        End Function

        Public Function UpdateArtist(sanatci As Sanatci) As Boolean
            Try
                Dim Duz = Collection.FindOneAs(Of Sanatci)(Query.EQ("_id", sanatci._id))
                Duz = sanatci
                Collection.Save(Duz)

                'Return Collection.Update(Query.EQ("_id", sanatci._id),
                '                         Update.Set("$", BsonDocumentWrapper.Create(Of Sanatci)(sanatci)),
                '                         SafeMode.True).Ok
                Return True
            Catch ex As MongoCommandException
                Dim msgLog As String = ex.Message
                Return False
            End Try
        End Function

        Private Function GetArtistsCollection() As MongoCollection(Of Sanatci)
            Return db.GetCollection(Of Sanatci)("Sanatci")
        End Function


        Sub New()
            Collection = GetArtistsCollection()
        End Sub

#Region "IDisposable"

        Public Sub Dispose() Implements IDisposable.Dispose
            Me.Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.Disposed Then
                If disposing Then
                    If Server IsNot Nothing Then
                        Me.Server.Disconnect()
                    End If
                End If
            End If

            Me.Disposed = True
        End Sub

#End Region

    End Class


End Namespace
