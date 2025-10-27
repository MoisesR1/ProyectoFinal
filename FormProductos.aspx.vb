Public Class FormProductos
    Inherits System.Web.UI.Page
    Public productos As New Productos()
    Protected dbHelper As New DataBaseHelper()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Btn_Agregar_Click(sender As Object, e As EventArgs)
        productos.Id = Convert.ToInt32(Txt_idproducto.Text)
        productos.Descripcion = Txt_descripcion.Text
        productos.Precio = Convert.ToDecimal(Txt_precio.Text)
        productos.Cantidad = Convert.ToInt32(Txt_cantidad.Text)
        lblMensaje.Text = dbHelper.create(productos)
        gvProductos.DataBind()

    End Sub

    Protected Sub gvProductos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim IDproducto As Integer = Convert.ToInt32(gvProductos.DataKeys(e.RowIndex).Value)
            dbHelper.delete(IDproducto)
            e.Cancel = True
            gvProductos.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar el producto: " & ex.Message
        End Try
    End Sub

    Protected Sub gvProductos_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub gvProductos_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvProductos.EditIndex = -1
        gvProductos.DataBind()

    End Sub

    Protected Sub gvProductos_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Dim IDproducto As Integer = Convert.ToInt32(gvProductos.DataKeys(e.RowIndex).Value)
        Dim producto As Productos = New Productos With {
            .Descripcion = e.NewValues("Descripcion"),
            .Precio = e.NewValues("Precio"),
            .Cantidad = e.NewValues("Cantidad"),
            .Id = IDproducto
         }
        dbHelper.delete(IDproducto)
        gvProductos.DataBind()
        e.Cancel = True
        gvProductos.EditIndex = -1
    End Sub

    Protected Sub gvProductos_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim IDproducto As Integer = Convert.ToInt32(gvProductos.DataKeys(e.Equals(IDproducto)))
        Dim producto As Productos = New Productos()

    End Sub


End Class