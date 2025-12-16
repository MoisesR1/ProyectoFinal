Public Class Productos
    Private _id As Integer
    Private _descripcion As String
    Private _precio As Decimal
    Private _cantidad As Integer
    Public Property IdProveedor As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Precio As Decimal
        Get
            Return _precio
        End Get
        Set(value As Decimal)
            _precio = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(id As Integer, descripcion As String, precio As Decimal, cantidad As Integer)
        Me.Id = id
        Me.Descripcion = descripcion
        Me.Precio = precio
        Me.Cantidad = cantidad
    End Sub
End Class
