using System;
using Xunit;
using RA;
using System.Text.RegularExpressions;

namespace test
{
    public class ConvertTest
    {
        [Fact]
        public void TestValidating() 
        {
            var body = new 
            {
                LongUrl = "http://alibaba.ir"
            };
            new RestAssured()
             .Given()
                .Name("long url validation")
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestBody("Validation", u => Regex.IsMatch(body.LongUrl, @"((www\.|(http|https|ftp|news|file)+\:\/\/)[_.a-z0-9-]+\.[a-z0-9\/_:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])"))
                .TestStatus("Status code Test", s => s == 200)
                .AssertAll();  
        }
        
    }
}