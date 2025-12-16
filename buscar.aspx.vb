Imports System.Data.SqlClient
Imports ProyectoFinal.Utils
Imports System.Data

Imports System.Configuration

Public Class buscar
    Inherits System.Web.UI.Page

    Private gbResultado As Object
    Public Property Txt_Buscar As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub Btn_Buscar_Click(sender As Object, e As EventArgs)
            gvResultado.DataBind()
        End Sub

    End Class
