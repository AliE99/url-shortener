using System;
using System.Collections.Generic;
using System.Threading.Tasks;
// using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Models;   
using src.Contexts;
using System.Linq;
namespace src.Controller
{
    [Route("/redirect/{*shortUrl}")]
    [ApiController]
    public class RedirectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RedirectController(AppDbContext context){
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<string> Get(string shortUrl)
        {
            var url = _context.urls.Find(shortUrl);
            return Redirect(url.longUrl);
        }

    }
}