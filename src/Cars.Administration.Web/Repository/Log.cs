using System;
using System.Collections.Generic;
using System.Linq;
using Cars.Administration.Web.Domain;

namespace Cars.Administration.Web.Repository
{
    public class Log : ILog
    {
        private readonly IList<LogAction> _log;

        public Log()
        {
            _log = new List<LogAction>();
        }

        public void Add(LogAction logAction)
        {
            var id = _log.Any() ? _log.Max(x => x.LogActionId) + 1 : 1;
            logAction.LogActionId = id;
            logAction.PerformedAt = DateTime.Now;
            _log.Add(logAction);
        }

        public IEnumerable<LogAction> List()
        {
            return _log;
        }
    }
}