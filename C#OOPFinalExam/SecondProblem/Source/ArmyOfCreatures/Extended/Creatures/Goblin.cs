namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;

    public class Goblin : Creature
    {
        private const int GoblinAttackPoints = 4;
        private const int GoblinDefensePoints = 2;
        private const int GoblinHealthPoints = 5;
        private const decimal GoblinDamage = 1.5M;

        public Goblin()
            : base(GoblinAttackPoints, GoblinDefensePoints, GoblinHealthPoints, GoblinDamage)
        {
        }
    }
}
