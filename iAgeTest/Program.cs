using CommandLine;
using iAgeTest.Commands;
using iAgeTest.Interface;
using iAgeTest.Models;
using System.Text.Json;

//Get path to JSON file
string path = Directory.GetCurrentDirectory().Replace(@"bin\Debug\net6.0", @"Data\ListOfEmployees.json");
//Read file and deserialize it
var jsonRead = File.ReadAllText(path);
var list = JsonSerializer.Deserialize<List<Employee>>(jsonRead);
//Parse input commands and run them
Parser.Default.ParseArguments<AddCommand, DeleteCommand, GetAllCommand, GetCommand, UpdateCommand>(args)
              .WithParsed<ICommand<Employee>>(t => t.Execute(list!));
//Serialize file after changes
var jsonWrite = JsonSerializer.Serialize(list);
File.WriteAllText(path, jsonWrite);