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
        List<CartProduct> cartCol;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            List<CartProduct> cartCol = (List<CartProduct>)Session["Cart"];

            if (cartCol != null && cartCol.Count == 0)
            {
                Session["Cart"] = null;
                myDataListCart.DataSource = null;
                myDataListCart.DataBind();
            }

            if (Session["Cart"] != null)
            {            

                DataTable dt = new DataTable("Cart");

                dt.Columns.Add("Image");
                dt.Columns.Add("Name");
                dt.Columns.Add("Count");
                dt.Columns.Add("Price");

                foreach (CartProduct p in cartCol)
                {
                    dt.Rows.Add(p.Image, p.Name, p.Count, p.Price);
                }
                myDataListCart.DataSource = dt;
                myDataListCart.DataBind();   
                             

                Layout master = Page.Master as Layout;
                master.SetBadge(cartCol.Count.ToString());
            }
            else
            {
                labelInfo.Visible = true;
            }
        }

        protected void myDataListCart_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            if(Session["Cart"] != null){
                cartCol = (List<CartProduct>)Session["Cart"];
                string name = ((Label)e.Item.FindControl("productName")).Text;
                CartProduct p = cartCol.Where(x => x.Name == name).SingleOrDefault();
                if (p != null)
                {
                    cartCol.Remove(p);                    
                }                
                BindData();                                         
            }
        }
    }
}