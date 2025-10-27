Public Class FormProveedores
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbProveedores()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Btn_Agregar_Click(sender As Object, e As EventArgs)
        Dim proveedores As New Proveedor()
        proveedores.id = Convert.ToInt32(Txt_idproveedor.Text)
        proveedores.empresa = Txt_empresa.Text
        proveedores.telefono = Txt_telefono.Text
        proveedores.direccion = Txt_direccion.Text
        lblMensaje.Text = dbHelper.Create(proveedores)
    End Sub
End Class