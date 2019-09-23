using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private ActivityController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Json(DAL.Activity.Instance.GetCount());
        }
        [HttpGet("verifyCount")]
        public ActionResult GetVerifyCount()
        {
            return Json(DAL.Activity.Instance.GetVerifyCount());
        }
            
      [HttpGet("recommend")]
      public ActionResult GetRecommend()
        {
            var result = DAL.Activity.Instance.GetRecommend();
            if (result != null)
                return Json(Result.Ok(result));
            else
                return Json(Result.Err("记录数为0"));
            }
        [HttpGet("end")]
        public ActionResult GetEnd()
        {
            var result = DAL.Activity.Instance.GetEnd();
            if (result != null)
                return Json(Result.Ok(result));
            else
                return Json(Result.Err("记录数为0"));
        }
        [HttpGet("names")]
        public ActionResult GetNames()
        {
            var result = DAL.Activity.Instance.GetActivityNames();
            if (result.Count() == 0)
                return Json(Result.Err("没有任何活动"));
            else
                return Json(Result.Ok(result));
        }
    }
   
}
