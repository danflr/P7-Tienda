<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumen.aspx.cs" Inherits="P7_Tienda.Ventas.Resumen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            Resumen de venta
        </div>
        <div class="card-body">
            <h5 class="card-title">Venta realizada correctamente</h5>
            <p class="card-text">A continuación encontrará el resumen de la venta:</p>
            <form action="#" method="post" runat="server"> 
            <asp:Label Text="Fecha:" CssClass="card-text" runat="server"></asp:Label><asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
            <asp:Label Text="Cliente:" CssClass="card-text" runat="server"></asp:Label><asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
            <asp:Label Text="Productos:" CssClass="card-text" runat="server"></asp:Label><asp:TextBox ID="txtProductos" runat="server"></asp:TextBox>
            <asp:Label Text="Total:" CssClass="card-text" runat="server"></asp:Label><asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
            <asp:DataGrid ID="dgDetalle" runat="server"></asp:DataGrid>
            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-success" />
            </form>
        </div>
    </div>
</asp:Content>
