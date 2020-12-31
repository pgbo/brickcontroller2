using BrickController2.CreationManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BrickController2.ProfileServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreationController : ControllerBase
    {
        private readonly ILogger<CreationController> _logger;

        public CreationController(ILogger<CreationController> logger)
        {
            _logger = logger;
        }

        public ActionResult<IEnumerable<Creation>> Get()
        {
            throw new NotImplementedException();
        }

        public ActionResult<Creation> Get(string name)
        {
            throw new NotImplementedException();
        }

        public ActionResult Post([FromBody]Creation creation)
        {
            throw new NotImplementedException();
        }
    }
}
