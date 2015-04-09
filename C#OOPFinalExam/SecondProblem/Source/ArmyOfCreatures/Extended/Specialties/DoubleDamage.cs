namespace ArmyOfCreatures.Extended.Specialties
{
    using System;

    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleDamage : Specialty
    {
        private const int MinRoundsCount = 0;
        private const int MaxRoundsCount = 10;

        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds <= MinRoundsCount)
            {
                throw new ArgumentOutOfRangeException(string.Format("The number of rounds should be greater than {0}", MinRoundsCount));
            }

            if (rounds > MaxRoundsCount)
            {
                throw new ArgumentOutOfRangeException(string.Format("The number of rounds should be less than or equal to {0}", MaxRoundsCount));
            }

            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            bool addedBonus = false;

            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (!addedBonus && this.rounds > 0)
            {
                addedBonus = true;
                this.rounds--;
                return currentDamage * 2M;
            }

            this.rounds--;
            return currentDamage;
        }

        public override string ToString()
        {
            return string.Format("DoubleDamage({0})", this.rounds);
        }
    }
}
