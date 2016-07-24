using SQLHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommercePlatform
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string category = Request["category"];

            if (category != null && category.Length > 0)
            {
                Dictionary<string, List<string>> products = SQL.LoadProducts(category);

                if (products != null)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var item in products.Keys)
                    {
                        sb.Append("<tr>");
                        sb.Append($"<td>{item}</td>");
                        sb.Append($"<td>{products[item][0]}</td>");
                        sb.Append($"<td>{products[item][1]}</td>");
                        sb.Append($"<td>&nbsp;</td>");
                        sb.Append("</tr>");
                    }

                    productsLit.Text = sb.ToString();
                }
            }
        }
    }
}