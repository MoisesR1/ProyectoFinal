Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Public Class dbProductos
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Public Function Create(producto As Productos) As String
        Try
            Dim sql As String = "INSERT INTO Productos (Descripcion, Precio, Cantidad) VALUES (@Descripcion, @Precio, @Cantidad)"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion)
                    command.Parameters.AddWithValue("@Precio", producto.Precio)
                    command.Parameters.AddWithValue("@Cantidad", producto.Cantidad)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Producto agregado exitosamente"
        Catch ex As Exception
            Return "Error al agregar producto: " & ex.Message
        End Try
    End Function

    Public Function Delete(id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Productos WHERE IDproducto = @Id"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@Id", id)
                    connection.Open()
                    Dim rows = command.ExecuteNonQuery()
                    If rows = 0 Then Return "El producto no existe"
                End Using
            End Using
            Return "Producto eliminado exitosamente"
        Catch ex As Exception
            Return "Error al eliminar producto: " & ex.Message
        End Try
    End Function

    Public Function Update(producto As Productos) As String
        Try
            Dim sql As String = "UPDATE Productos SET Descripcion=@Descripcion, Precio=@Precio, Cantidad=@Cantidad WHERE IDproducto=@Id"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@Id", producto.Id)
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion)
                    command.Parameters.AddWithValue("@Precio", producto.Precio)
                    command.Parameters.AddWithValue("@Cantidad", producto.Cantidad)
                    connection.Open()
                    Dim rows = command.ExecuteNonQuery()
                    If rows = 0 Then Return "El producto no existe"
                End Using
            End Using
            Return "Producto actualizado"
        Catch ex As Exception
            Return "Error al actualizar producto: " & ex.Message
        End Try
    End Function
    Public Function ObtenerProductos() As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "SELECT IDproducto, Descripcion FROM Productos"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using

        Return dt
    End Function
End Class

