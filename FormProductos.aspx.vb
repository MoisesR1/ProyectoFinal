Imports ProyectoFinal
Imports ProyectoFinal.Utils

Public Class FormProductos
    Inherits System.Web.UI.Page

    Protected dbHelper As New dbProductos()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gvProductos.DataBind()
        End If
    End Sub
    Protected Sub Btn_Agregar_Click(sender As Object, e As EventArgs)
        Try
            Dim nuevo As New Productos With {
                .Descripcion = Txt_descripcion.Text.Trim(),
                .Precio = Convert.ToDecimal(Txt_precio.Text),
                .Cantidad = Convert.ToInt32(Txt_cantidad.Text)
            }

            Dim mensaje = dbHelper.create(nuevo)

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
            Dim mensaje = dbHelper.delete(id)

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

            Dim mensaje = dbHelper.update(producto)

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
        Dim id As Integer = Convert.ToInt32(gvProductos.SelectedDataKey.Value)

    End Sub

End Class
