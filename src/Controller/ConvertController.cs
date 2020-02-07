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
    [Route("/urls")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConvertController(AppDbContext context){
            _context = context;
        }

        [HttpPost]
        public ActionResult<string> getLongUrl([FromBody]Url url){
            if(!isValid(url.longUrl))
            {
                return "The Url is not valid";
            }

            makeShortUrl(url);
            _context.urls.Add(url);
            _context.SaveChanges();
            return url.shortUrl;
        }


        public void makeShortUrl(Url url){
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            url.shortUrl = finalString;

        }

        public Boolean isValid(string url){
            Regex rx = new Regex(@"((www\.|(http|https|ftp|news|file)+\:\/\/)[_.a-z0-9-]+\.[a-z0-9\/_:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])");
            Match match =  rx.Match(url);
            if(match.Success){
                return true;
            }else{
                return false;
            }
 
        }
    }
}