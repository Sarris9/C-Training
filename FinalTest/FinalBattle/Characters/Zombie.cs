using static FinalBattle.HelpingMethods;
using FinalBattle.Enumeration;

namespace FinalBattle.Characters
{
    public class Zombie:Monster
    {
        public Zombie()
        {
            HP = 7;
            CurrentHp = HP;
            Attack = ZombieActionTypeEnum.Brains;
        }

        public override int Damage()
        {
            Random random = new Random();
            //int dmgChance = Convert.ToInt32(random.Next(2));
            //var gearDMG = WeaponGear.Attack();
            int dmg = Attack switch
            {
                ZombieActionTypeEnum.Brains => 1,
                Enum _ when WeaponGear != null => WeaponGear.Attack(),
                _ => 0
            };
            return dmg;
        }

        public override int GetActionDamage(bool isEnabled)
        {
                return Damage();
        }

        public override string GetActionName(bool isEnabled)
        {
            string name = string.Empty;
            if (isEnabled == true)
            {
                var number = ValidateNumber(ZombieActionTypeEnum.Brains, this);
                if (number > Enum.GetValues<ZombieActionTypeEnum>().Length)
                {
                    Attack = WeaponGear.AttackName;
                }
                else
                {
                    Attack = (ZombieActionTypeEnum)number;
                }
            }
            else
            {
                if (WeaponGear != null)
                {
                    Attack = WeaponGear.AttackName;
                }
                name = NameFixer(Attack);
            }
            return name;
        }
    }
}
