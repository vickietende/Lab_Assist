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
    public partial class ProductMgt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadTestCategories();
                loadSpecimenTypes();
                loadProducts();
                filProducts();
            }

        }
        private void loadProducts()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Products]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ddl_Products.DataSource = ds.Tables[0];
                            ddl_Products.DataTextField = "Test";
                            ddl_Products.DataValueField = "ProductID";

                        }
                        else
                        {
                            ddl_Products.DataSource = null;

                        }

                        ddl_Products.DataBind();
                        ddl_Products.Items.Insert(0, "-- Select Test --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadTestCategories()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_TestCategories]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                     
                            ddl_Category.DataSource = ds.Tables[0];
                            ddl_Category.DataTextField = "CategoryName";
                            ddl_Category.DataValueField = "CategoryID";

                        }
                        else
                        {
                            ddl_Category.DataSource = null;

                        }

                        ddl_Category.DataBind();
                        ddl_Category.Items.Insert(0, "-- Select Category --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadSpecimenTypes()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_SpecimenTypes]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ddl_SpecimenTypes.DataSource = ds.Tables[0];
                            ddl_SpecimenTypes.DataTextField = "Specimen_Type";
                            ddl_SpecimenTypes.DataValueField = "ID";

                        }
                        else
                        {
                            ddl_SpecimenTypes.DataSource = null;

                        }

                        ddl_SpecimenTypes.DataBind();
                        ddl_SpecimenTypes.Items.Insert(0, "-- Select Specimen Type --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void filProducts()
        {
            try
            {
                
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select ProductID,Test,tc.CategoryName,st.Specimen_Type,tp.TestCode from [dbo].[tbl_Products] tp left join [dbo].[tbl_TestCategories] tc ON tp.CategoryID=tc.CategoryID left join [dbo].[tbl_SpecimenTypes] st ON tp.SpecimenTypeID=st.ID", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "QGM");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grdProducts.DataSource = ds.Tables[0];
                            grdProducts.Visible = true;
                            grdProducts.DataBind();
                        }
                        else
                            grdProducts.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
              
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddl_Category.SelectedIndex == 0)
            {
                string script = "alert(\"Test Category is Required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;


            }
            if (ddl_SpecimenTypes.SelectedIndex == 0)
            {
                string script = "alert(\"Specimen Type is Required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;

            }
            if (txtTest.Text == "")
            {
                string script = "alert(\"Test name is Required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;

            }
           

            try
            {
               

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TestCode", txtTestCode.Text);
                cmd.Parameters.AddWithValue("@Test", txtTest.Text);
                cmd.Parameters.AddWithValue("@CategoryID", ddl_Category.SelectedValue);
                cmd.Parameters.AddWithValue("@SpecimenTypeID", ddl_SpecimenTypes.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);



                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();
                loadProducts();

                string script = "alert(\"New Product successfully created\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                ClearAll();
               
                con.Close();



            }
            catch (Exception)
            {

            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_EditProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ddl_Products.SelectedValue);
                cmd.Parameters.AddWithValue("@TestCode", txtTestCode.Text);
                cmd.Parameters.AddWithValue("@Test", txtTest.Text);
                cmd.Parameters.AddWithValue("@CategoryID", ddl_Category.SelectedValue);
                cmd.Parameters.AddWithValue("@SpecimenTypeID", ddl_SpecimenTypes.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);



                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Product information successfully updated\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                ClearAll();
                loadProducts();

                con.Close();



            }
            catch (Exception)
            {

            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();  

        }

        private void ClearAll()
        {
            txtTestCode.Text = "";
            txtTest.Text = "";
            ddl_Category.SelectedIndex = 0;
            ddl_SpecimenTypes.SelectedIndex = 0;
            txtPrice.Text = "";

        }

        protected void ddl_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProductDetails(ddl_Products.SelectedValue);

        }
        private void loadProductDetails(string prodid)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select ProductID,TestCode,Test,CategoryID,SpecimenTypeID , cast(Price as decimal(10,2)) Price from [dbo].[tbl_Products] where ProductID='"+ prodid +"'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            ddl_Category.SelectedValue = dt.Rows[0]["CategoryID"].ToString();
                            ddl_SpecimenTypes.SelectedValue = dt.Rows[0]["SpecimenTypeID"].ToString();
                            txtTest.Text = dt.Rows[0]["Test"].ToString();
                            txtTestCode.Text = dt.Rows[0]["TestCode"].ToString();
                            txtPrice.Text = dt.Rows[0]["Price"].ToString();
                          

                        }
                        else
                        {
                            string script = "alert(\"Error:404- The searched product was not found\");";
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

        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Products] where CategoryID='"+ ddl_Category.SelectedValue +"'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ddl_Products.DataSource = ds.Tables[0];
                            ddl_Products.DataTextField = "Test";
                            ddl_Products.DataValueField = "ProductID";

                        }
                        else
                        {
                            ddl_Products.DataSource = null;

                        }

                        ddl_Products.DataBind();
                        ddl_Products.Items.Insert(0, "-- Select Test --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_TestCategories (CategoryName)VALUES('"+ txtAddCategory.Text +"')", con);
               
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();
                loadProducts();

                string script = "alert(\"New Category successfully saved!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                loadTestCategories();
                ClearAll();

                con.Close();



            }
            catch (Exception)
            {

            }

        }

        protected void btnAddSpecimen_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_SpecimenTypes (Specimen_Type)VALUES('" + txtAddSpecimen.Text + "')", con);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();
                loadProducts();

                string script = "alert(\"New Specimen Type successfully added!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                loadSpecimenTypes();
                ClearAll();

                con.Close();



            }
            catch (Exception)
            {

            }

        }

        protected void grdProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView grdProducts = Master.FindControl("ContentPlaceHolder1").FindControl("grdProducts") as GridView;

            Label lblIDEdit = grdProducts.SelectedRow.FindControl("lblIDEdit") as Label;
            string IDEdit = lblIDEdit.Text;
            loadProductDetails(IDEdit);

        }

        protected void grdProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProducts.PageIndex = e.NewPageIndex;
            filProducts();

        }

        protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView grdProducts = Master.FindControl("ContentPlaceHolder1").FindControl("grdProducts") as GridView;

                Label lblIDEdit = grdProducts.Rows[e.NewEditIndex].FindControl("lblIDEdit") as Label;
                string IDEdit = lblIDEdit.Text;

                grdProducts.EditIndex = e.NewEditIndex;

                filProducts();

            }
            catch (Exception)
            {
            }

        }

        protected void grdProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProducts.EditIndex = -1;

            Label lblIDEdit = grdProducts.Rows[e.RowIndex].FindControl("lblIDEdit") as Label;
            string IDEdit = lblIDEdit.Text;
            filProducts();

        }
    }
}