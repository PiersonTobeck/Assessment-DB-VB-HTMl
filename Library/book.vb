Public Class Book

    'Declaration of variables

    Private Title As String
    Private Author As String
    Private Publisher As String
    Private Isbn As Double
    Private EstValue As Double

    'Constructors

    Public Sub New(a As String, b As String, c As String, d As Double, e As Double)

        Me.Title = a
        Me.Author = b
        Me.Publisher = c
        Me.Isbn = d
        Me.EstValue = e

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

    Public Function GetAuthor() As String

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

    Public Function GetEstValue() As Double

        Return Me.EstValue

    End Function

    ''' <summary>
    ''' Returns all information of selected book 
    ''' </summary>
    ''' <returns> string </returns>
    Public Function GetBookInfo()

        Return String.Format("Title: " & Me.GetTitle &
                             Environment.NewLine + " Author: " & Me.GetAuthor &
                             Environment.NewLine + " Publisher: " & Me.GetPublisher &
                             Environment.NewLine + " Isbn: " & Me.GetIsbn &
                             Environment.NewLine + " EstValue: " & Me.GetEstValue)

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

    Public Function SetAuthor(x As String)

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
