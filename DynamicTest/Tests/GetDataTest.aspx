<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="GetDataTest.aspx.cs" Inherits="DynamicTest.Tests.GetDataTest" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:PlaceHolder runat="server" ID="dynamicPlaceHolder"></asp:PlaceHolder>
    <asp:Button runat="server" ID="saveButton" OnClick="saveButton_OnClick"/>
</asp:Content>
