using CommandLine;
using iAgeTest.Commands;
using iAgeTest.Interface;
using iAgeTest.Models;
using System.Text.Json;


string path = Directory.GetCurrentDirectory().Replace(@"bin\Debug\net6.0", @"Data\ListOfEmployees.json");
var jsonRead = File.ReadAllText(path);
var list = JsonSerializer.Deserialize<List<Employee>>(jsonRead);

Parser.Default.ParseArguments<AddCommand, DeleteCommand, GetAllCommand, GetCommand, UpdateCommand>(args)
              .WithParsed<ICommand<Employee>>(t => t.Execute(list!));

var jsonWrite = JsonSerializer.Serialize(list);
File.WriteAllText(path, jsonWrite);