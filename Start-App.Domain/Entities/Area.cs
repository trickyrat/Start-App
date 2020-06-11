using System.Collections.Generic;

namespace Start_App.Domain.Entities
{
    /// <summary>
    /// 区域类
    /// </summary>
    public class Area
    {
        public int Id { get; set; }
        /// <summary>
        /// 区代码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }
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
        public int Sort { get; set; }
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


        public string CityCode { get; set; }
        public City City { get; set; }

        public List<Street> Streets { get; set; }
    }
}
