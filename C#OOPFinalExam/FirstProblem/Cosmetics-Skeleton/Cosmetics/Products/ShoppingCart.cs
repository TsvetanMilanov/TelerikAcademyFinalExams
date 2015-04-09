namespace Cosmetics.Products
{
    using System.Collections.Generic;

    using Common;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> listOfProducts;

        public ShoppingCart()
        {
            this.listOfProducts = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.listOfProducts.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.listOfProducts.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            if (this.listOfProducts.Contains(product))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var product in this.listOfProducts)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }
    }
}
