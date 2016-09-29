using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Testing.Sut;
using Testing.Sut.Interfaces;

namespace Testing.Moq
{

    /// <summary>
    /// No concrete refs - as they'll be brought in
    /// </summary>
    [TestClass]
    public class VerificationTests
    {
        [TestMethod]
        public void Primary_Dependency_Is_Called_Once_Per_Primary_Dependency_Dependant_Call()
        {
            // A
            var primaryDependencyMock = new Mock<IPrimaryDependency>();
            primaryDependencyMock.Setup(t => t.CalculatePrimary(It.IsAny<int>()));
            var sutService = new SutService(primaryDependencyMock.Object);

            // A
            sutService.PrimaryDependencyDependantCall(0);


            // A
            primaryDependencyMock.VerifyAll();
        }

        [TestMethod]
        public void Secondary_Dependency_Is_Called_Once_Per_Secondary_Dependency_Dependant_Call()
        {
            var primaryDependencyMock = new Mock<IPrimaryDependency>();
            var sutServiceMock = new Mock<SutService>(MockBehavior.Strict, primaryDependencyMock.Object); 

            var secondaryDependencyMock = new Mock<ISecondaryDependency>();
            secondaryDependencyMock.Setup(x => x.CalculateSecondary(It.IsAny<int>()));

            sutServiceMock.Setup(x => x.SecondaryDependency).Returns(secondaryDependencyMock.Object);

            sutServiceMock.Object.SecondaryDependencyDependantCall(0);

            sutServiceMock.VerifyAll();
        }
    }
}
