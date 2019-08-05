<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Project_HD.Report_DCD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bảng báo cáo</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            left: 378px;
            top: 124px;
            width: 267px;
        }

        .auto-style2 {
            left: 38px;
            top: 328px;
            width: 642px;
            height: 558px;
        }

        .auto-style3 {
            left: 240px;
            top: 41px;
            width: 301px;
        }

        .auto-style4 {
            top: 299px;
            left: 58px;
        }

        .auto-style5 {
            left: 247px;
            top: 19px;
            width: 259px;
        }
    </style>
    <link rel="icon"
        type="image/jpg"
        href="vendor/evn_logo.png"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panel_DCD" CssClass="panel_DCD" runat="server" BorderStyle="Solid"
            Height="27cm" Width="19cm">
            &nbsp;&nbsp;&nbsp;
        <img src="image/logo2.png" class="logo2" />
            <img src="image/logo1.png" class="logo1" />
            <asp:Label ID="lbl_title1" runat="server" CssClass="auto-style5" Text="TỔNG CÔNG TY ĐIỆN LỰC MIỀN NAM"></asp:Label>
            <asp:Label ID="lbl_title2" runat="server" Text="CÔNG TY THÍ NGHIỆM ĐIỆN MIỀN NAM" CssClass="auto-style3"></asp:Label>
            <hr class="hr_head" />
            <asp:Label ID="lbl_DCD_title3" runat="server" Text="KẾT QUẢ THÍ NGHIỆM" CssClass="auto-style1"></asp:Label>
            <asp:Label ID="lbl_DCD_title4" runat="server" Style="top: 85px; left: 396px; font-weight: 700; width: 208px;" Text="DẦU CÁCH ĐIỆN"></asp:Label>
            <asp:Label ID="lbl_heading1" runat="server" Style="top: 114px; left: 68px">I. ĐỐI TƯỢNG THỬ:</asp:Label>
            <asp:Label ID="lbl_heading2" runat="server" Style="top: 139px; left: 61px">II. THÔNG SỐ KỸ THUẬT:</asp:Label>
            <asp:Label ID="lbl_xuatxu" runat="server" Style="top: 163px; left: 82px"
                Text="Xuất xứ:"></asp:Label>
            <asp:Label ID="lbl_ngaylaymau" runat="server" Style="top: 183px; left: 82px"
                Text="Ngày lấy mẫu:"></asp:Label>
            <asp:Label ID="lbl_ngaynhanmau" runat="server" Style="top: 183px; left: 262px"
                Text="Nhận mẫu:"></asp:Label>
            <asp:Label ID="lbl_ngaythumau" runat="server" Style="top: 183px; left: 432px"
                Text="Thử mẫu:"></asp:Label>
            <asp:Label ID="lbl_kqxuatxu" runat="server" Style="top: 163px; left: 142px"
                Text="Xuất xứ:"></asp:Label>
            <asp:Label ID="lbl_kqngaylaymau" runat="server" Style="top: 183px; left: 176px"
                Text="Ngày lấy mẫu:"></asp:Label>
            <asp:Label ID="lbl_kqngaynhanmau" runat="server"
                Style="top: 183px; left: 336px" Text="Nhận mẫu:"></asp:Label>
            <asp:Label ID="lbl_kqngaythumau" runat="server" Style="top: 183px; left: 500px"
                Text="Thử mẫu:"></asp:Label>
            <asp:Label ID="lbl_lydothinghiem" runat="server" Style="top: 204px; left: 82px"
                Text="Lý do thí nghiệm:"></asp:Label>
            <asp:Label ID="lbl_kqlydothinghiem" runat="server"
                Style="top: 204px; left: 195px" Text="Lý do thí nghiệm:"></asp:Label>
            <asp:Label ID="lbl_phutrachlaymau" runat="server"
                Style="top: 225px; left: 82px" Text="Phụ trách lấy mẫu (TM-BCN):"></asp:Label>
            <asp:Label ID="lbl_kqphutrachlaymau" runat="server"
                Style="top: 225px; left: 267px" Text="Phụ trách lấy mẫu (TM-BCN):"></asp:Label>
            <asp:Label ID="lbl_ghichu" runat="server" Style="top: 245px; left: 82px"
                Text="Ghi chú:"></asp:Label>
            <asp:Label ID="lbl_kqghichu" runat="server" Style="top: 245px; left: 142px"
                Text="Ghi chú:"></asp:Label>
            <asp:Label ID="lbl_heading3" runat="server" CssClass="auto-style4">III. SỐ LIỆU THÍ NGHIỆM:</asp:Label>


            <!-- table -->
            <hr class="hr_foot" />
            <asp:Label ID="lbl_address" runat="server"
                Style="top: 981px; left: 9px; font-family: 'Times New Roman', Times, serif; font-size: 13px; color: #0000FF"
                Text="Add: 22bis Phan Đăng Lưu, Q.Bình Thạnh, Tp.Hồ Chí Minh"></asp:Label>
            <asp:Label ID="lbl_tel" runat="server"
                Style="top: 999px; left: 9px; font-family: 'Times New Roman', Times, serif; font-size: 13px; color: #0000FF"
                Text="Tel: 08 3841 4903 | Fax: 08 3551 1689"></asp:Label>
            <asp:Label ID="lbl_http" runat="server"
                Style="top: 981px; left: 605px; font-family: 'Times New Roman', Times, serif; font-size: 13px; color: #0000FF"
                Text="http://www.etc2.vn"></asp:Label>
            <asp:Label ID="lbl_email" runat="server"
                Style="top: 999px; left: 599px; font-family: 'Times New Roman', Times, serif; font-size: 13px; color: #0000FF"
                Text="Email: etc2@etc2.vn"></asp:Label>
            <asp:Label ID="lblSoCot" runat="server" Visible="false" Text=""></asp:Label>
            <div id="div_Table" class="auto-style2">
                <table class="table">
                    <tr>
                        <th style="width: 0.5cm;" rowspan="2" style="vertical-align: middle; text-align: center;" scope="col">STT
                        </th>
                        <th style="width: 5.7cm;" rowspan="2" style="vertical-align: middle; text-align: center;" scope="col">ĐẶC TÍNH
                        </th>
                        <th style="width: 2.3cm;" rowspan="2" style="vertical-align: middle; text-align: center;" scope="col">PHƯƠNG PHÁP
                        </th>
                        <th class="kq" colspan='<%= lblSoCot.Text %>' style="vertical-align: middle; text-align: center;" scope="col">KẾT QUẢ
                        </th>
                        <th rowspan="2" style="vertical-align: middle; text-align: center;" scope="col">NHÂN VIÊN THÍ NGHIỆM
                        </th>
                    </tr>
                    <tr>
                        <asp:Repeater ID="rptCot" runat="server">
                            <ItemTemplate>
                                <th style="width: 2.2cm; vertical-align: middle; text-align: center;" scope="col">
                                    <asp:Label ID="lblTenCot" runat="server" Text='<%# Eval("TenCot") %>'></asp:Label>
                                </th>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                    <asp:Repeater ID="rptThiNghiem" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblID1" runat="server" Text='<%# ((System.Data.DataRowView)Container.DataItem)["DT.ChiSo"] %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblTenDacTinh" runat="server" Text='<%# Eval("Ten") %>' />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblTenPhuongPhap" runat="server" Text='<%# Eval("PhuongPhap") %>' />
                                </td>
                                <td id="Cot1" runat="server" visible='<%# 1<=Convert.ToInt32(lblSoCot.Text) %>'>
                                    <asp:Label ID="txtCot1" runat="server" Text='<%# Eval("Cot1") %>'></asp:Label>
                                </td>
                                <td id="Cot2" runat="server" visible='<%# 2<=Convert.ToInt32(lblSoCot.Text) %>'>
                                    <asp:Label ID="txtCot2" runat="server" Text='<%# Eval("Cot2") %>'></asp:Label>
                                </td>
                                <td id="Cot3" runat="server" visible='<%# 3<=Convert.ToInt32(lblSoCot.Text) %>'>
                                    <asp:Label ID="txtCot3" runat="server" Text='<%# Eval("Cot3") %>'></asp:Label>
                                </td>
                                <td id="Cot4" runat="server" visible='<%# 4<=Convert.ToInt32(lblSoCot.Text) %>'>
                                    <asp:Label ID="txtCot4" runat="server" Text='<%# Eval("Cot4") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNguoiTao" runat="server" Text='<%# Eval("NguoiNhap") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
