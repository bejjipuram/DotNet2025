using System;
using System.Collections.Generic;
using System.Diagnostics;
using EmployeeMock.Models;
using EmployeeMock.Repositories;
using EmployeeMock.Services;
using Moq;
using NUnit.Framework;

namespace EmployeeTests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _repoMock = default!;
        private EmployeeService _service = default!;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IEmployeeRepository>(MockBehavior.Strict);
            _service = new EmployeeService(_repoMock.Object);
        }
        [Test]
        public void GetEmployeeOrThrow_ShouldThrowArgumentOutOfRangeException_WhenIdIsLessThanOrEqualToZero()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var service = new EmployeeService(mockRepo.Object);
            int invalidId = 0;
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetEmployeeOrThrow(invalidId));
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Running manual test...");

            var repoMock = new Mock<IEmployeeRepository>();
            var service = new EmployeeService(repoMock.Object);

            try
            {
                int testId = 0;
                var result = service.GetEmployeeOrThrow(testId);
                Console.WriteLine($"Employee Found: {result.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }

            Console.WriteLine("Program finished.");
        }


    }
}