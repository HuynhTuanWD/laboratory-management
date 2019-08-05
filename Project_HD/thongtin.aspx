<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="thongtin.aspx.cs" Inherits="Project_HD.thongtin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thông tin cá nhân</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="card card-body">
                <h4>Thông tin cá nhân</h4>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtTenHienThi">
                        Tên hiển thị</label>
                    <asp:TextBox class="form-control" ID="txtTenHienThi" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtSDT">
                        Số điện thoại</label>
                    <asp:TextBox class="form-control" ID="txtSDT" runat="server"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button class="btn btn-primary px-5" ID="btn_CapNhat" runat="server" Text="Cập Nhật" OnClick="btn_CapNhat_Click" />
                </div>
                <div id="ThongBaoTenHienThi" runat="server" class="alert alert-primary" style="display:none;">
                        <strong>Đổi tên hiển thị thành công</strong>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-6">
            <div class="card card-body">
                <h4>Đổi mật khẩu</h4>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtMatKhauCu">
                        Mật khẩu cũ</label>
                    <asp:TextBox class="form-control" placeholder="Nhập mật khẩu cũ" type="password" ID="txtMatKhauCu" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtMatKhauMoi1">
                        Mật khẩu mới</label>
                    <asp:TextBox class="form-control" placeholder="Nhập mật khẩu mới" type="password" ID="txtMatKhauMoi1" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtMatKhauMoi2">
                        Xác nhận mật khẩu mới</label>
                    <asp:TextBox class="form-control" placeholder="Nhập lại mật khẩu mới" type="password" ID="txtMatKhauMoi2" runat="server"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button class="btn btn-primary px-5" ID="btn_CapNhatMatKhau" runat="server" Text="Cập Nhật" OnClick="btn_CapNhatMatKhau_Click" />
                </div>
                <br />
                <div id="ThongBaoMK1" runat="server" class="alert alert-primary" style="display:none;">
                        <strong>Đổi mật khẩu thành công</strong>
                </div>
                <div id="ThongBaoMK2" runat="server" class="alert alert-danger" style="display:none;">
                        <strong>Mật khẩu không khớp</strong>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
