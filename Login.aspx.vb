Imports ProyectoFinal.Utils

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs)
        Dim nombreUsuario = txtUsuario.Text
        Dim password = txtPassword.Text

        Dim encrypter As New Simple3Des("MiClaveSecreta123")
        Dim pass As String = encrypter.EncryptData(password)

        Dim dbHelper As New dbLogin()
        Dim isValid As Boolean = dbHelper.ValidateLogin(nombreUsuario, pass)

        If isValid Then
            Dim User As Usuario = dbHelper.GetUser(nombreUsuario)
            Session("Usuario") = User
            Session("NombreUsuario") = User.NombreUsuario
            Session("Rol") = User.Rol

            If User.Rol = "2" Then
                Response.Redirect("FormProductos.aspx")
                Return
            End If

            Response.Redirect("Home.aspx")
        Else
            SwalUtils.ShowSwalError(Me, "Error de inicio de sesión", "Credenciales incorrectas.")
        End If
    End Sub
End Class
