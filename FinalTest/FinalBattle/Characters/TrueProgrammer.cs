using FinalBattle.Backpack;
using FinalBattle.Enumeration;
using static FinalBattle.HelpingMethods;


namespace FinalBattle.Characters
{
    public class TrueProgrammer:Monster
    {
        public TrueProgrammer(string name)
        {
            if(name == string.Empty)
            {
                name = "True Programmer";
            }
            Name = name;
            HP = 25;
            CurrentHp = HP;
            Attack = HeroActionTypeEnum.Punch;
            WeaponGear = new Sword();
            base.DMGResistance = DMGResistanceEnum.OBJECT_SIGHT;
        }
        public override string GetActionName(bool isEnabled)
        {
            string name = string.Empty;
            if (isEnabled)
            {              
                //var enumLength = Enum.GetValues<HeroActionType>().Length;
                var number = ValidateNumber(HeroActionTypeEnum.Punch,this);
                if(number > Enum.GetValues<HeroActionTypeEnum>().Length)
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
                if(WeaponGear != null)
                {
                    Attack = WeaponGear.AttackName;
                }
            }
            name = NameFixer(Attack);
            return name;
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
            if(isEnabled)
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
    }
}
