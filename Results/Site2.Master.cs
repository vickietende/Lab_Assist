using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_Assist.Results
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login.aspx", true);
                }
                else
                {
                    string username = Session["Username"].ToString();
                    string role = Session["userRoleID"].ToString();
                    string userid = Session["UserId"].ToString();
                    string BranchName = Session["BranchName"].ToString();
                    string BranchCode = Session["BranchCode"].ToString();
                    lblUserName.Text = Session["Username"].ToString();

                }

            }

        }

        protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            string currentPage = Request.Url.Segments[Request.Url.Segments.Length - 1].Split('.')[0];
            if (e.Item.Text.Equals(currentPage, StringComparison.InvariantCultureIgnoreCase))
            {
                if (e.Item.Parent != null)
                {
                    e.Item.Parent.Selected = true;
                }
                else
                {
                    e.Item.Selected = true;
                }
            }
        }
    }
}