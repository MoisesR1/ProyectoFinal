

Public Class Proveedor
        Private _id As Integer
        Private _empresa As String
        Private _telefono As String
        Private _direccion As String

        Public Property id As Integer
            Get
                Return _id
            End Get
            Set(value As Integer)
                _id = value
            End Set
        End Property

        Public Property empresa As String
            Get
                Return _empresa
            End Get
            Set(value As String)
                _empresa = value
            End Set
        End Property

        Public Property telefono As String
            Get
                Return _telefono
            End Get
            Set(value As String)
                _telefono = value
            End Set
        End Property

        Public Property direccion As String
            Get
                Return _direccion
            End Get
            Set(value As String)
                _direccion = value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(id As Integer, telefono As String, empresa As String, direccion As String)
            Me.id = id
            Me.telefono = telefono
            Me.empresa = empresa
            Me.direccion = direccion
        End Sub
    End Class


