﻿namespace DillonColeman_PaySkyAssessment.Exceptions
{
    [Serializable]
    public class UserFailedToUpdateException : Exception
    {
        public UserFailedToUpdateException() : base("Failure to update user in database") { }

        public UserFailedToUpdateException(string message) : base(message) { }
    }
}
