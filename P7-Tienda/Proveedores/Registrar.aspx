<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="P7_Tienda.Proveedores.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h5 class="card-header">Proveedores</h5>
        <div class="card-body">
            <h5 class="card-title">Registro de proveedor</h5>
            <form action="#" method="post" runat="server">
                <asp:Label Text="Nombre:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label Text="Correo:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtMail" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label Text="Domicilio:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtDomicilio" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label Text="Teléfono:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtTelefono" MaxLength="10" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Button runat="server" ID="btnEnviar" Text="Registrar proveedor" CssClass="btn btn-primary" OnClick="btnEnviar_Click"/>
            </form>
        </div>
    </div>
</asp:Content>
