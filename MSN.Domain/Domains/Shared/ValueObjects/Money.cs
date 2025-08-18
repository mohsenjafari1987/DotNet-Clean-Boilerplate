namespace MSN.Domain.Domains.Shared.ValueObjects
{
    // Money
    public readonly record struct Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Create(decimal amount, string currency)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount, nameof(amount));
            ArgumentException.ThrowIfNullOrWhiteSpace(currency, nameof(currency));

            return new Money(amount, currency.Trim().ToUpperInvariant());
        }

        public override string ToString() => $"{Amount:0.00} {Currency}";

        // Implicit conversion from tuple for convenience
        public static implicit operator Money((decimal amount, string currency) value)
            => Create(value.amount, value.currency);
    }
}
