using ManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Controllers
{
    
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44348/api");
        private readonly HttpClient client;
        public static DB db = new DB();
        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        } 
        private IEnumerable<User> GetAccounts()
        {
            var accounts = new DB();
            var res = from c in accounts.Users
                      select c;

            return res;
        }
        private IEnumerable<UserProfile> GetProfiles()
        {
            var accounts = new DB();
            var res = from c in accounts.Profiles
                      select c;

            return res;
        }
        [HttpGet]
        //public ActionResult Index()
   /* //    {
            var accs = GetAccounts().ToList();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                accs = JsonConvert.DeserializeObject<List<User>>(data);
            }
            return View(accs);
        }*/
        public ActionResult Index(string searchBy, string search)
        {
            var accs = GetAccounts().ToList();
     
            if (searchBy == "ID")
            {
                return View(accs.Where(x => x.Id == Int32.Parse(search) || search == null).ToList());
            }
            return View(accs.Where(x => x.Username == search || search == null).ToList());
        }
        // public ActionResult Index(string searching)
        //{
        //  return View(GetAccounts().Where(x =>
        // x.Username.Contains(searching)).ToList());
        //}
        public ActionResult Details(string Id)
        {
            return View(GetProfiles().Where(p => p.UserProfileId == Int64.Parse(Id)).FirstOrDefault());

        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            return View(GetAccounts().Where(p => p.Id == Int64.Parse(Id)).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var exist = GetAccounts().FirstOrDefault(u => u.Id == user.Id);
                if (exist != null)
                {
                    exist.Username = user.Username;
                    exist.Password = user.Password;
                    exist.Email = user.Email;
                    db.Entry(exist).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "An error occurred while updating the user.");

            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Delete(string Id)
        {
            return View(GetAccounts().Where(p => p.Id == Int64.Parse(Id)).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Delete(User user)
        { 
           
                    db.Entry(user).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Index");

        }
    }
    }
