using NUnit.Framework;
using ResultObjectVsException;
using ResultObjectVsException.Exceptions;

namespace Tests
{
    public class TestNotificationServiceUnitTeststs
    {
        private string _validUsername;
        private string _invalidUsername;

        private string _validDomain;
        private string _invalidDomain;

        private string _validMessage;
        private string _invalidMessage;
        private string _emptyDomain;

        [SetUp]
        public void Setup()
        {
            _validUsername   = "testUsername";
            _invalidUsername = string.Empty;
            _validDomain     = "DOMAIN";
            _invalidDomain   = "domain";
            _emptyDomain     = string.Empty;
            _validMessage    = "Valid message!";
            _invalidMessage  = string.Empty;
        }

        [Test]
        public void PublishMessage_WithException_InvalidUsername_ThrowsException()
        {
            var exception =
                Assert.Throws<ArgumentException>(() => NotificationService.PublishMessage_WithException(_invalidUsername,
                                                     _validDomain,
                                                     _validMessage));
            Assert.That(exception.Message,Is.EqualTo("Username must be defined (Parameter 'username')"));

        }
        [Test]
        public void PublishMessage_WithException_InvalidDomainEmpty_ThrowsException()
        {
            var exception =
                Assert.Throws<ArgumentException>(() => NotificationService.PublishMessage_WithException(_validUsername,
                                                              _emptyDomain,
                                                              _validMessage));
            Assert.That(exception.Message, Is.EqualTo("Domain must be defined (Parameter 'domain')"));   
        }
        [Test]
        public void PublishMessage_WithException_InvalidDomain_ThrowsException()
        {
            var exception =
                Assert.Throws<DomainNotAllCapitalLetters>(() => NotificationService.PublishMessage_WithException(_validUsername,
                                                     _invalidDomain,
                                                     _validMessage));
            Assert.That(exception.Message, Is.EqualTo("Domain must be all caps"));   
        }
        [Test]
        public void PublishMessage_WithException_InvalidMessage_ThrowsException()
        {
            var exception =
                Assert.Throws<ArgumentException>(() => NotificationService.PublishMessage_WithException(_validUsername,
                                                     _validDomain,
                                                     _invalidMessage));
            Assert.That(exception.Message, Is.EqualTo("Message must be defined (Parameter 'message')"));   
        }

        
        [Test]
        public void PublishMessage_WithResult_InvalidUsername_ThrowsException()
        {
            var result =
                NotificationService.PublishMessage_WithResultObject(_invalidUsername,
                                                     _validDomain,
                                                     _validMessage);
            Assert.IsTrue(result.IsFailed);
            result.WithError("username is required");

        }
        [Test]
        public void PublishMessage_WithResult_InvalidDomain_ThrowsException()
        {
            var result =
                NotificationService.PublishMessage_WithResultObject(_validUsername,
                                                                    _invalidDomain,
                                                                    _validMessage);
            Assert.IsTrue(result.IsFailed);
            result.WithError("domain is required");
        }
        [Test]
        public void PublishMessage_WithResult_InvalidDomainEmpty_ThrowsException()
        {
            var result =
                NotificationService.PublishMessage_WithResultObject(_validUsername,
                                                                    _emptyDomain,
                                                                    _validMessage);
            Assert.IsTrue(result.IsFailed);
            result.WithError("domain have to be in all capital letters");
        }
        [Test]
        public void PublishMessage_WithResult_InvalidMessage_ThrowsException()
        {
            var result =
                NotificationService.PublishMessage_WithResultObject(_validUsername,
                                                                    _validMessage,
                                                                    _invalidMessage);
            Assert.IsTrue(result.IsFailed);
            result.WithError("message is required");
        }


    }
}