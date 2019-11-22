using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day8_DictionariesAndMaps
    {
        //public void PhoneBook()
        //{
        //    Console.Write("Enter a number between 2 and 5: ");
        //    var inputNum = Int32.TryParse(Console.ReadLine(), out int number);
        //    var phoneBook = new Dictionary<string, string>();

        //    for (int i = 0; i < number; i++)
        //    {
        //        Console.Write("Enter a name and a phone number:  ");

        //        string[] nameNumber = Console.ReadLine().Split(' ');

        //        phoneBook.Add(nameNumber[0], nameNumber[1]);
        //    }

        //    string[] names = new string[number];

        //    Console.Write("Enter a name whose phone number you want to get: ");

        //    for (int i = 0; i < number; i++)
        //    {
        //        names[i] = Console.ReadLine();
        //    }

        //    foreach (var name in names)
        //    {
        //        if (phoneBook.ContainsKey(name))
        //        {
        //            Console.Write(name + "=" + phoneBook[name]);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Not found");
        //        }    
        //    }
        //}



        // Tutorial:
        public void AddToDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Monday", "Lunes");
            dictionary.Add("Tuesday", "Martes");
            dictionary.Add("Wednesday", "Miercoles");
            dictionary.Add("Thursday", "Jueves");
            dictionary.Add("Friday", "Viernes");
            dictionary.Add("Saturday", "Sabado");
            dictionary.Add("Sunday", "Domingo");

            string value;
            if (dictionary.TryGetValue("Friday", out value))
            {
                Console.WriteLine($"Friday is {value} in Spanish!");
            }

            Console.WriteLine();

            foreach (var item in dictionary)
            {
                Console.Write(item.Key + ", ");
                Console.WriteLine(item.Value);
            }

            Console.WriteLine();

            foreach (var element in dictionary)
            {
                value = element.Value;
                var key = element.Key;
                Console.WriteLine($"Key: {key} --> Value: {value}");
            }

            //Console.WriteLine();
            //foreach (var item in dictionary)
            //{
            //    Console.Write(item.Value + ", ");
            //}
            //Console.WriteLine();
            //Console.WriteLine($"The side of dictionary is: {dictionary.Count}");


            //Console.WriteLine();
            //Console.WriteLine();

            //// Getting Values by keys
            //foreach (var itemKey in dictionary.Keys)
            //{
            //    Console.WriteLine(dictionary[itemKey]);
            //}

            //// Getting Values by values
            //foreach (var itemValue in dictionary.Values)
            //{
            //    Console.WriteLine(itemValue);
            //}
        }

        //public void ShoppingList()
        //{
        //    // ShoppingList
        //    var shoppingList = new Dictionary<string, Boolean>();
        //    shoppingList.Add("Ham", true);
        //    shoppingList.Add("Bread", true);
        //    shoppingList.Add("Oreos", true);
        //    shoppingList.Add("Eggs", false);
        //    shoppingList.Add("Sugar", false);

        //    Console.WriteLine(shoppingList["Ham"]);
        //    Console.WriteLine(shoppingList["Sugar"]);

        //    Console.WriteLine(shoppingList.Count);
        //    Console.WriteLine(shoppingList.Any());
        //    // remove a key
        //    shoppingList.Remove("Eggs");
        //    Console.WriteLine(shoppingList.Count);
        //    // replace a key
        //    Console.WriteLine($"Bread was {shoppingList["Bread"]} now");
        //    shoppingList["Bread"] = false;
        //    Console.WriteLine($"Bread is {shoppingList["Bread"]} now");

        //    foreach (var item in shoppingList)
        //    {
        //        Console.Write(item.Key + ":" + item.Value + " ");
        //    }
        //    Console.WriteLine();
        //    shoppingList.Clear();
        //    Console.WriteLine(shoppingList.Count);
        //    Console.WriteLine(shoppingList.Any());
        //}
    }
}
