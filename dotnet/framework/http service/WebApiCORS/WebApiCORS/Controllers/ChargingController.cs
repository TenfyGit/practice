using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCORS.Extensions;

namespace WebApiCORS.Controllers
{
    public class ChargingController : BaseApiController
    {
        [HttpGet]
        public string GetAllChargingData()
        {
            return "Success";
        }
        /// <summary>
        /// 得到当前Id的所有数据
        /// </summary>
        /// <param name="id">参数Id</param>
        /// <returns>返回数据</returns>
        [HttpGet]
        public string GetAllChargingData(string id)
        {
            return "ChargingData" + id;
        }
	}
}