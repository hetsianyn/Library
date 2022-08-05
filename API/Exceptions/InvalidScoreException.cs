using System;

namespace API.Exceptions
{
    public class InvalidScoreException : Exception
    {
        public InvalidScoreException(decimal score) 
            : base($"Score {score} is invalid. Score must be in range from 1 to 5.")
        {
            
        }
    }
}