<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<DataObjects.Entities.Customer>>" %>
<%@ Import Namespace="DataObjects.Entities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Customers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customers</h2>
    <% foreach (Customer customer in Model) { %>
        
        <%: customer.LastName + ", " + customer.FirstName %>

    <%}  %>
    
</asp:Content>
