using FinalBattle.Enumeration;
using static FinalBattle.HelpingMethods;

namespace FinalBattle.Characters
{
    public class TheUncodedOne:Monster
    {
        public TheUncodedOne()
        {
            Name = "The Uncoded One";
            HP = 15;
            CurrentHp = HP;
            Attack = TheUncodedOneActionTypeEnum.UNRAVELING_ATTACK;
            DamageType = DamageTypeEnum.DECODING;
        }
        public override int Damage()
        {
            Random random = new Random();
            int dmgChance = Convert.ToInt32(random.Next(5));
            //var gearDMG = Gear.Attack();
            int dmg = Attack switch
            {
                TheUncodedOneActionTypeEnum.UNRAVELING_ATTACK => dmgChance,
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
                //var enumLength = Enum.GetValues<TheUncodedOneActionType>().Length;
                var number = ValidateNumber(TheUncodedOneActionTypeEnum.UNRAVELING_ATTACK,this);
                if (number > Enum.GetValues<TheUncodedOneActionTypeEnum>().Length)
                {
                    Attack = WeaponGear.AttackName;
                }
                else
                {
                    Attack = (TheUncodedOneActionTypeEnum)number;
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
