using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using reactTest.Data;

namespace  reactTest.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class SomethingController : ControllerBase {

        [HttpPost]
        public object Post(SomethingModel info){
            Console.WriteLine(info.something);

            using (var db = new SomethingContext()){
                db.somethingModel.Add(info);
                db.SaveChanges();
            }
            //I get the string in json format. HOW TO CONVERT TO USEABLE OBJECT?? (BIND TO MODEL? FUCK NO TOO MUCH WORK) I WANT ANON OBJECT
            return new {name = "HEHEHEH"};
        }

    }
}