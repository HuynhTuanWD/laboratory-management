<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="ThiNghiem.aspx.cs" Inherits="Project_HD.ThiNghiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang Thí Nghiệm</title>
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
        /* button search */

        .my-pagination {
            position: relative;
            height: 100px;
            width: 40%;
            margin: auto;
            min-width: 300px;
        }

        .my-previous {
            position: absolute;
            top: 50%;
            transform: translateY(-50%);
            left: 0;
        }

        .my-page {
            position: absolute;
            left: 50%;
            transform: translateX(-50%);
            top: 25%;
            font-weight: bold;
        }

        .my-numbPage {
            position: absolute;
            width: 20%;
            top: 50%;
            left: 50%;
            transform: translateX(-50%);
            text-align: center;
        }

        .my-next {
            position: absolute;
            top: 50%;
            transform: translateY(-50%);
            right: 0;
        }

        @media only screen and (max-width: 600px) {
            .my-pagination {
                width: 100%;
            }
        }
        /* button pagination */



        @media only screen and (max-width: 800px) {
            .rptTable td, .rptTable th {
                padding: 0;
            }
        }
    </style>
    <script type="text/javascript">
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
            $('.search-input').keypress(function (e) {
                if (e.which == 13) {//Enter key pressed
                    $('.noneClick').click(function () { return false; });
                    $('.search-button').click();//Trigger search button click event
                }
            });
            $('.search-button').click(function () {
                if (($('.search-input').val() == "") || ($('.search-input').val() == null)) {
                    alert("Khung tìm kiếm không được để trống");
                    return false;
                }
            });
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
        <button class="btn btn-primary font-weight-bold" type="button" data-toggle="collapse" data-target="#collapse_TaoThiNghiem"
            aria-expanded="false" aria-controls="collapse_TaoThiNghiem">
            Tạo Thí Nghiệm
        </button>
        <div class="collapse" id="collapse_TaoThiNghiem">
            <div class="card card-body">
                <div class="form-group">
                    <label class="badge badge-primary" for="ddlLoaiThiNghiem">
                        Chọn loại thí nghiệm</label>
                    <asp:DropDownList ID="ddlLoaiThiNghiem" class="custom-select" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="badge badge-pill badge-success" for="txtXuatXu">
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
                                Ngày in kết quả</label>
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
                    <asp:Button Style="width: 30%;" class="btn btn-primary px-5 noneClick" ID="btnTaoThiNghiem" runat="server" Text="Tạo" OnClick="btnTaoThiNghiem_Click" />
                </div>
            </div>
        </div>
    </div>
    <br />
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
                        <asp:Label ID="lblID" runat="server" Text='<%# ((System.Data.DataRowView)Container.DataItem)["sub1.ID"] %>' />
                        <asp:Panel Visible="false" ID="mazic" runat="server">
                            <asp:Label ID="mazic_lblID" runat="server" Text='<%# ((System.Data.DataRowView)Container.DataItem)["sub1.ID"] %>' />
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
                        <asp:HyperLink CssClass="btn btn-outline-primary font-weight-bold fa" ID="hyperNhapLieu" runat="server" NavigateUrl='<%# "~/NhapLieu.aspx?ID=" + ((System.Data.DataRowView)Container.DataItem)["sub1.ID"] %>' Target="_blank"></asp:HyperLink>
                        <asp:Button CssClass="btn btn-outline-warning font-weight-bold fa" ID="btn_Sua" CommandName="btn_Sua" runat="server" Text="" />
                        <asp:Button CssClass="" ID="btn_Khoa" CommandName="btn_Khoa" runat="server" Text="Khóa sửa" />
                        <asp:HyperLink ID="hyperXuatBaoCao" runat="server" class="btn btn-outline-primary font-weight-bold fa hyperXuatBaoCao" href='<%# (Eval("ID_LoaiThiNghiem").ToString() == "1" ? "Report.aspx" : "Report.aspx") +"?ID=" + ((System.Data.DataRowView)Container.DataItem)["sub1.ID"] %>' Target="_blank"></asp:HyperLink>
                        <asp:Button Style="display: none;" CommandName="btn_XuatBaoCao" CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["sub1.ID"] %>' CssClass="btn btn-outline-primary font-weight-bold fa" ID="btnXuatBaoCao" runat="server" Text="" />
                        <!-- Button trigger modal -->
                        <asp:Button class="btn btn-outline-danger font-weight-bold fa" ID="btn_XoaContent" UseSubmitBehavior="false" OnClientClick="return" runat="server" Text="" data-toggle="modal" data-target='<%# "#XoaThiNghiem" + ((System.Data.DataRowView)Container.DataItem)["sub1.ID"] %>' />
                        <asp:Button ID="btnCopy" CommandName="btn_Copy" CssClass="btn btn-outline-primary fa" runat="server" Text="" />
                        
                        <asp:Label ID="Label2" CssClass="BaoCao" Style="display: none;" runat="server" Text='<%# Eval("BaoCao") %>'></asp:Label>
                        <i class="fa text-danger mx-3" style="font-size: 18px; display:none;" data-toggle="tooltip" data-placement="top" title="Chưa xuất báo cáo"></i>
                        <!-- Modal -->
                        <div class="modal fade" id='<%# "XoaThiNghiem" + ((System.Data.DataRowView)Container.DataItem)["sub1.ID"] %>' tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
        <div class="my-pagination">
            <asp:Button ID="btn_previous" CssClass="btn btn-primary my-previous" runat="server" Text="Previous" OnClick="btn_previous_Click" />
            <asp:Label ID="Label1" CssClass="my-page" runat="server" Text="Trang " />
            <asp:Label ID="lblSoTrang" CssClass="my-numbPage" runat="server" Text="" />
            <asp:Button ID="btn_next" CssClass="btn btn-primary my-next" runat="server" Text="Next" OnClick="btn_next_Click" />
        </div>
    </div>
    <asp:Label ID="test" runat="server"></asp:Label>
</asp:Content>

