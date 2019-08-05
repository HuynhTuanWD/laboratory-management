<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster_OnlyBootstrap.Master" AutoEventWireup="true" CodeBehind="NhapLieu.aspx.cs" Inherits="Project_HD.NhapLieu_DCD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang nhập liệu</title>
    <style>
        .kq {
            min-width: 250px;
        }

        @media only screen and (max-width: 800px) {
            .rptTable td, .rptTable th {
                padding: 0;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="px-md-5">
        <asp:Label ID="lblSoCot" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblIDThiNghiem" runat="server" Visible="false" Text=""></asp:Label>
        <h5 style="line-height: 30px;">Thí nghiệm số:
            <asp:Label ID="lblID_ThiNghiem" CssClass="text-danger text-uppercase" runat="server" Text="Label"></asp:Label><br />
            Loại thí nghiệm:
            <asp:Label ID="lblTenThiNghiem" CssClass="text-danger text-uppercase" runat="server" Text="Label"></asp:Label><br />
            Xuất xứ:
            <asp:Label ID="lblXuatXu" CssClass="text-danger text-uppercase" runat="server" Text="Label"></asp:Label>
        </h5>

        <table class="table rptTable">
            <tr>
                <th rowspan="2" style="vertical-align: middle; text-align: center;" scope="col">STT
                </th>
                <th rowspan="2" style="vertical-align: middle; text-align: center;" scope="col">Đặc tính
                </th>
                <th rowspan="2" style="vertical-align: middle; text-align: center;" scope="col">Phương pháp
                </th>
                <th class="kq" colspan='<%= lblSoCot.Text %>' style="vertical-align: middle; text-align: center;" scope="col">Kết quả
                </th>
                <th rowspan="2" style="vertical-align: middle; text-align: center;" scope="col">Nhân viên nhập liệu
                </th>
            </tr>
            <tr>
                <asp:Repeater ID="rptCot" runat="server">
                    <ItemTemplate>
                        <th style="vertical-align: middle; text-align: center;" scope="col">
                            <asp:Label ID="lblTenCot" runat="server" Text='<%# Eval("TenCot") %>'></asp:Label>
                        </th>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
            <asp:Repeater ID="rptThiNghiem" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblID_DacTinh" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                            <asp:Label ID="lblChiSo" runat="server" Text='<%# ((System.Data.DataRowView)Container.DataItem)["DT.ChiSo"]  %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblTenDacTinh" runat="server" Text='<%# Eval("Ten") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblTenPhuongPhap" runat="server" Text='<%# Eval("PhuongPhap") %>' />
                        </td>
                        <td id="Cot1" runat="server" visible='<%# 1<=Convert.ToInt32(lblSoCot.Text) %>'>
                            <asp:TextBox class="form-control" ID="txtCot1" runat="server" Text='<%# Eval("Cot1") %>'></asp:TextBox>
                        </td>
                        <td id="Cot2" runat="server" visible='<%# 2<=Convert.ToInt32(lblSoCot.Text) %>'>
                            <asp:TextBox class="form-control" ID="txtCot2" runat="server" Text='<%# Eval("Cot2") %>'></asp:TextBox>
                        </td>
                        <td id="Cot3" runat="server" visible='<%# 3<=Convert.ToInt32(lblSoCot.Text) %>'>
                            <asp:TextBox class="form-control" ID="txtCot3" runat="server" Text='<%# Eval("Cot3") %>'></asp:TextBox>
                        </td>
                        <td id="Cot4" runat="server" visible='<%# 4<=Convert.ToInt32(lblSoCot.Text) %>'>
                            <asp:TextBox class="form-control" ID="txtCot4" runat="server" Text='<%# Eval("Cot4") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblNguoiNhap" runat="server" Text='<%# Eval("NguoiNhap") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <h5 class="text-center"><asp:Label ID="lblPhanCong" Visible="false" CssClass="text-info" runat="server" Text="Chưa được phân công thí nghiệm này<br/>Vui lòng liên hệ người quản trị"></asp:Label></h5>
        <div class="text-center">
            <asp:Button ID="btnCapNhat" runat="server" CssClass="btn btn-primary w-50 mb-3" Text="Cập nhật" OnClick="btnCapNhat_Click" />
        </div>
    </div>
    <asp:Label ID="test" runat="server" Text=""></asp:Label>
</asp:Content>
