using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using InterviewApp.Controllers;
using InterviewApp.Memory;
using InterviewApp.Model;
using InterviewApp.Model.Dto;
using InterviewApp.Services;


namespace Tests
{
    public class IntervieweesControllerTests
    {
        [Test]
        [TestCaseSource(typeof(TestUtils), "IntervieweesAndIntervieweesDtoListsWithOneInterview")]
        public void Given_IntervieweeServiceWithOneInterviewee_When_GetAll_Then_IntervieweeDtoListIsReturned(List<IntervieweeDto> expectedIntervieweesDto, List<Interviewee> testInterviewees)
        {
            Mock<IIntervieweesService> intervieweeeServiceMock = new Mock<IIntervieweesService>();
            intervieweeeServiceMock.Setup(x => x.GetAllInterviewees()).Returns( testInterviewees);
            var intervieweesController = new IntervieweesController(intervieweeeServiceMock.Object);
            
            var result = intervieweesController.GetAll();
            
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result);
                Assert.IsNotEmpty(result);
                Assert.AreEqual(result.First().Name, expectedIntervieweesDto.First().Name);
                Assert.AreEqual(result.First().Surname, expectedIntervieweesDto.First().Surname);
                Assert.AreEqual(result.First().Interviews.First().Result, expectedIntervieweesDto.First().Interviews.First().Result);
                Assert.AreEqual(result.First().Interviews.First().Date, expectedIntervieweesDto.First().Interviews.First().Date);
            });
        }

        [Test]
        public void Given_EmptyIntervieweeService_When_GetAll_Then_EmptyIntervieewesDtoListIsReturned()
        {
            var emptyInterviewees = new List<Interviewee>();
            Mock<IIntervieweesService> intervieweeeServiceMock = new Mock<IIntervieweesService>();
            intervieweeeServiceMock.Setup(x => x.GetAllInterviewees()).Returns( emptyInterviewees);
            var intervieweesController = new IntervieweesController(intervieweeeServiceMock.Object);

            var result = intervieweesController.GetAll();
            
            Assert.IsEmpty(result);
        }
    }
}