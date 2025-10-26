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
    End Sub


End Class