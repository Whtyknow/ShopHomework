﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopHomework
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("cart.aspx"); 
        }

        protected void LinkButtonShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        public void SetBadge(int value)
        {
            labelBadge.Text = Convert.ToString(value);
        }
    }
}