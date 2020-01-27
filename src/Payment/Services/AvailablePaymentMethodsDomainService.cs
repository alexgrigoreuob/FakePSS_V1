using System;
using System.Collections.Generic;
using System.Linq;
using NS.Booking.Common.Domain.Charge.Enums;
using NS.Booking.Common.Domain.Charge.Models;
using NS.Booking.Domain.Payment.Enums;
using NS.Booking.Domain.Payment.Models;
using NS.Booking.Domain.Payment.Services;

namespace NS.Booking.Infrastructure.Fake.Payment.Services
{
    public class AvailablePaymentMethodsDomainService : IAvailablePaymentMethodsDomainService
    {
        private readonly Random _random;

        public AvailablePaymentMethodsDomainService()
        {
            _random = new Random();
        }

        public List<PaymentMethod> GetAvailablePaymentMethods()
        {
            //Generate list of random payment methods.
            var randomPaymentMethods = new List<PaymentMethod>();
            var randomPaymentMethodsCount = _random.Next(1, Enum.GetNames(typeof(PaymentType)).Length + 2);

            while (randomPaymentMethods.Count < randomPaymentMethodsCount)
            {
                //Generate random payment method
                var randomPaymentMethod = GeneratePaymentMethod();

                //Ensure combination of paymentType and method does not already exist
                if (!randomPaymentMethods.Any(x => x.Type == randomPaymentMethod.Type && x.Method == randomPaymentMethod.Method))
                {
                    randomPaymentMethods.Add(randomPaymentMethod);
                }
            }

            return randomPaymentMethods;
        }

        private PaymentMethod GeneratePaymentMethod()
        {
            // Define possible values
            var paymentTypeValues = Enum.GetValues(typeof(PaymentType));
            var currencyValues = new List<string> {"EUR", "USD"};
            var creditCardMethodValues = new List<string> {"VI", "MC"};
            var prePaidMethodValues = new List<string> {"WP", "IC"};

            // Set random values
            var randomPaymentType = (PaymentType) paymentTypeValues.GetValue(_random.Next(paymentTypeValues.Length));
            var randomCurrency = currencyValues[_random.Next(currencyValues.Count)];
            string randomMethod;
            var randomDccAllowed = false;
            var randomCharge = new Charge
            {
                Amount = _random.Next(100),
                Code = "RND",
                Currency = randomCurrency,
                Type = ChargeType.Default
            };

            switch (randomPaymentType)
            {
                case PaymentType.CreditCard:
                    randomMethod = creditCardMethodValues[_random.Next(creditCardMethodValues.Count)];
                    randomDccAllowed = _random.Next(100) <= 40;
                    break;
                case PaymentType.PrePaid:
                    randomMethod = prePaidMethodValues[_random.Next(prePaidMethodValues.Count)];
                    break;
                default:
                    randomMethod = string.Empty;
                    break;
            }

            var paymentMethod = new PaymentMethod
            {
                Currency = randomCurrency,
                Type = randomPaymentType,
                Method = randomMethod,
                Charge = randomCharge,
                DccAllowed = randomDccAllowed
            };

            return paymentMethod;
        }
    }
}
