<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="ShopHomework.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:DataList ID="myDataListCart" runat="server" RepeatLayout="Flow"
        >
        
        <HeaderTemplate>
            <asp:Label runat="server" Text="Cart"></asp:Label>           
            <table class="table table-responsive">
                <thead>
                    <th>
                        <tr>
                            <th>Product</th>
                            <th>Count</th>
                            <th>Price</th>
                        </tr>
                    </th>
                </thead>
                <tbody>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                <asp:Image Width="40" Height="40" ID="productImage" runat="server"
                   ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image")%>'/>
                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>                
                </td>
                <td>
                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Count") %>'></asp:Label> 
                </td>
                <td>
                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")+"usd" %>'></asp:Label> 
                </td>  
            </tr>            
        </ItemTemplate>

        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>

    </asp:DataList>   
</asp:Content>
