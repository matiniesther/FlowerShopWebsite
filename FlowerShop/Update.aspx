﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="FlowerShop.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>This is the update place</h1>

    <div class="panel panel-font container-fluid">
        <div class="panel-heading text-center"><h2>New Customer Registration</h2></div>
        <div class="panel-body">
           <div class="form-group">
                                   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter a First Name" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <label>First Name:</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                     
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter a Last Name" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
                <label>Last Name:</label>
                	 <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter a Address" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
                <label>Address:</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" ErrorMessage="Please enter a City" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
                <label>City:</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                                  
               <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtState" ErrorMessage="Please enter a State" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
               <label>State:</label>
                    <asp:TextBox ID="txtState" runat="server" CssClass="form-control"></asp:TextBox>
                                   
               <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip" ErrorMessage="Please enter a Zipcode" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
               <label>Zipcode:</label>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="form-control"></asp:TextBox>

           </div>
           <div class="form-group text-center">
               <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click"/>
               <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-warning" onClick="btnCancel_Click" /></div>
           </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" ShowSummary="true" HeaderText="Please fix the following errors:" ForeColor="Red" />
        </div>
</asp:Content>