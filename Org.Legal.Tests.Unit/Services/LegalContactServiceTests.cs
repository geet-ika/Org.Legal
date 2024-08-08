
using Moq;
using Org.Legal;

namespace Org.Legal.Tests.Unit.Services
{
    public partial class LegalContactServiceTests
    {
        public Mock<IStorageBroker> storageBroker;
        public ILegalContactService

                    public LabServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.labService = new LabService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

    }
}
