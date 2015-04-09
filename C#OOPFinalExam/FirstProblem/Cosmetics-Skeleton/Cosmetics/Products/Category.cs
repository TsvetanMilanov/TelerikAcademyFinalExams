namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;

        private string name;
        private ICollection<IProduct> listOfProducts;

        public Category(string name)
        {
            this.Name = name;
            this.listOfProducts = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));
                Validator.CheckIfStringLengthIsValid(value, MaxCategoryNameLength, MinCategoryNameLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinCategoryNameLength, MaxCategoryNameLength));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.listOfProducts.Add(cosmetics);
            this.SortProducts();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (this.listOfProducts.Contains(cosmetics))
            {
                this.listOfProducts.Remove(cosmetics);
            }
            else
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
        }

        public string Print()
        {
            int productsCount = this.listOfProducts.Count;

            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("{0} category - {1} {2} in total", this.name, productsCount, productsCount == 1 ? "product" : "products"));

            foreach (var product in this.listOfProducts)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().Trim();
        }

        private void SortProducts()
        {
            this.listOfProducts = this.listOfProducts
                                                     .OrderBy(x => x.Brand)
                                                     .ThenByDescending(x => x.Price)
                                                     .ToList();
        }
    }
}
