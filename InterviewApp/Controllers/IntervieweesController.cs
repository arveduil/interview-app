using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InterviewApp.Miscellaneous;
using InterviewApp.Model.Dto;
using InterviewApp.Services;

namespace InterviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervieweesController : ControllerBase
    {
        private readonly IIntervieweesService _intervieweesService;
        
        public IntervieweesController(IIntervieweesService intervieweesServiceContext)
        {
            _intervieweesService = intervieweesServiceContext;
        }
        
        // GET api/interviewees
        [HttpGet]
        public IEnumerable<IntervieweeDto> GetAll()
        {
            return _intervieweesService
                .GetAllInterviewees()
                .Select(i => i.ToIntervieweeDto());
        }

        // POST api/interviewees
        [HttpPost]
        public void Post([FromBody] IntervieweeDto intervieweeDto)
        {
            _intervieweesService.SaveIntervieweeWithInterviews(intervieweeDto.ToRawInterviewee(), intervieweeDto.Interviews.Select(i => i.ToInterview()));
        }
    }
}