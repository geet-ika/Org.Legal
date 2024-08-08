using Org.Legal.Models;

namespace Org.Legal.Services
{
    public interface ILegalContactService
    {
        ValueTask<LegalContact> GetMyLegalContact(Employee employee);
    }
}
