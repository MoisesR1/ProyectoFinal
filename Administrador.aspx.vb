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
            CargarProductos()
            gvAdmin.DataSource = Nothing
            gvAdmin.DataBind()
        End If
    End Sub

    Private Sub CargarProductos()
        Dim dtProductos As DataTable = dbProductos.ObtenerProductos()
        ddlProductos.DataSource = dtProductos
        ddlProductos.DataTextField = "Descripcion"
        ddlProductos.DataValueField = "IDproducto"
        ddlProductos.DataBind()

        ddlProductos.Items.Insert(0, New ListItem("--Seleccione un producto--", "0"))
    End Sub

    Protected Sub BtnBusqueda_Click(sender As Object, e As EventArgs) Handles BtnBusqueda.Click
        Try
            Dim idProducto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)

            If idProducto = 0 Then
                lblMensaje.CssClass = "text-danger fw-bold mt-2"
                lblMensaje.Text = "Por favor, seleccione un producto válido."
                gvAdmin.DataSource = Nothing
                gvAdmin.DataBind()
                Return
            End If

            Dim dt As DataTable = dbHelper.ObtenerProductoPorId(idProducto)

            If dt.Rows.Count > 0 Then
                gvAdmin.DataSource = dt
                gvAdmin.DataBind()
                lblMensaje.Text = ""
            Else
                gvAdmin.DataSource = Nothing
                gvAdmin.DataBind()
                lblMensaje.CssClass = "text-danger fw-bold mt-2"
                lblMensaje.Text = "No se encontró información para este producto."
            End If

        Catch ex As Exception
            lblMensaje.CssClass = "text-danger fw-bold mt-2"
            lblMensaje.Text = "Error: " & ex.Message
        End Try
    End Sub
End Class


