using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Services;

namespace Lab_Assist
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtDateCreated.Text = DateTime.Today.ToString("dd/MM/yyyy");
                //loadServices();
                loadLocations();
                loadTestCategories();
                loadProducts();
                loadSpecimenTypes();
                BankEncryption64 EncQuery = new BankEncryption64();
                if (Request.QueryString["LabNumber"] == null | Request.QueryString["LabNumber"] == String.Empty)
                {

                }
                else
                {
                    ViewState["labno"] = EncQuery.Decrypt(Request.QueryString["LabNumber"].Replace(" ", "+"));

                    loadCustomerDetails(ViewState["labno"].ToString());

                }

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
        private void loadLocations()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Location]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_Cities.DataSource = ds.Tables[0];
                            ddl_Cities.DataTextField = "City";
                            ddl_Cities.DataValueField = "ID";

                        }
                        else
                        {
                            ddl_Cities.DataSource = null;

                        }

                        ddl_Cities.DataBind();

                        ddl_Cities.Items.Insert(0, "--Select Location--");


                    }
                }
            }
            catch (Exception)
            {

            }

        }

        protected void btnSearchCustomer_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("select LabNumber, isnull(Full_Name,'')+' '+isnull(LabNumber,'')+' '+isnull(IDNO,'') as display from [dbo].[tbl_Appointments] where isnull(Full_Name,'')+' '+isnull(LabNumber,'')+' '+isnull(IDNO,'') like '%" + txtSearchCustomer.Text + "%' and CustomerType not in ('New')", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cust");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lstCustomers.Visible = true;
                            lstCustomers.DataSource = ds.Tables[0];
                            lstCustomers.DataTextField = "display";
                            lstCustomers.DataValueField = "LabNumber";
                        }
                        else
                        {
                            lstCustomers.DataSource = null;
                            string script = "alert(\"Error:404- The searched name was not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }

                        lstCustomers.DataBind();
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        protected void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCustomerDetails(lstCustomers.SelectedValue);
            getSelectedServices(lstCustomers.SelectedValue);

        }
        private void loadCustomerDetails(string labno)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select ID,CustomerType,LabNumber,Full_Name,Email,Phone_Number,convert(varchar,Appointment_Date,103)AppointmentDate,IDNO,Gender,convert(varchar,DOB,103)DOB,Address,Location,isnull((Select Other  from tbl_SelectedServices where  Other != '' and Other is not null and LabNumber='" + labno + "'),'N/A')Other from tbl_Appointments where LabNumber='" + labno +"'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtDateCreated.Text = dt.Rows[0]["AppointmentDate"].ToString();
                            txtlabNo.Text = dt.Rows[0]["LabNumber"].ToString();
                            txtFullName.Text = dt.Rows[0]["Full_Name"].ToString();
                            txtemail.Text = dt.Rows[0]["Email"].ToString();
                            txtphone.Text = dt.Rows[0]["Phone_Number"].ToString();
                            txtIDNO.Text = dt.Rows[0]["IDNO"].ToString();
                            ddl_Gender.SelectedValue= dt.Rows[0]["Gender"].ToString();
                            txtDOB.Text= dt.Rows[0]["DOB"].ToString();
                            txtaddress.Text = dt.Rows[0]["Address"].ToString();
                            ddl_Cities.SelectedValue= dt.Rows[0]["Location"].ToString();
                            rdblClientType.SelectedValue= dt.Rows[0]["CustomerType"].ToString();
                            txtOther.Visible = true;
                            txtOther.Text = dt.Rows[0]["Other"].ToString();
                  
                        }
                        else
                        {
                            string script = "alert(\"Error:404- The searched name was not found\");";
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
        private void getSelectedServices(string labno)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select tss.ID, LabNumber,ServiceID,ts.Service_Required,ServiceOption,isnull(Other,'N/A')Other from [dbo].[tbl_SelectedServices] tss left join [dbo].[tbl_Services] ts ON tss.ServiceID=ts.ID where LabNumber='" + labno + "'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {


                            //chkServices.Visible = false;
                            chkSelectedServices.Visible = true;
                            chkSelectedServices.DataSource = ds.Tables[0];
                            chkSelectedServices.DataTextField = "Service_Required";
                            chkSelectedServices.DataValueField = "ServiceID";
                            chkSelectedServices.DataBind();
                          
                            foreach (ListItem li in chkSelectedServices.Items)
                            {
                               
                                li.Selected = true;
                            }

                        }
                        else
                        {
                            chkSelectedServices.DataSource = null;

                        }

                    }
                }
            }
            catch (Exception)
            {

            }
       
        }
      
        private void ClearAll()
        {
            txtDateCreated.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtOther.Text = "";
            txtlabNo.Text = "";
            txtFullName.Text = "";
            txtemail.Text = "";
            txtphone.Text = "";
            txtIDNO.Text = "";
            ddl_Gender.SelectedIndex = 0;
            txtDOB.Text = "";
            txtaddress.Text = "";
            ddl_Cities.SelectedIndex = 0;
            ddl_Category.SelectedIndex = 0;
            ddl_SpecimenTypes.SelectedIndex = 0;
            ddl_Products.SelectedIndex = 0;
           
            txtTestCode.Text = "";
            lstTests.Items.Clear();
            lstCustomers.DataSource = null;
            if (lstCustomers.Visible == true)
            {
                lstCustomers.Visible = false;
            }
            if (chkSelectedServices.Visible == true)
            {
                chkSelectedServices.DataSource = null;
                chkSelectedServices.Visible = false;
                //loadServices();
            }
            if (txtOther.Visible == true)
            {
                txtOther.Visible = false;
                txtOther.Text = "";
            }
            if (lstTests.Visible == true)
            {
                lstTests.Visible = false;

            }

        }

        protected void lnkRefresh_Click(object sender, EventArgs e)
        {
            ClearAll();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (rdblClientType.SelectedValue == "")
            {
                string script = "alert(\"Patient Type is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;

            }
          
            try
            {
                if (rdblClientType.SelectedValue == "Online")
                {
                    if (txtFullName.Text == "")
                    {
                        string script = "alert(\"Full name is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (txtphone.Text == "")
                    {
                        string script = "alert(\"Your Phone number  is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }

                    if (txtDateCreated.Text == "")
                    {
                        string script = "alert(\"Testing Date is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (txtaddress.Text == "")
                    {
                        string script = "alert(\"Physical Address is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (txtTime.Text == "")
                    {
                        string script = "alert(\"Provide Preferred Time for Testing\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (ddl_Cities.SelectedIndex == 0)
                    {
                        string script = "alert(\"Location is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (ddl_Category.SelectedIndex == 0)
                    {
                        string script = "alert(\"Test Category is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;

                    }
                    if (ddl_Products.SelectedIndex == 0)
                    {
                        string script = "alert(\"Test is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;

                    }
                    List<string> serviceslist = new List<string>();
                    foreach (ListItem li in lstTests.Items)
                    {
                        serviceslist.Add(li.Value.ToString());

                    }
                    try
                    {
                        foreach (string service in serviceslist)
                    {

                       
                            DateTime TestDate = DateTime.ParseExact(txtDateCreated.Text, "dd/MM/yyyy", null);
                            TestDate = Convert.ToDateTime(TestDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                            DateTime DOBDate = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", null);
                            DOBDate = Convert.ToDateTime(DOBDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);


                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                            con.Open();
                            SqlCommand cmd = new SqlCommand("[dbo].[SP_SavePendingResultsOnline]", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@LabNumber", txtlabNo.Text);
                            cmd.Parameters.AddWithValue("@Full_Name", txtFullName.Text);
                            cmd.Parameters.AddWithValue("@IDNO", txtIDNO.Text);
                            cmd.Parameters.AddWithValue("@Gender", ddl_Gender.SelectedValue);
                            cmd.Parameters.AddWithValue("@DOB", DOBDate);
                            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                            cmd.Parameters.AddWithValue("@Phone_Number", txtphone.Text);
                            cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                            cmd.Parameters.AddWithValue("@LocationID", ddl_Cities.SelectedValue);
                            cmd.Parameters.AddWithValue("@Test_Date", TestDate);
                            cmd.Parameters.AddWithValue("@Test_Time", txtTime.Text);
                            cmd.Parameters.AddWithValue("@ProductID", service);



                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();

                            }
                            SqlParameter IdParam = new SqlParameter("@TestID", SqlDbType.BigInt);
                            IdParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(IdParam);

                            cmd.ExecuteNonQuery();
                            string ID = IdParam.Value.ToString();
                            txtlabNo.Text = getLabNumber(ID.ToString());
                            ViewState["labno"] = getLabNumber(ID.ToString());
                            //insertservices(getLabNumber(ID.ToString()));
                            //SendEmail();
                         

                            con.Close();

                            //loadCustomerDetails(getLabNumber(ID.ToString()));
                            //getSelectedServices(getLabNumber(ID.ToString()));
                        }
                        string script = "alert(\"Submitted Successfully\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        ClearAll();
                    }
                        catch (Exception)
                        {
                                         

                        }

                    }

              
                else if (rdblClientType.SelectedValue == "New")
                {
                    ViewState["labno"] = "";

                    if (txtFullName.Text == "")
                    {
                        string script = "alert(\"Full name is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (txtphone.Text == "")
                    {
                        string script = "alert(\"Your Phone number  is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }

                    if (txtDateCreated.Text == "")
                    {
                        string script = "alert(\"Testing Date is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (txtaddress.Text == "")
                    {
                        string script = "alert(\"Physical Address is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (txtTime.Text == "")
                    {
                        string script = "alert(\"Provide Preferred Time for Testing\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;
                    }
                    if (ddl_Category.SelectedIndex == 0)
                    {
                        string script = "alert(\"Test Category is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;

                    }
                    if (ddl_Products.SelectedIndex == 0)
                    {
                        string script = "alert(\"Test is required\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        return;

                    }

                    List<string> serviceslist = new List<string>();
                    foreach (ListItem li in lstTests.Items)
                    {
                        serviceslist.Add(li.Value.ToString());

                    }
                    try
                    {

                        foreach (string service in serviceslist)
                        {
                       
                            DateTime TestDate = DateTime.ParseExact(txtDateCreated.Text, "dd/MM/yyyy", null);
                            TestDate = Convert.ToDateTime(TestDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                            DateTime DOBDate = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", null);
                            DOBDate = Convert.ToDateTime(DOBDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);


                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                            con.Open();
                            SqlCommand cmd = new SqlCommand("[dbo].[SP_SavePendingResults]", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@LabNumber", txtlabNo.Text);
                            cmd.Parameters.AddWithValue("@Full_Name", txtFullName.Text);
                            cmd.Parameters.AddWithValue("@IDNO", txtIDNO.Text);
                            cmd.Parameters.AddWithValue("@Gender", ddl_Gender.SelectedValue);
                            cmd.Parameters.AddWithValue("@DOB", DOBDate);
                            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                            cmd.Parameters.AddWithValue("@Phone_Number", txtphone.Text);
                            cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                            cmd.Parameters.AddWithValue("@LocationID", ddl_Cities.SelectedValue);
                            cmd.Parameters.AddWithValue("@Test_Date", TestDate);
                            cmd.Parameters.AddWithValue("@Test_Time", txtTime.Text);
                            cmd.Parameters.AddWithValue("@ProductID", service);



                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();

                            }
                            SqlParameter IdParam = new SqlParameter("@TestID", SqlDbType.BigInt);
                            IdParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(IdParam);

                            cmd.ExecuteNonQuery();
                            string ID = IdParam.Value.ToString();
                            txtlabNo.Text = getLabNumber(ID.ToString());
                            ViewState["labno"] = getLabNumber(ID.ToString());
                       
                            con.Close();

                        }
                        string script = "alert(\"Submitted successfully\");" + getLabNumber(ID.ToString());
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                 
                    }
                        catch (Exception)
                        {

                       
                        }

                    }

            }
            catch (Exception)
            {

            }

        }
        private Boolean checkIfExists()
        {
           
             
                        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                        {
                            using (var cmd = new SqlCommand("Select * from tbl_PendingResults where LabNumber='"+ txtlabNo.Text +"' and ProductID='"+ ddl_Products.SelectedValue +"'", con))
                            {
                                DataTable dt = new DataTable();
                                var adp = new SqlDataAdapter(cmd);
                                adp.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                            return true;
                                  

                                }
                                else
                                {
                            return false;

                                }

                            }
                        }
          
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (checkIfExists() == true)
            {
                string script = "alert(\"This record already Exists and has pending Results.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;


            }
            if (txtFullName.Text == "")
            {
                string script = "alert(\"Full name is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtphone.Text == "")
            {
                string script = "alert(\"Your Phone number  is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }

            if (txtDateCreated.Text == "")
            {
                string script = "alert(\"Testing Date is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtaddress.Text == "")
            {
                string script = "alert(\"Physical Address is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtTime.Text == "")
            {
                string script = "alert(\"Provide Preferred Time for Testing\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                DateTime TestDate = DateTime.ParseExact(txtDateCreated.Text, "dd/MM/yyyy", null);
                TestDate = Convert.ToDateTime(TestDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                DateTime DOBDate = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", null);
                DOBDate = Convert.ToDateTime(DOBDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveNewClientstoAppointments]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Full_Name", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Phone_Number", txtphone.Text);
                cmd.Parameters.AddWithValue("@Appointment_Date", TestDate);
                cmd.Parameters.AddWithValue("@Appointment_Time", txtTime.Text);
                cmd.Parameters.AddWithValue("@IDNO", txtIDNO.Text);
                cmd.Parameters.AddWithValue("@Gender", ddl_Gender.SelectedValue);
                cmd.Parameters.AddWithValue("@DOB", DOBDate);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Location", ddl_Cities.SelectedValue);
              
               
                cmd.Parameters.AddWithValue("@filName", "");
                cmd.Parameters.AddWithValue("@ContentType", "");
                cmd.Parameters.AddWithValue("@ImgFile", "");


                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }
                SqlParameter IdParam = new SqlParameter("@ID", SqlDbType.BigInt);
                IdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(IdParam);

                cmd.ExecuteNonQuery();
                string ID = IdParam.Value.ToString();
                //txtlabNo.Text=getLabNumber(ID.ToString());
                
                ViewState["labno"] = getLabNumber(ID.ToString());
                BankEncryption64 EncQuery = new BankEncryption64();
                lblAgree.Text = ViewState["labno"].ToString();
                lblEncAgree.Text = EncQuery.Encrypt(ViewState["labno"].ToString().Replace(" ", "+"));
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">showPopup()</script>");

              

                con.Close();
                //ClearAll();
         
            }
            catch (Exception)
            {


            }

        }
        private string getLabNumber(string scopeid)
        {
            string newlabnumber = "";
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select LabNumber from tbl_Appointments where ID ='" + scopeid + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            newlabnumber = dt.Rows[0]["LabNumber"].ToString();
                            return newlabnumber;


                        }
                        else
                        {
                            return "";
                        }

                    }
                }
            }
            catch (Exception)
            {

            }
            return newlabnumber;
        }
        //private void insertservices(string labnumber)
        //{
        //    try
        //    {
        //        foreach (ListItem service in chkServices.Items)
        //        {
        //            if (service.Selected == true)
        //            {
        //                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
        //                con.Open();
        //                SqlCommand cmd = new SqlCommand("SP_SaveServices", con);
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@LabNumber", labnumber);
        //                cmd.Parameters.AddWithValue("@ServiceID", service.Value);
        //                cmd.Parameters.AddWithValue("@ServiceOption", service.Selected);
        //                if (service.Text == "Other")
        //                {
        //                    cmd.Parameters.AddWithValue("@Other", txtOther.Text);
        //                }
        //                else
        //                {
        //                    cmd.Parameters.AddWithValue("@Other", "");
        //                }

        //                if (con.State != ConnectionState.Open)
        //                {
        //                    con.Open();

        //                }

        //                cmd.ExecuteNonQuery();

        //                con.Close();
                      

        //            }

        //        }
        //        ClearAll();


        //    }
        //    catch (Exception)
        //    {

        //    }

        //}
        protected void SendEmail()
        {
            string from = "codedimensions.info@gmail.com";   
            using (MailMessage mail = new MailMessage(from, "vickietende@gmail.com"))
            {
                mail.Subject = "Genomix Medical Centre";
                mail.Body = "Registration from: " + ViewState["fullname"] + " | " + " Lab No.: " + ViewState["labno"] + " | " + " Appointment Date:" + ViewState["testdate"] + " | " + " Time: " + ViewState["time"] + " | " + " Address: " + ViewState["address"] + " | " + " Phone Number: " + ViewState["phone"] + " | " + "  Email: " + ViewState["email"] + " | " + " Services Required: " + SendSelectedServices(ViewState["labno"].ToString());
              
                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, "tracieganga&85");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email Message has been sent successfully.');", true);
            }
        }
        private string SendSelectedServices(string labno)
        {
            string service = "";
            string otherservice = "";
            List<string> serviceslist = new List<string>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select ts.Service_Required,ss.Other from [dbo].[tbl_SelectedServices] ss left Join tbl_Services ts ON ss.ServiceID=ts.ID where LabNumber='" + labno + "'", con))
                    {

                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                service = dt.Rows[i]["Service_Required"].ToString();
                                if (service == "Other")
                                {
                                    otherservice = dt.Rows[i]["Other"].ToString();
                                    serviceslist.Add(otherservice);
                                }
                                serviceslist.Add(service);
                                service = string.Join(",", serviceslist.ToArray());
                            }

                            return service;


                        }
                        else
                        {
                            return "";
                        }



                    }
                }
            }
            catch (Exception)
            {
                

            }
            return service;

        }

        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterProducts(ddl_Category.SelectedValue);
        }
        private void filterProducts(string categoryID)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Products] where CategoryID='" + categoryID + "'", con))
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
        private void loadProducts()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Products] ", con))
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

        protected void ddl_Products_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select ProductID,TestCode,Test,CategoryID,SpecimenTypeID,tst.Specimen_Type from [dbo].[tbl_Products] tp left join tbl_SpecimenTypes tst ON tp.SpecimenTypeID=tst.ID where ProductID='" + ddl_Products.SelectedValue + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            txtTestCode.Text = dt.Rows[0]["TestCode"].ToString();
                            ddl_SpecimenTypes.SelectedValue = dt.Rows[0]["SpecimenTypeID"].ToString();
                            lstTests.Visible = true;
                            lstTests.Items.Add(new ListItem(ddl_Products.SelectedItem.Text, ddl_Products.SelectedValue));

                        }
                        else
                        {
                            string script = "alert(\"Error:404- The searched name was not found\");";
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

        protected void lstTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstTests.Items.Remove(lstTests.SelectedItem);
        }
  
    }
}