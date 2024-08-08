using Org.Legal.Models;

namespace Org.Legal.Brokers
{
    public class StorageBroker : IStorageBroker
    {
        public ValueTask<LegalContact> GetLegalContact(Guid employeeID)
        {
            return ValueTask.FromResult<LegalContact>(null);
        }
    }
}
