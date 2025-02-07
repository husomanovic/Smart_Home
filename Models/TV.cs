public class TV : Device
{

    private int Channel { get; set; }
    private int Volume { get; set; }
    private bool Muted { get; set; }


    public TV(string name, string ipaddress, string macaddress, bool isON = false, int channel = 0, int volume = 0) : base(name, ipaddress, macaddress, isON)
    {
        Channel = channel;
        Volume = volume;
        Muted = false;
    }

    public override void PowerOFF()
    {
        IsON = false;
        Console.WriteLine("TV is off");
    }

    public override void PowerON()
    {
        IsON = true;
        Console.WriteLine("TV is on");
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        if (!IsON)
            return;

        Console.WriteLine($"Channel: {Channel}");
        Console.WriteLine($"Volume: {Volume}");
        Console.WriteLine($"Muted: {Muted}");

    }


    publi override void ShowOperations()
    {
        Console.WriteLine("TV operations: ");
        Console.WriteLine("1. Power ON");
        Console.WriteLine("2. Power OFF");
        Console.WriteLine("3. Show info");
        Console.WriteLine("4. Change name");
        Console.WriteLine("5. Change channel");
        Console.WriteLine("6. Next channel");
        Console.WriteLine("7. Previous channel");
        Console.WriteLine("8. Increase volume");
        Console.WriteLine("9. Decrease volume");
        Console.WriteLine("10. Mute/Unmute");
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
                ChangeChannel();
                break;
            case "6":
                NextChannel();
                break;
            case "7":
                PreviousChannel();
                break;
            case "8":
                IncreaseVolume();
                break;
            case "9":
                DecreaseVolume();
                break;
            case "10":
                Mute();
                break;
            case "0":
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }


    public void ChangeChannel()
    {
        if (!isON)
        {
            Console.WriteLine("TV is off");
            return;
        }

        Console.WriteLine("Enter channel number: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out int channel))
        {
            if (channel < 0 || channel > 1000)
            {
                Console.WriteLine("Invalid channel");
                return;
            }

            Channel = channel;
            Console.WriteLine($"Channel changed to {Channel}");
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }

    public void NextChannel()
    {
        if (!isON)
        {
            Console.WriteLine("TV is off");
            return;
        }

        (Channel = 999) ? Channel = 0 : Channel++;
        Console.WriteLine($"Channel changed to {Channel}");
    }

    public void PreviousChannel()
    {
        if (!isON)
        {
            Console.WriteLine("TV is off");
            return;
        }

        (Channel = 0) ? Channel = 999 : Channel--;
        Console.WriteLine($"Channel changed to {Channel}");
    }



    public void Mute()
    {
        Muted = !Muted;
        if (Muted)
            Console.WriteLine("TV is muted");
        else
            Console.WriteLine("TV is unmuted");
    }

    public void IncreaseVolume()
    {
        if (!isON)
        {
            Console.WriteLine("TV is off");
            return;
        }

        (Volume = 100) ? Volume = 0 : Volume++;
        Console.WriteLine($"Volume changed to {Volume}");
    }

    public void DecreaseVolume()
    {
        if (!isON)
        {
            Console.WriteLine("TV is off");
            return;
        }

    (Volume = 0) ? Volume = 100 : Volume--;
        Console.WriteLine($"Volume changed to {Volume}");
    }
}