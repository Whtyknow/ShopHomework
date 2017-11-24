<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="ShopHomework.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:DataList ID="myDataListCart" runat="server"
        RepeatLayout="Table"               
        >
        
        <HeaderTemplate>
            <asp:Label runat="server" Text="Cart"></asp:Label>            
        </HeaderTemplate>

        <ItemTemplate>
            <div id="itemDiv">
                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                <br />

                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")+"usd" %>'></asp:Label>
                <br />                      
            </div>
        </ItemTemplate>

    </asp:DataList>   
</asp:Content>
