using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Ajax
{
    public partial class LMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string menuStr = @"
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,'Model/ModelQuery.aspx?model=Article.Recive'); hidefocus='true' style='outline:none;'>消息管理</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,'Test.aspx'); hidefocus='true' style='outline:none;'>生成测试数据</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>用户管理</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>角色管理</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>菜单管理</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>权限配置</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class='f14'>
    <span class='cu' title='点击操作'></span>
    <a href=javascript:_MP(19,''); hidefocus='true' style='outline:none;'>在线考勤</a>
</h3>
<h3 class=""f14""><span class=""switchs cu on"" title=""展开与收缩""></span>个人设置</h3>
<ul>
    <li id='_MP86' class='sub_menu'><a href=javascript:_MP(86,''); hidefocus='true' style='outline:none;'>个人信息</a></li>
</ul>
<script type=""text/javascript""> 
$("".switchs"").each(function(i){
	var ul = $(this).parent().next();
	$(this).click(
	function(){
		if(ul.is(':visible')){
			ul.hide();
			$(this).removeClass('on');
				}else{
			ul.show();
			$(this).addClass('on');
		}
	})
});
</script>
";
            Response.Clear();
            Response.Write(menuStr);
            Response.End();
        }
    }
}