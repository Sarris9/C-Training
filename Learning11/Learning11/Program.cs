using System.Data.Common;
using System.Diagnostics;
using System.Threading.Channels;
using static Learning11.Program;

namespace Learning11
{
    internal class Program
    {
        //public interface IWorld
        //{

        //    //public  string [,]? Board { get; set; }

        //    public void Checkrooms(string[,] board)// string[,] pleyerMove)
        //    {
        //        for (int i = 0; i < board!.GetLength(0); i++)
        //        {
        //            for (int j = 0; j <board.GetLength(1); j ++)
        //            {

        //                var cellValue = board[i, j];
        //                //var room = pleyerMove;
        //                //if(room == cellValue)
        //                Console.WriteLine(cellValue);
        //            }
        //        }
        //    }
        //}
        //public enum Compass
        //{
        //    North = 1,
        //    South = 2,
        //    East = 3,
        //    West = 4
        //}
        //public class Board
        //{
        //    public string[,] BoardSize { get; set; } = new string[0,0];
        //    public bool Fountain { get; set; } = false;
        //    public bool FindFountain { get; set; } = false;
        //    public bool Pit { get; set; } = false;
        //    public bool GameRun { get; set; } = false;


        //    private List<(string value, string extraValue, int row, int column)> Traps = new List<(string, string, int, int)>();

        //    public void SetRooms(string[,] board)
        //    {
        //        for (int i = 0; i < board!.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < board.GetLength(1); j++)
        //            {
        //                BoardSize.SetValue("You are in an empty room.", i, j);
        //            }
        //        }
        //        board.SetValue("You see light coming from the cavern entrance.", 0, 0);
        //    }
        //    public string GetBoard(int row, int column)
        //    {
        //        var boardValue = BoardSize.GetValue(row, column);
        //        if (boardValue != null && boardValue!.Equals("fountain"))
        //        {
        //            if (!FindFountain)
        //            {
        //                {
        //                    boardValue = ("You hear water dripping in this room.The Fountain of Objects is here!");
        //                    FindFountain = true;
        //                }
        //            }
        //            if (Fountain)
        //            {
        //                boardValue = ("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
        //                GameRun = true;
        //            }
        //        }

        //        if (Pit)
        //        {
        //            //Console.WriteLine("You fall into the pit!");
        //            //Pit = true;
        //            GameRun = true;
        //        }
        //        foreach (var trap in Traps)
        //        {
        //            if (row == trap.row && column == trap.column)
        //            {
        //                boardValue = trap.value;
        //            }
        //            if (Math.Abs(row - row) <= 1 &&
        //                Math.Abs(column - column) <= 1 &&
        //                !(row == trap.row && column == trap.column))
        //            {
        //                boardValue = trap.extraValue;
        //            }
        //        }

        //        Console.WriteLine(boardValue);
        //        return (string)boardValue!;
        //    }
        //    public string[,] SetBoard(string value,int row,int column)
        //    {
        //        BoardSize.SetValue(value, row, column);
        //        return BoardSize;
        //    }
            
        //    public  void SetFountain(int row, int column)
        //    {
        //        string value = "fountain";
        //            BoardSize.SetValue(value, row, column);
        //    }
        //    public string [,] SetBoardSize(int boardChoice)
        //    {
        //        switch(boardChoice)
        //        {
        //            case 1:
        //                {
        //                    BoardSize = new string[4, 4];
        //                    this.SetRooms(BoardSize);
        //                    this.SetFountain(1, 3);
        //                    this.SetPit(2,1);
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    BoardSize = new string[6, 6];
        //                    this.SetRooms(BoardSize);
        //                    this.SetFountain(2, 4);
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    BoardSize = new string[8, 8];
        //                    this.SetRooms(BoardSize);
        //                    this.SetFountain(3, 6);
        //                    break;
        //                }
        //        }
        //        return BoardSize;
        //    }
        //    //public  void AdjacentRooms(List<(string value, string extraValue, int row, int column)> trap)
        //    //{
        //    //    //var boardValue = this.SetBoard(value,row, column);
        //    //    //var boardExtraValue = this.GetBoard(row, column);
        //    //    //for (int r = row - 1; r <= row + 1; r++)
        //    //    //{
        //    //    //    for (int c = column - 1; c <= column; column++)
        //    //    //    {
        //    //    //        if (r < 0 || r >= BoardSize.GetLength(0) ||
        //    //    //            c < 0 || c >= BoardSize.GetLength(1))
        //    //    //        {
        //    //    //            continue;
        //    //    //        }
        //    //    //        //BoardSize[r, c] = extraValue;
        //    //    //        if(r == row && c == column)
        //    //    //        {
        //    //    //            continue;
        //    //    //        }
        //    //    //    }
        //    //    //}
        //    //    foreach (var traps in Traps)
        //    //    {
        //    //        int checkRow = traps.row - 1;
        //    //        int checkColumn = traps.column - 1;
        //    //        if (Math.Abs(checkRow - traps.row) <= 1 &&
        //    //            Math.Abs(checkColumn - traps.column) <= 1 &&
        //    //            !(checkRow == traps.row && checkColumn == traps.column))
        //    //        {
        //    //            Console.WriteLine(traps.extraValue);
        //    //        }
                    
        //    //    }

        //    //    //return extraValue;
        //    //}
        //    //public void SetPits(int row, int column)
        //    //{
        //    //    this.AdjacentRooms("You fall into the pit!", "You feel a draft. There is a pit in a nearby room.", row, column);
        //    //}
        //    public void SetPit(int row, int column)
        //    {
        //        Traps.Add(("You fall into the pit!", "You feel a draft. There is a pit in a nearby room.",  row,  column));
        //        BoardSize.SetValue("pit", row, column);
        //    }
        //    public bool GetTrapsCheck(int row,int column)
        //    {
        //       var check =  BoardSize.GetValue(row, column);
        //        if(check!.Equals("pit"))
        //        {
        //            //Pit = true;
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        //public class Move
        //{
        //    public Board? Board { get; set; }
        //    public Compass Compass { get; set; }
        //    public int Row { get; set; }
        //    public int Column { get; set; }
        //    //public bool GameRun { get; set; } = false;


        //    public string PlayerMove(int compass)
        //    {
        //        int newRow = Row;
        //        int newColumn = Column;
        //        switch ((Compass)compass)
        //        {
        //            case Compass.North:
        //                {
        //                    newRow ++;
        //                    break;
        //                }
        //            case Compass.South:
        //                {
        //                    newRow --;
        //                    break;
        //                }
        //            case Compass.West:
        //                {
        //                    newColumn --;
        //                    break;
        //                }
        //            case Compass.East:
        //                {
        //                    newColumn ++;
        //                    break;
        //                }
        //        }
        //        var boardCheck = Board!.BoardSize;
        //        if (newColumn >= boardCheck!.GetLength(0) || newColumn < 0 ||
        //            newRow >= boardCheck!.GetLength(1) || newRow < 0)
        //        {
        //            return null;
        //        }
        //        var pits = Board.GetTrapsCheck(newRow , newColumn);
        //        if(pits)
        //        {
        //            Board.Pit = true;
        //        }
        //        Row = newRow;
        //        Column = newColumn;
        //        //var playerMove = (Row, Column);
        //        var playerOnBoard = Board.BoardSize[Row, Column];
        //        //var checkTable = Board!.GetBoard(Row, Column);
        //        return playerOnBoard;
        //    }
        //}
        //public class MoveRules:Move
        //{
        //    //public bool CantMove { get; set; } = false;
        //    public string MoveCheck(int move )
        //    {

        //        var playerMove = PlayerMove(move);

        //        if(playerMove == null)
        //        {
        //            Console.WriteLine("You can't move there");
        //            return "invalid";
        //        }

        //        return playerMove;
        //    }        
        //}
        /// entrance and exit are at 0,0. it can sense light
        /// row,column = 0,2 = fountain room, fountain are disabled,type:enable fountain,
        static void Main(string[] args)
        {
            //Board NewBoard = new Board();
            Move NewMove = new Move();
            NewMove.Board = new BoardRules();

            Console.WriteLine("Hello player.Lets start");
            Console.WriteLine();
            DateTime gameStart = DateTime.Now;
            NewMove.EntranceIntro();
            Console.WriteLine();

            var boardChoice = 0;
            bool boardSuccess = false;
            bool shootChoice = false;
            do
            {
                Console.WriteLine("Choose number for Board, 1:small , 2:medium , 3:large");
                boardChoice = Convert.ToInt32(Console.ReadLine());
                if (boardChoice <= 0 || boardChoice > 3)
                {
                    Console.WriteLine("Choose a number between 1-3");
                }
                else
                {
                    boardSuccess = true;
                }
            }
            while (!boardSuccess);

            Console.WriteLine("You can type : help ,for more info!");
            Console.WriteLine();

            NewMove.Board.SetBoardSize(boardChoice);
            do
            {
                Console.WriteLine($"You are in the room at Row:{NewMove.Row}, Column{NewMove.Column}");
                Console.WriteLine($"You have {NewMove.Arrow.NumberOfArrow} arrows");
                NewMove.Board.GetBoard(NewMove.Row, NewMove.Column);

                NewMove.CheckGameEnd(NewMove.Row, NewMove.Column);
                if (NewMove.Board.GameEnd)
                {
                    break;
                }

                if (NewMove.Board.Maelstroms)
                {
                    NewMove.CheckMaelstroms();
                    NewMove.Board.Maelstroms = false;
                    continue;
                }
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Do you want to shoot an arrow?");
                    //Console.WriteLine("You can type : help ,for more info!");
                    Console.WriteLine("Type 'yes' or 'no'");
                    var shootRequest = Console.ReadLine();
                    if (shootRequest!.ToLower() == "yes")
                    {
                        NewMove.ValidArrow = true;
                        break;
                    }
                    else if (shootRequest!.ToLower() == "no")
                    {
                        NewMove.ValidArrow = false;
                        break;
                    }
                    else if (shootRequest!.ToLower() == "help")
                    {
                        NewMove.PlayerHelp("shoot");
                        shootChoice = false;
                    }
                    else
                    {
                        shootChoice = false;
                    }
                }
                while (!shootChoice);
                if (NewMove.ValidArrow)
                {
                    do
                    {
                        Console.WriteLine("You can type : help ,for more info!");
                        Console.WriteLine("Which direction you want to shoot?");
                        var shootDirection = Console.ReadLine();
                        NewMove.PlayerArrowDirection(shootDirection!);
                        if (NewMove.ValidArrow)
                        {
                            NewMove.CheckArrow(NewMove.PlayerShoutArrow);
                            //NewMove.ValidArrow = false;
                        }
                    }
                    while (!NewMove.Arrow.ArrowCheck);
                }

                shootChoice = false;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Where do you want to move?");
                    Console.WriteLine("You can type : help ,for more info!");

                    var choice = Console.ReadLine();

                    NewMove.PlayerChoice(choice!);
                    Console.WriteLine();

                    if (NewMove.ValidMove)
                    {
                    NewMove.MoveCheck(NewMove.PlayerMove);
                    }

                    if (NewMove.Board.FindFountain == true)
                    {
                        if (choice!.ToLower() == "enable fountain")
                        {
                            NewMove.Board.Fountain = true;
                            NewMove.ValidMove = false;
                        }
                    }
                }
                while (!NewMove.ValidMove);
            }
            while (!NewMove.Board.GameEnd);
            TimeSpan totalTime = gameStart - DateTime.Now;
            Console.WriteLine(totalTime);

        }
        /// <summary>
        /// refactoring
        /// </summary>
        /// 
        public class TrappedSquare
        {
            public string? TrapMessage { get; set; }
            public string? WarningMessage { get; set; }
            public int Row { get; set; }
            public int Column { get; set; }
            public TrappedSquare(string? trapMessage, string? warningMessage, int row, int columng)
            {
                TrapMessage = trapMessage;
                WarningMessage = warningMessage;
                Row = row;
                Column = columng;
            }
         }
        public enum TrapType
        {
            Pit = 1
        }
        public class Board
        {
            public string[,] BoardSize { get; set; } = new string[0, 0];
            public bool GameEnd { get; set; } = false;
            public bool Fountain { get; set; } = false;
            public bool FindFountain { get; set; } = false;
            public bool Pit { get; set; }
            public bool Maelstroms { get; set; }
            public bool Amarok { get; set; }
            public List<TrappedSquare> TrappedSquares { get; set; } = new List<TrappedSquare>();
        }
        public class BoardRules:Board
        {
            //public Dictionary<TrapType, List<TrappedSquare>> TrapVerification { get; set; } = new Dictionary<TrapType, List<TrappedSquare>> { };
            public void SetRooms(string[,] board)
            {
                for (int i = 0; i < board!.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        BoardSize.SetValue("You are in an empty room.", i, j);
                    }
                }
                board.SetValue("You see light coming from the cavern entrance.", 0, 0);
            }
            public string[,] SetBoardSize(int boardChoice)
            {
                switch (boardChoice)
                {
                    case 1:
                        {
                            BoardSize = new string[4, 4];
                            this.SetRooms(BoardSize);
                            this.SetFountain(1, 3);
                            this.SetPit(2, 1);
                            this.SetMaelstroms(0, 2);
                            this.SetAmarok(2, 0);
                            break;
                        }
                    case 2:
                        {
                            BoardSize = new string[6, 6];
                            this.SetRooms(BoardSize);
                            this.SetFountain(2, 5);
                            this.SetPit(2, 2);
                            this.SetPit(4, 1);
                            this.SetMaelstroms(0, 4);
                            this.SetAmarok(2, 0);
                            this.SetAmarok(4, 4);
                            break;
                        }
                    case 3:
                        {
                            BoardSize = new string[8, 8];
                            this.SetRooms(BoardSize);
                            this.SetFountain(5, 6);
                            this.SetPit(1, 4);
                            this.SetPit(3, 1);
                            this.SetPit(3, 5);
                            this.SetPit(6, 3);
                            this.SetMaelstroms(1, 6);
                            this.SetMaelstroms(4, 2);
                            this.SetAmarok(2, 2);
                            this.SetAmarok(6, 5);
                            this.SetAmarok(6, 0);
                            break;
                        }
                }
                return BoardSize;
            }
            public string GetBoard(int row, int column)
            {
                var boardValue = BoardSize.GetValue(row, column);
                if (boardValue != null && boardValue!.Equals("fountain"))
                {
                    if (!FindFountain)
                    {
                        {
                            boardValue = ("You hear water dripping in this room.The Fountain of Objects is here!");
                            FindFountain = true;
                        }
                    }
                    if (Fountain)
                    {
                        boardValue = ("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                        Fountain = true;
                        //GameEnd = true;
                    }
                }


                foreach (var trap in TrappedSquares)
                {
                    if (row == trap.Row && column == trap.Column)
                    {
                        if (boardValue!.Equals("pit"))
                        {
                            Pit = true;
                        }
                        if(boardValue!.Equals("maelstroms"))
                        {
                            Maelstroms = true;
                        }
                        if(boardValue!.Equals("amarok"))
                        {
                            Amarok = true;
                        }
                        //Console.WriteLine($"DEBUG: boardValue = '{boardValue}', checking trap at ({trap.Row},{trap.Column})");
                        boardValue = trap.TrapMessage;
                    }
                    if (Math.Abs(row - trap.Row) <= 1 &&
                        Math.Abs(column - trap.Column) <= 1 &&
                        !(row == trap.Row && column == trap.Column))
                    {
                        Console.WriteLine(trap.WarningMessage);
                    }
                }

                Console.WriteLine(boardValue);
                return (string)boardValue!;
            }
            public void SetFountain(int row, int column)
            {
                string value = "fountain";
                BoardSize.SetValue(value, row, column);
            }
            public void SetPit(int row, int column)
            {
                var pit = new TrappedSquare("You fall into the pit!", "You feel a draft. There is a pit in a nearby room.", row, column);
                TrappedSquares.Add(pit);
                //TrapVerification.Add(TrapType.Pit, pit);
                BoardSize.SetValue("pit", row, column);
            }
            public void SetMaelstroms(int row,int column)
            {
                var maelstroms = new TrappedSquare("You found a Maelstrom!", "You hear the growling and groaning of a maelstrom nearby..", row, column);
                TrappedSquares.Add(maelstroms);
                BoardSize.SetValue("maelstroms", row, column);
            }
            public void SetAmarok(int row,int column)
            {
                var amarok = new TrappedSquare("Amarok charge at you!", "You can smell the rotten stench of an amarok in a nearby room.", row, column);
                TrappedSquares.Add(amarok);
                BoardSize.SetValue("amarok", row, column);
            }
            public void ReplaceMaelstroms(int row,int column)
            {

                BoardSize.SetValue("You are in an empty room.", row, column);
                int newRow = row;
                int newColumn = column;
                newRow++;
                newColumn -= 2;
                if(newRow >= BoardSize.GetLength(0))
                {
                    newRow = (BoardSize.GetLength(0) - 1);
                }
                if (newColumn < 0)
                {
                    newColumn = 0;
                }

                var pitCheck = BoardSize.GetValue(newRow, newColumn);
                if ( pitCheck!.Equals("pit"))
                {
                    Console.WriteLine("Maelstroms fall into a pit");
                }
                else
                {
                    BoardSize.SetValue("maelstroms", newRow, column);
                }
            }
            //public TrapType CheckTraps(int row,int column)
            //{
            //    TrapType key;
            //    foreach (var trap in TrapVerification)
            //    {
            //        if(trap.Value.Row == row && trap.Value.Column == column)
            //        {
            //            key = trap.Key;
            //        }               
            //    }
            //    return key;
            //}
            //public void CheckGameEnd(int row,int column)
            //{
            //    var CheckBoard = BoardSize.GetValue(row, column);
            //    if (Pit)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine("You die...");
            //        GameEnd = true;
            //    }
            //    if((Fountain && FindFountain == true)&& (row == 0 & column ==0))
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine("You did it");
            //        GameEnd = true;
            //    }
            //    if(Maelstroms)
            //    {
            //        row--;
            //        column += 2;
            //        var boardCheck = BoardSize;
            //        if (column >= boardCheck!.GetLength(0) )
            //        {
            //            column = boardCheck!.GetLength(0);
            //        }

            //        if ( row < 0)
            //        {
            //            row = 0;
            //        }
            //        //var test = (Move)BoardRules
            //    }
            //}
        }
        public enum Compass
        {
            North = 1,
            South = 2,
            East = 3,
            West = 4
        }
        public class Arrow
        {
            public int NumberOfArrow { get; set; } = 5;
            public Compass ArrowCompass { get; set; }
            public bool ArrowCheck { get; set; } = true;

            public (int,int) ShootArrow(int ArrowCompass,int row,int column)
            {
                ArrowCheck = true;
                int newRow = row;
                int newColumn = column;
                int arrowShootRow = 0;
                int arrowShootColumn = 0;
                switch ((Compass)ArrowCompass)
                {
                    case Compass.North:
                        {
                            newRow--;
                            arrowShootRow = newRow;
                            break;
                        }
                    case Compass.South:
                        {
                            newRow++;
                            arrowShootRow = newRow;
                            break;
                        }
                    case Compass.West:
                        {
                            newColumn--;
                            arrowShootColumn = newColumn;
                            break;
                        }
                    case Compass.East:
                        {
                            newColumn++;
                            arrowShootColumn = newColumn;
                            break;
                        }
                }
                //if (arrowShootRow < 0)
                //{
                //    arrowShootRow = 0;
                //    ArrowCheck = false;
                //}
                ////else if(arrowShootRow)
                //if(arrowShootColumn < 0)
                //{
                //    arrowShootColumn = 0;
                //    ArrowCheck = false;
                //}
                //if(ArrowCheck == true)
                //{
                //    NumberOfArrow--;
                //    Console.WriteLine("You shot an arrow!");
                //}
                //else
                //{
                //    Console.WriteLine("You cant shoot there.");
                //}
                
                return (arrowShootRow, arrowShootColumn);
            }

        }
        public class Move
        {
            public BoardRules Board { get; set; } = new BoardRules();
            public Compass Compass { get; set; }
            public Arrow Arrow { get; set; } = new();
            public int Row { get; set; }
            public int Column { get; set; }
            public bool ValidMove { get; set; } = true;
            public bool ValidArrow { get; set; } = true;
            public int PlayerMove { get; set; }
            public int PlayerShoutArrow { get; set; }

            private string PlayerMove2(int compass)
            {
                int newRow = Row;
                int newColumn = Column;
                switch ((Compass)compass)
                {
                    case Compass.North:
                        {
                            newRow--;
                            break;
                        }
                    case Compass.South:
                        {
                            newRow++;
                            break;
                        }
                    case Compass.West:
                        {
                            newColumn--;
                            break;
                        }
                    case Compass.East:
                        {
                            newColumn++;
                            break;
                        }
                }
                var boardCheck = Board!.BoardSize;
                if (newColumn >= boardCheck!.GetLength(0) || newColumn < 0 ||
                    newRow >= boardCheck!.GetLength(1) || newRow < 0)
                {
                    return null;
                }
                Column = newColumn;
                Row = newRow;
                var playerOnBoard = Board.BoardSize[Row, Column];
                return playerOnBoard;

            }

            public string MoveCheck(int playerMoves)
            {
               //var  move = PlayerMove;

                var playerMove = PlayerMove2(playerMoves);

                if (playerMove == null)
                {
                    Console.WriteLine("You can't move there");
                    ValidMove = false;
                    return "invalid";
                }
                //else
                //{
                //    this.CheckMaelstroms
                //}

                return playerMove;
            }
            public void PlayerChoice(string  choice)
            {
                PlayerMove = 0;
                ValidMove = true;
                switch (choice!.ToLower())
                {
                    case "move north":
                        {
                            PlayerMove = 1;
                            break;
                        }
                    case "move south":
                        {
                            PlayerMove = 2;
                            break;
                        }
                    case "move east":
                        {
                            PlayerMove = 3;
                            break;
                        }
                    case "move west":
                        {
                            PlayerMove = 4;
                            break;
                        }
                    case "help":
                        {
                            ValidMove = false;
                            this.PlayerHelp("move");
                            break;
                        }
                    default:
                        {
                            ValidMove = false;
                            Console.WriteLine("Choose direction");
                            break;
                        }      
                        
                }
            }
            public void CheckGameEnd(int row, int column)
            {
                //var CheckBoard = Board!.BoardSize.GetValue(row, column);
                if (Board.Pit)
                {
                    Console.WriteLine();
                    Console.WriteLine("You die...");
                    Board.GameEnd = true;
                }
                if ((Board.Fountain && Board.FindFountain == true) && (row == 0 & column == 0))
                {
                    Console.WriteLine();
                    Console.WriteLine("You did it");
                    Board.GameEnd = true;
                }
                if(Board.Amarok)
                {
                    Console.WriteLine();
                    Console.WriteLine("You die...");
                    Board.GameEnd = true;
                }
               
            }
            public void CheckMaelstroms()
            {
                var row = Row;
                var column = Column;
                if (Board!.Maelstroms)
                {
                    Board.ReplaceMaelstroms(row, column);
                    row--;
                    column += 2;
                    var boardCheck = Board.BoardSize;
                    if (column >= boardCheck!.GetLength(0))
                    {
                        column = (boardCheck!.GetLength(0) - 1);
                    }

                    if (row < 0)
                    {
                        row = 0;
                    }
                    Row = row;
                    Column = column;
                    Console.WriteLine();
                    Console.WriteLine("You Pushed away!");
                    Console.WriteLine();
                    Console.WriteLine("Maelstroms Pushed too!");
                    Board.Maelstroms = false;
                }
            }
            public void PlayerArrowDirection(string choice)
            {
                PlayerShoutArrow = 0;
                ValidArrow = true;
                switch (choice!.ToLower())
                {
                    case "shoot north":
                        {
                            PlayerShoutArrow = 1;
                            break;
                        }
                    case "shoot south":
                        {
                            PlayerShoutArrow = 2;
                            break;
                        }
                    case "shoot east":
                        {
                            PlayerShoutArrow = 3;
                            break;
                        }
                    case "shoot west":
                        {
                            PlayerShoutArrow = 4;
                            break;
                        }
                    case "help":
                        {
                            this.PlayerHelp("shoot");
                            ValidArrow = false;
                            break;
                        }
                    default:
                        {
                            Arrow.ArrowCheck = false;
                            ValidArrow = false;
                            Console.WriteLine("Choose valid arrow direction");
                            Console.WriteLine();
                            break;
                        }

                }
            }
            public void CheckArrow(int playerArrowDirecttion)
            {

                if (Arrow.NumberOfArrow > 0)
                {
                    var direction = Arrow.ShootArrow(playerArrowDirecttion, Row, Column);
                    if (direction.Item1 < 0 || direction.Item1 >= Board.BoardSize.GetLength(0))
                    {
                        Arrow.ArrowCheck = false;
                    }
                    if (direction.Item2 < 0 || direction.Item2 >= Board.BoardSize.GetLength(1))
                    {
                        Arrow.ArrowCheck = false;
                    }

                    if (Arrow.ArrowCheck == true)
                    {
                        Arrow.NumberOfArrow--;
                        Console.WriteLine("You shot an arrow!");
                        Console.WriteLine();

                       var CheckBoard = Board!.BoardSize.GetValue(direction.Item1, direction.Item2);

                        if (CheckBoard!.Equals("maelstroms"))
                        {
                            Board.BoardSize.SetValue("You find a dead Maelstrom.", direction.Item1, direction.Item2);
                        }
                        else if (CheckBoard!.Equals("amarok"))
                        {
                            Board.BoardSize.SetValue("You find a dead Amarok.", direction.Item1, direction.Item2);
                        }

                        var deadEnemy = Board.TrappedSquares.FirstOrDefault(enemy => enemy.Row == direction.Item1 && enemy.Column == direction.Item2);
                        if (deadEnemy != null)
                        {
                            Board.TrappedSquares.Remove(deadEnemy);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You cant shoot there.");
                        Console.WriteLine();
                    }
                }
                else if (Arrow.NumberOfArrow <= 0)
                {
                    Console.WriteLine("You are out of arrow");
                }
                //string shout = Console.WriteLine("You shot an arrow");
                //return shout;
            }
            public void EntranceIntro()
            {
                string story = "You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.\n" +
                    "Light is visible only in the entrance, and no other light is seen anywhere in the caverns.\n" +
                    "You must navigate the Caverns with your other senses.\n" +
                    "Find the Fountain of Objects, activate it, and return to the entrance.\n" +
                    "Beware Hero!!\n" +
                    "Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.\n" +
                    "Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location \nin the caverns. You will be able to hear their growling and groaning in nearby rooms.\n" +
                    "Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.\n" +
                    "You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: \nyou have a limited supply.\n";
                Console.WriteLine(story);
            }
            public void PlayerHelp(string moveOrShoot)
            {
                string text = "";
                if(moveOrShoot == "move")
                {
                    text = "To move you must choose a direction.\n" +
                        "For north type :move north.\n" +
                        "For South type : move south.\n" + 
                        "For East type : move east.\n" +
                        "For West type : move west."; 
                }
                else if(moveOrShoot == "shoot")
                {
                    text = "To shoot an arrow you must choose a direction.\n" +
                        "To shoot north type : shoot north.\n" +
                        "To shoot South type : shoot south.\n" +
                        "To shoot East type : shoot east.\n" +
                        "To shoot West type : shoot west.";
                }
                Console.WriteLine();
                Console.WriteLine(text);
            }
        }
    }

}

