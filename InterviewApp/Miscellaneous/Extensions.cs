using System.Collections.Generic;
using System.Linq;
using InterviewApp.Model;
using InterviewApp.Model.Dto;

namespace InterviewApp.Miscellaneous
{
    public static class Extensions
    {
        public static IntervieweeDto ToIntervieweeDto(this Interviewee interviewee)
        {
            return new IntervieweeDto()
            {
                Name = interviewee.Name,
                Surname = interviewee.Surname,
                Interviews = interviewee.Interviews.Select(i => i.ToInterviewDto()).ToList()
            };
        }
        
        public static InterviewDto ToInterviewDto(this Interview interview)
        {
            return new InterviewDto()
            {
                Date = interview.Date,
                Result = interview.Result
            };
        }
        
        public static Interviewee ToRawInterviewee(this IntervieweeDto intervieweeDto)
        {
            return new Interviewee(intervieweeDto.Name, intervieweeDto.Surname);
        }
        
        public static Interview ToInterview(this InterviewDto interviewDto)
        {
            return new Interview(interviewDto.Date, interviewDto.Result);
        }
    }
}