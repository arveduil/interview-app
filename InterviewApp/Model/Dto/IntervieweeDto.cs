using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InterviewApp.Model.Dto
{
    public class IntervieweeDto
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public List<InterviewDto> Interviews { get; set; }
    }
}