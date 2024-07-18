using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.IDataAccessLayer
{
    public interface IQuotesDal
    {
        Task<ResponseEntity<List<QuotesEntity>>> GetAllQuotes();
    }
}
