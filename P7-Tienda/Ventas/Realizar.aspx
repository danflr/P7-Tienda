<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Realizar.aspx.cs" Inherits="P7_Tienda.Ventas.Realizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h5 class="card-header">Ventas</h5>
        <div class="card-body">
            <h5 class="card-title">Realizar venta</h5>
            <form action="#" method="post" runat="server"> 
                <div class="form-row">
                    <div class="form-group col-md-9">
                        <asp:Label Text="Cliente:" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddClientes" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddClientes_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Label Text="Fecha:" runat="server"></asp:Label>
                        <%: DateTime.Now %>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label Text="Producto:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" TextMode="Number" OnTextChanged="txtProducto_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Label Text="Cantidad:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtCant" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar producto" OnClick="btnAgregar_Click" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <asp:DataGrid ID="dgDetalle" runat="server"></asp:DataGrid>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <asp:Button ID="btnFinish" Text="Finalizar venta" CssClass="btn btn-success btn-raised" runat="server" OnClick="btnFinish_Click"/>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
