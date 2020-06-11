using System.Collections.Generic;

namespace Start_App.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        /// <summary>
        /// 市代码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        public string CityName { get; set; }

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


        public string ProvinceCode { get; set; }

        public Province Province { get; set; }


        public List<Area> Areas { get; set; }

    }
}
