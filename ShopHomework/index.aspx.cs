using ShopHomework.Cart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopHomework
{
    public partial class index : System.Web.UI.Page
    {
        List<CartProduct> cart;

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
            cart = (List<CartProduct>)Session["Cart"];
            
            if (cart == null)
            {
                cart = new List<CartProduct>();
                Session["Cart"] = cart;
            }

            string name = ((Label)myDataList.SelectedItem.FindControl("LabelName")).Text;
            CartProduct p = cart.Where(x => x.Name == name).SingleOrDefault();
            HiddenField hiddenFieldPrice = ((HiddenField)(myDataList.SelectedItem.FindControl("hiddenFieldPrice")));

            if (p == null)
            {
                int price = Convert.ToInt32(((Label)myDataList.SelectedItem.FindControl("LabelPrice")).Text);
                string image = ((Image)(myDataList.SelectedItem.FindControl("productImage"))).ImageUrl;
                p = new CartProduct() { Name = name, Price = price, Image = image, Count = 1 };
                hiddenFieldPrice.Value = p.Price.ToString();
                cart.Add(p);
                                
                Layout master = Page.Master as Layout;
                master.SetBadge(cart.Count.ToString());
            }
            else
            {
                p.Count++;
                p.Price += Convert.ToInt32(hiddenFieldPrice.Value);
            }              
        }
    }
}