using FinalBattle.Enumeration;

namespace FinalBattle.Backpack
{
    public class VinsBow:IGear
    {
        public string Name { get; set; } = "Vin's Bow";
        public int Attack()
        {
            return 3;
        }
        public GearAttacksEnum AttackName { get; } = GearAttacksEnum.Quick_Shot;
        public DamageTypeEnum DamageType { get; set; } = DamageTypeEnum.NORMAL;
    }
}
