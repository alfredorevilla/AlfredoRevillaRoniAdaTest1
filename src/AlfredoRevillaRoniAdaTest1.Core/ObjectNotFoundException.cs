using System;

namespace AlfredoRevillaRoniAdaTest1
{
    [Serializable]
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string type, string id) : base($"Object with id {id} of type {type} was not found.")
        {
        }
    }
}