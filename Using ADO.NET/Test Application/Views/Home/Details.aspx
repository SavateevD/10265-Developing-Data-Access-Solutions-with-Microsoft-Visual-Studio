<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DAL.ProductDataObject>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Product Details </legend>
        <p>
            ProductID:
            <%= Html.Encode(Model.ProductID) %>
        </p>
        <p>
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            ProductNumber:
            <%= Html.Encode(Model.ProductNumber) %>
        </p>
               <p>
            Color:
            <%= Html.Encode(Model.Color) %>
        </p>
        
        <p>
            ListPrice:
            <%= Html.Encode(String.Format("{0:F}", Model.ListPrice)) %>
        </p>
      
        <p>
            ModifiedDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ModifiedDate)) %>
        </p>
    </fieldset>
    <p>
     
        <%=Html.ActionLink("Back to List", "Products") %>
    </p>

</asp:Content>

