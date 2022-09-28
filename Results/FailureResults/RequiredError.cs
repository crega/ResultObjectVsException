using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultObjectVsException.Results.FailureResults
{
    public class RequiredError : Error
    {
        public           string FieldName { get; private set; }

        public RequiredError(string fieldName) : base($"{fieldName} is required")
        {
            FieldName = fieldName;
            Metadata.Add(ErrorCodes.RequiredField.ToString(),ErrorCodes.RequiredField);
        }
    }
}
