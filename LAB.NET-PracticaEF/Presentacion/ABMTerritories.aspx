<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMTerritories.aspx.cs" Inherits="Presentacion.ABMTerritories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AMB Simple Entity Framework</title>

    <link rel="stylesheet" href="/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12">
            <div class="form-group col-lg-6">
                <label for="txtTerritoryId">ID</label>
                <asp:TextBox ID="txtTerritoryId" runat="server" class="form-control" />
                <label for="txtDescription">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" class="form-control" />
            </div>
            <div class="dropdown-menu-right">
                <label for="listRegion">Region</label>
                <asp:DropDownList ID="listRegion" runat="server" EventChanged="listRegion_EventChanged">
                </asp:DropDownList>
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" class="btn btn-default" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" class="btn btn-info" />
                <asp:Button ID="btnAttach" runat="server" Text="Modificar-Attach" OnClick="btnAttach_Click" class="btn btn-btninfo" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-danger" />
            </div>
            <asp:GridView ID="Grid1" runat="server" OnSelectedIndexChanged="Grid1_SelectedIndexChanged" class="table table-striped">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="button" ControlStyle-CssClass="btn btn-success"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
