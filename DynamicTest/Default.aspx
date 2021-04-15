<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DynamicTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><a href="Tests/SimpleFormWithoutData.aspx">Simple form without data</a></h2>
    <h2><a href="Tests/SimpleFormWithData.aspx">Simple form with data</a></h2>
    <h2><a href="Tests/FluentGenerator.aspx">Fluent form generator</a></h2>
    <h2><a href="Tests/ValidationsForm.aspx">Validation form</a></h2>
    <h2><a href="Tests/GetDataTest.aspx">Get data</a></h2>
    <h2><a href="Tests/NonGenericTest.aspx">Non generic</a></h2>
</asp:Content>
