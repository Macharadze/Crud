using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ManagementSystem.Controllers.API
{
    public class UserController : ApiController
    {
        private DB _context;
        private IEnumerable<User> GetAccounts()
        {
            var accounts = new DB();
            var res = from c in accounts.Users
                      select c;

            return res;
        }
        public UserController()
        {
            _context = new DB();
        }
        //get api/user
        public IEnumerable<User> GetUsers()
        {
            return GetAccounts().ToList();
        }
        //Get api/user/1
        public User GetUser(int id)
        {
          var user = GetAccounts().SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);   
            }
            return user;
        }
        //post api/user
       /* [HttpPost]
        public User CrreateCustomer(User user)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        //put api/user/1
        public void Update(int id,User user) {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var userIndb= GetAccounts().SingleOrDefault(c=>c.Id==id);
            if(userIndb == null ) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            userIndb.Username=user.Username;
            userIndb.Password=user.Password;
            userIndb.Email=user.Email;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var user = GetAccounts().SingleOrDefault(c=> c.Id==id);
            if(user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }*/
    }
}
