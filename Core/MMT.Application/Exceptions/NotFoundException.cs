using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name) : base($"{name} is not found")
        {
            
        }
    }
}
