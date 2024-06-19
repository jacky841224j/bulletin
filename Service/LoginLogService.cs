using bulletin.Entity;
using bulletin.Models;

namespace bulletin.Service
{
    public class LoginLogService
    {
        public static async void Add(LoginLog loginLog)
        {
            try
            {
                using (var db = new Context())
                {
                    await db.LoginLogs.AddAsync(loginLog);
                }
            }
            catch (Exception ex)
            {
                //LogLib.Log(ex.Message);
            }
        }
    }
}
