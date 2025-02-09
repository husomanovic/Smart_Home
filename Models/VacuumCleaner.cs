namespace Devices
{
    public class VacuumCleaner : Device
    {

        public int Battery { get; set; }

        public VacuumCleaner(string name, string ipaddress, string macaddress, bool isON = false, int battery = 0) : base(name, ipaddress, macaddress, isON)
        {
            Battery = (battery <= 100 && battery >= 0) ? battery : 0;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            if (!IsON)
                return;

            Console.WriteLine($"Battery: {Battery}%");

        }

        public override void PowerON()
        {
            IsON = true;
            Console.WriteLine("Vacuum cleaner is on");
        }

        public override void PowerOFF()
        {
            IsON = false;
            Console.WriteLine("Vacuum cleaner is off");
        }

        public override void ShowOperations()
        {

            Console.WriteLine("Vacuum cleaner operations: ");
            Console.WriteLine("1. Power ON");
            Console.WriteLine("2. Power OFF");
            Console.WriteLine("3. Show info");
            Console.WriteLine("4. Change name");
            Console.WriteLine("5. Start cleaning");
            Console.WriteLine("6. Stop cleaning");
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
                    StartCleaning();
                    break;
                case "6":
                    StopCleaning();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }


        }



        public void StartCleaning()
        {
            if (!IsON)
            {
                Console.WriteLine("Vacuum cleaner is off");
                return;
            }
            Console.WriteLine("Start cleaning");
        }

        public void StopCleaning()
        {
            if (!IsON)
            {
                Console.WriteLine("Vacuum cleaner is off");
                return;
            }
            Console.WriteLine($"Stop cleaning, battery: {Battery}%");
            Console.WriteLine("Going to charge");
        }

    }
}