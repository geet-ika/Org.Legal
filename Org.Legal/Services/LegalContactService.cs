using Org.Legal.Brokers;
using Org.Legal.Models;

namespace Org.Legal.Services
{
    public class LegalContactService : ILegalContactService
    {
        private IStorageBroker storageBroker;

        public LegalContactService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<LegalContact> GetMyLegalContact(Employee employee)
        {
            LegalContact legalContact = null;

            while (legalContact == null && employee.EmployeeID != Guid.Empty)
            {
                legalContact = await this.storageBroker.GetLegalContact(employee.EmployeeID);

                if (legalContact == null)
                {
                    employee = employee.Manager;
                }
            }

            return legalContact;
        }
    }
}
