using System;
using System.Collections.Generic;
using System.Threading.Tasks;
// using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Models;   
using src.Contexts;


namespace src.Controller
{
    [Route("api/save")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConvertController(AppDbContext context){
            _context = context;
        }

        [HttpPost]
        public void getLongUrl([FromBody]Url url){

            _context.urls.Add(url);
        }


        public Url makeShortUrl(Url longUrl){
            Url  shortUrl = longUrl;
            return shortUrl;
        }
    }
}