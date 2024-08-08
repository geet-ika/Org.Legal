using System;
using Org.Legal.Models;

namespace Org.Legal.Brokers
{
    public interface IStorageBroker
    {
        ValueTask<LegalContact> GetLegalContact(Guid employeeID);
    }
}
