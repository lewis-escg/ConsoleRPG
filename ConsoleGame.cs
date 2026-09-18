using System;
using System.Threading;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        string transitionScreen1 = "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░/n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░";
        transitionScreen1 = transitionScreen1.Replace("/n", System.Environment.NewLine);

        string transitionScreen2 = "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒";
        transitionScreen2 = transitionScreen2.Replace("/n", System.Environment.NewLine);

        string transitionScreen3 = "▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓/n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓";
        transitionScreen3 = transitionScreen3.Replace("/n", System.Environment.NewLine);

        string transitionScreen4 = "████████████████████████████████████████/n████████████████████████████████████████/n████████████████████████████████████████/n████████████████████████████████████████/n████████████████████████████████████████/n████████████████████████████████████████/n████████████████████████████████████████/n████████████████████████████████████████/n████████████████████████████████████████/n████████████████████████████████████████";
        transitionScreen4 = transitionScreen4.Replace("/n", System.Environment.NewLine);

        Console.WriteLine(".");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("..");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("...");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("What is your name?");
        Thread.Sleep(1000);
        string inputtedname = Console.ReadLine();
        int nameLength = inputtedname.Length;
        string nameupper = inputtedname.ToUpper();
        string namelower = inputtedname.ToLower();
        string format1 = nameupper.Substring(0, 1);
        string format2 = namelower.Substring(1, nameLength - 1);
        string formattedName = ($"{format1}{format2}");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"Your name is {formattedName}.");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine($"Welcome, {formattedName}.");
        Thread.Sleep(2000);
        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine(transitionScreen1);
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine(transitionScreen2);
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine(transitionScreen3);
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine(transitionScreen4);
        Thread.Sleep(3000);
        Console.Clear();

        int playerlocation = 0;

        while (true)
        {
            ConsoleKeyInfo userkeyinput;
            char userinput;

            switch (playerlocation)
            {
                case 0:
                    Console.WriteLine("You reach a fork in the path. Continue forwards? (Y/N)");
                    userkeyinput = Console.ReadKey();
                    userinput = userkeyinput.KeyChar;
                    if (userinput.Equals('y'))
                    {
                        playerlocation = 1;
                    }
                    else if (userinput.Equals('n'))
                    {
                        playerlocation = 2;
                    }
                    else
                    {
                        playerlocation = 0;
                    }
                    Console.Clear();
                    break;
                case 1:
                    Console.WriteLine("You find a house. Enter? (Y) Or turn back? (N)");
                    userkeyinput = Console.ReadKey();
                    userinput = userkeyinput.KeyChar;
                    if (userinput.Equals('y'))
                    {
                        playerlocation = 3;
                    }
                    else if (userinput.Equals('n'))
                    {
                        playerlocation = 0;
                    }
                    else
                    {
                        playerlocation = 1;
                    }
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("You split off from the path and find a forest. It's too dangerous to continue at night. Head back? (Y/Y)");
                    userkeyinput = Console.ReadKey();
                    userinput = userkeyinput.KeyChar;
                    if (userinput.Equals('y'))
                    {
                        playerlocation = 0;
                    }
                    else if (userinput.Equals('n'))
                    {
                        playerlocation = 2;
                    }
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("You enter the house. There's nothing inside. Turn back? (Y/Y)");
                    userkeyinput = Console.ReadKey();
                    userinput = userkeyinput.KeyChar;
                    if (userinput.Equals('y'))
                    {
                        playerlocation = 1;
                    }
                    else if (userinput.Equals('n'))
                    {
                        playerlocation = 3;
                    }
                    Console.Clear();
                    break;
            }
        }

    }
}