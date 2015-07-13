<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/EditPage.Master" AutoEventWireup="true" CodeBehind="EmployeeEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Orgnization.EmployeeEdit" %>

<asp:Content ID="ctHeader" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="ctContent" ContentPlaceHolderID="Content" runat="server">
    <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="small">
        <tr>
            <td class="Big">
                <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" align="middle" alt=""><span class="big3"> 员工管理</span>&nbsp;&nbsp;&nbsp;&nbsp;
                <span style="font-size: 12px; float: right; margin-right: 20px;">
                    <a href="EmployeeList.aspx?departmentId=<%=DepartmentID %>" style="font-size: 12px;">&lt;&lt;返回列表页</a>
                </span>
            </td>
        </tr>
    </table>
    <fieldset>
        <legend>基本信息</legend>
        <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
            <tr>
                <td class="TableContent" width="15%">员工编号<font title='打*号表示为必填' color='#ff0000'>(*)</font>
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtEmployeeNumber" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">状态
                </td>
                <td class="TableData">
                    <asp:DropDownList ID="ddlWorkStatus" runat="server">
                        <asp:ListItem Text="在职" Value="1"></asp:ListItem>
                        <asp:ListItem Text="离职" Value="2"></asp:ListItem>
                        <asp:ListItem Text="试用" Value="3"></asp:ListItem>
                        <asp:ListItem Text="临聘" Value="4"></asp:ListItem>
                        <asp:ListItem Text="实习" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">中文名<font title='打*号表示为必填' color='#ff0000'>(*)</font>
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtChinesename" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">英文名<font title='打*号表示为必填' color='#ff0000'>(*)</font>
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtEnglishName" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">性别
                </td>
                <td class="TableData">
                    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="女" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="TableContent" width="15%">出生日期
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtBirthday" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">入职日期
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtHiredDate" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">离职日期
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtTerminatedDate" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">属地
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtAreaName" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">职级
                </td>
                <td class="TableData">
                    <asp:DropDownList ID="ddlJobGrade" runat="server">
                        <asp:ListItem Text="01"></asp:ListItem>
                        <asp:ListItem Text="02"></asp:ListItem>
                        <asp:ListItem Text="03"></asp:ListItem>
                        <asp:ListItem Text="04"></asp:ListItem>
                        <asp:ListItem Text="05"></asp:ListItem>
                        <asp:ListItem Text="06"></asp:ListItem>
                        <asp:ListItem Text="07"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">岗位信息
                </td>
                <td class="TableData" colspan="3">
                    <table>
                        <tr>
                            <th>序号</th>
                            <th>部门</th>
                            <th>职位</th>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">职称
                </td>
                <td class="TableData" colspan="3">
                    <table>
                        <tr>
                            <th>序号</th>
                            <th>职称</th>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">直系领导
                </td>
                <td class="TableData" colspan="3">
                    <asp:TextBox ID="txtReportLine" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">描述<font title='打*号表示为必填' color='#ff0000'>(*)</font>
                </td>
                <td class="TableData" colspan="3">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="500px" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
        <legend>工作信息</legend>
        <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
            <tr>
                <td class="TableContent" width="15%">办公电话
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtOfficePhone" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">传真
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtFax" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">手机1
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtMobilePhone" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">手机2
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtMobilePhone2" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">Email1
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">Email2
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtEmail2" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">所在地区
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtWorkCountryName" runat="server" CssClass="BigInput"></asp:TextBox>
                    <asp:TextBox ID="txtWorkProvinceName" runat="server" CssClass="BigInput"></asp:TextBox>
                    <asp:TextBox ID="txtWorkCityName" runat="server" CssClass="BigInput"></asp:TextBox>
                    <asp:TextBox ID="txtWorkCountyName" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">邮编
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtWorkZipCode" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">详细地址
                </td>
                <td class="TableData" colspan="3">
                    <asp:TextBox ID="txtWorkAddress" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
        <legend>家庭信息</legend>
        <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
            <tr>
                <td class="TableContent" width="15%">地址<font title='打*号表示为必填' color='#ff0000'>(*)</font>
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtHomeAddress" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%">电话
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtHomePhone" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">邮编
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtHomeZipCode" runat="server" CssClass="BigInput"></asp:TextBox>
                </td>
                <td class="TableContent" width="15%"></td>
                <td class="TableData"></td>
            </tr>
            <tr>
                <td class="TableContent" width="15%">紧急联系人
                </td>
                <td class="TableData" colspan="3">
                    <table>
                        <tr>
                            <td>序号</td>
                            <td>名称</td>
                            <td>关系</td>
                            <td>联系电话</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </fieldset>

    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" CssClass="BigButton" />
    <input type="button" value="返 回" onclick="location.href = 'EmployeeList.aspx?departmentId=<%=DepartmentID %>    '" class="BigButton" />
</asp:Content>
