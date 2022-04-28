using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Xceed.Words.NET;
using System.Diagnostics;
using System.IO;
using SautinSoft.Document;
using SautinSoft.Document.Drawing;
using System.Drawing;
using ZXing;
using System.Drawing.Imaging;
using Xceed;
using GemBox.Document;

namespace Lab_Assist.Results
{
    public partial class HIV_ViralLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDateCreated.Text = DateTime.Now.ToString("dd/MM/yyyy");
                loadProducts();
                loadTestCategories();
                loadSpecimenTypes();
                loadProductDetails(ddl_Products.SelectedValue);
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
                        ddl_Products.SelectedValue = "2";
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
        private void loadProductDetails(string prodid)
        {

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from tbl_Products where ProductID='" + prodid + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            ddl_Category.SelectedValue = dt.Rows[0]["CategoryID"].ToString();
                            ddl_SpecimenTypes.SelectedValue = dt.Rows[0]["SpecimenTypeID"].ToString();
                            txtTestCode.Text = dt.Rows[0]["TestCode"].ToString();

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

        protected void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select pr.LabNumber, isnull(Full_Name, '') + ' ' + isnull(pr.LabNumber, '') + ' ' + isnull(IDNO, '') + ' ' + isnull(pr.CustomerNo, '') as display from tbl_CustomerDetails cd left join tbl_PendingResults pr ON cd.CustomerNo = pr.CustomerNo where isnull(Full_Name, '') + ' ' + isnull(pr.LabNumber, '') + ' ' + isnull(IDNO, '') + ' ' + isnull(pr.CustomerNo, '') like '%" + txtSearchCustomer.Text + "%' and convert(varchar, ProductID) = '" + ddl_Products.SelectedValue + "' and pr.Status = 0", con))
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
                            string script = "alert(\"Error:404-No matches\");";
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
            loadCustomerDetails(lstCustomers.SelectedValue, ddl_Products.SelectedValue);

        }
        private void loadCustomerDetails(string labno, string prodid)
        {

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select pr.LabNumber,pr.CustomerNo,Full_Name,IDNO,Gender,convert(varchar,DOB,103)DOB,Email,Phone_Number,Address,LocationID,pr.Test_Date,pr.Test_Time from tbl_CustomerDetails cd left join tbl_PendingResults pr ON cd.CustomerNo=pr.CustomerNo where LabNumber='" + labno + "' and ProductID='" + prodid + "' and pr.Status=0", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            txtlabNo.Text = dt.Rows[0]["LabNumber"].ToString();
                            txtCustomerNo.Text = dt.Rows[0]["CustomerNo"].ToString();
                            txtFullName.Text = dt.Rows[0]["Full_Name"].ToString();
                            txtIDNO.Text = dt.Rows[0]["IDNO"].ToString();
                            ddl_Gender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                            txtDOB.Text = dt.Rows[0]["DOB"].ToString();

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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtlabNo.Text == "")
            {

                string script = "alert(\"Lab Number is required!!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;

            }
            if (ddl_Products.SelectedIndex == 0)
            {

                string script = "alert(\"Test is required!!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;

            }
            if (txtHIVRNA.Text == "")
            {

                string script = "alert(\"HIV RNA value is required!!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;

            }
            if (txtLogValue.Text == "")
            {

                string script = "alert(\"Log Value is required!!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;

            }
          
            try
            {
                ViewState["labno"] = "";
                ViewState["ProdID"] = "";
                DateTime ReceivedDate = DateTime.ParseExact(txtDateCreated.Text, "dd/MM/yyyy", null);
                ReceivedDate = Convert.ToDateTime(ReceivedDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                DateTime DOBDate = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", null);
                DOBDate = Convert.ToDateTime(DOBDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveHIVViralLoadResults]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LabNumber", txtlabNo.Text);
                cmd.Parameters.AddWithValue("@ProductID", ddl_Products.SelectedValue);
                cmd.Parameters.AddWithValue("@CustomerNo", txtCustomerNo.Text);
                cmd.Parameters.AddWithValue("@TestCode", txtTestCode.Text);
                cmd.Parameters.AddWithValue("@HIVRNA", txtHIVRNA.Text);
                cmd.Parameters.AddWithValue("@LogValue", txtLogValue.Text);
                
                cmd.Parameters.AddWithValue("@DateReceived", ReceivedDate);
                cmd.Parameters.AddWithValue("@TimeEntered", txtTime.Text);
                cmd.Parameters.AddWithValue("@Doctor", txtDoctor.Text);
                cmd.Parameters.AddWithValue("@Hospital", txtHospital.Text);
                cmd.Parameters.AddWithValue("@ResultDocument", "~/Docs/" + txtlabNo.Text + ".pdf");
                cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                cmd.Parameters.AddWithValue("@Payment_Status", ChkIsPaid.Checked);
                cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }
                SqlParameter IdParam = new SqlParameter("@ID", SqlDbType.BigInt);
                IdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(IdParam);

                cmd.ExecuteNonQuery();
                string ID = IdParam.Value.ToString();
                getLabNumber(ID.ToString());

                ViewState["labno"] = getLabNumber(ID.ToString());
                ViewState["ProdID"] = ddl_Products.SelectedValue;
                createResultDoc(getLabNumber(ID.ToString()), ddl_Products.SelectedValue);
                loadProducts();
                loadProductDetails(ddl_Products.SelectedValue);
                string script = "alert(\"Results Successfully Saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);


                con.Close();



            }
            catch (Exception)
            {

            }

        }
        protected void createResultDoc(string labno, string prodid)
        {
            try
            {
                if (labno != "" & prodid != "")
                {
                    getPatientData(labno, prodid);
                    string LabNumber = o_Result.LabNumber;


                    DocX filnameTemplate = DocX.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/Templates/HIVViralLoadTemplate.docx"));
                    string outputFileName = System.Web.Hosting.HostingEnvironment.MapPath("~/Docs/" + LabNumber + ".docx");
                    string outputFileNamePDF = System.Web.Hosting.HostingEnvironment.MapPath("~/Docs/" + LabNumber + ".pdf");
                    filnameTemplate.ReplaceText("[NAME]", o_Result.FullName);
                    filnameTemplate.ReplaceText("[IDNO]", o_Result.IDNO);
                    filnameTemplate.ReplaceText("[GENDER]", o_Result.Gender);
                    filnameTemplate.ReplaceText("[DOB]", o_Result.DOB);
                    filnameTemplate.ReplaceText("[LABNO]", o_Result.LabNumber);
                    filnameTemplate.ReplaceText("[DATE]", o_Result.DateReceived);
                    filnameTemplate.ReplaceText("[DOC]", o_Result.Doctor);
                    filnameTemplate.ReplaceText("[HOSP]", o_Result.Hospital);
                    filnameTemplate.ReplaceText("[HIVRNA]", o_Result.HIV_RNA);
                    filnameTemplate.ReplaceText("[LOG]", o_Result.LogValue);
                    
                    filnameTemplate.ReplaceText("[USER]", Session["Username"].ToString());
                    filnameTemplate.ReplaceText("[TIME]", o_Result.TimeEntered);
                    filnameTemplate.ReplaceText("[COMM]", o_Result.Comment);
                    generateQrCode(o_Result.FullName, o_Result.IDNO, o_Result.LabNumber, o_Result.LogValue, o_Result.DateReceived);
                    string myImageFullPath = Server.MapPath("~/QRImages/" + o_Result.LabNumber + ".jpg");


                    filnameTemplate.SaveAs(outputFileName);
                    DocumentCore dc = DocumentCore.Load(outputFileName);
                    DocumentPaginator dp = dc.GetPaginator();
                    // Find the text "QRCODE" on the 1st page.
                    SautinSoft.Document.ContentRange cr = dp.Pages[0].Content.Find("QRCODE").LastOrDefault();
                    if (cr != null)
                    {
                        SautinSoft.Document.Drawing.Picture pic = new SautinSoft.Document.Drawing.Picture(dc, myImageFullPath);
                        cr.End.Insert(pic.Content);
                    }
                    dc.Save(outputFileName);

                    dc.Save(outputFileNamePDF);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outputFileName) { UseShellExecute = true });

                }

            }
            catch (Exception)
            {


            }

        }
        private void generateQrCode(string name, string idno, string labno, string testresult, string date)
        {
            try
            {
                var writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE;
                var result = writer.Write("Full Name: " + name + "\n" + "IDNO: " + "\n" + idno + "\n" + " LabNo: " + labno + "--" + " Log Value: " + testresult + " Date: " + date);
                string path = Server.MapPath("~/QRImages/" + labno + ".jpg");
                var barcodeBitmap = new Bitmap(result);

                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                imgQRCode.Visible = true;
                imgQRCode.ImageUrl = "~/QRImages/" + labno + ".jpg";

            }
            catch (Exception)
            {

            }


        }
        public void getPatientData(string labno, string prodid)
        {
            try
            {


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_GetCustomerDataforResults]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LabNumber", labno);
                cmd.Parameters.AddWithValue("@ProductID", prodid);
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    o_Result.FullName = dt.Rows[0]["Full_Name"].ToString();
                    o_Result.IDNO = dt.Rows[0]["IDNO"].ToString();
                    o_Result.LabNumber = dt.Rows[0]["LabNumber"].ToString();
                    o_Result.Gender = dt.Rows[0]["Gender"].ToString();
                    o_Result.DOB = dt.Rows[0]["DOB"].ToString();
                    o_Result.DateReceived = dt.Rows[0]["DateReceived"].ToString();
                    o_Result.TimeEntered = dt.Rows[0]["TimeEntered"].ToString();
                    o_Result.Doctor = dt.Rows[0]["Doctor"].ToString();
                    o_Result.Hospital = dt.Rows[0]["Hospital"].ToString();
                    o_Result.HIV_RNA = dt.Rows[0]["HIV_RNA"].ToString();
                    o_Result.LogValue = dt.Rows[0]["LogValue"].ToString();
                    
                    o_Result.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    o_Result.Comment = dt.Rows[0]["Comment"].ToString();



                }

            }
            catch (Exception)
            {

            }


        }
        private void ClearAll()
        {
            txtlabNo.Text = "";
            //ddl_Products.SelectedIndex = 0;
            txtFullName.Text = "";
            txtDOB.Text = "";
            txtCustomerNo.Text = "";
            ddl_Gender.SelectedIndex = 0;
            txtDoctor.Text = "";
            txtHospital.Text = "";
            txtlabNo.Text = "";
            txtTestCode.Text = "";
            txtHIVRNA.Text = "";
            txtLogValue.Text = "";
           
            ChkIsPaid.Checked = false;
            txtComment.Text = "";
            imgQRCode.ImageUrl = "";
            litQRCode.Text = "";
            if (lstCustomers.Visible == true)
            {
                lstCustomers.DataSource = null;
                lstCustomers.Visible = false;
            }
            loadProducts();
            loadProductDetails(ddl_Products.SelectedValue);

        }
        private string getLabNumber(string scopeid)
        {
            string newlabnumber = "";
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select LabNumber from tbl_TestResults where ID ='" + scopeid + "'", con))
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

        protected void btnReadQR_Click(object sender, EventArgs e)
        {
            ReadQRCode(txtlabNo.Text);

        }
        private void ReadQRCode(string labno)
        {
            try
            {
                var reader = new BarcodeReader();
                string filename = Path.Combine(Request.MapPath("~/QRImages/" + labno + ".jpg"));
                // Detect and decode the barcode inside the bitmap
                var result = reader.Decode(new Bitmap(filename));
                if (result != null)
                {
                    litQRCode.Text = "QR Code: " + result.Text;
                }

            }
            catch (Exception)
            {

            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_EditHIVResults]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LabNumber", txtlabNo.Text);
                cmd.Parameters.AddWithValue("@ProductID", ddl_Products.SelectedValue);

                cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                cmd.Parameters.AddWithValue("@Payment_Status", ChkIsPaid.Checked);
                cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());


                ViewState["LabNumber"] = txtlabNo.Text;


                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }


                cmd.ExecuteNonQuery();


                string script = "alert(\"Results Successfully Updated\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                ClearAll();

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
    }
}