using FinalBattle.Enumeration;

namespace FinalBattle
{
    public class Dagger:IGear
    {
        public string Name { get; set; } = "Dagger";
        public int Attack()
        {
            return 1;
        }
        public GearAttacksEnum AttackName { get; } = GearAttacksEnum.Stab;
        public DamageTypeEnum DamageType { get; set; } = DamageTypeEnum.NORMAL;
    }
}

