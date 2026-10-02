using FinalBattle.Enumeration;

namespace FinalBattle.Characters
{
    public abstract class Monster
    {
        private string? _name;
        public string? Name 
        {
            get => _name ?? GetType().Name;
            set => _name = value;
        }
        public int HP { get; set; }
        public int CurrentHp { get; set; }
        public abstract int Damage();

        public abstract string GetActionName(bool isENabled);

        public abstract int GetActionDamage(bool isEnabled);
        public Enum? Attack { get; set; }
        public IGear? WeaponGear { get; set; }
        public IGear? ArmorGear { get; set; }
        public DMGResistanceEnum DMGResistance { get; set; } = DMGResistanceEnum._;
        private DamageTypeEnum _damageType = DamageTypeEnum._;
        public DamageTypeEnum DamageType
        {
            //get => DamageType = WeaponGear != null ? WeaponGear.DamageType : _damageType;
            get => WeaponGear?.DamageType ?? _damageType;
            set => _damageType = value;
        }

    }
}
