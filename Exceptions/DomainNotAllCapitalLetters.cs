using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultObjectVsException.Exceptions
{
    public class DomainNotAllCapitalLetters :Exception
    {
        public DomainNotAllCapitalLetters()
        {

        }

        public DomainNotAllCapitalLetters(string message) : base(message)
        {
        }

        public DomainNotAllCapitalLetters(string message, Exception? ex) : base(message, ex)
        {
        }
    }
}
