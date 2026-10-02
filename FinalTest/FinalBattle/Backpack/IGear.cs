using FinalBattle.Enumeration;

namespace FinalBattle
{
    public interface IGear
    {
        public string? Name { get; }
        public int Attack();
        public  GearAttacksEnum AttackName { get; }
        public DamageTypeEnum DamageType { get; set; }
    }
}
