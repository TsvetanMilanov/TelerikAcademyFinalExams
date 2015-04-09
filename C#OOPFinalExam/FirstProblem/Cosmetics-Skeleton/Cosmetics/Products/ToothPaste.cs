namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using Contracts;

    public class ToothPaste : Product, IToothpaste, IProduct
    {
        private const int MinIngredientsNameLength = 4;
        private const int MaxIngredientsNameLength = 12;

        public ToothPaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = this.JoinIngredients(ingredients);
        }
        public string Ingredients { get; private set; }

        private string JoinIngredients(IList<string> ingredients)
        {
            Validator.CheckIfNull(ingredients, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Ingredients"));

            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(ingredient, MaxIngredientsNameLength, MinIngredientsNameLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", MinIngredientsNameLength, MaxIngredientsNameLength));
            }

            return string.Join(", ", ingredients);
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.Print());
            result.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));

            return result.ToString().Trim();
        }
    }
}
