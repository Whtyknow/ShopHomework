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
                List<Product> cart;
                if (Session["Cart"] != null)
                {
                    cart = (List<Product>)Session["Cart"];

                    DataTable dt = new DataTable("Cart");

                    dt.Columns.Add("Name");
                    dt.Columns.Add("Price");

                    foreach(Product p in cart)
                    {
                        dt.Rows.Add(p.Name, p.Price);
                    }
                    myDataListCart.DataSource = dt;
                    myDataListCart.DataBind();
                }
            }
        }
    }
}