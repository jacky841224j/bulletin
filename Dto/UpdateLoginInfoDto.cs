namespace bulletin.Dto
{
    public class UpdateLoginInfoDto
    {
        public int pk { get; set; }

        /// <summary>
        /// 最後登入日期
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 最後登入IP
        /// </summary>
        public string? LastLoginIP { get; set; } = string.Empty;
    }
}
