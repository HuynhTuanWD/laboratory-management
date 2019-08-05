<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="SearchThiNghiem.aspx.cs" Inherits="Project_HD.SearchThiNghiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang tìm kiếm</title>
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
    <script type="text/javascript">
        $('document').ready(function () {
            $('#btnSearch').click(function () {
                if ($('#txtSearch').val() == "" || $('#txtSearch').val() == null) {
                    alert("Khung tìm kiếm không được để trống!");
                    return false;
                }
            });
            $('.copy').each(function () {
                if ($(this).text() == "1") {
                    $(this).parent().parent().css("background-color", "#ecf0f1");
                    $(this).parent().parent().next().css("background-color", "#ecf0f1");
                }
            });
            $('.hyperXuatBaoCao').click(function () {
                $(this).next().click();
            });
            $('.BaoCao').each(function () {
                if ($(this).text() == "0") {
                    $(this).next().css({ "display": "inline-block" });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="px-md-5">
        <label class="alert alert-primary mb-0 font-weight-bold">
            Danh Sách Thí Nghiệm
        </label>

        <!-- button search -->
        <div class="search-form">
            <asp:TextBox CssClass="search-input" ID="txtSearch" runat="server" placeholder="Tìm theo xuất xứ, nhập tên hoặc số serial"></asp:TextBox>
            <asp:Button CssClass="search-button" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
        </div>
        <!-- button search -->
        <asp:Repeater ID="rptThiNghiem" runat="server" OnItemCommand="rptThiNghiem_ItemCommand" OnItemDataBound="rptThiNghiem_ItemDataBound">
            <HeaderTemplate>

                <table class="table rptTable">
                    <tr style="background-color: #bdc3c7;">
                        <th scope="col">ID
                        </th>
                        <th scope="col">Loại thí nghiệm
                        </th>
                        <th scope="col">Xuất xứ
                        </th>
                        <th scope="col">Ngày tạo
                        </th>
                        <th scope="col">Người tạo
                        </th>
                        <th scope="col">Sửa cuối
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblCopy" CssClass="copy" Style="display: none;" runat="server" Text='<%# Eval("Copy") %>'></asp:Label>
                        <asp:Label ID="lblID" runat="server" Text='<%# ((System.Data.DataRowView)Container.DataItem)["TN.ID"] %>' />
                        <asp:Panel Visible="false" ID="mazic" runat="server">
                            <asp:Label ID="mazic_lblID" runat="server" Text='<%# ((System.Data.DataRowView)Container.DataItem)["TN.ID"] %>' />
                            <asp:Label ID="mazic_lblLoaiThiNghiem" runat="server" Text='<%# Eval("ID_LoaiThiNghiem") %>' />
                            <asp:Label ID="mazic_lblQuyenSua" runat="server" Text='<%# Eval("QuyenSua") %>' />
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Label ID="lblTenLoaiThiNghiem" runat="server" Text='<%# Eval("TenLoai") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblXuatXu" runat="server" Text='<%# Eval("XuatXu") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblNgayTao" runat="server" Text='<%# Eval("Created_at") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblNguoiTao" runat="server" Text='<%# Eval("Created_by") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblSuaCuoi" runat="server" Text='<%# Eval("Updated_by") %>' />
                    </td>

                </tr>
                <tr>
                    <td class="pt-0" colspan="6" style="border: none;">
                        <asp:HyperLink CssClass="btn btn-outline-primary font-weight-bold fa" ID="hyperNhapLieu" runat="server" NavigateUrl='<%# "~/NhapLieu.aspx?ID=" + ((System.Data.DataRowView)Container.DataItem)["TN.ID"] %>' Target="_blank"></asp:HyperLink>
                        <asp:Button CssClass="btn btn-outline-warning font-weight-bold fa" ID="btn_Sua" CommandName="btn_Sua" runat="server" Text="" />
                        <asp:Button CssClass="" ID="btn_Khoa" CommandName="btn_Khoa" runat="server" Text="Khóa sửa" />
                        <asp:HyperLink ID="hyperXuatBaoCao" runat="server" class="btn btn-outline-primary font-weight-bold fa hyperXuatBaoCao" href='<%# (Eval("ID_LoaiThiNghiem").ToString() == "1" ? "Report.aspx" : "Report.aspx") +"?ID=" + ((System.Data.DataRowView)Container.DataItem)["TN.ID"] %>' Target="_blank"></asp:HyperLink>
                        <asp:Button Style="display: none;" CommandName="btn_XuatBaoCao" CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["TN.ID"] %>' CssClass="btn btn-outline-primary font-weight-bold fa" ID="btnXuatBaoCao" runat="server" Text="" />
                        <!-- Button trigger modal -->
                        <asp:Button class="btn btn-outline-danger font-weight-bold fa" ID="btn_XoaContent" UseSubmitBehavior="false" OnClientClick="return" runat="server" Text="" data-toggle="modal" data-target='<%# "#XoaThiNghiem" + ((System.Data.DataRowView)Container.DataItem)["TN.ID"] %>' />
                        <asp:Button ID="btnCopy" CommandName="btn_Copy" CssClass="btn btn-outline-primary fa" runat="server" Text="" />

                        <asp:Label ID="Label2" CssClass="BaoCao" Style="display: none;" runat="server" Text='<%# Eval("BaoCao") %>'></asp:Label>
                        <i class="fa text-danger mx-3" style="font-size: 18px; display: none;" data-toggle="tooltip" data-placement="top" title="Chưa xuất báo cáo"></i>
                        <!-- Modal -->
                        <div class="modal fade" id='<%# "XoaThiNghiem" + ((System.Data.DataRowView)Container.DataItem)["TN.ID"] %>' tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Xác nhận</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        Bạn có muốn xóa thí nghiệm ?
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Hủy</button>
                                        <asp:Button CssClass="btn btn-danger" ID="btn_Xoa" CommandName="btn_Xoa" runat="server" Text="Xóa" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
