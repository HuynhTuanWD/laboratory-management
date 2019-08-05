<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster_OnlyBootstrap.Master" AutoEventWireup="true" CodeBehind="BangPhanQuyen.aspx.cs" Inherits="Project_HD.BangPhanQuyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Bảng Phân Quyền</title>
    <style>
        .chk_TN input {
            transform: scale(1.5,1.5);
        }

        .chkQuyen input {
            transform: scale(1.5,1.5);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <asp:HyperLink CssClass="btn btn-secondary" NavigateUrl="~/TaiKhoan.aspx" ID="hyperQuayLai" runat="server"><i class="fas fa-reply"></i> Quay lại</asp:HyperLink>
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <h4 id="lblTenNV" runat="server" class="card-title alert alert-primary d-flex justify-content-between" style="font-size: 1.5rem"><span class="text-left" id="lblTenNV1" runat="server"></span><span class="text-right" id="lblTenNV2" runat="server"></span></h4>

                        <h5 style="width: 200px" class="alert alert-dark px-3 py-2 mb-0">Chức vụ
                        </h5>
                        <asp:DropDownList Style="width: 200px" ID="ddlVaiTro" CssClass="form-control" runat="server"></asp:DropDownList>
                        <br />
                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="text-center p-1" scope="col">Tạo thí nghiệm</th>
                                    <th class="text-center p-1" scope="col">Sửa thí nghiệm</th>
                                    <th class="text-center p-1" scope="col">Xuất báo cáo</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="text-center p-1">
                                        <asp:CheckBox CssClass="chk_TN" ID="chkTaoThiNghiem" runat="server" /></td>
                                    <td class="text-center p-1">
                                        <asp:CheckBox CssClass="chk_TN" ID="chkSuaThiNghiem" runat="server" /></td>
                                    <td class="text-center p-1">
                                        <asp:CheckBox CssClass="chk_TN" ID="chkXuatBaoCao" runat="server" /></td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                        <asp:Label ID="lblID_NguoiDung" Visible="false" runat="server" Text="Label"></asp:Label>
                        <asp:Repeater ID="rptPhanQuyen" runat="server">
                            <ItemTemplate>
                                <h5 class="alert alert-dark px-3 py-2 mb-0">
                                    <asp:Label ID="lblID_LoaiThiNghiem" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    <asp:Label ID="lblTenLoai" runat="server" Text='<%# Eval("TenLoai") %>'></asp:Label>
                                </h5>
                                <asp:Repeater ID="rptThiNghiem" runat="server">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <tr>
                                                <th style="width: 40px;" class="p-1" scope="col">ID
                                                </th>
                                                <th style="width: 500px;" class="p-1" scope="col">Đặc tính
                                                </th>
                                                <th style="width: 300px;" class="p-1" scope="col">Phương pháp
                                                </th>
                                                <th class="p-1 text-center" scope="col">Chỉnh sửa
                                                </th>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="p-1">
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                                                <asp:Label ID="lblChiSo" runat="server" Text='<%# Eval("ChiSo") %>' />
                                            </td>
                                            <td class="p-1">
                                                <asp:Label ID="lblTen" runat="server" Text='<%# Eval("Ten") %>'></asp:Label>
                                            </td>
                                            <td class="p-1">
                                                <asp:Label ID="lblPhuongPhap" runat="server" Text='<%# Eval("PhuongPhap") %>'></asp:Label>
                                            </td>
                                            <td class="p-1 chkQuyen text-center">
                                                <asp:CheckBox ID="chkQuyen" Checked='<%# Convert.ToBoolean(Eval("Quyen")) %>' runat="server" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="text-center">
                            <asp:Button CssClass="btn btn-primary text-center w-50 p-2 mt-2" ID="btn_CapNhatQuyen" runat="server" Text="Cập nhật" OnClick="btn_CapNhatQuyen_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
