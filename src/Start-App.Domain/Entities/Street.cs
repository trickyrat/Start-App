namespace Start_App.Domain.Entities
{
    /// <summary>
    /// 街道类
    /// </summary>
    public class Street
    {
        public int Id { get; set; }
        /// <summary>
        /// 街道名称
        /// </summary>
        public string StreetName { get; set; }
        /// <summary>
        /// 街道编号
        /// </summary>
        public string StreetCode { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string GMTCreate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string GMTModified { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }


        public string AreaCode { get; set; }
        public Area Area { get; set; }
    }
}
