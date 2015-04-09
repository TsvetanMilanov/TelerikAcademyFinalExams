namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    public class CyclopsKing : Creature
    {
        private const int CyclopsKingAttackPoints = 17;
        private const int CyclopsKingDefensePoints = 13;
        private const int CyclopsKingHealthPoints = 70;
        private const decimal CyclopsKingDamage = 18M;

        public CyclopsKing()
            : base(CyclopsKingAttackPoints, CyclopsKingDefensePoints, CyclopsKingHealthPoints, CyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(3));
            this.AddSpecialty(new DoubleAttackWhenAttacking(4));
            this.AddSpecialty(new DoubleDamage(1));
        }
    }
}
