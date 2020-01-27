namespace NS.Booking.Domain.Payment.Enums
{
    public enum PaymentType
    {
        /// <summary>
        /// Prepaid type is used for third parties that process the payment themselves and then
        /// communicate the result of the operation. Ex. WorldPay, Ingenico, etc.
        /// </summary>
        PrePaid,

        /// <summary>
        /// CreditCard type is used when the payment is processed internally by the PSS, thus all card information is required.
        /// If the payment is done through a credit card but processed by an external third party then PrePaid should be used.
        /// </summary>
        CreditCard,
        Voucher,
        Loyalty,
        AgencyAccount,
        CustomerAccount,
        Mobile,
        Hold
    }
}
