Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usuario As Usuario = Session("Usuario")
        LblUsuario.Text = "Bienvenido(a) " & usuario.NombreUsuario
        Lbl_Email.Text = "Correo electronico: " & usuario.Email
    End Sub

    Protected Sub BtnBuscar_Click(sender As Object, e As EventArgs)

        lblResultado.Text = ""  ' limpia mensaje

        Dim vista As DataView = CType(SqlDataSourceBuscar.Select(DataSourceSelectArguments.Empty), DataView)

        If vista.Count > 0 Then
            ' Producto encontrado
            Dim fila As DataRowView = vista(0)

            lblResultado.CssClass = "text-success fw-bold"
            lblResultado.Text = $"Producto: {fila("Descripcion")} • Precio: {fila("Precio")} • Cantidad: {fila("Cantidad")}"
        Else
            ' Producto NO existe
            lblResultado.CssClass = "text-danger fw-bold"
            lblResultado.Text = "⚠ El producto NO existe en la base de datos!⚠"
        End If

    End Sub

End Class