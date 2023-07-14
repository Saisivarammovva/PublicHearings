<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="PublicHearings.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/font-awesome.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <title>PublicHearings Report</title>
    <style>
        #GridView1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                     <asp:BoundField DataField="SNO" HeaderText="SNO" />
                    <asp:BoundField DataField="Hearing_Name_Location" HeaderText="Hearing_Name_Location" />
                    <asp:BoundField DataField="Hearing_Venue" HeaderText="Hearing_Venue" />
                    <asp:BoundField DataField="Hearing_Date" HeaderText="Hearing_Date" />
                    <asp:BoundField DataField="Hearing_Time" HeaderText="Hearing_Time" DataFormatString="{0:dd/MM/yyyy}" /> 
                    <asp:BoundField DataField="Line_Of_Activity" HeaderText="Line_Of_Activity" />
                    <asp:BoundField DataField="Regional_Office" HeaderText="Regional_Office" />
                    <asp:TemplateField HeaderText="PDF">
                        <ItemTemplate>
                            <a href='<%# Eval("Executive_Summary_Telugu") %>' download>
                                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="PDF">
                        <ItemTemplate>
                            <a href='<%# Eval("Executive_Summary_English") %>' download>
                                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="PDF">
                        <ItemTemplate>
                            <a href='<%# Eval("EIA_Report") %>' download>
                                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="PDF">
                        <ItemTemplate>
                            <a href='<%# Eval("Meetings_File") %>' download>
                                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
