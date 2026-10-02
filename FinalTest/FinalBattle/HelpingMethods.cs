using System.Collections;
using System.Threading;
using FinalBattle.Characters;
using FinalBattle.Enumeration;

namespace FinalBattle
{
    public class HelpingMethods
    {
        /// <summary>
        /// Validates and adjusts a numeric input based on the specified value and gear context.
        /// </summary>
        /// <typeparam name="T">The type of the value to validate.</typeparam>
        /// <param name="value">The value to be validated.</param>
        /// <param name="gear">The gear context used for validation.</param>
        /// <returns>The validated and adjusted number.</returns>
        public static int ValidateNumber<T>(T value,Monster monster )

        {
            //bool hasGear = false;
            int number = 0;
            int range = 0;
            int correctNumber = 0;
            while (true)
            {
                range = CorrectValidations(value, monster,out correctNumber);

                var action = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(action, out number))
                {
                    //if (monster.Gear != null)
                    //{
                    //    range++;
                    //}
                    if (number > range || number <= 0)
                    {
                        Console.WriteLine("Number are out of range!");
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Its not a valid number!");
                    Console.WriteLine();
                }
            }
            number += correctNumber;
            return number;
        }
        public static int CorrectValidations<T>(T value, Monster monster,out int fixingNumber)
        {
            fixingNumber = 0;
            int range = 0;
            if (value is Enum enumValue)
            {
                Console.WriteLine("Choose an action from the list");
                ShowEnum(enumValue,monster);
                range = Enum.GetValues(enumValue.GetType()).Length;
                if(monster.WeaponGear != null)
                {
                    range++;
                }
                return range;
            }
            else if (value is ICollection collection)
            {
                if (value is List<Monster> monsters)
                {
                    Console.WriteLine("Choose an enemy from the list");
                    range = monsters.Count();
                    ShowList(monsters);
                    fixingNumber = -1;
                    return range;
                }
                fixingNumber = -1;
                return collection.Count;
            }
            else
            {
                return range;
            }
        }
        public static void ShowEnum(Enum enumeration, Monster monsterGear)
        {
            string name = string.Empty;
            int list = 0;
            foreach (Enum enums in Enum.GetValues(enumeration.GetType()))
            {
                name = NameFixer(enums);
                list++;
                Console.WriteLine($"{list}:{name}");
            }
            if (monsterGear != null)
            {
                name = NameFixer(monsterGear.WeaponGear.AttackName);
                list++;
                Console.WriteLine($"{list}:{name}");
            }
        }       
        private static void ShowList<T>(List<T> listValue)
        {
            int list = 0;
            foreach (var value in listValue)
            {
                list++;
                var valueType = value switch
                {
                    Monster monster => monster.Name,
                    IItem item => item.Name,
                    IGear gear => gear.Name,
                    _ => value.ToString()
                };
                Console.WriteLine($"{list}:{valueType}");
            }   
        }
        private static void UseItem(Inventory inventory, Monster monster,int number)
        {
            inventory.Items[number].Use(monster);
            Console.WriteLine($"{monster.Name} use {inventory.Items[number].Name}");
            inventory.Items.Remove(inventory.Items[number]);
        }
        private static void EquipGear(Inventory inventory, Monster monster, int choosenGear)
        {
            var equipGear = inventory.Gears[choosenGear];
            if (monster.WeaponGear != null)
            {
                var lastGear = monster.WeaponGear;
                inventory.Gears.Add(lastGear);
                monster.WeaponGear = equipGear;
                inventory.Gears.Remove(equipGear);
            }
            else
            {
                monster.WeaponGear = equipGear;
                inventory.Gears.Remove(equipGear);
            }
            Console.WriteLine($"{monster.Name} equip {equipGear.Name}");
        }
        public static void InventoryBag(Inventory inventory, Monster monster)
        {
            Console.WriteLine("You open your inventory");
            if(inventory.Items.Count >0)
            {
            OpenItemInventory(inventory, monster);
            }
            else
            {
                Console.WriteLine("You dont have any Item to use!");
            }
            if(inventory.Gears.Count > 0)
            {
            OpenGearInventory(inventory, monster);
            }
            else
            {
                Console.WriteLine("You dont have any gear to equip!");
                Console.WriteLine();
            }
        }
        private static bool ItemGearValidation()
        {
            bool responce = false;
            int number = 0;
            while (true)
            {
                Console.WriteLine("1:Yes\n2:No");
                var action = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(action, out number))
                {
                    if (number > 2 || number <= 0)
                    {
                        Console.WriteLine("Its not a valid choice!");
                    }
                    else if (number == 1)
                    {
                        responce = true;
                        break;
                    }
                    else
                    {
                        responce = false;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Its not a valid number!");
                }
            }
            return responce;
        }
        private static void OpenItemInventory(Inventory inventory, Monster monster)
        {
            var responce = false;
            Console.WriteLine("Do you want to search for item?");
            responce = ItemGearValidation();
            if(responce)
            {
                ShowList(inventory.Items);
                Console.WriteLine();
                Console.WriteLine("Do you want to use an Item");
                responce = ItemGearValidation();
                if (responce)
                {
                    Console.WriteLine("Pick an item from the list");
                    ShowList(inventory.Items);
                    var choice = ValidateNumber(inventory.Items,monster);
                    UseItem(inventory, monster, choice);
                }
            }
        }
        private static void OpenGearInventory(Inventory inventory,Monster monster)
        {
            var responce = false;
            Console.WriteLine("Do you want to search for gear?");
            responce = ItemGearValidation();
            if(responce)
            {
                ShowList(inventory.Gears);
                Console.WriteLine("Do you want to equip an Item");
                responce = ItemGearValidation();
                if(responce)
                {
                    Console.WriteLine("Pick a gear from the list");
                    ShowList(inventory.Gears);
                    var choice = ValidateNumber(inventory.Gears,monster);
                    EquipGear(inventory, monster, choice);
                }
            }
        }
        public static string NameFixer(Enum enumeration)
        {
            string name = enumeration.ToString();
            name = name.Replace("_", " ");
            return name;
        }
        public static int DmgResistance(Monster attacker, Monster defender)
        {
            string name = string.Empty;
            int dmg = CalculateDMG(attacker, defender);
            if (dmg < 0)
            {
                //Console.WriteLine($"{NameFixer(defender.DMGResistance)} reduced the attack by {Math.Abs(dmg)} point.");
                if (defender.ArmorGear != null)
                {
                    name = $"{defender.ArmorGear.Name}";
                }
                else if(defender.DMGResistance != DMGResistanceEnum._)
                {
                    name = $"{NameFixer(defender.DMGResistance)}";
                }
                Console.WriteLine($"{name} reduced the attack by {Math.Abs(dmg)} point.");
            }
            else if (dmg > 0)
            {
                Console.WriteLine($"{defender.Name} took extra {Math.Abs(dmg)} point.");
            }
            return dmg;
        }
        public static DamageTypeEnum CounterDMGType(DamageTypeEnum damageType)
        {
            var counterType = damageType switch
            {
                DamageTypeEnum.FIRE => DamageTypeEnum.ELECTRIC,
                DamageTypeEnum.ELECTRIC => DamageTypeEnum.WATER,
                DamageTypeEnum.WATER => DamageTypeEnum.FIRE,
                _ => DamageTypeEnum.NORMAL
            };
            return counterType;
        }
        // an exei tin idia amuna(reduction) dexetai ligotera dmg
        private static int CalculateDMG(Monster attacker,Monster defender)
        {
            var dmg = 0;
            var results = AbillityReduction(attacker.DamageType);
            if (results == defender.DMGResistance)
            {
                dmg = defender.DMGResistance switch
                {
                    DMGResistanceEnum.STONE_ARMOR => -1,
                    DMGResistanceEnum.OBJECT_SIGHT => -2,
                    DMGResistanceEnum._ => 0,
                    _ => 0
                };
            }
            //if (defender.ArmorGear.DamageType != null)
            if (defender.ArmorGear is { } armor)
            {
                if (attacker.WeaponGear is { } weapon && !(weapon.DamageType.Equals(DamageTypeEnum.NORMAL)))
                {
                    var counter = CounterDMGType(attacker.WeaponGear.DamageType);

                    if (counter == defender.ArmorGear.DamageType )//&& counter != DamageTypeEnum.NORMAL)
                    {
                        dmg += 1;
                    }
                    //else
                    //{
                    //    dmg = defender.ArmorGear.Attack();
                    //}
                }
                else
                {
                    dmg = defender.ArmorGear.Attack();
                }
                //dmg += (counter == armor.DamageType) ? 1 : armor.Attack();
            }
            return dmg;
        }
        //bazeis ton tipo tis epithesis kai sou gurnaei tin amuna(reduction)
        private static DMGResistanceEnum AbillityReduction(DamageTypeEnum dmgResistance)
        {
            var resistance = dmgResistance switch
            {
                DamageTypeEnum.DECODING => DMGResistanceEnum.OBJECT_SIGHT,
                DamageTypeEnum.NORMAL => DMGResistanceEnum.STONE_ARMOR,
                DamageTypeEnum.FIRE or DamageTypeEnum.WATER or DamageTypeEnum.ELECTRIC => DMGResistanceEnum._,
                _=> DMGResistanceEnum._
            };
            return resistance;
        }
        //private static 
    }
}
