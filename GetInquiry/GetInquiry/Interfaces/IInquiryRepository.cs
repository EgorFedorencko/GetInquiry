using GetInquiry.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInquiry.Interfaces
{
    public interface IInquiryRepository
    {
        Inquiry GetInquiryById(Guid guid);
        IEnumerable<Inquiry> GetInquiries(Guid client_id, String department_address);
    }
}
