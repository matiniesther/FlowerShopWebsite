<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FlowerShop.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        body, html {
            height: 100%;
        }
        body {
            
            background-image: url("Images/flowershop.jpeg");
            height: 100%;
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
       }
        
        .text {
            border: 10px solid white;
            border-radius: 2px;
            text-align: center;
            padding-bottom: 20px;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            color: white;
        }
        h1 {
            font-size: 48px;
            font-weight: 900;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        }
        p {
            font-size: 20px;
            font-weight:500;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
     
        <div class="text">
            <h1>Welcome to our Flower Shop!</h1>
            <p>Let us help you with your flower needs</p>
            <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" CssClass=" btn btn-success" />
        </div>
        
    
        
    
  </div>
     
</asp:Content>
