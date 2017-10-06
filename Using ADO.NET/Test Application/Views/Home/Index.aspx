<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        <%=Html.ActionLink("Browse all Products","Products") %>
    </p>
    <%using (Html.BeginForm("BrowseColor","Home"))
      { %>
    <p>
    Browse Products by Color: <%=Html.TextBox("Color")%> </p>
     <input type="submit" value="Browse" />
 <%} %>
 <%using (Html.BeginForm("BrowsePrice","Home"))
      { %>
    <p>Browse Products by Maximum Price: <%=Html.TextBox("Price")%> </p>
 <input type="submit" value="Browse" />
 <%} %>
 <br />
 <%=Html.ValidationSummary() %>
</asp:Content>
