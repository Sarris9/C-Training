namespace Learning4
{
    internal class Program
    {
        public class Point
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public Point()
            {
                X = 0;
                Y = 0;
            }
        }
        //
        public class Color
        {
            public int Red { get; private set; }
            public int Green { get; private set; }
            public int Blue { get; private set; }

            public Color(int red,int green,int blue)
            {
                this.Red = red;
                this.Green = green;
                this.Blue = blue;
            }
            public static Color WhiteColor()
            {
                return new Color(255, 255, 255);
            }
            public static Color BlackColor()
            {
                return new Color(0, 0, 0);
            }
            public static Color RedColor()
            {
                return new Color(255, 0, 0);
            }
            public static Color OrangeColor()
            {
                return new Color(255, 165, 0);
            }
            public static Color YellowColor()
            {
                return new Color(255, 255, 0);
            }
            public static Color GreenColor()
            {
                return new Color(0, 128, 0);
            }
            public static Color BlueColor()
            {
                return new Color(0, 0, 255);
            }
            public static Color PurpleColor()
            {
                return new Color(128, 0, 128);
            }
        }
        //
        public enum CardColor
        {
            red,
            green,
            blue,
            yellow
        }
        public enum CardRank
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Eleven = '$',
            Twelve = '%',
            Thirteen = '^',
            Forteen = '&'
        }
        public class Card
        {
            public  CardColor CardColors { get; set; }
            public  CardRank CardRanks { get; set; }
            public bool Indentifier { get; set; }

            public bool FaceCard(CardRank cardRank)
            {
                //return Indentifier = (int)cardRank > 10 ? true : false;
                if ((int)cardRank > 10)
                {
                    return Indentifier = true;
                }
                else
                {
                    return Indentifier = false;
                }
            }

        }
        public static void CreateCard()
        {
            var createCard = new Card();
            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    createCard.CardRanks = rank;
                    createCard.CardColors = color;
                    Console.WriteLine($"The {createCard.CardColors} {createCard.CardRanks}");
                }
            }
            //return Console.WriteLine($"The {createCard.CardColors} {createCard.CardRanks}");

        }
        //
        public enum DoorStatus
        {
            Open,
            Closed,
            Locked,
            Unlocked
        }
        public class Door
        {
            public DoorStatus doorStatus { get;set; }
            private int _passcode { get; set; }

            public static DoorStatus DoorTrack(DoorStatus doorStatus)
            {
                //var door = new Door();
                switch(doorStatus)
                {
                    case DoorStatus.Open:
                        doorStatus = DoorStatus.Closed;
                            break;
                    case DoorStatus.Closed:
                        doorStatus = DoorStatus.Locked;
                        break;
                    case DoorStatus.Locked:
                        doorStatus = DoorStatus.Unlocked;
                        break;
                    case DoorStatus.Unlocked:
                        doorStatus = DoorStatus.Open;
                        break;
                }
                return doorStatus;
            }
            public int GerPasscode()
            {
                _passcode = _passcode;
                return _passcode;
            }
            public Door(int codes)
            {
                _passcode = codes;
                doorStatus = DoorStatus.Closed;
            }
            public  bool ChangePassCode(int code,int newCode)
            {
                
                if (code == _passcode)
                {
                    _passcode = newCode;
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong Passcode");
                    return false;
                }
            }
        }
        //
        public class PasswordValidator
        {
            private string? _password { get; set; }
            public bool passwordPass { get; private set; }


            //public PasswordValidator(string password)
            public PasswordValidator(string _password)
            {
                bool uppercase = false;
                bool lowercase = false;
                bool number = false;
                bool capitaT = false;
                bool ampersand = false;
                var passCheck = _password.Concat(_password);
                foreach(char letter in passCheck)
                {
                    if(char.IsUpper(letter))
                    {
                        uppercase = true;
                    }

                    if (char.IsLower(letter))
                    {
                        lowercase = true;
                    }

                    if (char.IsDigit(letter))
                    {
                        number = true;
                    }
                    if(letter.Equals('T'))
                    {
                        capitaT = true;
                    }
                    if (letter.Equals('&'))
                    {
                        ampersand = true;
                    }
                }
                if(_password.Length <= 6 || _password.Length >= 13)
                {
                    Console.WriteLine("Passwords must be at least 6 letters long and no more than 13 letters long.");
                }
                if(!uppercase)
                {
                    Console.WriteLine("Password must contain at least one uppercase letter.");
                }
                if (!lowercase)
                {
                    Console.WriteLine("Password must contain at least one lowercase letter.");
                }
                if (!number)
                {
                    Console.WriteLine("Password must contain at least one number.");
                }
                if (capitaT)
                {
                    Console.WriteLine("Passwords cannot contain a capital T.");
                }
                if (ampersand)
                {
                    Console.WriteLine("Passwords cannot contain an ampersand &.");
                }
                passwordPass = true;
            }
        }
        //

        static void Main(string[] args)
        {
            //Point first = new Point(2, 3);
            //Point second = new Point(-4, 0);

            //Console.WriteLine($"({first.X} , {first.Y})");
            //Console.WriteLine($"({second.X} , {second.Y})");
            //var test = Color.RedColor();
            //var test2 = new Color(230, 50, 180);
            //Console.WriteLine($"{test.Red},{test.Green},{test.Blue}");
            //Console.WriteLine($"{test2.Red},{test2.Green},{test2.Blue}");
            //var pop = CardRank.Eleven;
            //Console.WriteLine((char)pop);

            //CreateCard();
            //var CardTest = new Card(CardColor.red,(char)CardRank.Thirteen);
            //var CardTest = new Card();
            //CardTest.CardColors = CardColor.red;
            //CardTest.CardRanks = CardRank.Thirteen;
            //Console.WriteLine($"The {CardTest.CardColors} {(char)CardTest.CardRanks}");

            //Console.WriteLine("Create a new Door ");
            //var code = Convert.ToInt32(Console.ReadLine());
            //var newDoor = new Door(code);
            //do
            //{
            //    Console.WriteLine($"The door are {newDoor.doorStatus}");
            //    Console.WriteLine("Turn the Key");

            //    var turn = Console.ReadLine()!.ToLower();
            //    if (turn == "turn")
            //    {
            //        newDoor.doorStatus = Door.DoorTrack(newDoor.doorStatus);
            //    }
            //    if(newDoor.doorStatus == DoorStatus.Locked)
            //    {
            //        do
            //        {
            //            Console.WriteLine("Put you passcode for unlock");
            //            var unlock = Convert.ToInt32(Console.ReadLine());
            //            if (unlock == newDoor.GerPasscode())
            //            {
            //                newDoor.doorStatus = DoorStatus.Unlocked;
            //            }
            //            else
            //            {
            //                Console.WriteLine("Wrong Passcode");
            //            }
            //        }
            //        while (newDoor.doorStatus != DoorStatus.Unlocked);
            //    }
            //}
            //while (newDoor.doorStatus != DoorStatus.Open);
            //Console.WriteLine($"The door are {newDoor.doorStatus}");
            //Console.WriteLine("Change your Passcode");
            //bool change = false;
            //do
            //{
            //    Console.WriteLine("Put your old Passcode");
            //    var oldCode = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Put your new Passcode");
            //    var newCode = Convert.ToInt32(Console.ReadLine());

            //    if (newDoor.ChangePassCode(oldCode, newCode))
            //    {
            //        change = true;
            //    }
            //}
            //while (!change);

            //Console.WriteLine("Put your password.");
            //bool pass = false;
            //do
            //{
            //    var code = Console.ReadLine()!;
            //    var checkPass = new PasswordValidator(code);
            //    if(checkPass.passwordPass)
            //    {
            //        pass = true;
            //    }
            //}
            //while (!pass);
            //Console.WriteLine("Password Passed");
            ///

            //Console.WriteLine("_X_|___|_O_");
            //Console.WriteLine("_X_|___|___");
            //Console.WriteLine("_X_|   |_O_");

            //Console.WriteLine("Player 1. Write your name");
            //var player1name = Console.ReadLine();
            //Console.WriteLine("Player 1 choose 1:X or 2:O");
            //var playerPiece = Console.ReadLine();
            //char player1Piece;
            //if(playerPiece == "1")
            //{
            //    player1Piece = 'X';
            //}
            //else
            //{
            //    player1Piece = 'O';
            //}
            //if(player1name == string.Empty && playerPiece == string.Empty)
            //{
            //    player1name = "Player1";
            //    player1Piece = 'X';
            //}
            //Console.WriteLine("Player 2. Write your name");
            //var player2name = Console.ReadLine();
            //char player2Pice;
            //if(player1Piece == 'X')
            //{
            //    player2Pice = 'O';
            //}
            //else
            //{
            //    player2Pice = 'X';

            //}
            //
        }
    }
}
