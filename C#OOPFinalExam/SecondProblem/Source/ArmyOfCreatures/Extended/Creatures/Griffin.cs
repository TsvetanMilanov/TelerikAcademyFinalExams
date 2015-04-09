namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class Griffin : Creature
    {
        private const int GriffinAttackPoints = 8;
        private const int GriffinDefensePoints = 8;
        private const int GriffinHealthPoints = 25;
        private const decimal GriffinDamage = 4.5M;

        public Griffin()
            : base(GriffinAttackPoints, GriffinDefensePoints, GriffinHealthPoints, GriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
            this.AddSpecialty(new AddDefenseWhenSkip(3));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
