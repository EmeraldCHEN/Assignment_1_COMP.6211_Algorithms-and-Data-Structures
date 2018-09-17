using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Developer : Yuan Chen (Emerald)

// Student ID: 27-044-044

// This program will obtain an infix expression from the user and create the postfix to output it to the console screen

namespace Question_2__Assignment_1_Collections
{
    class Program
    {
        // Create a Queue to store Postfix expression
        public static Queue Postfix = new Queue();

        static void Main(string[] args)
        {
            //Prompt the user to enter an infix expression 
            Console.Write("\n Please enter an infix arithmetic expression (containing single digit integers only) : ");

            // Assume it is a valid expression and obtain it as a string
            string input = Console.ReadLine();
            Console.WriteLine("\n Infix  : " + input);

            // First sep up 1: append a right parenthesis to the end of the entered infix 
            List<char> inputChar = input.ToList();
            inputChar.Add(')');

            //Push each char one by one into a Stack named reversedInput
            Stack reversedInput = new Stack();
            foreach (char i in inputChar)
            {
                reversedInput.Push(i);
            }
            // Push the reversedInput one by one to a new Stack name Input
            Stack Input = new Stack();
            while (reversedInput.Count != 0)
            {
                Input.Push(reversedInput.Pop());
            }
            // Create a new Stack named temp to store operators during the process
            Stack temp = new Stack();

            // First sep up 2: push a left parenthesis onto the temp stack     
            temp.Push('(');

            // Call Conversion method 
            Conversion(temp, Input);
           
            Queue newPostfix = new Queue();
            for (int i = 0; i <= Postfix.Count*20; i++)          
            {   
                // delete '(' if any
                if ((char)Postfix.Peek() != '(')
                {
                    newPostfix.Enqueue(Postfix.Dequeue());
                }
                else 
                {
                    Postfix.Dequeue();                 
                }
            }
            Console.Write("\nPostfix : ");
            foreach (char element in newPostfix)
            {
                Console.Write(element);
            }
            Console.ReadKey();
        }
        // Conversion method to convert the infix expression to postfix using a Stack
        public static void Conversion(Stack temp, Stack Input)
        {
            while (temp.Count > 0 && Input.Count > 0)  
            {
                // Read the entered infix from left to right
                char peek = (char)Input.Peek();
                char tempPeek = (char)temp.Peek();

                bool isAnOp = IsOperator(peek);
                bool tempIsAnOp = IsOperator(tempPeek);
                // If the current character in entered infix is a digit, append it to Queue Postfix 
                if ((!isAnOp) && peek != '(' && peek != ')')
                {
                    Postfix.Enqueue(Input.Pop());
                }
                // If the current character in entered infix is '(', push it to temp Stack
                else if (peek == '(')
                {
                    temp.Push(Input.Pop());
                }
                // Call IsOperator method again to check if the current character in entered infix is an operater 
                // If it is true... 
                else if (isAnOp)
                {
                    // And if the top character of the temp Stack is also an operator
                    if (tempIsAnOp)
                    {
                        // Pop operators at the top of temp Stack 
                        // while they have equal or higher precdence than the current operator of the entered infix

                        if (OpPrecedence(peek, tempPeek))  // Call OpPrecedence method 
                        {
                            // Append the poped operators to Postfix Queue
                            Postfix.Enqueue(temp.Pop());
                            // And then push that operator to temp Stack
                            temp.Push(Input.Pop());
                        }
                        else
                        {
                            temp.Push(Input.Pop());
                        }                                                       
                    }
                    else if (tempPeek == '(')
                    {
                        // push the poped operators to temp stack
                        temp.Push(Input.Pop());
                    }
                }
                // If the current character in entered infix is ')'
                else if (peek == ')')
                {
                    // Append the poped operators from the top of temp Stack to Postfix
                    // untill '(' is at the top of temp Stack                    
                    while (temp.Count > 0)
                    {
                        while (tempPeek == '(' && temp.Count > 0)
                        {
                            temp.Pop();
                            break;
                        }
                        if (tempPeek != '(')
                        {
                            Postfix.Enqueue(temp.Pop());
                            Postfix.Enqueue(temp.Pop());
                            break;
                        }
                        else // Pop '(' from the temp Stack
                        {
                            temp.Pop();
                        }
                    } 
                    // delete ')'
                    Input.Pop();
                }
            }
        }
       // OpPrecedence method to determine whether operator2(from the stack) has higher or equal precedence to operator1(from the infix expression).
        public static bool OpPrecedence(char operator1, char operator2)
        {
                // Returns true if operator2 has higher or equal precedence to operator1
                // i.e. operator2 is '+','-','*' or '/' while operator1 is '+' or '-'
                if (operator1 == '+' || operator1 == '-')
                {
                    return true;
                }
                else
                {
                    // Returns true if operator2 has equal precedence to operator1
                    // i.e. operator2 is '*' or '/' while operator1 is '*' or '/'
                    if (operator2 == '*' || operator2 == '/')
                        return true;
                    else
                        return false; // Return false if opposite to above
                }
        }
        // IsOperator method to determine whether a character is an operator
        public static bool IsOperator(char element)
        {
                if (element == '+' || element == '-' || element == '*' || element == '/')
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
    }
    
}
// Retrieved from https://www.youtube.com/watch?v=OVFwgYrMShw