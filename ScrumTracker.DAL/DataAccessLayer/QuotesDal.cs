using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class QuotesDal:IQuotesDal
    {
        private readonly ApplicationDBContext _context;

        public QuotesDal(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ResponseEntity<List<QuotesEntity>>> GetAllQuotes()
        {
            var quotesStatus = await _context.Quotes.ToListAsync();
            return new ResponseEntity<List<QuotesEntity>>
            {
                Result = quotesStatus,
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }
    }
}
