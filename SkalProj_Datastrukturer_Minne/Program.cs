using System;
using System.Collections.Generic;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();
            while (true)
            {

                Console.WriteLine("Enter a +Name to add a new name, -Name to remove a Name, or Exit to return to the Main Menu!");
                string input = Console.ReadLine();
                // adding some validation for the input 
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please add an invalid input!");
                    continue;
                }
                else if (input.ToLower() == "exit")
                {
                    break;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Name {value} is added to the list");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Name {value} is removed from the list");
                        break;
                    default :
                        Console.WriteLine("Please enter + or - to add/remove a name!");
                        break;
                }
                Console.WriteLine($"The list contains {theList.Count} number of values and {theList.Capacity} of the whole capacity");
            }

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            List<string> customers= new List<string>() { "Ole","Kalle","Nalle", "Emma", "Daniel", "Anna"};
            List<string> queue = new List<string>();
            int customerIndex = 0;
            Console.WriteLine("Ica opens and the cash register and it is empty. Press 1/ to add to the queue and 2/ to remove from the queue");
            
            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;

              

                    switch (input) 
                    {
                        case "1":
                            Console.WriteLine(customers[customerIndex] + " enteres the queue.");
                            queue.Add(customers[customerIndex]);
                            customerIndex++;
                        break;

                        case "2":
                        if (queue.Count>0)
                        {
                            string firstIn = queue[0]; //the first customer in the queue if the list is not null
                            queue.RemoveAt(0);
                            Console.WriteLine( firstIn + " leaves the queue.");

                        }
                        break;
                        default:
                            Console.WriteLine("Invalid input. Use 1, 2, or 'exit'.");
                            break;

                    }

                


            }

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            List<string> customers = new List<string>() { "Ole", "Kalle", "Nalle", "Emma", "Daniel", "Anna" };
            Stack<string> stack = new Stack<string>();
    
            int customerIndex = 0;
            Console.WriteLine("Ica opens and the cash register and it is empty. Press 1/ to add to the queue and 2/ to remove 3/reverse from the queue");

            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;



                switch (input)
                {
                    case "1":
                        Console.WriteLine(customers[customerIndex] + " enteres the queue.");
                        stack.Push(customers[customerIndex]);
                        customerIndex++;
                        Console.WriteLine("The queue contains: " + string.Join(" , ", stack));
                        break;

                    case "2":
                        
                        
                        var lastIn=stack.Pop();
                        Console.WriteLine(lastIn + " leaves the queue.");
                        //customerIndex--; // It shows that the customer once removed can enter the queue again. 
                        break;
                    case "3":
                        Console.WriteLine("Choose a name from the list to reverse: " + string.Join(", ", customers));
                        string name = Console.ReadLine().Trim();

                        if (!customers.Contains(name))
                        {
                            Console.WriteLine("Please enter a name from the list.");
                            break;
                        }

                        Stack<char> nameChar= new Stack<char>();
                        foreach (char c in name)
                        { 
                        nameChar.Push(c);
                        }
                        string reversedName = new string(nameChar.ToArray());
                        Console.WriteLine($"The reversed name is: {reversedName} " );
                        break;
                    default:
                        Console.WriteLine("Invalid input. Use 1, 2, 3 or 'exit'.");
                        break;

                }





            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Console.WriteLine("Write a string to check if the parantesis are wellformed ");
            string input = Console.ReadLine();
            List<char>charOpen=new List<char>{ '{', '[', '(' };
            List<char> charClose = new List<char> { '}', ']', ')' };


            // case { } 
            if (input != null && input.Contains('{'))
            {
                bool includesClosing = input.Contains('}');
                bool closingComesAfter = input.IndexOf('{') < input.IndexOf('}');
                bool balancedCount = input.Count(c => c == '{') == input.Count(c => c == '}');

                if (includesClosing && closingComesAfter && balancedCount)
                {
                    Console.WriteLine("Correct use of {}");
                }
                else { Console.WriteLine("Incorrect use of parentasis"); }
            }

            // case [ ]
            if (input.Contains('['))
            {
                bool includesClosing = input.Contains(']');
                bool closingComesAfter = input.IndexOf('[') < input.IndexOf(']'); //checks if the closing parentasis comes after the opening one
                bool balancedCount = input.Count(c => c == '[') == input.Count(c => c == ']');

                if (includesClosing && closingComesAfter && balancedCount)
                {
                    Console.WriteLine("Correct use of []");
                }
                else { Console.WriteLine("Incorrect use of parentasis"); }
            }
            // case ( )
            if (input.Contains('('))
            {
                bool includesClosing = input.Contains(')');
                bool closingComesAfter = input.IndexOf('(') < input.IndexOf(')'); //checks if the closing parentasis comes after the opening one
                bool balancedCount = input.Count(c => c == '(') == input.Count(c => c == ')');

                if (includesClosing && closingComesAfter && balancedCount)
                {
                    Console.WriteLine("Correct use of ()");
                }
                else { Console.WriteLine("Incorrect use of parentasis"); }
            }
        }
    }
}

