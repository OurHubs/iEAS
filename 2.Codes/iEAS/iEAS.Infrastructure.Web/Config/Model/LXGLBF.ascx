<%@ Control Language="C#" AutoEventWireup="true" %>
<table border="1" style="border-collapse:collapse">
    <tbody>
    <tr>
        <td rowspan="2" width="50px">序号</td>
        <td rowspan="2" width="200px">检查项目</td>
        <td rowspan="2">试验方法</td>
        <td rowspan="2" width="70px">整定值</td>
        <td colspan="5">动作值（动作时间）</td>
        <td rowspan="2" width="70px">最大误差</td>
        <td rowspan="2" width="100px">技术要求</td>
    </tr>
    <tr>
        <td width="70px">第一次</td>
        <td width="70px">第二次</td>
        <td width="70px">第三次</td>
        <td width="70px">第四次</td>
        <td width="70px">第五次</td>
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
        </tbody>
    <tbody>
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
         </tbody>
    <tbody>
    <tr>
        <td>7</td>
        <td>PT断线</td>
        <td>要求：PT断线后，零序电流Ⅱ段退出，零序电流Ⅲ段退出方向。</td>
        <td colspan="5" style="width:355px">方法：零序过流保护软压板、零序电流保护控制字、零序过流Ⅲ段经方向整为1，零序过流Ⅱ段、Ⅲ段定值整为0.5A，动作延时均整为0.1s。采用状态序列菜单，模拟故障状态发生任意一相、二相或三相断线，故障电流为0.6A。并置零序方向于反方向。检查零序Ⅱ段、Ⅲ段是否动作。</td>
        <td colspan="3" style="width:240px">
            <iEAS:ModelFieldContainer ID="ModelFieldContainer85" runat="server" FieldCode="R7C1I1V1"></iEAS:ModelFieldContainer>告警&nbsp;&nbsp;报文<iEAS:ModelFieldContainer ID="ModelFieldContainer91" runat="server" FieldCode="R7C1I1V2"></iEAS:ModelFieldContainer>
            <br />
            <iEAS:ModelFieldContainer ID="ModelFieldContainer92" runat="server" FieldCode="R7C1I2"></iEAS:ModelFieldContainer>零序电流Ⅱ段动作
            <br />
            <iEAS:ModelFieldContainer ID="ModelFieldContainer93" runat="server" FieldCode="R7C1I3"></iEAS:ModelFieldContainer>零序电流Ⅲ段动作
        </td>
    </tr>
    <tr>
        <td>8</td>
        <td>非全相运行</td>
        <td>当线路非全相运行时自动将零序电流保护最末一段动作时间缩短 0.5 s 并取消方向元件，作为线路非全相运行时不对称故障的总后备保护，取消线路非全相时投入运行的零序电流保护的其它段.</td>
        <td colspan="5" style="width:355px">方法：零序过流保护软压板、零序电流保护控制字、零序过流Ⅲ段经方向整为1，零序过流Ⅱ段、Ⅲ段定值整为0.5A，动作延时分别整为0.1s和1s。模拟系统缺一相运行，采用状态序列菜单模拟故障电流为0.6A。并置零序方向于反方向。检查零序Ⅱ段、Ⅲ段是否动作。</td>
        <td colspan="3" style="width:240px">
            <iEAS:ModelFieldContainer ID="ModelFieldContainer86" runat="server" FieldCode="R8C1I1V1"></iEAS:ModelFieldContainer>告警&nbsp;&nbsp;报文<iEAS:ModelFieldContainer ID="ModelFieldContainer87" runat="server" FieldCode="R8C1I1V2"></iEAS:ModelFieldContainer>
            <br />
            <iEAS:ModelFieldContainer ID="ModelFieldContainer88" runat="server" FieldCode="R8C1I2V1"></iEAS:ModelFieldContainer>零序电流Ⅱ段动作，时间：<iEAS:ModelFieldContainer ID="ModelFieldContainer90" runat="server" FieldCode="R8C1I2V2"></iEAS:ModelFieldContainer>
            <br />
            <iEAS:ModelFieldContainer ID="ModelFieldContainer89" runat="server" FieldCode="R8C1I3V1"></iEAS:ModelFieldContainer>零序电流Ⅲ段动作，时间：<iEAS:ModelFieldContainer ID="ModelFieldContainer94" runat="server" FieldCode="R8C1I3V2"></iEAS:ModelFieldContainer>
        </td>
    </tr>

    <tr>
        <td>9</td>
        <td>纵差零序死区电压</td>
        <td>纵联零序保护软压板和纵联零序保护控制字整为“1”。零序电流为1.2倍整定值，零序方向设为灵敏角，零序电压设为变化量。电压从0往上升，步长0.001 V，单步变化时间不小于200 ms。</td>
        <td>固有（不可整定）</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer95" runat="server" FieldCode="R9R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer96" runat="server" FieldCode="R9R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer97" runat="server" FieldCode="R9R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer98" runat="server" FieldCode="R9R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer99" runat="server" FieldCode="R9R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer100" runat="server" FieldCode="R9R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td>≤1V</td>
    </tr>

     <tr>
        <td rowspan="3">10</td>
        <td rowspan="3">零序过流加速断定值</td>
        <td rowspan="3">零序过流保护软压板和零序电流保护控制字整为1，单相重合闸控制字整为1，零序过流Ⅱ段定值整为1A，时间为0.2s，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统单相接地—故障切除—重合于故障。重合于故障的电流分别设为0.95倍加速段整定值和1.05倍加速段整定值，通过动作时间来判断加速段在0.95倍定值时是否可靠闭锁1.05倍定值时是否可靠动作。</td>
        <td>0.05s</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer101" runat="server" FieldCode="R10R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer102" runat="server" FieldCode="R10R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer103" runat="server" FieldCode="R10R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer104" runat="server" FieldCode="R10R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer105" runat="server" FieldCode="R10R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer106" runat="server" FieldCode="R10R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="3">≤±5%或
±0.02A
        </td>
    </tr>
    <tr>
        <td>0.50s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer107" runat="server" FieldCode="R10R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer108" runat="server" FieldCode="R10R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer109" runat="server" FieldCode="R10R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer110" runat="server" FieldCode="R10R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer111" runat="server" FieldCode="R10R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer112" runat="server" FieldCode="R10R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td>10.0s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer113" runat="server" FieldCode="R10R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer114" runat="server" FieldCode="R10R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer115" runat="server" FieldCode="R10R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer116" runat="server" FieldCode="R10R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer117" runat="server" FieldCode="R10R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer118" runat="server" FieldCode="R10R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>

    <tr>
        <td>11</td>
        <td>零序过流加速断时间</td>
        <td>零序过流保护软压板整为1，零序电流保护控制字整为1，单相重合闸控制字整为1，零序过流Ⅱ段定值整为IN，加速段定值整为0.5 In，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统单相接地—故障切除—重合于故障，重合于故障的电流 设为0.6 In。</td>
        <td>100ms（不可整定）</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer119" runat="server" FieldCode="R11R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer120" runat="server" FieldCode="R11R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer121" runat="server" FieldCode="R11R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer122" runat="server" FieldCode="R11R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer123" runat="server" FieldCode="R11R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer124" runat="server" FieldCode="R11R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td>≤±30ms</td>
    </tr>
     <tr>
        <td rowspan="3">12</td>
        <td rowspan="3">单相重合闸</td>
        <td rowspan="3">零序过流保护软压板整为1，零序电流保护控制字整为1，单相重合闸控制字整为1，零序过流Ⅱ段定值整为In，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统单相接地故障（故障零序电流1.2 In）—保护发跳闸命令延时40ms后切除故障，进行单相重合闸检查。</td>
        <td>0.1s</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer131" runat="server" FieldCode="R12R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer132" runat="server" FieldCode="R12R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer133" runat="server" FieldCode="R12R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer134" runat="server" FieldCode="R12R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer135" runat="server" FieldCode="R12R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer136" runat="server" FieldCode="R12R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="3">≤±1%或
±40ms
        </td>
    </tr>
    <tr>
        <td>1.5s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer137" runat="server" FieldCode="R12R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer138" runat="server" FieldCode="R12R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer139" runat="server" FieldCode="R12R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer140" runat="server" FieldCode="R12R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer141" runat="server" FieldCode="R12R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer142" runat="server" FieldCode="R12R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td>10.0s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer143" runat="server" FieldCode="R12R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer144" runat="server" FieldCode="R12R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer145" runat="server" FieldCode="R12R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer146" runat="server" FieldCode="R12R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer147" runat="server" FieldCode="R12R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer148" runat="server" FieldCode="R12R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>


    <tr>
        <td>13</td>
        <td>重合闸</td>
        <td>调查并确认重合闸计时方式</td>
        <td colspan="8">
            重合闸计时方式：<iEAS:ModelFieldContainer ID="ModelFieldContainer149" runat="server" FieldCode="R13R1C1"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    
    

    <tr>
        <td>14</td>
        <td>后加速</td>
        <td>零序过流保护软压板整为1，零序电流保护控制字整为1，单相重合闸控制字整为1，零序过流Ⅱ段定值整为In，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统单相接地故障（故障零序电流1.2 In）—故障切除—单相重合闸—重合于永久性故障，进行后加速时间检查。</td>
        <td>固有（不可整定）</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer125" runat="server" FieldCode="R14R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer126" runat="server" FieldCode="R14R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer127" runat="server" FieldCode="R14R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer128" runat="server" FieldCode="R14R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer129" runat="server" FieldCode="R14R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer130" runat="server" FieldCode="R14R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td>≤±30ms</td>
    </tr>

     <tr>
        <td rowspan="3">15</td>
        <td rowspan="3">三相重合闸</td>
        <td rowspan="3">零序过流保护软压板整为1，零序电流保护控制字整为1，三相重合闸控制字整为1，零序过流Ⅱ段定值整为In，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统单相接地故障（故障零序电流1.2 In）发跳三相命令延时40ms切除故障，进行三相重合闸检查。</td>
        <td>0.1s</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer150" runat="server" FieldCode="R15R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer151" runat="server" FieldCode="R15R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer152" runat="server" FieldCode="R15R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer153" runat="server" FieldCode="R15R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer154" runat="server" FieldCode="R15R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer155" runat="server" FieldCode="R15R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="3">≤±1%或
±40ms
        </td>
    </tr>
    <tr>
        <td>3.0s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer156" runat="server" FieldCode="R15R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer157" runat="server" FieldCode="R15R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer158" runat="server" FieldCode="R15R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer159" runat="server" FieldCode="R15R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer160" runat="server" FieldCode="R15R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer161" runat="server" FieldCode="R15R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td>10.0s</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer162" runat="server" FieldCode="R15R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer163" runat="server" FieldCode="R15R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer164" runat="server" FieldCode="R15R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer165" runat="server" FieldCode="R15R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer166" runat="server" FieldCode="R15R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer167" runat="server" FieldCode="R15R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>

        <tr>
        <td>16</td>
        <td>三重加速距离Ⅱ段</td>
        <td>零序过流保护软压板、零序电流保护控制字、三相重合闸控制字、三重加速距离Ⅱ段控制字、距离保护软压板、距离保护Ⅱ段控制字为1整为1。零序过流Ⅱ段定值整为In，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统单相接地故障（故障零序电流1.2 In）跳三相—故障切除—三相重合闸—重合于永久性故障（接地阻抗设为0.7倍距离Ⅱ段整定值）。</td>
        <td>固有（不可整定）</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer186" runat="server" FieldCode="R16R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer187" runat="server" FieldCode="R16R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer188" runat="server" FieldCode="R16R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer189" runat="server" FieldCode="R16R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer190" runat="server" FieldCode="R16R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer191" runat="server" FieldCode="R16R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td>≤30ms</td>
    </tr>
        <tr>
        <td>17</td>
        <td>三重加速距离Ⅲ段</td>
        <td>零序过流保护软压板、零序电流保护控制字、三相重合闸控制字、三重加速距离Ⅲ段控制字、距离保护软压板、距离保护Ⅲ段控制字为1整为1。零序过流Ⅱ段定值整为In，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统单相接地故障（故障零序电流1.2 In）跳三相—故障切除—三相重合闸—重合于永久性故障（接地阻抗设为0.7倍距离Ⅲ段整定值）。</td>
        <td>固有（不可整定）</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer192" runat="server" FieldCode="R17R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer193" runat="server" FieldCode="R17R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer194" runat="server" FieldCode="R17R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer195" runat="server" FieldCode="R17R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer196" runat="server" FieldCode="R17R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer197" runat="server" FieldCode="R17R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td>≤30ms</td>
    </tr>
    <tr>
        <td rowspan="3">18</td>
        <td rowspan="3">同期合闸角</td>
        <td rowspan="3">零序过流保护软压板整为1，零序电流保护控制字整为1，三相重合闸控制字整为1，重合闸检同期方式控制字整为1，零序过流Ⅱ段定值整为In，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统相间短路（故障零序电流1.2 In）—故障切除，故障切除后分别改变同期电压与线路电压之间的角度差找出可靠合闸角。</td>
        <td>0°</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer168" runat="server" FieldCode="R18R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer169" runat="server" FieldCode="R18R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer170" runat="server" FieldCode="R18R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer171" runat="server" FieldCode="R18R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer172" runat="server" FieldCode="R18R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer173" runat="server" FieldCode="R18R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td rowspan="3"≤±3°
        </td>
    </tr>
    <tr>
        <td>30°</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer174" runat="server" FieldCode="R18R2C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer175" runat="server" FieldCode="R18R2C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer176" runat="server" FieldCode="R18R2C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer177" runat="server" FieldCode="R18R2C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer178" runat="server" FieldCode="R18R2C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer179" runat="server" FieldCode="R18R2C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
    <tr>
        <td>90°</td>
         <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer180" runat="server" FieldCode="R18R3C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer181" runat="server" FieldCode="R18R3C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer182" runat="server" FieldCode="R18R3C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer183" runat="server" FieldCode="R18R3C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer184" runat="server" FieldCode="R18R3C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer185" runat="server" FieldCode="R18R3C6"></iEAS:ModelFieldContainer>
        </td>
    </tr>
     <tr>
        <td>19</td>
        <td>检无压定值</td>
        <td>零序过流保护软压板整为1，零序电流保护控制字整为1，三相重合闸控制字整为1，重合闸检无压方式控制字整为1，零序过流Ⅱ段定值整为In，零序Ⅲ段定值和时间均整最大值。采用状态序列菜单，模拟系统相间短路（故障零序电流1.2 In）—故障切除，故障切除后从大到小改变同期电压直至重合闸 。</td>
        <td>固有（不可整定）</td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer198" runat="server" FieldCode="R19R1C1"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer199" runat="server" FieldCode="R19R1C2"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer200" runat="server" FieldCode="R19R1C3"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer201" runat="server" FieldCode="R19R1C4"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer202" runat="server" FieldCode="R19R1C5"></iEAS:ModelFieldContainer>
        </td>
        <td>
            <iEAS:ModelFieldContainer ID="ModelFieldContainer203" runat="server" FieldCode="R19R1C6"></iEAS:ModelFieldContainer>
        </td>
        <td>±5.0%或±0.002UN</td>
    </tr>
        </tbody>
</table>
<style type="text/css">
    td {
        font-family: 楷体;
        font-size: 14px;
        line-height: 150%;
    }
</style>
