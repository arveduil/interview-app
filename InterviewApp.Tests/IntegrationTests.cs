using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using InterviewApp;
using InterviewApp.Controllers;
using InterviewApp.Memory;
using InterviewApp.Model;
using InterviewApp.Model.Dto;
using InterviewApp.Services;

namespace Tests
{
    public class IntegrationTests
    {
        private IntervieweesController _intervieweesController;
        
        [SetUp]
        public void SetUp()
        {
            _intervieweesController = new IntervieweesController(new IntervieweesService(new IntervieweesMemory()));
        }

        [Test]
        public void When_GetAll_Then_EmptyListReturned()
        {
            var result = _intervieweesController.GetAll();
            
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
        
        [Test]
        [TestCaseSource(typeof(TestUtils), nameof(TestUtils.IntervieweeDto))]
        public void When_GetAllAfterAdding_Then_AddedInterviewee(IntervieweeDto testIntervieweeDto)
        {
            _intervieweesController.Post(testIntervieweeDto);
            var result = _intervieweesController.GetAll().ToList();
            
            
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.First().Name, testIntervieweeDto.Name);
            Assert.AreEqual(result.First().Surname, testIntervieweeDto.Surname);
            Assert.AreEqual(result.First().Interviews.First().Result, testIntervieweeDto.Interviews.First().Result);
            Assert.AreEqual(result.First().Interviews.First().Date, testIntervieweeDto.Interviews.First().Date);
        }
    }
}