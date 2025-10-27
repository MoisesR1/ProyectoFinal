Imports System.Data.SqlClient

Public Class dbProveedores
    Private ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Friend Sub delete(id As Integer)
        Throw New NotImplementedException()
    End Sub

    Public Function Create(proveedor As Proveedor) As String
        Try
            Dim sql As String = "INSERT INTO Proveedor (id, empresa, telefono, direccion) VALUES (@id, @empresa, @telefono, @direccion)"
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
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return "Proveedor Agregado correctamente"
    End Function
End Class
