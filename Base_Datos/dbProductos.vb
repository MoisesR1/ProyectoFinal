Imports System.Data.SqlClient

Public Class dbProductos
    Private ReadOnly dbHelper = New DbHelper()
    Private ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Public Function create(Productos As Productos) As String
        Try
            Dim sql As String = "INSERT INTO Productos (Descripcion, Precio, Cantidad) VALUES (@Descripcion, @Precio, @Cantidad)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Descripcion", Productos.Descripcion),
                New SqlParameter("@Precio", Productos.Precio),
                New SqlParameter("@Cantidad", Productos.Cantidad)
                }

            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Return "!Error al agregar Producto!" & ex.Message
        End Try
        Return "!Producto agregado exitosamente!"
    End Function

    Public Function delete(ByRef id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Productos WHERE IDproducto = @Id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id)
                }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Return "Error al eliminar el producto: " & ex.Message
        End Try
        Return "Producto eliminado exitosamente"
    End Function

    Public Function update(Productos As Productos) As String
        Try
            Dim sql As String = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio, Cantidad = @Cantidad WHERE IDproducto = @Id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Id", Productos.Id),
                New SqlParameter("@Descripcion", Productos.Descripcion),
                New SqlParameter("@Precio", Productos.Precio),
                New SqlParameter("@Cantidad", Productos.Cantidad)
                }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Return "Error al actualizar producto" & ex.Message
        End Try
        Return "Producto Actualizado"

    End Function

End Class
