using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

namespace Lab_Assist
{
    public partial class ResultsRepository : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadPendingResults();
                loadArchivedResults();

            }

        }
     
      
        protected void loadPendingResults()
        {
            try
            {
                ListBox lstServices = lvPendingResults.FindControl("lstServices") as ListBox;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select pr.TestID, Full_Name,IDNO,Gender,Phone_Number,p.Test,pr.LabNumber,convert(varchar,pr.Test_Date,103)Test_Date,pr.Test_Time, Case when pr.Status=0 THEN 'Pending' END AS Status from tbl_CustomerDetails cd left join tbl_PendingResults pr ON cd.CustomerNo=pr.CustomerNo left join tbl_Products p ON pr.ProductID=p.ProductID where pr.Status=0", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "QGM");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lvPendingResults.DataSource = ds.Tables[0];
                            lvPendingResults.Visible = true;
                            lvPendingResults.DataBind();


                        }
                        else
                        {
                            lvPendingResults.DataSource = null;
                            lblNotification.Visible = true;
                            lblNotification.Text = "No Pending Results!";

                        }

                    }
                }


            }
            catch (Exception)
            {
               

            }
        }

        protected void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            filterCustomersList(txtSearchCustomer.Text);
        }


        private void filterCustomersList(string searchname)
        {
            try
            {
                ListBox lstServices = lvPendingResults.FindControl("lstServices") as ListBox;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select pr.TestID, Full_Name,IDNO,Gender,Phone_Number,p.Test,pr.LabNumber,convert(varchar,pr.Test_Date,103)Test_Date,pr.Test_Time, Case when pr.Status=0 THEN 'Pending' END AS Status from tbl_CustomerDetails cd left join tbl_PendingResults pr ON cd.CustomerNo=pr.CustomerNo left join tbl_Products p ON pr.ProductID=p.ProductID where Full_Name LIKE '%" + searchname + "%' and  pr.Status=0", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "QGM");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lvPendingResults.DataSource = ds.Tables[0];
                            lvPendingResults.Visible = true;
                            lvPendingResults.DataBind();


                        }
                        else
                        {
                            lvPendingResults.DataSource = null;
                            lblNotification.Visible = true;
                            lblNotification.Text = "No Pending Results!";

                        }

                    }
                }


            }
            catch (Exception)
            {


            }
        }
            protected void loadArchivedResults()
            {
                try
                {
                    
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                    {
                        using (var cmd = new SqlCommand("Select pr.TestID, Full_Name,IDNO,Gender,Phone_Number,p.Test,pr.LabNumber,convert(varchar,pr.Test_Date,103)Test_Date,pr.Test_Time, Case when pr.Status=1 THEN 'ISSUED' END AS Status from tbl_CustomerDetails cd left join tbl_PendingResults pr ON cd.CustomerNo=pr.CustomerNo left join tbl_Products p ON pr.ProductID=p.ProductID where pr.Status=1", con))
                        {
                            DataSet ds = new DataSet();
                            var adp = new SqlDataAdapter(cmd);
                            adp.Fill(ds, "QGM");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                grdArchive.DataSource = ds.Tables[0];
                                grdArchive.Visible = true;
                                grdArchive.DataBind();


                            }
                            else
                            {
                                grdArchive.DataSource = null;
                                lblArchiveNotification.Text = "Error-404:No Pending Results found";

                            }

                        }
                    }


                }
                catch (Exception)
                {
            
                }
            }

        protected void grdArchive_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdArchive.PageIndex = e.NewPageIndex;
            loadArchivedResults();

        }

        protected void grdArchive_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView grdArchive = Master.FindControl("ContentPlaceHolder1").FindControl("grdArchive") as GridView;

                Label lblIDEdit = grdArchive.Rows[e.NewEditIndex].FindControl("lblIDEdit") as Label;
                string IDEdit = lblIDEdit.Text;


                grdArchive.EditIndex = e.NewEditIndex;

                loadArchivedResults();

            }
            catch (Exception)
            {
            }
        }

        protected void grdArchive_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdArchive.EditIndex = -1;

            Label lblIDEdit = grdArchive.Rows[e.RowIndex].FindControl("lblIDEdit") as Label;
            string IDEdit = lblIDEdit.Text;
            loadArchivedResults();
        }

        protected void grdArchive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Label lblLabNumber = grdArchive.SelectedRow.FindControl("lblLabNumber") as Label;
                string LabNumber = lblLabNumber.Text;
           
              
                string outputFileName = System.Web.Hosting.HostingEnvironment.MapPath("~/Docs/" + LabNumber + ".docx");
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outputFileName) { UseShellExecute = true });
            }
            catch (Exception)
            {

            }

        }

        protected void btnSearchArchive_Click(object sender, EventArgs e)
        {
            filterArchivesList(txtSearchArchive.Text);
        }
        private void filterArchivesList(string searchname)
        {
            try
            {
                ListBox lstServices = lvPendingResults.FindControl("lstServices") as ListBox;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select pr.TestID, Full_Name,IDNO,Gender,Phone_Number,p.Test,pr.LabNumber,convert(varchar,pr.Test_Date,103)Test_Date,pr.Test_Time, Case when pr.Status=1 THEN 'Pending' END AS Status from tbl_CustomerDetails cd left join tbl_PendingResults pr ON cd.CustomerNo=pr.CustomerNo left join tbl_Products p ON pr.ProductID=p.ProductID where Full_Name LIKE '%" + searchname + "%' and  pr.Status=1", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "QGM");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grdArchive.DataSource = ds.Tables[0];
                            grdArchive.Visible = true;
                            grdArchive.DataBind();


                        }
                        else
                        {
                            grdArchive.DataSource = null;
                            lblArchiveNotification.Visible = true;
                            lblArchiveNotification.Text = "No Matches on Archived Results!";

                        }

                    }
                }


            }
            catch (Exception)
            {


            }
        }
    }
}