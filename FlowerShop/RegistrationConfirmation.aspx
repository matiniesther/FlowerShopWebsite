<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrationConfirmation.aspx.cs" Inherits="FlowerShop.RegistrationConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2>
                Our Current Customers
            </h2>
        </div>
        <div class="panel-body center-block">
            <asp:panel ID= "pnlCustomers" runat="server"></asp:panel>
        </div>
       </div>
    

</asp:Content>
