using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UpdateQ.Simulator.Model;

namespace UpdateQ.Api.Controllers
{
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [Route("api/values")]
        [HttpGet]
        public IActionResult Get()
        {
            //_logger.LogDebug("Test debug log!");
            //_logger.LogCritical("This is critical log!");

            return Ok(new string[] { "value1", "value2" });
            //return new string[] { "value1", "value2" };

        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [Route("api/values")]
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            var asd = "here";

            return Ok();
        }

        [Route("api/products")]
        [HttpPost]
        public IActionResult PostProductData([FromBody]Product productData, CancellationToken cToken)
        {
            var asd = "Product data received";

            return Ok(productData);
        }

        [Route("api/sensors")]
        [HttpPost]
        public void PostSensorsData([FromBody]SensorDto sensorData, CancellationToken cToken)
        {
            var asd = "Sensor data received";

            //return Ok(asd);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{

        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
