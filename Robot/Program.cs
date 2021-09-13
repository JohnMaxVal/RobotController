using System;

namespace Robot
{
    using Panel = ControlPanel.ControlPanel;
    using ControlPanel.InputParameters;
    using Robot = Robot.Device.Machine;
    using Robot.Device;

    class Program
    {
        static void Main(string[] args)
        {
            Panel panel = new Panel();

            while (true)
            {
                try
                {
                    Robot robot = new Robot(panel);
                    Console.Write("Enter Grapth Upper Right Coordinates: ");
                    panel.AddParameter(new GridParameter(), Console.ReadLine());
                    Console.Write($"Rover {Robot.Version} Starting Position: ");
                    panel.AddParameter(new PositionParameter(), Console.ReadLine());
                    Console.Write($"Rover {Robot.Version} Movement Plan: ");
                    panel.AddParameter(new MoveCommandsParameter(), Console.ReadLine());

                    robot.Move();
                    Console.WriteLine($"Rover {Robot.Version} Output: " +
                        $"{robot.CurrentPosition.X} " +
                        $"{robot.CurrentPosition.Y} " +
                        $"{robot.CurrentPosition.Direction}");
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Error: {e.Message}\nStack trace: {e.StackTrace}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}\nStack trace: {e.StackTrace}");
                }
            }
        }

    }
}
