

Public Class Models

    Public Class DiscountItem
        Public Property Name As String
        Public Property Value As Decimal

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Public Class ProductItem
        Public Property ID As Integer
        Public Property Name As String
        Public Property Description As String
        Public Property Price As Decimal

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

End Class
