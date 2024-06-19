using bulletin.Business;
using bulletin.Dto;
using bulletin.Models;
using bulletin.Service;
using bulletin.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;

namespace bulletin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("token");
            HttpContext.Session.Clear();
            LoginVm model = new();
            model.account = "";
            model.password = "";
            return View(model);
        }

        public IActionResult SignIn(LoginVm model)
        {
            var ip = HttpContext.Connection.RemoteIpAddress;

            //取得使用者裝置
            var platform = GetPlatForm(Request.Headers["User-Agent"]);

            try
            {
                // 1. 驗證 IP 允許登錄
                //LoginBiz.CheckWhiteList(ip, model.LoginProvider);

                // 2. 驗證碼驗證
                //string captchaCode = GetSession("Captcha.Code");
                // LoginBiz.AuthCaptcha(model.code, captchaCode);

                // 3. 帳密密碼驗證
                var admin = LoginBiz.Authenticate(model.account.ToString(), model.password);

                // 4. 這裡不論成功與否, 紀錄 login 行為 
                LoginLogService.Add(new LoginLog
                {
                    Admin_pk = admin.Pk,
                    LoginDate = DateTime.UtcNow,
                    LoginIP = ip.ToString(),
                    IsSuccessful = true,
                });

                //寫入登入log
                AdminUserBiz.UpdateLoginInfo(new UpdateLoginInfoDto
                {
                    pk = admin.Pk,
                    LastLoginDate = DateTime.UtcNow,
                    LastLoginIP = ip.ToString(),
                });               
            }
            catch (Exception ex)
            {
                return View("Index", model);
            }

        }

        /// <summary>
        /// 取得使用者裝置
        /// </summary>
        /// <param name="userAgent">Request.Headers["User-Agent"]</param>
        /// <returns></returns>
        public string GetPlatForm(string userAgent)
        {
            string platform = "Unknown";

            if (userAgent.Contains("Windows NT"))
            {
                platform = "Windows";
            }
            else if (userAgent.Contains("Macintosh"))
            {
                platform = "macOS";
            }
            else if (userAgent.Contains("iPhone") || userAgent.Contains("iPad"))
            {
                platform = "iOS";
            }
            else if (userAgent.Contains("Android"))
            {
                platform = "Android";
            }
            else if (userAgent.Contains("Linux"))
            {
                platform = "Linux";
            }

            return platform;
        }
    }
}
