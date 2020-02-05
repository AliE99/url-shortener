using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace url_shortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        [HttpGet]
        public void Getsout(){
            Console.WriteLine("Hello");
        }

        [HttpPost]
        public void Postsout2(){
            Console.WriteLine("Bye");
        }
    }
}