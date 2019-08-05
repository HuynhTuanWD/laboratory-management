<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuaThiNghiem.aspx.cs" Inherits="Project_HD.SuaThiNghiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang sửa thí nghiệm</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Bootstrap core CSS-->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Page level plugin CSS-->
    <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet">
    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet">
    <link rel="icon"
        type="image/jpg"
        href="vendor/evn_logo.png" />
    <script src="vendor/jquery/jquery.min.js"></script>
    <script>
        function checkDate(value) {
            var check = false;
            var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
            if (re.test(value)) {
                var adata = value.split('/');
                var dd = parseInt(adata[0], 10);
                var mm = parseInt(adata[1], 10);
                var yyyy = parseInt(adata[2], 10);
                var xdata = new Date(yyyy, mm - 1, dd);
                if ((xdata.getFullYear() === yyyy) && (xdata.getMonth() === mm - 1) && (xdata.getDate() === dd)) {
                    check = true;
                }
                else {
                    check = false;
                }
            } else {
                check = false;
            }
            return check;
        }
        $('document').ready(function () {
            $('#txtNgayLayMau').focusout(function () {
                if (!checkDate($('#txtNgayLayMau').val())) {
                    $('#txtNgayLayMau').removeClass("is-valid").addClass("is-invalid");
                    $('#lblValiNLM').css("display", "block");
                }
                else {
                    $('#txtNgayLayMau').removeClass("is-invalid").addClass("is-valid");
                    $('#lblValiNLM').css("display", "none");
                }
            });
            $('#txtNgayNhanMau').focusout(function () {
                if (!checkDate($('#txtNgayNhanMau').val())) {
                    $('#txtNgayNhanMau').removeClass("is-valid").addClass("is-invalid");
                    $('#lblValiNNM').css("display", "block");
                }
                else {
                    $('#txtNgayNhanMau').removeClass("is-invalid").addClass("is-valid");
                    $('#lblValiNNM').css("display", "none");
                }
            });
            $('#txtNgayThuMau').focusout(function () {
                if (!checkDate($('#txtNgayThuMau').val())) {
                    $('#txtNgayThuMau').removeClass("is-valid").addClass("is-invalid");
                    $('#lblValiNIKQ').css("display", "block");
                }
                else {
                    $('#txtNgayThuMau').removeClass("is-invalid").addClass("is-valid");
                    $('#lblValiNIKQ').css("display", "none");
                }
            });


            $('#btnTaoThiNghiem').click(function () {
                var flag = true;
                if (!checkDate($('#txtNgayLayMau').val())) {
                    $('#txtNgayLayMau').removeClass("is-valid").addClass("is-invalid");
                    $('#lblValiNLM').css("display", "block");
                    flag = false;
                }
                else {
                    $('#txtNgayLayMau').removeClass("is-invalid").addClass("is-valid");
                    $('#lblValiNLM').css("display", "none");
                }
                if (!checkDate($('#txtNgayNhanMau').val())) {
                    $('#txtNgayNhanMau').removeClass("is-valid").addClass("is-invalid");
                    $('#lblValiNNM').css("display", "block");
                    flag = false;
                }
                else {
                    $('#txtNgayNhanMau').removeClass("is-invalid").addClass("is-valid");
                    $('#lblValiNNM').css("display", "none");
                }
                if (!checkDate($('#txtNgayThuMau').val())) {
                    $('#txtNgayThuMau').removeClass("is-valid").addClass("is-invalid");
                    $('#lblValiNIKQ').css("display", "block");
                    flag = false;
                }
                else {
                    $('#txtNgayThuMau').removeClass("is-invalid").addClass("is-valid");
                    $('#lblValiNIKQ').css("display", "none");
                }
                return flag;
            });
        });
    </script>
</head>
<body>
    <form id="frm" runat="server">
        <div class="container">
            <asp:HyperLink CssClass="btn btn-secondary" NavigateUrl="~/ThiNghiem.aspx" ID="hyperQuayLai" runat="server"><i class="fa fa-mail-reply"></i> Quay lại</asp:HyperLink>
        </div>
        <div class="container">
            <div class="card card-body">
                <asp:Label CssClass="fa-2x" ID="txtTenThiNghiem" runat="server" Text="Label"></asp:Label>
                <div class="form-group">
                    <label class="badge badge-primary" for="ddlLoaiThiNghiem">
                        Loại thí nghiệm</label>
                    <br />
                    <strong>
                        <asp:Label ID="txtTenLoaiThiNghiem" runat="server"></asp:Label>
                    </strong>
                </div>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="body_txtXuatXu">
                        Xuất xứ</label>
                    <asp:TextBox class="form-control" TextMode="MultiLine" placeholder="Nhập xuất xứ" ID="txtXuatXu" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="form-group">
                            <label class="badge badge-pill badge-success" for="txtNgayLayMau">
                                Ngày lấy mẫu</label>
                            <asp:TextBox class="form-control" ID="txtNgayLayMau" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                            <asp:Label ID="lblValiNLM" Style="display: none;" CssClass="invalid-feedback" Text="Sai định dạng ngày tháng năm" runat="server" />
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="form-group">
                            <label class="badge badge-pill badge-success" for="txtNgayNhanMau">
                                Ngày nhận mẫu</label>
                            <asp:TextBox class="form-control" ID="txtNgayNhanMau" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                            <asp:Label ID="lblValiNNM" Style="display: none;" CssClass="invalid-feedback" Text="Sai định dạng ngày tháng năm" runat="server" />
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="form-group">
                            <label class="badge badge-pill badge-success" for="txtNgayThuMau">
                                Ngày thử mẫu</label>
                            <asp:TextBox class="form-control" ID="txtNgayThuMau" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                            <asp:Label ID="lblValiNIKQ" Style="display: none;" CssClass="invalid-feedback" Text="Sai định dạng ngày tháng năm" runat="server" />
                        </div>
                    </div>
                </div>
                <!-- row -->
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtLyDoThiNghiem">
                        Lý do thí nghiệm</label>
                    <asp:TextBox class="form-control" placeholder="Nhập lý do thí nghiệm" ID="txtLyDoThiNghiem" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtPhuTrachLayMau">
                        Phụ trách lấy mẫu
                    </label>
                    <asp:TextBox class="form-control" placeholder="Nhập phụ trách lấy mẫu" ID="txtPhuTrachLayMau" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtGhiChu">
                        Ghi chú</label>
                    <asp:TextBox class="form-control" placeholder="Nhập ghi chú" ID="txtGhiChu" runat="server"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button class="btn btn-primary w-50" ID="btnSuaThiNghiem" runat="server" Text="Cập Nhật" OnClick="btnSuaThiNghiem_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
<!-- Bootstrap core JavaScript-->
<script src="vendor/jquery/jquery.min.js"></script>
<script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- Core plugin JavaScript-->
<script src="vendor/jquery-easing/jquery.easing.min.js"></script>
<!-- Page level plugin JavaScript-->
<script src="vendor/datatables/jquery.dataTables.js"></script>
<script src="vendor/datatables/dataTables.bootstrap4.js"></script>
<!-- Custom scripts for all pages-->
<script src="js/sb-admin.min.js"></script>
<!-- Custom scripts for this page-->
<script src="js/sb-admin-datatables.min.js"></script>
</html>
