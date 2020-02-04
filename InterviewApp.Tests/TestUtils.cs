using System;
using System.Collections.Generic;
using NUnit.Framework;
using InterviewApp.Model;
using InterviewApp.Model.Dto;

namespace Tests
{
    public static class TestUtils
    {
        private static DateTime _testDate = new DateTime(2010, 3, 14, 2, 30, 0, DateTimeKind.Local);

        private static IntervieweeDto _testIntervieweeDto =
            new IntervieweeDto()
            {
                Name = "Piotr",
                Surname = "Boszczyk",
                Interviews = new List<InterviewDto>()
                {
                    new InterviewDto()
                    {
                        Date = _testDate,
                        Result = InterviewResult.Accepted
                    }
                }
            };

        private static Interviewee _testInterviewee = new Interviewee("Piotr", "Boszczyk")
        {
            Interviews = new List<Interview>()
            {
                new Interview(_testDate, InterviewResult.Accepted)
            }
        };

        public static IEnumerable<TestCaseData> IntervieweesAndIntervieweesDtoListsWithOneInterview
        {
            get
            {
                yield return new TestCaseData(new List<IntervieweeDto>
                {
                    _testIntervieweeDto
                }, new List<Interviewee>()
                {
                    _testInterviewee
                });
            }
        }
        
        
        public static IEnumerable<TestCaseData> IntervieweeDto
        {
            get
            {
                yield return new TestCaseData(_testIntervieweeDto);
            }
        }
        
        public static IEnumerable<TestCaseData> Interviewee
        {
            get
            {
                yield return new TestCaseData(_testInterviewee);
            }
        }
    }
}