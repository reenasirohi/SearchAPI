using Newtonsoft.Json;
using SearchAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAPI.DataAccess
{
    public class JsonDB
    {
        public JsonDB()
        {

        }

        /// <summary>
        /// Below method reads the json data from json file
        /// </summary>
        /// <param name="_hostingEnvironment"></param>
        /// <returns></returns>
        public Models.User[] getJsonData(Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment)
        {

            var rootPath = _hostingEnvironment.ContentRootPath; 

            var fullPath = Path.Combine(rootPath, "DataAccess/User.json"); 

            var jsonData = System.IO.File.ReadAllText(fullPath);

            if (string.IsNullOrWhiteSpace(jsonData)) return null; 

            var users = JsonConvert.DeserializeObject<User[]>(jsonData); 

            return users;

        }
    }
}
