using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enumeration;

namespace FinalBattle.Backpack
{
    public class TheCannonOfConsolas:IGear
    {
        public string Name { get; set; } = "The Cannon of Consolas";
        public int Attack()
        {
            if (_rounds >= 15)
            {
                _rounds = 1;
            }
            var currentRound = _rounds;
            if(currentRound %3 == 0 && currentRound % 5 == 0)
            {
                DamageType = DamageTypeEnum.FIRE;
                _rounds++;
                return 5;
            }
            else if(currentRound % 3 == 0 || currentRound % 5 == 0)
            {
                DamageType = DamageTypeEnum.ELECTRIC;
                _rounds++;
                return 2;
            }
            else
            {
                DamageType = DamageTypeEnum.NORMAL;
                _rounds++;
                return 1;
            }
        }
        public GearAttacksEnum AttackName { get; } = GearAttacksEnum.Cannon_Ball;
        public DamageTypeEnum DamageType { get; set; } = DamageTypeEnum.NORMAL;
        private int _rounds  = 1;
    }
}
