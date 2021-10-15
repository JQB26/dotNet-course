using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Witcher_Negotiations
{
    internal class Program
    {
        private class Hero
        {
            public EHeroClass HeroClass { get; set; }

            public string HeroName { get; set; }

            public Hero(string heroName, EHeroClass heroClass)
            {
                HeroName = heroName;
                HeroClass = heroClass;
            }
        }

        private class NonPlayserCharacter
        {
            public string CharacterName { get; set; }

            public static NpcDialogPart StartTalking()
            {
                return new NpcDialogPart("First line", null);
            }

            public NonPlayserCharacter(string characterName)
            {
                CharacterName = characterName;
            }
        }

        private class NpcDialogPart
        {
            public string Line { get; set; }

            public List<HeroDialogPart> FollowingLines { get; set; }

            public NpcDialogPart(string line, List<HeroDialogPart> followingLines)
            {
                Line = line;
                FollowingLines = followingLines;
            }
        }

        private class HeroDialogPart
        {
            public string Line { get; set; }

            public NpcDialogPart FollowingLine { get; set; }

            public HeroDialogPart(string line, NpcDialogPart followingLine)
            {
                Line = line;
                FollowingLine = followingLine;
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
                var heroClass = EHeroClass.Barbarian;

                var correctName = false;
                var correctNameOption = true;
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
                    Console.WriteLine(heroName + " what is your class?");
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
                Console.WriteLine(_hero.HeroClass + " " + _hero.HeroName + " your adventure is beginning!");
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
        Barbarian,
        Paladin,
        Amazon
    }
}
