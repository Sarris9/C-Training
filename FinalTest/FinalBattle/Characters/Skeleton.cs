using FinalBattle.Enumeration;
using static FinalBattle.HelpingMethods;

namespace FinalBattle.Characters
{
    public class Skeleton:Monster
    {
        public Skeleton()
        {
            HP = 5;
            CurrentHp = HP;
            Attack = SkeletonActionTypeEnum.BONE_CRUNCH;
        }

        public override int Damage()
        {
            Random random = new Random();
            int dmgChance = Convert.ToInt32(random.Next(2));
            //var gearDMG = WeaponGear.Attack();
            int dmg = Attack switch
            {
                SkeletonActionTypeEnum.BONE_CRUNCH => dmgChance,
                Enum _ when WeaponGear != null => WeaponGear.Attack(),
                _ => 0
            };
            return dmg;
        }

        public override int GetActionDamage(bool isEnabled)
        {
            if (isEnabled)
            {
                return Damage();
            }
            else
            {
                if (WeaponGear == null)
                {
                    return Damage();
                }
                else
                {
                    return WeaponGear!.Attack();
                }
            }
        }

        public override string GetActionName(bool isEnabled)
        {
            string name = string.Empty;
            if (isEnabled == true)
            {
                var number = ValidateNumber(SkeletonActionTypeEnum.BONE_CRUNCH,this);
                if (number > Enum.GetValues<SkeletonActionTypeEnum>().Length)
                {
                    Attack = WeaponGear.AttackName;
                }
                else
                {
                    Attack = (SkeletonActionTypeEnum)number;
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
