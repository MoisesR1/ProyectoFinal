Public Class FormProveedores
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbProveedores()
    Public proveedor As New Proveedor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rol As Integer = Session("Rol")
        If rol = 0 Then
            Response.Redirect("~/Login.aspx")
        End If
        If rol = 1 Then

            gvProveedores.Columns(0).Visible = False
            gvProveedores.Columns(5).Visible = False
            Txt_idproveedor.Visible = False
            Txt_empresa.Visible = False
            Txt_telefono.Visible = False
            Txt_direccion.Visible = False
            Btn_Agregar.Visible = False

        End If

    End Sub



    Protected Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click
        'proveedor.id = Convert.ToInt32(Txt_idproveedor.Text)
        proveedor.empresa = Txt_empresa.Text
        proveedor.telefono = Convert.ToInt32(Txt_telefono.Text)
        proveedor.direccion = (Txt_direccion.Text)
        lblMensaje.Text = dbHelper.Create(proveedor)
        gvProveedores.DataBind()
    End Sub

    Protected Sub gvProveedores_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvProveedores.RowUpdating

        Dim id As Integer = Convert.ToInt32(gvProveedores.DataKeys(e.RowIndex).Value)
        proveedor.id = e.NewValues("id")
        proveedor.empresa = e.NewValues("empresa")
        proveedor.telefono = e.NewValues("telefono")
        proveedor.direccion = e.NewValues("direccion")
        proveedor.id = id

        dbHelper.updating(proveedor)
        gvProveedores.DataBind()
        e.Cancel = True
        gvProveedores.EditIndex = -1
    End Sub

    Protected Sub gvProveedores_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvProveedores.DataKeys(e.RowIndex).Value)
            dbHelper.delete(id)
            e.Cancel = True
            gvProveedores.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar el proveedor: " & ex.Message
        End Try
    End Sub
End Class