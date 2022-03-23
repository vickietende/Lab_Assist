<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lab_Assist.Login" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>GENOMIX MEDICAL CENTRE LAB-LMS</title>
  <!-- plugins:css -->
  <link rel="stylesheet" href="../assets/vendor/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="../assets/vendor/base/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../assets/style.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="../../assets/img/logo1.png" />
</head>

<body>
  <div class="container-scroller">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-center auth px-0">
        <div class="row w-100 mx-0">
          <div class="col-lg-4 mx-auto">
            <div class="auth-form-light text-left py-5 px-4 px-sm-5">
              <div class="brand-logo">
                <img src="../../assets/img/logo1.png" alt="logo">
              </div>
              <h4>GENOMIX MEDICAL CENTRE LAB-LMS</h4>
              <h6 class="font-weight-light">Sign in to continue.</h6>
              <form runat="server" class="pt-3">
                <div class="form-group">
                  <input type="text" class="form-control  form-control-lg" runat="server"  id="txtUserName" placeholder="Username">
                </div>
                <div class="form-group">
                  <input type="password" class="form-control form-control-lg" runat="server" id="txtpwd" placeholder="Password">
                </div>
                <div class="mt-3">
                 <asp:Button ID="btnLogin" CssClass="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" runat="server" Text="Login" OnClick="btnLogin_Click"/>
                      <asp:Label ID="InvalidCredentials" runat="server" Text="Invalid user credentials, Please try again!" Visible="false" ForeColor="Red" ></asp:Label>
                </div>
                <div class="my-2 d-flex justify-content-between align-items-center">
        
                  <a href="#" class="auth-link text-black">Forgot password?</a>
                </div>
            
              </form>
            </div>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->
  <!-- plugins:js -->
  <script src="../../assets/vendor/base/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- inject:js -->
  <script src="../../assets/js/off-canvas.js"></script>
  <script src="../../assets/js/hoverable-collapse.js"></script>
  <script src="../../assets/js/template.js"></script>
  <!-- endinject -->
</body>

</html>
