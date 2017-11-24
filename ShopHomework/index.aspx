<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ShopHomework.index" %>
<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <asp:DataList ID="myDataList" runat="server"
        RepeatLayout="Table"
        RepeatColumns="3" OnSelectedIndexChanged="myDataList_SelectedIndexChanged"        
        >
        
        <HeaderTemplate>
            <asp:Label runat="server" Text="My Shop"></asp:Label>            
        </HeaderTemplate>

        <ItemTemplate>
            <div id="itemDiv">

                <asp:Label ID="LabelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                <br />

                <asp:Label ID="LabelPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                <br />

                <asp:Image Width="200" Height="200" id="productImage" runat="server"
                   ImageUrl='<%# GetImage(Eval("Image")) %>'/>
                <br />

                <asp:Button ID="buttonAddToCart" runat="server" Text="AddToCart" CommandName="Select"/>
                <br />                             

            </div>
        </ItemTemplate>

    </asp:DataList>   

</asp:Content>

