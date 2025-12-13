Imports System.Data.SqlClient
Imports System.Configuration

Public Class Administrador
    Inherits System.Web.UI.Page

    ' Cadena de conexión correcta
    Private ReadOnly connectionString As String =
        ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarProductos()
        End If
    End Sub

    Private Sub CargarProductos()
        gvProductos.DataSource = GetProductosConProveedor()
        gvProductos.DataBind()
    End Sub

    Public Function GetProductosConProveedor() As DataTable
        Dim dt As New DataTable()

        Dim sql As String = "
            SELECT 
                p.IDproducto,
                p.Descripcion,
                p.precio,
                p.Cantidad,
                p.proveedor_id
            FROM productos p
            INNER JOIN Proveedores pr ON p.proveedor_id = pr.id
        "

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(sql, con)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

End Class
