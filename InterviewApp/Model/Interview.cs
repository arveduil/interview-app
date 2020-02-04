using System;

namespace InterviewApp.Model
{
    public class Interview
    {
        public string ID { get; set; }
        
        public DateTime Date { get; set; }
        
        public InterviewResult Result { get; set; }

        public Interview(DateTime date, InterviewResult result)
        {
            Date = date;
            Result = result;
        }
    }
}