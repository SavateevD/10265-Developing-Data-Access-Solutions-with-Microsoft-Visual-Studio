<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DAL.ProductDataObject>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Products
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Products</h2>
    <table>
        <tr>
            <th></th>
            <th>
                ProductID
            </th>
            <th>
                Name
            </th>
            <th>
                ProductNumber
            </th>
          
            <th>
                Color
            </th>
            
            <th>
                ListPrice
            </th>
   
            <th>
                ModifiedDate
            </th>
        </tr>

    <% foreach (var item in Model)
       { %>
    
        <tr>
            <td>
                        <%= Html.ActionLink("Details", "Details", new {  id=item.ProductID  })%>
            </td>
            <td>
                <%= Html.Encode(item.ProductID) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.ProductNumber) %>
            </td>
           
            <td>
                <%= Html.Encode(item.Color) %>
            </td>
        
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.ListPrice)) %>
            </td>
       
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ModifiedDate)) %>
            </td>
        </tr>
    
    <% } %>

    </table>
  
</asp:Content>
