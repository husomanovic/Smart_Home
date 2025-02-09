namespace Devices
{
    class Camera : Device
    {
        private string Position { get; set; }
        private string RoomName { get; set; }

        public Camera(string name, string ipaddress, string macaddress, bool isON = false, string position = "", string roomName = "") : base(name, ipaddress, macaddress, isON)
        {
            Position = position;
            RoomName = roomName;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            if (!IsON)
                return;

            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Room: {RoomName}");
        }

        public override void PowerOFF()
        {
            IsON = false;
            Console.WriteLine("Camera is off");
        }

        public override void PowerON()
        {
            IsON = true;
            Console.WriteLine("Camera is on");
        }

        public override void ShowOperations()
        {

            Console.WriteLine("Camera operations: ");
            Console.WriteLine("1. Power ON");
            Console.WriteLine("2. Power OFF");
            Console.WriteLine("3. Show info");
            Console.WriteLine("4. Change name");
            Console.WriteLine("5. Change position");
            Console.WriteLine("6. Change room name");
            Console.WriteLine("7. Show picture");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter your choice: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    PowerON();
                    break;
                case "2":
                    PowerOFF();
                    break;
                case "3":
                    ShowInfo();
                    break;
                case "4":
                    ChangeName();
                    break;
                case "5":
                    ChangePosition();
                    break;
                case "6":
                    ChangeRoomName();
                    break;
                case "7":
                    ShowPicture();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        public void ShowPicture()
        {
            Console.WriteLine();
            Console.WriteLine("            /\\        ");
            Console.WriteLine("           /  \\       ");
            Console.WriteLine("          /    \\      ");
            Console.WriteLine("         /      \\     ");
            Console.WriteLine("        /        \\    ");
            Console.WriteLine("       /\\        /|   ");
            Console.WriteLine("      /  \\      / |   ");
            Console.WriteLine("     /    \\    /  |   ");
            Console.WriteLine("    /      \\  /   |   ");
            Console.WriteLine("   /________\\/    |   ");
            Console.WriteLine("   |   __   |  /| |   ");
            Console.WriteLine("   |  |__|  | |/ /    ");
            Console.WriteLine("   |        |   /     ");
            Console.WriteLine("   |   __   |  /      ");
            Console.WriteLine("   |  |  |  | /       ");
            Console.WriteLine("   |__|__|__|/        ");
            Console.WriteLine();

        }

        public void ChangePosition()
        {
            Console.WriteLine("Enter new position: ");
            string input = Console.ReadLine() ?? "";
            if (input != "")
            {
                Position = input;
                Console.WriteLine($"Position changed to {Position}");
            }
            else
            {
                Console.WriteLine("Position cannot be empty");
            }
        }

        public void ChangeRoomName()
        {
            Console.WriteLine("Enter new room name: ");
            string input = Console.ReadLine() ?? "";
            if (input != "")
            {
                RoomName = input;
                Console.WriteLine($"Room name changed to {RoomName}");
            }
            else
            {
                Console.WriteLine("Room name cannot be empty");
            }
        }
    }
}