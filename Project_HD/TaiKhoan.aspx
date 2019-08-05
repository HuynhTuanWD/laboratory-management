<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="TaiKhoan.aspx.cs" Inherits="Project_HD.TaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản trị tài khoản</title>
    <style type="text/css">
        @media only screen and (max-width: 800px) {
            .rptTable td, .rptTable th {
                padding: 0;
            }
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.modalXoa').click(function () {
                var id = $(this).next().text();
                $('#txtID_NguoiDung').val(id);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="px-md-5">
        <h5 class="alert alert-info mb-0">Danh sách tài khoản</h5>
        <div id="DanhSachNguoiDung">
            <asp:Repeater ID="rptDanhSachNguoiDung" runat="server" OnItemDataBound="rptDanhSachNguoiDung_ItemDataBound">
                <HeaderTemplate>
                    <table class="table rptTable">
                        <tr>
                            <th scope="col">Tài khoản
                            </th>
                            <th scope="col">Tên hiển thị
                            </th>
                            <th scope="col">Số điện thoại
                            </th>
                            <th style="min-width: 90px;" scope="col">Chức vụ
                            </th>
                            <th class="text-center" scope="col">Chức năng
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label Style="display: none;" ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                            <asp:Label ID="lblTaiKhoan" runat="server" Text='<%# Eval("TaiKhoan") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblTenHienThi" runat="server" Text='<%# Eval("TenHienThi") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSDT" runat="server" Text='<%# Eval("SDT") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblVaiTro" runat="server" Text='<%# Eval("VaiTro").ToString()=="1"?"Admin":"Nhân Viên" %>'></asp:Label>
                        </td>
                        <td class="text-center">
                            <a class="" href='<%# "BangPhanQuyen.aspx?ID=" + Eval("ID") %>'><i class="fas fa-user-cog btn btn-primary"></i></a>
                            <!-- Button trigger modal -->
                            <button type="button" class="btn btn-danger modalXoa" data-toggle="modal" data-target="#modalXoa">
                                <i class="fas fa-trash-alt"></i>
                            </button>
                            <asp:Label Style="display: none;" Enabled="false" ID="lbl_ID" runat="server" Text='<%# Eval("ID") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <!-- Modal -->
            <div class="modal fade" id="modalXoa" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">Bạn muốn xóa người dùng này ?</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <asp:TextBox ID="txtID_NguoiDung" Style="display: none" runat="server"></asp:TextBox>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Hủy</button>
                            <asp:Button class="btn btn-primary" ID="btnXoa" runat="server" AutoPostBack="true" CommandArgument='<%# Eval("ID") %>' Text="Đồng ý" OnClick="btnXoa_Click1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="px-md-5">
        <h5 class="alert alert-info mb-0">Tạo tài khoản</h5>
        <div class="card card-body">
            <div class="form-group">
                <label class="badge badge-pill badge-primary" for="txtTaiKhoan">
                    Tài khoản</label>
                <asp:TextBox class="form-control" placeholder="Nhập tài khoản" ID="txtTaiKhoan" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="badge badge-pill badge-primary" for="txtMatKhau">
                    Mật khẩu</label>
                <asp:TextBox class="form-control" placeholder="Nhập mật khẩu" ID="txtMatKhau" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="badge badge-pill badge-primary" for="txtTenHienThi">
                    Tên hiển thị</label>
                <asp:TextBox class="form-control" placeholder="Nhập tên hiển thị" ID="txtTenHienThi" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="badge badge-pill badge-primary" for="txtSDT">
                    Số điện thoại
                </label>
                <asp:TextBox class="form-control" placeholder="Nhập số điện thoại" ID="txtSDT" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="badge badge-pill badge-primary" for="ddlVaiTro">
                    Vai trò</label>
                <asp:DropDownList class="custom-select" ID="ddlVaiTro" runat="server"></asp:DropDownList>
            </div>
            <div class="text-center">
                <asp:Button Style="width: 30%;" class="btn btn-primary px-5" ID="btnTaoTaiKhoan" runat="server" Text="Tạo" OnClick="btnTaoTaiKhoan_Click" />
            </div>
        </div>
    </div>
    <br />
</asp:Content>
