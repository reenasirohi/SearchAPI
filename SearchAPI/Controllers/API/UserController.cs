using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SearchAPI.DataAccess;
using SearchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAPI.Controllers.API
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UserController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Below method returns all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("user/")]
        public User[] T()
        {
            JsonDB objsJsonDB = new JsonDB();
            Models.User[] users = objsJsonDB.getJsonData(_hostingEnvironment);
            if (users == null || users.Length == 0) return null;
            return users;
        }


        /// <summary>
        /// Below method returns the user data on the basis of search string
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("user/{search}")]
        public User[] GetUser(string search)
        {
            var user = Array.Empty<User>();
                
            if (search !=null && search.Length>0)
            {
                JsonDB objsJsonDB = new JsonDB();
                Models.User[] users = objsJsonDB.getJsonData(_hostingEnvironment);

                if (users == null || users.Length == 0) return null;

                user = Array.FindAll(users, x => (x.First_Name + " " + x.Last_Name).Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            return user;


        }

    }
}
