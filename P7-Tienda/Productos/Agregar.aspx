<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="P7_Tienda.Productos.Agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h5 class="card-header">Productos</h5>
        <div class="card-body">
            <h5 class="card-title">Registro de productos</h5>
            <form action="#" method="post" runat="server">
                <asp:Label Text="SKU:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtSKU" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <br />
                <asp:Label Text="Nombre:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label Text="Descripcion:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control"></asp:TextBox>                
                <br />
                <asp:Label Text="Precio:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtprecio" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <br />
                <asp:Label Text="Categoría:" runat="server"></asp:Label>
                <asp:DropDownList ID="ddCategorias" CssClass="form-control" runat="server"></asp:DropDownList>
                <br />
                <asp:Button runat="server" ID="btnEnviar" Text="Registrar producto" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
            </form>
        </div>
    </div>
</asp:Content>
