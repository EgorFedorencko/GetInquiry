using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInquiry.Interfaces;
using GetInquiry.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GetInquiry.Controllers
{
   // [ApiController]
    //[Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInquiryRepository _repository;
        public HomeController(ILogger<HomeController> logger, IInquiryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult GetInquiryById([FromBody]Request_id request_id)
        {

            if (request_id == null)
                return BadRequest();

            if (request_id.guid == null)
                return BadRequest();

            Inquiry inquiry = _repository.GetInquiryById(request_id.guid);

            if (inquiry == null)
                return NotFound();

            return Ok(inquiry);
        }

        [HttpPost]
        public IActionResult GetInquiries([FromBody]ClientId_Department clientwithdepart)
        {
            if (clientwithdepart.client_id == null)
                return BadRequest();
            if (clientwithdepart.department_address == null)
                return BadRequest();

            return Ok(_repository.GetInquiries(clientwithdepart.client_id, clientwithdepart.department_address));
        }
    }
}
