<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoProductos.aspx.cs" Inherits="P7_Tienda.Productos.ListadoProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h5 class="card-header">Productos</h5>
        <div class="card-body">
            <h5 class="card-title">Listado de productos</h5>
            <asp:DataGrid runat="server" ID="dgProductos"></asp:DataGrid>
        </div>
    </div>
</asp:Content>
