using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheChamaApp.Application.IApplication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheChamaApp.Presentation.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class StateController : Controller
    {
        #region # Propriedades

        private readonly IStateApplication _IStateApplication;

        #endregion

        #region # Constructor

        public StateController(IStateApplication stateApplication)
        {
            _IStateApplication = stateApplication;
        }

        #endregion

        #region # Actions

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get() {

            var ListState = _IStateApplication.GetAll();
            return Ok(ListState);
        }
        #endregion

        /*

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
