using System;
using Xunit;
using RA;
namespace test
{
    public class RedirectTest
    {
        [Fact]
        public void nullGet(){
            new RestAssured()
        		.Given()
                    .Name("Null Get")
                    .Header("content-type", "application/json")
                    .Header("accept-Encoding", "utf-8")
                .When()
                    .Get("http://localhost:5000/redirect/")
                    .Then()
                    .TestStatus("Null Get", r => r == 400)
                    .AssertAll();
        }
		
		[Fact]
		public void shortUrlLength()
        {
			new RestAssured()
				.Given()
					.Name("shorturl length")
					.Header("content-type", "application/json")
				.When()
					.Get("http://localhost:5000/redirect/fnefladeca")
					.Then()
					.TestStatus("short url length should be less than 8 characters",r => r == 400)
					.AssertAll();

        }
        
		[Fact]
        public void noDigits()
        { 
            new RestAssured()
            	.Given()
                	.Name("is digit")
                	.Header("content-type", "application/json")
              	.When()
                	.Get("http://localhost:5000/redirect/bla1bla2bla3")
                	.Then()
                	.TestStatus("it has digits", r => r == 400)
                	.AssertAll();
        }
    

		[Fact]
        public void notFound()
        {
            
            new RestAssured()
            	.Given()
					.Name("Not Found ")
					.Header("content-type", "application/json")
					.Header("Accept-Encoding", "gzip, deflate, br")
            	.When()
					.Get("http://localhost:5000/redirect/blablabla")
					.Then()
					.TestStatus("Not Found", r => r == 404)
					.AssertAll();

        
        }
   


    }
}