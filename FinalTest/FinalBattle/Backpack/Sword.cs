using FinalBattle.Enumeration;

namespace FinalBattle.Backpack
{
    public class Sword:IGear
    {
        public string Name { get; set; } = "Sword";
        public int Attack()
        {          
            return 2;
        }
        public GearAttacksEnum AttackName { get; } = GearAttacksEnum.Slash_Attack;
        public DamageTypeEnum DamageType { get; set; } = DamageTypeEnum.NORMAL;

    }
}
