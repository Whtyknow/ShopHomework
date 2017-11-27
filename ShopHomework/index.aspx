<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ShopHomework.index" %>
<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <asp:DataList ID="myDataList" runat="server"
        RepeatLayout="Table"
        RepeatColumns="3" OnSelectedIndexChanged="myDataList_SelectedIndexChanged"        
        >       
        

        <ItemTemplate>
            <div id="itemDiv">

                <asp:Label Font-Size="Large" 
                    Font-Italic="true" 
                    ID="LabelName" 
                    runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                <br />

                <asp:Label Font-Bold="true" ID="LabelPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                <span>usd</span>
                <br />

                <asp:Image Width="200" Height="200" ID="productImage" runat="server"
                   ImageUrl='<%# GetImage(Eval("Image")) %>'/>
                <br />

                <asp:Button CssClass="btn btn-success" ID="buttonAddToCart" runat="server" Text="AddToCart" CommandName="Select"/>
                <br />                             

                <asp:HiddenField runat="server" ID="hiddenFieldPrice" />
            </div>
        </ItemTemplate>

    </asp:DataList>   

</asp:Content>

