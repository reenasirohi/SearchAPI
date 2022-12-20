using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using SearchAPI.Controllers.API;
using SearchAPI.Models;
using System;
using System.IO;

namespace SearchAPITest
{
    public class SearchTest 
    {
        Mock<IWebHostEnvironment> mockEnvironment = new Mock<IWebHostEnvironment>();

        [SetUp]
        public void Setup()
        {
            string AssemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            mockEnvironment
                    .Setup(m => m.ContentRootPath)
                    .Returns(AssemblyPath);

        }



        /// <summary>
        /// Given a search term of “James”, when I enter the search term into the search input and
        /// click the ‘Search’ button, then the search results should include the records for “James
        /// Kubu” and “James Pfieffer”.
        /// </summary>

        [Test]
        public void GetJamesSearch()
        {
            var objUser = new UserController(mockEnvironment.Object);
            User[] result = objUser.GetUser("James");
            Assert.IsNotNull(result);
            Assert.AreEqual(2,result.Length);
        }

        /// <summary>
        /// Given a search term of “jam”, when I enter the search term into the search input and
        /// click the ‘Search’ button, then the search results should include the records for “James
        /// Kubu”, “James Pfieffer” and “Chalmers Longfut”.
        /// </summary>
        
        [Test]
        public void GetJamSearch()
        {
            
            var objUser = new UserController(mockEnvironment.Object);
            User[] result = objUser.GetUser("jam");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
        }

        /// <summary>
        /// Given a search term of “Katey Soltan”, when I enter the search term into the search
        /// input and click the ‘Search’ button, then the search results should include only the record
        /// for “Katey Soltan”.
        /// </summary>
       
        [Test]
        public void GetKateySoltanSearch()
        {
            
            var objUser = new UserController(mockEnvironment.Object);
            User[] result = objUser.GetUser("Katey Soltan");
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
        }

        /// <summary>
        /// Given a search term of “Jasmine Duncan”, when I enter the search term into the search
        /// input and click the ‘Search’ button, then no results should be returned.
        /// </summary>
        
        [Test]
        public void GetJasmineDuncanSearch()
        {
            var objUser = new UserController(mockEnvironment.Object);
            User[] result = objUser.GetUser("Jasmine Duncan");
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
        }

        /// <summary>
        /// Given an empty search term, when I click the ‘Search’ button I should be notified that I
        /// did not provide a search input and no results should be returned.
        /// </summary>
        
        [Test]
        public void GetBlankSearch()
        {            
            var objUser = new UserController(mockEnvironment.Object);
            User[] result = objUser.GetUser("");
            Assert.IsNotNull(result);
            Assert.AreEqual(0,result.Length);
        }



    }
}