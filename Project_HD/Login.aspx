<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project_HD.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang Đăng Nhập</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Bootstrap core CSS-->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet">
    <link rel="icon"
        type="image/jpg"
        href="vendor/evn_logo.png">
    <style>
        .main {
            background: url(vendor/bg2.jpg) #7f8c8d;
            background-repeat: no-repeat;
            background-size: 100% 100%;
            background-position: center;
        }
        .card-login{
            width:300px;
            left:50%;
            top:50%;
            transform:translate(-50%,-35%);
        }
    </style>
</head>
<body class="main">
    <form id="frm_main" runat="server">
        <div class="">
            <div class="card card-login position-absolute">
                <div class="card-header">
                    Đăng Nhập
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="txtTenTaiKhoan">
                            Tài Khoản</label>
                        <asp:TextBox class="form-control" placeholder="Nhập tên tài khoản" aria-describedby="taikhoanHelp"
                            ID="txtTenTaiKhoan" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtMatKhau">
                            Mật Khẩu</label>
                        <asp:TextBox class="form-control" Type="password" placeholder="Nhập mật khẩu" aria-describedby="matkhauHelp"
                            ID="txtMatKhau" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button class="btn btn-primary btn-block" Text="Đăng nhập" runat="server"
                        ID="btn_DangNhap" OnClick="btn_DangNhapClick" />
                    <br />
                    <div id="ThongBao" runat="server" class="alert alert-danger" style="display: none;">
                        <strong>Sai tài khoản hoặc mật khẩu</strong>
                    </div>
                </div>
            </div>
        </div>
        <!-- Bootstrap core JavaScript-->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    </form>
</body>
</html>
