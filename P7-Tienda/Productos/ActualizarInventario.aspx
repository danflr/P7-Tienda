<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarInventario.aspx.cs" Inherits="P7_Tienda.Productos.ActualizarInventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h5 class="card-header">Productos</h5>
        <div class="card-body">
            <h5 class="card-title">Registro de productos</h5>
            <form action="#" method="post" runat="server"> 
                <div class="form-row">
                    <div class="form-group col-md-3">
                        <asp:Label Text="Producto:" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddProductos" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddProductos_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-9">
                        <asp:Label ID="lblProducto" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label Text="Disponibilidad:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtDisp" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label Text="Nueva disponibilidad:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtNueva" CssClass="form-control" runat="server" TextMode="Number">s</asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnActualizar" Text="Actualizar disponibilidad" runat="server" OnClick="btnActualizar_Click"/>
            </form>
        </div>
    </div>
</asp:Content>
