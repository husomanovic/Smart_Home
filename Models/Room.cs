namespace Rooms
{

    using Devices;

    public class Room
    {
        private List<Device> Devices { get; set; }
        private string Name { get; set; }

        public Room(string name)
        {
            Name = name;
            Devices = new List<Device>();
        }

        public void AddDevice()
        {

            Console.WriteLine("Device type : ");
            Console.WriteLine("1. TV");
            Console.WriteLine("2. Light");
            Console.WriteLine("3. Air conditioning");
            Console.WriteLine("4. Vacuum cleaner");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Enter your choice: ");

            var input = Console.ReadLine();
            if (input != "1" && input != "2" && input != "3" && input != "4" && input != "0")
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            if (input == "0")
                return;

            Console.WriteLine("Enter device name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter device IP address: ");
            string ipaddress = Console.ReadLine();
            Console.WriteLine("Enter device MAC address: ");
            string macaddress = Console.ReadLine();

            if (name == "" || ipaddress == "" || macaddress == "")
            {
                Console.WriteLine("Invalid input data.");
                return;
            }

            switch (input)
            {
                case "1":
                    Devices.Add(new TV(name, ipaddress, macaddress));
                    break;
                case "2":
                    Devices.Add(new Light(name, ipaddress, macaddress));
                    break;
                case "3":
                    Devices.Add(new AirConditioning(name, ipaddress, macaddress));
                    break;
                case "4":
                    Devices.Add(new VacuumCleaner(name, ipaddress, macaddress));
                    break;
            }

        }

        public void ShowAllDevicesInfo()
        {
            foreach (var device in Devices)
            {
                device.ShowInfo();
                Console.WriteLine();
            }
        }

        public void ShowInfo()
        {
            int count = 1;
            Console.WriteLine($"Room name: {Name}");
            Console.WriteLine("Devices: ");
            foreach (var device in Devices)
            {
                Console.WriteLine($"{count}. : {device.GetName()}");
                count++;
            }

        }

        public void ChangeRoomName()
        {
            Console.WriteLine("Enter new room name: ");
            string input = Console.ReadLine() ?? "";
            if (input != "")
            {
                Name = input;
                Console.WriteLine($"Room name changed to {Name}");
            }
            else
            {
                Console.WriteLine("Room name cannot be empty");
            }
        }


        public void ShowDeviceOperations()
        {
            Console.WriteLine("Devices: ");
            for (int i = 0; i < Devices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Devices[i].GetName()}");
            }
            Console.WriteLine("0. Exit");
            Console.WriteLine();

            Console.WriteLine("Enter device number: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int deviceNumber) && deviceNumber > 0 && deviceNumber <= Devices.Count)
            {
                if (deviceNumber == 0)
                    return;

                Devices[deviceNumber - 1].ShowOperations();
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return;
            }
        }

    }

}