<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true"
    CodeBehind="PhanQuyen.aspx.cs" Inherits="Project_HD.quantri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang phân quyền</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
        <h4>Chọn loại thí nghiệm</h4>
        
        <asp:DropDownList CssClass="custom-select w-25" ID="ddlLoaiThiNghiem" runat="server" OnSelectedIndexChanged="ddlLoaiThiNghiem_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Repeater ID="rptPhanQuyen" runat="server" OnItemDataBound="rptPhanQuyen_ItemDataBound" OnItemCreated="rptPhanQuyen_ItemCreated">
            <HeaderTemplate>
                
                <table class="table">
                    <tr>
                        <th scope="col">ID
                        </th>
                        <th scope="col">Tên đặc tính
                        </th>
                        <th scope="col">Phương pháp
                        </th>
                        <th scope="col">Quyền chỉnh sửa
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblChiSo" runat="server" Text='<%# Eval("ChiSo") %>' />
                        <asp:Label Visible="false" ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblTen" runat="server" Text='<%# Eval("Ten") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblPhuongPhap" runat="server" Text='<%# Eval("PhuongPhap") %>' />
                    </td>
                    <td>
                        <asp:DropDownList class="custom-select" ID="ddlNguoiDung" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
</asp:Content>
