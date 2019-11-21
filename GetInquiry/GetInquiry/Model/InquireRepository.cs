using Dapper;
using GetInquiry.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GetInquiry.Model
{
    public class InquireRepository: IInquiryRepository
    {
        public readonly String _connectionstring;
        public InquireRepository(String connectionstring)
        {
            _connectionstring = connectionstring;
        }
        public Inquiry GetInquiryById(Guid guid)
        {
            using (IDbConnection db = new SqlConnection(_connectionstring))
            {
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add("Id", guid, DbType.Guid, direction: ParameterDirection.Input);
                return db.Query<Inquiry>("dbo.GET_INQUIRY", dynamicParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<Inquiry> GetInquiries(Guid client_id, String department_address)
        {
            using (IDbConnection db = new SqlConnection(_connectionstring))
            {
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add("client_id", client_id, DbType.Guid, direction: ParameterDirection.Input);
                dynamicParams.Add("department_address", department_address, DbType.String, direction: ParameterDirection.Input);
                return db.Query<Inquiry>("dbo.GET_INQUIRIES", dynamicParams, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
