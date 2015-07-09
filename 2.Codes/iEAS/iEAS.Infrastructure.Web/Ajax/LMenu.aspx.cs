using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Ajax
{
    public partial class LMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid menuId = Request["menuid"].ToGuid();
            string portal = Request["portal"];
            var portalMenus = AccountContext.Current.GetPortalMenus(portal);
            var menus = portalMenus
                .Where(m => m.ParentID == menuId)
                .OrderBy(m => m.Sort);

            StringBuilder sbMenus = new StringBuilder();
            foreach(var menu in menus)
            {
                var subMenus = portalMenus.Where(m => m.ParentID == menu.ID).OrderBy(m => m.Sort).ToList();
                if (subMenus.Count > 0)
                {
                    sbMenus.AppendFormat(@"<h3 class=""f14""><span class=""switchs cu on"" title=""展开与收缩""></span>{0}</h3>",menu.Name);
                    sbMenus.Append("<ul>");
                    foreach (var subMenu in subMenus)
                    {
                        sbMenus.AppendFormat(" <li id='_MP86' class='sub_menu'><a href=javascript:_MP('{0}','{1}'); hidefocus='true' style='outline:none;'>{2}</a></li>", subMenu.ID, subMenu.Url, subMenu.Name);
                    }
                    sbMenus.Append("</ul>");
                }
                else
                {
                    sbMenus.AppendFormat(@"<h3 class='f14'><span title='点击操作'></span><a href=javascript:_MP('{0}','{1}'); hidefocus='true' style='outline:none;'>{2}</a></h3>", menu.ID,menu.Url,menu.Name);
                }
            }
            sbMenus.Append(@"<script type=""text/javascript""> 
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
</script>");
            Response.Clear();
            Response.Write(sbMenus);
            Response.End();
        }
    }
}