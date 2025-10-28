Public Class FormProveedores
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbProveedores()
    Public proveedor As New Proveedor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click
        proveedor.id = Convert.ToInt32(Txt_idproveedor.Text)
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
        proveedor.direccion = e.NewValues("direcion")
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