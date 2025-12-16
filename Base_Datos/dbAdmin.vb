Imports System.Data.SqlClient
Imports System.Configuration

Public Class dbAdmin
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Public Function ObtenerProductosConProveedores() As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "SELECT p.IDproducto, p.Descripcion, p.Precio, p.Cantidad, pr.empresa " &
                    "FROM Productos p " &
                    "INNER JOIN Proveedores pr ON p.Proveedor_id = pr.Id"

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

