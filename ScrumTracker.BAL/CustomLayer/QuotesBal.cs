using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.DataAccessLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class QuotesBal:IQuotesBal
    {
        private IUnitofData UnitofData { get; }
        public QuotesBal(IUnitofData unitofData)
        {
            UnitofData = unitofData;
        }
        public async Task<ResponseEntity<List<QuotesEntity>>> GetAllQuotes()
        {
            return await UnitofData.QuotesDal.GetAllQuotes();
        }
    }
}
