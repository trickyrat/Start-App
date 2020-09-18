// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System.Collections.Generic;

namespace Start_App.Domain.Entities
{
    /// <summary>
    /// 省份类
    /// </summary>
    public class Province
    {
        public int Id { get; set; }
        /// <summary>
        /// 省份代码
        /// </summary>
        public string ProvinceCode { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
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

        public List<City> Cities { get; set; }
    }
}
