using System;
using System.Linq;
using NUnit.Framework;
using InterviewApp.Miscellaneous;
using InterviewApp.Model;
using InterviewApp.Model.Dto;

namespace Tests
{
    public class ExtensionTests
    {
        [TestCaseSource(typeof(TestUtils), nameof(TestUtils.IntervieweeDto))]
        public void Given_IntervieweeDto_When_ConvertedToInterviewee_Then_IntervieweeIdenticalWithoutInterviews(IntervieweeDto intervieweeDto)
        {
            var interviewee = intervieweeDto.ToRawInterviewee();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(intervieweeDto.Name, interviewee.Name);
                Assert.AreEqual(intervieweeDto.Surname, interviewee.Surname);
                Assert.IsEmpty(interviewee.Interviews);
            });
        }
        
        [TestCaseSource(typeof(TestUtils), nameof(TestUtils.Interviewee))]
        public void Given_Interviewee_When_ConvertedToIntervieweeDto_Then_IntervieweeDtoIsIdentical(Interviewee interviewee)
        {
            var intervieweeDto = interviewee.ToIntervieweeDto();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(interviewee.Name, intervieweeDto.Name);
                Assert.AreEqual(interviewee.Surname, intervieweeDto.Surname);
                Assert.AreEqual(interviewee.Interviews.First().Result, intervieweeDto.Interviews.First().Result);
                Assert.AreEqual(interviewee.Interviews.First().Date, intervieweeDto.Interviews.First().Date);
            });
        }
    }
}