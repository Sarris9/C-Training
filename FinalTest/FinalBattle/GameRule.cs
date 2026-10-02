using FinalBattle.Backpack;
using FinalBattle.Characters;
using FinalBattle.Enumeration;

namespace FinalBattle
{
    public class GameRule
    {
        public List<Monster> HeroesParty { get; set; } = new();
        public List<Monster> MonstersParty { get; set; } = new();
        public int Level { get; set; } = 0;
        public MenuItem MenuItem { get; set; } = new MenuItem();
        public Inventory HeroesInventory { get; set; } = new Inventory { Items = new List<IItem> { new HealthPotion(), new HealthPotion(), new HealthPotion() } };
        public Inventory MonsterInventory { get; set; } = new Inventory(); //{ Items = new List<IItem> { new HealthPotion() }, Gears = new List<IGear> { new Dagger() } };


        public void Battle()
        {
            bool endGame = false;
            GameChoice();
            while (this.Level <= 6)
            {
                if (endGame == true)
                {
                    break;
                }

                Level++;
                SetRound(Level);
                if (Level % 4 == 0)
                {
                    var friend = RescueFriend();
                    Console.WriteLine($"You rescue {friend.Name}!");
                    Console.WriteLine();
                    Console.WriteLine($"{friend.Name} will fight with you now!");
                    Console.WriteLine();
                    this.HeroesInventory.Items.Add(new SimulasSoup());
                    Console.WriteLine($"You found {new SimulasSoup().Name}");
                    this.HeroesParty.Add(friend);
                }
                while (true)
                {
                    // end game
                    if (this.HeroesParty.Count == 0)
                    {
                        Console.WriteLine("The heroes lost and the Uncoded One’s forces have prevailed.");
                        endGame = true;
                        break;
                    }
                  
                    if (this.MonstersParty.Count == 0)
                    {
                        //SetRound(BattleTurns);
                        //BattleTurns++;
                        if (Level == 2 || Level == 5)
                        {
                            Console.WriteLine($"You defeat the {Level} wave.");
                            Console.WriteLine();
                            LootInventory(HeroesInventory, MonsterInventory);
                            Console.WriteLine();
                            Console.WriteLine("Get ready for the Boss.");
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to continue.");
                            Console.ReadKey(true);
                            break;
                        }
                        else
                        {
                            //SetRound(BattleTurns);
                            Console.WriteLine($"You defeat the {Level} wave.");
                            Console.WriteLine();
                            LootInventory(HeroesInventory, MonsterInventory);
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to continue.");
                            Console.ReadKey(true);
                            break;
                        }  

                    }

                    foreach (Monster monster in HeroesParty.ToList())
                    {
                        if(MonstersParty.Count ==0)
                        {
                            break;
                        }
                        BattleStatus(this.HeroesParty, this.MonstersParty, monster);
                        MenuItem.ActionToPerform?.Turn(this.MonstersParty, monster, this.HeroesInventory, this.MenuItem.IsEnabled.Item1);

                        RemoveDead();
                        Console.WriteLine();
                        Thread.Sleep(1500);
                    }
                    foreach (Monster monster in MonstersParty.ToList())
                    {
                        if (HeroesParty.Count == 0)
                        {
                            break;
                        }
                        BattleStatus(this.HeroesParty, this.MonstersParty, monster);
                        MenuItem.ActionToPerform?.Turn(this.HeroesParty, monster, this.MonsterInventory, this.MenuItem.IsEnabled.Item2);

                        RemoveDead();
                        Console.WriteLine();
                        Thread.Sleep(1500);
                    }
                }
            }
            if(endGame = false)
            {
                Console.WriteLine("The heroes won, and the Uncoded One was defeated.");
            }

        }
        private void RemoveDead()
        {
            var deadHeros = this.HeroesParty;
            var deadMonsters = this.MonstersParty;
            foreach (Monster heros in deadHeros)
            {
                if(heros.CurrentHp <= 0)
                {
                    LootDead(MonsterInventory, heros);
                    this.HeroesParty.Remove(heros);
                    break;
                }
            }
            foreach (Monster monst in deadMonsters)
            {
                if (monst.CurrentHp <= 0)
                {
                    LootDead(HeroesInventory, monst);
                    this.MonstersParty.Remove(monst);
                    break;
                }
            }
        }
        public void GameChoice()
        {
            int number = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine(MenuItem.Description);
                var choice = Console.ReadLine();
                if (int.TryParse(choice, out number))
                {
                    if (number > 3 || number <= 0)
                    {
                        Console.WriteLine("Choose between 1 through 3 ");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Its not a valid number!");
                }
            }
            Console.Clear();
            MenuItem.IsEnabled = number switch
            {
                1 => (true, false),
                2 => (false, false),
                3 => (true, true),
                _ => throw new NotImplementedException()
            };
        }
        public void BattleStatus(List<Monster> teamA,List<Monster> teamB,Monster currentOne)
        {
            var firstTeam = teamA.ToList();
            var secondTeam = teamB.ToList();
            Console.WriteLine(new string('=',100));
            Console.WriteLine(new string('-', 44) + " Battle " + new string('-', 47));
            for (int a = 0; a<firstTeam.Count; a++)
            {
                if (firstTeam[a] == currentOne)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                Console.Write($"{firstTeam[a].Name}  ( {firstTeam[a].CurrentHp}/{firstTeam[a].HP}) {Icon(firstTeam[a])}");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 46) + " VS " + new string('-', 47));
            for (int b = 0; b < secondTeam.Count; b++)
            {
                if (secondTeam[b] == currentOne)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                Console.Write($"{secondTeam[b].Name}  ( {secondTeam[b].CurrentHp}/{secondTeam[b].HP}) {Icon(secondTeam[b])}");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine(new string('=', 100));
            Console.WriteLine();
        }
        private string Icon(Monster monster)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var icon = monster.WeaponGear switch
            {
                Dagger => "🗡️",
                Sword => "⚔️",
                VinsBow => "🏹",
                TheCannonOfConsolas => "💣",
                BladeOfCrit => "🔪",
                _ => "👊"
            };
            //icon = monster.Attack switch
            //{
            //    SkeletonActionTypeEnum.BONE_CRUNCH => "🦴",
            //    StoneAmaroActionTypeEnum.BITE => "🦷",
            //};
            return icon;
        }
        private void LootInventory(Inventory heroInventory,Inventory monsterInventory)
        {
            Console.WriteLine("You open enemies inventory!");
            if (monsterInventory.Items.Count > 0)
            {
                foreach (var item in monsterInventory.Items.ToList())
                {
                    Console.WriteLine($"{item.Name} is acquired!");
                    heroInventory.Items.Add(item);
                    monsterInventory.Items.Remove(item);
                }
            }
            Console.WriteLine();
            if(monsterInventory.Gears.Count > 0)
            {
                foreach(var gear in monsterInventory.Gears.ToList())
                {
                    Console.WriteLine($"{gear.Name} is acquired!");
                    heroInventory.Gears.Add(gear);
                    monsterInventory.Gears.Remove(gear);
                }
            }
            if(monsterInventory.Items.Count == 0 && monsterInventory.Gears.Count == 0)
            {
                Console.WriteLine("Invetory are empty!");
            }
        }
        private void LootDead(Inventory inventory, Monster monster)
        {
            if (monster.WeaponGear != null)
            {
                var gear = monster.WeaponGear;
                inventory.Gears.Add(gear);
                Console.WriteLine($"{gear.Name} is acquired!");
            }
        }
        private Monster RandomMonsters()
        {
            Random random = new Random();
            var create = random.Next(3);
            Monster createMonster = create switch
            {
                0 => new Zombie(),
                1 => new Skeleton(),
                2 => new StoneAmarok(),
                _ => throw new NotImplementedException(),
            };
            return createMonster;
        }
        private IGear RandomItem()
        {
            Random random = new Random();
            var items = random.Next(3);
            IGear randomItems = items switch
            {
                0 => new Sword(),
                1 => new BladeOfCrit(),
                2 => new BinaryHelm(),
                _ => throw new NotImplementedException(),
            };
            return randomItems;
        }
        private Monster RescueFriend()
        {
            Random random = new Random();
            var friend = random.Next(2);
            Monster rescue = friend switch
            {
                0 => new VinFletcher(),
                1 => new MylaraAndSkorin(),
                _ => throw new NotImplementedException()
            };
            return rescue;
        }
        private void SetRound(int rounds)
        {
            for (int i = 1; i <= rounds; i++)
            {
                Monster monster = RandomMonsters();
                if (this.MonsterInventory.Items.Count == 0)
                {
                    this.MonsterInventory.Items.Add(new HealthPotion());
                }
                if(monster is Skeleton)
                {
                    this.MonsterInventory.Gears.Add(new Dagger());
                }

                if (rounds % 3 == 0 && rounds > 0)
                {
                    this.MonstersParty.Add(new TheUncodedOne());
                    this.MonsterInventory.Gears.Add(RandomItem());
                    this.MonstersParty.Add(monster);
                    break;
                }
                else
                {
                    this.MonstersParty.Add(monster);
                }
            }
        }
    }
}
