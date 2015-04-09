namespace ArmyOfCreatures.Extended.Specialties
{
    using System;

    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Battles;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            if (rounds <= 0)
            {
                throw new ArgumentOutOfRangeException("The rounds count must be greater than 0!");
            }

            this.rounds = rounds;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("The attacker must not be null!");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("The defender must not be null!");
            }

            if (this.rounds <= 0)
            {
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;

            this.rounds--;
        }

        public override string ToString()
        {
            return string.Format("DoubleAttackWhenAttacking({0})", this.rounds);
        }
    }
}
