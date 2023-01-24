using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Infrastructure.HttpService.Models
{
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public enum RecordStatus
    {
        InActive = 1,
        Active = 2,
        Deleted
    }
    public enum Epilepsy
    {
        No = 0,
        Yes
    }
}
