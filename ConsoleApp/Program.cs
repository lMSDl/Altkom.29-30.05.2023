using System;

//namespace ConsoleApp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//Instrukcja najwyższego poziomu


Console.WriteLine($"Hello, {args[0]}!");
JsonConvert.SerializeObject(new object());

string? name = "ALA";
string result = ToLower(name)!; // ! - uspokaja warningi przy niezgodności typu NULL z nieNULL

string? ToLower(string? value /*!! - parameter null-checking feature - automatycznie dodaje kod jak poniżej*/)
{
    /*if(value == null)
        throw new ArgumentNullException("value");*/

    return value?.ToLower();
}



//        }
//    }
//}