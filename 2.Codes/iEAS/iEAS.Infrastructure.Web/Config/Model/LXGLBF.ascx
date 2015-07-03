<%@ Control Language="C#" AutoEventWireup="true" %>
<table border="1" style="border-collapse:collapse">
    <tr>
        <td rowspan="2" width="60px">序号</td>
        <td rowspan="2" width="200px">检查项目</td>
        <td rowspan="2">试验方法</td>
        <td rowspan="2" width="60px">整定值</td>
        <td colspan="5" width="300px">动作值（动作时间）</td>
        <td rowspan="2" width="60px">最大误差</td>
        <td rowspan="2" width="100px">技术要求</td>
    </tr>
    <tr>
        <td width="60px">第一次</td>
        <td width="60px">第二次</td>
        <td width="60px">第三次</td>
        <td width="60px">第四次</td>
        <td width="60px">第五次</td>
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
            <iEAS:ModelFieldContainer ID="ModelFieldContainer19" runat="server" FieldCode="R2R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer20" runat="server" FieldCode="R2R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer21" runat="server" FieldCode="R2R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer22" runat="server" FieldCode="R2R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer23" runat="server" FieldCode="R2R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer24" runat="server" FieldCode="R2R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <!--序号三-->
    <tr>
        <td rowspan="3">3</td>
        <td rowspan="3">零序过流Ⅲ段定值</td>
        <td rowspan="3">零序过流保护软压板整为1，零序电流保护控制字整为1，动作延时设为0.1s，零序过流Ⅱ段定值和时间均整最大值。采用电流递变菜单，将零序电流设为变化量，电流从0.9倍整定值往上升至保护动作；步长1‰整定值（最小为1mA），单步变化时间为200ms。</td>
        <td>0.05A</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer25" runat="server" FieldCode="R3R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer26" runat="server" FieldCode="R3R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer27" runat="server" FieldCode="R3R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer28" runat="server" FieldCode="R3R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer29" runat="server" FieldCode="R3R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer30" runat="server" FieldCode="R3R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="3">≤±5%或
±0.02A
        </td>
    </tr>
    <tr>
        <td>1.00A</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer31" runat="server" FieldCode="R3R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer32" runat="server" FieldCode="R3R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer33" runat="server" FieldCode="R3R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer34" runat="server" FieldCode="R3R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer35" runat="server" FieldCode="R3R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer36" runat="server" FieldCode="R3R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td>20.0A</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer37" runat="server" FieldCode="R3R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer38" runat="server" FieldCode="R3R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer39" runat="server" FieldCode="R3R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer40" runat="server" FieldCode="R3R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer41" runat="server" FieldCode="R3R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer42" runat="server" FieldCode="R3R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td rowspan="3">4</td>
        <td rowspan="3">零序过流Ⅲ段时间</td>
        <td rowspan="3">零序过流保护软压板整为1，零序电流保护控制字整为1，零序过流Ⅲ段定值整定为0.5 In，零序过流Ⅱ段定值整为20 In。采用测试仪状态序列菜单，故障状态设置零序故障电流为0.6 In。</td>
        <td>0.01s</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer43" runat="server" FieldCode="R4R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer44" runat="server" FieldCode="R4R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer45" runat="server" FieldCode="R4R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer46" runat="server" FieldCode="R4R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer47" runat="server" FieldCode="R4R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer48" runat="server" FieldCode="R4R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="3">≤±1%或
±30ms
        </td>
    </tr>
    <tr>
        <td>0.50s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer49" runat="server" FieldCode="R4R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer50" runat="server" FieldCode="R4R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer51" runat="server" FieldCode="R4R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer52" runat="server" FieldCode="R4R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer53" runat="server" FieldCode="R4R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer54" runat="server" FieldCode="R4R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td>10.0s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer55" runat="server" FieldCode="R4R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer56" runat="server" FieldCode="R4R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer57" runat="server" FieldCode="R4R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer58" runat="server" FieldCode="R4R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer59" runat="server" FieldCode="R4R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer60" runat="server" FieldCode="R4R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>

     <tr>
        <td rowspan="2">5</td>
        <td rowspan="2">零序Ⅱ段方向</td>
        <td rowspan="2">零序过流保护软压板整为1，零序电流保护控制字整为1，零序过流Ⅱ段定值整为0.5 In，动作延时整为0.01s。采用继保测试仪递变菜单，固定零序电压角度，将零序电流相位设为变化量，零序电流为1.2 In，零序电流相位从理论不动作区的两个边界转向动作区；步长0.1°，单步变化时间为200ms。</td>
        <td>理论边界1:</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer61" runat="server" FieldCode="R5R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer62" runat="server" FieldCode="R5R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer63" runat="server" FieldCode="R5R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer64" runat="server" FieldCode="R5R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer65" runat="server" FieldCode="R5R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer66" runat="server" FieldCode="R5R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="2">≤±3°
        </td> 
    </tr>
    <tr>
        <td>理论边界2:</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer67" runat="server" FieldCode="R5R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer68" runat="server" FieldCode="R5R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer69" runat="server" FieldCode="R5R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer70" runat="server" FieldCode="R5R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer71" runat="server" FieldCode="R5R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer72" runat="server" FieldCode="R5R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>

    <tr>
        <td rowspan="2">6</td>
        <td rowspan="2">零序Ⅲ段方向</td>
        <td rowspan="2">零序过流保护软压板整为1，零序电流保护控制字整为1，零序过流Ⅲ段经方向整为1，零序过流Ⅲ段定值整为0.5IN，动作延时整为0.01s，零序过流Ⅲ段定值整为In 。采用继保测试仪递变菜单，固定零序电压角度，将零序电流相位设为变化量，零序电流为1.2 In，零序电流相位从理论不动作区的两个边界转向动作区；步长0.1°，单步变化时间为200ms。</td>
        <td>理论边界1:</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer73" runat="server" FieldCode="R6R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer74" runat="server" FieldCode="R6R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer75" runat="server" FieldCode="R6R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer76" runat="server" FieldCode="R6R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer77" runat="server" FieldCode="R6R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer78" runat="server" FieldCode="R6R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="2">≤±3°
        </td>
    </tr>
    <tr>
        <td>理论边界2:</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer79" runat="server" FieldCode="R6R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer80" runat="server" FieldCode="R6R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer81" runat="server" FieldCode="R6R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer82" runat="server" FieldCode="R6R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer83" runat="server" FieldCode="R6R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer84" runat="server" FieldCode="R6R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>

    <tr>
        <td>7</td>
        <td>PT断线</td>
        <td>要求：PT断线后，零序电流Ⅱ段退出，零序电流Ⅲ段退出方向。</td>
        <td colspan="5">方法：零序过流保护软压板、零序电流保护控制字、零序过流Ⅲ段经方向整为1，零序过流Ⅱ段、Ⅲ段定值整为0.5A，动作延时均整为0.1s。采用状态序列菜单，模拟故障状态发生任意一相、二相或三相断线，故障电流为0.6A。并置零序方向于反方向。检查零序Ⅱ段、Ⅲ段是否动作。</td>
        <td colspan="3">
            <iEAS:ModelFieldContainer ID="ModelFieldContainer85" runat="server" FieldCode="R7C1I1V1"></iEAS:ModelFieldContainer>告警&nbsp;&nbsp;报文<iEAS:ModelFieldContainer ID="ModelFieldContainer91" runat="server" FieldCode="R7C1I1V2"></iEAS:ModelFieldContainer>
            <br />
            <iEAS:ModelFieldContainer ID="ModelFieldContainer92" runat="server" FieldCode="R7C1I2"></iEAS:ModelFieldContainer>零序电流Ⅱ段动作
            <br />
            <iEAS:ModelFieldContainer ID="ModelFieldContainer93" runat="server" FieldCode="R7C1I3"></iEAS:ModelFieldContainer>零序电流Ⅲ段动作
        </td>
    </tr>
</table>
