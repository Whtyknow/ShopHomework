<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="ShopHomework.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:Label runat="server" Font-Size="XX-Large" ID="labelInfo" Visible="false" Text="Your cart is empty"></asp:Label>
    <asp:DataList ID="myDataListCart" runat="server" RepeatLayout="Flow" OnDeleteCommand="myDataListCart_DeleteCommand"
        >
        
        <HeaderTemplate>                  
            <table class="table table-bordered">
                <thead>
                    <tr>                                                  
                            <th>Product</th>                            
                            <th>Count</th>
                            <th>Price</th>       
                            <th>Remove</th>                 
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                <asp:Image Width="40" Height="40" ID="productImage" runat="server"
                   ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image")%>'/>
                <asp:Label ID="productName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>                
                </td>
                <td>
                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Count") %>'></asp:Label> 
                </td>
                <td>
                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")+"usd" %>'></asp:Label> 
                </td>  
                <td>
                    <asp:LinkButton CommandName="Delete" runat="server" Text="Delete"></asp:LinkButton>
                </td>
            </tr>            
        </ItemTemplate>

        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>

    </asp:DataList>   
</asp:Content>
