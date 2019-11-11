using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeSpoked.Repo.Models;
using BeSpoked.Repo;

namespace BeSpoked.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly BeSpokedRepository _repository;

        public ReportController(BeSpokedRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Report
        [HttpGet]
        public ActionResult<IEnumerable<CommissionReport>> GetReport()
        {
            var items=_repository.GetCommissionReport();

            if(items!=null && items.Count()>0)
            {
                return Ok(items);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
