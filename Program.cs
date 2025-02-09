// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Rooms;

var room = new Room("Living Room");
room.AddDevice();
// Console.WriteLine();
// room.ShowAllDevicesInfo();

Console.WriteLine();

room.ShowDeviceOperations();

Console.WriteLine();
room.ShowAllDevicesInfo();