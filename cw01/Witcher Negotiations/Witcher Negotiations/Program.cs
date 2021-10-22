using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Witcher_Negotiations
{
    internal class Program
    {
        /*
        private class NonPlayerCharacter
        {
            public string Name { get; }

            public NpcDialogPart StartTalking()
            {

            }



            public NonPlayerCharacter(string name)
            {
                this.Name = name;
            }
        }

        private class NpcDialogPart
        {
            public string Line { get; }
            public List<HeroDialogPart> PossibleHeroDialogParts { get; }

            public NpcDialogPart(string line, List<HeroDialogPart> possibleHeroDialogParts)
            {
                this.Line = line;
                this.PossibleHeroDialogParts = possibleHeroDialogParts;
            }
        }

        private class HeroDialogPart
        {
            public string Line { get; }
            public NpcDialogPart FollowingNpcDialogPart { get; }

            public HeroDialogPart(string line, NpcDialogPart followingNpcDialogPart)
            {
                this.Line = line;
                this.FollowingNpcDialogPart = followingNpcDialogPart;
            }
        }

        private class Dialogs
        {
            public HeroDialogPart[] HeroDialogParts { get; }
            public NpcDialogPart[] NpcDialogParts { get; }


            public Dialogs()
            {
                
            }
        }
        */
        private class Hero
        {
            public EHeroClass HeroClass { get; }

            public string HeroName { get; }

            public Hero(string heroName, EHeroClass heroClass)
            {
                this.HeroName = heroName;
                this.HeroClass = heroClass;
            }
        }

        private class Game
        {
            private Hero _hero;

            public void StartGame()
            {
                var showMenu = true;
                while (showMenu)
                {
                    Console.WriteLine("Welcome to The Witcher Negotiations!");
                    Console.WriteLine("[1] Start a new game");
                    Console.WriteLine("[X] Close the program");


                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            _hero = CreateHero();
                            showMenu = false;
                            break;
                        case "X":
                            System.Environment.Exit(0);
                            break;
                        default:
                            PrintSelectValidOption();
                            break;
                    }
                }
            }

            private static Hero CreateHero()
            {
                var heroName = "";
                var heroClass = EHeroClass.Wolf;

                var correctName = false;
                var correctNameOption = true;
                Console.Clear();
                while (!correctName)
                {
                    if (correctNameOption)
                    {
                        Console.WriteLine("Choose a name for your Witcher:");

                        heroName = Console.ReadLine();
                        heroName = RemoveSpecialCharacters(heroName);
                        Console.Clear();
                    }

                    if (heroName.Length > 2)
                    {
                        Console.WriteLine("Your name will be: " + heroName);
                        Console.WriteLine("Do you want to continue with that name?");
                        Console.WriteLine("[1] Yes");
                        Console.WriteLine("[2] No");

                        var option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                correctName = true;
                                correctNameOption = true;
                                break;
                            case "2":
                                Console.Clear();
                                correctNameOption = true;
                                continue;
                            default:
                                correctNameOption = false;
                                PrintSelectValidOption();
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Select valid name");
                        Console.WriteLine("====================");
                    }

                }

                var correctClass = false;
                Console.Clear();
                while (!correctClass)
                {
                    Console.WriteLine(heroName + " what is your school?");
                    var classes = (EHeroClass[])Enum.GetValues(typeof(EHeroClass));
                    var i = 0;
                    foreach (var clazz in classes)
                    {
                        Console.WriteLine("[" + i + "] " + clazz.ToString());
                        i++;
                    }

                    var option = Console.ReadLine();
                    for (var j = 0; j < i; j++)
                    {
                        if (option == j.ToString())
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
                var sb = new StringBuilder();
                foreach (var c in str.Where(c => c is (>= 'A' and <= 'Z') or (>= 'a' and <= 'z') or ' '))
                {
                    sb.Append(c);
                }
                var result = sb.ToString().Trim();
                result = Regex.Replace(result, @"\s+", " ");
                return result;
            }

            private static void PrintSelectValidOption()
            {
                Console.Clear();
                Console.WriteLine("Select valid option");
                Console.WriteLine("====================");
            }

            public void PrintWelcome()
            {
                Console.Clear();
                Console.WriteLine(_hero.HeroName + " from the " + _hero.HeroClass + "'s school, your adventure is beginning!");
            }
        }

        private static void Main()
        {
            var game = new Game();
            game.StartGame();
            game.PrintWelcome();
        }
    }

    

    public enum EHeroClass
    {
        Wolf,
        Cat,
        Griffin,
        Bear,
        Viper,
        Manticore,
        Crane
    }
}
