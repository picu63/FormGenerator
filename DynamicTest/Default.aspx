<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DynamicTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><a href="Tests/SimpleFormWithoutData.aspx">Prosty formularz bez danych</a></h2>
    <h2><a href="Tests/SimpleFormWithData.aspx">Prosty formularz z danymi</a></h2>
    <h2><a href="Tests/FluentGenerator.aspx">Fluent form generator</a></h2>
</asp:Content>
