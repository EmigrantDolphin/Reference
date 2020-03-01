using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;

namespace reactTest.Controllers {
    public class CustomDependencyModel : ICustomDependency{

        public void WriteMessage(string message){
            Console.WriteLine(message);
        }

    }

    public interface ICustomDependency {
        void WriteMessage(string message);
    }
    
    [ApiController]
    [Route("[controller]")]
    public class CustomDependencyController : ControllerBase {
        private readonly ICustomDependency _customDependency;
        public CustomDependencyController(ICustomDependency customDependency){
            _customDependency = customDependency;
        }

        [Authorize]
        [HttpGet]
        public object Get(){
            _customDependency.WriteMessage("DEEZ NUTZ");
            return new { dib = "asd"};
        }

        [HttpGet("Login")]
        public object GetLogin(){
            var someClaim = new List<Claim>(){
                new Claim(ClaimTypes.Name, "bob"),
                new Claim(ClaimTypes.Email, "bob@fmail.com")
            };

            var someIdentity = new ClaimsIdentity(someClaim, "Someones Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { someIdentity });

            Console.WriteLine("Im in LOGIN");
            HttpContext.SignInAsync(userPrincipal);

            return new {test = ":)"};
        }

    }





}