using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Controllers
{
    public class PagerController : Controller
    {
        // GET: Pager
        public ViewResult Index(int pg = 1)
        {
            DB db = new DB();
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recscount = db.Users.Count();
            var pager = new Pager(recscount,pg,pageSize);
            int recSkip = (pg-1)*pageSize;
            List<User> users = db.Users.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(users);
        }
    }
}