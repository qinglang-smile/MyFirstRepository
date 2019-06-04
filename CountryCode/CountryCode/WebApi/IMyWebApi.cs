using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.DataAnnotations;
using WebApiClient;

namespace CountryCode.WebApi
{
   // [HttpHost("http://www.webapiclient.com")]//如果接口IMyWebApi有多个方法且都指向同一服务器，可以将请求的域名抽出来放到HttpHost特性
    public interface IMyWebApi : IHttpApi
    {
        [HttpGet("http://ip.taobao.com/service/getIpInfo.php?ip={ipAddress}")]
        [JsonReturn]
        ITask<Root> GetCountryCode(string ipAddress);

    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 中国
        /// </summary>
        public string country  { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 广东
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 广州
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string county { get; set; }
        /// <summary>
        /// 电信
        /// </summary>
        public string isp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_id  { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string area_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string county_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isp_id { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }
}
