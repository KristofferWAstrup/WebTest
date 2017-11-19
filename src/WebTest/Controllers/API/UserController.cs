using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebTest.Models.API;

namespace WebTest.Controllers.API
{
    public class UserController : ApiController
    {
        private static List<User> UserList = new List<Models.API.User>
        {

        };

        // GET: api/User
        public IEnumerable<User> Get()
        {
            return UserList;
        }

        // GET: api/User/5
        public User Get(Guid id)
        {
            return UserList.SingleOrDefault(u => u.id == id);
        }

        // POST: api/User
        public void Post([FromBody]User value)
        {
            value.id = Guid.NewGuid();
            UserList.Add(value);
        }

        // PUT: api/User/5
        public void Put(Guid id, [FromBody]User value)
        {
            Delete(id);
            value.id = id;
            UserList.Add(value);
        }

        // DELETE: api/User/5
        public void Delete(Guid id)
        {
            var user = Get(id);
            if (user == null) return;
            UserList.Remove(user);
        }
    }
}
