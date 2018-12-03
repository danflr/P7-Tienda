<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="P7_Tienda.Proveedores.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h5 class="card-header">Productos</h5>
        <div class="card-body">
            <h5 class="card-title">Listado de proveedores</h5>
            <asp:DataGrid runat="server" ID="dgProveedores"></asp:DataGrid>
        </div>
    </div>
</asp:Content>
