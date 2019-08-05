<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster_OnlyBootstrap.Master" AutoEventWireup="true" CodeBehind="NhapLieu_DNCN.aspx.cs" Inherits="Project_HD.NhapLieu_DNCN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang nhập liệu</title>
    <style>
        .kq {
            min-width: 150px;
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
        <h5 style="line-height: 30px;">Thí nghiệm số:
            <asp:Label ID="lblID_ThiNghiem" CssClass="text-danger text-uppercase" runat="server" Text="Label"></asp:Label><br />
            Loại thí nghiệm:
            <asp:Label ID="lblTenThiNghiem" CssClass="text-danger text-uppercase" runat="server" Text="Label"></asp:Label><br />
            Xuất xứ:
            <asp:Label ID="lblXuatXu" CssClass="text-danger text-uppercase" runat="server" Text="Label"></asp:Label>
        </h5>
        <asp:Repeater ID="rptDNCN" runat="server" OnItemCommand="rptDNCN_ItemCommand">
            <HeaderTemplate>
                <table class="table rptTable">
                    <tr>
                        <th style="vertical-align: middle; text-align: center;" scope="col">STT
                        </th>
                        <th style="vertical-align: middle; text-align: center;" scope="col">Đặc tính
                        </th>
                        <th style="vertical-align: middle; text-align: center;" scope="col">Phương pháp
                        </th>
                        <th class="kq" style="vertical-align: middle; text-align: center;" scope="col">Kết quả
                        </th>
                        <th style="vertical-align: middle; text-align: center;" scope="col">Nhân viên nhập liệu
                        </th>
                        <th style="vertical-align: middle; text-align: center;" scope="col">Chức năng
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblID_DacTinh" Visible="false" runat="server" Text='<%# Eval("ID_DacTinh") %>' />
                        <asp:Label ID="lblChiSo" runat="server" Text='<%# ((System.Data.DataRowView)Container.DataItem)["DT.ChiSo"]  %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblTenDacTinh" runat="server" Text='<%# Eval("Ten") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblTenPhuongPhap" runat="server" Text='<%# Eval("PhuongPhap") %>' />
                    </td>
                    <td>
                        <asp:TextBox class="form-control" ID="txtNoiDung" runat="server" Text='<%# Eval("NoiDung") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblNguoiNhap" runat="server" Text='<%# Eval("NguoiNhap") %>' />
                    </td>
                    <td>
                        <asp:Button class="btn btn-primary" ID="btn_CapNhat" CommandName="CapNhat" runat="server" Text="Cập nhật" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
