using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultObjectVsException.Results.SuccessResults
{
    public class MessagePublished <T>: Success where T : class
    {
        public string ActionName { get; private set; }

        public MessagePublished(string actionName, T result) : base($"{actionName} published message successfully")
        {
            ActionName = actionName;
            Metadata.Add("returnObject",result);
        }
    }
}
