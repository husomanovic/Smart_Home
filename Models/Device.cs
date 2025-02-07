public abstract class Device
{
    protected string Name { get; set; }
    protected string IPaddress { get; set; }
    protected string MACaddress { get; set; }
    protected bool IsON { get; set; }

    public Device(string name, string ipaddress, string macaddress, bool isON = false)
    {
        Name = name;
        IPaddress = ipaddress;
        MACaddress = macaddress;
        IsON = isON;
    }

    public abstract void PowerON();
    public abstract void PowerOFF();
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"IP address: {IPaddress}");
        Console.WriteLine($"MAC address: {MACaddress}");
        Console.WriteLine($"Device is {IsON ? 'ON' : 'OFF'}");
    }
    public abstract void ShowOperations();

    public virtual void ChangeName()
    {
        Console.WriteLine("Enter new name: ");
        string input = Console.ReadLine();
        if (input != "")
        {
            Name = input;
            Console.WriteLine($"Name changed to {Name}");
        }
        else
        {
            Console.WriteLine("Name cannot be empty");
        }
    }
}