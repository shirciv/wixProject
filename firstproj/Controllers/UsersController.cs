using firstproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SQLite;
using System.Web.Http.Cors;




namespace firstproj.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        
        UsersDbService service = new UsersDbService();

        // GET: api/Users
    /*    public List<User> Get()
        {
            return UsersInput;
        }
        */

        // GET: api/Users/5
        public List<User> Get(int id)
        {
            return service.Get(id);
        }

        // POST: api/Users
        public void Post(User newUser)
        {
            service.insert(newUser);
        }


    }
}
