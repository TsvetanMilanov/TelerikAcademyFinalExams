namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;

    public class Shampoo : Product, IShampoo, IProduct
    {
        private decimal price;
        private UsageType usageType;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price = price;
        }

        public override decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The price must be positive number!");
                }

                this.price = value * (decimal)this.Milliliters;
            }
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage
        {
            get
            {
                return this.usageType;
            }
            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "UsageType"));

                this.usageType = value;
            }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.Print());
            result.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            result.AppendLine(string.Format("  * Usage: {0}", this.Usage.ToString()));

            return result.ToString().Trim();
        }
    }
}
