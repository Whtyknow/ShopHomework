using ShopHomework.Cart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopHomework
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<CartProduct> cart;
                if (Session["Cart"] != null)
                {
                    cart = (List<CartProduct>)Session["Cart"];

                    DataTable dt = new DataTable("Cart");

                    dt.Columns.Add("Image");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Count");
                    dt.Columns.Add("Price");

                    foreach (CartProduct p in cart)
                    {
                        dt.Rows.Add(p.Image, p.Name, p.Count, p.Price);
                    }
                    myDataListCart.DataSource = dt;
                    myDataListCart.DataBind();
                }
            }
        }
    }
}