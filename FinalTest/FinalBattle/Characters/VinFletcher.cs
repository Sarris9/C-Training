using FinalBattle.Backpack;
using FinalBattle.Enumeration;
using static FinalBattle.HelpingMethods;

namespace FinalBattle.Characters
{
    public class VinFletcher:Monster
    {
        public VinFletcher()
        {
            Name = "Vin Fletcher";
            HP = 15;
            CurrentHp = HP;
            Attack = HeroActionTypeEnum.Punch;
            WeaponGear = new VinsBow();
        }
        public override int Damage()
        {
            //var gearDMG = WeaponGear.Attack();
            int dmg = Attack switch
            {
                HeroActionTypeEnum.Punch => 1,
                HeroActionTypeEnum.Do_Nothing => 0,
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
                var number = ValidateNumber(HeroActionTypeEnum.Punch, this);
                if (number > Enum.GetValues<HeroActionTypeEnum>().Length)
                {
                    Attack = WeaponGear.AttackName;
                }
                else
                {
                    Attack = (HeroActionTypeEnum)number;
                }
            }
            else
            {
                if (WeaponGear != null)
                {
                    Attack = WeaponGear.AttackName;
                }
            }
            name = NameFixer(Attack);
            return name;
        }

    }
}
