namespace NS.Booking.Domain.BoardingPass.Models.Requests
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;

    public class BoardingPassRequest
    {
        private readonly List<IValidator<BoardingPassRequest>> _validators;

        public BoardingPassRequest()
        {
            this._validators = IoCContainer.Instance.ResolveAll<IValidator<BoardingPassRequest>>();
        }

        public string SegmentId { get; set; }

        public string PaxId { get; set; }

        public void Validate()
        {
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
