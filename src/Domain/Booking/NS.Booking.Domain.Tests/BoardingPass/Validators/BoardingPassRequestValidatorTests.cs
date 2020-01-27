namespace NS.Booking.Domain.Tests.BoardingPass.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.BoardingPass.Exceptions;
    using NS.Booking.Domain.BoardingPass.Models.Requests;
    using NS.Booking.Domain.BoardingPass.Validators;
    using NUnit.Framework;

    [TestFixture]
    public class BoardingPassRequestValidatorTests
    {
        private IValidator<BoardingPassRequest> _validator;

        [SetUp]
        public void Setup()
        {
            this._validator = new BoardingPassRequestValidator();
        }

        [Test]
        public void ThrowsWhenNullRequest()
        {
            Assert.Throws<InvalidBoardingPassRequestInformationException>(() =>
            {
                this._validator.Validate(null);
            });
        }

        [Test]
        public void ThrowsWhenEmptyRequest()
        {
            Assert.Throws<InvalidBoardingPassRequestInformationException>(() =>
            {
                this._validator.Validate(new BoardingPassRequest());
            });
        }

        [Test]
        public void DoesNotThrowWhenRequestIsValid()
        {
            Assert.DoesNotThrow(() =>
            {
                this._validator.Validate(new BoardingPassRequest
                {
                    PaxId = "TEST123",
                    SegmentId = "123ABC"
                });
            });
        }
    }
}
