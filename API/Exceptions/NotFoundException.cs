using System;

namespace API.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity, int id) 
            : base($"The entity {entity} with id {id} was not found")
        {
            
        }
    }
}