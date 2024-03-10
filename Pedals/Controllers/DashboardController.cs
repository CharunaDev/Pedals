using Pedals.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pedals.Models;

namespace Pedals.Controllers
{
    public class DashboardController : Controller
    {
        public IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;

        }


        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getOrderDetails(DateTime fromDate, DateTime toDate, string status, int PageNumber, int PageSize)
        {
            DateTime FromDate = Convert.ToDateTime(fromDate);
            DateTime ToDate = Convert.ToDateTime(toDate);
            var orderDet = _dashboardService.GetOrderDetails(FromDate, ToDate, status, PageNumber, PageSize);
            return Json(orderDet, JsonRequestBehavior.AllowGet);
        }
    }
}