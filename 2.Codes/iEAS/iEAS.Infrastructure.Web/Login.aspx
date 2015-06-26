<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="iEAS.Infrastructure.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="assets/common/css/viplogin_130319.css" />
    <script type="text/javascript" src="Assets/common/js/jquery.min.js"></script>
</head>
<body>
    <div id="bgHeight" class="bgHeight">
        <!--登录页背景-->
        <div class="viploginbg">
            <img src="Assets/common/images/sp2013_2.jpg" style="width: 100%;height: auto; margin-left: 0px; margin-top: -68.5px; visibility: visible;" />
        </div>
        <!--/登录页背景-->
        <!--顶部导航-->
        <div class="topbar">
            <div class="topmain">
                <h1 class="logo"><a href=""></a></h1>
                <div class="rtop"><a href=""></a></div>
            </div>
        </div>
        <!--/顶部导航-->
        <!--登录框-->
        <div class="loginBox" id="loginBox">
            <form id="form1" runat="server">
                <ul class="vipMailbox">
                    <li class="mailname">
                        <label class="placeholder" for="vipname">输入用户名</label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="username focus" TabIndex="1"></asp:TextBox>
                        <a class="clearname" href="#" style="display: none;"></a></li>
                    <li class="mailpass" style="margin-top: 5px;">
                        <label class="placeholder" for="vippassword">输入密码</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="password" TabIndex="2"></asp:TextBox>
                    </li>
                    <li class="btn">
                        <asp:Button ID="btnLogin" runat="server" Text="登陆" CssClass="loginBtn" OnClick="btnLogin_Click" />
                    </li>
                </ul>
            </form>
        </div>
        <!--/登录框-->
        <!--尾部-->
        <div class="vipfooter">
            <div class="loginFooter" style="background-color: #CC6600;">
                <ul>
                    <li>测试账号:test1 , test2 , test3 , test4 , test5  , test6  , test7  , test8  , test9 密码统一为:111111 ;由于同一时间账号只能一个用户登录,请尽量使用后面账号测试</li>
                </ul>
            </div>
            <div class="footenter">
                <div class="copyRight">CopyRight © 2015&nbsp; <a href="">北京天生创想信息技术有限公司</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Powered by <a href="">天生创想OA政务版</a> V3.0</div>
            </div>
        </div>
        <!--/尾部-->
    </div>
    <script type="text/javascript">
        var loginBox = document.getElementById('loginBox');
        var setMiddle = function () {
            var middleH;
            var windoww = Math.max(document.body.clientWidth, document.documentElement.clientWidth),
                windowh = Math.max(document.body.clientHeight, document.documentElement.clientHeight);
            if (windowh <= 500 && windoww <= 950) {
                middleH = getMiddleH(1);
            } else if (windowh <= 500) {
                middleH = getMiddleH(1);
            } else if (windoww <= 950) {
                middleH = getMiddleH();
            } else {
                middleH = getMiddleH();
            }
            loginBox.style.marginTop =
            loginBox.style.marginBottom = middleH + 'px';
        };
        //获得居中高度
        function getMiddleH(flag) {
            var bgHeight = document.getElementById('bgHeight');
            var height = loginBox.clientHeight;
            if (!flag) {
                return (bgHeight.clientHeight - 54 - 65 - height) / 2;
            } else {
                return (500 - 54 - 65 - height) / 2;
            }
        }
        setMiddle();

        var placeHolderHandler = function () {
            if ($(this).val()) {
                $(this).prev().show();
            }
            else{
                $(this).prev().hide();
            }
        }

        $(function () {
            $(".placeholder").click(function () {
                $(this).next().focus();
            });
            $("input:text,input:password").focus(function () {
                $(this).prev().hide();
            }).blur(function () {
                if ($(this).val()=="") {
                    $(this).prev().show();
                }
                else {
                    $(this).prev().hide();
                }
            });

            $("input:text,input:password").each(function () {
                if ($(this).val() == "") {
                    $(this).prev().show();
                }
                else {
                    $(this).prev().hide();
                }
            });
        });
    </script>
</body>
</html>

