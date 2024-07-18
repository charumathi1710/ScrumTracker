using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.CustomLayer;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.Entity;

namespace ScrumTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private IUnitofWork UnitOfWork { get; }
        public QuotesController(IUnitofWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        [HttpGet("GetAllQuotes")]
        public async Task<ActionResult<List<QuotesEntity>>> GetAllQuotes()
        {
            var result = await UnitOfWork.QuotesBal.GetAllQuotes();
            return Ok(result);
        }
    }
}
