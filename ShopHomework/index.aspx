<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ShopHomework.index" %>
<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:DataList ID="myDataList" runat="server"
        RepeatLayout="Table"
        RepeatColumns="3">
        
        <HeaderTemplate>
            <asp:Label runat="server" Text="My Shop"></asp:Label>
        </HeaderTemplate>

        <ItemTemplate>
            <div id="itemDiv">
                <asp:Image id="productImage" runat="server" h />
            </div>
        </ItemTemplate>

    </asp:DataList>   

</asp:Content>

