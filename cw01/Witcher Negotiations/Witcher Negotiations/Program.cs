using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Witcher_Negotiations
{
    internal class Program
    {
        private class Location
        {
            private Hero Hero { get; set; }

            public Location(string locationName)
            {
                LocationName = locationName;
                NonPlayerCharacters = new List<NonPlayerCharacter>();
            }

            private List<NonPlayerCharacter> NonPlayerCharacters { get; }

            private string LocationName { get; }

            private static void TalkTo(NonPlayerCharacter npc, Hero hero)
            {
                npc.StartTalking(hero);
            }

            private void AddNpc(NonPlayerCharacter nonPlayerCharacter)
            {
                NonPlayerCharacters.Add(nonPlayerCharacter);
            }

            public void AddNpcs(List<NonPlayerCharacter> nonPlayerCharacters)
            {
                foreach (var npc in nonPlayerCharacters)
                {
                    AddNpc(npc);
                }
            }

            public void PrintWelcome(Hero hero)
            {
                Hero = hero;
                var correctAction = false;
                Console.Clear();
                while (!correctAction)
                {
                    Console.WriteLine($"You're in: {LocationName}. What do you wanna do?");
                    var i = 0;
                    foreach (var npc in NonPlayerCharacters)
                    {
                        Console.WriteLine("[" + i + "] Talk to " + npc.Name);
                        i++;
                    }
                    Console.WriteLine("[X] Close the program");

                    var option = Console.ReadLine();
                    if (option == "X")
                    {
                        Environment.Exit(0);
                    }
                    for (var j = 0; j < i; j++)
                    {
                        if (option != j.ToString()) continue;
                        TalkTo(NonPlayerCharacters[j], Hero);
                        correctAction = true;
                    }

                    if (!correctAction)
                    {
                        PrintSelectValidOption();
                    }
                }

            }

            private static void PrintSelectValidOption()
            {
                Console.Clear();
                Console.WriteLine("Select valid option");
                Console.WriteLine("====================");
            }

        }
        
        private class NonPlayerCharacter
        {
            public string Name { get; }
            private Dialogs Dialogs { get; }

            public void StartTalking(Hero hero)
            {
                Dialogs.StartTalking(hero);
            }

            public NonPlayerCharacter(string name, uint number, Hero hero)
            {
                this.Name = name;
                Dialogs = new Dialogs();
                switch (number)
                {
                    case 1:
                        Dialogs.GenerateNpc1();
                        break;
                    case 2:
                        Dialogs.GenerateNpc2();
                        break;
                }
            }
        }
        
        private class NpcDialogPart : IDialogPart
        {
            public NpcDialogPart()
            {
            }

            public NpcDialogPart(string line, List<HeroDialogPart> possibleHeroDialogParts)
            {
                Line = line;
                PossibleHeroDialogParts = possibleHeroDialogParts;
            }

            private string Line { get; }

            public List<HeroDialogPart> PossibleHeroDialogParts { get; }
            public string GetLine()
            {
                return Line;
            }
        }
        
        private class HeroDialogPart : IDialogPart
        {
            private string Line { get; }
            public NpcDialogPart FollowingNpcDialogPart { get; }

            public HeroDialogPart(string line, NpcDialogPart followingNpcDialogPart)
            {
                Line = line;
                FollowingNpcDialogPart = followingNpcDialogPart;
            }

            public string GetLine()
            {
                return Line;
            }
        }

        public interface IDialogPart
        {
            public string GetLine();
        }

        private class DialogParser
        {
            private Hero Hero { get; }

            public string ParseDialog(IDialogPart dialog)
            {
                var line = dialog.GetLine();
                var parts = line.Split("#HERONAME#");
                var result = "";
                for (var i = 0; i < parts.Length; i++)
                {
                    result += parts[i];
                    if (i != parts.Length - 1)
                    {
                        result += Hero.HeroName;
                    }
                }

                return result;
            }

            public DialogParser(Hero hero)
            {
                Hero = hero;
            }
        }

        private class Dialogs
        {

            private NpcDialogPart ConversationStarter { get; set; }

            private NpcDialogPart AddNpcDialog(string line, List<HeroDialogPart> possibleHeroDialogParts)
            {
                var npcDialog = new NpcDialogPart(line, possibleHeroDialogParts);
                return npcDialog;
            }

            private HeroDialogPart AddHeroDialog(string line, NpcDialogPart followingNpcDialogPart)
            {
                var heroDialog = new HeroDialogPart(line, followingNpcDialogPart);
                return heroDialog;
            }

            public void StartTalking(Hero hero)
            {
                var nextPartNpc = ConversationStarter;
                HeroDialogPart nextPartHero = null;

                var dialogParser = new DialogParser(hero);

                var correctOption = false;
                Console.Clear();
                while (true)
                {
                    while (!correctOption)
                    {
                        {
                            var options = nextPartNpc.PossibleHeroDialogParts;

                            Console.WriteLine(dialogParser.ParseDialog(nextPartNpc));
                            var i = 0;
                            if (options != null)
                            {
                                foreach(var dialog in options)
                                {
                                    Console.WriteLine("[" + i + "] " + dialogParser.ParseDialog(dialog));
                                    i++;
                                }
                            }
                            

                            if (i == 0)
                            {
                                return;
                            }

                            var select = Console.ReadLine();
                            for (var j = 0; j < i; j++)
                            {
                                if (@select != j.ToString()) continue;
                                if (options != null) nextPartHero = options[j];
                                correctOption = true;
                                break;
                            }

                            if (!correctOption)
                            {
                                PrintSelectValidOption();
                            }
                        }
                    }


                    if (nextPartHero != null) nextPartNpc = nextPartHero.FollowingNpcDialogPart;
                    if (nextPartNpc == null)
                    {
                        return;
                    }

                    Console.Clear();
                    correctOption = false;
                }
                
            }

            private static void PrintSelectValidOption()
            {
                Console.Clear();
                Console.WriteLine("Select valid option");
                Console.WriteLine("====================");
            }

            public void GenerateNpc2()
            {
                var temp1 = new List<HeroDialogPart>();
                var npc1 = AddNpcDialog("Okay! #HERONAME# your fight is about to begin!", null);
                var hero1 = AddHeroDialog("It's not enough. Give me 75$ and I'll fight right now", npc1);
                var hero2 = AddHeroDialog("Then I accept the challenge", npc1);
                var hero3 = AddHeroDialog("I don't have time to fight for such a small stake. Goodbye", null);
                temp1.Add(hero1);
                temp1.Add(hero2);
                temp1.Add(hero3);
                var npc2 = AddNpcDialog("For winning one fight, you get 50$", temp1);

                var temp2 = new List<HeroDialogPart>();
                var hero4 = AddHeroDialog("Of course! What can I win?", npc2);
                var hero5 = AddHeroDialog("No, bye", null);
                temp2.Add(hero4);
                temp2.Add(hero5);
                var npc3 = AddNpcDialog("We're looking for fist fighters. Would you be interested?", temp2);

                var temp3 = new List<HeroDialogPart>();
                var hero6 = AddHeroDialog("Yes, it's me. What's going on?", npc3);
                var hero7 = AddHeroDialog("Yes, but I don't have time to talk", npc3);
                temp3.Add(hero6);
                temp3.Add(hero7);
                var npc4 = AddNpcDialog("Hello, are you the famous #HERONAME#?", temp3);

                ConversationStarter = npc4;

            }

            public void GenerateNpc1()
            {
                var temp1 = new List<HeroDialogPart>();
                var npc1 = AddNpcDialog("Thank you #HERONAME#!", null);
                var hero1 = AddHeroDialog("Than do it on your own, bye", null);
                var hero2 = AddHeroDialog("Ok, I can do it for a 100$", npc1);
                temp1.Add(hero1);
                temp1.Add(hero2);
                var npc2 = AddNpcDialog("Sorry, that's all the money that I have #HERONAME#. " +
                                      "Please, could you do it for 100$?", temp1);

                var temp2 = new List<HeroDialogPart>();
                var hero3 = AddHeroDialog("100$ is not enough!", npc2);
                var hero4 = AddHeroDialog("I'll let you know when I'm ready", null);
                temp2.Add(hero3);
                temp2.Add(hero4);
                var npc3 = AddNpcDialog("Awesome, I can give you 100$ for that job", temp2);

                var temp3 = new List<HeroDialogPart>();
                var hero5 = AddHeroDialog("Yes. I'd love to help you", npc3);
                var hero6 = AddHeroDialog("No, I won't help you, bye", null);
                temp3.Add(hero5);
                temp3.Add(hero6);
                var npc4 = AddNpcDialog("Hello, could you help me? I'm having a problem with a weird creatures. " +
                                        "I've already lost 3 horses because of that.", temp3);
                
                ConversationStarter = npc4;
            }

            public Dialogs()
            {
                ConversationStarter = new NpcDialogPart();
            }
        }
        
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
            private static Hero _hero;

            public Location Location { get; }

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
                            Environment.Exit(0);
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
                        Console.WriteLine("[" + i + "] " + clazz);
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

            public static void PrintWelcome()
            {
                Console.Clear();
                Console.WriteLine(_hero.HeroName + " from the " + _hero.HeroClass + "'s school, your adventure is beginning!");
            }

            public static void ShowLocation(Location location)
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    location.PrintWelcome(_hero);
                }
            }

            private static List<NonPlayerCharacter> GenerateCharacters()
            {
                var result = new List<NonPlayerCharacter>
                {
                    new("Old gentleman", 1, _hero),
                    new("Bookmaker", 2, _hero)
                };
                return result;
            }

            public Game(string locationName)
            {
                Location = new Location(locationName);
                Location.AddNpcs(GenerateCharacters());
                _hero = new Hero("notSet", EHeroClass.Cat);
            }

        }

        private static void Main()
        {
            var game = new Game("Novigrad");
            game.StartGame();
            Game.PrintWelcome();
            Game.ShowLocation(game.Location);
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
