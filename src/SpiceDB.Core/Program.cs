// See https://aka.ms/new-console-template for more information
using SpiceDBProtoTest;

Console.WriteLine("Hello, World!");

Auth auth = new Auth();
//auth.LoadSchema();
await auth.Test();
Console.ReadLine();