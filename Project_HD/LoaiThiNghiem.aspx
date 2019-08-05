<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="LoaiThiNghiem.aspx.cs" Inherits="Project_HD.LoaiThiNghiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cài đặt loại thí nghiệm</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="px-md-5">
        <asp:Repeater ID="rptLoaiThiNghiem" runat="server" OnItemDataBound="rptLoaiThiNghiem_ItemDataBound" OnItemCommand="rptLoaiThiNghiem_ItemCommand">
            <ItemTemplate>
                <div class="row alert alert-primary my-0">
                    <div class="col-2 text-center align-self-center">
                        <asp:Label ID="lblID_LoaiThiNghiem" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        <%# Container.ItemIndex+1 %>
                    </div>
                    <div class="col-5">
                        <asp:TextBox ID="txtTenLoaiThiNghiem" CssClass="form-control" runat="server" Text='<%# Eval("TenLoai") %>'></asp:TextBox>
                    </div>
                    <div class="col-5">
                        <asp:Button ID="btn_CapNhat" CommandName="btn_CapNhatLoaiThiNghiem" CssClass="btn btn-primary fa" runat="server" Text="" />
                        <!-- Button trigger modal -->
                        <asp:HyperLink ID="hyperXoaLoaiThiNghiem" CssClass="btn btn-danger fa text-white" role="button" aria-pressed="true" data-toggle="modal" data-target='<%# "#xoaLoai"+Eval("ID") %>' runat="server"></asp:HyperLink>
                        <!-- Modal -->
                        <div class="modal fade" id='<%# "xoaLoai"+Eval("ID") %>' tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLongTitle">Bạn chắc chắn muốn xóa loại thí nghiệm này ?</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Hủy</button>
                                        <asp:Button ID="btn_Xoa" CommandName="btn_XoaLoaiThiNghiem" CssClass="btn btn-primary" runat="server" Text="Đồng ý" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Repeater ID="rptCotThiNghiem" OnItemCommand="rptCotThiNghiem_ItemCommand" runat="server">
                    <ItemTemplate>
                        <div class="mx-3 row alert alert-secondary mb-0">
                            <div class="col-2 text-center align-self-center">
                                <asp:Label ID="lblID_LoaiThiNghiem" Visible="false" runat="server" Text='<%# Eval("ID_LoaiThiNghiem") %>'></asp:Label>
                                <asp:Label ID="lblCot" runat="server" Text='<%# Eval("Cot") %>'></asp:Label>
                            </div>
                            <div class="col-5">
                                <asp:TextBox ID="txtTenCot" CssClass="form-control" runat="server" Text='<%# Eval("TenCot") %>'></asp:TextBox>
                            </div>
                            <div class="col-5">
                                <asp:Button ID="btn_CapNhatCot" CommandName="btn_CapNhatCot" CssClass="btn btn-primary fa" runat="server" Text="" />
                                <asp:Button ID="btn_XoaCot" Visible="false" CommandName="btn_XoaCot" CssClass="btn btn-danger fa" runat="server" Text="" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="mx-3 row alert alert-secondary mb-0">
                    <div class="col">
                        <asp:Button ID="btn_ThemCot" CommandName="btn_ThemCot" CssClass="btn btn-primary fa" runat="server" Text="" data-toggle="tooltip" data-placement="top" title="Thêm cột" />
                    </div>
                </div>
                <br />
            </ItemTemplate>
        </asp:Repeater>
        <div class="row alert alert-primary my-0">
            <asp:Button ID="btn_ThemLoaiThiNghiem" CssClass="btn btn-primary fa" runat="server" Text="" OnClick="btn_ThemLoaiThiNghiem_Click" data-toggle="tooltip" data-placement="top" title="Thêm loại thí nghiệm" />
        </div>
        <asp:Label ID="test" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
