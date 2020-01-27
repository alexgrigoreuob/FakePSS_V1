namespace NS.Booking.Domain.Pax.Models
{
    using System.Collections.Generic;

    using Newshore.Core.IoC;
    using Newshore.Core.NativeObjects.Extensions;

    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Common.Domain.Person.Models;

    public class Pax : Person
    {
        private readonly List<IValidator<Pax>> validators;

        public Pax()
        {
            this.PersonInfo = new PersonInfo();
            this.SegmentsInfo = new List<PaxSegmentInfo>();
            this.MemberNumbers = new List<MemberNumberInfo>();
            this.validators = IoCContainer.Instance.ResolveAll<IValidator<Pax>>();
        }

        public PaxTypeInfo Type { get; set; }

        public List<MemberNumberInfo> MemberNumbers { get; set; }

        public string[] DependentPaxes { get; set; }

        public List<PaxSegmentInfo> SegmentsInfo { get; set; }

        public string ReferenceId { get; set; }

        public string Id
        {
            get
            {
                var refId = string.IsNullOrEmpty(this.ReferenceId) ? string.Empty : this.ReferenceId.EncodeHexadecimal();

                if (string.IsNullOrEmpty(refId) && (this.Name == null || (string.IsNullOrEmpty(this.Name.First) && string.IsNullOrEmpty(this.Name.Last))))
                {
                    return string.Empty;
                }

                var value = $"{this.Name?.First}~{this.Name?.Last}~{this.PersonInfo?.DateOfBirth.ToUniversalTime():yyyy-MM-dd}~{refId}";
                return value.EncodeHexadecimal();
            }
        }

        public void Validate()
        {
            this.validators.ForEach(x => x.Validate(this));
        }
    }
}
