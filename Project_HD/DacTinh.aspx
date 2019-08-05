<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="DacTinh.aspx.cs" Inherits="Project_HD.DacTinh" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cài đặt đặc tính</title>
    <script type="text/javascript" src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.modalclick').click(function (event) {
                /* Act on the event */
                var id = $(this).next();
                var dactinh = id.next();
                var phuongphap = dactinh.next();
                $('#txtIDDacTinh').val(id.text());
                CKEDITOR.instances['CKEditorTenDacTinh'].setData(dactinh.html());
                CKEDITOR.instances['CKEditorTenPhuongPhap'].setData(phuongphap.html());
            });;
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:DropDownList ID="ddlLoaiThiNghiem" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLoaiThiNghiem_SelectedIndexChanged"></asp:DropDownList>
    <asp:Repeater ID="rptDacTinh" runat="server" OnItemCommand="rptDacTinh_ItemCommand">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th scope="col">ID
                    </th>
                    <th scope="col">Tên đặc tính
                    </th>
                    <th scope="col">Phương pháp
                    </th>
                    <th scope="col">Chức năng
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("ChiSo") %>
                    <asp:Label Style="display: none;" ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                </td>
                <td>
                    <asp:Label ID="lblTen" runat="server" Text='<%# Eval("Ten") %>' />
                </td>
                <td>
                    <asp:Label ID="lblPhuongPhap" runat="server" Text='<%# Eval("PhuongPhap") %>' />
                </td>
                <td>
                    <!--Modal CapNhat-->
                    <asp:HyperLink ID="hyperCapNhat" CssClass="btn btn-primary fa text-white modalclick" role="button" aria-pressed="true" data-toggle="modal" data-target="#CapNhat" runat="server"></asp:HyperLink>
                    <asp:Label Style="display: none;" ID="abc" runat="server" Text='<%# Eval("ID") %>' />
                    <asp:Label Style="display: none;" ID="def" runat="server" Text='<%# Eval("Ten") %>' />
                    <asp:Label Style="display: none;" ID="ghi" runat="server" Text='<%# Eval("PhuongPhap") %>' />
                    <!-- End Modal Xoa -->
                    <!--Modal Xoa-->
                    <asp:HyperLink ID="hyperXoa" CssClass="btn btn-danger text-white fa" role="button" aria-pressed="true" data-toggle="modal" data-target='<%# "#Xoa"+Eval("ID") %>' runat="server" Visible="false"></asp:HyperLink>
                    <div class="modal fade" id='<%# "Xoa"+Eval("ID") %>' tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLongTitle">Bạn chắc chắn muốn xóa ?</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Hủy</button>
                                    <asp:Button ID="btn_Xoa" CommandName="btn_Xoa" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-primary" runat="server" Text="Đồng ý" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- End Modal Xoa -->
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="modal fade" id="CapNhat" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Chỉnh sửa đặc tính</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="txtIDDacTinh" style="display:none;" runat="server" Text=""></asp:TextBox>
                    <div class="form-group">
                        <label class="badge badge-pill badge-success" for="CKEditorTenDacTinh">Tên đặc tính</label>
                        <asp:TextBox ID="CKEditorTenDacTinh" TextMode="MultiLine" runat="server"></asp:TextBox>
                        <script type="text/javascript" lang="javascript">
                            CKEDITOR.replace('<%=CKEditorTenDacTinh.ClientID%>');
                        </script>
                    </div>
                    <div class="form-group">
                        <label class="badge badge-pill badge-success" for="CKEditorTenPhuongPhap">Tên phương pháp</label>
                        <asp:TextBox ID="CKEditorTenPhuongPhap" TextMode="MultiLine" runat="server"></asp:TextBox>
                        <script type="text/javascript" lang="javascript">
                            CKEDITOR.replace('<%=CKEditorTenPhuongPhap.ClientID%>');
                        </script>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Hủy</button>
                    <asp:Button ID="btn_CapNhat" CssClass="btn btn-primary" runat="server" Text="Cập nhật" OnClick="btn_CapNhat_Click" />
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btnThemDacTinh" CssClass="btn btn-primary fa" runat="server" Text="" OnClick="btnThemDacTinh_Click" data-toggle="tooltip" data-placement="top" title="Thêm đặc tính" />
    <asp:Label ID="test" runat="server" Text=""></asp:Label>
</asp:Content>
