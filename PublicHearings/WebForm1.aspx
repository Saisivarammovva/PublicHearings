<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PublicHearings.WebForm1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap-datepicker.js"></script>
    <link href="Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="JavaScript.js"></script>
    <title>Public Hearings</title>
    <style>
        #GridView1 {
            text-align: center;
            margin-left: 120px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="container">
            <div form="row">
                <div style="text-align: center;">
                    <h2  style="color: cornflowerblue">Public Hearings</h2>
                    <br/>
                    <asp:RadioButton ID="rtbn1" runat="server" Text="Summary Details" Style="margin-right: 4em" onclick="Option1()" GroupName="RBN" />

                    <asp:RadioButton ID="rbtn2" runat="server" Text="Meeting Details" onclick="Option2()" GroupName="RBN"  />
                </div>

                <div id="option1Textboxes" style="display: none">
                    <h4 style="margin-left: 18px; color: cornflowerblue"><b>Summary Details</b></h4>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl1" runat="server" for="txt1"><b>Hearing Name & Location:</b> <span style="color:red">*</span></asp:Label>
                            <asp:TextBox ID="HearingNametxt" runat="server" class=" form-control" placeholder="Please Enter Hearing Name & Location" autocomplete="off"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl2" runat="server" for="txt2"><b>Hearing Venue:</b> <span style="color:red">*</span></asp:Label>
                            <asp:TextBox ID="HearingVenuetxt" runat="server" class=" form-control" placeholder="Please Enter Hearing Venue" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl3" runat="server" for="txtDate"><b>Hearing date:</b> <span style="color:red">*</span></asp:Label>
                            <br />
                            <asp:TextBox ID="txtDate" runat="server" class="form-control" onkeypress="return false;" placeholder="Please Enter Hearing Date" autocomplete="off"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl4" runat="server" for="txt4"><b>Hearing Time:</b> <span style="color:red">*</span></asp:Label> 

                            <asp:TextBox ID="HearingTimetxt" runat="server" class=" form-control" placeholder="HH:MM" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl5" runat="server" for="txt5"><b>Line Of Activity:</b> <span style="color:red">*</span></asp:Label>         

                            <asp:TextBox ID="LineOfActivitytxt" runat="server" class=" form-control" placeholder="Please Enter Line Of Activity" autocomplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl6" runat="server" for="txt6"><b>Regional Office:</b> <span style="color:red">*</span></asp:Label>

                            <asp:TextBox ID="RegionalOfficetxt" runat="server" class=" form-control" placeholder="Please Enter Regional Office" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl7" runat="server" for="FileUpload1"><b>Executive Summary Telugu:</b> <span style="color:red">*</span></asp:Label>

                            <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl8" runat="server" for="FileUpload2"><b>Executive Summary English:</b> <span style="color:red">*</span></asp:Label>
                            <asp:FileUpload ID="FileUpload2" runat="server" class="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl9" runat="server" for="FileUpload3"><b>EIA Report:</b> <span style="color:red">*</span></asp:Label>
                            <asp:FileUpload ID="FileUpload3" runat="server" class="form-control" />
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl10" runat="server" for="FileUpload4"><b>Other Document 1:</b> </asp:Label>
                            <asp:FileUpload ID="FileUpload4" runat="server" class="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbl11" runat="server" for="FileUpload5"><b>Other Document 2:</b> </asp:Label>
                            <asp:FileUpload ID="FileUpload5" runat="server" class="form-control" />
                            <br />
                        </div>
                        <div class="form-group col-md-4">
                        </div>
                    </div>
                    <div class="form-group col-md-4">
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Button ID="btn1" runat="server" Text="Submit" OnClientClick="return validateForm()" OnClick="btn1_Click" class="btn btn-primary" />
                    </div>
                </div>
                <div id="option2Textboxes" style="display: none">
                    <h4 style="margin-left: 150px; color: cornflowerblue"><b>Meeting Details</b></h4>
                    <asp:GridView ID="GridView1" runat="server" Width="701px" AutoGenerateColumns="False" Height="180px" OnRowUpdating="GridView1_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="Hearing ID ">
                                <ItemTemplate>
                                    <asp:Label ID="HearingID" runat="server" Text='<%#Eval("SNO") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hearing Name">
                                <ItemTemplate>
                                    <asp:Label ID="HearingName" runat="server" Text='<%#Eval("Hearing_Name_Location") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File Upload Details">
                                <ItemTemplate>
                                    <asp:FileUpload ID="meetingfile" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="UpdateButton" runat="server" Text="Update" CommandName="Update" class="btn btn-primary " OnClientClick="return Validate()" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
