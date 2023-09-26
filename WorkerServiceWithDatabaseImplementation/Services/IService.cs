using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceWithDatabaseImplementation.Models;

namespace WorkerServiceWithDatabaseImplementation.Services
{
    public interface IService
    {
        bool AddDetails(Details add);
    }
}
