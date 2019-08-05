<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Project_HD.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ</title>
    <style type="text/css">
        .search-form {
            display: inline-block;
        }

        .search-input {
            display: inline-block;
            box-sizing: border-box;
            border-radius: 5px 0 0 5px;
            border: solid 1px #b2bec3;
            line-height: 35px;
            width: 330px;
            padding-left: 10px;
        }

        .search-button {
            display: inline-block;
            box-sizing: border-box;
            border-radius: 0 5px 5px 0;
            border: solid 1px #b2bec3;
            line-height: 35px;
            background: url("vendor/search.svg") no-repeat 9%;
            padding-left: 30px;
            background-size: 17px 17px;
            margin-left: -5px;
            background-color: #ecf0f1;
            width: 110px;
            font-weight: bold;
            cursor: pointer;
        }
    </style>
    <script>
        $('document').ready(function () {
            $('#btnSearch').click(function () {
                if ($('#txtSearch').val() == "" || $('#txtSearch').val() == null) {
                    alert("Khung tìm kiếm không được để trống!");
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <label class="alert alert-primary mb-0 font-weight-bold">
            Tìm kiếm thí nghiệm
        </label>

        <!-- button search -->
        <div class="search-form">
            <asp:TextBox CssClass="search-input" ID="txtSearch" runat="server" placeholder="Tìm theo xuất xứ, nhập tên hoặc số serial"></asp:TextBox>
            <asp:Button CssClass="search-button" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
        </div>
        <!-- button search -->
        <br />
        <br />
        <h4>Nhân viên</h4>
        <div class="row">
            <div class="col-xl-4 col-sm-6 mb-3">
                <div class="card text-white bg-primary o-hidden">
                    <div class="card-body">
                        <div class="card-body-icon">
                            <i class="fa"></i>
                        </div>
                        <div class="">Thông tin cá nhân</div>
                    </div>
                    <a class="card-footer text-white clearfix small z-1" href="thongtin.aspx">
                        <span class="float-left">Xem chi tiết ...</span>
                        <span class="float-right">
                            <i class="fa fa-angle-right"></i>
                        </span>
                    </a>
                </div>
            </div>
            <div class="col-xl-4 col-sm-6 mb-3">
                <div class="card text-white bg-success o-hidden">
                    <div class="card-body">
                        <div class="card-body-icon">
                            <i class="fa fa-fw fa-list"></i>
                        </div>
                        <div class="">Nhập liệu thí nghiệm</div>
                    </div>
                    <a class="card-footer text-white clearfix small z-1" href="ThiNghiem.aspx">
                        <span class="float-left">Xem chi tiết ...</span>
                        <span class="float-right">
                            <i class="fa fa-angle-right"></i>
                        </span>
                    </a>
                </div>
            </div>
        </div>
        <h4>Quản trị</h4>
        <div class="row">
            <div class="col-xl-4 col-sm-6 mb-3">
                <div class="card text-white bg-dark o-hidden">
                    <div class="card-body">
                        <div class="card-body-icon">
                            <i class="fa"></i>
                        </div>
                        <div class="">Cài đặt loại thí nghiệm</div>
                    </div>
                    <a class="card-footer text-white clearfix small z-1" href="LoaiThiNghiem.aspx">
                        <span class="float-left">Xem chi tiết ...</span>
                        <span class="float-right">
                            <i class="fa fa-angle-right"></i>
                        </span>
                    </a>
                </div>
            </div>
             <div class="col-xl-4 col-sm-6 mb-3">
                <div class="card text-white bg-dark o-hidden">
                    <div class="card-body">
                        <div class="card-body-icon">
                            <i class="fa"></i>
                        </div>
                        <div class="">Cài đặt đặc tính</div>
                    </div>
                    <a class="card-footer text-white clearfix small z-1" href="LoaiThiNghiem.aspx">
                        <span class="float-left">Xem chi tiết ...</span>
                        <span class="float-right">
                            <i class="fa fa-angle-right"></i>
                        </span>
                    </a>
                </div>
            </div>
            <div class="col-xl-4 col-sm-6 mb-3">
                <div class="card text-white bg-danger o-hidden">
                    <div class="card-body">
                        <div class="card-body-icon">
                            <i class="fa"></i>
                        </div>
                        <div class="">Quản lý tài khoản</div>
                    </div>
                    <a class="card-footer text-white clearfix small z-1" href="TaiKhoan.aspx">
                        <span class="float-left">Xem chi tiết ...</span>
                        <span class="float-right">
                            <i class="fa fa-angle-right"></i>
                        </span>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div>
</div>
</asp:Content>
