using Rooms;
using Devices;

namespace Smart_Home
{
    public class Home
    {
        private string Name { get; set; }

        private Alarm SecurityAlarm { get; set; }
        private List<Room> Rooms { get; set; }
        private List<Camera> Cameras { get; set; }


        public Home(string name)
        {
            Name = name;
            Rooms = new List<Room>();
            Cameras = new List<Camera>();
            SecurityAlarm = new Alarm("Security Alarm", "127.0.0.1", "00:00:00:00:00:00");
        }

        public void AddRoom()
        {
            Console.WriteLine("Enter room name:");
            string roomName = Console.ReadLine() ?? "";

            if (roomName != "")
            {
                Rooms.Add(new Room(roomName));
                Console.WriteLine($"Room {roomName} added.");
            }
            else
            {
                Console.WriteLine("Room name cannot be empty.");
            }
        }

        public void AddCamera()
        {
            Console.WriteLine("Enter camera name:");
            string cameraName = Console.ReadLine() ?? "";
            if (cameraName == "")
            {
                Console.WriteLine("Camera name cannot be empty.");
                return;
            }
            Console.WriteLine("Enter camera IP address:");
            string cameraIPaddress = Console.ReadLine() ?? "127.0.0.1";
            Console.WriteLine("Enter camera MAC address:");
            string cameraMACaddress = Console.ReadLine() ?? "00:00:00:00:00:00";

            Console.WriteLine("Enter '1' if you want to ON the camera.");
            string isON = Console.ReadLine() ?? "0";

            Console.WriteLine("Enter position:");
            string position = Console.ReadLine() ?? "";

            Console.WriteLine("Enter room name:");
            string roomName = Console.ReadLine() ?? "";

            Cameras.Add(new Camera(cameraName, cameraIPaddress, cameraMACaddress, isON == "1" ? true : false, position, roomName));
            Console.WriteLine($"Camera {cameraName} added.");

        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine();

            int i = 1;
            Console.WriteLine("Rooms:");
            foreach (Room room in Rooms)
            {
                Console.WriteLine($"{i++}. {room.GetName()}");
            }
            Console.WriteLine();

            i = 1;
            Console.WriteLine("Cameras:");
            foreach (Camera camera in Cameras)
            {
                Console.WriteLine($"{i++}. {camera.GetName()}");
            }
            Console.WriteLine();
            Console.WriteLine($"Security alarm is {(SecurityAlarm.IsAlarmActivated() ? "ON" : "OFF")}");

        }

        public void ChangetName()
        {
            Console.WriteLine("Enter new home name:");
            string newName = Console.ReadLine() ?? "";
            if (newName != "")
            {
                Name = newName;
                Console.WriteLine($"Home name changed to {Name}");
            }
            else
            {
                Console.WriteLine("Home name cannot be empty.");
            }
        }

        public void EditRoom()
        {
            for (int i = 1; i <= Rooms.Count; i++)
            {
                Console.WriteLine($"{i}. {Rooms[i - 1].GetName()}");
            }
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter your choice:");
            var input = Console.ReadLine() ?? "";

            if (input == "0")
                return;

            if (int.TryParse(input, out int roomNumber) && roomNumber > 0 && roomNumber <= Rooms.Count)
            {
                Rooms[roomNumber - 1].ShowOperations();
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

        }

        public void EditCamera()
        {
            for (int i = 1; i <= Cameras.Count; i++)
            {
                Console.WriteLine($"{i}. {Cameras[i - 1].GetName()}");
            }
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter your choice:");
            var input = Console.ReadLine() ?? "";

            if (input == "0")
                return;

            if (int.TryParse(input, out int cameraNumber) && cameraNumber > 0 && cameraNumber <= Cameras.Count)
            {
                Cameras[cameraNumber - 1].ShowOperations();
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        public void ShowOperations()
        {
            Console.WriteLine("Home operations: ");
            Console.WriteLine("1. Show info");
            Console.WriteLine("2. Change name");
            Console.WriteLine("3. Add room");
            Console.WriteLine("4. Add camera");
            Console.WriteLine("5. Edit room");
            Console.WriteLine("6. Edit camera");
            Console.WriteLine("7. Security alarm options");
            Console.WriteLine("0. Exit Program");
            Console.WriteLine("Enter your choice: ");

            var input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "1":
                    ShowInfo();
                    break;
                case "2":
                    ChangetName();
                    break;
                case "3":
                    AddRoom();
                    break;
                case "4":
                    AddCamera();
                    break;
                case "5":
                    EditRoom();
                    break;
                case "6":
                    EditCamera();
                    break;
                case "7":
                    SecurityAlarm.ShowOperations();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }

        }

    }
}