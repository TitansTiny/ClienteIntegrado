<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="VistaCliente.Form1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Productos</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 80%;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            color: #333;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .form-group input[type="text"] {
            width: calc(100% - 22px);
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
        }
        .form-group input[type="text"]:focus {
            border-color: #007bff;
        }
        .form-buttons {
            text-align: center;
        }
        .form-buttons input[type="button"], .form-buttons button {
            padding: 10px 20px;
            margin: 5px;
            border: none;
            border-radius: 5px;
            background-color: #007bff;
            color: #fff;
            font-size: 14px;
            cursor: pointer;
        }
        .form-buttons input[type="button"]:hover, .form-buttons button:hover {
            background-color: #0056b3;
        }
        .result {
            margin-top: 20px;
            text-align: center;
            font-weight: bold;
        }
        .gridview {
            margin-top: 20px;
        }
        .gridview table {
            width: 100%;
            border-collapse: collapse;
        }
        .gridview th, .gridview td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: center;
        }
        .gridview th {
            background-color: #f4f4f4;
        }
        .gridview img {
            max-height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestión de Productos</h1>
            <div class="form-group">
                <label for="txtId">ID:</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDescripcion">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtImagen">Imagen:</label>
                <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTienda">Tienda:</label>
                <asp:TextBox ID="txtTienda" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-buttons">
                <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </div>
            <div class="result">
                <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <label for="txtNombreBuscar">Buscar por Nombre:</label>
                <asp:TextBox ID="txtNombreBuscar" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>
            <div class="gridview">
                <asp:GridView ID="dgvProductos" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvProductos_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Nombre" />
                        <asp:BoundField DataField="Desc" HeaderText="Descripción" />
                        <asp:BoundField DataField="Tienda" HeaderText="Tienda" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <img src='<%# Eval("Imagen") %>' alt="Imagen del producto" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' Text="Editar" />
                                <asp:Button ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' Text="Eliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>