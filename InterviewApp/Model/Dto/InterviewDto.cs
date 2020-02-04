using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InterviewApp.Model.Dto
{
    public class InterviewDto
    {
        public DateTime Date { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public InterviewResult Result { get; set; }
    }
}