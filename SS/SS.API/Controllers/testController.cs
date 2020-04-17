//
using System;
using System.Linq;
//
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//
//

namespace SS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class testController : ControllerBase
    {
        // [HttpGet]
        // public IActionResult GetAction()
        // {
        //     // int[] A = { 1, 1000, 80, -91 };
        //     int[] A = { 47, 1900, 1, 90, 45 };

        //     int sum = 0;
        //     int length = A.Length;
        //     for (int i = 0; i < length; i++)
        //     {
        //         var value = A[i];
        //         var abs = Math.Abs(value);
        //         if (abs > 9 && abs < 100)
        //         {
        //             sum += value;
        //         }
        //     }

        //     return Ok(sum);
        // }

        [HttpGet]
        public IActionResult GetAction()
        {
            String s = "!";

            char c = s[0];
            if (Char.IsUpper(c))
            {
                // return "upper";
                return Ok("upper");
            }
            else if (Char.IsLower(c))
            {
                // return "lower";
                return Ok("lower");
            }
            else if (Char.IsDigit(c))
            {
                // return "digit";
                return Ok("digit");
            }
            else
            {
                // return "other";
                return Ok("other");
            }

            return Ok();
        }
    }
}