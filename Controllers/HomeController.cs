using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        AppContext appdb = new AppContext();

        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult GetTableData(TableModel model)
        {
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Validation(LoginModel model)
        {
            foreach (LoginModel x in appdb.LoginContext)
            {
                if (x.Login == model.Login)
                {
                    ModelState.AddModelError("Login", "Login is not origin");
                }
            }
            if (ModelState.IsValid)
            {
                return View("Main", "Auth complited");

            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Params()
        {
            Dictionary<string,string> dict=new Dictionary<string,string>();
            foreach (String key in Request.QueryString.AllKeys)
            {
                dict.Add(key,Request.QueryString[key]);
            }
            return View( dict);
            
        }

        public ActionResult Summ()
        {
            return View();
        }

        [HttpPost]
        public string Summ(string arr)
        {

            var sum = Regex.Split(arr, @"[^-\d]+").Select(p => string.IsNullOrEmpty(p) ? 0 : int.Parse(p)).Sum();
               
          
            return sum.ToString();
        }
     }

   
        
	
}