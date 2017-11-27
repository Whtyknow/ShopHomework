using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using ShopHomework.Properties;

namespace ShopHomework
{
    public class ShopDbContext : DbContext
    {
        static ShopDbContext()
        {
            Database.SetInitializer<ShopDbContext>(new MyInitializer());
        }

        public ShopDbContext() : base("ShopBase")
        {

        }

        public DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public byte[] Image { get; set; }
    }

    public class MyInitializer : CreateDatabaseIfNotExists<ShopDbContext>
    {
        protected override void Seed(ShopDbContext db)
        {
            string path = Directory.GetCurrentDirectory();           

            Product p1 = new Product { Name = "Samsung pm-400", Price = 400, Image = MyImage.GetByteImage(Resources.Iphone) };
            Product p2 = new Product { Name = "Iphone iph1", Price = 500, Image = MyImage.GetByteImage(Resources.Motorolla) };
            Product p3 = new Product { Name = "Motorolla vs-40", Price = 800, Image = MyImage.GetByteImage(Resources.samsung) };
            Product p4 = new Product { Name = "Samsung pm-100", Price = 200, Image = MyImage.GetByteImage(Resources.samsung2) };
            Product p5 = new Product { Name = "Huawei H1", Price = 800, Image = MyImage.GetByteImage(Resources.huawei) };


            db.Products.AddRange(new Product[] { p1, p2, p3, p4, p5 });
            db.SaveChanges();
        }
    }

    static class MyImage {

        static public byte[] GetByteImage(Image img)
        {            
            byte[] arr = null;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }
    }
}