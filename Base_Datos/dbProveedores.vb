Imports System.Data.SqlClient

Public Class dbProveedores
    Private ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString



    Public Function Create(proveedor As Proveedor) As String
        Try
            Dim sql As String = "INSERT INTO [proveedores] (empresa, telefono, direccion) VALUES (@empresa, @telefono, @_direccion)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@empresa", proveedor.empresa),
                New SqlParameter("@telefono", proveedor.telefono),
                New SqlParameter("@_direccion", proveedor.direccion)
                }

            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("" + ex.ToString())
        End Try
        Return "Proveedor Agregado correctamente"
    End Function

    Public Function delete(ByRef id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM proveedores WHERE id = @Id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@id", id)
                }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error al eliminar el proveedor: " & ex.Message)
        End Try
        Return "Proveedor Eliminado"
    End Function

    Public Function updating(proveedor As Proveedor) As String
        Try
            Dim sql As String = "UPDATE [proveedores] SET empresa = @empresa, telefono = @telefono, direccion = @direccion WHERE id = @id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@id", proveedor.id),
                New SqlParameter("@empresa", proveedor.empresa),
                New SqlParameter("@telefono", proveedor.telefono),
                New SqlParameter("@direccion", proveedor.direccion)
                }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    Dim filasAfectadas As Integer = command.ExecuteNonQuery()
                    If filasAfectadas > 0 Then
                        Return "Proveedor actualizado correctamente."
                    Else
                        Return "No se encontró el proveedor con ese ID."
                    End If

                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error al actualizar el proveedor: " & ex.Message)
            Return "Error al actualizar"
        End Try
        Return "Proveedor Actualizado correctamente"
    End Function
End Class
