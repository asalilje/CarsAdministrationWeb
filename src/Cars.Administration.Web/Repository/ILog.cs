using System.Collections.Generic;
using Cars.Administration.Web.Domain;

namespace Cars.Administration.Web.Repository
{
    public interface ILog
    {
        void Add(LogAction logAction);
        IEnumerable<LogAction> List();
    }
}