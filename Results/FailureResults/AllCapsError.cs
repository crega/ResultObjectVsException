using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultObjectVsException.Results.FailureResults
{
    public class AllCapsError : Error
    {
        public           string FieldName { get; private set; }

        public AllCapsError(string fieldName) : base($"{fieldName} have to be in all capital letters")
        {
            FieldName = fieldName;
            Metadata.Add(ErrorCodes.RequiredField.ToString(),ErrorCodes.RequiredField);
        }
    }
}
