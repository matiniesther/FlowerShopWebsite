<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="FlowerShop.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* makes sure all rows are the same height*/
        .row{
               overflow: hidden; 
          }

       [class*="col-"]{
             margin-bottom: -99999px;
              padding-bottom: 99999px;
       }
      .row-1 { 
           background-color: #1abc9c; /* Green */
            color: #ffffff;
            
        }
      .row-2 { 
          background-color: black; 
          color: #ffffff;
      }
      .row-3 { 
           background-color: #1abc9c; /* Green */
            color: #ffffff;
        }
      body, html{
          font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
       }
    
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
      <div class="container-fluid bg-3 text-center"> 
          <h1>Where To Find Us?</h1>
          <div class="row">
            <div class="col-sm-4 row-1">
              <h1>Store Location</h1>
               <img src="Images/1001.jpeg" class="img-circle" style="height:200px;width:200px;"/>
              <p>Operating Hours:</p>
               <p> Monday-Saturday: 8:00am – 12:00am (EDT)</p>
               <p> Sunday: 9:00am – 12:00am (EDT)</p>
     
            </div>

            <div class="col-sm-4 row-2">
              <h1> Phone Numbers </h1>
              <img src="Images/2002.jpeg" class="img-circle" style="height:200px;width:200px;"/>
              <p>Phone: 345-777-5780</p>
              <p>Fax: 546-782-5640</p>
     
            </div>
      
            <div class="col-sm-4 row-3"> 
              <h1>Online</h1>
              <img src="Images/3003.jpeg" class="img-circle" style="height:200px;width:200px;"/>
              <p>Whether you’re looking for answers, would like to solve a problem, or just want to let us know how we did, you’ll find many ways to contact us right here. We’ll help you resolve your issues quickly and easily, getting you back to more important things, like relaxing on your new sofa. 
</p>
      
            </div>
          </div>
    </div>
</asp:Content>
