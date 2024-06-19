using bulletin.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace bulletin.Models
{
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pk { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 身分
        /// </summary>
        public RoleEnum Role { get; set; }

        /// <summary>
        /// 最後登入日期
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 最後登入IP
        /// </summary>
        public string? LastLoginIP { get; set; } = string.Empty;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remark { get; set; } = string.Empty;

        /// <summary>
        /// 用户状态
        /// </summary>
        public StatusEnum Status { get; set; }

        public virtual ICollection<LoginLog> LoginLogs { get; set; }
    }
}
