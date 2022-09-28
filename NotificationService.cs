using FluentResults;
using ResultObjectVsException.Exceptions;
using ResultObjectVsException.Results.FailureResults;
using ResultObjectVsException.Results.SuccessResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultObjectVsException
{
    public static class NotificationService
    {
        public static string PublishMessage_WithException(string username, string domain, string message)
        {
            #region ArgumentsValidation
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username must be defined", nameof(username));
            }
            if (string.IsNullOrWhiteSpace(domain))
            {
                throw new ArgumentException("Domain must be defined", nameof(domain));
            }

            if (domain.ToUpper().Equals(domain) == false)
            {
                throw new DomainNotAllCapitalLetters("Domain must be all caps");
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message must be defined", nameof(message));
            } 
            #endregion

            return PublishMessage(username, domain, message);
        }

        public static Result<string> PublishMessage_WithResultObject(string username, string domain, string message)
        {
            #region ArgumentsValidation
            if (string.IsNullOrWhiteSpace(username))
            {
                return Result.Fail( new RequiredError("username"));   
            }
            if (string.IsNullOrWhiteSpace(domain))
            {
                return Result.Fail( new RequiredError("domain"));   
            }

            if (domain.ToUpper().Equals(domain) == false)
            {
                return  Result.Fail(new AllCapsError("domain"));
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                return Result.Fail( new RequiredError("message"));   
            } 
            #endregion

            return PublishMessage(username, domain, message).ToResult();

        }


        private static string PublishMessage(string username, string domain, string message)
        {
            // For brevity we assume that message gets published to some service, and after that returns string that signalize successful action.
            return $@"[{DateTime.UtcNow}] Message published successfully from user {domain}\{username} with content:{Environment.NewLine}{message}";
        }
    }
}
