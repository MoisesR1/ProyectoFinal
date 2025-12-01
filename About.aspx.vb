Public Class About
    Inherits Page
    Public productos As New Productos()
    Public proveedor As New Proveedor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Btn_ingresar_Click(sender As Object, e As EventArgs)
        productos.Id = Convert.ToInt32(Txt_idproducto.Text)
        productos.Descripcion = Txt_descripcion.Text
        productos.Precio = Convert.ToDecimal(Txt_precio.Text)
        productos.Cantidad = Convert.ToInt32(Txt_cantidad.Text)
        lbl_mensaje.Text = "Producto ingresado: " & productos.Descripcion & " con ID: " & productos.Id.ToString()
        proveedor.id = Convert.ToInt32(Txt_idproveedor.Text)
        proveedor.telefono = Convert.ToInt32(Txt_telefono.Text)
        proveedor.direccion = (Txt_direccion.Text)
        lbl_mensaje.Text = "Proveedor ingresado: " & productos.Descripcion & " con ID: " & productos.Id.ToString()

    End Sub



End Class