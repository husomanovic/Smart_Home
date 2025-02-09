namespace Devices
{
    public class Alarm : Device
    {
        public static bool ActvateAlarm { get; set; } = false;
        public Alarm(string name, string ipaddress, string macaddress, bool isON = false) : base(name, ipaddress, macaddress, isON)
        {
        }

        public override void PowerOFF()
        {
            IsON = false;
            Console.WriteLine("Alarm is off");
        }
        public override void PowerON()
        {
            IsON = true;
            Console.WriteLine("Alarm is on");
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            if (!IsON)
                return;
            Console.WriteLine($"Activate : {(ActvateAlarm ? "ON" : "OFF")}");
        }

        public override void ShowOperations()
        {

            Console.WriteLine("Alarm operations: ");
            Console.WriteLine("TV operations: ");
            Console.WriteLine("1. Power ON");
            Console.WriteLine("2. Power OFF");
            Console.WriteLine("3. Show info");
            Console.WriteLine("4. Change name");
            Console.WriteLine("5. Activate alarm");
            Console.WriteLine("6. Deactivate alarm");
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
                    ActivateAlarm();
                    break;
                case "6":
                    DeactivateAlarm();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        }

        public void DeactivateAlarm()
        {
            ActvateAlarm = false;
            Console.WriteLine("Alarm is deactivated");
        }

        public void ActivateAlarm()
        {
            ActvateAlarm = true;
            Console.WriteLine("Alarm is activated");
        }

        public bool IsAlarmActivated() => ActvateAlarm;

    }
}