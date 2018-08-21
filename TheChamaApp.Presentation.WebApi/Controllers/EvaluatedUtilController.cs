using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    //[Produces("application/json")]
    //[Route("api/EvaluatedUtil")]
    [Route("api/[controller]")]
    public class EvaluatedUtilController : BaseController
    {

        //// POST api/csvtest/import
        //[HttpPost]
        //[Route("import")]
        //public IActionResult Import([FromBody]List<Domain.Entities.Evaluated> value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    else
        //    {
        //        List<Domain.Entities.Evaluated> data = value;
        //        return Ok();
        //    }
        //}
    }
}