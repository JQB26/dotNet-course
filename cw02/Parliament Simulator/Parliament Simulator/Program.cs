using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Parliament_Simulator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Parliament parliament = new Parliament();
            parliament.VotingStarted += LogicOnVotingStarted;
            parliament.VotingStopped += LogicOnVotingStopped;
            parliament.VotingCompleted += LogicOnVotingCompleted;
            parliament.StartProcess();
        }

        private static void LogicOnVotingStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Voting Started");
        }

        private static void LogicOnVotingStopped(object sender, EventArgs e)
        {
            Console.WriteLine("Voting Stopped");
        }

        private static void LogicOnVotingCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Voting Completed");
        }
    }

    public delegate void Notify();

    public class Person
    {
        public event EventHandler<MyEventArgs> Voted;

        public int Id { get; set; }
        public bool CanIVote { get; set; }

        public Parliament Par {  get; set; }

        public virtual void Vote()
        {
            CanIVote = false;
            Random rnd = new();
            var res =  rnd.Next(2) == 0;
            Voted?.Invoke(this, new MyEventArgs() { Vote = res });
        }

        private void InitPerson()
        {
            Par.VotingStarted += LogicOnVotingStartedPer;
            Par.VotingStopped += LogicOnVotingStoppedPer;
        }

        public Person(int id, Parliament parliament)
        {
            Id = id;
            CanIVote = false;
            Par = parliament;
            InitPerson();
        }

        private void LogicOnVotingStartedPer(object sender, EventArgs e)
        {
            CanIVote = true;
        }

        private void LogicOnVotingStoppedPer(object sender, EventArgs e)
        {
            CanIVote = false;
        }


    }

    public class Parliament
    {
        public event EventHandler VotingStarted;
        public event EventHandler VotingStopped;
        public event EventHandler VotingCompleted;

        Collection<Person> people;

        private int numberOfVotingParliamentarians;
        private string votingTopic = "";
        private List<bool> votingResults;

        private VoteResult results;

        public void StartProcess()
        {
            VotingInit();
            while (true)
            {
                var line = Console.ReadLine();
                var command = line.Split(" ", 2);
                switch (command[0])
                {
                    case "POCZATEK":
                        votingTopic = command[1];
                        OnVotingStarted();
                        break;
                    case "GLOS":
                        if (people[short.Parse(command[1])].CanIVote)
                        {
                            people[short.Parse(command[1])].Vote();
                        }
                        break;
                    case "KONIEC":
                        Console.WriteLine("To get results from the last vote type: RESULTS");
                        OnVotingStopped();
                        break;
                    case "RESULTS":
                        PrintResults();
                        OnVotingCompleted();
                        Console.ReadKey();
                        VotingInit();
                        break;
                    case "EXIT":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void VotingInit()
        {
            Console.Clear();
            Console.WriteLine("Number of voting parliamentarians: ");
            numberOfVotingParliamentarians = Convert.ToInt32(Console.ReadLine());
            people = new Collection<Person>();
            votingResults = new List<bool>();
            for (int i = 0; i < numberOfVotingParliamentarians; i++)
            {
                var person = new Person(i, this);
                people.Add(person);
                person.Voted += GetVote;
            }
            Console.Clear();
            Console.WriteLine("To start a vote type: POCZATEK [voting topic]");
            Console.WriteLine("To end a vote type: KONIEC");
            Console.WriteLine("To vote type: GLOS [parliamentarian ID]");
            Console.WriteLine("To exit type: EXIT");
        }

        public virtual void OnVotingStarted()
        {
            VotingStarted?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnVotingStopped()
        {
            VotingStopped?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnVotingCompleted()
        {
            VotingCompleted?.Invoke(this, EventArgs.Empty);
        }

        private void GetVote(object sender, MyEventArgs e)
        {
            MyEventArgs args = e;
            votingResults.Add(args.Vote);
        }

        public void PrintResults()
        {
            var result = GetResults();
            Console.Clear();
            Console.WriteLine("Vote on: " + result.VotingTopic);
            Console.WriteLine("Votes for: " + result.VotesFor);
            Console.WriteLine("Votes against: " + result.VotesAgainst);
        }

        public VoteResult GetResults()
        {
            results = new VoteResult
            {
                VotingTopic = votingTopic,
                VotesFor = 0,
                VotesAgainst = 0
            };
            for (int i = 0; i < votingResults.Count; i++)
            {
                if (votingResults[i])
                {
                    results.VotesFor++;
                }
                else
                {
                    results.VotesAgainst++;
                }
            }
            return results;
        }
    }

    public class VoteResult
    {
        public string VotingTopic { get; set; }
        public int VotesFor { get; set; }
        public int VotesAgainst { get; set; }
    }

    public class MyEventArgs : EventArgs
    {
        public bool Vote { get; set; }
    }

}
