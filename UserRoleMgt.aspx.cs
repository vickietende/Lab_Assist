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
    public partial class UserRoleMgt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadRoles();
                loadDepartments();
                loadBranches();
                loadOccupations();
                txtDateCreated.Text = DateTime.Today.ToString("dd/MM/yyyy");

            }
        

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtuserSurname.Text == "")
            {
                string script = "alert(\"Surname is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserfname.Text == "")
            {
                string script = "alert(\"First Name is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserIDNO.Text == "")
            {
                string script = "alert(\"IDNO is required\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_userDept.SelectedIndex == 0)
            {
                string script = "alert(\"User Department is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_userOccupation.SelectedIndex == 0)
            {
                string script = "alert(\"Occupation is required\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_userGender.SelectedIndex == 0)
            {
                string script = "alert(\"Gender is required\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtusername.Text == "")
            {
                string script = "alert(\"Username is required\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtpwd.Text == "")
            {
                string script = "alert(\"Password is required\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }

            if (txtuserEmail.Text == "")
            {
                string script = "alert(\"Email is required\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserPhone.Text == "")
            {
                string script = "alert(\"User's phone number is required\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_userRole.SelectedIndex == 0)
            {
                string script = "alert(\"Please specify user's Role\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_Branches.SelectedIndex == 0)
            {
                string script = "alert(\"User's Branch is required\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }


            string md5Pwd = Basic.EncodePassword(txtpwd.Text);
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SaveLabAssistUsers]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@user_Surname", txtuserSurname.Text);
                cmd.Parameters.AddWithValue("@user_Fname", txtuserfname.Text);
                cmd.Parameters.AddWithValue("@user_IDNO", txtuserIDNO.Text);
                cmd.Parameters.AddWithValue("@user_Dept", ddl_userDept.SelectedValue);
                cmd.Parameters.AddWithValue("@user_Occupation", ddl_userOccupation.SelectedValue);
                cmd.Parameters.AddWithValue("@user_Gender", ddl_userGender.SelectedValue);

                cmd.Parameters.AddWithValue("@user_Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@user_userpwd", md5Pwd);
                cmd.Parameters.AddWithValue("@user_useremail", txtuserEmail.Text);
                cmd.Parameters.AddWithValue("@user_userphone", txtuserPhone.Text);
                cmd.Parameters.AddWithValue("@user_userRoleID", ddl_userRole.SelectedValue);

                cmd.Parameters.AddWithValue("@user_CreatedBy", Session["Username"].ToString());
                cmd.Parameters.AddWithValue("@user_Activate", 1);
                cmd.Parameters.AddWithValue("@user_BranchCode", ddl_Branches.SelectedValue);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Saved successfully\");" ;
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAll();






            }
            catch (Exception)
            {

            }

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

            if (txtuserSurname.Text == "")
            {
                string script = "alert(\"Surname is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserfname.Text == "")
            {
                string script = "alert(\"First Name is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserIDNO.Text == "")
            {
                string script = "alert(\"IDNO is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_userDept.SelectedIndex == 0)
            {
                string script = "alert(\"User Department is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_userOccupation.SelectedIndex == 0)
            {
                string script = "alert(\"Occupation is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_userGender.SelectedIndex == 0)
            {
                string script = "alert(\"Gender is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtusername.Text == "")
            {
                string script = "alert(\"Username is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtpwd.Text == "")
            {
                string script = "alert(\"Password is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }

            if (txtuserEmail.Text == "")
            {
                string script = "alert(\"Email is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserPhone.Text == "")
            {
                string script = "alert(\"User's phone number is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_userRole.SelectedIndex == 0)
            {
                string script = "alert(\"Please specify user's Role\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_Branches.SelectedIndex == 0)
            {
                string script = "alert(\"User's Branch is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[EditLabAssistUsers]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@user_Surname", txtuserSurname.Text);
                cmd.Parameters.AddWithValue("@user_Fname", txtuserfname.Text);
                cmd.Parameters.AddWithValue("@user_IDNO", txtuserIDNO.Text);
                cmd.Parameters.AddWithValue("@user_Dept", ddl_userDept.SelectedValue);
                cmd.Parameters.AddWithValue("@user_Occupation", ddl_userOccupation.SelectedValue);
                cmd.Parameters.AddWithValue("@user_Gender", ddl_userGender.SelectedValue);
                cmd.Parameters.AddWithValue("@RoleID", ddl_userRole.SelectedValue);
                cmd.Parameters.AddWithValue("@BranchCode", ddl_Branches.SelectedValue);
                cmd.Parameters.AddWithValue("@user_useremail", txtuserEmail.Text);
                cmd.Parameters.AddWithValue("@user_userphone", txtuserPhone.Text);


                cmd.Parameters.AddWithValue("@user_CreatedBy", Session["Username"].ToString());
                cmd.Parameters.AddWithValue("@user_Activate", 1);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"User's Details successfully updated!!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAll();






            }
            catch (Exception)
            {

            }

        }

        private void loadRoles()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_UserRoles]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_AvailableRoles.DataSource = ds.Tables[0];
                            ddl_AvailableRoles.DataTextField = "Role";
                            ddl_AvailableRoles.DataValueField = "user_userRoleID";

                            ddl_userRole.DataSource = ds.Tables[0];
                            ddl_userRole.DataTextField = "Role";
                            ddl_userRole.DataValueField = "user_userRoleID";

                        }
                        else
                            ddl_AvailableRoles.DataSource = null;


                        ddl_AvailableRoles.DataBind();
                        ddl_userRole.DataBind();

                        ddl_AvailableRoles.Items.Insert(0, "--Select Role--");
                        ddl_userRole.Items.Insert(0, "--Select Role--");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadDepartments()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Department]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_AvailableDepts.DataSource = ds.Tables[0];
                            ddl_AvailableDepts.DataTextField = "Department";
                            ddl_AvailableDepts.DataValueField = "ID";

                            ddl_userDept.DataSource = ds.Tables[0];
                            ddl_userDept.DataTextField = "Department";
                            ddl_userDept.DataValueField = "ID";

                        }
                        else
                            ddl_AvailableDepts.DataSource = null;


                        ddl_AvailableDepts.DataBind();
                        ddl_userDept.DataBind();


                        ddl_AvailableDepts.Items.Insert(0, "-Select Department-");
                        ddl_userDept.Items.Insert(0, "-Select Department-");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadBranches()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Branches]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_Branches.DataSource = ds.Tables[0];
                            ddl_Branches.DataTextField = "BranchName";
                            ddl_Branches.DataValueField = "BranchCode";

                        }
                        else
                            ddl_Branches.DataSource = null;


                        ddl_Branches.DataBind();


                        ddl_Branches.Items.Insert(0, "--Select Branch--");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadOccupations()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Occupations]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_userOccupation.DataSource = ds.Tables[0];
                            ddl_userOccupation.DataTextField = "Occupation";
                            ddl_userOccupation.DataValueField = "ID";



                        }
                        else
                            ddl_userOccupation.DataSource = null;


                        ddl_userOccupation.DataBind();


                        ddl_userOccupation.Items.Insert(0, "--Select Occupation--");


                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void ClearAll()
        {
            txtuserSurname.Text = "";
            txtuserfname.Text = "";
            txtuserIDNO.Text = "";
            ddl_userDept.SelectedIndex = 0;
            ddl_userOccupation.SelectedIndex = 0;
            ddl_userGender.SelectedIndex = 0;
            txtusername.Text = "";
            txtpwd.Text = "";
            txtuserEmail.Text = "";
            txtuserPhone.Text = "";
            ddl_userRole.SelectedIndex = 0;
            ddl_Branches.SelectedIndex = 0;

        }

        protected void btnSearchSurname_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("select UserID, isnull(user_Surname,'')+' '+isnull(user_Fname,'')+' --- '+isnull(convert(varchar,UserID),'')+' --- '+isnull(user_IDNO,'') as display from[dbo].[tbl_Lab_Assist_Users]  where isnull(user_Surname,'')+'---'+isnull(user_Fname,'')+' --- '+isnull(convert(varchar,UserID),'')+' --- '+isnull(user_IDNO,'') like '%" + txtSearchSurname.Text + "%'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cust");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lstSurnames.Visible = true;
                            lstSurnames.DataSource = ds.Tables[0];
                            lstSurnames.DataTextField = "display";
                            lstSurnames.DataValueField = "UserID";
                        }
                        else
                        {
                            lstSurnames.DataSource = null;
                            string script = "alert(\"The searched name was not found!\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }

                        lstSurnames.DataBind();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void lstSurnames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
            getUserDetails(lstSurnames.SelectedValue);

        }
        protected void getUserDetails(string ID)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select  UserID, user_Surname, user_Fname, user_Gender, user_IDNO, user_Dept,user_Occupation,user_Username,user_userpwd,user_useremail,user_userphone,user_userRoleID,user_DateCreated,user_BranchCode from [dbo].[tbl_Lab_Assist_Users] where UserID='" + ID + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtUserID.Text = dt.Rows[0]["UserID"].ToString();
                            txtuserSurname.Text = dt.Rows[0]["user_Surname"].ToString();
                            txtuserfname.Text = dt.Rows[0]["user_Fname"].ToString();
                            txtuserIDNO.Text = dt.Rows[0]["user_IDNO"].ToString();
                            ddl_userDept.SelectedValue = dt.Rows[0]["user_Dept"].ToString();
                            ddl_userOccupation.SelectedValue = dt.Rows[0]["user_Occupation"].ToString();
                            ddl_userGender.SelectedValue = dt.Rows[0]["user_Gender"].ToString();
                            txtusername.Text = dt.Rows[0]["user_Username"].ToString();
                            txtpwd.Text = "";
                            txtuserEmail.Text = dt.Rows[0]["user_useremail"].ToString();
                            txtuserPhone.Text = dt.Rows[0]["user_userphone"].ToString();
                            ddl_userRole.SelectedValue = dt.Rows[0]["user_userRoleID"].ToString();
                            ddl_Branches.SelectedValue = dt.Rows[0]["user_BranchCode"].ToString();


                        }
                        else
                        {
                            string script = "alert(\"User record not found!\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }
                    }
                }
            }
            catch (Exception)
            {
               
            }


        }

        protected void btnLock_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update tbl_Lab_Assist_Users set user_Activate=0 where UserID='" + txtUserID.Text + "'", con);


                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"User successfully locked!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAll();


            }
            catch (Exception)
            {

            }
        }

        protected void btnUnlockUser_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update tbl_Lab_Assist_Users set user_Activate=1 where UserID='" + txtUserID.Text + "'", con);


                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"User is successfully unlocked!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAll();

            }
            catch (Exception)
            {

            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveRoles]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Role", txtNewRole.Text);


                cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Role details successfully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                txtNewRole.Text = "";
                loadRoles();

            }
            catch (Exception)
            {

            }
        }
        private void ClearAllOnRoles()
        {
            txtNewRole.Text = "";
            txtRoleID.Text = "";
            txtSearchUsers.Text = "";
            txtUserIDonRoles.Text = "";
            txtUsernameOnRoles.Text = "";
            txtUserIDNOonRoles.Text = "";
            ddl_AvailableRoles.SelectedIndex = 0;
            lstUsersOnRoles.Visible = false;
        }

        protected void btnSearchUserforRoles_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("select UserID, isnull(user_Surname,'')+' '+isnull(user_Fname,'')+' --- '+isnull(convert(varchar,UserID),'')+' --- '+isnull(user_IDNO,'') as display from[dbo].[tbl_Lab_Assist_Users]  where isnull(user_Surname,'')+'---'+isnull(user_Fname,'')+' --- '+isnull(convert(varchar,UserID),'')+' --- '+isnull(user_IDNO,'') like '%" + txtSearchUsers.Text + "%'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cust");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lstUsersOnRoles.Visible = true;
                            lstUsersOnRoles.DataSource = ds.Tables[0];
                            lstUsersOnRoles.DataTextField = "display";
                            lstUsersOnRoles.DataValueField = "UserID";
                        }
                        else
                        {
                            lstUsersOnRoles.DataSource = null;
                            string script = "alert(\"The searched name was not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }

                        lstUsersOnRoles.DataBind();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void lstUsersOnRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllOnRoles();
            getmyUserDetailsforRoles(lstUsersOnRoles.SelectedValue);
        }
        protected void getmyUserDetailsforRoles(string userID)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select  UserID, user_Surname, user_Fname, user_Gender, user_IDNO, user_Dept,user_Occupation,user_Username,user_userpwd,user_useremail,user_userphone,user_userRoleID,user_DateCreated from [dbo].[tbl_Lab_Assist_Users] where UserID='" + userID + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtUserID.Text = dt.Rows[0]["UserID"].ToString();

                            txtRoleID.Text = dt.Rows[0]["user_userRoleID"].ToString();

                            txtUserIDonRoles.Text = dt.Rows[0]["UserID"].ToString();
                            txtUsernameOnRoles.Text = dt.Rows[0]["user_Surname"].ToString();
                            txtUserIDNOonRoles.Text = dt.Rows[0]["user_IDNO"].ToString();
                            ddl_AvailableRoles.SelectedValue = dt.Rows[0]["user_userRoleID"].ToString();


                        }
                        else
                        {
                            string script = "alert(\"User record not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }
                            
                    }
                }
            }
            catch (Exception )
            {
               
            }

        }

        protected void ddl_AvailableRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoleID.Text = ddl_AvailableRoles.SelectedValue;
        }

        protected void btnAssignRole_Click(object sender, EventArgs e)
        {
            if (txtUserIDonRoles.Text == "")
            {
                string script = "alert(\"Select a user\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update [dbo].[tbl_Lab_Assist_Users] set [user_userRoleID]='" + ddl_AvailableRoles.SelectedValue + "' where UserID='" + txtUserIDonRoles.Text + "'", con);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"User role successfully assigned\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAllOnRoles();

            }
            catch (Exception)
            {

            }
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            if (txtDept.Text == "")
            {
                string script = "alert(\"Provide name\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveDepartment]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Department", txtDept.Text);


                cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Dept successfully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                txtDept.Text = "";
                loadDepartments();

            }
            catch (Exception)
            {
               
            }
        }

        protected void btnAddOccupation_Click(object sender, EventArgs e)
        {
            if (txtOccupation.Text == "")
            {
                string script = "alert(\"Enter New Occupation name\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_AvailableDepts.SelectedIndex == 0)
            {
                string script = "alert(\"Specify the Dept of the new Occupation\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveOccupation]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                cmd.Parameters.AddWithValue("@DeptID", ddl_AvailableDepts.SelectedValue);


                cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Occupation details successfully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                txtOccupation.Text = "";
                ddl_AvailableDepts.SelectedIndex = 0;


            }
            catch (Exception)
            {

            }
        }

        protected void ddl_AvailableDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Department]", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtDeptID.Text = dt.Rows[0]["ID"].ToString();

                        }
                        else
                        {
                            string script = "alert(\"Record not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);

                        }
                           
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnAddBranch_Click(object sender, EventArgs e)
        {
            if (txtNewBranch.Text == "")
            {
                string script = "alert(\"Enter new Branch name\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveBranch]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BranchName", txtNewBranch.Text);


                cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Branch details successully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                txtNewBranch.Text = "";
                loadBranches();

            }
            catch (Exception)
            {

            }
        }
    }
}