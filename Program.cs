using System;
using System.Collections.Generic;
using Note.BusinessDataLogic;

internal class Program
{

    static string[] actions = new string[] { "[1] Add Note", "[2] Remove Note", "[3] View All Notes", "[4] Exit" };

    static void Main(string[] args)
    {
        string name = GetName();
        DisplayName(name);

        while (true)
        {
            DisplayActions(name);
            int userInput = GetUserInput();

            switch (userInput)
            {
                case 1:
                    Console.Write("What's on your mind? \n \t");
                    string note = Console.ReadLine();
                    if (NoteProcess.UpdateNotes(Actions.AddNote, note))
                    {
                        Console.WriteLine("Got it!");
                    }
                    break;

                case 2:
                    if (!NoteProcess.HasNotes())
                    {
                        Console.WriteLine("No notes to delete.");
                        break;
                    }

                    ShowNotes();
                    Console.WriteLine("Which number of the note do you want to delete: ");
                    string input = Console.ReadLine();
                    if (NoteProcess.UpdateNotes(Actions.DeleteNote, input))
                    {
                        Console.WriteLine("Note deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid note number.");
                    }
                    break;

                case 3:
                    ShowNotes();
                    break;

                case 4:
                    ExitInvalid(userInput);
                    Environment.Exit(0);
                    break;

                default:
                    ExitInvalid(userInput);
                    break;
            }

        }
    }

    static void DisplayActions(string name)
    {
        Console.WriteLine("================");
        Console.WriteLine("What would you like to do, " + name + "?");

        foreach (var action in actions)
        {
            Console.WriteLine(action);
        }
    }

    static void ShowNotes()
    {
        if (!NoteProcess.HasNotes())
        {
            Console.WriteLine("No notes");
        }
        else
        {
            List<string> notes = NoteProcess.GetNotes();
            Console.WriteLine("Your notes:");
            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + notes[i]);
            }
        }


    }



    static int GetUserInput()
    {
        while (true)
        {
            Console.Write("[User Input]: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int userInput))
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
    }

    static void DisplayName(string name)
    {
        Console.WriteLine("Good day! " + name);
    }

    static string GetName()
    {
        Console.WriteLine("Hello, this is a note-taking program.");
        Console.WriteLine("What is your name?");
        return Console.ReadLine();
    }

    static void ExitInvalid(int? userAction)
    {
        if (userAction == 4)
        {
            Console.WriteLine("CLOSING PROGRAM...");
        }
        else
        {
            Console.WriteLine("Invalid option. Please choose again.");
        }
    }
}
//trtrsfsdf