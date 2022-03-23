using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab_Assist
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string md5Pwd = Basic.EncodePassword(txtpwd.Value);
                //string md5Pwd = "";
                string username = txtUserName.Value;
                string userid = "";
                string userrole = "";
                string BranchName = "";
                string BranchCode = "";
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select UserID,user_Username,user_userpwd,user_userRoleID,tb.BranchName,* from tbl_Lab_Assist_Users tu left join tbl_Branches tb ON tu.user_BranchCode=tb.BranchCode where user_Username='" + username + "' and user_userpwd='" + md5Pwd + "' and [user_Activate]=1", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            userid = dt.Rows[0]["UserID"].ToString();
                            userrole = dt.Rows[0]["user_userRoleID"].ToString();
                            BranchName = dt.Rows[0]["BranchName"].ToString();
                            BranchCode = dt.Rows[0]["BranchCode"].ToString();
                            Session["UserId"] = userid;
                            Session["UserRoleID"] = userrole;
                            Session["Username"] = username;
                            Session["BranchName"] = BranchName;
                            Session["BranchCode"] = BranchCode;

                            Response.Redirect("Home.aspx", true);

                        }
                        else
                        {
                            InvalidCredentials.Visible = true;
                        }




                    }
                }


            }
            catch (Exception ex)
            {
                InvalidCredentials.Visible = true;
                InvalidCredentials.Text = ex.Message;
            }

        }
    }
}