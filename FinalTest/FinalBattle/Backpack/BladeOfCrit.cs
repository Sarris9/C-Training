using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enumeration;

namespace FinalBattle.Backpack
{
    public class BladeOfCrit: IGear
    {
        public string Name { get; set; } = "Blade of Crit";
        public int Attack()
        {
            Random random = new Random();
            var chance = random.Next(100);

            if(chance < 25)
            {
                return 2;
            }
            else if(chance > 90)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        public GearAttacksEnum AttackName { get; } = GearAttacksEnum.Chop;
        public DamageTypeEnum DamageType { get; set; } = DamageTypeEnum.NORMAL;

    }
}
