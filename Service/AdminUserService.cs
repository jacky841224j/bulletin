using bulletin.Dto;
using bulletin.Entity;
using bulletin.Models;

namespace bulletin.Service
{
    public class AdminUserService
    {
        public static Admin FindByAccount(string account)
        {
            try
            {
                using (var db = new Context())
                {
                    return db.Admins.Where(x => x.Account == account).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //LogLib.Log(ex.Message);
                return null;
            }
        }

        public static async void UpdateLoginInfo(UpdateLoginInfoDto dto)
        {
            try
            {
                using (var db = new Context())
                {
                    var admin = db.Admins.Where(x => x.Pk == dto.pk).FirstOrDefault();

                    if (admin != null)
                    {
                        admin.LastLoginDate = dto.LastLoginDate;
                        admin.LastLoginIP = dto.LastLoginIP;
                    }

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }
        
    }
}
