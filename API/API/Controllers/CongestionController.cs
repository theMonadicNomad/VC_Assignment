using CongestionCalculator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongestionController : ControllerBase
    {

        // POST api/<ValuesController>
        [HttpPost("{vehicle}")]
        public int Post(string vehicle, [FromBody] string[] dateTimes)
        {

            CongestionTaxCalculator congestionTaxCalculator = new CongestionTaxCalculator();
            DateTime[] newDateTimes = dateTimes.Select(dateTime => DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss",
                                                   System.Globalization.CultureInfo.InvariantCulture)).ToArray();
            if (vehicle == "Motorcycle")
                return congestionTaxCalculator.GetTax(new Motorcycle(), newDateTimes);

            else if (vehicle == "Tractor")
                return congestionTaxCalculator.GetTax(new Tractor(), newDateTimes);

            else if (vehicle == "Emergency")
                return congestionTaxCalculator.GetTax(new Emergency(), newDateTimes);

            else if (vehicle == "Diplomat")
                return congestionTaxCalculator.GetTax(new Diplomat(), newDateTimes);

            else if (vehicle == "Foreign")
                return congestionTaxCalculator.GetTax(new Foreign(), newDateTimes);


            else if (vehicle == "Military")
                return congestionTaxCalculator.GetTax(new Military(), newDateTimes);

            else if (vehicle == "Car")
                return congestionTaxCalculator.GetTax(new Car(), newDateTimes);

            else throw new Exception("Invalid vehicle category :");

        }

    }
}
