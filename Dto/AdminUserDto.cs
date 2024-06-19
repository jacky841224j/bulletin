namespace bulletin.Dto
{
    public class AdminUserDto
    {
        /// <summary>  </summary>
        public int pk { get; set; }
        /// <summary> 用户名 </summary>
        public string account { get; set; }
        /// <summary> 用戶角色 </summary>
        public int role { get; set; }
        /// <summary> 密码 </summary>
        public string password { get; set; }
        /// <summary> 状态：0禁用，1启用 </summary>
        public bool status { get; set; }

        /// <summary> 最后一次登录时间 </summary>
        public DateTime? last_login_time { get; set; }

        /// <summary> 登录ip </summary>
        public string? last_login_ip { get; set; }
    }
}
