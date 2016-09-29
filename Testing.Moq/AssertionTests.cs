using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Testing.Sut;
using Testing.Sut.Interfaces;

namespace Testing.Moq
{
    [TestClass]
    public class AssertionTests
    {
        [TestMethod]
        public void Run_Primary_Dependency_Call_With_Non_Negative_Value_Exptect_Input_To_Be_Devided_By_Ten()
        {
            int inputValue = 100;

            var primaryDependencyMock = new Mock<IPrimaryDependency>();
            primaryDependencyMock.Setup(x => x.CalculatePrimary(It.IsAny<int>())).Returns(inputValue);

            var sutService = new SutService(primaryDependencyMock.Object);
            var returnValue = sutService.PrimaryDependencyDependantCall(inputValue);

            Assert.AreEqual(inputValue/10, returnValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Run_Primary_Dependency_Call_With_Negative_Value_Expect_Invalid_Operation_Exception()
        {
            var primaryDependencyMock = new Mock<IPrimaryDependency>();
            primaryDependencyMock.Setup(x => x.CalculatePrimary(It.IsAny<int>())).Returns(-1);

            var sutService = new SutService(primaryDependencyMock.Object);

            sutService.PrimaryDependencyDependantCall(0);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Run_Secondary_Dependency_With_Without_Depenendency_Sepcified_Expect_Invalid_Operation_Excpetion()
        {
            var primaryDependencyMock = new Mock<IPrimaryDependency>();
            var sutService = new SutService(primaryDependencyMock.Object);

            sutService.SecondaryDependencyDependantCall(0);
        }
    }
}
