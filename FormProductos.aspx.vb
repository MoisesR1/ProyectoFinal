Imports ProyectoFinal
Imports ProyectoFinal.Utils

Public Class FormProductos
    Inherits System.Web.UI.Page

    Protected dbHelper As New dbProductos()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Usuario") Is Nothing OrElse Session("Rol") <> "2" Then
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            gvProductos.DataBind()
        End If
    End Sub

    Protected Sub Btn_Agregar_Click(sender As Object, e As EventArgs)
        Try
            ' Validación mínima
            Dim precioDec As Decimal
            Dim cantidadInt As Integer
            If String.IsNullOrWhiteSpace(Txt_descripcion.Text) OrElse
               Not Decimal.TryParse(Txt_precio.Text, precioDec) OrElse
               Not Integer.TryParse(Txt_cantidad.Text, cantidadInt) Then
                SwalUtils.ShowSwalError(Me, "Error", "Complete todos los campos correctamente")
                Exit Sub
            End If

            Dim nuevo As New Productos With {
                .Descripcion = Txt_descripcion.Text.Trim(),
                .Precio = precioDec,
                .Cantidad = cantidadInt
            }

            Dim mensaje = dbHelper.Create(nuevo)
            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error", mensaje)
            Else
                SwalUtils.ShowSwal(Me, mensaje)
            End If

            Txt_descripcion.Text = ""
            Txt_precio.Text = ""
            Txt_cantidad.Text = ""

            gvProductos.DataBind()

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al guardar el producto!", ex.Message)
        End Try
    End Sub

    Protected Sub gvProductos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvProductos.DataKeys(e.RowIndex).Value)
            ' Confirmación al eliminar se hace por OnClientClick en GridView
            Dim mensaje = dbHelper.Delete(id)
            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error", mensaje)
            Else
                SwalUtils.ShowSwal(Me, mensaje)
            End If
            gvProductos.DataBind()
            e.Cancel = True
        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al eliminar el producto!", ex.Message)
        End Try
    End Sub

    Protected Sub gvProductos_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvProductos.EditIndex = e.NewEditIndex
        gvProductos.DataBind()
    End Sub

    Protected Sub gvProductos_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvProductos.EditIndex = -1
        gvProductos.DataBind()
    End Sub

    Protected Sub gvProductos_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim IDproducto As Integer = Convert.ToInt32(gvProductos.DataKeys(e.RowIndex).Value)
            Dim producto As New Productos With {
                .Id = IDproducto,
                .Descripcion = e.NewValues("Descripcion"),
                .Precio = Convert.ToDecimal(e.NewValues("Precio")),
                .Cantidad = Convert.ToInt32(e.NewValues("Cantidad"))
            }

            Dim mensaje = dbHelper.Update(producto)
            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error", mensaje)
            Else
                SwalUtils.ShowSwal(Me, mensaje)
            End If

            gvProductos.EditIndex = -1
            gvProductos.DataBind()
            e.Cancel = True
        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al actualizar!", ex.Message)
        End Try
    End Sub

    Protected Sub gvProductos_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

End Class

