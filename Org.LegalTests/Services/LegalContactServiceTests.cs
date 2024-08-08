using Org.Legal.Brokers;
using Moq;
using Tynamix.ObjectFiller;
using Org.Legal.Models;
using Force.DeepCloner;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;


namespace Org.Legal.Services.Tests
{
    public partial class LegalContactServiceTests
    {
        public Mock<IStorageBroker> storageBrokerMock;
        public ILegalContactService legalContactService;

        public LegalContactServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.legalContactService = new LegalContactService(this.storageBrokerMock.Object);
        }

        [Fact]
        public async Task GetMyLegalContactShouldReturnLegalContact()
        {
            // given
            (Employee randomEmployee, LegalContact randomLegalContact) = CreateRandomEmployeeHeirarchy();
            Employee expectedEmployee = randomEmployee;
            Employee selectedEmployeeWithDevices = randomEmployee;
            LegalContact expectedLegalContact = randomLegalContact.DeepClone();

            this.storageBrokerMock.Setup(broker =>
              broker.GetLegalContact(randomLegalContact.EmployeeID))
                  .ReturnsAsync(randomLegalContact);

            // when
            LegalContact actualLegalContact = await this.legalContactService.GetMyLegalContact(randomEmployee);

            // then
            actualLegalContact.Should().BeEquivalentTo(expectedEmployee);

            this.storageBrokerMock.Verify(broker =>
                broker.GetLegalContact(randomEmployee.EmployeeID),
                    Times.Once);

        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
        
        private static int GetRandomNumber(int max) =>
            new IntRange(min: 2, max: max).GetValue();

        private static (Employee, LegalContact) CreateRandomEmployeeHeirarchy()
        {
            int randomNumber = GetRandomNumber();
            int numberOfEmployee = randomNumber;
            
            Employee employeeToReturn = new Employee();
            Employee currentEmployee = employeeToReturn;
            while(numberOfEmployee > 0)
            {
                
                Employee managerEmployee = new Employee();
                currentEmployee.Manager = managerEmployee;
                currentEmployee = managerEmployee;

                numberOfEmployee--;
            }

            int legalContactLevel = GetRandomNumber(randomNumber);

            currentEmployee = employeeToReturn;
            while (legalContactLevel-- > 0)
            {
                currentEmployee = currentEmployee.Manager;
            }

            LegalContact legalContact = new LegalContact()
            {
                EmployeeID = currentEmployee.EmployeeID,
                LawyerID = Guid.NewGuid()
            };

            return (employeeToReturn, legalContact);

        }
    }
}