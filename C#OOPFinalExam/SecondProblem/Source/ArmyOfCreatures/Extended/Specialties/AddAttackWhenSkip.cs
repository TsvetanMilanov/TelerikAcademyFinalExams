namespace ArmyOfCreatures.Extended.Specialties
{
    using System;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    public class AddAttackWhenSkip : Specialty
    {
        private const int MinAttackToAdd = 1;
        private const int MaxAttackToAdd = 10;

        private int attackToAdd;

        public AddAttackWhenSkip(int attackToAdd)
        {
            if (attackToAdd < MinAttackToAdd || attackToAdd > 10)
            {
                throw new ArgumentOutOfRangeException(string.Format("The value to add to the attack mus be between {0} and {1}", MinAttackToAdd, MaxAttackToAdd));
            }

            this.attackToAdd = attackToAdd;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("The skipCreature must not be null!");
            }

            skipCreature.PermanentAttack += this.attackToAdd;
        }

        public override string ToString()
        {
            return string.Format("AddAttackWhenSkip({0})", this.attackToAdd);
        }
    }
}
