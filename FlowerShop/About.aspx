<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FlowerShop.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
      .bg-1 { 
           background-color: #1abc9c; /* Green */
            color: #ffffff;
        }
      .bg-2 { 
          background-color: black; 
          color: #ffffff;
      }
     .container-fluid-for {
        padding-top: 70px;
        padding-bottom: 70px;
      }
      body, html{
          font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
       }
    
  </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid bg-1 text-center">
  <h3>Who Are We?</h3>
    <img src="Images/flowershop.jpeg" class="img-circle" style="height:400px;width:400px;"/>
  <h3>Let let it grow Florist be your first choice for flowers</h3>
        </div>
<div class="container-fluid bg-2 text-center container-fluid-for">
  <h3>What Do We Do?</h3>
  <p >Park Avenue Florist and Gift Shop has been proudly serving Orange Park and Jacksonville since 1980. We are family owned and operated with one location serving the Orange Park area. We are committed to offering only the finest floral arrangements and gifts, backed by service that is friendly and prompt. Because all of our customers are important, our professional staff is dedicated to making your experience a pleasant one. That is why we always go the extra mile to make your floral gift perfect.</p>
</div>
</asp:Content>
