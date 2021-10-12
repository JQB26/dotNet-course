using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Wiedzminskie_Negocjacje
{
    internal class Program
    {

        class Hero
        {
            private string heroName;
            private EHeroClass heroClass;

            public Hero(string heroName, EHeroClass heroClass)
            {
                this.HeroName = heroName;
                this.HeroClass = heroClass;
            }

            public EHeroClass HeroClass { get => heroClass; set => heroClass = value; }
            public string HeroName { get => heroName; set => heroName = value; }
        }

        class Game
        {
            Hero hero;

            public void StartGame()
            {
                bool showMenu = true;
                while (showMenu)
                {
                    Console.WriteLine("Witaj w grze Wiedmińskie Negocjacje");
                    Console.WriteLine("[1] Zacznij nową grę");
                    Console.WriteLine("[X] Zamknij program");


                    string option = Console.ReadLine();

                    if (option == "1")
                    {
                        hero = CreateHero();
                        showMenu = false;
                    }
                    else if (option == "X")
                    {
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        PrintSelectValidOption();
                    }
                }
            }

            public Hero CreateHero()
            {
                string heroName = "";
                EHeroClass heroClass = EHeroClass.Barbarzynca;

                bool correctName = false;
                bool correctNameOption = true;
                Console.Clear();
                while (!correctName)
                {
                    if (correctNameOption)
                    {
                        Console.WriteLine("Choose a name for your hero:");

                        heroName = Console.ReadLine();
                        heroName = RemoveSpecialCharacters(heroName);
                        Console.Clear();
                    }

                    if(heroName.Length > 2)
                    {
                        Console.WriteLine("Your name will be: " + heroName);
                        Console.WriteLine("Do you want to continue with that name?");
                        Console.WriteLine("[1] Yes");
                        Console.WriteLine("[2] No");

                        string option = Console.ReadLine();
                        if (option == "1")
                        {
                            correctName = true;
                            correctNameOption = true;
                        }
                        else if (option == "2")
                        {
                            Console.Clear();
                            correctNameOption = true;
                            continue;
                        }
                        else
                        {
                            correctNameOption = false;
                            PrintSelectValidOption();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Select valid name");
                        Console.WriteLine("====================");
                    }

                }
                
                bool correctClass = false;
                Console.Clear();
                while (!correctClass)
                {
                    Console.WriteLine(heroName + " what is your class?");
                    EHeroClass[] classes = (EHeroClass[])Enum.GetValues(typeof(EHeroClass));
                    int i = 0;
                    foreach (EHeroClass clazz in classes)
                    {
                        Console.WriteLine("[" + i + "] " + clazz.ToString());
                        i++;
                    }

                    string option = Console.ReadLine();
                    for(int j = 0; j < i; j++)
                    {
                        if(option == j.ToString())
                        {
                            heroClass = classes[j];
                            correctClass = true;
                        }
                    }
                    if (!correctClass)
                    {
                        PrintSelectValidOption();
                    }
                    
                }

                return new Hero(heroName, heroClass);

            }

            private static string RemoveSpecialCharacters(string str)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in str)
                {
                    if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c == ' '))
                    {
                        sb.Append(c);
                    }
                }
                string result = sb.ToString().Trim();
                result = Regex.Replace(result, @"\s+", " ");
                return result;
            }

            private static void PrintSelectValidOption()
            {
                Console.Clear();
                Console.WriteLine("Select valid option");
                Console.WriteLine("====================");
            }

            public void PrintHero()
            {
                Console.Clear();
                Console.WriteLine("Your name is: " + hero.HeroName);
                Console.WriteLine("Your class is: " + hero.HeroClass);
            }

            public void PrintWelcome()
            {
                Console.Clear();
                Console.WriteLine(hero.HeroClass + " " + hero.HeroName + " your adventure is beginning!");
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
            game.PrintWelcome();
        }
    }

    public enum EHeroClass
    {
        Barbarzynca,
        Paladyn,
        Amazonka
    }
}
