Imports System.Data.SqlClient

Public Class Buscar

    Private _id As Integer
    Private _empresa As String
    Private _telefono As String
    Private _producto As String
    Private _cantidad As Integer
    Private ddlProducto As Object
    Private lblMsg As Object

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Empresa As String
        Get
            Return _empresa
        End Get
        Set(value As String)
            _empresa = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

    Public Property Producto As String
        Get
            Return _producto
        End Get
        Set(value As String)
            _producto = value
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

    Public Property TxtPrecioProveedor As Object

    Public Sub New()

    End Sub

    Public Sub New(id As Integer, empresa As String, telefono As String, producto As String, cantidad As Integer)
        Me.Id = id
        Me.Empresa = empresa
        Me.Producto = producto
        Me.Cantidad = cantidad

    End Sub


    Protected Sub Btn_AgregarProducto_Click(sender As Object, e As EventArgs)
            Try
                Dim idProveedor As Integer = Convert.ToInt32(ddlProveedor.SelectedValue)
                Dim idProducto As Integer = Convert.ToInt32(ddlProducto.SelectedValue)
                Dim precioProv As Decimal = Decimal.Parse(TxtPrecioProveedor.Text)

                Dim cs As String = System.Configuration.ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

                Using cn As New SqlConnection(cs)
                    cn.Open()


                Dim sql As String = "IF EXISTS (SELECT 1 FROM dbo.ProveedorProducto WHERE IdProveedor=@IdProveedor AND IdProducto=@IdProducto)
                         UPDATE dbo.ProveedorProducto SET PrecioProveedor=@PrecioProveedor
                         WHERE IdProveedor=@IdProveedor AND IdProducto=@IdProducto
                     ELSE
                         INSERT INTO dbo.ProveedorProducto (IdProveedor, IdProducto, PrecioProveedor)
                         VALUES (@IdProveedor, @IdProducto, @PrecioProveedor);"

                Using cmd As New SqlCommand(sql, cn)
                        cmd.Parameters.AddWithValue("@IdProveedor", idProveedor)
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto)
                        cmd.Parameters.AddWithValue("@PrecioProveedor", precioProv)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                lblMsg.CssClass = "text-success mt-2 d-block"
                lblMsg.Text = "✅ Producto ligado al proveedor."

                TxtPrecioProveedor.Text = ""
                gvResultado.DataBind()

            Catch ex As Exception
            lblMsg.CssClass = "text-danger mt-2 d-block"
            lblMsg.Text = "❌ Error: " & ex.Message
            End Try
        End Sub

    End Class


