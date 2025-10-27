Public Class FormProveedores
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbProveedores()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Btn_Agregar_Click(sender As Object, e As EventArgs, proveedor As Proveedor)

        proveedor.id = Txt_idproveedor.Text
        proveedor.empresa = Txt_empresa.Text
        proveedor.telefono = Txt_telefono.Text

        lblMensaje.Text = dbHelper.Create(proveedor)

    End Sub

    Protected Sub btn_Editar_Click(sender As Object, e As EventArgs)

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