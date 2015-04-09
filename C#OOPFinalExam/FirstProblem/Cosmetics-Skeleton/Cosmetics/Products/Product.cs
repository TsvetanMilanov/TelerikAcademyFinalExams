namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 10;
        private const int MinBrandLength = 2;
        private const int MaxBrandLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType genderType;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name"));
                Validator.CheckIfStringLengthIsValid(value, MaxNameLength, MinNameLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", MinNameLength, MaxNameLength));

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Brand name"));
                Validator.CheckIfStringLengthIsValid(value, MaxBrandLength, MinBrandLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", MinBrandLength, MaxBrandLength));

                this.brand = value;
            }
        }

        public virtual decimal Price
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

                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.genderType;
            }
            protected set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "GenderType"));

                this.genderType = value;
            }
        }

        public virtual string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("  * Price: ${0}", this.Price));
            result.AppendLine(string.Format("  * For gender: {0}", this.Gender.ToString()));

            return result.ToString().Trim();
        }
    }
}
