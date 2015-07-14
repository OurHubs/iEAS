using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iEAS.Infrastructure.Web.Pages.Account
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string code=context.Request["code"].ToStr();
            string action = context.Request["action"].ToStr();
            //if (!string.IsNullOrEmpty(code))
            //{
            //    context.Response.Write("1");
            //    context.Response.End();
            //}
            //context.Response.Write("0");


           
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "CheckRoleCode":
                        string result = "";
                        if (!string.IsNullOrEmpty(code))
                        {
                            result = CheckRoleCode(code);
                        }
                        else
                        {
                            ReturnMsg msg = new ReturnMsg();
                            msg.ReturnCode = "0";
                            msg.ReturnDesc = "编码为空";
                            result= Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        context.Response.Write(result);
                        break;
                    default:

                        break;
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public string CheckRoleCode(string code)
        {
            ReturnMsg msg = new ReturnMsg();
            msg.ReturnCode = "2";
            msg.ReturnDesc = "编码重复" + code;
            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);

        }
    }

    public class ReturnMsg
    {
        public string ReturnCode { get; set; }
        public string ReturnDesc { get; set; }
    }
}