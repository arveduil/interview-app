using System;
using System.Collections.Generic;

namespace InterviewApp.Model
{
    public class Interviewee
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public List<Interview> Interviews { get; set; }

        public Interviewee(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Interviews = new List<Interview>();
        }
        
        protected bool Equals(Interviewee other)
        {
            return Name == other.Name && Surname == other.Surname;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Interviewee) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Surname != null ? Surname.GetHashCode() : 0);
            }
        }
    }
}