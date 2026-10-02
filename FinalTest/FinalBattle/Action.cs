using FinalBattle.Backpack;
using FinalBattle.Characters;
using FinalBattle.Enumeration;
using static FinalBattle.HelpingMethods;


namespace FinalBattle
{
    public class Action:IAction
    {
        public void Turn(List<Monster> enemies, Monster monster, Inventory inventory, bool isEnabled)
        {
            Monster target = null;
            int monsterDMG = 0;
            Console.WriteLine($"It is {monster.Name}'s turn");

            AutoUseInventory(inventory, monster, isEnabled);
            var action = monster.GetActionName(isEnabled);
            monsterDMG = monster.GetActionDamage(isEnabled);
            if (isEnabled)
            {
                int targetChoise = 0;
                targetChoise = ValidateNumber(enemies, monster);
                target = enemies[targetChoise];
            }
            else
            {
                Random random = new Random();
                var targetChoice = random.Next(enemies.Count);
                target = monster is TrueProgrammer ? enemies[targetChoice] : enemies.First();
                //monsterDMG = monster.GetActionDamage();
            }
            //Console.WriteLine(AtackChance(target,monster,action,monsterDMG));
            //Console.WriteLine($"{monster.Name} did {action} on {target.Name}");
            //Console.WriteLine($"{action} dealt {monsterDMG} dmg to {target.Name}");
            AtackChance(target, monster, action, monsterDMG);
            //CountHp(target, monsterDMG);
        }
        private void CountHp(Monster defender, Monster attacker, int dmg)
        {
            int currentHp = defender.CurrentHp;
            int hp = currentHp - dmg;
            if (hp <= 0)
            {
                defender.CurrentHp = 0;
                Console.WriteLine($"{defender.Name} was defeated!");
            }
            else
            {
                //defender.CurrentHp = hp;
                defender.CurrentHp = hp > defender.HP ? defender.HP : hp;
                Console.WriteLine($"{defender.Name} is now at {defender.CurrentHp}/{defender.HP}");
            }
        }

        private void AutoUseInventory(Inventory inventory, Monster monster, bool isEnabled)
        {
            if(isEnabled)
            {
                InventoryBag(inventory, monster);
            }
            else
            {
                Random random = new();
                if (inventory.Items.Count > 0)
                {
                    if (monster.CurrentHp <= monster.HP / 2)
                    {
                        int chanceNumber = Convert.ToInt32(random.Next(100));
                        if (chanceNumber < 25)
                        {
                            Console.WriteLine($"{monster.Name} use {inventory.Items.First().Name}");
                            inventory.Items.First().Use(monster);
                            inventory.Items.Remove(inventory.Items.First());
                        }
                    }

                }
                if (inventory.Gears.Count > 0)
                {
                    if (monster.WeaponGear == null && (monster is Skeleton))
                    {
                        int chanceNumber = Convert.ToInt32(random.Next(2));
                        if (chanceNumber == 1)
                        {
                            var dagger = inventory.Gears.FirstOrDefault(d => d is Dagger);
                            monster.WeaponGear = dagger;
                            Console.WriteLine($"{monster.Name} equip {monster.WeaponGear.Name}");
                            inventory.Gears.Remove(dagger);
                        }
                    }
                    else if(monster.ArmorGear == null && (monster is TrueProgrammer || monster is VinFletcher || monster is MylaraAndSkorin))
                    {
                        if (inventory.Gears.Any(g => g is BinaryHelm))
                        {
                            int chanceNumber = Convert.ToInt32(random.Next(2));
                            if (chanceNumber == 1)
                            {
                                monster.ArmorGear = inventory.Gears.First();
                                Console.WriteLine($"{monster.Name} equip {monster.ArmorGear.Name}");
                                inventory.Gears.Remove(inventory.Gears.First());
                            }
                        }
                    }
                }
            }
        }
        private void AtackChance(Monster defender, Monster attacker, string attack, int dmg)
        {
            string anounce = string.Empty;
            Random random = new Random();
            var chance = random.Next(2);
            if (attacker.Attack is HeroActionTypeEnum heroEnum && heroEnum == HeroActionTypeEnum.Do_Nothing)
            {
                //Console.WriteLine($"{monster.Name} did nothing!");
                anounce = $"{attacker.Name} did nothing!";
            }
            else if (attacker is VinFletcher)
            {
                if (chance == 0 && attacker.Attack is GearAttacksEnum)
                {
                    //Console.WriteLine($"{monster.Name} MISSED!");
                    anounce = $"{attacker.Name} MISSED!";
                    dmg = 0;
                }
                else
                {
                    dmg += DmgResistance(attacker, defender);
                    dmg = dmg < 0 ? 0 : dmg;
                    anounce = $"{attacker.Name} did {attack} on {defender.Name}\n{attack} dealt {dmg} dmg to {defender.Name}";
                }
            }
            else
            {
                dmg += DmgResistance(attacker, defender);
                //dmg = dmg < 0 ? 0 : dmg;
                dmg = Math.Max(0, dmg);
                anounce = $"{attacker.Name} did {attack} on {defender.Name}\n{attack} dealt {dmg} dmg to {defender.Name}";
                //Console.WriteLine($"{monster.Name} did {attack} on {enemy.Name}!");
                //Console.WriteLine($"{attack} dealt {dmg} dmg to {enemy.Name}!");
            }
            Console.WriteLine(anounce);
            CountHp(defender,attacker, dmg);
        }
       
    }
}
