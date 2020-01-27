﻿namespace NS.Booking.Common.Domain.Tests
{
    using Newshore.Core.IoC;
    using Newshore.Core.Logger;

    using NUnit.Framework;

    [SetUpFixture]
    public class SetupTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            LoggerBootstrapper.Initialize();
            IoCBootstrapper.Initialize();
        }
    }
}