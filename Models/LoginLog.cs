using System.ComponentModel.DataAnnotations.Schema;

namespace bulletin.Models
{
    public class LoginLog
    {
        /// <summary>
        /// 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int Admin_pk { get; set; }

        /// <summary>
        /// 登入日期
        /// </summary>
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// 登入IP
        /// </summary>
        public string LoginIP { get; set; } = string.Empty;

        /// <summary>
        /// 登入結果
        /// </summary>
        public bool IsSuccessful { get; set; }

        [ForeignKey("Admin_pk")]
        public virtual Admin Admin { get; set; }
    }
}
