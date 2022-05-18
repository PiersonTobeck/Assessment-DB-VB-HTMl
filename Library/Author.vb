Public Class Author

    Private id As Integer

    Private FName, Lname As String

    Public Sub New(AuthorName As String)


        'grab the data
        Dim AuthorArray As String() = Split(AuthorName)

        Me.FName = AuthorArray(0)

        Me.Lname = AuthorArray(1)

    End Sub

    Public Sub New()

    End Sub

    Public Function setID(ID As Integer)

        Me.id = ID

        Return Nothing

    End Function

    Public Function setName(FName As String, LName As String)

        Me.FName = FName

        Me.Lname = LName

        Return Nothing

    End Function

    Public Function getID()

        Return Me.id

    End Function

    Public Function getFName()

        Return Me.FName

    End Function
    Public Function getLName()

        Return Me.Lname

    End Function
    Public Function getbook()

        Return Me

    End Function

End Class
