using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopHomework
{
    public partial class index : System.Web.UI.Page
    {
        List<Product> cart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (ShopDbContext db = new ShopDbContext())
                {
                    Product[] products = db.Products.ToArray();
                    DataTable dt = new DataTable("Products");

                    dt.Columns.Add("Name");
                    dt.Columns.Add("Price", typeof(int));
                    dt.Columns.Add("Image", typeof(byte[]));

                    foreach (Product p in products)
                    {
                        dt.Rows.Add(p.Name, p.Price, p.Image = p.Image);
                    }

                    myDataList.DataSource = dt;
                    myDataList.DataBind();
                }
            }
        }

        public string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
        
        protected void myDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cart = (List<Product>)Session["Cart"];
            
            if (cart == null)
            {
                cart = new List<Product>();
                Session["Cart"] = cart;
            }

           DataListItem item = myDataList.SelectedItem;
                Product p = new Product()
                {
                    Name = ((Label)myDataList.SelectedItem.FindControl("LabelName")).Text,
                    Price = Convert.ToInt32(((Label)myDataList.SelectedItem.FindControl("LabelPrice")).Text)
                };
                cart.Add(p);
                      
            
        }
    }
}