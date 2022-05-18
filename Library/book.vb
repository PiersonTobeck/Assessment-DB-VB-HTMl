Public Class Book

    'Declaration of variables

    Private Title As String
    Private Author As Author
    Private Publisher As String
    Private Isbn As Double
    Private EstValue As Double

    'Constructors

    Public Sub New(Title As String, Author As Author, Publisher As String, ISBN As Double, Value As Double)

        Me.Title = Title
        Me.Author = Author
        Me.Publisher = Publisher
        Me.Isbn = ISBN
        Me.EstValue = Value

    End Sub

    Public Sub New()

    End Sub

    'Methods

    'Getters

    ''' <summary>
    ''' Returns the title of selected book
    ''' </summary>
    ''' <returns> string </returns>
    Public Function GetTitle() As String

        Return Me.Title

    End Function

    ''' <summary>
    ''' Returns the Author of selected book
    ''' </summary>
    ''' <returns> string </returns>

    Public Function GetAuthor() As Author

        Return Me.Author

    End Function

    ''' <summary>
    ''' Returns the Publisher of selected book
    ''' </summary>
    ''' <returns> string </returns>

    Public Function GetPublisher() As String

        Return Me.Publisher

    End Function

    ''' <summary>
    ''' Returns the ISBN of selected book
    ''' </summary>
    ''' <returns> Double </returns>

    Public Function GetIsbn() As Double

        Return Me.Isbn

    End Function

    ''' <summary>
    ''' Returns the Estimated Value of selected book
    ''' </summary>
    ''' <returns> Double </returns>

    Public Function GetValue() As Double

        Return Me.EstValue

    End Function

    'Setters
    ''' <summary>
    ''' Sets the title of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>
    Public Function SetTitle(x As String)

        Me.Title = x

        Return Nothing

    End Function

    ''' <summary>
    ''' Sets the author of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>

    Public Function SetAuthor(x As Author)

        Me.Author = x

        Return Nothing

    End Function

    ''' <summary>
    ''' Sets the publisher of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>
    ''' 
    Public Function SetPublisher(x As String)

        Me.Publisher = x

        Return Nothing

    End Function

    ''' <summary>
    ''' Sets the ISBN of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>
    Public Function SetIsbn(x As Double)

        Me.Isbn = x

        Return Nothing

    End Function

    ''' <summary>
    ''' Sets the estimated value of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>
    Public Function SetEstValue(x As Double)

        Me.EstValue = x

        Return Nothing

    End Function

End Class
