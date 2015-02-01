using System.Transactions;
using System.Web;
using Cars.Administration.Web.Infrastructure.Tasks;
using Cars.Administration.Web.Repository;

namespace Cars.Administration.Web.Infrastructure
{
    public class TransactionPerRequest : IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        private readonly ICarRepository _carRepository;
        private readonly HttpContextBase _httpContext;

        public TransactionPerRequest(ICarRepository carRepository, HttpContextBase httpContext)
        {
            _carRepository = carRepository;
            _httpContext = httpContext;
        }

        void IRunOnEachRequest.Execute()
        {
            // start transaction
        }

        void IRunOnError.Execute()
        {
            // set error flag in context
        }

        void IRunAfterEachRequest.Execute()
        {
            // commit or rollback
        }
    }
}