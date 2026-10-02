using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enumeration;

namespace FinalBattle.Backpack
{
    public class BinaryHelm:IGear
    {
        public string Name { get; set; } = "Binary Helm";
        public int Attack()
        {
            return -1;
        }
        public GearAttacksEnum AttackName { get; } = GearAttacksEnum._;
        public DamageTypeEnum DamageType { get; set; } = DamageTypeEnum.NORMAL;
    }
}
