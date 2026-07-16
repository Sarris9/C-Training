using static Learning7.Program.Robot;

namespace Learning7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            IRobotCommand robotONCommand = new OnCommand();
            IRobotCommand robotOFFCommand = new OffCommand();
            IRobotCommand robotNorthCommand = new NorthCommand();
            IRobotCommand robotSouthCommand = new SouthCommand();
            IRobotCommand robotWestCommand = new WestCommand();
            IRobotCommand robotEastCommand = new EastCommand();
            //robot.Commands[0] = robotONCommand;
            //robot.Commands[1] = robotNorthCommand;
            //robot.Commands[2] = robotEastCommand;
            //robot.Run();
            Console.WriteLine("The Robot are turned off.");
            Console.WriteLine();
            //robot.IsPowered = false;
            Console.WriteLine("Do you want to turn it on and move it?");
            Console.WriteLine();
            Console.WriteLine("Press Y for 'yes' or N for 'no'");
            Console.WriteLine();
            var turnOnOrOff = Console.ReadLine();
            if (turnOnOrOff!.ToLower() == "n")
            {
                //robot.Commands[0] = robotOFFCommand;
                Console.WriteLine("Ok then. Have a nice day.");
                return;
            }
            if (turnOnOrOff.ToLower() == "y")
            {
                Console.WriteLine("To turn off the Robot, type 'stop'.");
                //robot.IsPowered = true;
                robot.Commands.Add(robotONCommand);
            }
            robot.Run();
            Console.WriteLine();
            do
            {
                //for (int i = 1; i < robot.Commands.Count; i++)
                //{
                    Console.WriteLine("Where do you want to move?");
                    Console.WriteLine();
                    Console.WriteLine("You can go North,South,West and East.");
                    Console.WriteLine();
                    Console.WriteLine("Choose...");
                Console.WriteLine();
                    var direction = Console.ReadLine();
                    switch (direction!.ToLower())
                    {
                        case "north":
                            {
                            robot.Commands.Add(robotNorthCommand);
                            robot.Run();
                            robot.Commands.Remove(robotNorthCommand);
                            break;
                            }
                        case "south":
                            {
                            //robot.Commands[i] = robotSouthCommand;
                            robot.Commands.Add(robotSouthCommand);
                            robot.Run();
                            robot.Commands.Remove(robotSouthCommand);
                            break;
                            }
                        case "west":
                            {
                            //robot.Commands[i] = robotWestCommand;
                            robot.Commands.Add(robotWestCommand);
                            robot.Run();
                            robot.Commands.Remove(robotWestCommand);

                            break;
                            }
                        case "east":
                            {
                            //robot.Commands[i] = robotEastCommand;
                            robot.Commands.Add(robotEastCommand);
                            robot.Run();
                            robot.Commands.Remove(robotEastCommand);
                            break;
                        }
                    case "stop":
                        {
                            robot.Commands.Add(robotOFFCommand);
                            robot.Run();
                            Console.WriteLine("Ok then. Have a nice day.");
                            break;
                        }
                    default:
                            {
                                break;
                            }
                    }
                //}
                Console.WriteLine();
                
                //robot.Run();
                //Console.WriteLine("Do you want to turn off the Robot?");
                //Console.WriteLine("To turn off the Robot, type 'stop'.");
                //Console.WriteLine();
                //Console.WriteLine("Press Y for 'yes' or N for 'no'");
                //turnOnOrOff = Console.ReadLine();
                //if (turnOnOrOff!.ToLower() == "stop")
                //{
                //    robot.Commands[0] = robotOFFCommand;
                //    Console.WriteLine("Ok then. Have a nice day.");
                //    return;
                //}
                //if (turnOnOrOff.ToLower() == "y")
                //{
                //    //robot.IsPowered = true;
                //    robot.Commands[0] = robotONCommand;
                //}
            }
            while (robot.IsPowered);
        }
        public class Robot
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsPowered { get; set; }
            public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();
            public void Run()
            {
                foreach (IRobotCommand? command in Commands)
                {
                    command?.Run(this);
                    Console.WriteLine($"[{X} {Y} {IsPowered}]");
                }
            }
            public interface  IRobotCommand
            {
                  void Run(Robot robot);
            }
            public class OnCommand : IRobotCommand
            {
                public  void Run(Robot robot)
                {
                    robot.IsPowered = true;
                }
            }
            public class OffCommand : IRobotCommand
            {
                public  void Run(Robot robot)
                {
                    robot.IsPowered = false;
                }
            }
            public class NorthCommand : IRobotCommand
            {
                public  void Run(Robot robot)
                {
                    if (robot.IsPowered == true)
                        robot.Y += 1;
                }
            }
            public class SouthCommand : IRobotCommand
            {
                public  void Run(Robot robot)
                {
                    if (robot.IsPowered == true)
                        robot.Y -= 1;
                }
            }
            public class WestCommand : IRobotCommand
            {
                public  void Run(Robot robot)
                {
                    if (robot.IsPowered == true)
                        robot.X += 1;
                }
            }
            public class EastCommand : IRobotCommand
            {
                public  void Run(Robot robot)
                {
                    if (robot.IsPowered == true)
                        robot.X -= 1;
                }
            }
        }
    }
}
