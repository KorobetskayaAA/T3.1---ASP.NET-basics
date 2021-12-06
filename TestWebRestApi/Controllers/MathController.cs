using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpGet("sum")]
        public double GetSum(double a, double b)
        {
            return a + b;
        }

        [HttpGet("sum")]
        public double GetSum(double[] a)
        {
            return a.Sum();
        }

        [HttpGet("sin/{value}")]
        public double GetSin(double value)
        {
            return Math.Sin(value);
        }

        [HttpGet("circle/{radius}")]
        public object GetCircle(double radius)
        {
            return new { perimeter = 2 * Math.PI * radius, area = Math.PI * radius * radius };
        }

        [HttpGet("/circle")]
        [HttpGet("circle")]
        public object GetCircleParam(double radius)
        {
            return GetCircle(radius);
        }

        [HttpPost("/circle")]
        [HttpPost("circle")]
        public object PostCircle([FromBody] double radius)
        {
            return GetCircle(radius);
        }
    }
}
