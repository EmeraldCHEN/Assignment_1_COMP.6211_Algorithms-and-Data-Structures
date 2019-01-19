using System;
using System.Collections;

/* Developer : Yuan Chen (Emerald)

 This program will obtain a word or sentence from the user, then the input will be displayed back to the screen in reverse without any space

 If the user presses the backspace key, the last entered character will be deleted from the console screen  */

namespace Question_1__Assignment_1_Collections
{
    class Program
    {
        // Stack declaration
        public static Stack inputStack = new Stack();

        static void Main(string[] args)
        {
            // Prompt the user for input and obtain it as an string
            Console.Write("\n Please type in a word or sentence: ");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            string input = Console.ReadLine();
            Console.ResetColor();
            char[] inputChar = input.ToCharArray();

            // and then push each character of that string onto a stack until a full stop is entered                        
            for (int i = 0; i < inputChar.Length; i++)
            {
                    // Only push the character onto a stack if the character is NOT a space, so the stack contains no spaces or full stop             
                    if (inputChar[i] != ' ')
                    {
                        inputStack.Push(inputChar[i]);
                    }
                    if (inputChar[i] == '.')
                    {
                        inputStack.Pop();
                        break;
                    }
            }
            Console.WriteLine("\n Your input (before full stop if any) in reverse order without any space is: \n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (object o in inputStack)
            {
                Console.Write(o);
            }
            Console.ResetColor();
            Console.WriteLine("\n\n If you press Backspace key, the last character (before full stop if any) will be deleted. \n");
            Console.WriteLine(" Delete the last character -- Press Backspace\n Exit -- Press Enter");

            // Call the Undo method if the user presses the backspace key, 
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Backspace)   // Retrieved from : https://www.c-sharpcorner.com/forums/how-can-perform-a-event-on-key-press-in-console-c-sharp
            { 
                Undo();
            }         
            Console.ReadKey();            
        }
        // Undo method to delete the last entered character if the user presses the backspace key  O(∩_∩)O~ 
        public static void Undo()
        {
            // Use the Pop() method to remove the value that was added last to the Stack          
            inputStack.Pop();
            Console.WriteLine("\n Deleting......");
            Console.Write("\n There you go:  ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (object o in inputStack)
            {
                Console.Write(o);
            }
        }
    }
}









