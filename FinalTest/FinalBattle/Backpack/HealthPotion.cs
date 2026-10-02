using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Characters;

namespace FinalBattle
{
    public class HealthPotion:IItem
    {
        public string Name { get; set; } = "Health Potion";
        public void Use(Monster user)
        {
            var userCH = user.CurrentHp;
            var baseHP = user.HP;
            var heal = userCH + 10; 
            user.CurrentHp = heal > baseHP ? baseHP : heal;
            //user.CurrentHp = Math.Min(user.CurrentHp + 10, user.HP);
        }
    }
}
