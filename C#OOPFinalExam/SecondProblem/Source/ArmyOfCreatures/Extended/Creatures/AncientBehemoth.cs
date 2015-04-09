namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        private const int AncientBehemothAttackPoints = 19;
        private const int AncientBehemothDefensePoints = 19;
        private const int AncientBehemothHealthPoints = 300;
        private const decimal CyclopsKingDamage = 40M;

        public AncientBehemoth()
            : base(AncientBehemothAttackPoints, AncientBehemothDefensePoints, AncientBehemothHealthPoints, CyclopsKingDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
