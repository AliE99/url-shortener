using System;
using System.Collections.Generic;
using System.Threading.Tasks;
// using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Models;   
using src.Contexts;
using System.Linq;
using System.Text.RegularExpressions;

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
        public ActionResult Get(string shortUrl)
        {
            Url url = new Url();
            
            if(shortUrl==null)
            {
                return BadRequest();
            }

            if(shortUrl.Length != 8){
                return BadRequest();
            }
            
            if(!Regex.IsMatch(shortUrl, @"^[a-zA-Z]+$")) 
            {
                return BadRequest();
            }


            if((_context.Find(url.GetType(),shortUrl) == null)) 
            {  
                return NotFound();
            }

            url = _context.urls.Find(shortUrl);
            return Redirect(url.longUrl);
        }

    }
}