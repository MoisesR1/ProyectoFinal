Imports System.Data
Imports ProyectoFinal

Public Class Admin
    Inherits System.Web.UI.Page

    Private dbHelper As New dbAdmin()
    Private dbProductos As New dbProductos()
    Private dbProveedores As New dbProveedores()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Usuario") Is Nothing OrElse Session("Rol") <> "2" Then
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            CargarProveedores()
            CargarDatos()
        End If
    End Sub

    Private Sub CargarProveedores()
        Dim dtProveedores As DataTable = dbProveedores.ObtenerProveedores()

        ddlProveedores.DataSource = dtProveedores
        ddlProveedores.DataTextField = "empresa"
        ddlProveedores.DataValueField = "Id"
        ddlProveedores.DataBind()

        ddlProveedores.Items.Insert(0, New ListItem("--Seleccione proveedor--", "0"))
    End Sub

    Private Sub CargarDatos()
        Dim dt As DataTable = dbHelper.ObtenerProductosConProveedores()
        gvAdmin.DataSource = dt
        gvAdmin.DataBind()
    End Sub

    Protected Sub BtnAgregar_Click(sender As Object, e As EventArgs)
        Try
            Dim proveedorId As Integer = Convert.ToInt32(ddlProveedores.SelectedValue)
            If proveedorId = 0 Then
                lblMensaje.Text = "Por favor, seleccione un proveedor válido."
                Return
            End If

            Dim nuevoProducto As New Productos With {
                .Descripcion = TxtDescripcion.Text.Trim(),
                .Precio = Convert.ToDecimal(TxtPrecio.Text),
                .Cantidad = Convert.ToInt32(TxtCantidad.Text),
                .IdProveedor = proveedorId
            }

            Dim mensaje = dbProductos.Create(nuevoProducto)

            If mensaje.Contains("Error") Then
                lblMensaje.Text = mensaje
            Else
                lblMensaje.CssClass = "text-success fw-bold mt-2"
                lblMensaje.Text = mensaje

                ' Limpiar campos después de agregar
                TxtDescripcion.Text = ""
                TxtPrecio.Text = ""
                TxtCantidad.Text = ""
                ddlProveedores.SelectedIndex = 0

                gvAdmin.DataBind()
                CargarDatos()
            End If

        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
        End Try
    End Sub

End Class

