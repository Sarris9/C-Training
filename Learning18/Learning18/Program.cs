namespace Learning18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int ScoreFor(Monster monster)
            //{
            //    return monster switch
            //    {
            //        //Decleration Patterns
            //        //Snake => 7,
            //        //Snake s => (int)(s.Lenght * 2),
            //        // Case Guard
            //        //Snake s  when s.Lenght >= 3 => 7,
            //        //Snake => 3,
            //        //And , OR
            //        Snake { Lenght: < 2} => 1,
            //        Snake { Lenght: >= 2 and <= 5} => 3,
            //        Snake { Lenght: (>2 and<5) or (>100 and <1000)} => 20,
            //        Snake { Lenght: > 5} => 7,
            //        Dragon { LifePhase:LifePhase.Ancient,Type: DragonType.Red} => 110,
            //        Dragon { LifePhase: LifePhase.Ancient } d => 100,
            //        Dragon { LifePhase:LifePhase.Adult or LifePhase.Ancient} =>100,
            //        Dragon ( DragonType.Blue ,LifePhase.Wyrmling) d => 100,
            //        Dragon { LifePhase : not LifePhase.Wyrmling} => 50,
            //        Dragon => 50,
            //        //Nested Patterns
            //        Orc { Sword: { Type:SwordType.Longsword} } => 15,
            //        Orc { Sword:{Type:SwordType.ArmingSword} } => 8,
            //        Orc { Sword: { Type:SwordType.WoodenStick} } => 2,
            //        // OR
            //        //Orc { Sword.Type: SwordType.Longsword} =>15,
            //        //Orc { Sword.Type: SwordType.ArmingSword } => 8,
            //        //Orc { Sword.Type: SwordType.WoodenStick } => 2,
            //        _      => 5
            //    };
            //}
            // Switch Expression :
            //Player DetermineWinner(Choice player1, Choice player2)
            //{
            //    return (player1, player2) switch
            //    {
            //        (Choice.Rock, Choice.Scissors) => Player.One,
            //        (Choice.Paper, Choice.Rock) => Player.One,
            //        (Choice.Scissors , Choice.Paper) => Player.One,
            //        //(Choice a, Choice b) when a == b => Player.None,
            //        //Var pattern
            //        (var a,var b) when a == b =>Player.None,
            //        _ => Player.Two
            //    };
            //}
            //
            //Switch Statement :
            //Player DetermineWinner(Choice player1Choice , Choice player2Choice)
            //{
            //    switch(player1Choice,player2Choice)
            //    {
            //        case (Choice.Rock, Choice.Scissors):
            //        case (Choice.Paper, Choice.Rock):
            //        case (Choice.Scissors, Choice.Paper):
            //            return Player.One;
            //        case (Choice a, Choice b) when a == b:
            //            return Player.None;
            //        default:
            //            return Player.Two;
            //    }
            //}
            //void TellUserAboutMonster(Monster monster)
            //{
            //    Console.WriteLine("There is a monster!");
            //    if(monster is Snake)
            //        Console.WriteLine("Why did it have to be snakes?");
            //}
            PotionsType CreatePotion(Ingredience ingredience,PotionsType potions)
            {
                return (ingredience ,potions)switch
                {
                    (Ingredience.Stardust ,PotionsType.Water) => PotionsType.Elixir,
                    (Ingredience.SnakeVenom , PotionsType.Elixir) => PotionsType.Poison,
                    (Ingredience.DragonBreath,PotionsType.Elixir) => PotionsType.Flying,
                    (Ingredience.ShadowGlass, PotionsType.Elixir) => PotionsType.Invisibility,
                    (Ingredience.EyeshineGem, PotionsType.Elixir) => PotionsType.NightSight,
                    (Ingredience.ShadowGlass, PotionsType.NightSight) => PotionsType.CloudyBrew,
                    (Ingredience.EyeshineGem, PotionsType.Invisibility) => PotionsType.CloudyBrew,
                    (Ingredience.Stardust, PotionsType.CloudyBrew) => PotionsType.Wraith,
                    _ => PotionsType.RuinedPotion
                };
            }
            void ShowIngredience()
            {
                int numbers = 0;
                foreach (Ingredience ingredience in Enum.GetValues(typeof(Ingredience)))
                {
                    numbers++;
                    var test = ingredience.ToString();
                    switch (test)
                    {
                        case ("SnakeVenom"):
                            test = "Snake Venom";
                            break;
                        case ("DragonBreath"):
                            test = "Dragon Breath";
                            break;
                        case ("ShadowGlass"):
                            test = "Shadow Glass";
                            break;
                        case ("EyeshineGem"):
                            test = "Eyeshine Gem";
                            break;
                    }
                    Convert.ToString(numbers);
                    var result = numbers + " " + test;
                    Console.WriteLine(result);
                }
            }

            void ShowPotions(PotionsType potionsType)
            {
                //List<string> showPotions = new List<string>();
                //string[] showPotions = Enum.GetNames(typeof(PotionsType));
                string checkPotion = string.Empty;
                string clearName = string.Empty;
                foreach (PotionsType types in Enum.GetValues(typeof(PotionsType)))
                {
                    clearName = types.ToString();

                        switch (clearName)
                        {
                            case ("NightSight"):
                                clearName = "Night Sight";
                                break;
                            case ("CloudyBrew"):
                                clearName = "Cloudy Brew";
                                break;
                            case ("RuinedPotion"):
                                clearName = "Ruined Potion";
                                break;                           
                        }
                    //showPotions.Add(clearName);
                    if (potionsType == types)
                    {
                        //Console.WriteLine(clearName);
                        checkPotion = clearName;
                        break;
                    }
                }
                Console.WriteLine($"You have {clearName}");
                //if(potionsType != PotionsType.Water && showPotions.Contains(checkPotion))
                //{
                //    Console.WriteLine(checkPotion);
                //}
                //else
                //{
                //    for (int i = 0; i < showPotions.Count; i++)
                //    {
                //        Console.WriteLine(showPotions[i]);
                //    }
                //}
            }


            PotionsType playerPotion = PotionsType.Water;
            //bool succeedNumber = false;
            bool endGame = false;
            int parsedNumber = 0;
            string playerAnswers = string.Empty;
            //string playerIChoice;
            Console.WriteLine("Lets make a potion.");
            Console.WriteLine("All potions start with water.");
            ShowPotions(playerPotion);
            while (!endGame)
            {
                Console.WriteLine("Choose ingrediences for mix:");
                ShowIngredience();
                //var playerIChoice = Console.ReadLine();

                bool succeedNumber = false;
                while (!succeedNumber)
                {
                    var playerIChoice = Console.ReadLine();
                    succeedNumber = int.TryParse(playerIChoice, out parsedNumber);
                    if (!succeedNumber)
                    {
                        Console.WriteLine("This is not a number.Write a number!");
                    }
                    else
                    {
                        continue;
                    }
                }
                Ingredience playerIngredient = (Ingredience)(int)parsedNumber - 1;
                playerPotion = CreatePotion(playerIngredient, playerPotion);
                ShowPotions(playerPotion);
                if(playerPotion == PotionsType.RuinedPotion)
                {
                    playerPotion = PotionsType.Water;
                    Console.WriteLine("Lets start again.");
                    continue;
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to put another ingredience: yes , no ?");

                bool continuePlay = false;
                while (!continuePlay)
                {
                    playerAnswers = Console.ReadLine();
                    if (playerAnswers == "yes")
                    {
                        continuePlay = true;
                        continue;
                    }
                    else if (playerAnswers == "no")
                    {
                        continuePlay = true;
                        endGame = true;
                    }
                    else
                    {
                        Console.WriteLine("Write: yes or no");
                    }
                }
            }
        }
        //public abstract record Monster;
        //public record Skeleton():Monster;
        //public record Snake(double Lenght):Monster;
        //public record Dragon(DragonType Type,LifePhase LifePhase) :Monster;
        //public enum DragonType { Black,Green,Red,Blue,Gold};
        //public enum LifePhase { Wyrmling,Young,Adult,Ancient};
        //public record Orc(Sword Sword):Monster;
        //public record Sword(SwordType Type);
        //public enum SwordType { WoodenStick,ArmingSword,Longsword};

        //public enum Choice { Rock,Paper,Scissors}
        //public enum Player { None,One,Two}

        //public abstract record Water;
        //public record Potions(Ingredience Ingredience): Water;

        public enum Ingredience { Stardust,SnakeVenom, DragonBreath,ShadowGlass,EyeshineGem, }
        public enum PotionsType { Water,Elixir,Poison,Flying,Invisibility,NightSight,Wraith,CloudyBrew,RuinedPotion}

    }
}
