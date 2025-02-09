namespace Devices
{
    public class AirConditioning : Device
    {
        private int Temperature { get; set; }
        private int FanSpeed { get; set; }

        public AirConditioning(string name, string ipaddress, string macaddress, bool isON = false, int temperature = 20, int fanSpeed = 100) : base(name, ipaddress, macaddress, isON)
        {
            Temperature = (temperature >= 16 && temperature <= 30) ? temperature : 20;
            FanSpeed = (fanSpeed >= 0 && fanSpeed <= 100) ? fanSpeed : 100;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            if (!IsON)
                return;

            Console.WriteLine($"Temperature: {Temperature}");
            Console.WriteLine($"Fan speed: {FanSpeed}%");
        }

        public override void PowerON()
        {
            IsON = true;
            Console.WriteLine("Air conditioning is on");
        }

        public override void PowerOFF()
        {
            IsON = false;
            Console.WriteLine("Air conditioning is off");
        }

        public override void ShowOperations()
        {

            Console.WriteLine("Air conditioning operations: ");
            Console.WriteLine("1. Power ON");
            Console.WriteLine("2. Power OFF");
            Console.WriteLine("3. Show info");
            Console.WriteLine("4. Change name");
            Console.WriteLine("5. Increase temperature");
            Console.WriteLine("6. Decrease temperature");
            Console.WriteLine("7. Change fan speed");
            Console.WriteLine("8. Increase fan speed");
            Console.WriteLine("9. Decrease fan speed");
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
                    IncreaseTemperature();
                    break;
                case "6":
                    DecreaseTemperature();
                    break;
                case "7":
                    ChangeFanSpeed();
                    break;
                case "8":
                    IncreaseFanSpeed();
                    break;
                case "9":
                    DecreaseFanSpeed();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public void IncreaseTemperature()
        {
            if (!IsON)
            {
                Console.WriteLine("Air conditioning is off");
                return;
            }

            if (Temperature != 30)
                Temperature++;

            Console.WriteLine($"Temperature changed to {Temperature}");
        }

        public void DecreaseTemperature()
        {
            if (!IsON)
            {
                Console.WriteLine("Air conditioning is off");
                return;
            }

            if (Temperature != 16)
                Temperature--;

            Console.WriteLine($"Temperature changed to {Temperature}");
        }


        public void IncreaseFanSpeed()
        {

            if (!IsON)
            {
                Console.WriteLine("Air conditioning is off");
                return;
            }

            if (FanSpeed != 100)
                FanSpeed++;

            Console.WriteLine($"Fan speed changed to {FanSpeed}%");
        }

        public void DecreaseFanSpeed()
        {
            if (!IsON)
            {
                Console.WriteLine("Air conditioning is off");
                return;
            }

            if (FanSpeed != 0)
                FanSpeed--;

            Console.WriteLine($"Fan speed changed to {FanSpeed}%");
        }

        public void ChangeFanSpeed()
        {
            Console.WriteLine("Enter new fan speed: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int fanSpeed))
            {
                FanSpeed = (fanSpeed >= 0 && fanSpeed <= 100) ? fanSpeed : FanSpeed;
                Console.WriteLine($"Fan speed changed to {FanSpeed}%");
            }
            else
            {
                Console.WriteLine("Fan speed must be between 0 and 100.");
            }
        }

    }
}