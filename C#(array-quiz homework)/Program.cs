

using System;
using System.Security.Cryptography.X509Certificates;

string[,] arr = new string[10, 5]
{
    {"What is the capital of Japan?","Tokyo" ,"Beijing","Seoul","Bangkok"},
    {"Who wrote \"Harry Potter and the Philosopher's Stone\"?","J.R.R. Tolkien","J.K. Rowling","George R.R. Martin","Stephen King" },
    { "Who painted the famous artwork \"The Starry Night\"?","Vincent van Gogh","Leonardo da Vinci","Pablo Picasso","Claude Monet"},
    {"What is the chemical symbol for iron?","Fe","Na","Ag","Au" },
    {"Which planet is known as the \"Red Planet\"?","Venus","Mars","Saturn","Jupiter" },
    {"In c# programming language which of the followings is value type?","Enum","Class","Array","Delegate" },
    {"What is a constructor ?","A member function used to initialize objects of a class"," A function used to destruct objects of a class","A function used to allocate memory for objects","A member function used to perform arithmetic operations" },
    {"What is the highest mountain in the world?","Mount Kilimanjaro","Mount Everest"," K2"," Mount McKinley" },
    { "What is the capital of Azerbaijan?","Paris" ,"Baku","Istanbul","London"},
    { "Which is the longest river on the Earth?","Nile","Kongo","Amazon","Kur"}

};

string[] answers = new string[10]
{
    "Tokyo","J.K. Rowling","Vincent van Gogh","Fe","Mars","Enum","A member function used to initialize objects of a class","Mount Everest","Baku","Nile"
};


int select = 1;

do
{
    Console.Clear();
    printMenu(select);

    ConsoleKeyInfo info = Console.ReadKey(true);

    if (info.Key == ConsoleKey.DownArrow)
    {
        if (select == 2) select = 1;
        else
            select++;
    }

    else if (info.Key == ConsoleKey.UpArrow)
    {
        if (select == 1) select = 2;
        else
            select--;
    }

    else if (info.Key == ConsoleKey.Enter)
    {
        if (select == 1)  //new game
        {
            Console.Clear();
            QuizGame(arr, answers);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlease enter backspace button to back to main menu...");
            Console.ForegroundColor= ConsoleColor.White;
            while (info.Key != ConsoleKey.Backspace)
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Backspace)
                {
                    Console.Clear();
                    break;
                }

            }

        }


        else if (select == 2)  //exit
        {
            Console.Clear();
            Console.WriteLine("You are quitting game...");
            Thread.Sleep(500);
            break;
        }
    }

} while (true);


void Result(int correct,int incorrect,int total_point)
{
    Console.Clear();
    Console.WriteLine("~~~~~~~Results~~~~~~~~");
    Console.WriteLine("Correct: " + correct);
    Console.WriteLine("Incorrect: " + incorrect);

    if (total_point > 0)
        Console.WriteLine("Total points: " + total_point);
    else
        Console.WriteLine("total points: 0");
}


void QuizGame(string[,] arr, string[] answers)
{
    int correct = 0, incorrect = 0;
    int total_point = 0;
    int it = 0;
    int choice = 1;

    Random random = new Random();

    Shuffle(random, arr, it);
    do
    {
        Console.Clear();

        if (it == 10)
        {
            Result(correct, incorrect, total_point);  
            break;
        }

        Console.WriteLine(arr[it, 0]);
        printVariants(arr, choice, it);

        ConsoleKeyInfo button = Console.ReadKey(true);

        if (button.Key == ConsoleKey.DownArrow)
        {
            if (choice == 4) choice = 1;
            else
                choice++;
        }

        else if (button.Key == ConsoleKey.UpArrow)
        {
            if (choice == 1) choice = 4;
            else
                choice--;
        }

        else if (button.Key == ConsoleKey.Enter)
        {
            if (arr[it, choice] == answers[it])
            {
                correct++;
                it++;
                total_point += 10;
                if(it==10)
                {

                    Result(correct, incorrect, total_point);
                    break;
                }

                Shuffle(random,arr, it);
            }
            else
            {
                incorrect++;
                it++;
                total_point -= 10;
                if(it==10)
                {
                    Result(correct, incorrect, total_point);
                    break;
                }

                Shuffle(random, arr, it);
            }
        }



    } while (true);
}

void printVariants(string[,] arr, int choice, int it)
{


    for (int i = 1; i < 5; i++)
    {
        if (i == choice)
        {
            if (i == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"a){arr[it, i]}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (i == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"b){arr[it, i]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (i == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"c){arr[it, i]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (i == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"d){arr[it, i]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            if (i == 1)
                Console.WriteLine($"a){arr[it, i]}");

            else if (i == 2)
                Console.WriteLine($"b){arr[it, i]}");

            else if (i == 3)
                Console.WriteLine($"c){arr[it, i]}");

            else if (i == 4)
                Console.WriteLine($"d){arr[it, i]}");
        }
    }

}

void Shuffle(Random random,string[,] array, int it)
{
    int n = array.GetLength(1); 

  
    for (int i = 1; i < n; i++)
    {
        int k = random.Next(i, n); 
        string temp = array[it, i];
        array[it, i] = array[it, k]; 
        array[it, k] = temp; 
    }
}



void printMenu(int select)
{
    string[] menu = new string[] { "Quiz Game", "Exit" };


    Console.WriteLine("\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~");
    for (int i = 0; i < menu.Length; i++)
    {
        if (i == select - 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t\t\t=>{menu[i]}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
            Console.WriteLine($"\t\t\t\t{menu[i]}");
    }
    Console.WriteLine("\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~");

}
