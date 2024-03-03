using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Build.Utilities;
using Microsoft.Extensions.Logging;
using Pedals.Models;
using Pedals.Services;

namespace Pedals.Controllers
{
    public class AccountController : Controller
    {

        public IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;

        }


        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {

            try
            {
                connectionString();
                con.Open();
                cm.Connection = con;
                cm.CommandText = "select * from sales.logins where username=@username and password = @password";
                cm.Parameters.AddWithValue("@username", acc.username);
                cm.Parameters.AddWithValue("@password", acc.password);
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    return RedirectToAction("Dashboard", "Dashboard");
                    // Return a success view
                }
                else
                {
                    con.Close();
                    return View("Error"); // Return an error view
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return View("Error"); // Return an error view
            }
            finally
            {
                con.Close(); // Ensure connection is closed even if an exception occurs
            }
        }

        void connectionString()
        {
            string connectionString = "Data Source=LAPTOP-5QSPL81Q\\FROZTY;Initial Catalog=Pedals;User ID=sa;Password=1234;MultipleActiveResultSets=True;App=EntityFramework";
            con.ConnectionString = connectionString;
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getStaff(int? staff_id)
        {
            //int Staff_id = 11;
            var staffDetails = _accountService.GetStaffDetails(staff_id);
            return Json(staffDetails, JsonRequestBehavior.AllowGet);
        }


    }
}