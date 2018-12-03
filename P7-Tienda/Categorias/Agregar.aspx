<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="P7_Tienda.Categorias.Agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h5 class="card-header">Productos</h5>
        <div class="card-body">
            <h5 class="card-title">Registro de productos</h5>
            <form action="#" method="post" runat="server"> 
                <div class="form-row">
                    <div class="form-group col-md-3">
                        <asp:Label Text="ID:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-9">
                        <asp:Label Text="Nombre:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" />
            </form>
        </div>
    </div>
</asp:Content>
