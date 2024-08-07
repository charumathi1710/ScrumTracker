using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class EmployeeRepositoryDal:IEmployeeRepositoryDal
    {
        private readonly string _connectionString;

        public EmployeeRepositoryDal(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("dbcs");
        }

        public async Task<List<EmployeeScrumReport>> GetEmployeeScrumReportAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "GetEmployeeScrumReportMail"; 

                return (await connection.QueryAsync<EmployeeScrumReport>(query, commandType: CommandType.StoredProcedure)).ToList();
            }
        }
    }
}
