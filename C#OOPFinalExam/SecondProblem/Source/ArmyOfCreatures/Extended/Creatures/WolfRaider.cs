namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    public class WolfRaider : Creature
    {
        private const int WolfRaiderAttackPoints = 8;
        private const int WolfRaiderDefensePoints = 5;
        private const int WolfRaiderHealthPoints = 10;
        private const decimal WolfRaiderDamage = 3.5M;
        private const int WolfRiderInitialDoubleDamageRounds = 7;

        public WolfRaider()
            : base(WolfRaiderAttackPoints, WolfRaiderDefensePoints, WolfRaiderHealthPoints, WolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(WolfRiderInitialDoubleDamageRounds));
        }
    }
}
