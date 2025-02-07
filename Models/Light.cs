class Light : Device
{

    private int Brightness { get; set; }
    private string Color { get; set; }


    public Light(string name, string ipaddress, string macaddress, bool isON = false, string color = "white", int brightness = 0) : base(name, ipaddress, macaddress, isON)
    {
        Color = color;
        Brightness = (brightness >= 0 && brightness <= 100) ? brightness : 0;
    }


    public override void ShowInfo()
    {
        base.ShowInfo();
        if (!IsON)
            return;

        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Brightness: {Brightness}");
    }

    public override void ShowOperations()
    {
        Console.WriteLine("TV operations: ");
        Console.WriteLine("1. Power ON");
        Console.WriteLine("2. Power OFF");
        Console.WriteLine("3. Show info");
        Console.WriteLine("4. Change name");
        Console.WriteLine("5. Change color");
        Console.WriteLine("6. Change brightness");
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
                ChangeColor();
                break;
            case "6":
                ChangeBrightness();
                break;
            case "0":
                break;
        }
    }

    public override void PowerON()
    {
        IsON = true;
        Console.WriteLine("Light is on");
    }

    public override void PowerOFF()
    {
        IsON = false;
        Console.WriteLine("Light is off");
    }


    public void ChangeColor()
    {
        Console.WriteLine("Enter new color: ");
        string input = Console.ReadLine();
        if (input != "")
        {
            Color = input;
            Console.WriteLine($"Color changed to {Color}");
        }
        else
        {
            Console.WriteLine("Color cannot be empty");
        }
    }

    public void ChangeBrightness()
    {
        Console.WriteLine("Enter new brightness: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int brightness))
        {
            0 <= brightness <= 100 ? Brightness = brightness : Brightness = 0;
            Console.WriteLine($"Brightness changed to {Brightness}");
        }
        else
        {
            Console.WriteLine("Brightness must be between 0 and 100.");
        }
    }
}