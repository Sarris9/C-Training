using FinalBattle.Enumeration;
using static FinalBattle.HelpingMethods;


namespace FinalBattle.Characters
{
    public class StoneAmarok:Monster
    {
        public StoneAmarok()
        {
            base.Name = "Stone Amarok";
            HP = 4;
            CurrentHp = HP;
            Attack = StoneAmaroActionTypeEnum.BITE;
            DMGResistance = DMGResistanceEnum.STONE_ARMOR;
        }

        public override int Damage()
        {
            //var gearDMG = WeaponGear?.Attack();
            int dmg = Attack switch
            {
                StoneAmaroActionTypeEnum.BITE => 1,
                //Enum _ when Gear != null => Gear.Attack(),
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
                var number = ValidateNumber(StoneAmaroActionTypeEnum.BITE, this);
                if (number > Enum.GetValues<StoneAmaroActionTypeEnum>().Length)
                {
                    Attack = WeaponGear.AttackName;
                }
                else
                {
                    Attack = (StoneAmaroActionTypeEnum)number;
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

