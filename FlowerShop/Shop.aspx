<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="FlowerShop.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2>
                Our Current Products
            </h2>
        </div>
        <div class="panel-body center-block">
          <asp:Panel ID="pnlProducts" runat="server"></asp:Panel>
        </div>
      </div>
</asp:Content>
