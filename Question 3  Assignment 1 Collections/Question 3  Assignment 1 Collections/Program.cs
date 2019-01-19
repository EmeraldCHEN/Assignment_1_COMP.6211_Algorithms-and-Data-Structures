using System;                                   
using System.Collections;

// Developer : Yuan Chen (Emerald) 

// This program containing a generic class (“MyQueue”) that has 3 methods to simulate those of a queue while using an Array List instead of a Queue -_-||

namespace Question_3__Assignment_1_Collections
{
    class Program
    {
        static void Main(string[] args)  
        {
            GClass<string> iceCream = new GClass<string>();

            // Call the PopulateArrayList method to display the list
            iceCream.PopulateArrayList();
            
            Console.WriteLine("\n\tHi there :)   We've got 3 flavors of ice cream :\n ");

            // Call the PrintQueue method to display the  list
            Console.ForegroundColor = ConsoleColor.Cyan;
            iceCream.PrintQueue();
            Console.ResetColor();

            Console.Write("\n\tPlease type in another flavor you like for ice cream : ");
            string newFlavor = Console.ReadLine();
            Console.WriteLine("\n\tAdding the flavor you like ...... Thank you for your patience :)");
            Console.WriteLine("\n\tPress ENTER to see the updated menu :)\n");

            // Call the Enqueue method to add the entered flavor to the end of the list
            iceCream.Enqueue(newFlavor);

            ConsoleKeyInfo press = Console.ReadKey();       
                   
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Call the PrintQueue method to display the updated list
            iceCream.PrintQueue(); 
            Console.ResetColor();

            Console.WriteLine("\n\n\t... Oh sorry :(    The first flavor is not available anymore. Removing it......\n ");

            // Call the Dequeue method to removes the first item from the front 
            iceCream.Dequeue();
            Console.WriteLine("\n\tPress ENTER to see the most updated menu :)\n");
            ConsoleKeyInfo pressAgain = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;

            // Call the PrintQueue method to display the most updated list
            iceCream.PrintQueue();

            Console.ReadKey();
        }
    }
    // Create a generic class 
    class GClass<T>
    {
        ArrayList anArrayList = new ArrayList();

        // PopulateArrayList method to populate the ArrayList
        public void PopulateArrayList()
        {
            anArrayList.Add("Chocolate");
            anArrayList.Add("Greentea");
            anArrayList.Add("Blueberry");
        }
        // PrintQueue method to displays the contents of the "Queue"
        public void PrintQueue()
        {
            foreach (T element in anArrayList)
            {
                Console.Write("\t" + element);
            }
            Console.WriteLine();
        }
        // Enqueue method to add an object to the back of the "Queue"
        public void Enqueue(T newFlavor)
        {
           anArrayList.Add(newFlavor);
        }     
        // Dequeue method to removes the object from the front of the "Queue"
        public void Dequeue()
        {
            anArrayList.RemoveAt(0);
        }    
    }
}
