<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="P7_Tienda.Categorias.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h5 class="card-header">Categorías</h5>
        <div class="card-body">
            <h5 class="card-title">Listado de categorías</h5>
            <asp:DataGrid runat="server" ID="dgCategorias"></asp:DataGrid>
        </div>
    </div>
</asp:Content>
