<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LXGLBF.ascx.cs" Inherits="iEAS.Infrastructure.Web._Templates.Default.Model.LXGLBF" %>
<table border="1" style="border-collapse:collapse">
    <tr>
        <td rowspan="2" style="width:60px">序号</td>
        <td rowspan="2" style="width:200px">检查项目</td>
        <td rowspan="2">试验方法</td>
        <td rowspan="2" style="width:60px">整定值</td>
        <td colspan="5">动作值（动作时间）</td>
        <td rowspan="2" style="width:60px">最大误差</td>
        <td rowspan="2" style="width:100px">技术要求</td>
    </tr>
    <tr>
        <td style="width:60px">第一次</td>
        <td style="width:60px">第二次</td>
        <td style="width:60px">第三次</td>
        <td style="width:60px">第四次</td>
        <td style="width:60px">第五次</td>
    </tr>
    <tr>
        <td rowspan="3">1</td>
        <td rowspan="3">零序过流Ⅱ段定值</td>
        <td rowspan="3">零序过流保护软压板整为1，零序电流保护控制字整为1，动作延时设为0.1s，零序过流Ⅲ段定值和时间均整最大值。采用电流递变菜单，将零序电流设为变化量，电流从0.9倍整定值往上升至保护动作；步长1‰整定值（最小为1mA），单步变化时间为200ms。</td>
        <td>0.05A</td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R1C1" runat="server" FieldCode="R1R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R1C2" runat="server" FieldCode="R1R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R1C3" runat="server" FieldCode="R1R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R1C4" runat="server" FieldCode="R1R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R1C5" runat="server" FieldCode="R1R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R1C6" runat="server" FieldCode="R1R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="3">≤±5%或
±0.02A
        </td>
    </tr>
    <tr>
        <td>1.00A</td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R2C1" runat="server" FieldCode="R1R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R2C2" runat="server" FieldCode="R1R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R2C3" runat="server" FieldCode="R1R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R2C4" runat="server" FieldCode="R1R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R2C5" runat="server" FieldCode="R1R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="R1R2C6" runat="server" FieldCode="R1R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td>20.0A</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer1" runat="server" FieldCode="R1R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer2" runat="server" FieldCode="R1R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer3" runat="server" FieldCode="R1R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer4" runat="server" FieldCode="R1R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer5" runat="server" FieldCode="R1R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer6" runat="server" FieldCode="R1R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td rowspan="3">2</td>
        <td rowspan="3">零序过流Ⅱ段时间</td>
        <td rowspan="3">零序过流保护软压板整为1零序过流保护软压板整为1，零序电流保护控制字整为1，零序过流Ⅱ段定值整定为0.5 In，零序过流Ⅱ段定值整为20 In。采用测试仪状态序列菜单，故障状态设置零序故障电流为0.6 In。</td>
        <td>0.01s</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer7" runat="server" FieldCode="R2R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer8" runat="server" FieldCode="R2R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer9" runat="server" FieldCode="R2R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer10" runat="server" FieldCode="R2R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer11" runat="server" FieldCode="R2R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer12" runat="server" FieldCode="R2R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="3">≤±1%或
±30ms
        </td>
    </tr>
    <tr>
        <td>0.50s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer13" runat="server" FieldCode="R2R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer14" runat="server" FieldCode="R2R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer15" runat="server" FieldCode="R2R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer16" runat="server" FieldCode="R2R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer17" runat="server" FieldCode="R2R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer18" runat="server" FieldCode="R2R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td>10.0s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer19" runat="server" FieldCode="R3R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer20" runat="server" FieldCode="R3R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer21" runat="server" FieldCode="R3R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer22" runat="server" FieldCode="R3R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer23" runat="server" FieldCode="R3R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer24" runat="server" FieldCode="R3R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
</table>
